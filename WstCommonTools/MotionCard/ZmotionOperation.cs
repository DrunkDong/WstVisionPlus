using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstCommonTools
{
    public class ZmotionOperation
    {
        public IntPtr g_handle;
        public string g_command;       //发送的命令

        public string IP { get; set; }
        public bool IsOpen;
        public int OpenMotionCard()
        {
            int res = zmcaux.ZAux_OpenEth(IP, out g_handle);
            //链接失败
            if ((long)g_handle == 0)
                return 1;


            zmcaux.ZAux_Direct_SetDatumIn(g_handle, 0, 24);        //原点
            zmcaux.ZAux_Direct_SetFwdIn(g_handle, 0, 28);          //正限位in(2)
            zmcaux.ZAux_Direct_SetRevIn(g_handle, 0, 29);          //负限位in(3)
            zmcaux.ZAux_Direct_SetInvertIn(g_handle, 28, 1);    //信号反转
            zmcaux.ZAux_Direct_SetInvertIn(g_handle, 29, 1);    //信号反转

            //设置轴参数
            zmcaux.ZAux_Direct_SetAtype(g_handle, 0, 1);       //轴类型
            zmcaux.ZAux_Direct_SetUnits(g_handle, 0, 1);        //脉冲当量
            zmcaux.ZAux_Direct_SetLspeed(g_handle, 0, 0);    //起始速度
            zmcaux.ZAux_Direct_SetSpeed(g_handle, 0, 50000);    //运行速度
            zmcaux.ZAux_Direct_SetAccel(g_handle, 0, 500000);   //加速度
            zmcaux.ZAux_Direct_SetDecel(g_handle, 0, 500000);   //减速度
            zmcaux.ZAux_Direct_SetCreep(g_handle, 0, 2000);     //爬行速度
            zmcaux.ZAux_Direct_SetInvertIn(g_handle, 24, 1);    //原点信号反转

            return res;

        }
        public void CloseMotionCard()
        {
            if ((long)g_handle != 0)
            {
                zmcaux.ZAux_Close(g_handle);
                g_handle = (IntPtr)0;
            }
        }

        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="AxisNum">轴号</param>
        /// 
        public int StartHome(int AxisNum, int TimeOut = 10000)
        {
            var task = Task.Run(() => 
            {
                float home_speed = 50000;
                float slow_speed = 20000;

                zmcaux.ZAux_Direct_SetSpeed(g_handle, 0, home_speed);         //设置速度
                zmcaux.ZAux_Direct_SetCreep(g_handle, 0, slow_speed);         //2次回零反找速度
                zmcaux.ZAux_Direct_Singl_Datum(g_handle, 0, 3);                //先正向找原点
                Thread.Sleep(100);
                while (true)
                {
                    int state = 0;
                    float pos = 0;
                    uint value1 = 0;
                    uint value2 = 0;
                    zmcaux.ZAux_Direct_GetDpos(g_handle, 0, ref pos);
                    zmcaux.ZAux_Direct_GetIfIdle(g_handle, 0, ref state);
                    zmcaux.ZAux_Direct_GetIn(g_handle, 28, ref value1);
                    zmcaux.ZAux_Direct_GetIn(g_handle, 29, ref value2);
                    if (state == -1 && pos == 0 && value1 == 0 && value2 == 0)//若状态停止且目标不在正负限位
                    {
                        return 0;
                    }
                    if (state == -1 && value1 == 1)//若状态停止且在正限位,则走到负限位
                    {
                        //zmcaux.ZAux_Direct_Singl_Datum(g_handle, 0, 4);
                       SingAxisVmove(0, -1);
                    }
                    if (state == -1 && value2 == 1)//若状态停止且在负限位，则回零
                    {
                        zmcaux.ZAux_Direct_Singl_Datum(g_handle, 0, 3);
                    }
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            });

            if (task.Wait(TimeSpan.FromMilliseconds(TimeOut)))
                return 0;
            else
            {
                zmcaux.ZAux_Direct_Singl_Cancel(g_handle, AxisNum, 2);//0 取消当前运动 1 取消缓冲的运动 2 取消当前运动和缓冲运动
                return 1;
            }
        }

        public void SingAxisVmove(int AxisNum,int dir)
        {
            zmcaux.ZAux_Direct_Singl_Vmove(g_handle, AxisNum, dir);
        }

        public void SingAxisMove(int AxisNum, int dir, int Distance)
        {
            zmcaux.ZAux_Direct_Singl_Move(g_handle, AxisNum, dir * Convert.ToSingle(Distance));
        }

        /// <summary>
        /// 单轴停止
        /// </summary>
        /// <param name="AxisNum"></param>
        public void SingleAxisMoveStop(int AxisNum)
        {
            if ((long)g_handle != 0)
            {
                zmcaux.ZAux_Direct_Singl_Cancel(g_handle, AxisNum, 2);//0 取消当前运动 1 取消缓冲的运动 2 取消当前运动和缓冲运动
            }
        }

        /// <summary>
        /// 绝对位置移动
        /// </summary>
        /// <param name="AxisNum"></param>
        /// <param name="pulse"></param>
        /// <param name="speed"></param>
        public void SingleAxisMoveAbs(int AxisNum, float pulse, float speed)
        {
            zmcaux.ZAux_Direct_SetSpeed(g_handle, AxisNum, speed);
            zmcaux.ZAux_Direct_Singl_MoveAbs(g_handle, AxisNum, pulse);
        }

        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="AxisNum"></param>
        /// <param name="pulse"></param>
        /// <param name="speed"></param>
        public void SingleAxisMoveRel(int AxisNum, float pulse, float speed)
        {
            zmcaux.ZAux_Direct_SetSpeed(g_handle, AxisNum, speed);
            zmcaux.ZAux_Direct_Singl_Move(g_handle, AxisNum, pulse);
        }
        public float GetFbkPosition(int AxisNum)
        {
            float res = 0;
            zmcaux.ZAux_Direct_GetMpos(g_handle, AxisNum, ref res);
            return res;
        }

        /// <param >发送指令位置</param>
        /// <param moveMode="运动模式"></param>
        /// <param Sportspeed="运动速度"></param>
        /// <param Sportdist="运动距离"></param>
        /// <returns></returns>
        public int AxisSport(int Axis, int moveMode, float Sportspeed, float Sportdist)
        {
            if ((long)g_handle == 0)
            {
                return -1;
            }
            //0是相对 1是绝对
            if (moveMode == 0)
            {
                //相对
                zmcaux.ZAux_Direct_SetSpeed(g_handle, Axis, Sportspeed);         //设置速度

                zmcaux.ZAux_Direct_Singl_Move(g_handle, Axis, Sportdist);

            }
            else
            {
                //绝对
                zmcaux.ZAux_Direct_SetSpeed(g_handle, Axis, Sportspeed);         //设置速度

                zmcaux.ZAux_Direct_Singl_MoveAbs(g_handle, Axis, Sportdist);

            }

            return 0;

        }

        /// <summary>
        /// 单轴运动
        /// </summary>
        /// <param name="AxisNum"></param>
        /// <param name="pulse"></param>
        /// <param name="speed"></param>

        public int JogMove(int axis, int dir)
        {
            int res = zmcaux.ZAux_Direct_Singl_Vmove(g_handle, axis, dir * 500);
            return 0;
        }

        /// <summary>
        /// 获取当前实时坐标
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="CurrentPosition"></param>
        /// <param name="AxisIsFinsh"></param>
        /// <param name="AxisStatus"></param>
        /// <returns></returns>
        public int GetRealPosition(int Axis, out float realPos, out float MPos, out int axisFin, out int status)
        {
            realPos = 0;
            axisFin = 0;
            status = 0;
            MPos = 0;
            int CurrentPosition = zmcaux.ZAux_Direct_GetDpos(g_handle, Axis, ref realPos);
            zmcaux.ZAux_Direct_GetMpos(g_handle, Axis, ref MPos);
            int AxisIsFinsh = zmcaux.ZAux_Direct_GetIfIdle(g_handle, Axis, ref axisFin);
            int AxisStatus = zmcaux.ZAux_Direct_GetAxisStatus(g_handle, Axis, ref status);
            return 0;

        }

        public void SetRunSpeed(int AxisNum, float speed)
        {
            zmcaux.ZAux_Direct_SetSpeed(g_handle, AxisNum, speed);
        }

        //读取运动状态
        public int GetAxisInpState()
        {
            int run_state = 2;
            zmcaux.ZAux_Direct_GetIfIdle(g_handle, 0, ref run_state); //读取轴 0 运动状态，0-运动，-1 停止
            return run_state;
        }
        //读取加速度参数
        public float GetAccSpeed()
        {
            float run_state = 0;
            zmcaux.ZAux_Direct_GetAccel(g_handle, 0, ref run_state);
            return run_state;
        }
        //设置加速度
        public int SetetAccSpeed(float num)
        {
            float run_state = 0;
            int ret = zmcaux.ZAux_Direct_SetAccel(g_handle, 0, num);
            return ret;
        }
        //读取减速度
        public float GetDecSpeed()
        {
            float run_speed = 0;
            // zmcaux.ZAux_Direct_SetFastDec(g_handle, 0, ref run_speed);

            return run_speed;
        }
        //设置减速度 
        public int SetetDecSpeed(float num)
        {
            float run_state = 0;
            int ret = zmcaux.ZAux_Direct_SetDecel(g_handle, 0, num);
            return ret;
        }


        //设置轴加减速状态
        public int SetSramp()
        {
            zmcaux.ZAux_Direct_SetSramp(g_handle, 0, 0);
            return 0;
        }
        //获取轴状态
        public int GetAxisStatus()
        {
            int axisstatus = 0;
            zmcaux.ZAux_Direct_GetAxisStatus(g_handle, 0, ref axisstatus);
            return axisstatus;

        }

        public void MovePostion(float pos, float speed)
        {
            //绝对运动
            SingleAxisMoveAbs(0, pos, speed);
            Task t = new Task(() =>
            {
                while (true)
                {
                    int state = 0;
                    //运动状态
                    state = GetAxisInpState();
                    //停止终止
                    if (state == -1)
                    {
                        Console.WriteLine(pos);
                        break;
                    }
                        
                }
            });
            t.Start();
            Task.WaitAll(t);

        }

        //设置轴运动速度
        public void SetMoveSpeed(float Sportspeed)
        {
            int a = zmcaux.ZAux_Direct_SetSpeed(g_handle, 1, Sportspeed);
        }


    }
}
