using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JB_EzOracleSQL
{
    public partial class EditSqlForm : Form
    {
        public int MainForm_tabControl_SelIndex; //記錄是從MainForm哪一個編輯區傳過來的SQL

        public EditSqlForm()
        {
            InitializeComponent();

            //設定預設字體大小
            RTB_SQL.Font = new Font("Comic Sans MS", 10);
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
        //函式名稱: BT_save_Click
        //說明: 回存
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_save_Click(object sender, EventArgs e)
        {
            MainForm daForm = (MainForm)this.Owner; //daForm指向MainForm

            //將目前SQL回存回MainForm
            TabPage tp = daForm.tabControl.TabPages[daForm.tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                rtb.Text = RTB_SQL.Text;
            }
            tp = null;

            this.Close();
        }
        //----------------------------------------------------------
        //函式名稱: EditSqlForm_Resize
        //說明: Resize Form
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void EditSqlForm_Resize(object sender, EventArgs e)
        {
            RTB_SQL.Width = this.Width - 50;
            RTB_SQL.Height = this.Height - 100;
        }
        //----------------------------------------------------------
        //函式名稱: LLB_ColInfo_LinkClicked
        //說明: 顯示欄位資訊
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_ColInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm daForm = (MainForm)this.Owner; //daForm指向MainForm
            daForm.LLB_col_LinkClicked(sender, null); 
        }
        //----------------------------------------------------------
        //函式名稱: RB_wordsize_CheckedChanged
        //說明: Change字體大小
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void RB_wordsize_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Name)
            {
                case "RB_big": //字體:大
                    RTB_SQL.Font = new Font("Comic Sans MS", 11);
                    break;
                case "RB_mid": //字體:中(default)
                    RTB_SQL.Font = new Font("Comic Sans MS", 10);
                    break;
                case "RB_small": //字體:小
                    RTB_SQL.Font = new Font("Comic Sans MS", 9);
                    break;
                default:
                    break;
            }
        }
        //----------------------------------------------------------
        //函式名稱: RTB_SQL_KeyDown
        //說明: 鍵盤按鍵事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void RTB_SQL_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F:  //Ctrl+F=尋找和取代
                    if (e.Control) //Control寫在這邊判斷
                    {
                        ReplaceForm rf = new ReplaceForm();
                        rf.Show(this);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}