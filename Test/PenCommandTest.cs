using ASE;
using ASE.Commands.Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Test
{
    [TestClass]
    public class PenCommandTest
    {
        [TestMethod]
        public void Execute_PenCommand_ValidColor_ShouldSetDrawingPenAndFillColor()
        {
            // Arrange
            PenCommand penCommand = new PenCommand();
            DrawingCanvas canvas = new DrawingCanvas(); // Create an instance of the canvas

            // Act
            penCommand.Execute(canvas, new string[] { "blue" });

            // Assert
            Assert.AreEqual(Color.Blue, canvas.DrawingPen.Color);
            Assert.AreEqual(Color.Blue, canvas.FillColor);
        }


        [TestMethod]
        public void Execute_PenCommand_NoArgument_ShouldNotChangeDrawingPenAndFillColor()
        {
            // Arrange
            PenCommand penCommand = new PenCommand();
            DrawingCanvas canvas = new DrawingCanvas(); // Create an instance of the canvas
            Color initialDrawingColor = canvas.DrawingPen.Color;
            Color initialFillColor = canvas.FillColor;

            // Act
            penCommand.Execute(canvas, new string[] { });

            // Assert
            Assert.AreEqual(initialDrawingColor, canvas.DrawingPen.Color); // Check if the color remains unchanged
            Assert.AreEqual(initialFillColor, canvas.FillColor); // Check if the fill color remains unchanged
        }
    }
}
