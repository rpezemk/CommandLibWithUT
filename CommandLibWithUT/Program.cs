using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    class Program
    {
        static void Main(string[] args)
        {


            Invoker invoker = new Invoker();

            Vector vector = new Vector(1, 1, 1, "v");// { Name = "v", X = 1, Y = 1, Z = 1 };//really....? booo
            Vector argVectorOne = new Vector(1, 2, 1, "r");// { Name = "q", X = 1, Y = 1, Z = 1 };//booo.......
            Vector argVectorTwo = new Vector(3, 4, 3, "q");
            Vector argVectorThree = new Vector(3, 4, 5, "u");

            vector.Print();
            argVectorOne.Print();
            argVectorTwo.Print();
            argVectorThree.Print();

            ICommand CommandOne = new Command(vector, AlgebraAction.Add, argVectorOne);
            ICommand CommandTwo = new Command(vector, AlgebraAction.Substract, argVectorTwo);
            ICommand CommandThree = new Command(vector, AlgebraAction.Multiply, argVectorThree);

            List<ICommand> CommandList = new List<ICommand>()
            {
                CommandOne,
                CommandTwo,
                CommandThree
            };
            ICommand AggregatedCmdsOne = new Command(CommandList);
            Console.WriteLine("Nastąpi złożenie następujących operacji:");
            AggregatedCmdsOne.Print();

            Invoker invokerTwo = new Invoker();
            invokerTwo.SetCommand(AggregatedCmdsOne);
            invokerTwo.Invoke();
            vector.Print();

            Console.ReadLine();


        }
    }
}
