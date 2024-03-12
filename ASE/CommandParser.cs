using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASE
{
    public class CommandParser
    {
        public string Command { get; private set; } = "";

        public string[] Argument { get; private set; } = Array.Empty<string>();



        private void ParseCommand(string commandText)
        {
            Thread parseThread = new Thread(() =>
            {
                string[] commandParts = commandText.Split(' ');

                if (commandParts.Length == 0)
                {
                    Command = "";
                    Argument = Array.Empty<string>();
                    return;
                }

                Command = commandParts[0];
                Argument = commandParts.Length > 1 ? commandParts.Skip(1).ToArray() : Array.Empty<string>();
            });

            parseThread.Start();
            parseThread.Join();
        }

        public CommandParser(string commandText)
        {
            ParseCommand(commandText);
        }


        private string[] ParseArguments(string[] commandParts, int startIndex)
        {
            return commandParts.Skip(startIndex).ToArray();
        }
    }
}
