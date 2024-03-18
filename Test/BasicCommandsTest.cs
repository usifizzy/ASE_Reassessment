using ASE.Commands;
using ASE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test
{
    [TestClass]
    public class BasicCommandsTest
    {

        [TestMethod]
        public void Execute_MoveToCommand()
        {
            // Arrange
            Canvas canvas = new Canvas();
            BasicCommands basicCommands = new BasicCommands(canvas);
            string[] arguments = { "100", "100" };
            Point expectedPosition = new Point(100, 100);

            // Act
            basicCommands.ExecuteDrawing(new CommandParser("moveto 100 100"));

            // Assert
            Assert.AreEqual(expectedPosition, canvas.CurrentPosition);
        }


        [TestMethod]
        public void Execute_DrawToCommand()
        {
            // Arrange
            Canvas canvas = new Canvas();
            BasicCommands basicCommands = new BasicCommands(canvas);
            string[] arguments = { "200", "200" }; // Assuming destination coordinates
            Point expectedPosition = new Point(200, 200);

            // Act
            basicCommands.ExecuteDrawing(new CommandParser("drawto 200 200"));

            // Assert
            Assert.AreEqual(expectedPosition, canvas.CurrentPosition);
        }

    }
}
