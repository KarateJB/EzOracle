using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; //!!! Process
using System.IO;

namespace JB_EzOracleSQL
{
    public partial class ExportForm : Form
    {
        public string export_SQL;
        public ExportForm()
        {
            InitializeComponent();
            lb_alert.Visible = false;
        }
        //----------------------------------------------------------
        //函式名稱: bt_close_Click
        //說明: 關閉此視窗
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //----------------------------------------------------------
        //函式名稱: bt_ok_Click
        //說明: 開始執行匯出
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (rb_Excel.Checked)
            {
                try
                {
                    DataTable Rslt_dt = Common.DBModule.DB_ExecQuery(export_SQL);
                    //匯出Excel
                    PaintExcel(Rslt_dt);
                    Rslt_dt.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("匯出Excel 失敗!! \n原因：" + ex.Message, "錯誤");
                }
            }
            else if (rb_txt.Checked)
            {
                try
                {
                    DataTable Rslt_dt = Common.DBModule.DB_ExecQuery(export_SQL);
                    //匯出txt
                    WriteTxt(Rslt_dt);
                    Rslt_dt.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("匯出純文字檔 失敗!! \n原因：" + ex.Message, "錯誤");
                }
            }
            else
            {
                MessageBox.Show("請選擇匯出檔案的類型。","警告");
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_browse_Click
        //說明: 選擇文字檔儲存路徑&檔名
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_browse_Click(object sender, EventArgs e)
        {
            rb_txt.Checked = true;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = false; //若為true，則檔案必先存在
            saveFileDialog.Filter = "純文字檔案|*.txt";  //儲存檔案篩選條件

            Random rd = new Random();
            saveFileDialog.FileName = "查詢結果_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "-" + rd.Next(30).ToString() + ".txt"; //預設檔名a
            saveFileDialog.OverwritePrompt = true; //若檔名已存在，事先警告
            saveFileDialog.Title = "請選擇儲存的地方"; //對話框抬頭

            DialogResult dr = saveFileDialog.ShowDialog();

            if (dr == DialogResult.OK) //使用者在對話框確定儲存
            {
                tb_path.Text = saveFileDialog.FileName;
            }
        }

        //----------------------------------------------------------
        //函式名稱:PaintExcel
        //說明: 啟動背景作業
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void PaintExcel(DataTable Rslt_dt)
        {
            if (!bgWorker_excel.IsBusy) //當作業背景不忙碌時
            {
                //設定Thread可存取元件
                Form.CheckForIllegalCrossThreadCalls = false;
                lb_alert.Visible = true;
                lb_alert.Text = "匯出Excel中... 請稍候。";
                bt_ok.Enabled = false;
                bgWorker_excel.RunWorkerAsync(Rslt_dt); //執行bgWorker_export_DoWork
            }
        }
        //----------------------------------------------------------
        //函式名稱:bgWorker_excel_DoWork
        //說明: 畫Excel
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_excel_DoWork(object sender, DoWorkEventArgs e)
        {
            int [] Format_Chosen_index = new int[clb_SetCol.CheckedItems.Count];  //紀錄有選擇要列印成文字格式的欄位序號
            int idx = 0;
            foreach (int indexChecked in clb_SetCol.CheckedIndices)
            {
                Format_Chosen_index[idx] = indexChecked;
                idx++;
            }

            //呼叫 寫到Excel 函式
            string rslt_str = Common.RegularFuc.Paint_The_Excel((DataTable)e.Argument, Format_Chosen_index);
            if (rslt_str != "")
            {
                MessageBox.Show("匯出Excel失敗! 原因:" + rslt_str);
            }
            else
            {
                lb_alert.Text = "匯出Excel成功! ";
            }
        }
        //----------------------------------------------------------
        //函式名稱:bgWorker_excel_RunWorkerCompleted
        //說明: 結束bgWorker_excel
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Form.CheckForIllegalCrossThreadCalls = true;
            bt_ok.Enabled = true;
        }

        //----------------------------------------------------------
        //函式名稱:WriteTxt
        //說明: 啟動背景作業:儲存查詢結果為文字檔
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void WriteTxt(DataTable Rslt_dt)
        {
            if (!bgWorker_txt.IsBusy) //當作業背景不忙碌時
            {
                //設定Thread可存取元件
                Form.CheckForIllegalCrossThreadCalls = false;
                lb_alert.Visible = true;
                lb_alert.Text = "匯出文字檔中... 請稍候。";
                bt_ok.Enabled = false;
                bgWorker_txt.RunWorkerAsync(Rslt_dt); //執行bgWorker_export_DoWork
            }
        }
        //----------------------------------------------------------
        //函式名稱:bgWorker_txt_DoWork
        //說明: 啟動背景作業:儲存查詢結果為文字檔
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_txt_DoWork(object sender, DoWorkEventArgs e)
        {
            //呼叫 寫到文字檔 函式
            string rslt_str = Common.RegularFuc.Write_The_Text((DataTable)e.Argument, tb_path.Text);
            if (rslt_str != "")
            {
                MessageBox.Show("匯出文字檔失敗! 原因:" + rslt_str);
            }
            else
            {
                lb_alert.Text = "匯出文字檔成功! ";
            }
        }
        //----------------------------------------------------------
        //函式名稱:bgWorker_txt_RunWorkerCompleted
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_txt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Form.CheckForIllegalCrossThreadCalls = true;
            bt_ok.Enabled = true;
        }
        //----------------------------------------------------------
        //函式名稱:llb_open_LinkClicked
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void llb_open_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(tb_path.Text))
            {
                Process.Start(tb_path.Text, "quickload.ini");
            }
            else
            {
                lb_alert.Text="該檔案不存在!";
                lb_alert.Visible=true;
            }
        }

        //----------------------------------------------------------
        //函式名稱:cb_SetCol_CheckedChanged
        //說明: 開啟要選擇用文字格式的欄位
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void cb_SetCol_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_SetCol.Checked)
            {
                String pSql="SELECT * FROM (" + export_SQL + ") WHERE ROWNUM<=0";
                DataTable dt_Preview_data = Common.DBModule.DB_ExecQuery(pSql);
                if (dt_Preview_data != null)
                {
                    if (dt_Preview_data.Columns[0].Caption == "錯誤訊息")
                    {
                        string rslt_str = dt_Preview_data.Rows[0].ItemArray[0].ToString();
                        MessageBox.Show("無法顯示查詢的欄位! 原因:" + rslt_str);
                    }
                    else
                    {
                        for (int i = 0; i < dt_Preview_data.Columns.Count; i++)
                        {
                            clb_SetCol.Items.Add(dt_Preview_data.Columns[i].Caption);
                        }
                    }
                    dt_Preview_data = null;
                }
            }
            else
            {
                clb_SetCol.Items.Clear();
            }
        }
        //----------------------------------------------------------
        //函式名稱:lb_SelAll_LinkClicked
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void lb_SelAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int64 Col_cnt = clb_SetCol.Items.Count;
            if( Col_cnt>0)
            {
                for (int i = 0; i < Col_cnt; i++)
                {
                    clb_SetCol.SetItemChecked(i, true); //設定項目的選取
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱:lb_CnlAll_LinkClicked
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void lb_CnlAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int64 Col_cnt = clb_SetCol.Items.Count;
            if (Col_cnt > 0)
            {
                for (int i = 0; i < Col_cnt; i++)
                {
                    clb_SetCol.SetItemChecked(i, false); //設定項目的選取
                }
            }
        }
    }
}