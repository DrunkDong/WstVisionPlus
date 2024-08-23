using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstCommonTools
{
    public static class ColorHelper
    {
        public static string RgbToHex(int red, int green, int blue)
        {
            return $"#{red:X2}{green:X2}{blue:X2}";
        }
        public static string ARgbToHex(int alpha, int red, int green, int blue)
        {
            return $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";
        }
        public static string RgbToHex(this Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        public static string ARgbToHex(this Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}
