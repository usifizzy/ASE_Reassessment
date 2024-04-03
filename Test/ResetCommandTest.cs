using ASE;
using ASE.Commands.Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Test
{
    [TestClass]
    public class ResetCommandTest
    {
        [TestMethod]
        public void Execute_ResetCommand_ShouldResetCanvasProperties()
        {
            // Arrange
            ResetCommand resetCommand = new ResetCommand();
            DrawingCanvas canvas = new DrawingCanvas(); // Create an instance of the canvas

            // Act
            resetCommand.Execute(canvas, new string[] { });

            // Assert
            Assert.AreEqual(new Point(388, 294), canvas.CurrentPosition);
            Assert.AreEqual(Color.BlueViolet, canvas.DrawingPen.Color);
            Assert.AreEqual(Color.DarkBlue, canvas.FillColor);
        }
    }
}
