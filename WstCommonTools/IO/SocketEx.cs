using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace WstCommonTools
{
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    #region 服务端类
    public class TCPServer
    {
        //私有变量
        private SocketMessage m_SocketMsgDelegate = null;
        private Socket m_Listener = null; //监听
        private Socket m_Handler = null; //握手

        //公开变量
        public delegate void SocketMessage(string str);
        public string m_strInfo = null;

        #region InitServer --服务端初始化
        public void InitServer(string strAddr, int nPort, SocketMessage sockMsg = null)
        {
            if (sockMsg != null)
            {
                m_SocketMsgDelegate = sockMsg;
            }

            //创建套接字  
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(strAddr), nPort);
            m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                m_Listener.Bind(ipe);
                m_Listener.Listen(10);
 
                //开启异步监听连接    
                m_Listener.BeginAccept(new AsyncCallback(AcceptCallback), m_Listener);
                //等待直到连接 
                if (m_SocketMsgDelegate!=null)
                {
                    m_SocketMsgDelegate("SERVER ONLINE");
                }              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                m_SocketMsgDelegate(e.Message);
            }
        }
        #endregion

        #region AcceptCallback函数
        private void AcceptCallback(IAsyncResult iar)
        {
            Socket listener = (Socket)iar.AsyncState;
            m_Handler = listener.EndAccept(iar); //结束接收请求

            //创建状态对象    
            StateObject state = new StateObject();
            state.workSocket = m_Handler;

            m_strInfo = m_Handler.RemoteEndPoint.ToString();

            //发送信息
            if (m_SocketMsgDelegate != null)
            {
                m_SocketMsgDelegate("CLIENT ONLINE");
            }

            //开启数据回调
            m_Handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        }
        #endregion

        #region ReceiveCallback函数
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                if (handler!=null && handler.Connected)
                {
                    //读取数据   
                    int bytesRead = handler.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        state.sb.Append(Encoding.GetEncoding("GB2312").GetString(state.buffer, 0, bytesRead));
                        //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        content = state.sb.ToString();

                        if (m_SocketMsgDelegate != null)
                        {
                            m_SocketMsgDelegate(content);
                        }

                        //发送数据
                        Send(content);

                        state.sb.Clear();
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        if (m_SocketMsgDelegate != null)
                        {
                            m_SocketMsgDelegate("CLIENT OFFLINE");
                        }
                        m_Listener.BeginAccept(new AsyncCallback(AcceptCallback), m_Listener);
                    }
                }
                else
                {
                    if (m_SocketMsgDelegate != null)
                    {
                        m_SocketMsgDelegate("SERVER OFFLINE");
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
                if (m_SocketMsgDelegate != null)
                {
                    string str = string.Format("{0} {1}", ex.ErrorCode, ex.Message);
                    m_SocketMsgDelegate(str);
                    m_SocketMsgDelegate("CLIENT OFFLINE");
                }
                m_Listener.BeginAccept(new AsyncCallback(AcceptCallback), m_Listener);
            }
        }
        #endregion

        #region Send函数
        public void Send(String data)
        {
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            byte[] byteData = Encoding.GetEncoding("GB2312").GetBytes(data);
            m_Handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), m_Handler);
        }
        #endregion

        #region SendCallback函数
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region CloseSocket函数
        public void CloseSocket()
        {
            try
            {
                if (m_Handler != null && m_Handler.Connected)
                {
                    m_Handler.Shutdown(SocketShutdown.Both);
                    m_Handler.Close();
                    m_Listener.Dispose();
                }
            }
            catch (Exception ex)
            { 
            }
        }
        #endregion
    }
    #endregion

    #region 客户端类
    public class TCPClient
    {
        ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        public delegate void SocketMessage(string str);
        private SocketMessage m_SocketMsgDelegate = null;
        private Socket m_Client = null;
        private Socket m_Handler = null;
        private IPEndPoint m_ipe;
        public string m_strInfo;
        public bool IsConnectionSuccessful;

        #region InitClient --客户端初始化
        public bool InitClient(string strAddr, int nPort, SocketMessage sockMsg = null)
        {
            if (sockMsg != null)
            {
                m_SocketMsgDelegate = sockMsg;
            }
            //端口及IP  
            m_ipe = new IPEndPoint(IPAddress.Parse(strAddr), nPort);
            //创建套接字  
            m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //开始连接到服务器  
            m_Client.BeginConnect(m_ipe, new AsyncCallback(ConnectCallback), m_Client);
            if (TimeoutObject.WaitOne(3000, false))
            {
                if (IsConnectionSuccessful)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        #endregion

        #region ConnectCallback函数
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                m_Handler = (Socket)ar.AsyncState;
                m_Handler.EndConnect(ar);

                if (m_SocketMsgDelegate != null)
                {
                    m_strInfo = m_Handler.LocalEndPoint.ToString();
                    IsConnectionSuccessful = true;
                }

                //创建状态对象    
                StateObject state = new StateObject();
                state.workSocket = m_Handler;

                //开启数据回调
                m_Handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallBack), state);

            }
            catch (Exception e)
            {
                IsConnectionSuccessful = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                TimeoutObject.Set();
            }
        }
        #endregion

        #region ReceiveCallBack函数
        private void ReceiveCallBack(IAsyncResult iar)
        {
            String content = String.Empty;
            StateObject state = (StateObject)iar.AsyncState;
            Socket handler = state.workSocket;

            try
            {
                if (handler != null && handler.Connected)
                {
                    //读取数据   
                    int bytesRead = handler.EndReceive(iar);
                    if (bytesRead > 0)
                    {
                        state.sb.Append(Encoding.GetEncoding("GB2312").GetString(state.buffer, 0, bytesRead));
                        //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        content = state.sb.ToString();

                        if (m_SocketMsgDelegate != null)
                        {
                            m_SocketMsgDelegate(content);
                        }

                        state.sb.Clear();
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallBack), state);
                    }
                    else
                    {
                        if (m_SocketMsgDelegate != null)
                        {
                            m_SocketMsgDelegate("SERVER OFFLINE");
                        }

                        //关闭并且允许重复使用
                        m_Client.Disconnect(true);
                        //重新连接到服务器  
                        m_Client.BeginConnect(m_ipe, new AsyncCallback(ConnectCallback), m_Client);
                    }
                }
                else
                {
                    if (m_SocketMsgDelegate != null)
                    {
                        m_SocketMsgDelegate("CLIENT OFFLINE");
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                if (m_SocketMsgDelegate != null)
                {
                    string str = string.Format("{0} {1}", ex.ErrorCode, ex.Message);
                    m_SocketMsgDelegate(str);
                    m_SocketMsgDelegate("DISCONNECT");
                }
            }
        }
        #endregion

        #region Send函数
        public void Send(String data)
        {
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            byte[] byteData = Encoding.GetEncoding("GB2312").GetBytes(data);
            m_Handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), m_Handler);
        }
        #endregion

        #region SendCallback函数
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region CloseSocket函数
        public void CloseSocket()
        {
            try
            {
                if (m_Handler != null)
                {
                    m_Handler.Shutdown(SocketShutdown.Both);
                    m_Handler.Close();
                    m_Client.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
    #endregion

    #region IPInfo
    public class IPInfo
    {
        public string m_strIPAddr;
        public int m_nIPPort;
        public IPInfo()
        {
            m_strIPAddr = "127.0.0.1";
            m_nIPPort = 60000;
        }
    }
    #endregion

}
