using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace CommandLibWithUT
{
    public class Invoker
    {
        private readonly List<ICommand> _commandList;
        private ICommand _command;
        
        public Invoker()
        {
            _commandList = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _commandList.Add(_command);
            _command.Execute();
        }
    }
}
