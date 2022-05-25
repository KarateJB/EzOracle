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
    public partial class RsltForm : Form
    {
        private DataTable DaDt; //存放目前顯示的資料在記憶體
        private ContextMenuStrip cmenustrip = new ContextMenuStrip(); //for DG_rslt
        public RsltForm()
        {
            InitializeComponent();

            Form.CheckForIllegalCrossThreadCalls = false;
            SetContextMenuStrip();

            //狀態列加上時間
            ToolStripStatusLabel ts = new ToolStripStatusLabel(DateTime.Now.ToString("HH:mm:ss"));
            stsStrip.Items.Add(ts);
            ts = null;
        }
        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip()
        //說明: DG_rslt右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip()
        {
            ToolStripMenuItem tsmi_single = new ToolStripMenuItem("單筆顯示", null, new EventHandler(tsmi_single_Click));
            ToolStripMenuItem tsmi_all = new ToolStripMenuItem("全部顯示", null, new EventHandler(tsmi_all_Click));
            tsmi_all.Enabled = false;
            cmenustrip.Items.Add(tsmi_single);
            cmenustrip.Items.Add(tsmi_all);
            tsmi_single = null;
            tsmi_all = null;
            DG_rslt.ContextMenuStrip = cmenustrip;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_single_Click
        //回傳值: DG_rslt右鍵功能表 [單筆顯示] CLICK事件
        //說明: 無
        //參數: 無
        //----------------------------------------------------------
        private void tsmi_single_Click(object sender, EventArgs e)
        {
            //把目前DataGrid資料存到記憶體
            DaDt = null;
            DaDt = (DataTable)DG_rslt.DataSource;

            //取得目前USER選擇的資料列
            if (DG_rslt.SelectedRows.Count == 0) DG_rslt.Rows[0].Selected = true; //若未選擇任一列資料，則強制選第一筆
            DataGridViewRow dr = DG_rslt.SelectedRows[0]; //dr指到目前選擇的資料列

            //新的DataTable
            DataTable DT_new = new DataTable();
            DT_new.Columns.Add("欄位名稱");
            DT_new.Columns.Add("值");
            //加上資料
            for (int i = 0; i < dr.Cells.Count; i++)
            {
                DataRow dr_new = DT_new.NewRow();
                dr_new["欄位名稱"] = DG_rslt.Columns[i].HeaderText; //HeaderText:表首欄位名稱
                dr_new["值"] = dr.Cells[i].Value;
                DT_new.Rows.Add(dr_new);
                dr_new = null;
            }
            DG_rslt.DataSource = DT_new;
            DT_new = null;

            //Disable右鍵[單筆顯示]
            ToolStripItem tsmi_single = cmenustrip.Items[0];
            tsmi_single.Enabled = false;
            ToolStripItem tsmi_all = cmenustrip.Items[1];
            tsmi_all.Enabled = true;
            tsmi_single = null;
            tsmi_all = null;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_all_Click
        //回傳值: DG_rslt右鍵功能表 [全部顯示] CLICK事件
        //說明: 無
        //參數: 無
        //----------------------------------------------------------
        private void tsmi_all_Click(object sender, EventArgs e)
        {
            DG_rslt.DataSource = DaDt;

            //Enable右鍵[單筆顯示]
            ToolStripItem tsmi_single = cmenustrip.Items[0];
            tsmi_single.Enabled = true;
            ToolStripItem tsmi_all= cmenustrip.Items[1];
            tsmi_all.Enabled = false;
            tsmi_single = null;
            tsmi_all = null;
        }
        //----------------------------------------------------------
        //函式名稱: BT_close_Click
        //說明: 關閉視窗
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_close_Click(object sender, EventArgs e)
        {
            DaDt = null;
            this.Close();
        }
        //----------------------------------------------------------
        //函式名稱: BT_excel_Click
        //說明: 儲存成Excel
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_excel_Click(object sender, EventArgs e)
        {
            if (LB_cnt.Text.IndexOf("(限制查詢") > 0)
            {
                if (MessageBox.Show("查詢時有限制筆數!! 系統只會匯出目前顯示的資料，繼續？", "筆數限制警告!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            DataTable Rslt_dt = (DataTable)DG_rslt.DataSource;
            //呼叫 寫到Excel 函式
            string rslt_str = Common.RegularFuc.Paint_The_Excel(Rslt_dt);
            if (rslt_str != "")
            {
                MessageBox.Show("匯出Excel失敗! 原因:" + rslt_str);
            }
            else
            {
                //MessageBox.Show("匯出Excel成功! ","訊息");
            }
        }

        //----------------------------------------------------------
        //函式名稱: RsltForm_Resize
        //說明: 改變視窗大小時，顯示結果的DataGrid也跟著改變大小
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void RsltForm_Resize(object sender, EventArgs e)
        {
            DG_rslt.Width = this.Width - 50;
            DG_rslt.Height = this.Height - 145;
            BT_close.Left = this.Width - 100;
        }

        //----------------------------------------------------------
        //函式名稱: Bt_auto_Click
        //說明: 顯示結果的DataGrid自動調整欄寬
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Bt_auto_Click(object sender, EventArgs e)
        {
            DG_rslt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        //----------------------------------------------------------
        //函式名稱: LLB_Sql_LinkClicked
        //說明: 顯示(隱藏)SQL
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_Sql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LLB_Sql.Text == "顯示Sql")
            {
                LB_Sql.Visible = true;
                LLB_Sql.Text = "隱藏Sql";
            }
            else
            {
                LB_Sql.Visible = false;
                LLB_Sql.Text = "顯示Sql";
            }
        }

        //----------------------------------------------------------
        //函式名稱: RsltForm_Shown
        //說明: 第一次顯示Form時...
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void RsltForm_Shown(object sender, EventArgs e)
        {
            if (DG_rslt.Rows.Count == 0) //沒有資料時
            {
                //Disable右鍵[單筆顯示]&[全部顯示]
                ToolStripItem tsmi_single = cmenustrip.Items[0];
                tsmi_single.Enabled = false;
                ToolStripItem tsmi_all = cmenustrip.Items[1];
                tsmi_all.Enabled = false;
                tsmi_single = null;
                tsmi_all = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_img_Click
        //說明: 將結果儲存成圖片
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_img_Click(object sender, EventArgs e)
        {
            int form_x = this.Location.X; //RsltForm X座標
            int form_y = this.Location.Y; //RsltForm Y座標
            int form_width = this.Width; //RsltForm 寬
            int form_height = this.Height; //RsltForm 長
            Image myImage = new Bitmap(form_width, form_height); //宣告 image 類別
            Graphics g = Graphics.FromImage(myImage);
            //CopyFromScreen
            g.CopyFromScreen(new Point(form_x, form_y), new Point(0, 0), new Size(form_width, form_height));
            //Release控制權
            IntPtr dc1 = g.GetHdc();
            g.ReleaseHdc(dc1);
            g = null;

            //開始儲存
            Random rd = new Random();
            saveFileDialog.CheckFileExists = false; //若為true，則檔案必先存在
            saveFileDialog.Filter = "JPEG|*.jpg";  //儲存檔案篩選條件
            saveFileDialog.FileName = "查詢結果_"+DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "-" + rd.Next(30).ToString() + ".jpg"; //預設檔名
            saveFileDialog.OverwritePrompt = true; //若檔名已存在，事先警告
            saveFileDialog.Title = "儲存對話框"; //對話框抬頭
            rd = null;
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK) //使用者在對話框確定儲存
            {
                myImage.Save(saveFileDialog.FileName); //把圖片存起來
            }
            myImage = null;
        }
    }
}