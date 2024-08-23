using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;

namespace WstVisionPlus
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {            
            //处理异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);  //处理UI线程异常 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool flag = false;
            System.Threading.Mutex hMutex = new System.Threading.Mutex(true, Application.ProductName, out flag);
            bool b = hMutex.WaitOne(0, false);
            if (flag)
            {
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
            else
            {
                MessageBox.Show("当前程序已在运行，请勿重复运行。");
                Environment.Exit(1);//退出程序 
            }
        }

        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        static bool glExitApp = false;

        //处理UI线程异常
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                LogHelper.WriteErrorLog("-----------------------begin--------------------------");
                LogHelper.WriteErrorLog("Application_ThreadException" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                LogHelper.WriteErrorLog(e.Exception.ToString());
                LogHelper.WriteErrorLog("-----------------------end----------------------------");
                //while (true)
                //{//循环处理，否则应用程序将会退出
                //    if (glExitApp)
                //    {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                //        SaveLog("ExitApp");
                //        return;
                //    }
                //    System.Threading.Thread.Sleep(2 * 1000);
                //};
                Exception ex = (Exception)e.Exception;
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("不可恢复的UI线程异常，应用程序将退出！");
            }
        }

        /// <summary>
        /// 处理未捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                LogHelper.WriteErrorLog("-----------------------begin--------------------------");
                LogHelper.WriteErrorLog("CurrentDomain_UnhandledException" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                LogHelper.WriteErrorLog("IsTerminating : " + e.IsTerminating.ToString());
                LogHelper.WriteErrorLog(e.ExceptionObject.ToString());
                LogHelper.WriteErrorLog("-----------------------end----------------------------");
                //while (true)
                //{//循环处理，否则应用程序将会退出
                //    if (glExitApp)
                //    {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                //        SaveLog("ExitApp");
                //        return;
                //    }
                //    System.Threading.Thread.Sleep(2 * 1000);
                //};
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("不可恢复的非Windows窗体线程异常，应用程序将退出！");
            }
        }
    }
}
