using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;


namespace WstControls
{
    [Serializable]
    public class ToolBase : ToolParamBase
    {
        [NonSerialized]
        HDebugWindow mDebugWind;//运行窗口
        [NonSerialized]
        HDebugWindow mToolWind;//显示窗口

        List<ToolBase> mChildToolList;//子工具列表       
        double mCostTime;//执行耗时

        /// <summary>
        /// 工具子窗体显示句柄
        /// </summary>
        public HDebugWindow ToolWind
        {
            get => mToolWind;
            set => mToolWind = value;
        }
        /// <summary>
        /// 运行显示窗口
        /// </summary>
        public HDebugWindow DebugWind
        {
            get => mDebugWind;
            set => mDebugWind = value;
        }

        /// <summary>
        /// 算法运行耗时
        /// </summary>
        public double CostTime
        {
            get => mCostTime;
            set => mCostTime = value;
        }
        public List<ToolBase> ChildToolList
        {
            get => mChildToolList;
            set => mChildToolList = value;
        }

        /// <summary>
        /// 工具执行方法
        /// </summary>
        /// <param name="imageInput">外部输入源</param>
        /// <param name="toolList">工具链表</param>
        /// <param name="mIsShowResult">是否显示工具运行结果</param>
        /// <returns></returns>
        public virtual OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult) { return OperateStatus.OK; }

        /// <summary>
        /// 释放上一次运算结果
        /// </summary>
        public virtual void ReleaseReslut() { }

        /// <summary>
        /// 刷新工具输入输出源
        /// </summary>
        /// <param name="toolList">工具链表</param>
        public virtual void RefreshToolSource(List<ToolBase> toolList) { }

        /// <summary>
        /// 工具强制停止
        /// </summary>
        public virtual void ToolForceStop() { }

        public virtual void InitTool() { }

        public ToolBase()
        {
            mChildToolList = new List<ToolBase>();
        }
    }



    [Serializable]
    public class ToolParamBase
    {
        int mImageSourceToolIDMark = -1;
        string mImageSourceParam = "";
        int mRegionSourceToolIDMark = -1;
        string mRegionSourceParam = "";
        int mShapeModelSourceToolIDMark = -1;
        string mShapeModelSourceParam = "";
        ToolType mType = ToolType.None;
        ToolResultType mResultType = ToolResultType.None;
        int mToolID = 0;
        string mShowName = "";
        string mToolRemarks = "";
        bool mForceOK = false;
        int mReturnValue = -1;

        /// <summary>
        /// 工具Tool返回值
        /// </summary>
        public int ReturnValue
        {
            get => mReturnValue;
            set => mReturnValue = value;
        }
        /// <summary>
        /// 工具显示名
        /// </summary>
        public string ShowName
        {
            get => mShowName;
            set => mShowName = value;
        }
        /// <summary>
        /// 是否强制工具输出OK
        /// </summary>
        public bool ForceOK
        {
            get => mForceOK;
            set => mForceOK = value;
        }
        /// <summary>
        /// 工具类型
        /// </summary>
        public ToolType Type
        {
            get => mType;
            set => mType = value;
        }
        /// <summary>
        /// 工具输出结果类型
        /// </summary>
        public ToolResultType ResultType
        {
            get => mResultType;
            set => mResultType = value;
        }
        /// <summary>
        /// 工具内部ID索引
        /// </summary>
        public int ToolID
        {
            get => mToolID;
            set => mToolID = value;
        }
        /// <summary>
        /// 图像源输入地址
        /// </summary>
        public int ImageSourceToolIDMark
        {
            get => mImageSourceToolIDMark;
            set => mImageSourceToolIDMark = value;
        }
        /// <summary>
        /// 图像源输入参数名
        /// </summary>
        public string ImageSourceParam
        {
            get => mImageSourceParam;
            set => mImageSourceParam = value;
        }
        /// <summary>
        /// 区域源输入地址
        /// </summary>
        public int RegionSourceToolIDMark
        {
            get => mRegionSourceToolIDMark;
            set => mRegionSourceToolIDMark = value;
        }
        /// <summary>
        /// 区域源输入参数名
        /// </summary>
        public string RegionSourceParam
        {
            get => mRegionSourceParam;
            set => mRegionSourceParam = value;
        }
        /// <summary>
        /// 模板源输入地址
        /// </summary>
        public int ShapeModelSourceToolIDMark
        {
            get => mShapeModelSourceToolIDMark;
            set => mShapeModelSourceToolIDMark = value;
        }
        /// <summary>
        /// 模板源输入参数名
        /// </summary>
        public string ShapeModelSourceParam
        {
            get => mShapeModelSourceParam;
            set => mShapeModelSourceParam = value;
        }
        public string ToolRemarks
        {
            get => mToolRemarks;
            set => mToolRemarks = value;
        }
    }
}
