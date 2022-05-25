using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JB_EzOracleSQL
{
    public partial class ReplaceForm : Form
    {
        public ReplaceForm()
        {
            InitializeComponent();
            lb_Alert.Text = "";
            tb_NewText.Focus();
            tb_ReplaceText.Text = Clipboard.GetText(); //將剪貼簿的文字放到搜尋的文字方塊
        }
        //----------------------------------------------------------
        //函式名稱: ReplaceForm_FormClosed
        //說明: Dispose the form
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void ReplaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        //----------------------------------------------------------
        //函式名稱: bt_Next_Click
        //說明: 搜尋下一個
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_Next_Click(object sender, EventArgs e)
        {
            SearchKeyText(tb_ReplaceText.Text, 1);
        }
        //----------------------------------------------------------
        //函式名稱: bt_Replace_Click
        //說明: 單一取代
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_Replace_Click(object sender, EventArgs e)
        {
            if (SearchKeyText(tb_ReplaceText.Text, 0) == true) //如果有找到文字，才作取代的動作
            {
                ReplaceSelText();
                lb_Alert.Text = "已取代1個文字!";
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_ReplaceAll_Click
        //說明: 全部取代
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_ReplaceAll_Click(object sender, EventArgs e)
        {
            Int16 KeyText_Cnt=0; //計錄共有幾個文字要被取代
            EditSqlForm esform = (EditSqlForm)this.Owner;
            esform.RTB_SQL.SelectionStart = 0;

            //計算要取代的文字數目--------------------------------------
            while (SearchKeyText(tb_ReplaceText.Text, 1) == true) 
            {
                KeyText_Cnt++;
            }
            if (KeyText_Cnt > 0)
            {
                lb_Alert.Text = "共有 " + KeyText_Cnt.ToString() + " 個要取代的文字。";
            }
            else
            {
                lb_Alert.Text = "沒有任何要取代的文字!";
                esform = null;
                return;
            }

            //POPUP再次確認是否全部取代--------------------------------------
            if (MessageBox.Show("即將取代 " + KeyText_Cnt.ToString() + " 個文字，請確定？", "全部取代訊息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                esform.RTB_SQL.SelectionStart = 0;
                while (SearchKeyText(tb_ReplaceText.Text, 1) == true)
                {
                    ReplaceSelText();
                }
                lb_Alert.Text = "已取代 " + KeyText_Cnt.ToString() + " 個文字!";
            }
            esform = null;
        }
        //----------------------------------------------------------
        //函式名稱: SearchKeyText
        //說明: 尋找文字
        //參數: KeyText(搜尋的字串), StartPosFlg(0:選取文字的起頭開始搜尋)(1:選取文字的結尾開始搜尋)...若無選取任何文字則無差別
        //回傳值: true(有找到),false(沒有找到)
        //----------------------------------------------------------
        private bool SearchKeyText(string KeyText, int StartPosFlg)
        {
            EditSqlForm esform = (EditSqlForm)this.Owner;

            //開始的位置(若有選取文字，則為目前選取文字的最後一個位置)
            Int32 SearchStartPos = 0;
            switch (StartPosFlg)
            {
                case 0:
                    SearchStartPos = esform.RTB_SQL.SelectionStart;
                    break;
                case 1:
                    SearchStartPos = esform.RTB_SQL.SelectionStart + esform.RTB_SQL.SelectionLength;
                    break;
                default:
                    break;
            }

            //往後找到符合文字的位置
            Int32 FoundPos = esform.RTB_SQL.Text.IndexOf(KeyText, SearchStartPos);
            if (FoundPos >= 0)
            {
                lb_Alert.Text = "";
                esform.RTB_SQL.Select(FoundPos, KeyText.Length); //選取該文字
                esform.RTB_SQL.Focus();
                esform = null;
                return true;
            }
            else
            {
                lb_Alert.Text = "往後尋找..無此文字!";
                esform = null;
                return false;
            }       
        }
         //----------------------------------------------------------
        //函式名稱: ReplaceSelText
        //說明: 取代"目前選擇的文字"
        //參數: 
        //回傳值: 
        //----------------------------------------------------------
        private void ReplaceSelText()
        {
            EditSqlForm esform = (EditSqlForm)this.Owner;
            Int32 start_pos = esform.RTB_SQL.SelectionStart;
            string part01 = esform.RTB_SQL.Text.Substring(0, start_pos);
            string part02 = esform.RTB_SQL.Text.Substring(start_pos + esform.RTB_SQL.SelectionLength);
            esform.RTB_SQL.Text = part01 + tb_NewText.Text + part02;
            esform.RTB_SQL.SelectionStart = start_pos + tb_NewText.Text.Length;
            esform.RTB_SQL.Focus(); //回到焦點
            esform = null;
        }
        
    }
}