using ASE.Interface;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{
    public class FillCommand : ICommand
    {
        public void Execute(Canvas canvas, string[] argument)
        {
            TextBox commandTextBox = canvas.CommandTextBox;

            if (argument.Length >= 1)
            {
                string fillMode = argument[0].ToLower();

                switch (fillMode)
                {
                    case "on":
                        canvas.IsFilling = true;
                        canvas.FillColor = canvas.DrawingPen.Color;
                        break;
                    case "off":
                        canvas.IsFilling = false;
                        break;
                    default:
                        MessageBox.Show("Invalid fill mode. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else
            {
                MessageBox.Show("Missing argument for 'fill' command. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
