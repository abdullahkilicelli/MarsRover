using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverConsoleApp;

namespace MarsRoverConsoleAppTest
{
    [TestClass]
    public class MarsRoverConsoleAppTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Test Case -> 1 2 N LMLMLMLMM
            string letterTest = "LMLMLMLMM";
            int xPoint = 1;
            int yPoint = 2;
            int maxX = 5;
            int maxY = 5;
            MarsRover marsRover = new MarsRover(xPoint, yPoint, CompassDirections.N, maxX, maxY);
            marsRover.ChangePosition(letterTest);

            string actualOutput = marsRover.PositionX + " " + marsRover.PositionY + " " + marsRover.RoverCompassDirection;
            string expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Test Case -> 3 3 E MMRMMRMRRM
            string letterTest = "MMRMMRMRRM";
            int xPoint = 3;
            int yPoint = 3;
            int maxX = 5;
            int maxY = 5;
            MarsRover marsRover = new MarsRover(xPoint, yPoint, CompassDirections.E, maxX, maxY);
            marsRover.ChangePosition(letterTest);

            string actualOutput = marsRover.PositionX + " " + marsRover.PositionY + " " + marsRover.RoverCompassDirection;
            string expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
