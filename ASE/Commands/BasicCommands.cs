using ASE_Programming_Lang.Commands.Screen;
using ASE_Programming_Lang.Commands.Shapes;
using ASE_Programming_Lang.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Programming_Lang.Commands
{
    public class BasicCommands
    {
        private Canvas canvas;
        private readonly object _locker = new object();


        public BasicCommands(Canvas canvas)
        {
            this.canvas = canvas;
        }

        /// <summary>
        /// Dictionary of graphics commands.
        /// </summary>
        private Dictionary<string, ICommand> basicCommands = new Dictionary<string, ICommand>
        {
            { "moveto", new MoveToCommand() },
            { "drawto", new DrawToCommand() },
            { "fill", new FillCommand() },
            { "reset", new ResetCommand() },
            { "clear", new ClearScreen() },
            { "pen", new PenCommand() }
        };

        public bool ContainsBasicCommand(string command)
        {
            return basicCommands.ContainsKey(command.ToLower());
        }


        /// <summary>
        /// Executes the drawing command parsed by the CommandParser.
        /// </summary>
        /// <param name="parser">The CommandParser containing the parsed command.</param>
        public void ExecuteDrawing(CommandParser parser)
        {
            if (canvas.InvokeRequired)
            {
                canvas.Invoke(new Action(() => ExecuteDrawingInternal(parser)));
            }
            else
            {
                ExecuteDrawingInternal(parser);
            }
        }

        /// <summary>
        /// Executes the drawing command internally after checking if the invocation is required.
        /// </summary>
        /// <param name="parser">The CommandParser containing the parsed command.</param>
        private void ExecuteDrawingInternal(CommandParser parser)
        {
            lock (_locker)
            {
                using (Graphics graphics = canvas.PictureBox.CreateGraphics())
                {
                    switch (parser.Command.ToLower())
                    {
                        case "moveto":
                        case "drawto":
                        case "fill":
                        case "reset":
                        case "clear":
                        case "pen":
                            basicCommands[parser.Command.ToLower()].Execute(canvas, parser.Argument);
                            break;
                       
                        default:
                            MessageBox.Show("Unrecognized command: " + parser.Command, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
    }
}
