using ASE.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE
{
    public partial class Canvas : Form
    {
        private bool isFill = false;
        private Point Position = new Point(388, 294);
        private Pen PenColor = new Pen(Color.BlueViolet);
        private Color fillColor = Color.DarkBlue;
        public GraphicsCommands GraphicsCommands;
        public BasicCommands BasicCommands;


        public Canvas()
        {
            InitializeComponent();
            CommandParser commandParser = new CommandParser("");
            GraphicsCommands = new GraphicsCommands(this);
            BasicCommands = new BasicCommands(this);
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            string command = singleCommandBox.Text;
            CommandParser parser = new CommandParser(command);

            if (GraphicsCommands.ContainsGraphicsCommand(parser.Command.ToLower()))
            {
                GraphicsCommands.ExecuteDrawing(parser);
            }
            else if (BasicCommands.ContainsBasicCommand(parser.Command.ToLower()))
            {
                BasicCommands.ExecuteDrawing(parser);
            }
            else
            {
                MessageBox.Show("Unrecognized command: " + parser.Command, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            string command = "clear";
            CommandParser parser = new CommandParser(command);
            BasicCommands.ExecuteDrawing(parser);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            string command = "reset";
            CommandParser parser = new CommandParser(command);
            BasicCommands.ExecuteDrawing(parser);
        }

        private void runScriptBtn_Click(object sender, EventArgs e)
        {
             try
            {
                MultiLineForm newWindow = new MultiLineForm(this);
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the new window: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void singleCommandBox_TextChanged(object sender, EventArgs e)
        {

        }

        public Point CurrentPosition
        {
            get { return Position; }
            set
            {
                Position = value;
            }
        }


        public TextBox CommandTextBox
        {
            get { return singleCommandBox; }
        }

        public PictureBox PictureBox
        {
            get { return pictureBox; }
        }


        public Pen DrawingPen
        {
            get { return PenColor; }
            set { PenColor = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }


        public bool IsFilling
        {
            get { return isFill; }
            set { isFill = value; }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursorPosition = e.Location;

            this.Text = $"Mouse Position: {cursorPosition.X}, {cursorPosition.Y}";
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int dotSize = 3;
            int x = Position.X - dotSize / 2;
            int y = Position.Y - dotSize / 2;
            e.Graphics.FillEllipse(Brushes.Blue, x, y, dotSize, dotSize);
        }
    }
}
