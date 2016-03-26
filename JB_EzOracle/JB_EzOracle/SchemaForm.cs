using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; //!!! Process

namespace JB_EzOracleSQL
{
    public partial class SchemaForm : Form
    {
        private string [][] PathLog = new string [0][]; //放置Table name&對應的檔案路徑
        
        public SchemaForm()
        {
            InitializeComponent();
            lb_pathlist_sn.Visible = false;
            openFileDialog.Filter="Word檔案|*.doc|Excel files|*.xls|All files|*.*";  //儲存檔案篩選條件
        }

        private void SchemaForm_Shown(object sender, EventArgs e)
        {
            GetUserTables(); //取得此owner下所有Table name
            GetPathLog(); //將對應路徑儲存到Array
        }
        
        //----------------------------------------------------------
        //函式名稱: lb_refresh_LinkClicked
        //說明: Reload everything
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void lb_refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetUserTables(); //取得此owner下所有Table name
            GetPathLog(); //將對應路徑儲存到Array
            lb_pathlist.Items.Clear();
            lb_pathlist_sn.Items.Clear();
            tb_newpath.Text = "";
        }
        //----------------------------------------------------------
        //函式名稱: GetUserTables
        //說明: 取得此owner下所有Table name
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void GetUserTables()
        {
            cb_TableName.Items.Clear();
            string selectCmd = "SELECT TABLE_NAME,TABLESPACE_NAME FROM USER_TABLES";
            try
            {
                DataTable dt_col = Common.DBModule.DB_ExecQuery(selectCmd);
                if (dt_col==null)
                {
                    gb_set.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < dt_col.Rows.Count; i++)
                    {
                        cb_TableName.Items.Add(dt_col.Rows[i].ItemArray[0].ToString()); //dt_col.Rows[i].ItemArray[j] : 第i列資料, 第j個欄位
                    }
                    dt_col.Dispose();
                }
                dt_col = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤： "+ex.Message, "例外錯誤");
            }
        }
        //----------------------------------------------------------
        //函式名稱: GetPathLog
        //說明: 將table_schema.ini的資料放在記憶體
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void GetPathLog()
        {
            //先清空Array
            Array.Clear(PathLog, 0, PathLog.Length);
            Array.Resize(ref PathLog,0); 

            if (File.Exists("table_schema.ini"))
            {
                try
                {
                    StreamReader sr = new StreamReader("table_schema.ini", Encoding.Default);
                    Int32 index = 0;
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine(); //一行一行讀

                        string str_table_name = str.Substring(0, str.IndexOf(",")); //table name
                        string str_path = str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1); //檔案路徑

                        if (str == "") continue; //若為空白行則跳過
                        Array.Resize(ref PathLog, PathLog.Length + 1); //Resize
                        PathLog[index] = new string[] { str_table_name, str_path,index.ToString()}; //{表格名稱,檔案路徑,檔案中的行號}
                        index++;
                    }
                    sr.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤："+ex.Message,"錯誤訊息");
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_close_Click
        //說明: 關閉此畫面
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------------------------------------------
        //函式名稱: SchemaForm_FormClosing
        //說明: 關閉此畫面時
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SchemaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Array.Clear(PathLog, 0, PathLog.Length); //Clear Array
            Array.Resize(ref PathLog, 0); //Free Array
        }
        //----------------------------------------------------------
        //函式名稱: cb_TableName_SelectedIndexChanged
        //說明: 選擇Table name
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void cb_TableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_pathlist.Items.Clear();
            lb_pathlist_sn.Items.Clear();
            for (int i = 0; i < PathLog.Length; i++)
            {
                if (PathLog[i][0] == tb_owner.Text + "." + cb_TableName.SelectedItem.ToString())
                {
                    lb_pathlist.Items.Add(PathLog[i][1]); //加入路徑
                    lb_pathlist_sn.Items.Add(PathLog[i][2]); //加入在檔案中的行號
                }
            }
        }
        
        //----------------------------------------------------------
        //函式名稱: bt_open_Click
        //說明: 開啟選擇檔案
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_open_Click(object sender, EventArgs e)
        {
            if (lb_pathlist.SelectedIndex >= 0)
            {
                try
                {
                    Process.Start(lb_pathlist.SelectedItem.ToString()); //開啟檔案
                }
                catch (Exception ex)
                {
                    MessageBox.Show("開啟失敗!\n請檢查該檔案是否被移除! \n或其他程式正使用中!\n內部錯誤訊息：" + ex.Message, "錯誤");
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_chgpath_Click
        //說明: 選擇新的Table schema檔案位置
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_chgpath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tb_newpath.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤：" + ex.Message, "錯誤訊息");
                }
                finally
                {
                    openFileDialog.Dispose();
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: llb_openlog_LinkClicked
        //說明: 打開table_schema.ini
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void llb_openlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists("table_schema.ini"))
            {
                Process.Start("notepad", "table_schema.ini"); //開啟table_schema.ini
            }
            else
            {
                MessageBox.Show("table_schema.ini 不存在!\n無法開啟!!", "存取失敗");
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_save_Click
        //說明: 儲存
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (File.Exists("table_schema.ini"))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("table_schema.ini", true, System.Text.Encoding.Default);
                    sw.WriteLine(tb_owner.Text + "." + cb_TableName.SelectedItem.ToString() + "," + tb_newpath.Text);
                    sw.Close();
                    MessageBox.Show("儲存成功!");
                    Reload(); //Reload
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存失敗!\n錯誤訊息：" + ex.Message, "錯誤訊息");
                }
            }
            else
            {
                MessageBox.Show("無法儲存! table_schema.ini不存在。","錯誤");
            }
        }
        //----------------------------------------------------------
        //函式名稱: Reload
        //說明: 當作完新增或刪除後，重新將table_schema.ini放到記憶體，並引發cb_TableName的SelectedIndexChange事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Reload()
        {
            GetPathLog();
            Int32 SelInx = cb_TableName.SelectedIndex;
            cb_TableName.SelectedIndex = 0;
            cb_TableName.SelectedIndex = SelInx;
        }
        //----------------------------------------------------------
        //函式名稱: bt_del_Click
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_del_Click(object sender, EventArgs e)
        {
            if (lb_pathlist.SelectedIndex >= 0) 
            { 
                try
                {
                    //要刪除的key值
                    Int32 del_index = Convert.ToInt32(lb_pathlist_sn.Items[lb_pathlist.SelectedIndex]);  //行號
                    string del_str = tb_owner.Text + "." + cb_TableName.SelectedItem.ToString() + "," + lb_pathlist.SelectedItem.ToString();  //內容

                    string file_new_content = ""; //新的檔案內容
                    //讀出檔案內容(不包含要刪除的資料)
                    Int32 file_index = 0;
                    StreamReader sr = new StreamReader("table_schema.ini", Encoding.Default);
                    while (!sr.EndOfStream)
                    {
                        string str_line = sr.ReadLine();
                        if (file_index != del_index || str_line != del_str) //任一KEY值不符合，則保留
                        {
                            file_new_content += str_line + "\n";
                        }
                        file_index++;
                    }
                    sr.Dispose();

                    //寫入到檔案(取代)
                    StreamWriter sw = new StreamWriter("table_schema.ini", false, System.Text.Encoding.Default);
                    sw.Write(file_new_content.Replace("\n", Environment.NewLine)); //取代\n成一般檔案中的換行
                    sw.Close();

                    //MessageBox.Show("刪除成功!");
                    Reload(); //Reload
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除失敗! \n錯誤訊息："+ex.Message);
                }
            }
        }
    }
}