using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WstCommonTools
{
    [Serializable]
    public class ColorEx
    {
        public Color color;
        public ShowMode showMode;
        public ShowType showType;
        public ColorEx()
        {
            color = Color.Red;
            showMode = ShowMode.Margin;
            showType = ShowType.Region;
        }
        public ColorEx(Color colr)
        {
            color = colr;
        }
    }
    [Serializable]
    public enum ShowMode
    {
        Margin = 1,
        Fill = 2
    }
    [Serializable]
    public enum ShowType
    {
        Region = 1,
        Xld = 2,
        contours = 3,
    }
}
