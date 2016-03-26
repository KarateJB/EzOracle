#define MODIFYING
//#undef MODIFYING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JB_EzOracleSQL
{
    public partial class SetupForm : Form
    {
        public Setup_Info si;

        /*#####################  設定參數區 ##################### */
        private String Setup_File_Name = "setup.ini";
        private String MainForm_BkColor_Def = "淺藍(預設)";
        private String Theme_Def_Pic_Path = @"Theme\\Theme_Spe.jpg";
        private String Theme_User_Pic_Path = @"Theme\\Theme.jpg";
        private String Theme_err_Pic_Path = @"Theme\\error.jpg";
        /*################################################### */


        public SetupForm()
        {
            InitializeComponent();
            si = new Setup_Info();
        }

        //----------------------------------------------------------
        //函式名稱: BT_ok_Click
        //說明: 儲存設定，並利用Setup_Info這個class裡面的方法，讓其他Form可取得這些參數的值。
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_ok_Click(object sender, EventArgs e)
        {
            if (CB_alltables.Checked == true) si.Set_List_All_Tbs = true;
            else si.Set_List_All_Tbs = false;

            if (CB_ShowRsltForm.Checked == true) si.Set_CB_ShowRsltForm = true;
            else si.Set_CB_ShowRsltForm = false;

            if (CB_music.Checked == true) si.Set_CB_music = true;
            else si.Set_CB_music = false;

            if (RB_rslt_big.Checked) si.Set_RB_rslt_wordsize = 0;
            else if (RB_rslt_mid.Checked) si.Set_RB_rslt_wordsize = 1;
            else if (RB_rslt_small.Checked) si.Set_RB_rslt_wordsize = 2;
            else si.Set_RB_rslt_wordsize = 1;//default

            si.Set_CB_cellAutoWidth = CB_cellAutoWidth.SelectedIndex;
            si.Set_CB_backcolor = CB_backcolor.SelectedIndex;

            si.Set_CB_theme = CB_theme.SelectedIndex;
            si.Set_CB_maincolor = CB_maincolor.SelectedIndex;
            
            SaveSetup();
            MainForm form1 = (MainForm)this.Owner;
            if (Common.Setup.GetMySteup(form1.Setup_File_Name, ref form1.userSetupList) == true)
             {
                 form1.Active_Setup();
             }

            form1 = null;
            this.Close();
        }
        //----------------------------------------------------------
        //函式名稱: SaveSetup
        //說明: 設定後，儲存到setup.ini
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SaveSetup()
        {
            if (!File.Exists(Setup_File_Name ))
            {
                MessageBox.Show(String.Format("無法儲存~請檢查 {0} 是否存在？", Setup_File_Name),"儲存失敗");
            }
            else
            {
                Stream myStream;
                myStream = File.Open( Setup_File_Name , FileMode.Open); //開啟檔案讀到Stream
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.Default);
                try
                {
                    sw.WriteLine("列出所有表格=" + CB_alltables.Checked.ToString());
                    sw.WriteLine("開啟音效=" + CB_music.Checked.ToString());
                    sw.WriteLine("主題選擇=" + CB_theme.SelectedIndex.ToString());
                    sw.WriteLine("背景顏色=" + CB_maincolor.SelectedIndex.ToString());
                    sw.WriteLine("查詢結果自動寬度=" + CB_cellAutoWidth.SelectedIndex.ToString());
                    sw.WriteLine("查詢結果單數行底色=" + CB_backcolor.SelectedIndex.ToString());
                    sw.WriteLine("查詢結果字體大小=" + si.Set_RB_rslt_wordsize.ToString());
                    sw.WriteLine("查詢結果於新視窗=" + CB_ShowRsltForm.Checked.ToString());
                    
                    //sw.Flush();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法儲存~請檢查檔案是否開啟？\n內部錯誤訊息：" + ex.Message,"儲存失敗");
                }
                finally
                {
                    myStream.Close();
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: SetupForm_Load
        //說明: 產生SetupForm時，便將MainForm讀取setup.ini的設定值設定給各元件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetupForm_Load(object sender, EventArgs e)
        {
            //產生SetupForm時，便將MainForm讀取setup.ini的設定值設定給各元件
            //是否列出所有Table
            CB_alltables.Checked = Convert.ToBoolean(si.Set_List_All_Tbs); 
            //是否另外顯示結果視窗
            CB_ShowRsltForm.Checked = Convert.ToBoolean(si.Set_CB_ShowRsltForm);
            //開啟音樂
            CB_music.Checked = Convert.ToBoolean(si.Set_CB_music);
            //自動寬度調整
            CB_cellAutoWidth.SelectedIndex = si.Set_CB_cellAutoWidth;
            //雙數列底色
            CB_backcolor.SelectedIndex = si.Set_CB_backcolor;
            //查詢結果字體大小
            if (si.Set_RB_rslt_wordsize == 0) RB_rslt_big.Checked = true;
            else if (si.Set_RB_rslt_wordsize == 1) RB_rslt_mid.Checked = true;
            else if (si.Set_RB_rslt_wordsize == 2) RB_rslt_small.Checked = true;
            else RB_rslt_mid.Checked = true;
            //主題選擇
            CB_theme.SelectedIndex = si.Set_CB_theme;
            //背景顏色
            CB_maincolor.SelectedIndex = si.Set_CB_maincolor;
        }
        //----------------------------------------------------------
        //函式名稱: bt_picpath_Click
        //說明: 上傳新的主題圖片，注意需將picbox_theme.BackgroundImage作Dispose，否則Theme.jpg會被鎖定無法覆蓋。
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_picpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDg = new OpenFileDialog();
            openFileDg.Filter = "JPG檔案|*.jpg";  //儲存檔案篩選條件

            if (openFileDg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDg.OpenFile());
                try
                {
                    //先取消圖片的使用權
                    picbox_theme.BackgroundImage.Dispose(); 
                    picbox_theme.BackgroundImage = new Bitmap(@"Theme\\error.jpg");

                    //複製使用者選擇的圖片，第三個參數表示是否直接覆蓋
                    File.Copy(openFileDg.FileName, @"Theme\\Theme.jpg", true);
                    picbox_theme.BackgroundImage=new Bitmap(@"Theme\\Theme.jpg");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("複製圖片時發生錯誤!\n內部錯誤訊息：" + ex.Message);
                }
                finally
                {
                    openFileDg.Dispose();
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: cb_theme_SelectedIndexChanged
        //說明: 主題選擇下拉式選單改變
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void cb_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_theme.SelectedIndex)
            {
                case 0:
                    picbox_theme.BackgroundImage = new Bitmap( Theme_Def_Pic_Path );
                    CB_maincolor.SelectedItem = MainForm_BkColor_Def;
                    CB_maincolor.Enabled = false;
                    bt_picpath.Enabled = false;
                    break;
                case 1:
                    picbox_theme.BackgroundImage = new Bitmap( Theme_User_Pic_Path );
                    CB_maincolor.Enabled = true;
                    bt_picpath.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}