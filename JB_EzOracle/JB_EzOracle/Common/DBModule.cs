using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb; //!!!
using System.Data;
using System.Data.OracleClient;

namespace JB_EzOracleSQL.Common
{
    public class DBModule
    {
        //public static OleDbConnection Conn = new OleDbConnection();
        public static OracleConnection Conn = new OracleConnection();
        //----------------------------------------------------------
        //函式名稱: DB_Connect
        //說明: Oracle DB Connection
        //參數: 主機名稱,OWNER名稱,密碼
        //回傳值: OleDbConnection
        //----------------------------------------------------------
        public static OracleConnection DB_Connect(string host, string owner, string pwd)
        {
            OracleConnectionStringBuilder Csbuilder = new OracleConnectionStringBuilder();
            try
            {
                //如果使用OleDbConnection才用下列這個連線字串
                //設定連線字串參考(oracle)Provider=MSDAORA;Data Source=xxxxx;Persist Security Info=True;User ID=xxxx
                //Csbuilder.Provider = "MSDAORA";
                Csbuilder.DataSource = host;
                Csbuilder.Add("User ID", owner); //加入使用者帳號
                Csbuilder.Add("Password", pwd);  //加入密碼帳號
                Conn.ConnectionString = Csbuilder.ConnectionString;
                //Conn = new OleDbConnection(Csbuilder.ConnectionString); //設定Connection的連線字串。
                Conn.Open();
                return Conn;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                Csbuilder = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: DB_Disconnect
        //說明: Close Oracle DB Connection
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        public static void DB_Disconnect()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            catch(Exception)
            {
                //...
            }
        }
        //----------------------------------------------------------
        //函式名稱: DB_ExecQuery
        //說明: 
        //參數: SQL
        //回傳值: DataTable
        //----------------------------------------------------------
        public static DataTable DB_ExecQuery(string sSql)
        {
            DataTable Rslt_dt = new DataTable();
            try
            {
                //OleDbDataAdapter da = new OleDbDataAdapter(sSql, Conn);  //OleDb
                OracleDataAdapter da = new OracleDataAdapter(sSql, Conn);
                da.Fill(Rslt_dt);
                return Rslt_dt;
            }
            catch (Exception ex)
            {
                Rslt_dt.Columns.Add("錯誤訊息"); //加入新欄位名稱
                DataRow dr = Rslt_dt.NewRow(); //New一個DataRow物件
                dr["錯誤訊息"] = ex.Message.ToString();
                Rslt_dt.Rows.Add(dr); //加入一筆資料
            }
            return Rslt_dt;
        }
        //----------------------------------------------------------
        //函式名稱: DB_ExecNonQuery
        //說明: 
        //參數: SQL
        //回傳值: 成功或失敗訊息
        //----------------------------------------------------------
        public static string DB_ExecNonQuery(string nSql)
        {
            if (Conn.State == ConnectionState.Closed) return "失敗=資料庫未連結";
            try
            {
                //OleDbCommand cmdGeneral = new OleDbCommand(nSql, Conn); //OleDb
                OracleCommand cmdGeneral = new OracleCommand(nSql, Conn);
                double Result = cmdGeneral.ExecuteNonQuery();
                return "成功=" + Result.ToString();
            }
            catch (Exception ex)
            {
                return "失敗=" + ex.Message;
            }
        }

        //----------------------------------------------------------
        //函式名稱: DB_ExecNonQuery
        //說明: 
        //參數: SQL
        //回傳值: 成功或失敗訊息
        //----------------------------------------------------------
        public static string DB_ExecNonQuery_Trans(ref OracleTransaction transaction, string nSql)
        {
            if (Conn.State == ConnectionState.Closed) return "失敗=資料庫未連結";
            try
            {
                if (transaction == null) //transaction為null時，才需要重新指定，否則會error
                {
                    transaction = Conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                }
               OracleCommand command = Conn.CreateCommand();
               //指定command的Transaction為transaction
                command.Transaction = transaction;

                command.CommandText = nSql;
                double Result = command.ExecuteNonQuery();

                return "成功=" + Result.ToString();
            }
            catch (Exception ex)
            {
                return "失敗=" + ex.Message;
            }
        }
    }
}
