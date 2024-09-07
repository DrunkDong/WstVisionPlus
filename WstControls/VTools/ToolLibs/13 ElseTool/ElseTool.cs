using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    [Serializable]
    public class ElseTool : ToolBase
    {
        public ElseTool()
        {
            Type = ToolType.Else;
            ResultType = ToolResultType.None;           
        }
        public override void ReleaseReslut()
        {
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            System.Threading.Thread.Sleep(100);
            return OperateStatus.ExcuteElse;
        }

        public override void RefreshToolSource(List<ToolBase> toolList)
        {
           
        }
    }
}
