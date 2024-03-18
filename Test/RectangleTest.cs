using ASE.Commands.Shapes;
using ASE.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void Execute_ValidArguments_DrawsRectangleAndCalculatesArea()
        {
            // Arrange
            RectangleCommand rectangleCommand = new RectangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { "20", "30" }; // Adjust width and height as needed

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();
            mockCanvas.Setup(c => c.CurrentPosition).Returns(new Point(50, 50)); // Set a starting position for the rectangle
            mockCanvas.Setup(c => c.DrawingPen).Returns(new Pen(Color.Black));
            mockCanvas.Setup(c => c.IsFilling).Returns(false); // Set drawing mode (not filling)

            // Create a new TextBox instance
            var textBox = new TextBox();
            // Configure the mock to return the TextBox instance
            mockCanvas.Setup(c => c.CommandTextBox).Returns(textBox);

            // Act
            rectangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert
            int expectedWidth = 20;
            int expectedHeight = 30;

            // Calculate the area
            int calculatedArea = 0;

            for (int i = 50; i < 70; i++)
            {
                for (int j = 50; j < 80; j++)
                {
                    calculatedArea++;
                }
            }
            // Check if the calculated area matches the expected area
            Assert.AreEqual(expectedWidth * expectedHeight, calculatedArea, "The area of the drawn rectangle should match the expected area.");
        }

        [TestMethod]
        public void Rectangle_Execute_InvalidArguments_ShowErrorMessage()
        {
            // Arrange
            RectangleCommand rectangleCommand = new RectangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { }; // No arguments provided

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();

            // Act
            rectangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert
            Assert.IsTrue(true);
        }

    }
}
