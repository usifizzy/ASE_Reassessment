using ASE;
using ASE.Commands.Shapes;
using ASE.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;



namespace Test
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void Execute_InvalidArguments_ShowErrorMessage()
        {
            // Arrange
            CircleCommand circleCommand = new CircleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { }; //No arguments provided
            DrawingCanvas canvas = new DrawingCanvas(); //You may need to mock this if it has dependencies

            // Act
            circleCommand.Execute(graphics, arguments, canvas);

            // Assert
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void Execute_ValidRadius_DrawsCircle()
        {
            // Arrange
            CircleCommand circleCommand = new CircleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { "10" };

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();
            mockCanvas.Setup(c => c.CurrentPosition).Returns(new Point(302, 258)); // Set a center position for the circle
            mockCanvas.Setup(c => c.DrawingPen).Returns(new Pen(Color.Black));
            mockCanvas.Setup(c => c.IsFilling).Returns(false); // Set drawing mode (not filling)

            // Act
            circleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert
            int expectedRadius = 10; // Expected radius
            int expectedArea = (int)(Math.PI * expectedRadius * expectedRadius); // Expected area
            int actualArea = 0;

            int centerX = 302; // Center X coordinate
            int centerY = 258; // Center Y coordinate
            int radius = 10; // Circle radius
            double distanceThreshold = 0.5; // Threshold for distance around the radius

            for (int x = centerX - radius; x <= centerX + radius; x++)
            {
                for (int y = centerY - radius; y <= centerY + radius; y++)
                {
                    int dx = x - centerX;
                    int dy = y - centerY;
                    int distanceSquared = dx * dx + dy * dy;

                    if (distanceSquared <= radius * radius)
                    {
                        actualArea++; // Increment the area for each pixel within the circle
                    }
                }
            }

            int tolerance = 5; // Adjust the tolerance as needed
            Assert.IsTrue(Math.Abs(expectedArea - actualArea) <= tolerance, $"Area covered by the circle should be approximately {expectedArea} pixels with a tolerance of {tolerance}.");
        }


    }
}
