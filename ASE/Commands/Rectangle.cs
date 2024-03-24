using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Shapes
{
    public class RectangleCommand : IGraphicsCommand
    {
        public void Execute(Graphics graphics, string[] argument, ICanvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length == 2)
            {
                if (int.TryParse(argument[0], out int width) && int.TryParse(argument[1], out int height))
                {
                    int x = currentPosition.X;
                    int y = currentPosition.Y;

                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillRectangle(brush, x, y, width, height);
                        }
                    }

                    graphics.DrawRectangle(drawingPen, x, y, width, height);

                  /*  commandTextBox.Invoke((MethodInvoker)delegate
                    {
                        commandTextBox.Clear();
                    });*/
                }
                else
                {
                    MessageBox.Show("Invalid arguments for 'rectangle' command. Please provide valid width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not enough arguments for 'rectangle' command. Please provide width and height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
