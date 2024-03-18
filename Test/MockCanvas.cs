using ASE.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public class MockCanvas : ICanvas
    {
       // public Point CurrentPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TextBox CommandTextBox => throw new NotImplementedException();

        public PictureBox PictureBox => throw new NotImplementedException();

      //  public Pen DrawingPen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
     //   public Color FillColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       // public bool IsFilling { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Point CurrentPosition { get; set; }
        public Pen DrawingPen { get; set; }
        public Color FillColor { get; set; }
        public bool IsFilling { get; set; }
        public Action<MethodInvoker> InvokeAction { get; set; }

        public MockCanvas()
        {
            // Set default values
            CurrentPosition = Point.Empty;
            DrawingPen = Pens.Black;
            FillColor = Color.Black;
            IsFilling = false;
        }

        public void Invoke(MethodInvoker method)
        {
            // Invoke the method directly
            method.Invoke();
        }
    }
}
