using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{

    public enum Color
    {
        Red,
        Green,
        Blue
    }


    public class Command : ICommand
    {
        private readonly Vector _vector;
        private readonly AlgebraAction _algebraAction;
        private readonly Vector _argumentVector;

        public Command(Vector vector, AlgebraAction algebraAction, Vector argumentVector)
        {
            _vector = vector;
            _algebraAction = algebraAction;
            _argumentVector = argumentVector;
        }

        public void Execute()
        {
            switch (_algebraAction)
            {
                case AlgebraAction.Add:
                    _vector.Add(_argumentVector);
                    break;
                case AlgebraAction.Substract:
                    _vector.Substract(_argumentVector);
                    break;
                case AlgebraAction.Multiply:
                    _vector.Mulitply(_argumentVector);
                    break;
            }
        }
        public void Undo()
        {
            switch (_algebraAction)
            {
                case AlgebraAction.Substract:
                    _vector.Add(_argumentVector);
                    break;
                case AlgebraAction.Add:
                    _vector.Substract(_argumentVector);
                    break;
                case AlgebraAction.Divide:
                    _vector.Mulitply(_argumentVector);
                    break;
                case AlgebraAction.Multiply:
                    _vector.Divide(_argumentVector);
                    break;
            }
        }
    }
}
