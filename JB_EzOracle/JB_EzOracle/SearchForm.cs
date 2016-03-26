using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.UI;

namespace JB_EzOracleSQL
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            SetContextMenuStrip(); //設定RTB_des右鍵選單
        }
        //----------------------------------------------------------
        //函式名稱: BT_close_Click
        //說明: 關閉
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_02
        //說明: RichTextBox右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void CB_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = CB_search.SelectedItem.ToString();
            if (File.Exists("SQL說明\\" + keywords + ".ini"))
            {
                StreamReader sr = new StreamReader("SQL說明\\" + keywords + ".txt");
                RTB_des.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            else
            {
                MessageBox.Show("無法提供說明!", "檔案不存在..");
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip
        //說明: RichTextBox右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip()
        {
            ToolStripMenuItem tsmi_01 = new ToolStripMenuItem("複製", null, new EventHandler(tsmi_01_Click));
            ToolStripMenuItem tsmi_02 = new ToolStripMenuItem("全部選取", null, new EventHandler(tsmi_02_Click));
            cMenuStrip.Items.Add(tsmi_01);
            cMenuStrip.Items.Add(tsmi_02);
            RTB_des.ContextMenuStrip = cMenuStrip; //指定RTB_des(RichTextBox)的右鍵選單
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_01_Click
        //說明: 右鍵功能表 [複製] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_01_Click(object sender, EventArgs e)
        {
            if (RTB_des.SelectedText.Length > 0) RTB_des.Copy();
        }
        //----------------------------------------------------------
        //函式名稱:
        //說明: RichTextBox系列右鍵功能表 [全部選取] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_02_Click(object sender, EventArgs e)
        {
            RTB_des.SelectAll();
        }
    }
}