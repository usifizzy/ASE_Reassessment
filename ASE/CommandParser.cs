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
            string[] commandParts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (commandParts.Length == 0)
            {
                Command = "";
                Argument = Array.Empty<string>();
                return;
            }

            Command = commandParts[0];

            if (commandParts.Length > 1)
            {
                Argument = ParseArguments(commandParts, 1);
            }
            else
            {
                Argument = Array.Empty<string>();
            }
        }


        public CommandParser(string commandText)
        {
            Thread parseThread = new Thread(() => ParseCommand(commandText));
            parseThread.Start();
            parseThread.Join();
        }


        private string[] ParseArguments(string[] commandParts, int startIndex)
        {
            List<string> arguments = new List<string>();

            for (int i = startIndex; i < commandParts.Length; i++)
            {
                arguments.Add(commandParts[i]);
            }

            return arguments.ToArray();
        }
    }
}
