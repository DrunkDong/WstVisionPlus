using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace WeiVision
{
    public class StepInfo
    {
        public double mCostTime = 0.0;
        public HObject mNGResult = null;
        public List<ToolRunResult> mResList = new List<ToolRunResult>();
        public bool mResOK = false;
        public HObject mShowResult;
        public List<string> mShowString = new List<string>();
        public int mStepIndex;
        public ToolBase mTool;
        public int mToolID = 0;
        public ToolType mToolType;
        public ToolResultType mToolResultType;

        public void Release()
        {
            if (this.mResList != null)
            {
                if (this.mShowResult != null)
                {
                    this.mShowResult.Dispose();
                    this.mShowResult = null;
                }
                if (this.mNGResult != null)
                {
                    this.mNGResult.Dispose();
                    this.mNGResult = null;
                }
                this.mResList.Clear();
            }
        }
    }



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
