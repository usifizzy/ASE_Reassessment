using ASE.Interface;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{

    public class ClearScreen : ICommand
    {
        public void Execute(Canvas canvas, string[] args)
        {
            TextBox commandTextBox = canvas.CommandTextBox;

            canvas.PictureBox.Invalidate();

            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
