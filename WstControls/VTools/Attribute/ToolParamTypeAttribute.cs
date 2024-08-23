using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ToolParamTypeAttribute : Attribute
    {
        public ParamType paramType = ParamType.none;
        public ToolParamTypeAttribute(ParamType type)
        {
            this.paramType = type;
        }
    }

    public enum ParamType
    {
        none = 0,
        image = 1,
        region = 2,
        _int = 3,
        _double = 4,
        _tuple = 5,
        _line = 6
    }
}
