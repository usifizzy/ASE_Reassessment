using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{
    public class MoveToCommand : ICommand
    {
        public void Execute(Canvas canvas, string[] arguments)
        {
            if (arguments.Length == 2 && int.TryParse(arguments[0], out int x) && int.TryParse(arguments[1], out int y))
            {
                TextBox commandTextBox = canvas.CommandTextBox;

                canvas.CurrentPosition = new Point(x, y);

                commandTextBox.Invoke((MethodInvoker)delegate
                {
                    commandTextBox.Clear();
                });
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'moveto' command. Please provide valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
