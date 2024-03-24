using ASE.Commands;
using ASE.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASE
{
    public partial class DrawingCanvas : Form, ICanvas
    {
        private bool fillEnabled = false;
        private Point currentPosition = new Point(388, 294);
        private Pen drawingPen = new Pen(Color.BlueViolet);
        private Color fillColor = Color.DarkBlue;
        public GraphicsCommands GraphicsCommands;
        public BasicCommands BasicCommands;

        public DrawingCanvas()
        {
            InitializeComponent();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CommandParser commandParser = new CommandParser("");
            GraphicsCommands = new GraphicsCommands(this);
            BasicCommands = new BasicCommands(this);
        }

        private void RunButton_Click(object sender, EventArgs e)
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
                ShowErrorMessage("Unrecognized command: " + parser.Command);
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ExecuteBasicCommand("clear");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ExecuteBasicCommand("reset");
        }

        private void ExecuteBasicCommand(string command)
        {
            CommandParser parser = new CommandParser(command);
            BasicCommands.ExecuteDrawing(parser);
        }

        private void RunScriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMultiLineForm();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error opening the new window: " + ex.Message);
            }
        }

        private void ShowMultiLineForm()
        {
            MultiLineForm newWindow = new MultiLineForm(this);
            newWindow.Show();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursorPosition = e.Location;
            this.Text = $"Mouse Position: {cursorPosition.X}, {cursorPosition.Y}";
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int dotSize = 3;
            int x = currentPosition.X - dotSize / 2;
            int y = currentPosition.Y - dotSize / 2;
            e.Graphics.FillEllipse(Brushes.Blue, x, y, dotSize, dotSize);
        }

        public Point CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
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
            get { return drawingPen; }
            set { drawingPen = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public bool IsFilling
        {
            get { return fillEnabled; }
            set { fillEnabled = value; }
        }
    }
}
