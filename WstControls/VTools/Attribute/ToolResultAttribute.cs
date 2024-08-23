using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    /// <summary>
    /// 工具名称自定义类
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ToolResultAttribute : Attribute
    {
        public string ToolResultName = "";
        public ToolResultAttribute(string toolmark)
        {
            ToolResultName = toolmark;
        }
    }
}
