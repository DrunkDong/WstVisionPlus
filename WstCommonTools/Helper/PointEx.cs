using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstCommonTools
{
    [Serializable]
    public class PointEx
    {
        public int X;
        public int Y;

        public PointEx(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
