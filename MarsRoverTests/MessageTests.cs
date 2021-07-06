using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("");
            }
            catch (ArgumentNullException messageName)
            {
                Assert.AreEqual("Message name required.", messageName.Message);
            }
        }
        
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("HELLO");
            Assert.AreEqual(newMessage.Name, "HELLO");
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Command[] commands = { new Command("MODE_CHANGE", 1887), new Command("MOVE", 500) };
            Message newMessage = new Message("Test message with two commands", commands);
            Assert.AreEqual(newMessage.Commands, commands);
        }

    }
}
