using ASE_Programming_Lang;
using ASE_Programming_Lang.Interface;

namespace ASE_Programming_Lang.Commands.Screen
{
    /// <summary>
    /// Represents a command to clear the screen on the canvas.
    /// </summary>
    public class ClearScreen : ICommand
    {
        public void Execute(Canvas canvas, string[] args)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            // Invalidate the drawing area of the canvas to clear the screen
            canvas.PictureBox.Invalidate();

            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
