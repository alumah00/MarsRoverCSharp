using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        //8
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newPosition = new Rover(100);
            Assert.AreEqual(newPosition.Position, 100);
        }
        //9
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newMode = new Rover(100);
            Assert.AreEqual(newMode.Mode, "NORMAL");
        }
        //10
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newGW = new Rover(110);
            Assert.AreEqual(newGW.GeneratorWatts, 110);
        }
        //11
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", 500, "LOW_POWER") };
            Message newMessage= new Message("HAPPY", commands);
            Rover newChange = new Rover(250);

            newChange.ReceiveMessage(newMessage);

            string expectedRoverMode = "LOW_POWER";
            string actualRoverMode = newChange.Mode;

            Assert.AreEqual(expectedRoverMode, actualRoverMode);
        }


        //12
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { new Command("MODE_CHANGE", 500, "LOW_POWER"), new Command("MOVE", 10) };
        
            Message newMessage = new Message("HAPPY", commands);
            Rover newChange = new Rover(250);

            newChange.ReceiveMessage(newMessage);

            string expectedRoverMode = "LOW_POWER";
            string actualRoverMode = newChange.Mode;

            Assert.AreEqual(expectedRoverMode, actualRoverMode);

            int expectedRoverPosition = 250;
            int actualRoverPosition = newChange.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);
        }
        //13  Not Done!! Just copied from 12 without mods yet
        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MOVE", 100) };
            Message newMessage = new Message("HAPPY", commands);
            Rover newChange = new Rover(250);

            int expectedRoverPosition = 250;
            int actualRoverPosition = newChange.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);

            newChange.ReceiveMessage(newMessage);

            expectedRoverPosition = 100;
            actualRoverPosition = newChange.Position;

            Assert.AreEqual(expectedRoverPosition, actualRoverPosition);
        }
    }
}
