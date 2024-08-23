using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WstControls
{
    public static class ToolParamHelper
    {
        public static List<string> GetParamsNames<T>(T t, ToolResultType resultType, ParamType paramType)
        {
            var list = new List<string>();
            Type type = t.GetType();
            PropertyInfo toolResult = type.GetProperty("ResultType");
            ToolResultType result = (ToolResultType)toolResult.GetValue(t);
            if (result.Equals(resultType))
            {
                PropertyInfo[] infos = type.GetProperties();
                foreach (var item in infos)
                {
                    if (item.GetParamType().Equals(paramType))
                    {
                        string name = item.GetToolResultParamName();
                        if (name != "")
                            list.Add(name);
                    }
                }
            }
            return list;
        }

        public static string GetToolResultParamName(this PropertyInfo property)
        {
            string paramName = "";
            ToolResultAttribute attribute = property.GetCustomAttribute<ToolResultAttribute>();
            if (attribute != null)
            {
                paramName = property.GetName();
            }
            return paramName;
        }

        public static T GetParamValueByName<T>(ToolBase toolBase, string name) where T : new()
        {
            T t = new T();
            Type type = toolBase.GetType();
            PropertyInfo toolResult = type.GetProperty(name);
            if (toolResult != null)
            {
                t = (T)toolResult.GetValue(toolBase);
            }
            return t;
        }

        public static ParamType GetParamType(this PropertyInfo property)
        {
            ParamType type = ParamType.none;
            ToolParamTypeAttribute attribute = property.GetCustomAttribute<ToolParamTypeAttribute>();
            if (attribute != null)
            {
                type = attribute.paramType;
            }
            return type;
        }

        public static string GetName(this PropertyInfo pi)
        {
            string result = pi.Name;
            XmlElementAttribute customAttribute = pi.GetCustomAttribute<XmlElementAttribute>();
            if (customAttribute != null && !customAttribute.ElementName.IsNullOrEmpty())
            {
                result = customAttribute.ElementName;
            }

            return result;
        }
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
