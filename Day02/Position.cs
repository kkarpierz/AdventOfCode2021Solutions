using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Position
    {
        private int _horizontal;
        private int _depth;
        private int _aim;

        public Position()
        {
            _horizontal = 0;
            _depth = 0;
            _aim = 0;
        }

        public int Horizontal { 
            get { return _horizontal; } 
            set { _horizontal = value; }
        }

        public int Depth 
        { 
            get { return _depth; }
            set { _depth = value; }
        }

        public int Aim 
        {
            get { return _aim; }
            set { _aim = value; }
        }

        //may be moved to class called movementStrategy to make algorithms more generic 
        public void Move(string command)
        {
            var MoveCommand = new MovementCommand(command);
            string commandDirection = MoveCommand.Command;
            int scalarValueOfVector = MoveCommand.Scalar;

            switch (commandDirection)
            {
                case "forward":
                    _horizontal += scalarValueOfVector;
                    //Console.WriteLine("H + " + scalarValueOfVector + ", H=" + _horizontal);
                    break;
                case "up":
                    _depth -= scalarValueOfVector;
                    //Console.WriteLine("D + " + scalarValueOfVector + ", D=" + _depth);
                    break;
                case "down":
                    _depth += scalarValueOfVector;
                    //Console.WriteLine("D - " + scalarValueOfVector + ", D=" + _depth);
                    break;
            }
        }

        public void MoveWithAim(string command)
        {
            var MoveCommand = new MovementCommand(command);
            string commandDirection = MoveCommand.Command;
            int scalarValueOfVector = MoveCommand.Scalar;

            switch (commandDirection)
            {
                case "forward":
                    _horizontal += scalarValueOfVector;
                    _depth += scalarValueOfVector * _aim;
                    //Console.WriteLine("H + " + scalarValueOfVector + ", H=" + _horizontal);
                    break;
                case "up":
                    //_depth -= scalarValueOfVector;
                    _aim -= scalarValueOfVector;
                    //Console.WriteLine("D + " + scalarValueOfVector + ", D=" + _depth);
                    break;
                case "down":
                    //_depth += scalarValueOfVector;
                    _aim += scalarValueOfVector;
                    //Console.WriteLine("D - " + scalarValueOfVector + ", D=" + _depth);
                    break;
            }
        }

        public int calculateResult()
        {
            return _horizontal * _depth;
        }

    }
}
