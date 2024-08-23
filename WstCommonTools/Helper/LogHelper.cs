using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace WstCommonTools
{
    public static class LogHelper
    {
        public static readonly ILog sCommonLogger = log4net.LogManager.GetLogger("Info");
        public static readonly ILog sErrorLogger = log4net.LogManager.GetLogger("ErrorLog");
        public static readonly ILog sExceptionLogger = log4net.LogManager.GetLogger("ExceptionLog");


        public static void WriteExceptionLog(object strLog)
        {
            sExceptionLogger.Fatal(strLog);
        }
        public static void WriteInfoLog(object strLog)
        {
            sCommonLogger.Info(strLog);
        }
        public static void WriteErrorLog(object strLog)
        {
            sErrorLogger.Error(strLog);
        }
        public static void WriteInfoLog(string str, Exception strLog)
        {
            sCommonLogger.Info(str, strLog);
        }
        public static void WriteErrorLog(string str, Exception strLog)
        {
            sErrorLogger.Error(str, strLog);
        }
        public static void WriteExceptionLog(string str, Exception strLog)
        {
            sExceptionLogger.Fatal(str, strLog);
        }
    }
}
