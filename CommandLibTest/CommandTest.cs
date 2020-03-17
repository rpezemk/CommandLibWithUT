using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandLibWithUT;

namespace CommandLibTest
{

    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void TestSingleExecution()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");
            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);

            float expectedX = 4;
            float expectedY = 4;
            float expectedZ = 4;

            //Act
            commandOne.Execute();

            //Assert
            Assert.IsTrue(
                vectorOne.X == expectedX &&
                vectorOne.Y == expectedY &&
                vectorOne.Y == expectedZ
                );
        }

        [TestMethod]
        public void TestAggregateExecution()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");

            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);
            ICommand commandTwo = new Command(vectorOne, AlgebraAction.Substract, new Vector(1, 1, 1));
            ICommand commandThree = new Command(vectorOne, AlgebraAction.Multiply, new Vector(2, 2, 2));
            ICommand commandFour = new Command(vectorOne, AlgebraAction.Divide, new Vector(3, 3, 3));

            List<ICommand> CommandList = new List<ICommand>()
            {
                commandOne,
                commandTwo,
                commandThree,
                commandFour
            };

            ICommand CommandAggregate = new Command(CommandList);

            float expectedX = 2;
            float expectedY = 2;
            float expectedZ = 2;

            //Act
            CommandAggregate.Execute();

            //Assert
            Assert.IsTrue(
                vectorOne.X == expectedX &&
                vectorOne.Y == expectedY &&
                vectorOne.Y == expectedZ
                );

        }

        [TestMethod]
        public void TestNestedCommandsExecution()
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

            //Act
            CommandNestedAggregate.Execute();

            //Assert
            Assert.IsTrue(
                vectorOne.X == expectedX &&
                vectorOne.Y == expectedY &&
                vectorOne.Y == expectedZ
                );


        }


        [TestMethod]
        public void TestUndo()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");

            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);

            float expectedX = 1;
            float expectedY = 1;
            float expectedZ = 1;

            //Act
            commandOne.Execute();
            commandOne.Undo();

            //Assert
            Assert.IsTrue(
                vectorOne.X == expectedX &&
                vectorOne.Y == expectedY &&
                vectorOne.Y == expectedZ
                );
        }

        [TestMethod]
        public void TestNestedUndo()
        {
            //Assemble
            Vector vectorOne = new Vector(1, 1, 1, "Test Name One");
            Vector vectorTwo = new Vector(3, 3, 3, "Test Name Two");
            ICommand commandOne = new Command(vectorOne, AlgebraAction.Add, vectorTwo);
            ICommand commandTwo = new Command(vectorOne, AlgebraAction.Add, new Vector(1, 1, 1));

            List<ICommand> CommandList = new List<ICommand>()
            {
                commandOne,
                commandTwo,
            };

            ICommand CommandAggregate = new Command(CommandList);

        }
    }
}
