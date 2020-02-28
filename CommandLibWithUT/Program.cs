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
            Vector vector = new Vector() { Name = "v", X = 1, Y = 1, Z = 1 };
            Vector argVector = new Vector() { Name = "q", X = 1, Y = 1, Z = 1 };

            ICommand AddCommand = new Command(vector, AlgebraAction.Add, argVector);
            ICommand SubstractCommand = new Command(vector, AlgebraAction.Substract, argVector);

            vector.Print();

            invoker.SetCommand(AddCommand);
            invoker.Invoke();
            vector.Print();

            invoker.SetCommand(SubstractCommand);
            invoker.Invoke();
            vector.Print();

            Console.ReadLine();

        }
    }
}
