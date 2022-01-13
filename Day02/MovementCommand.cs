using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class MovementCommand
    {
        private int _scalar;
        private string _commandText;

        public MovementCommand(string command)
        {
            string[] commandSplitted = command.Split();
            _scalar = Convert.ToInt32(commandSplitted[1]);
            _commandText = commandSplitted[0];
        }

        public string Command {  get { return _commandText; } }
        public int Scalar { get { return _scalar; } }

    }
}
