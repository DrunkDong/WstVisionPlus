using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    public delegate void ChangeShowStateDel(bool state, double cost);
    public interface FrmInterface
    {
        List<ToolBase> ToolList { get; set; }
        void ShowToolRunMessage(string mes1 = "", bool isRed1 = false, string mes2 = "", bool isRed2 = false);
    }
}
