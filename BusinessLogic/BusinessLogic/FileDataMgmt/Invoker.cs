using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FileDataMgmt
{
    public class Invoker
    {
        private IDataFileManageCommand _onStart;

        public void SetOnStart(IDataFileManageCommand command)
        {
            _onStart = command;
        }

        public void FileDataLines()
        {
            if (_onStart is IDataFileManageCommand)
            {
                _onStart.Execute();
            }
        }

    }
}
