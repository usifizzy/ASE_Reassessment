using ASE.Commands.Shapes;
using ASE.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands
{
    public class GraphicsCommands
    {
        private Canvas canvas;
        private readonly object _locker = new object();


        public GraphicsCommands(Canvas canvas)
        {
            this.canvas = canvas;
        }

        private Dictionary<string, IGraphicsCommand> graphicsCommands = new Dictionary<string, IGraphicsCommand>
        {
            { "circle", new CircleCommand() },
            { "rectangle", new RectangleCommand() },
        };


        public bool ContainsGraphicsCommand(string command)
        {
            return graphicsCommands.ContainsKey(command.ToLower());
        }


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

        private void ExecuteDrawingInternal(CommandParser parser)
        {
            lock (_locker)
            {
                using (Graphics graphics = canvas.PictureBox.CreateGraphics())
                {
                    switch (parser.Command.ToLower())
                    {
                        case "circle":
                        case "rectangle":
                            graphicsCommands[parser.Command.ToLower()].Execute(graphics, parser.Argument, canvas);
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
