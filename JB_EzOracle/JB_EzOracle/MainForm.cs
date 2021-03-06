#define DEBUG
//undef DEBUG
//#define DEMO
#undef DEMO
#define MODIFYING
//#undef MODIFYING

using System;
using System.IO;
using System.Web.UI;
using System.Threading;
using System.Web.UI.WebControls;//!!!
using System.Data.OleDb; //!!!
using System.Diagnostics; //!!! Process
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using System.Text.RegularExpressions;
using System.Media;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;

namespace JB_EzOracleSQL
{
    public partial class MainForm : Form
    {

        /*#####################  設定參數區 ##################### */
        static String MainFormTitle = "JB EzOracle SQL v2.8";
        static int RTB_min_hight = 232;
        static int RTB_max_hight = 385;
        public String Setup_File_Name = "setup.ini";
        private String QLoad_File_Name = "quickload.ini";

        private String Theme_Def_Pic_Path = @"Theme\\Theme_Spe.jpg";
        private String Theme_User_Pic_Path = @"Theme\\Theme.jpg";
        private String Theme_err_Pic_Path = @"Theme\\error.jpg";
        /*################################################### */


        public SetupForm setupForm= new SetupForm(); //設定Form
        public AlertBox alertbox = new AlertBox(); //警告訊息Form
        private EditSqlForm editsqlForm = new EditSqlForm(); //編輯SQL Form
        private SchemaForm schemaForm = new SchemaForm(); //Table Schema Form


        public MainForm()
        {
            InitializeComponent();

            //讀入參數設定-------------------------------------------------------------------------
            Common.Setup.Init_SetupList(ref userSetupList);

            //初始化所有選單(含右鍵選單)-----------------------------------------------------------
            Common.Initial.Initial_MenuItems(ref MenuItemNameSet);

            SetMenuStrip();
            SetContextMenuStrip_01(); //for CLB_column
            SetContextMenuStrip_02(); //for RTB
            SetContextMenuStrip_03(); //for dG_table
            SetContextMenuStrip_04(); //for LB_tablename
            SetContextMenuStrip_05(); //for TabControl

            SetStatusStrip();
            CB_sqlstyle.SelectedIndex = 0;
            SetKeyWords();
            SetQuickLoad();
            SetDataGridView();
            RsltFormSet_inx = 0;


#if(DEMO) //試用版限制
            //試用版限制
            CB_restrict.Enabled = false;
            TB_maxrow.Text = "100";
            TB_maxrow.Enabled = false;
            llb_newpage.Enabled = false;
            LLB_EditBigSql.Enabled = false;
            CB_quickload.Enabled = false;
#endif
        }

        //----------------------------------------------------------
        //函式名稱: MainForm_Shown
        //說明: 第一次顯示MainForm時，讀取setup.ini預先初始化各項設定
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //設定MainForm顯示工具名稱
            string sApName = ConfigurationManager.AppSettings["ApName"];
            string sApVersion = ConfigurationManager.AppSettings["ApVersion"];
            MainFormTitle = sApName + " " + sApVersion;
            this.Text = MainFormTitle;

            //取得使用者儲存的設定
            bool bGetMySetup = Common.Setup.GetMySteup(Setup_File_Name, ref userSetupList);

            if (bGetMySetup)
            {
                Active_Setup();  //開始設定UI
                SetupForm_initial();   //設定SetupForm的選項
            }
            else
            {
                ShowAlertBox("無法匯入個人設定!", "警告");
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetupForm_initial
        //說明: 設定SetupForm的選項
        //參數: 無
        //回傳值: bool 
        //----------------------------------------------------------
        private bool SetupForm_initial()
        {
            try
            {
                foreach (MyClass.cSetup setup in userSetupList)
                {
                    String sTitle = setup.KeyName;
                    String sValue = Common.Setup.Get_Setup_Value(ref userSetupList, sTitle);
                    switch (sTitle)
                    {
                        case "列出所有表格":
                            if (sValue.ToString().ToLower() == "true")
                            {
                                setupForm.si.Set_List_All_Tbs = true;
                            }
                            else
                            {
                                setupForm.si.Set_List_All_Tbs = false;
                            }
                            break;
                        case "開啟音效":
                            if (sValue.ToString().ToLower() == "true")
                            {
                                setupForm.si.Set_CB_music = true;
                            }
                            else
                            {
                                setupForm.si.Set_CB_music = false;
                            }
                            break;
                        case "主題選擇":
                            setupForm.si.Set_CB_theme = Convert.ToInt16(sValue);
                            break;
                        case "背景顏色":
                            setupForm.si.Set_CB_maincolor = Convert.ToInt16(sValue);
                            break;
                        case "查詢結果自動寬度":
                            setupForm.si.Set_CB_cellAutoWidth = Convert.ToInt16(sValue);
                            break;
                        case "查詢結果單數行底色":
                            setupForm.si.Set_CB_backcolor = Convert.ToInt16(sValue);
                            break;
                        case "查詢結果字體大小":
                            setupForm.si.Set_RB_rslt_wordsize = Convert.ToInt16(sValue);
                            break;
                        case "查詢結果於新視窗":
                            if (sValue.ToString().ToLower() == "true")
                            {
                                setupForm.si.Set_CB_ShowRsltForm = true;
                            }
                            else
                            {
                                setupForm.si.Set_CB_ShowRsltForm = false;
                            }
                            break;
                        default:
                            break;
                    }

                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("錯誤! 無法存取設定視窗，原因：" + ex.Message);
                return false;
            }
        }

        
        //----------------------------------------------------------
        //函式名稱: Active_Setup
        //說明: 根據Setup.ini設定UI
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        public void Active_Setup()
        {
            //取得該設定標題對應的cSetup物件
            
            foreach(MyClass.cSetup uSetup in userSetupList)
            {
                switch (uSetup.KeyName)
                {
                    case "列出所有表格":
                        //在GetUserTables()判斷...
                        break;
                    case "開啟音效":
                        //需要播放時才判斷...
                        break;
                    case "查詢結果於新視窗":
                        //需要播放時才判斷...
                        break;
                    case "主題選擇":
                        Int16 iTheme_index = Convert.ToInt16( uSetup.GetValue() );
                        switch( iTheme_index )
                        {
                            case 0:
                                if (File.Exists(Theme_Def_Pic_Path)) 
                                    GB_db.BackgroundImage = new Bitmap(Theme_Def_Pic_Path );
                                else
                                    GB_db.BackgroundImage = new Bitmap(Theme_err_Pic_Path);
                                break;
                            case 1:
                                if (File.Exists(Theme_User_Pic_Path))
                                    GB_db.BackgroundImage = new Bitmap(Theme_User_Pic_Path); 
                                else
                                    GB_db.BackgroundImage = new Bitmap(Theme_err_Pic_Path);
                                break;
                            default:
                                GB_db.BackgroundImage = new Bitmap(Theme_err_Pic_Path );
                                break;
                        }
                        break;
                    case "背景顏色":
                        Int16 iBk_Color = Convert.ToInt16(uSetup.GetValue());
                        switch (iBk_Color)
                        {
                            case 0:
                                this.BackColor = Color.LightSteelBlue; break;
                            case 1:
                                this.BackColor = Color.LightGreen; break;
                            case 2:
                                this.BackColor = Color.Silver; break;
                            case 3:
                                this.BackColor = Color.LightYellow; break;
                            case 4:
                                this.BackColor = Color.LightPink; break;
                            default:
                                this.BackColor = Color.LightSteelBlue; break;
                        }
                        break;
                    case "查詢結果自動寬度":
                        foreach (TabPage tp in tabControl2.Controls)
                        {
                            DataGridView dg = (DataGridView)tp.Controls[0];
                            //自動Cell寬度
                            int flg = Convert.ToInt16( uSetup.GetValue() );
                            dg.AutoSizeColumnsMode = Common.RegularFuc.Get_AutoSizeColumnsMode(flg );
                        }
                        break;
                    case "查詢結果字體大小":
                        Int16 iFont_Size = Convert.ToInt16(uSetup.GetValue());
                        SetDataGridView_WordSize(iFont_Size);
                        break;
                    case "查詢結果單數行底色":
                         foreach (TabPage tp in tabControl2.Controls)
                         {   
                            DataGridView dg = (DataGridView)tp.Controls[0];
                            //奇數列背景顏色
                            int flg = Convert.ToInt16(uSetup.GetValue());
                            dg.AlternatingRowsDefaultCellStyle.BackColor = Common.RegularFuc.Get_CellBackColor(flg);
                        }
                        break;
                }
            }

            
        }
        
        //----------------------------------------------------------
        //函式名稱: SetKeyWords
        //說明: 從文字檔抓取KeyWords匯入
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetKeyWords()
        {
            LB_keyword.Items.Clear();
            if (File.Exists("keywords.ini"))
            {
                StreamReader sr = new StreamReader("keywords.ini");
                while (!sr.EndOfStream)
                {
                    LB_keyword.Items.Add(sr.ReadLine().ToUpper());
                }
                sr.Close();
                sr.Dispose();
            }
            else
            {
               MessageBox.Show("keywords.ini 讀取失敗...","檔案遺失");
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetQuickLoad
        //說明: 從文字檔抓取主機帳號密碼匯入
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetQuickLoad()
        {
            CB_quickload.Items.Clear();
            if (File.Exists(QLoad_File_Name ))
            {
                StreamReader sr = new StreamReader(QLoad_File_Name);
                int index = 0;
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str.IndexOf("/") < 0)
                    {
                        CB_quickload.Items.Add(str);
                        Array.Resize(ref QuickLoad, QuickLoad.Length + 1);
                        QuickLoad[index] = new string[] { "", "", "" };
                        index++;
                        continue;
                    }
                    else
                    {
                        string str_id = str.Substring(0, str.IndexOf("/"));
                        string str_pwd = str.Substring(str.IndexOf("/") + 1, str.IndexOf("@") - str.IndexOf("/") - 1);
                        string str_server = str.Substring(str.IndexOf("@") + 1, str.Length - str.IndexOf("@") - 1);
                        
                        Array.Resize(ref QuickLoad, QuickLoad.Length + 1);
                        QuickLoad[index] = new string[] { str_id, str_pwd, str_server };
                        index++;
                        CB_quickload.Items.Add(str_id + "/" + str_pwd.Substring(0, str_pwd.Length / 2) + "***@" + str_server);
                    }
                }
                sr.Close();
                sr.Dispose();
            }
            else
            {
                MessageBox.Show(QLoad_File_Name+" 讀取失敗...", "檔案遺失");
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetStatusStrip
        //說明: 狀態列initial
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetStatusStrip()
        {
            StatusStrip01.Dock = DockStyle.Bottom; //停駐在底部
            TSSL.Font = new Font("新細明體", 9);
            TSSL.Text = "請先連線!";

            TSPB.AutoSize = false;
            TSPB.Width = 200;
            TSPB.Maximum = 600;
            

            StatusStrip01.Items.Add(TSSL);
            StatusStrip01.Items.Add(TSPB);

            TSPB.Dock = DockStyle.Right;
        }

        
        

        

        
        
        //----------------------------------------------------------
        //函式名稱: Get_User_Sel_Sql_ForSelect
        //說明: 取得User選擇的Select指令
        //參數: 無
        //回傳值: string
        //----------------------------------------------------------
        private string Get_User_Sel_Sql_ForSelect()
        {
            string UserSql = ""; //User打的sql

            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                UserSql = rtb.SelectedText.Trim();
            }
            tp = null;

            try
            {
                //判斷例外情況
                if (UserSql.Length == 0)
                {
                    return "Error01";   //請從SQL指令區先選擇SQL!
                }
                if (UserSql.Substring(0, 6).ToUpper() != "SELECT")
                {
                    return "Error02";   //非SELECT指令，無法執行匯出!
                }

               
                //加上筆數限制----------------------------------------------------------------------------
                if (UserSql.Substring(0, 6).ToUpper() == "SELECT" && CB_restrict.Checked == true)
                {
                    UserSql = "SELECT * FROM ( " + UserSql + " ) WHERE ROWNUM<=" + TB_maxrow.Text;
                }
                return UserSql;
            }
            catch (Exception)
            {
                return "Error03";   //例外情況
            }
        }
        

        
       

        

        //----------------------------------------------------------
        //函式名稱: timer_Run
        //說明: 執行timer
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void timer_Run()
        {
            timer_cnt = 0;
            TSPB.Value = 0;
            timer.Enabled = true;
        }
        //----------------------------------------------------------
        //函式名稱: timer_Stop
        //說明: 停止timer
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void timer_Stop()
        {
            timer.Enabled = false;
            TSPB.Value = TSPB.Maximum;
        }

        //----------------------------------------------------------
        //函式名稱: GetUserTables
        //說明: 列出owner下的tables
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void GetUserTables()
        {
            CB_tablename.Items.Clear();
            LB_tablename.Items.Clear();
            string selectCmd;

            bool bListAll = Common.Setup.Get_Setup_Value(ref userSetupList, "列出所有表格").ToLower() == "true" ? true : false;
            if (! bListAll) //只列出本身OWN的Table
            {
                selectCmd = "SELECT TABLE_NAME,TABLESPACE_NAME FROM USER_TABLES";
                LLB_constraint.Enabled = true;
            }
            else //列出所有可SELECT的Tables
            {
                selectCmd = "SELECT OWNER || '.' || TABLE_NAME as TABLE_NAME FROM ALL_TABLES ORDER BY OWNER";
                LLB_constraint.Enabled = false;
            }
          
            try
            {
                Application.DoEvents();
                DataTable dt_col = Common.DBModule.DB_ExecQuery(selectCmd);
                for (int i = 0; i < dt_col.Rows.Count; i++) 
                {
                    CB_tablename.Items.Add(dt_col.Rows[i].ItemArray[0].ToString()); //dt_col.Rows[i].ItemArray[j] : 第i列資料, 第j個欄位
                    LB_tablename.Items.Add(dt_col.Rows[i].ItemArray[0].ToString()); 
                }
                dt_col.Dispose();
            }
            catch (Exception ex)
            {
                ShowAlertBox(ex.Message, "例外錯誤");
            }
        }
       
        //----------------------------------------------------------
        //函式名稱: BT_query_Click
        //說明: 查詢
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_query_Click(object sender, EventArgs e)
        {
            //記錄開始時間
            DateTime start_time = DateTime.Now;
            TSSL.Text = "SQL執行中...請稍後。";
            RTB_SysMsg.Clear();
            timer_Run();
            Application.DoEvents();

            //OleDbConnection Conn = DB_Connect(TB_host.Text, TB_owner.Text, TB_pwd.Text);
            if (Common.DBModule.Conn.State == ConnectionState.Closed) //檢查Conn是否初始化了
            {
                tsmi_1_1_Click(sender, e);
            }

            string UserSql = ""; //User打的sql
            string UserSelSql = ""; //User選取的SQL

            //先設定 UserSql 和 UserSelSql-------------------------------------------
            TabPage tp_sql = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp_sql.Controls)
            {
                UserSql = rtb.Text.Trim();
                UserSelSql=rtb.SelectedText.Trim();
            }
            tp_sql = null;

            //判斷: 只執行選取的SQL 或是 全部SQL-----------------------------------
            if (UserSelSql.Length != 0)  //User有選取SQL ---> 只執行選取的SQL
            {
                UserSql= UserSelSql;
            }
            else
            {
                if (UserSql.Length == 0)
                {
                    timer_Stop();
                    TSSL.Text = "請輸入SQL...";
                    return;
                }
            }

            /**********************************
             * 開始執行後端查詢
             **********************************/
            //單一查詢..................................................................................
            if (UserSql.IndexOf(';') <= 0)  //以 ; 判斷是否為單或多個查詢
            {
                Go_Query(true, UserSql);
            }
            //多支查詢..................................................................................
            else
            {
                /*
                //因Regular Expression忽略斷行(\n)後，只能抓單行符合Pattern的字串，所以要
                //1.先把所有\n取代成blank
                //2.再把 ; 取代成\n
                //這樣原本有斷行的單一指令便會變成在單行
                */
                UserSql = UserSql.Replace("\n", " "); //取代斷行-->blank
                UserSql = UserSql.Replace(";", ";\n"); //取代 ; --> ;\n


                /************************************
                 * SELECT
                 ************************************/
                //(?mi) : 設定參數 ... m為啟用Multiline(\n)選項，i為忽略大小寫
                //(?<sql> ... ) : 設定群組名稱為sql ，其內容為 ...
                //SELECT.{0,} : Pattern為 "SELECT"和0~N個的萬用字元(除了\n)
                //Regex Rex = new Regex(@"(?mi)(?<sql>SELECT.{0,});");

                //(?mi) : 設定參數 ... m為啟用Multiline(\n)選項，i為忽略大小寫
                //^ : 開頭
                // blank{0,} : 允許0~N個空字串
                //(?<sql> ... ) : 設定群組名稱為sql ，其內容為 ...
                //SELECT.{0,} : Pattern為 "SELECT"和0~N個的萬用字元(除了\n)
                //$ : 結尾
                Regex Rex = new Regex(@"(?mi)^ {0,}(?<sql>.{0,});$");

                foreach (Match mch in Rex.Matches(UserSql))
                {
                    foreach (Capture c in mch.Groups["sql"].Captures)
                    {
                        //取得Regular Expression抓出來的字串
                        string qSql = c.Value;
                        Go_Query(false,qSql);
                    }
                }
                Rex = null;

            }//else
            
            

            //計算此Select SQL執行時間
            DateTime end_time = DateTime.Now;
            TimeSpan ts = new TimeSpan(end_time.Ticks - start_time.Ticks);
            TSSL.Text = "完成SQL指令! 共花費: " + ts.Seconds.ToString() + " 秒";
            timer_Stop();
        }

        //----------------------------------------------------------
        //函式名稱: Go_Query
        //說明: 查詢
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Go_Query(bool MsgFlg, string UserSql)
        {
            //左方頁籤[系統訊息]
            if (MsgFlg == false)
            {
                tabControl_Func.SelectedIndex = 1;
            }

            try
            {
                //加上筆數限制----------------------------------------------------------------------------
                if (UserSql.Substring(0, 6).ToUpper() == "SELECT" && CB_restrict.Checked == true)
                {
                    UserSql = "SELECT * FROM ( " + UserSql + " ) WHERE ROWNUM<=" + TB_maxrow.Text;
                }

                //下DROP,TRUNCATE,UPDATE,DELETE時，請USER再次確認--------------------------------
                string UserSql_Type = UserSql.Substring(0, UserSql.IndexOf(" ")).ToUpper();
                if (
                     MsgFlg == true &&
                     (
                     UserSql_Type == "DROP" || UserSql_Type == "TRUNCATE" || UserSql_Type == "UPDATE" || UserSql_Type == "DELETE"
                     || UserSql.Substring(0, 4).ToUpper() == "DROP" || UserSql.Substring(0, 8).ToUpper() == "TRUNCATE" || UserSql.Substring(0, 6).ToUpper() == "UPDATE" || UserSql.Substring(0, 6).ToUpper() == "DELETE"
                     )
                    )
                {
                    if (MessageBox.Show("您即將執行-" + UserSql_Type + "指令，無法還原資料。請再次確認!!! \n\nDB名稱:  " + Common.DBModule.Conn.DataSource.ToString(), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        TSSL.Text = "已取消SQL指令!";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlertBox("無法查詢!! \n原因：" + ex.Message, "錯誤");
                return;
            }

            try
            {
                if (UserSql.Substring(0, 6).ToUpper() == "SELECT") //SELECT的指令------------------------------------
                {
                    //開始進DB查詢
                    DataTable Rslt_dt = Common.DBModule.DB_ExecQuery(UserSql);

                    //播放音效
                    bool bPlayBGM = Common.Setup.Get_Setup_Value(ref userSetupList, "開啟音效").ToLower() == "true" ? true : false;
                    if (bPlayBGM == true) mciMusic(@"BGM\Query.wav", "play");

                    //查詢此次select的筆數
                    double sql_cnt = Common.RegularFuc.Cal_SQL_Count(UserSql);

                    //顯示筆數(MainForm)，只當主視窗的查詢結果有顯示時...
                    if (BT_down2.Visible == false)
                    {
                        if (CB_restrict.Checked) LB_cnt.Text = "共 " + sql_cnt.ToString() + " 筆(限制查詢" + TB_maxrow.Text + "筆)";
                        else LB_cnt.Text = "共 " + sql_cnt.ToString() + " 筆(沒有限制查詢筆數)";
                    }
                    else LB_cnt.Text = "";


                    //將Select結果放到對應的tabControl2
                    TabPage tp = tabControl2.TabPages[tabControl2.SelectedIndex];
                    foreach (DataGridView dg in tp.Controls)
                    {
                        dg.DataSource = Rslt_dt;
                    }
                    tp = null;

                    //判斷是否開啟另一視窗顯示結果
                    bool bShowRsltForm = Common.Setup.Get_Setup_Value(ref userSetupList, "查詢結果於新視窗").ToLower() == "true" ? true : false;
                    if (bShowRsltForm == true)
                    {
                        Array.Resize(ref RsltFormSet, RsltFormSet.Length + 1);
                        RsltFormSet[RsltFormSet_inx] = new RsltForm();
                        RsltFormSet[RsltFormSet_inx].Show();
                        RsltFormSet[RsltFormSet_inx].DG_rslt.DataSource = Rslt_dt;
                        RsltFormSet[RsltFormSet_inx].LB_Sql.Text = UserSql;

                        //單數行底色
                        RsltFormSet[RsltFormSet_inx].DG_rslt.AlternatingRowsDefaultCellStyle.BackColor = dG_table01.AlternatingRowsDefaultCellStyle.BackColor;
                        //顯示筆數(RsltForm)
                        if (CB_restrict.Checked) RsltFormSet[RsltFormSet_inx].LB_cnt.Text = "共 " + sql_cnt.ToString() + " 筆(限制查詢" + TB_maxrow.Text + "筆)";
                        else RsltFormSet[RsltFormSet_inx].LB_cnt.Text = "共 " + sql_cnt.ToString() + " 筆(沒有限制查詢筆數)";

                        RsltFormSet_inx++;
                    }
                    Rslt_dt.Dispose();


                }
                else  //非SELECT的指令------------------------------------
                {
                   
#if(DEMO)
                     //試用版限制
                    ShowAlertBox("試用版無法執行此指令!", "訊息");
                    return;
#endif
                    
                    string Rslt_NonQuery = "";


                    if (CB_rollback.Checked) //啟用資料還原
                    {
                        Rslt_NonQuery = Common.DBModule.DB_ExecNonQuery_Trans(ref transaction, UserSql);
                        Reset_Rollback_Buttons(2);
                        LLB_viewSql.Enabled = true;
                        transaction_Sql += UserSql +"; \n";
                    }
                    else
                    {
                        Rslt_NonQuery = Common.DBModule.DB_ExecNonQuery(UserSql);
                    }


                    //播放音效
                    bool bPlayBGM = Common.Setup.Get_Setup_Value(ref userSetupList, "開啟音效").ToLower() == "true" ? true : false;
                    if (bPlayBGM == true) mciMusic(@"BGM\Query.wav", "play");


                    //顯示結果
                    switch (Rslt_NonQuery.Substring(0, 2))
                    {
                        case "失敗":
                            if (MsgFlg == true)
                            {
                                TSSL.Text = "執行SQL失敗!";
                                ShowAlertBox("執行SQL失敗!\n " + Rslt_NonQuery.Substring(3, Rslt_NonQuery.Length - 3), "錯誤");
                            }
                            else
                            {
                                StringBuilder sb_SysMsg=new StringBuilder(300);
                                sb_SysMsg.Append("-->執行失敗：");
                                sb_SysMsg.Append(UserSql.Substring(0, (UserSql.Length > 100) ? 100 : UserSql.Length)); //只列出最多100字元的Sql
                                sb_SysMsg.Append("\n");
                                sb_SysMsg.Append(Rslt_NonQuery.Substring(3, Rslt_NonQuery.Length - 3));
                                sb_SysMsg.Append("\n\n");
                                RTB_SysMsg.Text += sb_SysMsg.ToString();
                            }
                            break;
                        case "成功":
                            if (MsgFlg == true)
                            {
                                TSSL.Text = "完成SQL指令! 共花費: " + timer_cnt.ToString() + " 秒";
                                ShowAlertBox("執行成功!! 成功筆數: " + Rslt_NonQuery.Substring(3, Rslt_NonQuery.Length - 3) + "\n(注意:新增,更新,刪除指令才會有筆數。)", "成功訊息");
                            }
                            else
                            {
                                StringBuilder sb_SysMsg = new StringBuilder(300);
                                sb_SysMsg.Append("-->執行成功：");
                                sb_SysMsg.Append(UserSql.Substring(0, (UserSql.Length > 100) ? 100 : UserSql.Length)); //只列出最多100字元的Sql
                                sb_SysMsg.Append("\n");
                                sb_SysMsg.Append("成功筆數: " + Rslt_NonQuery.Substring(3, Rslt_NonQuery.Length - 3));
                                sb_SysMsg.Append("\n\n");
                                RTB_SysMsg.Text += sb_SysMsg.ToString();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlertBox("無法完成查詢! 請重新檢查SQL。\n內部錯誤訊息： " + ex.Message, "錯誤");
                TSSL.Text = "查詢錯誤，請檢查SQL指令";
            }
        }
        //----------------------------------------------------------
        //函式名稱: SetDataGridView
        //說明: DataGrid Initial
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetDataGridView()
        {
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                TabPage tp2 = tabControl2.TabPages[i];
                foreach (DataGridView dg in tp2.Controls)
                {
                    dg.RowsDefaultCellStyle.BackColor = Color.LightYellow; //儲存格背景顏色
                    //dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightPink; //奇數列背景顏色
                    dg.EditMode = DataGridViewEditMode.EditOnEnter;  //USER選取資料時，即可編輯
                }
                tp2 = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: SetDataGridView_WordSize
        //說明: 設定查詢結果字體大小
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetDataGridView_WordSize(int v_Rslt_WordSize)
        {
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                TabPage tp2 = tabControl2.TabPages[i];
                foreach (DataGridView dg in tp2.Controls)
                {
                    switch (v_Rslt_WordSize)
                    {
                        case 0:
                            dg.Font = new Font("微軟正黑體", 10);
                            break;
                        case 1:
                            dg.Font = new Font("微軟正黑體", 9);
                            break;
                        case 2:
                            dg.Font = new Font("微軟正黑體", 8);
                            break;
                        default:
                            dg.Font = new Font("微軟正黑體", 9);
                            break;
                    }
                }
                tp2 = null;
            }
            
        }

        //----------------------------------------------------------
        //函式名稱: BT_excel_Click
        //說明: 將查詢的資料另存為Excel檔
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_excel_Click(object sender, EventArgs e)
        {
            if (CB_restrict.Checked)
            {
                if (MessageBox.Show("查詢時有限制筆數!!\n系統只會匯出目前顯示的資料，是否繼續？", "筆數限制警告!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            TabPage tp2 = tabControl2.TabPages[tabControl2.SelectedIndex];
            foreach (DataGridView dg in tp2.Controls)
            {
                DataTable dt_rslt = (DataTable)dg.DataSource;
                //呼叫 寫到Excel 函式---------------------------------------------
                string rslt_str = Common.RegularFuc.Paint_The_Excel(dt_rslt);
                if (rslt_str != "")
                {
                    MessageBox.Show("匯出Excel失敗! 原因:" + rslt_str);
                }
                else
                {
                    TSSL.Text = "匯出Excel成功! ";
                }
            }
            tp2 = null;
        }

        //----------------------------------------------------------
        //函式名稱: CB_tablename_SelectedIndexChanged
        //說明: 選擇Table name
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void CB_tablename_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLB_column.Items.Clear();
            if (CB_tablename.SelectedIndex >= 0)
            {
                string tb_name = CB_tablename.SelectedItem.ToString();
                string selectCmd = "SELECT column_name FROM user_tab_columns WHERE table_name = '" + tb_name +"' ORDER BY COLUMN_ID";
                try
                {
                    DataTable dt_col = Common.DBModule.DB_ExecQuery(selectCmd);
                    for (int i = 0; i < dt_col.Rows.Count; i++) //ds.Tables["TB1"].Columns.Count : 欄位數目
                    {
                        CLB_column.Items.Add(dt_col.Rows[i].ItemArray[0].ToString()); //dt_col.Columns[i] : 第i個欄位名稱
                    }
                    dt_col.Dispose();

                    //LB_tablename和CB_tablename同步化
                    for (int i = 0; i < LB_tablename.Items.Count; i++)
                    {
                        if (LB_tablename.Items[i].ToString() == tb_name)
                        {
                            LB_tablename.SelectedIndex = i;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowAlertBox(ex.Message, "例外錯誤");
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: LB_tablename_SelectedIndexChanged
        //說明: LB_tablename和CB_tablename同步化
        //----------------------------------------------------------
        private void LB_tablename_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_tablename.SelectedItem = LB_tablename.SelectedItem.ToString();
        }
        //----------------------------------------------------------
        //函式名稱: LLB_03_LinkClicked
        //說明: 勾選所有欄位
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_03_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < CLB_column.Items.Count; i++)
            {
                CLB_column.SetItemChecked(i, true); //設定項目的選取
            }
        }

        //----------------------------------------------------------
        //函式名稱: LLB_04_LinkClicked
        //說明: 取消勾選所有欄位
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_04_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < CLB_column.Items.Count; i++)
            {
                CLB_column.SetItemChecked(i, false);//設定項目的選取
            }
        }

        //----------------------------------------------------------
        //函式名稱: InsertIntoRTB
        //說明: 插入字串
        //參數: 插入的字串
        //回傳值: 無
        //----------------------------------------------------------
        private void InsertIntoRTB(string src)
        {
            int start_pos;
            string part01;
            string part02;

            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                start_pos = rtb.SelectionStart;
                part01 = rtb.Text.Substring(0, start_pos);
                part02 = rtb.Text.Substring(start_pos + rtb.SelectionLength);
                rtb.Text = part01 + src + part02;
                rtb.SelectionStart = start_pos + src.Length;
                rtb.Focus(); //回到焦點
            }
            tp = null;
        }

        //----------------------------------------------------------
        //函式名稱: LB_keyword_DoubleClick
        //說明: 插入KEYWORD裡面的字串
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LB_keyword_DoubleClick(object sender, EventArgs e)
        {
            InsertIntoRTB(LB_keyword.SelectedItem.ToString());
        }

        //----------------------------------------------------------
        //函式名稱: BT_add1_Click
        //說明: 加入SQL到編輯區
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_add1_Click(object sender, EventArgs e)
        {
            if (!(CB_tablename.SelectedIndex >= 0)) return;

            string sql;
            if (CLB_column.CheckedItems.Count > 0)
            {
                string str_Sel_ColName_v = ""; //USER勾選的欄位名稱集合(含斷行)
                string str_Sel_ColName_p = ""; //USER勾選的欄位名稱集合(Parallel)
                string str_Sel_ColName_e = ""; //USER勾選的欄位名稱集合(含=,)
                for (int i = 0; i < CLB_column.CheckedItems.Count; i++)
                {
                    if (i == (CLB_column.CheckedItems.Count - 1))
                    {
                        str_Sel_ColName_v += CLB_column.CheckedItems[i].ToString();
                        str_Sel_ColName_p += CLB_column.CheckedItems[i].ToString();
                        str_Sel_ColName_e += CLB_column.CheckedItems[i].ToString() + "=";
                    }
                    else
                    {
                        str_Sel_ColName_v += CLB_column.CheckedItems[i].ToString() + ",\n";
                        str_Sel_ColName_p += CLB_column.CheckedItems[i].ToString() + ",";
                        str_Sel_ColName_e += CLB_column.CheckedItems[i].ToString() + "=,\n";
                    }
                }
                switch (CB_sqlstyle.SelectedItem.ToString())
                {
                    case "SELECT":
                        sql = "SELECT \n" + str_Sel_ColName_v + "\nFROM " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "CREATE":
                        sql = "CREATE TABLE ... \nAS SELECT\n" + str_Sel_ColName_v + "\nFROM " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "INSERT":
                        sql = "INSERT INTO " + CB_tablename.SelectedItem.ToString() + "\nSELECT\n" + str_Sel_ColName_v + "\nFROM " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "DELETE":
                        sql = "DELETE FROM " + CB_tablename.SelectedItem.ToString() + "\nWHERE\n" + str_Sel_ColName_e;
                        break;
                    case "UPDATE":
                        sql = "UPDATE " + CB_tablename.SelectedItem.ToString() + " SET\n" + str_Sel_ColName_e;
                        break;
                    case "TRUNCATE":
                        sql = "TRUNCATE TABLE " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "DROP":
                        sql = "DROP TABLE " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "查看欄位型態長度":
                        string tmp2 = str_Sel_ColName_v;
                        tmp2=tmp2.Replace(",\n", "',\n'");
                        tmp2 = "'" + tmp2 + "'";

                        string tb_org_name=CB_tablename.SelectedItem.ToString().ToUpper();
                        string owner_name="";
                        string tb_name="";
                        if (tb_org_name.IndexOf(".") > 0) //選擇非自己Own的Table
                        {
                             owner_name = tb_org_name.Substring(0, tb_org_name.IndexOf("."));
                             tb_name = tb_org_name.Substring(tb_org_name.IndexOf(".") + 1, tb_org_name.Length - tb_org_name.IndexOf(".") - 1);
                             sql = "SELECT column_name, data_type, data_length, data_precision, data_scale \nFROM all_tab_columns \nWHERE table_name = '" + 
                                        tb_name + "' \nand \nowner='" + owner_name + "'" + "' \n" +
                                        "AND column_name in (\n" + tmp2 + "\n) ORDER BY COLUMN_ID"; 
                        }
                       else //自己Own的Table
                       {
                          tb_name = tb_org_name;
                          sql = "SELECT column_name, data_type, data_length, data_precision, data_scale \nFROM user_tab_columns \n" +
                                   "WHERE table_name = '" + tb_name +"' \n" +
                                   "AND column_name in (\n" + tmp2 + "\n)  ORDER BY COLUMN_ID";
                       }
                        break;
                    default:
                        sql = "";
                        break;
                }

            }
            else //USER沒有勾選任何欄位名稱
            {
                switch (CB_sqlstyle.SelectedItem.ToString())
                {
                    case "SELECT":
                        sql = "SELECT * FROM " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "CREATE":
                        sql = "CREATE ... \nAS SELECT\n*\nFROM " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "INSERT":
                        sql = "INSERT INTO " + CB_tablename.SelectedItem.ToString() + " VALUES( ... )";
                        break;
                    case "DELETE":
                        sql = "DELETE FROM " + CB_tablename.SelectedItem.ToString() + "\nWHERE\n ...";
                        break;
                    case "UPDATE":
                        sql = "UPDATE " + CB_tablename.SelectedItem.ToString() + " SET\n ...";
                        break;
                    case "TRUNCATE":
                        sql = "TRUNCATE TABLE " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "DROP":
                        sql = "DROP TABLE " + CB_tablename.SelectedItem.ToString();
                        break;
                    case "查看欄位型態長度":
                        string tb_org_name = CB_tablename.SelectedItem.ToString().ToUpper();
                        string owner_name = "";
                        string tb_name = "";
                        if (tb_org_name.IndexOf(".") > 0) //選擇非自己Own的Table
                        {
                            owner_name = tb_org_name.Substring(0, tb_org_name.IndexOf("."));
                            tb_name = tb_org_name.Substring(tb_org_name.IndexOf(".") + 1, tb_org_name.Length - tb_org_name.IndexOf(".") - 1);
                            sql = "SELECT column_name, data_type, data_length, data_precision, data_scale \nFROM all_tab_columns \nWHERE table_name = '" +
                                       tb_name + "' \nand \nowner='" + owner_name + "'";
                        }
                        else //自己Own的Table
                        {
                            tb_name = tb_org_name;
                            sql = "SELECT column_name, data_type, data_length, data_precision, data_scale \nFROM user_tab_columns \n" +
                                     "WHERE table_name = '" + tb_name + "' \n";
                        }
                        break;
                    default:
                        sql = "";
                        break;
                }
            }

            /*將SQL加入tabPage*/
            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                rtb.Text = sql;
                rtb.Focus();
                rtb.Select(rtb.TextLength, 1);
            }
            tp = null;
        }

        //----------------------------------------------------------
        //函式名稱: LLB_01_LinkClicked
        //說明: 加入目前選擇的Table name到編輯區
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_01_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CB_tablename.SelectedIndex >= 0)
                InsertIntoRTB(CB_tablename.SelectedItem.ToString());
        }

        //----------------------------------------------------------
        //函式名稱: LLB_refresh_LinkClicked
        //說明: 重新整理TABLES
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetUserTables();
        }

        //----------------------------------------------------------
        //函式名稱: LLB_edit02_LinkClicked
        //說明: 打開keywords.ini
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_edit02_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists("keywords.ini"))
            {
                Process.Start("notepad", "keywords.ini");
            }
            else
            {
                MessageBox.Show("keywords.ini 不存在（請置於執行檔相同資料夾)!!", "檔案遺失...@@");
                ShowAlertBox("keywords.ini 不存在!\n無法開啟!!", "存取失敗");
            }
        }

        //----------------------------------------------------------
        //函式名稱: LLB_refreshkeyword_LinkClicked
        //說明: Refresh keywords
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_refreshkeyword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetKeyWords();
        }

        //----------------------------------------------------------
        //函式名稱: CB_quickload_SelectedIndexChanged
        //說明: 選擇quickload
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void CB_quickload_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_quickload.SelectedIndex >= 0)
            {
                int index = CB_quickload.SelectedIndex;
                TB_host.Text = QuickLoad[index][2];
                TB_owner.Text = QuickLoad[index][0];
                TB_pwd.Text = QuickLoad[index][1];
            }
        }

        //----------------------------------------------------------
        //函式名稱: linkLabel1_LinkClicked
        //說明: 打開quickload.ini
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(QLoad_File_Name))
            {
                Process.Start("notepad", QLoad_File_Name );
            }
            else
            {
                ShowAlertBox(QLoad_File_Name+" 不存在!\n無法開啟!!", "存取失敗");
            }
        }

        //----------------------------------------------------------
        //函式名稱: dG_table_DataError
        //說明: 顯示錯誤訊息
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void dG_table_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowAlertBox("錯誤訊息： \n" + e.Exception.Message, "錯誤");
        }

        //----------------------------------------------------------
        //函式名稱: timer_Tick
        //說明: timer每執行一次，會觸發的事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            if (timer_cnt < 600)
            {
                timer_cnt++;
                TSSL.Text = "花費時間：" + timer_cnt.ToString() + "秒   ";
                TSPB.Value = timer_cnt;
            }
            else
            {
                timer.Enabled = false;
                TSPB.Value = timer_cnt;
                TSSL.Text = "花費時間超過十分鐘，請再稍後 ... ";
            }
        }

        //----------------------------------------------------------
        //函式名稱: RTB_KeyDown
        //說明: 快速鍵
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void RTB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: //F5=查詢
                    BT_query_Click(sender, e);
                    break;
                case Keys.D1:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 0;
                    }
                    break;
                case Keys.D2:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 1;
                    }
                    break;
                case Keys.D3:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 2;
                    }
                    break;
                case Keys.D4:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 3;
                    }
                    break;
                case Keys.D5:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 4;
                    }
                    break;
                case Keys.D6:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 5;
                    }
                    break;
                case Keys.E:  //Ctrl+E=開啟設定畫面
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tsmi_1_4_Click(sender, null);
                    }
                    break;
                case Keys.S:  //Ctrl+S=儲存SQL
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tsmi_1_5_Click(sender,null);
                    }
                    break;
                case Keys.L:  //Ctrl+L=匯入SQL
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tsmi_1_6_Click(sender, null);
                    }
                    break;
                case Keys.W:  //Ctrl+W=開啟編輯sql視窗
                    if (e.Control) //Control寫在這邊判斷
                    {
                        LLB_EditBigSql_LinkClicked(sender, null);
                    }
                    break;
                case Keys.N:  //Ctrl+N=開啟新Tabpage
                    if (e.Control) //Control寫在這邊判斷
                    {
                        llb_newpage_LinkClicked(sender, null);
                    }
                    break;
                default:
                    break;
            }
        }
        //----------------------------------------------------------
        //函式名稱: MainForm_KeyDown
        //說明: 快速鍵
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6: //直接查詢
                    tsmi_201_Click(sender, e);
                    break;
                case Keys.D1:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 0;
                    }
                    break;
                case Keys.D2:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 1;
                    }
                    break;
                case Keys.D3:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 2;
                    }
                    break;
                case Keys.D4:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 3;
                    }
                    break;
                case Keys.D5:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 4;
                    }
                    break;
                case Keys.D6:
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tabControl.SelectedIndex = 5;
                    }                  
                    break;
                case Keys.E:  //Ctrl+E=開啟設定畫面
                    if (e.Control) //Control寫在這邊判斷
                    {
                        tsmi_1_4_Click(sender, null);
                    }
                    break;
                default:
                    break;
            }
        }
        //----------------------------------------------------------
        //函式名稱: tabControl_SelectedIndexChanged,tabControl2_SelectedIndexChanged
        //說明: 同步編輯區和資料區的頁籤
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = tabControl.SelectedIndex;

            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                rtb.Focus();
            }
            tp = null;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = tabControl2.SelectedIndex;
        }

        //----------------------------------------------------------
        //函式名稱: BT_top_Click
        //說明: 隱藏上方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_top_Click(object sender, EventArgs e)
        {
            GB_top.Visible = false;
            BT_top.Visible = false;
            BT_down.Visible = true;

            /*編輯SQL處*/
            tabControl.Top=25;
            tabControl.Height = 420;
            foreach (TabPage tp in tabControl.Controls)
            {
                tp.Controls[0].Height = RTB_max_hight; //每個RichTextBox的高度改變
            }

            /*關鍵字選擇處*/
            //GB_sp.Top = 25;
            //GB_sp.Height = 420;
            //LB_keyword.Height = 400;
        }

        //----------------------------------------------------------
        //函式名稱: BT_down_Click
        //說明: 顯示上方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_down_Click(object sender, EventArgs e)
        {
            GB_top.Visible = true;
            BT_top.Visible = true;
            BT_down.Visible = false;

            /*編輯SQL處*/
            tabControl.Top = 180;
            tabControl.Height = 264;
            foreach (TabPage tp in tabControl.Controls)
            {
                tp.Controls[0].Height = RTB_min_hight; //每個RichTextBox的高度改變
            }

            /*關鍵字選擇處*/
            //GB_sp.Top = 194;
            //GB_sp.Height = 250;
            //LB_keyword.Height = 199;
        }

        //----------------------------------------------------------
        //函式名稱: BT_left_Click
        //說明: 隱藏右方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_left_Click(object sender, EventArgs e)
        {
            this.LB_tablename.Visible = false;
            this.Width = 865;
            BT_left.Visible = false;
            BT_right.Visible = true;
        }

        //----------------------------------------------------------
        //函式名稱: BT_right_Click
        //說明: 顯示右方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_right_Click(object sender, EventArgs e)
        {
            this.LB_tablename.Visible = true;
            this.Width = 1100;
            BT_left.Visible = true;
            BT_right.Visible = false;
        }

        //----------------------------------------------------------
        //函式名稱: BT_top2_Click
        //說明: 隱藏下方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_top2_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            this.Height = 540;
            BT_top2.Visible = false;
            BT_down2.Visible = true;
        }

        //----------------------------------------------------------
        //函式名稱: BT_down2_Click
        //說明: 顯示下方的區域
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_down2_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = true;
            this.Height = 680;
            BT_top2.Visible=true;
            BT_down2.Visible = false;
        }
        //----------------------------------------------------------
        //函式名稱: LLB_col_LinkClicked
        //說明: 直接顯示[欄位資訊]
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        public void LLB_col_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //判斷是否有選取Table name
            if (CB_tablename.SelectedIndex < 0) return; 

            string cSql = ""; //欄位資訊SQL
            string tb_org_name = CB_tablename.SelectedItem.ToString().ToUpper(); //選擇的Table name

            //欄位資訊的SQL------------------------------------------------------------
            if (tb_org_name.IndexOf(".") > 0) //選擇非自己Own的Table
            {
                string owner_name = tb_org_name.Substring(0, tb_org_name.IndexOf("."));
                string tb_name = tb_org_name.Substring(tb_org_name.IndexOf(".") + 1, tb_org_name.Length - tb_org_name.IndexOf(".") - 1);
                cSql = "SELECT column_name, data_type, data_length, data_precision, data_scale FROM all_tab_columns WHERE table_name = '" +
                           tb_name + "' and owner='" + owner_name + "' ORDER BY COLUMN_ID";
            }
            else  //自己Own的Table
            {
                cSql = "SELECT column_name, data_type, data_length, data_precision, data_scale FROM user_tab_columns WHERE table_name = '" + CB_tablename.SelectedItem.ToString() + "' ORDER BY COLUMN_ID";
            }

            if (CB_tablename.SelectedIndex >= 0)
            {
                string user_sql_tmp; //暫存目前USER下在指令區的SQL
                TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
                foreach (RichTextBox rtb in tp.Controls)
                {
                    user_sql_tmp = rtb.Text;
                    rtb.Text = cSql;
                    rtb.SelectAll(); //預防使用者開啟了"只執行選取的SQL"，故自動選取所有文字。
                    BT_query_Click(sender, e);
                    rtb.Text = user_sql_tmp;
                }
                tp = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: LLB_constraint_LinkClicked
        //說明: 顯示目前選擇的Table constraints 等資訊
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_constraint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string SelTableName;
            if (CB_tablename.SelectedIndex >= 0)
            {
                SelTableName = CB_tablename.SelectedItem.ToString();
                //SQL----
                //Primary Key---------------
                string pSql = "SELECT INDEX_NAME AS INDEX名稱,COLUMN_NAME AS PK欄位,COLUMN_POSITION AS PK順位 "+
                                          "FROM USER_IND_COLUMNS "+
                                          "WHERE TABLE_NAME='"+SelTableName+"' "+
                                          "ORDER BY COLUMN_POSITION";
                //Constraint----------------
                string cSql = "SELECT " +
                                          "OWNER, " +
                                          "CONSTRAINT_NAME AS CONSTRAINT名稱, " +
                                          "DECODE(CONSTRAINT_TYPE,'C','check constraint on a table','P','primary key','U','unique key','R','referential integrity','V','with check option, on a view','O','with read only, on a view') AS 種類, " +
                                          "CASE WHEN STATUS='ENABLED' THEN '使用中' ELSE '無效' END AS 狀態, " +
                                          "SEARCH_CONDITION AS 描述, " +
                                          "INDEX_NAME AS INDEX名稱, " +
                                          "LAST_CHANGE AS 修改日期 " +
                                          "FROM USER_CONSTRAINTS " +
                                          "WHERE TABLE_NAME='" + SelTableName + "'";
                
                try
                {
                    DataTable dt01 = Common.DBModule.DB_ExecQuery(pSql);
                    DataTable dt02 = Common.DBModule.DB_ExecQuery(cSql);

                    //打開Constraint新視窗-----
                    ConstraintForm CstForm = new ConstraintForm();
                    CstForm.Show();
                    CstForm.DG_pkey.DataSource = dt01;
                    CstForm.DG_constraint.DataSource = dt02;
                    dt01.Dispose();
                    dt02.Dispose();
                 }
                catch (Exception ex)
                {
                    ShowAlertBox("無法提供其他資訊!!\n內部錯誤訊息： " + ex.Message, "例外錯誤");
                }
            }          
        }

        //----------------------------------------------------------
        //函式名稱: CB_rollback_CheckedChanged
        //說明: 開啟或關閉 [啟用資料還原]
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void CB_rollback_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_rollback.Checked == false)
            {
                int iChked_case = Chk_Transaction(ref transaction);
                switch (iChked_case)
                {
                    case 0: //已作Commit或Rollback
                        CB_rollback.Checked = false;
                        break;
                    case 1: //取消
                        CB_rollback.Checked = true;
                        break;
                    case -1: //例外錯誤
                        ShowAlertBox("錯誤! 資料無法Commit或Rollback。 ", "錯誤");
                        break;
                    default:
                        break;
                }
            }
        }

        //----------------------------------------------------------
        //函式名稱: LLB_viewSql_LinkClicked
        //說明: 檢視尚未Commit或Rollback的Sql
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_viewSql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (transaction_Sql != "" && transaction_Sql != null)
            {
                if (tabControl.TabPages.Count < 20)
                {
                    try
                    {
                        llb_newpage_LinkClicked(sender, null);

                        /*將SQL加入tabPage*/
                        TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
                        foreach (RichTextBox rtb in tp.Controls)
                        {
                            rtb.Text = transaction_Sql;
                            rtb.Focus();
                            rtb.Select(rtb.TextLength, 1);
                        }
                        tp = null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("錯誤! " + ex.Message);
                    }
                }
            }
        }
        
        //----------------------------------------------------------
        //函式名稱: LLB_EditBigSql_LinkClicked
        //說明: 顯示EditSqlForm
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void LLB_EditBigSql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editsqlForm.MainForm_tabControl_SelIndex = tabControl.SelectedIndex;

            TabPage tp = tabControl.TabPages[tabControl.SelectedIndex];
            foreach (RichTextBox rtb in tp.Controls)
            {
                editsqlForm.RTB_SQL.Text = rtb.Text;
            }
            tp = null;
            //顯示EditSqlForm
            editsqlForm.ShowDialog(this); //在ShowDialog裡面指定Owner為MainForm，否則在EditSqlForm回存會出錯!!!!!
        }

        //----------------------------------------------------------
        //函式名稱: MainForm-MouseEnter,MouseLeave,MouseDown,MouseUp,MouseMove
        //說明: 顯示EditSqlForm
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private int ms_xPos_s;
        private int ms_yPos_s;
        private int ms_xPos_e;
        private int ms_yPos_e;
        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            ms_xPos_s = 0; ms_yPos_s = 0; ms_xPos_e = 0; ms_yPos_e = 0;
        }
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            ms_xPos_s = 0; ms_yPos_s = 0; ms_xPos_e = 0; ms_yPos_e = 0;
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ms_xPos_s = e.X;
            ms_yPos_s = e.Y;
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            ms_xPos_e = e.X;
            ms_yPos_e = e.Y;
            if (ms_xPos_e == ms_xPos_s)
            {
                ms_xPos_s = 0;
                ms_xPos_e = 0;
            }
            if (ms_yPos_e == ms_yPos_s)
            {
                ms_yPos_s = 0;
                ms_yPos_e = 0;
            }
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (ms_xPos_s != 0 && ms_yPos_s != 0 && ms_xPos_e != 0 && ms_yPos_e != 0)
            {
                if (ms_yPos_e - ms_yPos_s > 50) //往下滑動
                {
                    BT_down_Click(this, null);
                }
                else if (ms_yPos_e - ms_yPos_s < -50) //往上滑動
                {
                    BT_top_Click(this, null);
                }
                else
                {ms_yPos_s = 0; ms_yPos_e = 0;}

                if (ms_xPos_e - ms_xPos_s >50) //往右滑動
                {
                    BT_right_Click(this,null);
                }
                else if (ms_xPos_e - ms_xPos_s < -50) //往左滑動
                {
                    BT_left_Click(this, null);
                }
                else
                {ms_xPos_s = 0; ms_xPos_e = 0;}
            }
        }
        //----------------------------------------------------------
        //函式名稱: llb_newpage_LinkClicked
        //說明: 新增TabPage
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void llb_newpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabControl.TabPages.Count >= 20)
            {
                ShowAlertBox("無法再新增新的查詢頁面!","系統警告");
                return;
            }
            TabPage tp=new TabPage("新增指令("+(tabControl.TabPages.Count+1).ToString()+")");
            TabPage tp_rslt = new TabPage("結果(" + (tabControl2.TabPages.Count + 1).ToString() + ")");
            
            //RichTexBox----------------------------------
            RichTextBox new_rtb = new RichTextBox();
            //new_rtb.Name = "RTB" + (tabControl.TabPages.Count + 1).ToString().PadLeft(2, '0');
            new_rtb.Width = RTB01.Width;
            new_rtb.Height = RTB01.Height;
            new_rtb.Left=RTB01.Location.X;
            new_rtb.Top=RTB01.Location.Y;
            new_rtb.BackColor = RTB01.BackColor;
            new_rtb.ContextMenuStrip = cmenustrip_02_RTB;
            new_rtb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            new_rtb.Focus();


            //DataGridView-------------------------------
            DataGridView new_dg = new DataGridView();
            new_dg.Name = "dG_table" + (tabControl.TabPages.Count + 1).ToString().PadLeft(2, '0');
            new_dg.Width = dG_table01.Width;
            new_dg.Height = dG_table01.Height;
            new_dg.Left = dG_table01.Location.X;
            new_dg.Top = dG_table01.Location.Y;
            new_dg.BackgroundColor = dG_table01.BackgroundColor;
            new_dg.BorderStyle = dG_table01.BorderStyle;
            //自動Cell寬度
            new_dg.AutoSizeColumnsMode = dG_table01.AutoSizeColumnsMode;
            //奇數列背景顏色
            new_dg.AlternatingRowsDefaultCellStyle.BackColor = dG_table01.AlternatingRowsDefaultCellStyle.BackColor;
            new_dg.ContextMenuStrip = cmenustrip_03;
           
            //加入TabPage-------------------------
            tp.Controls.Add(new_rtb);
            tp_rslt.Controls.Add(new_dg);
            
            //加入TabCOntrol----------------------
            tabControl.TabPages.Add(tp);
            tabControl2.TabPages.Add(tp_rslt);
            tabControl.SelectedIndex = (tabControl.TabPages.Count - 1); //自動Select最後一個tabpage

            tp = null;
            tp_rslt = null;
        }

        //----------------------------------------------------------
        //函式名稱: MainForm_FormClosing
        //說明: 關閉主程式
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    e.Cancel = true;
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
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }

        }

        

    }
 }  
