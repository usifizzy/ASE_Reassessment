using ASE.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{
    public class ResetCommand : ICommand
    {
        public void Execute(Canvas canvas, string[] argument)
        {
            TextBox commandTextBox = canvas.CommandTextBox;

            canvas.CurrentPosition = new Point(388, 294);
            canvas.DrawingPen = new Pen(Color.BlueViolet);
            canvas.FillColor = Color.DarkBlue;
            canvas.IsFilling = false;


           /* commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });*/
        }
    }
}
