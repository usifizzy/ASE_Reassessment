using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Shapes
{
    public class ConcentricCircleCommand : IGraphicsCommand
    {
        public void Execute(Graphics graphics, string[] argument, ICanvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length == 2 && int.TryParse(argument[0], out int radius) && int.TryParse(argument[1], out int numCircles))
            {
                for (int i = 0; i < numCircles; i++)
                {
                    int currentRadius = radius * (i + 1);

                    int x = currentPosition.X - currentRadius;
                    int y = currentPosition.Y - currentRadius;

                    if (canvas.IsFilling)
                    {
                        // Fill the circle
                        SolidBrush brush = new SolidBrush(canvas.FillColor);
                        graphics.FillEllipse(brush, x, y, 2 * currentRadius, 2 * currentRadius);
                    }
                    else
                    {
                        // Draw the circle
                        graphics.DrawEllipse(drawingPen, x, y, 2 * currentRadius, 2 * currentRadius);
                    }
                }

                // Use Invoke to update the commandTextBox on the UI thread
                commandTextBox.Invoke((MethodInvoker)delegate
                {
                    commandTextBox.Clear();
                });
            }
            else
            {
                // Show error message for invalid arguments
                MessageBox.Show("Invalid arguments for 'concentriccircle' command. Please provide valid radius and number of circles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}