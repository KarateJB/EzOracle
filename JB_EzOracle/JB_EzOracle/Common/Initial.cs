#define MODIFYING
//#undef MODIFYING

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JB_EzOracleSQL.Common
{
    public class Initial
    {
        //----------------------------------------------------------
        //函式名稱: Get_Setup_Value
        //說明: 設定
        //參數: 無
        //回傳值: String
        //----------------------------------------------------------
        public static void Initial_MenuItems(ref List<MyClass.cMenuItem> MenuItemNameSet)
        {
            try
            {
                //主視窗功能列大項
                MenuItemNameSet.Add( new MyClass.cMenuItem("tsmi_lv1_001", "檔案", "") );
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv1_002", "編輯", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv1_003", "檢視", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv1_004", "SQL字體", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv1_005", "視窗大小", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv1_006", "說明", ""));

                //主視窗功能列大項[檔案]的小項目
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_1", "連線", "tsmi_1_1_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_2", "斷線", "tsmi_1_2_Click"));
                MenuItemNameSet.Add( new MyClass.cMenuItem("tss_lv2_001", "分隔線", "") );
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_5", "儲存SQL", "tsmi_1_5_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_6", "匯入SQL", "tsmi_1_6_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_4", "詳細設定", "tsmi_1_4_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tss_lv2_001", "分隔線", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_7", "關閉子視窗", "tsmi_1_7_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tss_lv2_001", "分隔線", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_001_3", "結束", "tsmi_1_3_Click"));

                //主視窗功能列大項[編輯]的小項目
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_002_1", "資料還原", ""));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv3_002_1_01", "Commit", "tsmi_lv2_002_1_01_Click", false));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv3_002_1_02", "Rollback", "tsmi_lv2_002_1_02_Click", false));

                //主視窗功能列大項[檢視]的小項目
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_003_1", "Table Schema", "tsmi_3_1_Click"));

                //主視窗功能列大項[SQL字體]的小項目
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_004_1", "大", "tsmi_4_1_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_004_2", "中", "tsmi_4_2_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_004_3", "小", "tsmi_4_3_Click"));

                //主視窗功能列大項[視窗大小]的小項目"
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_005_1", "一般", "tsmi_5_1_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_005_2", "放大", "tsmi_5_2_Click"));

                //主視窗功能列大項[說明]的小項目
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_006_1", "使用說明", "tsmi_6_1_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_006_2", "版本", "tsmi_6_2_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_006_3", "熱鍵查詢", "tsmi_6_3_Click"));
                MenuItemNameSet.Add( new MyClass.cMenuItem("tss_lv2_006", "分隔線", "") );
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_lv2_006_4", "Oracle語法查詢", "tsmi_5_4_Click"));


                //CLB_column 右鍵選單內容 : 複製
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_50", "複製", "tsmi_50_Click"));

                //RTB(RichTextBox)的右鍵選單
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_100", "執行選取SQL", "tsmi_100_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_101", "直接匯出 ...", "tsmi_101_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_102", "複製", "tsmi_102_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_103", "剪下", "tsmi_103_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_104", "貼上", "tsmi_104_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_105", "全部選取", "tsmi_105_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_106", "清除全部", "tsmi_106_Click"));

                //RTB(RichTextBox)的右鍵選單
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_ins", "新增", "tsmi_Get_Sql_BySelRow_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_del", "刪除", "tsmi_Get_Sql_BySelRow_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_upd", "更新", "tsmi_Get_Sql_BySelRow_Click"));

                //LB_tablename 右鍵選單
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_200", "複製", "tsmi_200_Click"));
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_201", "查詢", "tsmi_201_Click"));

                //tabControl 右鍵選單
                MenuItemNameSet.Add(new MyClass.cMenuItem("tsmi_closepage", "關閉", "tsmi_closepage_Click"));

            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! 原因：" + ex.Message);
            }
        }
    }
}
