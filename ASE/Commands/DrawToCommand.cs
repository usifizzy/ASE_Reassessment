﻿using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{
    public class DrawToCommand : ICommand
    {
        public void Execute(Canvas canvas, string[] arguments)
        {
            if (arguments.Length == 2 && int.TryParse(arguments[0], out int x) && int.TryParse(arguments[1], out int y))
            {
                Point destination = new Point(x, y);
                using (Graphics graphics = canvas.PictureBox.CreateGraphics())
                {
                    graphics.DrawLine(canvas.DrawingPen, canvas.CurrentPosition, destination);
                }
                canvas.CurrentPosition = destination;
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'drawto' command. Please provide a valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
