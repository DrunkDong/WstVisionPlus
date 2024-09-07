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
    public class IfTool : ToolBase
    {
        public IfTool()
        {
            Type = ToolType.If;
            ResultType = ToolResultType.None;
        }


        public override void ReleaseReslut()
        {
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            System.Threading.Thread.Sleep(100);
            if (BingdingTool != null)
                return OperateStatus.RunElse;
            else
                return OperateStatus.OK;

        }

        public override void RefreshToolSource(List<ToolBase> toolList)
        {

        }
    }
}
