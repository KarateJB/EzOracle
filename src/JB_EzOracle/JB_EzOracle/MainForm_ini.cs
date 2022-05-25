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
        /* 使用者設定List */
        public List<MyClass.cSetup> userSetupList = new List<MyClass.cSetup>();

        private RsltForm[] RsltFormSet = new RsltForm[0]; //結果視窗集合
        private Int32 RsltFormSet_inx; //結果視窗序號

        /* 選單集合 */
        private List<MyClass.cMenuItem> MenuItemNameSet = new List<MyClass.cMenuItem>(); //所有ToolStripMenuItem物件(ID,Name)

        /* 功能表 */
        private MenuStrip menustrip = new MenuStrip();

        /* 右鍵選單 */
        private ContextMenuStrip cmenustrip_01 = new ContextMenuStrip(); //for CLB_column
        private ContextMenuStrip cmenustrip_02_RTB = new ContextMenuStrip(); //for RichTextBox RTB
        private ContextMenuStrip cmenustrip_03 = new ContextMenuStrip(); //for dG_table
        private ContextMenuStrip cmenustrip_04 = new ContextMenuStrip(); //for LB_tablename
        private ContextMenuStrip cmenustrip_05 = new ContextMenuStrip(); //for TabControl

        /* Quick Load DB connect name and id/password */
        private string[][] QuickLoad = new string[0][];
        private Int32 timer_cnt;

        /* 可以做Commit & Rollback 的Transaction */
        private OracleTransaction transaction = null;

        /* 紀錄Transaction的SQL */
        private String transaction_Sql = "";

        //----------------------------------------------------------
        //函式名稱: Get_MenuItem_EventHandler
        //說明: 取得對應的EventHandler
        //參數: 事件名稱
        //回傳值: EventHandler
        //----------------------------------------------------------
        private EventHandler Get_MenuItem_EventHandler(String EventName)
        {
            switch (EventName)
            {
                case "tsmi_1_1_Click":
                    return tsmi_1_1_Click;
                case "tsmi_1_2_Click":
                    return tsmi_1_2_Click;
                case "tsmi_1_3_Click":
                    return tsmi_1_3_Click;
                case "tsmi_1_4_Click":
                    return tsmi_1_4_Click;
                case "tsmi_1_5_Click":
                    return tsmi_1_5_Click;
                case "tsmi_1_6_Click":
                    return tsmi_1_6_Click;
                case "tsmi_1_7_Click":
                    return tsmi_1_7_Click;
                case "tsmi_lv2_002_1_01_Click":
                    return tsmi_lv2_002_1_01_Click;
                case "tsmi_lv2_002_1_02_Click":
                    return tsmi_lv2_002_1_02_Click;
                case "tsmi_3_1_Click":
                    return tsmi_3_1_Click;
                case "tsmi_4_1_Click":
                    return tsmi_4_1_Click;
                case "tsmi_4_2_Click":
                    return tsmi_4_2_Click;
                case "tsmi_4_3_Click":
                    return tsmi_4_3_Click;
                case "tsmi_5_1_Click":
                    return tsmi_5_1_Click;
                case "tsmi_5_2_Click":
                    return tsmi_5_2_Click;
                case "tsmi_6_1_Click":
                    return tsmi_6_1_Click;
                case "tsmi_6_2_Click":
                    return tsmi_6_2_Click;
                case "tsmi_6_3_Click":
                    return tsmi_6_3_Click;
                case "tsmi_6_4_Click":
                    return tsmi_6_4_Click;
                case "tsmi_50_Click":
                    return tsmi_50_Click;
                case "tsmi_100_Click":
                    return tsmi_100_Click;
                case "tsmi_101_Click":
                    return tsmi_101_Click;
                case "tsmi_102_Click":
                    return tsmi_102_Click;
                case "tsmi_103_Click":
                    return tsmi_103_Click;
                case "tsmi_104_Click":
                    return tsmi_104_Click;
                case "tsmi_105_Click":
                    return tsmi_105_Click;
                case "tsmi_106_Click":
                    return tsmi_106_Click;
                case "tsmi_Get_Sql_BySelRow_Click":
                    return tsmi_Get_Sql_BySelRow_Click;
                case "tsmi_200_Click":
                    return tsmi_200_Click;
                case "tsmi_201_Click":
                    return tsmi_201_Click;
                case "tsmi_closepage_Click":
                    return tsmi_closepage_Click;

                default:
                    return null;
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetMenuStrip
        //說明: 工具列Initial
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetMenuStrip()
        {
            menustrip.BackColor = System.Drawing.Color.SeaShell;
            /*
            ToolStripMenuItem tsmi_1 = new ToolStripMenuItem("檔案");
            ToolStripMenuItem tsmi_2 = new ToolStripMenuItem("檢視");
            ToolStripMenuItem tsmi_3 = new ToolStripMenuItem("SQL字體");
            ToolStripMenuItem tsmi_4 = new ToolStripMenuItem("視窗大小");
            ToolStripMenuItem tsmi_5 = new ToolStripMenuItem("說明");

            menustrip.Items.Add(tsmi_1); //加入第一層
            menustrip.Items.Add(tsmi_2);
            menustrip.Items.Add(tsmi_3);
            menustrip.Items.Add(tsmi_4);
            menustrip.Items.Add(tsmi_5);

            ToolStripMenuItem tsmi_1_1 = new ToolStripMenuItem("連線", null, new EventHandler(tsmi_1_1_Click));
            ToolStripMenuItem tsmi_1_2 = new ToolStripMenuItem("斷線", null, new EventHandler(tsmi_1_2_Click));
            ToolStripMenuItem tsmi_1_3 = new ToolStripMenuItem("結束", null, new EventHandler(tsmi_1_3_Click));
            ToolStripMenuItem tsmi_1_4 = new ToolStripMenuItem("詳細設定", null, new EventHandler(tsmi_1_4_Click));
            ToolStripMenuItem tsmi_1_5 = new ToolStripMenuItem("儲存SQL", null, new EventHandler(tsmi_1_5_Click));
            ToolStripMenuItem tsmi_1_6 = new ToolStripMenuItem("匯入SQL", null, new EventHandler(tsmi_1_6_Click));
            ToolStripMenuItem tsmi_1_7 = new ToolStripMenuItem("關閉子視窗", null, new EventHandler(tsmi_1_7_Click));
            ToolStripMenuItem tsmi_2_1 = new ToolStripMenuItem("Table Schema", null, new EventHandler(tsmi_2_1_Click));
            ToolStripMenuItem tsmi_3_1 = new ToolStripMenuItem("大", null, new EventHandler(tsmi_3_1_Click));
            ToolStripMenuItem tsmi_3_2 = new ToolStripMenuItem("中", null, new EventHandler(tsmi_3_2_Click));
            ToolStripMenuItem tsmi_3_3 = new ToolStripMenuItem("小", null, new EventHandler(tsmi_3_3_Click));
            ToolStripMenuItem tsmi_4_1 = new ToolStripMenuItem("一般", null, new EventHandler(tsmi_4_1_Click));
            ToolStripMenuItem tsmi_4_2 = new ToolStripMenuItem("放大", null, new EventHandler(tsmi_4_2_Click));
            ToolStripMenuItem tsmi_5_1 = new ToolStripMenuItem("使用說明", null, new EventHandler(tsmi_5_1_Click));
            ToolStripMenuItem tsmi_5_2 = new ToolStripMenuItem("版本", null, new EventHandler(tsmi_5_2_Click));
            ToolStripMenuItem tsmi_5_3 = new ToolStripMenuItem("熱鍵查詢", null, new EventHandler(tsmi_5_3_Click));
            ToolStripMenuItem tsmi_5_4 = new ToolStripMenuItem("Oracle語法查詢", null, new EventHandler(tsmi_5_4_Click));
            ToolStripSeparator tss01 = new ToolStripSeparator(); //分隔線
            ToolStripSeparator tss02 = new ToolStripSeparator(); //分隔線
            ToolStripSeparator tss03 = new ToolStripSeparator(); //分隔線

            tsmi_1_2.Enabled = false; //檔案-斷線
            tsmi_4_1.Checked = true; //視窗大小-一般

            //方法一：使用ToolStripItem集合加入------------------------
            //ToolStripItem[] tsmi_set = new ToolStripItem[3];
            ToolStripItem[] tsmi_set = { tsmi_1_1, tsmi_1_2, tss01, tsmi_1_5, tsmi_1_6, tsmi_1_4,tss02, tsmi_1_7,tss03, tsmi_1_3 };
            tsmi_1.DropDownItems.AddRange(tsmi_set);
            tsmi_set = null;
            ToolStripItem[] tsmi_set3 = { tsmi_3_1, tsmi_3_2, tsmi_3_3};
            tsmi_3.DropDownItems.AddRange(tsmi_set3);
            tsmi_set3 = null;
            //方法二：直接加上去下拉式選單--------------
            tsmi_2.DropDownItems.Add(tsmi_2_1);
            tsmi_4.DropDownItems.Add(tsmi_4_1);tsmi_4.DropDownItems.Add(tsmi_4_2);
            tsmi_5.DropDownItems.Add(tsmi_5_1);tsmi_5.DropDownItems.Add(tsmi_5_2);
            tsmi_5.DropDownItems.Add(tsmi_5_3);tsmi_5.DropDownItems.Add(tsmi_5_4);

            menustrip.Dock = DockStyle.Top;
            menustrip.RenderMode = ToolStripRenderMode.System;
            this.MainMenuStrip = menustrip; //!!!設定表單主要功能表為menustrip。
            this.Controls.Add(menustrip);   //!!!加入表單容器。
            this.menustrip.ItemClicked += new ToolStripItemClickedEventHandler(this.menustrip_ItemClicked);//設定最上層CLICK事件。
            */
            IEnumerable<MyClass.cMenuItem> enum_MenuItem =
                from item in MenuItemNameSet
                where item.ItemID.StartsWith("tsmi_lv") || item.ItemID.StartsWith("tss")
                select item;

            foreach (MyClass.cMenuItem item in enum_MenuItem)
            {
                int iLevel = 0;      //物件所屬階層
                int[] iPos = null; //該物件及其母層的所有位置
                
                //int iParent_Index = 0;   //最上層母物件的序號
                //int iItem_Index = 0;       //物件序號


                /************************************************************************
                 * 從itemName去取得資訊  
                 ************************************************************************/
                string[] info = item.ItemID.Split('_');
                iLevel = Convert.ToInt16(info[1].Substring(2, 1)); //屬於第幾層

                try
                {
                    if (info.Length == 3 && info[0] == "tss") //分隔線
                    {
                        iPos = new int[2];
                        iPos[0] = 1; 
                        iPos[1] = Convert.ToInt16(info[2]);
                    }
                    else
                    {
                        iPos = new int[iLevel];
                        for (int i = 0; i < iLevel; i++)
                        {
                            int index = i + 2;
                            iPos[i] = Convert.ToInt16(info[index]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("錯誤! " + ex.Message);
                }


                /* 加入UI */
                if (item.ItemName == "分隔線")
                {
                    ToolStripSeparator tss = new ToolStripSeparator(); //分隔線
                    

                    switch (iLevel )
                    {
                        case 2:
                             int iParent_Index = iPos[0];   //最上層母物件的序號

                             MyClass.cMainMenu_Sep newMainMenu_Sep =
                                                                  new MyClass.cMainMenu_Sep(iLevel, iParent_Index, tss, item.ItemName);

                            ToolStripMenuItem ParentItem = (ToolStripMenuItem)menustrip.Items[(iParent_Index - 1)];
                            ParentItem.DropDownItems.Add(newMainMenu_Sep.sMenuSp);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    int iParent_Index = 0;
                    int iParent2_Index = 0;
                    int iItem_Index = 0;   //物件的序號

                    ToolStripMenuItem tsmi = new ToolStripMenuItem();
                    switch (iLevel )
                    {
                        case 1: /* 最上層 */
                            iParent_Index = 0;   //沒有最上層母物件
                            iItem_Index = iPos[0];   //物件的序號

                            MyClass.cMainMenu newMainMenu_lv1 =
                                new MyClass.cMainMenu(iLevel , iItem_Index, iParent_Index, tsmi, item.ItemID, item.ItemName);
                            newMainMenu_lv1.Init_MenuItem_lv1();
                            menustrip.Items.Add(newMainMenu_lv1.MenuItem);
                            break;

                        case 2: 
                            iParent_Index = iPos[0];   //最上層母物件
                            iItem_Index = iPos[1];   //物件的序號

                            EventHandler myEventHandler = Get_MenuItem_EventHandler(item.ItemEventHandler);

                            MyClass.cMainMenu newMainMenu_lv2 =
                                new MyClass.cMainMenu(iLevel , iItem_Index, iParent_Index, tsmi, item.ItemID, item.ItemName, myEventHandler);

                            if (myEventHandler!=null)
                                newMainMenu_lv2.Init_MenuItem(1); //該選單有對應事件
                            else
                                newMainMenu_lv2.Init_MenuItem(0); //下層的子選單才有對應事件

                            ToolStripMenuItem ParentItem = (ToolStripMenuItem)menustrip.Items[(iParent_Index - 1)];
                            ParentItem.DropDownItems.Add(newMainMenu_lv2.MenuItem);
                            //判斷是否Enabled
                            if (item.ItemEnabled == false)
                            {
                                ParentItem.DropDownItems[iItem_Index-1].Enabled = false;
                            }
                            break;

                        case 3:
                            iParent_Index = iPos[0];   
                            iParent2_Index = iPos[1];  
                            iItem_Index = iPos[2];   //物件的序號

                            EventHandler EventHandler_lv3 = Get_MenuItem_EventHandler(item.ItemEventHandler);

                            MyClass.cMainMenu newMainMenu_lv3 =
                                new MyClass.cMainMenu(iLevel , iItem_Index, iParent_Index, tsmi, item.ItemID, item.ItemName, EventHandler_lv3);

                            if (EventHandler_lv3 != null)
                                newMainMenu_lv3.Init_MenuItem(1); //該選單有對應事件
                            else
                                newMainMenu_lv3.Init_MenuItem(0); //下層的子選單才有對應事件

                            ToolStripMenuItem ParentItem_lv3 = (ToolStripMenuItem)menustrip.Items[(iParent_Index - 1)];
                            ToolStripMenuItem Item_lv3 = (ToolStripMenuItem)ParentItem_lv3.DropDownItems[iParent2_Index - 1];
                            Item_lv3.DropDownItems.Add(newMainMenu_lv3.MenuItem);
                            //判斷是否Enabled
                            if (item.ItemEnabled == false)
                            {
                                Item_lv3.DropDownItems[iItem_Index-1].Enabled = false;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            menustrip.Dock = DockStyle.Top;
            menustrip.RenderMode = ToolStripRenderMode.System;
            this.MainMenuStrip = menustrip; //!!!設定表單主要功能表為menustrip。
            this.Controls.Add(menustrip);   //!!!加入表單容器。
            this.menustrip.ItemClicked += new ToolStripItemClickedEventHandler(this.menustrip_ItemClicked);//設定最上層CLICK事件。
        }

        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_01
        //說明: CLB_column右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_01()
        {
            /*
            ToolStripMenuItem tsmi_50 = new ToolStripMenuItem("複製", null, new EventHandler(tsmi_50_Click));
            cmenustrip_01.Items.Add(tsmi_50);
            CLB_column.ContextMenuStrip = cmenustrip_01;
            */

            IEnumerable<MyClass.cMenuItem> enum_MenuItem =
                from item in MenuItemNameSet
                where item.ItemID.StartsWith("tsmi_50")
                select item;

            foreach (MyClass.cMenuItem item in enum_MenuItem)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();

                EventHandler myEventHandler = Get_MenuItem_EventHandler(item.ItemEventHandler);

                MyClass.cContextMenu newContextMenu =
                    new MyClass.cContextMenu(tsmi, item.ItemID, item.ItemName, myEventHandler);

                newContextMenu.Init_MenuItem(0);
                cmenustrip_01.Items.Add(newContextMenu.MenuItem);
            }

            //設定右鍵選單內容給CLB_column
            CLB_column.ContextMenuStrip = cmenustrip_01;
        }

        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_02
        //說明: RichTextBox右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_02()
        {
            /*
            ToolStripMenuItem tsmi_100 = new ToolStripMenuItem("執行選取SQL", null, new EventHandler(tsmi_100_Click));
            ToolStripMenuItem tsmi_101 = new ToolStripMenuItem("直接匯出 ...", null, new EventHandler(tsmi_101_Click));
            ToolStripMenuItem tsmi_102 = new ToolStripMenuItem("複製", null, new EventHandler(tsmi_102_Click));
            ToolStripMenuItem tsmi_103 = new ToolStripMenuItem("剪下", null, new EventHandler(tsmi_103_Click));
            ToolStripMenuItem tsmi_104 = new ToolStripMenuItem("貼上", null, new EventHandler(tsmi_104_Click));
            ToolStripMenuItem tsmi_105 = new ToolStripMenuItem("全部選取", null, new EventHandler(tsmi_105_Click));
            ToolStripMenuItem tsmi_106 = new ToolStripMenuItem("清除全部", null, new EventHandler(tsmi_106_Click));
            cmenustrip_02_RTB.Items.Add(tsmi_100); 
            cmenustrip_02_RTB.Items.Add(tsmi_101); 
            cmenustrip_02_RTB.Items.Add(tsmi_102);
            cmenustrip_02_RTB.Items.Add(tsmi_103); 
            cmenustrip_02_RTB.Items.Add(tsmi_104); 
            cmenustrip_02_RTB.Items.Add(tsmi_105);
            cmenustrip_02_RTB.Items.Add(tsmi_106);

            foreach (TabPage tp in tabControl.Controls)
            {
                RichTextBox rtb = (RichTextBox)tp.Controls[0];
                rtb.ContextMenuStrip = cmenustrip_02_RTB; //指定RTB(RichTextBox)的右鍵選單為cmenustrip_RTB
            }
            */

            IEnumerable<MyClass.cMenuItem> enum_MenuItem =
                from item in MenuItemNameSet
                where item.ItemID.StartsWith("tsmi_10")
                select item;

            foreach (MyClass.cMenuItem item in enum_MenuItem)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();

                EventHandler myEventHandler = Get_MenuItem_EventHandler(item.ItemEventHandler);

                MyClass.cContextMenu newContextMenu =
                    new MyClass.cContextMenu(tsmi, item.ItemID, item.ItemName, myEventHandler);

                newContextMenu.Init_MenuItem(0);
                cmenustrip_02_RTB.Items.Add(newContextMenu.MenuItem);
            }

            foreach (TabPage tp in tabControl.Controls)
            {
                RichTextBox rtb = (RichTextBox)tp.Controls[0];
                rtb.ContextMenuStrip = cmenustrip_02_RTB; //指定RTB(RichTextBox)的右鍵選單為cmenustrip_RTB
            }
        }


        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_03
        //說明: dataGridView右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_03()
        {
            /*
            ToolStripMenuItem tsmi_ins = new ToolStripMenuItem("新增", null, new EventHandler(tsmi_ins_Click));
            ToolStripMenuItem tsmi_del = new ToolStripMenuItem("刪除", null, new EventHandler(tsmi_del_Click));
            ToolStripMenuItem tsmi_upd = new ToolStripMenuItem("更新", null, new EventHandler(tsmi_upd_Click));
            cmenustrip_03.Items.Add(tsmi_ins);
            cmenustrip_03.Items.Add(tsmi_del);
            cmenustrip_03.Items.Add(tsmi_upd);

            foreach (TabPage tp in tabControl2.Controls)
            {
                DataGridView dg = (DataGridView)tp.Controls[0];
                dg.ContextMenuStrip = cmenustrip_03;
            }
            */
            IEnumerable<MyClass.cMenuItem> enum_MenuItem =
                from item in MenuItemNameSet
                where item.ItemID.Equals("tsmi_ins") || item.ItemID.Equals("tsmi_del") || item.ItemID.Equals("tsmi_upd")
                select item;

            foreach (MyClass.cMenuItem item in enum_MenuItem)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();

                EventHandler myEventHandler = Get_MenuItem_EventHandler(item.ItemEventHandler);

                MyClass.cContextMenu newContextMenu =
                    new MyClass.cContextMenu(tsmi, item.ItemID, item.ItemName, myEventHandler);

                newContextMenu.Init_MenuItem(0);
                cmenustrip_03.Items.Add(newContextMenu.MenuItem);
            }

            foreach (TabPage tp in tabControl2.Controls)
            {
                DataGridView dg = (DataGridView)tp.Controls[0];
                dg.ContextMenuStrip = cmenustrip_03;
            }
        }

        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_04
        //說明: LB_tablename右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_04()
        {
            /*
            ToolStripMenuItem tsmi_200 = new ToolStripMenuItem("複製", null, new EventHandler(tsmi_200_Click));
            ToolStripMenuItem tsmi_201 = new ToolStripMenuItem("查詢", null, new EventHandler(tsmi_201_Click)); 
            cmenustrip_04.Items.Add(tsmi_200);
            cmenustrip_04.Items.Add(tsmi_201);
            LB_tablename.ContextMenuStrip = cmenustrip_04;
            */
            IEnumerable<MyClass.cMenuItem> enum_MenuItem =
                from item in MenuItemNameSet
                where item.ItemID.StartsWith("tsmi_20")
                select item;

            foreach (MyClass.cMenuItem item in enum_MenuItem)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();

                EventHandler myEventHandler = Get_MenuItem_EventHandler(item.ItemEventHandler);

                MyClass.cContextMenu newContextMenu =
                    new MyClass.cContextMenu(tsmi, item.ItemID, item.ItemName, myEventHandler);
                newContextMenu.Init_MenuItem(0);
                cmenustrip_04.Items.Add(newContextMenu.MenuItem);
            }

            //設定右鍵選單給LB_tablename
            LB_tablename.ContextMenuStrip = cmenustrip_04;
        }
        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_05
        //說明: TabControl右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_05()
        {
            ToolStripMenuItem tsmi_closepage = new ToolStripMenuItem("關閉", null, new EventHandler(tsmi_closepage_Click));
            cmenustrip_05.Items.Add(tsmi_closepage);
            tabControl.ContextMenuStrip = cmenustrip_05;
        }

    }
}
