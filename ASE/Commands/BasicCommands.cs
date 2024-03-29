﻿using ASE.Commands.Screen;
using ASE.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands
{
    public class BasicCommands
    {
        private DrawingCanvas canvas;
        private readonly object _locker = new object();


        public BasicCommands(DrawingCanvas canvas)
        {
            this.canvas = canvas;
        }

        private Dictionary<string, ICommand> basicCommands = new Dictionary<string, ICommand>
        {
            { "clear", new ClearScreen() },
            { "color", new PenCommand() }, 
            { "fill", new FillCommand() },
            { "reset", new ResetCommand() },           
            { "point", new MoveToCommand() },            
            { "drawto", new DrawToCommand() },
        };

        public bool ContainsBasicCommand(string command)
        {
            return basicCommands.ContainsKey(command.ToLower());
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
                        case "clear":
                        case "color":
                        case "fill":
                        case "reset":
                        case "point":
                        case "drawto":
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
