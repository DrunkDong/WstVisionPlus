using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstCommonTools
{
    public enum OperateStatus
    {
        Error = -1,
        OK = 0,
        Virtual = 1,
        Break = 2,
        RunIf = 3,
        RunElse = 4,
        ExcuteElse = 5,
        EndIf = 6
    }
}
