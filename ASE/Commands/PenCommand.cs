using ASE.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ASE.Commands.Screen
{

    public class PenCommand : ICommand
    {
        private static readonly Dictionary<string, Color> ColorMap = new Dictionary<string, Color>
        {
            { "red", Color.Red },
            { "blue", Color.Blue },
            { "green", Color.Green },
            { "yellow", Color.Yellow },
            { "orange", Color.Orange },
            { "purple", Color.Purple },
            { "pink", Color.Pink },
            { "cyan", Color.Cyan },
            { "magenta", Color.Magenta },
            { "brown", Color.Brown },
            { "black", Color.Black },
            { "white", Color.White },
            { "gray", Color.Gray },
            { "darkred", Color.DarkRed },
            { "darkblue", Color.DarkBlue },
            { "darkgreen", Color.DarkGreen },
            { "darkorange", Color.DarkOrange },
            { "darkcyan", Color.DarkCyan },
            { "lavender", Color.Lavender },
            { "lime", Color.Lime },
            { "gold", Color.Gold },
            { "silver", Color.Silver },
            { "teal", Color.Teal },
            { "skyblue", Color.SkyBlue },
            { "maroon", Color.Maroon },
            { "indigo", Color.Indigo },
            { "olive", Color.Olive },
            { "violet", Color.Violet },
            { "turquoise", Color.Turquoise },
            { "coral", Color.Coral },
            { "orchid", Color.Orchid }
        };

        public void Execute(DrawingCanvas canvas, string[] argument)
        {
            TextBox commandTextBox = canvas.CommandTextBox;

            Pen currentPen = canvas.DrawingPen;

            if (argument.Length >= 1)
            {
                string colorName = argument[0].ToLower();

                if (ColorMap.TryGetValue(colorName, out Color newColor))
                {
                    canvas.DrawingPen = new Pen(newColor);
                    canvas.FillColor = newColor;
                }
                else
                {
                    MessageBox.Show("Color not available. Available colors: red, blue, ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid command. Please provide a valid color command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           /* commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });*/
        }
    }
}
