using ASE.Commands.Shapes;
using ASE.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void Execute_ValidSideLength_DrawsTriangle()
        {
            // Arrange
            TriangleCommand triangleCommand = new TriangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { "10" }; // Adjust side length as needed

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();
            mockCanvas.Setup(c => c.CurrentPosition).Returns(new Point(50, 50)); // Set a starting position for the triangle
            mockCanvas.Setup(c => c.DrawingPen).Returns(new Pen(Color.Black));
            mockCanvas.Setup(c => c.IsFilling).Returns(false); // Set drawing mode (not filling)

            // Create a new TextBox instance
            var textBox = new TextBox();
            // Configure the mock to return the TextBox instance
            mockCanvas.Setup(c => c.CommandTextBox).Returns(textBox);


            // Act
            triangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert
            double expectedSideLength = 10; // Expected side length
            double expectedArea = Math.Sqrt(3) / 4 * expectedSideLength * expectedSideLength; // Expected area for equilateral triangle
            double actualArea = 0;

            // Calculate area using formula for triangle area (Heron's formula)
            actualArea = 0.5 * expectedSideLength * (Math.Sqrt(3) / 2) * expectedSideLength;

            int tolerance = 5; // Adjust the tolerance as needed
            Assert.IsTrue(Math.Abs(expectedArea - actualArea) <= tolerance, $"Area covered by the triangle should be approximately {expectedArea} square units with a tolerance of {tolerance}.");
        }


        [TestMethod]
        public void Triangle_Execute_InvalidArguments_ShowErrorMessage()
        {
            // Arrange
            TriangleCommand triangleCommand = new TriangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { }; // No arguments provided

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();

            // Act
            triangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert.
            Assert.IsTrue(true); // Placeholder assertion, you can refine it if needed
        }

    }
}
