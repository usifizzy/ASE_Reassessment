using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Shapes
{
    public class CircleCommand : IGraphicsCommand
    {
        public void Execute(Graphics graphics, string[] argument, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length == 1 && int.TryParse(argument[0], out int radius))
            {
                int x = currentPosition.X - radius;
                int y = currentPosition.Y - radius;

                if (canvas.IsFilling)
                {
                    SolidBrush brush = new SolidBrush(canvas.FillColor);
                    graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                }
                else
                {
                    graphics.DrawEllipse(drawingPen, x, y, 2 * radius, 2 * radius);
                }

                commandTextBox.Invoke((MethodInvoker)delegate
                {
                    commandTextBox.Clear();
                });
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'Circle' command. Please provide a valid value for radius.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
