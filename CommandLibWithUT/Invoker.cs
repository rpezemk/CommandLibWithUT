using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    public class Invoker
    {
        private ICommand _command;
        private List<ICommand> _commands;
  
        public Invoker()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }

        public void UndoInvoke()
        {
            _command.Undo();
        }

    }
}
