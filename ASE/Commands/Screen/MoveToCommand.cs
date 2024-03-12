using ASE_Programming_Lang.Interface;

namespace ASE_Programming_Lang.Commands.Screen
{
    /// <summary>
    /// Represents a command to move the drawing position to a specified point on the canvas.
    /// </summary>
    public class MoveToCommand : ICommand
    {
        /// <summary>
        /// Executes the MoveTo command.
        /// </summary>
        /// <param name="canvas">The Canvas object representing the drawing surface.</param>
        /// <param name="arguments">An array of arguments containing the coordinates of the destination point.</param>
        public void Execute(Canvas canvas, string[] arguments)
        {
            // Implementation for MoveTo command
            if (arguments.Length == 2 && int.TryParse(arguments[0], out int x) && int.TryParse(arguments[1], out int y))
            {
                TextBox commandTextBox = canvas.CommandTextBox;

                canvas.CurrentPosition = new Point(x, y);

                // Use Invoke to update the commandTextBox on the UI thread
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
