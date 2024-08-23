using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    //工具信息类
    public class ToolInfo
    {
        public string ToolName = "";//工具显示名称
        public string ToolRemarks = "";//工具注释
        public bool ToolRunStatus = false;//工具运行状态
        public int StepIndex = -1;//步骤序号
        public int ToolID = -1;//工具内部ID
        public double CostTime = 0.0;//耗时
        public HObject NGResultObj = null;//NG结果显示类
        public HObject ShowResult = null;//
        public List<ToolRunResult> ResultList = new List<ToolRunResult>();//运行结果
        public List<string> ShowString = new List<string>();//显示字符串
        public ToolBase ToolCurr;
        public ToolType ToolType;
        public ToolResultType ToolResultType;

        public void Release()
        {
            if (this.ResultList != null)
            {
                if (this.ShowResult != null)
                {
                    this.ShowResult.Dispose();
                    this.ShowResult = null;
                }
                if (this.NGResultObj != null)
                {
                    this.NGResultObj.Dispose();
                    this.NGResultObj = null;
                }
                this.ResultList.Clear();
            }
        }
    }

    //运行结果类
    public class ToolRunResult
    {
        // Fields
        public byte[] mByteValue;
        public double[] mDoubleValue;
        public List<string> mMesDataOutPut;
        public HObject mRegionOutPut = null;
        public HObject mImageOutPut = null;
        public HTuple mHTupleData;
        public int[] mIntValue;
        public bool mJudge;
        public int mResNum;
        public string[] mString;

        public ToolRunResult()
        {
            mDoubleValue = new double[8];
            mMesDataOutPut = new List<string>();
        }
    }
}
