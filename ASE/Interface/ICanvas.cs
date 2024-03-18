using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE.Interface
{
    public interface ICanvas
    {
        Point CurrentPosition { get; set; }
        TextBox CommandTextBox { get; }
        PictureBox PictureBox { get; }
        Pen DrawingPen { get; set; }
        Color FillColor { get; set; }
        bool IsFilling { get; set; }
    }
}
