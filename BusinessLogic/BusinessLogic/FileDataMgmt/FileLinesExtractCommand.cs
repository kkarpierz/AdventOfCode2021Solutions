using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FileLinesExtractCommand : IDataFileManageCommand
    {
        private List<string> _dataLines;
        private string _dataFileName;

        public List<string> DataLines { get { return _dataLines; } }  

        public FileLinesExtractCommand(string dataFileName)
        {
            _dataFileName = dataFileName;
        }

        public void Execute()
        {
            _dataLines = new List<string>();

            foreach (string line in System.IO.File.ReadLines(@"..\..\..\..\..\AdventOfCode2021\Files\" + _dataFileName + ".txt"))
            {
                _dataLines.Add(line);
            }
            Console.WriteLine("File found by class:FileLinesExtractCommand");
        }
    }
}
