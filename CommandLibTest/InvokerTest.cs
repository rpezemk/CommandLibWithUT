using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandLibWithUT;

namespace CommandLibTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class InvokerTest
    {
        [TestMethod]
        public void TestInvoke()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");

            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);
            ICommand commandTwo = new Command(vectorOne, AlgebraAction.Substract, new Vector(1, 1, 1));
            ICommand commandThree = new Command(vectorOne, AlgebraAction.Multiply, new Vector(2, 2, 2));
            ICommand commandFour = new Command(vectorOne, AlgebraAction.Divide, new Vector(3, 3, 3));
            ICommand commandFive = new Command(vectorOne, AlgebraAction.Divide, new Vector(2, 2, 2));


            List<ICommand> CommandSublist = new List<ICommand>()
            {
                commandOne,
                commandTwo,
            };

            ICommand SubCommands = new Command(CommandSublist);

            List<ICommand> CommandListTwo = new List<ICommand>()
            {
                SubCommands,
                commandThree,
                commandFour
            };

            ICommand CommandNestedAggregate = new Command(new List<ICommand>()
            {
                new Command(CommandListTwo),
                commandFive
            });

            float expectedX = 1;
            float expectedY = 1;
            float expectedZ = 1;

            Invoker invoker = new Invoker();

            //Act
            invoker.SetCommand(CommandNestedAggregate);

            //Assert
            Assert.IsTrue(
                vectorOne.X == expectedX &&
                vectorOne.Y == expectedY &&
                vectorOne.Y == expectedZ
                );
        }

        public void TestUndoInvoke()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");

            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);
            Invoker invoker = new Invoker();

            //Act
            invoker.SetCommand(commandOne);
            invoker.Invoke();

        }
    }
}
