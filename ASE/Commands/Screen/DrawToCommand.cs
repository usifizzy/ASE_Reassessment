using ASE_Programming_Lang.Interface;

namespace ASE_Programming_Lang.Commands.Screen
{
    /// <summary>
    /// Represents a command to draw a line to a specified point on the canvas.
    /// </summary>
    public class DrawToCommand : ICommand
    {
        /// <summary>
        /// Executes the DrawTo command.
        /// </summary>
        /// <param name="canvas">The Canvas object representing the drawing surface.</param>
        /// <param name="arguments">An array of arguments containing the coordinates of the destination point.</param>
        public void Execute(Canvas canvas, string[] arguments)
        {
            // Implementation for DrawTo command
            if (arguments.Length == 2 && int.TryParse(arguments[0], out int x) && int.TryParse(arguments[1], out int y))
            {
                Point destination = new Point(x, y);
                using (Graphics graphics = canvas.PictureBox.CreateGraphics())
                {
                    graphics.DrawLine(canvas.DrawingPen, canvas.CurrentPosition, destination);
                }
                canvas.CurrentPosition = destination;
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'drawto' command. Please provide a valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
