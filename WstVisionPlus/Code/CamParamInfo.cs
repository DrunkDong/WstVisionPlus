using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstVisionPlus
{
    [Serializable]
    public class CamParam
    {
        public CamParamInfo CamInfo1;
        public CamParamInfo CamInfo2;
        public CamParamInfo CamInfo3;
        public CamParamInfo CamInfo4;
        public CamParamInfo CamInfo5;
        public CamParamInfo CamInfo6;
        public CamParamInfo CamInfo7;
        public CamParamInfo CamInfo8;
        public CamParamInfo CamInfo9;
        public CamParamInfo CamInfo10;
        public CamParamInfo CamInfo11;
        public CamParamInfo CamInfo12;

        public CamParam()
        {
            CamInfo1 = new CamParamInfo();
            CamInfo2 = new CamParamInfo();
            CamInfo3 = new CamParamInfo();
            CamInfo4 = new CamParamInfo();
            CamInfo5 = new CamParamInfo();
            CamInfo6 = new CamParamInfo();
            CamInfo7 = new CamParamInfo();
            CamInfo8 = new CamParamInfo();
            CamInfo9 = new CamParamInfo();
            CamInfo10 = new CamParamInfo();
            CamInfo11 = new CamParamInfo();
            CamInfo12 = new CamParamInfo();
        }

        public void SetParamValue(int CamIndex, CamParamInfo par)
        {
            switch (CamIndex)
            {
                case 0:
                    CamInfo1 = par;
                    break;
                case 1:
                    CamInfo2 = par;
                    break;
                case 2:
                    CamInfo3 = par;
                    break;
                case 3:
                    CamInfo4 = par;
                    break;
                case 4:
                    CamInfo5 = par;
                    break;
                case 5:
                    CamInfo6 = par;
                    break;
                case 6:
                    CamInfo7 = par;
                    break;
                case 7:
                    CamInfo8 = par;
                    break;
                case 8:
                    CamInfo9 = par;
                    break;
                case 9:
                    CamInfo10 = par;
                    break;
                case 10:
                    CamInfo11 = par;
                    break;
                case 11:
                    CamInfo12 = par;
                    break;
                default:
                    break;
            }
        }

        public void GetParamValue(int CamIndex, out CamParamInfo par)
        {
            par = new CamParamInfo();
            switch (CamIndex)
            {
                case 0:
                    par = CamInfo1;
                    break;
                case 1:
                    par = CamInfo2;
                    break;
                case 2:
                    par = CamInfo3;
                    break;
                case 3:
                    par = CamInfo4;
                    break;
                case 4:
                    par = CamInfo5;
                    break;
                case 5:
                    par = CamInfo6;
                    break;
                case 6:
                    par = CamInfo7;
                    break;
                case 7:
                    par = CamInfo8;
                    break;
                case 8:
                    par = CamInfo9;
                    break;
                case 9:
                    par = CamInfo10;
                    break;
                case 10:
                    par = CamInfo11;
                    break;
                case 11:
                    par = CamInfo12;
                    break;
                default:
                    break;
            }
        }
    }


    [Serializable]
    public class CamParamInfo
    {
        public int CameraExposure;
        public int CameraGain;
        public int TriggerDelay;

        public CamParamInfo()
        {
            CameraExposure = 200;
            CameraGain = 0;
            TriggerDelay = 0;
        }
    }
}
