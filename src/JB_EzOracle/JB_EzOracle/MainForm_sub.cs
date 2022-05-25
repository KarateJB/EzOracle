using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Data.OracleClient;

namespace JB_EzOracleSQL
{
    public partial class MainForm
    {
        //----------------------------------------------------------
        //函式名稱: mciMusic
        //說明:音樂播放器
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string m_strCmd, string m_strReceive, int m_v1, int m_v2);
        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);
        private static void mciMusic(string name, string command)
        {
            StringBuilder shortpath = new StringBuilder();
            int result = GetShortPathName(name, shortpath, shortpath.Capacity);
            name = shortpath.ToString();
            string buf = string.Empty;
            mciSendString(command + " " + name, buf, buf.Length, 0); //播放
        }

        //----------------------------------------------------------
        //函式名稱: ShowAlertBox
        //說明: 顯示訊息視窗
        //參數: string 訊息
        //回傳值: 無
        //----------------------------------------------------------
        public void ShowAlertBox(string msg, string title)
        {
            alertbox.Text = title;
            alertbox.lb_alert.Text = msg;
            alertbox.ShowDialog(this);
        }

        //----------------------------------------------------------
        //函式名稱: Chk_Transaction
        //說明: 顯示訊息視窗
        //參數: string 訊息
        //回傳值: 0(關閉視窗: 已作或不需要 commit或rollback), 1(取消關閉視窗) , -1(例外錯誤)
        //----------------------------------------------------------
        public int Chk_Transaction( ref OracleTransaction transaction )
        {
            if (transaction != null)
            {
                DialogResult dRslt =
                    MessageBox.Show("有未Commit的Transaction，\n是否Commit ? \n按下[是] Commit，[否] Rollback，或[取消]。", "警告",
                                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                try
                {
                    switch (dRslt)
                    {
                        case DialogResult.Yes:
                            transaction.Commit();
                            transaction = null;
                            transaction_Sql = "";
                            LLB_viewSql.Enabled = false;

                            return 0;

                        case DialogResult.No:
                            transaction.Rollback();
                            transaction = null;
                            transaction_Sql = "";
                            LLB_viewSql.Enabled = false;

                            return 0;

                        case DialogResult.Cancel:
                            return 1;

                        default:
                            return 0;
                    }
                }
                catch (Exception ex)
                {
                    ShowAlertBox("錯誤，原因：" + ex.Message, "錯誤");
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
        //----------------------------------------------------------
        //函式名稱: menustrip_ItemClicked
        //說明: 選取上層選單時所觸發事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void menustrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //選取上層選單時所觸發事件。 ex. [檔案]
            //.....
        }

        //----------------------------------------------------------
        //函式名稱: Reset_Rollback_Buttons
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Reset_Rollback_Buttons(int iCase)
        {
            //Menustrip無法直接選下下層物件，所以必須用一個ToolstripMenuItem指到下層。然後再用DropDownItems去選下下層物件。
            var items = from x in MenuItemNameSet
                                    where x.ItemName == "Commit" || x.ItemName=="Rollback"
                                    select x;
            foreach (MyClass.cMenuItem item in items)
            {
                String[] sSplitID = item.ItemID.Split('_');
                //Parent Index
                int _posParent = Convert.ToInt16(sSplitID[2]) - 1;
                //Parent2 Index
                int _posParent2= Convert.ToInt16(sSplitID[3]) - 1;
                //Item Index
                int _posItem = Convert.ToInt16(sSplitID[4]) - 1;

                ToolStripMenuItem tsmi = (ToolStripMenuItem)menustrip.Items[_posParent];
                ToolStripMenuItem tsmi2 = (ToolStripMenuItem)tsmi.DropDownItems[_posParent2];

                switch (iCase)
                {
                    case 0:
                        if (item.ItemName == "Commit")
                            tsmi2.DropDownItems[_posItem].Enabled = true;
                        else if (item.ItemName == "Rollback")
                            tsmi2.DropDownItems[_posItem].Enabled = false;
                        break;
                    case 1:
                        if (item.ItemName == "Commit")
                            tsmi2.DropDownItems[_posItem].Enabled = false;
                        else if (item.ItemName == "Rollback")
                            tsmi2.DropDownItems[_posItem].Enabled = true;
                        break;
                    case 2:
                        if (item.ItemName == "Commit")
                            tsmi2.DropDownItems[_posItem].Enabled = true;
                        else if (item.ItemName == "Rollback")
                            tsmi2.DropDownItems[_posItem].Enabled = true;
                        break;
                    case 3:
                        if (item.ItemName == "Commit")
                            tsmi2.DropDownItems[_posItem].Enabled = false;
                        else if (item.ItemName == "Rollback")
                            tsmi2.DropDownItems[_posItem].Enabled = false;
                        break;
                    default:
                        break;
                }
                tsmi = null;
                tsmi2 = null;
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_1_Click
        //說明: 功能列 [連線] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_1_Click(object sender, EventArgs e)
        {
            timer_Run();
            try
            {
                if (Common.DBModule.DB_Connect(TB_host.Text, TB_owner.Text, TB_pwd.Text) != null)
                {
                    //設定MainForm顯示連線DB資訊
                    this.Text = MainFormTitle + String.Format(" (目前連線到：{0} )", TB_host.Text);

                    //取得Table names
                    GetUserTables();

                    //Menustrip無法直接選下下層物件，所以必須用一個ToolstripMenuItem指到下層。然後再用DropDownItems去選下下層物件。
                    var items = from x in MenuItemNameSet
                                           where x.ItemName == "連線" || x.ItemName=="斷線"
                                           select x;
                    foreach (MyClass.cMenuItem item in items)
                    {
                        String[] sSplitID = item.ItemID.Split('_');
                        //Parent Index
                        int _posParent = Convert.ToInt16(sSplitID[2]) - 1; 
                        //Item Index
                        int _posItem = Convert.ToInt16(sSplitID[3]) - 1;

                        ToolStripMenuItem tsmi2 = (ToolStripMenuItem)menustrip.Items[_posParent];
                        switch (item.ItemName)
                        {
                            case "連線":
                                tsmi2.DropDownItems[_posItem].Enabled = false;
                                break;
                            case "斷線":
                                tsmi2.DropDownItems[_posItem].Enabled = true;
                                break;
                            default:
                                break;
                        }
                        tsmi2 = null;
                    }

                    BT_conn.Enabled = false;

                    //播放音效
                    bool bPlayBGM = Common.Setup.Get_Setup_Value(ref userSetupList, "開啟音效").ToLower() == "true" ? true : false;
                    if (bPlayBGM == true) mciMusic(@"BGM\Login.wav", "play");

                    timer_Stop();
                    TSSL.Text = "已成功連線至Oracle DB Server! 共花費: " + timer_cnt.ToString() + " 秒";
                }
                else
                {
                    //播放音效
                    bool bPlayBGM = Common.Setup.Get_Setup_Value(ref userSetupList, "開啟音效").ToLower() == "true" ? true : false;
                    if (bPlayBGM == true) mciMusic(@"BGM\Error.wav", "play");

                    ShowAlertBox("無法連結資料庫! \n請檢查Server name,帳號和密碼。", "錯誤");
                }
            }
            catch (Exception ex)
            {
                //播放音效
                bool bPlayBGM = Common.Setup.Get_Setup_Value(ref userSetupList, "開啟音效").ToLower() == "true" ? true : false;
                if (bPlayBGM == true) mciMusic(@"BGM\Error.wav", "play");

                ShowAlertBox("無法連結資料庫! \n請檢查Server name,帳號和密碼。\n內部錯誤訊息： " + ex.Message, "錯誤");
            }
            finally
            {
                timer_Stop();
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_2_Click
        //說明: 功能列 [斷線] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_2_Click(object sender, EventArgs e)
        {
            Common.DBModule.DB_Disconnect();
            CLB_column.Items.Clear();
            CB_tablename.Items.Clear();
            LB_tablename.Items.Clear();

            //設定MainForm顯示連線DB資訊
            this.Text = MainFormTitle + " (離線)";


            /* 
             Menustrip無法直接選下下層物件，所以必須用一個ToolstripMenuItem指到下層。
             然後再用DropDownItems去選下下層物件。
             */
            var items = from x in MenuItemNameSet
                        where x.ItemName == "連線" || x.ItemName == "斷線"
                        select x;
            foreach (MyClass.cMenuItem item in items)
            {
                String[] sSplitID = item.ItemID.Split('_');
                //Parent Index
                int _posParent = Convert.ToInt16(sSplitID[2]) - 1;
                //Item Index
                int _posItem = Convert.ToInt16(sSplitID[3]) - 1;

                ToolStripMenuItem tsmi = (ToolStripMenuItem)menustrip.Items[_posParent];
                switch (item.ItemName)
                {
                    case "連線":
                        tsmi.DropDownItems[_posItem].Enabled = true;
                        break;
                    case "斷線":
                        tsmi.DropDownItems[_posItem].Enabled = false;
                        break;
                    default:
                        break;
                }
                tsmi = null;
            }

            BT_conn.Enabled = true;
            TSSL.Text = "與Oracle DB Server斷線";
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_3_Click
        //說明: 功能列 [結束] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_3_Click(object sender, EventArgs e)
        {
            //查看是否有未完成的transaction (0:關閉 , 1:取消關閉 , -1: 有error)
            int iCloseWindow = Chk_Transaction(ref transaction);

            switch (iCloseWindow)
            {
                case 0:
                    //Free Array
                    Array.Clear(QuickLoad, 0, QuickLoad.Length);
                    Array.Clear(RsltFormSet, 0, RsltFormSet.Length);

                    //Close DB
                    Common.DBModule.DB_Disconnect();
                    this.Dispose();
                    break;

                case 1:
                    break;
                case -1:
                    DialogResult dForceClose = MessageBox.Show("資料無法Commit或Rollback，\n是否直接關閉程式 ?", "錯誤",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dForceClose == DialogResult.Yes)
                    {
                        //Free Array
                        Array.Clear(QuickLoad, 0, QuickLoad.Length);
                        Array.Clear(RsltFormSet, 0, RsltFormSet.Length);

                        //Close DB
                        Common.DBModule.DB_Disconnect();
                        this.Dispose();
                    }
                    break;
                default:
                    break;
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_4_Click
        //說明: 功能列 [詳細設定] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        /*******功能列 [詳細設定] CLICK事件********/
        private void tsmi_1_4_Click(object sender, EventArgs e)
        {
            GB_db.BackgroundImage.Dispose();
            GB_db.BackgroundImage = new Bitmap(@"Theme\\error.jpg");
            setupForm.ShowDialog(this);
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_5_Click
        //說明: 功能列 [儲存SQL] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_5_Click(object sender, EventArgs e)
        {
            saveFileDialog.CheckFileExists = false; //若為true，則檔案必先存在
            saveFileDialog.Filter = "SQL檔案|*.sql";  //儲存檔案篩選條件
            saveFileDialog.FileName = "NEW.sql"; //預設檔名
            saveFileDialog.OverwritePrompt = true; //若檔名已存在，事先警告
            saveFileDialog.Title = "請選擇儲存的地方"; //對話框抬頭

            DialogResult dr = saveFileDialog.ShowDialog();

            if (dr == DialogResult.OK) //使用者在對話框確定儲存
            {
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.Default);
                try
                {
                    TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
                    foreach (RichTextBox rtb in tp.Controls)
                    {
                        sw.WriteLine(rtb.Text.Replace("\n", Environment.NewLine));
                    }
                    TSSL.Text = "儲存成功!";
                }
                catch (Exception ex)
                {
                    ShowAlertBox("無法儲存~請檢查檔案是否開啟？\n內部錯誤訊息：" + ex.Message, "錯誤");
                    TSSL.Text = "儲存失敗!";
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_1_6_Click
        //說明: 功能列 [匯入SQL] CLICK事件
        //參數:  無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDg = new OpenFileDialog();

            if (openFileDg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDg.OpenFile());
                try
                {
                    TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
                    foreach (RichTextBox rtb in tp.Controls)
                    {
                        rtb.Text = sr.ReadToEnd();
                    }
                    tp = null;
                    TSSL.Text = "匯入成功!";
                }
                catch (Exception ex)
                {
                    ShowAlertBox("無法開啟檔案!\n內部錯誤訊息：" + ex.Message, "錯誤");
                    TSSL.Text = "匯入失敗!";
                }
                finally
                {
                    openFileDg.Dispose();
                    sr.Close();
                    sr.Dispose();
                }
            }

        }
        //----------------------------------------------------------
        //函式名稱: tsmi_1_7_Click
        //說明: 功能列 [關閉子視窗] CLICK事件
        //參數:  無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_1_7_Click(object sender, EventArgs e)
        {
            try
            {
                //關閉所有子視窗,若某個子視窗已關閉,再執行Close不影響!
                for (int i = 0; i < RsltFormSet_inx; i++)
                {
                    RsltFormSet[i].Close();
                }
            }
            catch (Exception ex)
            {
                ShowAlertBox("無法關閉所有查詢結果子視窗！\n原因：" + ex.Message, "錯誤");
            }
            finally
            {
                Array.Clear(RsltFormSet, 0, RsltFormSet.Length); //釋放記憶體
                RsltFormSet_inx = 0;
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_lv2_002_1_01_Click
        //說明: Commit
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_lv2_002_1_01_Click(object sender, EventArgs e)
        {
            if (transaction == null)
            {
                ShowAlertBox("目前沒有需要Commit的Transaction!", "Commit");
            }
            else
            {
                try
                {
                    transaction.Commit();
                    transaction = null;
                    transaction_Sql = "";
                    LLB_viewSql.Enabled = false;

                    Reset_Rollback_Buttons(3);
                    ShowAlertBox("Commit成功! ", "Commit");
                }
                catch (Exception ex)
                {
                    Reset_Rollback_Buttons(2);
                    ShowAlertBox("Commit失敗! 原因："+ex.Message, "錯誤");
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_lv2_002_1_02_Click
        //說明: Commit
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_lv2_002_1_02_Click(object sender, EventArgs e)
        {
            if (transaction == null)
            {
                ShowAlertBox("目前沒有可以Rollback的Transaction!", "Rollback");
            }
            else
            {
                try
                {
                    transaction.Rollback();
                    transaction = null;
                    transaction_Sql = "";
                    LLB_viewSql.Enabled = false;

                    Reset_Rollback_Buttons(3);
                    ShowAlertBox("Rollback成功! ", "Rollback");
                }
                catch (Exception ex)
                {
                    Reset_Rollback_Buttons(2);
                    ShowAlertBox("Rollback失敗! 原因：" + ex.Message, "錯誤");
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_3_1_Click
        //說明: 開啟[Table Schema]視窗
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_3_1_Click(object sender, EventArgs e)
        {
            if (Common.DBModule.Conn.State == ConnectionState.Closed) //檢查Conn是否初始化了
            {
                ShowAlertBox("請先連線到資料庫，才能使用此功能! ", "錯誤訊息");
            }
            else
            {
                schemaForm.tb_owner.Text = this.TB_owner.Text.ToUpper();
                schemaForm.ShowDialog(this);
            }
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_4_1_Click
        //說明: 設定編輯SQL區的字體大小為[大]
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_4_1_Click(object sender, EventArgs e)
        {
            MyClass.cMenuItem item = null;
            item =
                (
                from x in MenuItemNameSet
                where x.ItemName=="SQL字體"
                select x
            ).SingleOrDefault();

            try
            {
                String[] sSplitID = item.ItemID.Split('_');
                int _pos = Convert.ToInt16(sSplitID[2])-1;

                ToolStripMenuItem ts = (ToolStripMenuItem)menustrip.Items[_pos];
                ts.DropDownItems[0].ForeColor = Color.Red;
                ts.DropDownItems[1].ForeColor = Color.Black;
                ts.DropDownItems[2].ForeColor = Color.Black;
                ToolStripMenuItem ts00 = (ToolStripMenuItem)ts.DropDownItems[0];
                ToolStripMenuItem ts01 = (ToolStripMenuItem)ts.DropDownItems[1];
                ToolStripMenuItem ts02 = (ToolStripMenuItem)ts.DropDownItems[2];
                ts00.Checked = true; ts01.Checked = false; ts02.Checked = false;
                ts = null; ts00 = null; ts01 = null; ts02 = null;


                foreach (TabPage tp in tabControl.Controls)
                {
                    RichTextBox rtb = (RichTextBox)tp.Controls[0];
                    rtb.Font = new Font("微軟正黑體", 12);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! " + ex.Message);
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_4_2_Click
        //說明: 設定編輯SQL區的字體大小為[中]
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_4_2_Click(object sender, EventArgs e)
        {
            MyClass.cMenuItem item = null;
            item =
                (
                from x in MenuItemNameSet
                where x.ItemName=="SQL字體"
                select x
            ).SingleOrDefault();

            try
            {
                String[] sSplitID = item.ItemID.Split('_');
                int _pos = Convert.ToInt16(sSplitID[2])-1;

                ToolStripMenuItem ts = (ToolStripMenuItem)menustrip.Items[ _pos ];
                ts.DropDownItems[0].ForeColor = Color.Black;
                ts.DropDownItems[1].ForeColor = Color.Red;
                ts.DropDownItems[2].ForeColor = Color.Black;
                ToolStripMenuItem ts00 = (ToolStripMenuItem)ts.DropDownItems[0];
                ToolStripMenuItem ts01 = (ToolStripMenuItem)ts.DropDownItems[1];
                ToolStripMenuItem ts02 = (ToolStripMenuItem)ts.DropDownItems[2];
                ts00.Checked = false; ts01.Checked = true; ts02.Checked = false;
                ts = null; ts00 = null; ts01 = null; ts02 = null;
                foreach (TabPage tp in tabControl.Controls)
                {
                    RichTextBox rtb = (RichTextBox)tp.Controls[0];
                    rtb.Font = new Font("微軟正黑體", 10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! "+ex.Message);
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_4_3_Click
        //說明: 設定編輯SQL區的字體大小為[小]
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_4_3_Click(object sender, EventArgs e)
        {
            MyClass.cMenuItem item = null;
            item =
                (
                from x in MenuItemNameSet
                where x.ItemName=="SQL字體"
                select x
            ).SingleOrDefault();

            try
            {
                String[] sSplitID = item.ItemID.Split('_');
                int _pos = Convert.ToInt16(sSplitID[2])-1;

                ToolStripMenuItem ts = (ToolStripMenuItem)menustrip.Items[_pos];
                ts.DropDownItems[0].ForeColor = Color.Black;
                ts.DropDownItems[1].ForeColor = Color.Black;
                ts.DropDownItems[2].ForeColor = Color.Red;
                ToolStripMenuItem ts00 = (ToolStripMenuItem)ts.DropDownItems[0];
                ToolStripMenuItem ts01 = (ToolStripMenuItem)ts.DropDownItems[1];
                ToolStripMenuItem ts02 = (ToolStripMenuItem)ts.DropDownItems[2];
                ts00.Checked = false; ts01.Checked = false; ts02.Checked = true;
                ts = null; ts00 = null; ts01 = null; ts02 = null;
                foreach (TabPage tp in tabControl.Controls)
                {
                    RichTextBox rtb = (RichTextBox)tp.Controls[0];
                    rtb.Font = new Font("微軟正黑體", 9);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! " + ex.Message);
            }
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_5_1_Click
        //說明: 視窗大小-一般
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_5_1_Click(object sender, EventArgs e)
        {
            MyClass.cMenuItem item = null;
            item =
                (
                from x in MenuItemNameSet
                where x.ItemName == "視窗大小"
                select x
            ).SingleOrDefault();

            try
            {
                String[] sSplitID = item.ItemID.Split('_');
                int _pos = Convert.ToInt16(sSplitID[2])-1;
                ToolStripMenuItem ts = (ToolStripMenuItem)menustrip.Items[_pos]; //指到[視窗大小]
                ToolStripMenuItem ts00 = (ToolStripMenuItem)ts.DropDownItems[0]; //指到[一般]
                ToolStripMenuItem ts01 = (ToolStripMenuItem)ts.DropDownItems[1]; //指到[放大]
                ts00.Checked = true; ts01.Checked = false;
                ts = null; ts00 = null; ts01 = null;

                BT_down_Click(sender, null);
                BT_left_Click(sender, null);
                BT_top2_Click(sender, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! " + ex.Message);
            }
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_5_2_Click
        //說明: 視窗大小-放大
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_5_2_Click(object sender, EventArgs e)
        {
            MyClass.cMenuItem item = null;
            item =
                (
                from x in MenuItemNameSet
                where x.ItemName == "視窗大小"
                select x
            ).SingleOrDefault();

            try
            {
                String[] sSplitID = item.ItemID.Split('_');
                int _pos = Convert.ToInt16(sSplitID[2])-1;
                ToolStripMenuItem ts = (ToolStripMenuItem)menustrip.Items[_pos]; //指到[視窗大小]
                ToolStripMenuItem ts00 = (ToolStripMenuItem)ts.DropDownItems[0]; //指到[一般]
                ToolStripMenuItem ts01 = (ToolStripMenuItem)ts.DropDownItems[1]; //指到[放大]
                ts00.Checked = false; ts01.Checked = true;
                ts = null; ts00 = null; ts01 = null;

                BT_top_Click(sender, null);
                BT_right_Click(sender, null);
                BT_down2_Click(sender, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! " + ex.Message);
            }
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_6_1_Click
        //說明: 打開說明檔
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_6_1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此動作將開啟Readme.doc。\n請確定您有安裝Microsoft Office Word 2003以上版本!", "訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process.Start("Readme.doc");
                }
                catch (Exception ex)
                {
                    ShowAlertBox("開啟失敗!\n請檢查Readme.doc檔案是否被移除! \n或其他程式正使用中!\n內部錯誤訊息：" + ex.Message, "錯誤");
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_6_2_Click
        //說明: 顯示版本資訊
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_6_2_Click(object sender, EventArgs e)
        {
            try
            {
                string sApName = ConfigurationManager.AppSettings["ApName"];
                string sApMaker = ConfigurationManager.AppSettings["ApMaker"];
                string sApVersion = ConfigurationManager.AppSettings["ApVersion"];
                string sApModDate = ConfigurationManager.AppSettings["ApModDate"];

                string sStr = String.Format("{0} \n\n作者: {1} \n\n版本: {2} \n\n更新日期: {3}\n ",
                                                                       sApName, sApMaker, sApVersion, sApModDate);
                MessageBox.Show(sStr, "版本");
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤! 無法顯示版本資訊。 原因：" + ex.Message.ToString());
            }
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_6_3_Click
        //說明: 查詢熱鍵對應
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_6_3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ctrl+數字鍵 : 翻頁到指令框1~6\nF5 : 查詢\nF6 : 直接查詢\nCtrl+E:設定\nCtrl+S:儲存SQL\nCtrl+L:匯入SQL\nCtrl+W:開啟sql編輯視窗\nCtrl+N:新分頁", "熱鍵對應");
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_6_4_Click
        //說明: 查詢Oracle內建語法
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_6_4_Click(object sender, EventArgs e)
        {
            SearchForm sForm = new SearchForm();
            sForm.Show();
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_50_Click
        //說明: CLB_column右鍵功能表 [複製] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_50_Click(object sender, EventArgs e)
        {
            if (CLB_column.SelectedIndex >= 0)
            {
                Clipboard.SetData(DataFormats.Text, CLB_column.SelectedItem.ToString());
                //或 Clipboard.SetText (String, TextDataFormat) 
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_100_Click
        //說明: RichTextBox系列右鍵功能表 [執行選取SQL] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_100_Click(object sender, EventArgs e)
        {
            BT_query_Click(sender, null);
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_101_Click
        //說明: RichTextBox系列右鍵功能表 [直接匯出 ...] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_101_Click(object sender, EventArgs e)
        {
            string UserSql = Get_User_Sel_Sql_ForSelect();
            if (UserSql.Substring(0, 5) == "Error")
            {
                switch (UserSql)
                {
                    case "Error01":
                        ShowAlertBox("請從SQL指令區先選擇SQL!", "錯誤");
                        break;
                    case "Error02":
                        ShowAlertBox("非SELECT指令，無法執行匯出!", "錯誤");
                        break;
                    case "Error03":
                        ShowAlertBox("發生例外情況，無法取得使用者選擇指令!", "錯誤");
                        break;
                    default:
                        ShowAlertBox("未知的錯誤!", "錯誤");
                        break;
                }
            }
            else
            {
                //限制筆數
                if (CB_restrict.Checked)
                {
                    if (MessageBox.Show("查詢時有限制筆數!! 系統只會匯出限制筆數下的資料，是否繼續？", "筆數限制警告!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                ExportForm export_form = new ExportForm();
                export_form.export_SQL = UserSql;
                export_form.Show(this);
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_102_Click
        //說明: RichTextBox系列右鍵功能表 [複製] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_102_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                if (rtb.SelectedText.Length > 0) rtb.Copy();
            }
            tp = null;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_103_Click
        //說明: RichTextBox右鍵功能表 [剪下] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_103_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                if (rtb.SelectedText.Length > 0)
                {
                    rtb.Copy();
                    rtb.SelectedText = "";
                }
            }
            tp = null;
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_104_Click
        //說明: RichTextBox右鍵功能表 [貼上] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_104_Click(object sender, EventArgs e)
        {
            InsertIntoRTB(Clipboard.GetText());
        }
        //----------------------------------------------------------
        //函式名稱:tsmi_105_Click
        //說明: RichTextBox系列右鍵功能表 [全部選取] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_105_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                rtb.SelectAll();
            }
            tp = null;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_106_Click
        //說明: RichTextBox右鍵功能表 [清除全部] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_106_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                rtb.Clear();
            }
            tp = null;
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_Get_Sql_BySelRow_Click
        //回傳值: dG_table右鍵功能表 [新增][刪除][更新]  CLICK事件
        //說明: 無
        //參數: 無
        //----------------------------------------------------------
        private void tsmi_Get_Sql_BySelRow_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            TabPage tp2 = tabControl2.TabPages[tabControl2.SelectedIndex];
            RichTextBox rtb = (RichTextBox)tp.Controls[0];
            DataGridView dg = (DataGridView)tp2.Controls[0];

            if (dg.SelectedRows.Count == 1)
            {
                ToolStripMenuItem myButton = (ToolStripMenuItem)sender;

                switch (myButton.Text)
                {
                    case "新增":
                        rtb.Text = Common.RegularFuc.Get_Sql_BySelRow(1, CB_tablename.Text, ref dg);
                        TSSL.Text = "已加入[新增] Sql ";
                        break;
                    case "刪除":
                        rtb.Text = Common.RegularFuc.Get_Sql_BySelRow(2, CB_tablename.Text, ref dg);
                        TSSL.Text = "已加入[刪除] Sql ";
                        break;
                    case "更新":
                        rtb.Text = Common.RegularFuc.Get_Sql_BySelRow(3, CB_tablename.Text, ref dg);
                        TSSL.Text = "已加入[更新] Sql ";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                TSSL.Text = "請先選擇一列資料 !!";
            }

            tp = null;
            tp2 = null;
        }


        //----------------------------------------------------------
        //函式名稱: tsmi_200_Click
        //說明: LB_tablename右鍵功能表 [複製] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_200_Click(object sender, EventArgs e)
        {
            if (LB_tablename.SelectedIndex >= 0)
            {
                //複製到剪貼簿
                Clipboard.SetText(LB_tablename.SelectedItem.ToString(), TextDataFormat.Text);
            }
        }

        //----------------------------------------------------------
        //函式名稱: tsmi_closepage_Click
        //說明: tabControl [關閉] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_closepage_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            TabPage tp2 = tabControl2.TabPages[tabControl2.SelectedIndex];
            if (tp.Text.Substring(0, 2) != "新增")
            {
                ShowAlertBox("您不能關閉此系統預設分頁!", "系統警告");
            }
            else
            {
                foreach (RichTextBox rtb in tp.Controls)
                {
                    rtb.Dispose(); //Dispose RichTextBox
                }
                foreach (DataGridView dg in tp2.Controls)
                {
                    dg.Dispose(); //Dispose DataGridView
                }
                //Dispose 分頁
                tp.Dispose();
                tp2.Dispose();
            }
            tp = null;
            tp2 = null;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_201_Click
        //說明: LB_tablename右鍵功能表 [查詢] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_201_Click(object sender, EventArgs e)
        {
            if (LB_tablename.SelectedIndex >= 0)
            {
                string user_sql_tmp;

                TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
                foreach (RichTextBox rtb in tp.Controls)
                {
                    user_sql_tmp = rtb.Text;
                    rtb.Text = "SELECT * FROM " + LB_tablename.SelectedItem.ToString();
                    rtb.SelectAll(); //預防使用者開啟了"只執行選取的SQL"，故自動選取所有文字。
                    BT_query_Click(sender, e);
                    rtb.Text = user_sql_tmp;
                }
                tp = null;
            }
        }

    }
}
