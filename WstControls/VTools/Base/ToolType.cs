using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    public enum ToolType
    {
        TransImage = 1,
        BlobImage = 2,
        ShapeModel = 3,
        NccModel = 4,
        NinePoint = 5,
        FindLine = 6,
        FindCircle = 7,
        If = 8,
        Else = 9,
        Camera = 10,
        None = 999
    }

    public enum ToolResultType
    {
        None = 0,
        Image = 1,
        Region = 2,
        RegionAndTuple = 3,
        AlignData = 4,
        line = 5,
        circle = 6,
        point = 7
    }
}
