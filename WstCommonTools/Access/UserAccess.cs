using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using ADOX;

namespace WstCommonTools
{
    public class UserAccess
    {
        string mAccessConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig\\Access\\Users\\user.mdb" +
            "; Jet OLEDB:Database Password = qwer1234";


        public UserAccess()
        {
        }
        

        public bool CreateNewUserTable()
        {
            try
            {
                //创建目录
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig\\Access\\Users"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig\\Access\\Users").Create();           
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\user.mdb"))
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create(mAccessConnStr);
                    OleDbConnection conn = new OleDbConnection(mAccessConnStr);
                    string dbstr = "create table UerInfoTable(UserName TEXT, UserPassWord TEXT, UserLevel TEXT)";
                    OleDbCommand oleDbCom = new OleDbCommand(dbstr, conn);
                    conn.Open();
                    oleDbCom.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                return false;
            }
        }

        public bool DeleOneData(string name)
        {
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                string DeleStr = "delete from UerInfoTable where UserName = '" + name + "'";
                OleDbCommand comm = new OleDbCommand(DeleStr, odcConnection);
                comm.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return false;
            }
        }

        public bool UpdateUserPassWord(string userName,string userPassWord)
        {
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                string UpdateStr = "update UerInfoTable set UserPassWord = '"+ userPassWord + "'  where UserName = '" + userName + "'";
                OleDbCommand comm = new OleDbCommand(UpdateStr, odcConnection);
                int aaa = comm.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return false;
            }
        }

        public bool UpdateUserLevel(string userName, string level)
        {
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                string UpdateStr = "update UerInfoTable set UserLevel = '" + level + "'  where UserName = '" + userName + "'";
                OleDbCommand comm = new OleDbCommand(UpdateStr, odcConnection);
                comm.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return false;
            }
        }

        public bool InsertOneData(UserInfo info)
        {
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                string insertStr = "Insert into UerInfoTable( UserName , UserPassWord , UserLevel ) values ( '" + 
                    info.UserName + "', '" +
                    info.UserPassWord + "','" + 
                    info.UserLevel + "')";
                OleDbCommand oleCommand = new OleDbCommand(insertStr, odcConnection);
                oleCommand.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return false;
            }
        }

        public DataTable ReadAllData()
        {
            DataTable dt = new DataTable();
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                //3、输入查询语句
                string str = "select * from UerInfoTable";
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(str, odcConnection);
                dbDataAdapter.Fill(dt);
                odcConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return dt;
            }
        }

        public string GetOneData(string strSql)
        {
            string returnStr = "";
            DataTable dt = new DataTable();
            OleDbConnection odcConnection = new OleDbConnection(mAccessConnStr);
            odcConnection.Open();
            try
            {
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(strSql, odcConnection);
                dbDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                    returnStr = dt.Rows[0][0].ToString();
                odcConnection.Close();
                return returnStr;
            }
            catch (Exception ex)
            {
                odcConnection.Close();
                LogHelper.WriteErrorLog(ex);
                return returnStr;
            }


        }

    }

    public class UserInfo
    {
        public string UserName;
        public string UserPassWord;
        public string UserLevel;

        public UserInfo() { }

        public UserInfo(string name, string pw, string level)
        {
            UserName = name;
            UserPassWord = pw;
            UserLevel = level;
        }
    }
}
