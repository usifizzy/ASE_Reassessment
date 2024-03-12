using ASE.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Shapes
{

    public class TriangleCommand : IGraphicsCommand
    {
        public void Execute(Graphics graphics, string[] argument, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length == 1)
            {
                if (int.TryParse(argument[0], out int sideLength))
                {
                    int x1 = currentPosition.X;
                    int y1 = currentPosition.Y;
                    int x2 = x1 + sideLength;
                    int y2 = y1;
                    int x3 = x1 + sideLength / 2;
                    int y3 = y1 - (int)(Math.Sqrt(3) * sideLength / 2);

                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillPolygon(brush, points);
                        }
                    }

                    graphics.DrawPolygon(drawingPen, points);

                    commandTextBox.Invoke((MethodInvoker)delegate
                    {
                        commandTextBox.Clear();
                    });
                }
                else
                {
                    // Show error message for invalid side length argument
                    MessageBox.Show("Invalid arguments for 'triangle' command. Please provide a valid side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show error message for insufficient arguments
                MessageBox.Show("Not enough arguments for 'triangle' command. Please provide a side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
