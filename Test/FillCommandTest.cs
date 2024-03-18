using ASE;
using ASE.Commands.Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class FillCommandTest
    {
        [TestMethod]
        public void Execute_FillCommand_OnMode()
        {
            // Arrange
            Canvas canvas = new Canvas();
            FillCommand fillCommand = new FillCommand();
            string[] arguments = { "on" };

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            Assert.IsTrue(canvas.IsFilling);
            Assert.AreEqual(canvas.DrawingPen.Color, canvas.FillColor);
            // You can add more assertions if needed
        }

        [TestMethod]
        public void Execute_FillCommand_OffMode()
        {
            // Arrange
            Canvas canvas = new Canvas();
            FillCommand fillCommand = new FillCommand();
            string[] arguments = { "off" }; // Turning off filling mode

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            Assert.IsFalse(canvas.IsFilling);
            // You can add more assertions if needed
        }

        [TestMethod]
        public void Execute_FillCommand_InvalidMode()
        {
            // Arrange
            Canvas canvas = new Canvas();
            FillCommand fillCommand = new FillCommand();
            string[] arguments = { "invalid" }; // Using invalid mode

            // Act
            fillCommand.Execute(canvas, arguments);

            // Assert
            // Ensure that the canvas state remains unchanged (filling mode should still be off)
            Assert.IsFalse(canvas.IsFilling);
            // You can add more assertions if needed
        }
    }
}
