using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    [Serializable]
    public class RoiRectangle1
    {
        public double RowStart1;
        public double ColumnStart1;
        public double RowEnd1;
        public double ColumnEnd1;

        public RoiRectangle1()
        {
            RowStart1 = 0;
            ColumnStart1 = 0;
            RowEnd1 = 0;
            ColumnEnd1 = 0;
        }
    }

    [Serializable]
    public class RoiRectangle2
    {
        public double RowCenter;
        public double ColumnCenter;
        public double Phi;
        public double Length1;
        public double Length2;

        public RoiRectangle2()
        {
            RowCenter = 0;
            ColumnCenter = 0;
            Phi = 0;
            Length1 = 0;
            Length2 = 0;
        }
    }

    [Serializable]
    public class CircleROI
    {
        public double RowCenter;
        public double ColumnCenter;
        public double Radius;
        public CircleROI()
        {
            RowCenter = 0;
            ColumnCenter = 0;
            Radius = 0;
        }
    }

    [Serializable]
    public class LineROI
    {
        public double RowStart1;
        public double ColumnStart1;
        public double RowEnd1;
        public double ColumnEnd1;
        public LineROI()
        {
            RowStart1 = 0;
            ColumnStart1 = 0;
            RowEnd1 = 0;
            ColumnEnd1 = 0;
        }
    }

    public class PointROI
    {
        public double RowCenter;
        public double ColumnCenter;

        public PointROI()
        {
            RowCenter = 0;
            ColumnCenter = 0;
        }

    }
}
