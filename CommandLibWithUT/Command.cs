using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    public class Command : ICommand
    {
        private  Vector _vector;
        private Vector _previousVector = new Vector();
        private readonly Vector _initialVector;
        private readonly Vector _argumentVector;

        private readonly AlgebraAction _algebraAction;
        private readonly List<ICommand> _aggregatedCommands = new List<ICommand>();


        public Command(List<ICommand> _commandList)
        {
            _aggregatedCommands = _commandList;
            //_aggregatedCommands.
        }

        public Command(Vector vector, AlgebraAction algebraAction, Vector argumentVector)
        {
            _vector = vector;
            _algebraAction = algebraAction;
            _argumentVector = argumentVector;
            _initialVector = new Vector(vector);

        }

        public void Execute()
        {
            if (! _aggregatedCommands.Any())
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
                    case AlgebraAction.Divide:
                        _vector.Divide(_argumentVector);
                        break;
                }
            }
            else
            {
                foreach (ICommand command in _aggregatedCommands)
                {
                    command.Execute();
                }
            }
        }

        public void Undo()
        {
            if (!_aggregatedCommands.Any())
            {
                _previousVector.Set(_vector);
                _vector.Set(_initialVector); 
            }
            else
            {
                foreach (ICommand command in _aggregatedCommands)
                {
                    command.Undo();
                }
            }
        }

        public void Redo()
        {
            if (!_aggregatedCommands.Any())
            {
                //_previousVector.Set(_vector);
                _vector.Set(_previousVector);
            }
            else
            {
                foreach (ICommand command in _aggregatedCommands)
                {
                    command.Undo();
                }
            }
        }

        public void Print()
        {
            if (!_aggregatedCommands.Any())
            {
                Console.WriteLine($"{_algebraAction.ToString()}  {_vector.Name} {_argumentVector.Name}");
            }
            else
            {
                foreach (ICommand command in _aggregatedCommands)
                {
                    command.Print();
                }
            }
        }
    }
}
