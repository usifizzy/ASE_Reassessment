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
        private Point Position = new Point(330, 250);
        private Pen PenColor = new Pen(Color.Black);
        private Color fillColor = Color.Black;


        public Canvas()
        {
            InitializeComponent();
            CommandParser commandParser = new CommandParser("");
        }

        private void runBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }

        private void runScriptBtn_Click(object sender, EventArgs e)
        {

        }

        private void singleCommandBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
