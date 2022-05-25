using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; //!!! Process
using System.IO;

namespace JB_EzOracleSQL.Common
{
    public class RegularFuc
    {
        //----------------------------------------------------------
        //函式名稱: Get_AutoSizeColumnsMode
        //說明: 取得DataGrid欄位自動寬度
        //參數: int
        //回傳值: DataGridViewAutoSizeColumnsMode
        //----------------------------------------------------------
        public static DataGridViewAutoSizeColumnsMode Get_AutoSizeColumnsMode(int FLG)
        {
            switch (FLG)
            {
                case 0:
                    return DataGridViewAutoSizeColumnsMode.None;
                case 1:
                    return DataGridViewAutoSizeColumnsMode.AllCells;
                case 2:
                    return DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                case 3:
                    return DataGridViewAutoSizeColumnsMode.ColumnHeader;
                case 4:
                    return DataGridViewAutoSizeColumnsMode.DisplayedCells;
                case 5:
                    return DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                default:
                    return DataGridViewAutoSizeColumnsMode.None;
            }
        }
        //----------------------------------------------------------
        //函式名稱: Get_AutoSizeColumnsMode
        //說明: 取得奇數列背景顏色
        //參數: int
        //回傳值: Color
        //----------------------------------------------------------
        public static Color Get_CellBackColor(int FLG)
        {
            switch (FLG) //使用者設定奇數列底色
            {
                case 0:
                    return Color.LightPink; 
                case 1:
                    return Color.LightGray;
                case 2:
                    return Color.LightSteelBlue;
                case 3:
                   return Color.Yellow;
                case 4:
                    return Color.LightGreen;
                default:
                    return Color.LightPink;
            }
        }

        //----------------------------------------------------------
        //函式名稱:Paint_The_Excel
        //說明: 把DataTable的資料放到Excel
        //參數: DataTable
        //回傳值: 錯誤訊息
        //----------------------------------------------------------
        public static string Paint_The_Excel(DataTable export_tb)
        {
            //引用Excel Application類別
            Excel.Application myExcel = new Excel.Application();
            //引用活頁簿類別 
            Excel.Workbook myBook = null;
            //引用工作表類別
            Excel.Worksheet mySheet = null;

            if (myExcel == null)
            {
                return "請檢查本機是否有安裝Microsoft Office Excel!";
            }
            myExcel.DisplayAlerts = false; //停用警告訊息
            myExcel.ShowToolTips = false; //停用工具提示
            myExcel.Visible = false; //隱藏Excel文件，不顯示過程

            try
            {
                myExcel.Workbooks.Add(true);
                //引用第一個活頁簿
                myBook = myExcel.Workbooks[1];
                //引用第一個工作表
                mySheet = (Excel.Worksheet)myBook.Worksheets[1];

                Excel.Range myRange; //合併儲存格範圍

                //匯出欄位
                for (int i = 0; i < export_tb.Columns.Count; i++)
                {
                    mySheet.Cells[1, i + 1] = export_tb.Columns[i].Caption.ToString();
                }
                //匯出資料
                for (int i = 0; i < export_tb.Rows.Count; i++)
                {
                    for (int j = 0; j < export_tb.Columns.Count; j++)
                    {
                        mySheet.Cells[i + 2, j + 1] = export_tb.Rows[i].ItemArray[j].ToString();
                    }
                }
                //設定EXCEL相關格式-----------------------------------------------------------------------------
                //含欄位和資料的範圍
                myRange = mySheet.Cells.get_Range(mySheet.Cells[1, 1], mySheet.Cells[export_tb.Rows.Count + 1, export_tb.Columns.Count]);
                myRange.VerticalAlignment = Excel.Constants.xlCenter; //儲存格格式置中
                myRange.HorizontalAlignment = Excel.Constants.xlCenter; //儲存格格式置中
                myRange.WrapText = true; //文繞圖
                myRange.Columns.AutoFit(); //自動調整寬度
                myRange.Borders.ColorIndex = -4105; //框線:黑色

                //只含資料的範圍
                myRange = mySheet.Cells.get_Range(mySheet.Cells[2, 1], mySheet.Cells[export_tb.Rows.Count + 1, export_tb.Columns.Count]);
                myRange.NumberFormatLocal = "0";

                //設定Excel格式
                mySheet.Application.ActiveWindow.Zoom = 80; //縮放比例

                //預覽列印部份
                mySheet.PageSetup.Zoom = 80;
                //mySheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                //mySheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                //設成縮放比例為1頁
                mySheet.PageSetup.FitToPagesWide = 1;
                mySheet.PageSetup.FitToPagesTall = 1;

                myBook.Application.StatusBar = "就緒";
                myExcel.Visible = true;
                export_tb = null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        //----------------------------------------------------------
        //函式名稱:Paint_The_Excel
        //說明: 把DataTable的資料放到Excel
        //參數: DataTable
        //回傳值: 錯誤訊息
        //----------------------------------------------------------
        public static string Paint_The_Excel(DataTable export_tb, int [] Format_Chosen_index)
        {
            //引用Excel Application類別
            Excel.Application myExcel = new Excel.Application();
            //引用活頁簿類別 
            Excel.Workbook myBook = null;
            //引用工作表類別
            Excel.Worksheet mySheet = null;

            if (myExcel == null)
            {
                return "請檢查本機是否有安裝Microsoft Office Excel!";
            }
            myExcel.DisplayAlerts = false; //停用警告訊息
            myExcel.ShowToolTips = false; //停用工具提示
            myExcel.Visible = false; //隱藏Excel文件，不顯示過程

            try
            {
                myExcel.Workbooks.Add(true);
                //引用第一個活頁簿
                myBook = myExcel.Workbooks[1];
                //引用第一個工作表
                mySheet = (Excel.Worksheet)myBook.Worksheets[1];

                Excel.Range myRange; //合併儲存格範圍

                //匯出欄位
                for (int i = 0; i < export_tb.Columns.Count; i++)
                {
                    mySheet.Cells[1, i + 1] = export_tb.Columns[i].Caption.ToString();
                }
                //匯出資料
                for (int i = 0; i < export_tb.Rows.Count; i++)
                {
                    for (int j = 0; j < export_tb.Columns.Count; j++)
                    {
                        //判斷此欄位是否顯示為文字格式---------------------------
                        bool Format_Chosen = false;
                        for (int k = 0; k < Format_Chosen_index.Length; k++)
                        {
                            if (j == Format_Chosen_index[k])
                            {
                                Format_Chosen = true;
                            }
                        }

                        if (Format_Chosen==true)
                            mySheet.Cells[i + 2, j + 1] = "'"+export_tb.Rows[i].ItemArray[j].ToString();
                        else
                            mySheet.Cells[i + 2, j + 1] = export_tb.Rows[i].ItemArray[j].ToString();
                    }
                }
                //設定EXCEL相關格式-----------------------------------------------------------------------------
                //含欄位和資料的範圍
                myRange = mySheet.Cells.get_Range(mySheet.Cells[1, 1], mySheet.Cells[export_tb.Rows.Count + 1, export_tb.Columns.Count]);
                myRange.VerticalAlignment = Excel.Constants.xlCenter; //儲存格格式置中
                myRange.HorizontalAlignment = Excel.Constants.xlCenter; //儲存格格式置中
                myRange.WrapText = true; //文繞圖
                myRange.Columns.AutoFit(); //自動調整寬度
                myRange.Borders.ColorIndex = -4105; //框線:黑色

                //只含資料的範圍
                myRange = mySheet.Cells.get_Range(mySheet.Cells[2, 1], mySheet.Cells[export_tb.Rows.Count + 1, export_tb.Columns.Count]);
                myRange.NumberFormatLocal = "0";

                //設定Excel格式
                mySheet.Application.ActiveWindow.Zoom = 80; //縮放比例

                //預覽列印部份
                mySheet.PageSetup.Zoom = 80;
                //mySheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                //mySheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                //設成縮放比例為1頁
                mySheet.PageSetup.FitToPagesWide = 1;
                mySheet.PageSetup.FitToPagesTall = 1;

                myBook.Application.StatusBar = "就緒";
                myExcel.Visible = true;
                export_tb = null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        //----------------------------------------------------------
        //函式名稱:Write_The_Text
        //說明: 把DataTable的資料放到Text
        //參數: DataTable, 存檔路徑
        //回傳值: 錯誤訊息
        //----------------------------------------------------------
        public static string Write_The_Text(DataTable export_tb,string export_path)
        {
            StreamWriter sw = new StreamWriter(export_path, false, System.Text.Encoding.Default);
            try
            {
                //欄位
                string str_col = "";
                for (int i = 0; i < export_tb.Columns.Count; i++)
                {
                    if (i == (export_tb.Columns.Count - 1))
                    {
                        str_col += export_tb.Columns[i].Caption.ToString();
                    }
                    else
                    {
                        str_col += export_tb.Columns[i].Caption.ToString() + ",";
                    }
                }
                sw.WriteLine(str_col);
                //資料
                for (int x = 0; x < export_tb.Rows.Count; x++)
                {
                    string str_data = "";
                    for (int i = 0; i < export_tb.Columns.Count; i++)
                    {
                        if (i == (export_tb.Columns.Count - 1))
                        {
                            str_data += export_tb.Rows[x].ItemArray[i].ToString();
                        }
                        else
                        {
                            str_data += export_tb.Rows[x].ItemArray[i].ToString() + ",";
                        }
                    }
                    sw.WriteLine(str_data);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sw.Close();
                export_tb = null;
            }
            return "";
        }
         //----------------------------------------------------------
        //函式名稱:Cal_SQL_Count
        //說明: 計算查詢的筆數
        //參數: string User_Sql
        //回傳值: double
        //----------------------------------------------------------
        public static double Cal_SQL_Count(string User_Sql)
        {
            double my_cnt = 0;
            string Cnt_Sql = "SELECT COUNT(1) AS CNT FROM (" + User_Sql + ")";
            DataTable Cnt_dt = Common.DBModule.DB_ExecQuery(Cnt_Sql);
            if (Cnt_dt != null)
            {
                if (Cnt_dt.Columns[0].Caption != "錯誤訊息")
                {
                    my_cnt=Convert.ToDouble(Cnt_dt.Rows[0].ItemArray[0].ToString()); //筆數
                }
            }
            return my_cnt;
        }

        //----------------------------------------------------------
        //函式名稱:Get_Sql_BySelRow
        //說明: 從DataGridView 取得INSERT or DELETE or UPDATE的語法
        //參數: iCaseID (1:新增, 2:刪除, 3:更新) , sTableName, DataGridView
        //回傳值: double
        //----------------------------------------------------------
        public static String Get_Sql_BySelRow( int iCaseID, String sTableName, ref DataGridView dg )
        {
            String sRslt = "";
            switch (iCaseID)
            {
                case 1:
                    try
                    {
                        if (dg.SelectedCells[0].Value.ToString() != null)
                        {
                            //先取出目前使用者選取哪一列資料...
                            int selIndex = dg.SelectedCells[0].OwningRow.Index;
                            //若使用dg.SelectedRows[0].Index會有BUG

                            int iColCnt = dg.Columns.Count;
                            StringBuilder sInserSql = new StringBuilder(10 * iColCnt);
                            String sEndStr = ",\n"; //結束換行
                            decimal t;

                            for (int i = 0; i < iColCnt; i++)
                            {
                                //欄位值
                                string col_value = dg.Rows[selIndex].Cells[i].Value.ToString();

                                if (col_value.Length == 0 || col_value == null)
                                {
                                    sInserSql.Append("NULL");
                                } //空值
                                else if (
                                    decimal.TryParse(col_value, out t) == true  //數值，利用 "型態.TryParse(值, out xxx)" : 回傳BOOL，且xxx為型態轉換後的值。
                                    &&
                                    !(col_value.Substring(0, 1) == "0" && col_value.Length > 1) //'0123'這種不要讓它算數值
                                    )
                                {
                                    sInserSql.Append(col_value);
                                }
                                else
                                {
                                    sInserSql.Append("'");
                                    sInserSql.Append(col_value);
                                    sInserSql.Append("'");
                                }
                                sInserSql.Append(sEndStr);
                            }
                            sInserSql.Remove(sInserSql.Length - sEndStr.Length, sEndStr.Length);                            

                            sRslt = "INSERT INTO " + sTableName + "\n" +
                                        "VALUES ( \n" +
                                            sInserSql.ToString() +
                                        "\n)";

                            sInserSql.Clear();
                            sInserSql = null;
                        }

                        return sRslt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("無法產生新增指令，原因：" + ex.Message);
                        return "";
                    }
                case 2:
                    try
                    {
                        if (dg.SelectedCells[0].Value.ToString() != null)
                        {
                            int selIndex = dg.SelectedCells[0].OwningRow.Index;//目前選取資料列的index

                            int iColCnt = dg.Columns.Count;
                            StringBuilder sDelSql = new StringBuilder(10 * iColCnt);
                            decimal t;

                            for (int i = 0; i < iColCnt; i++)
                            {
                                string col_value = dg.Rows[selIndex].Cells[i].Value.ToString();

                                if (i == 0)
                                {
                                    sDelSql.Append("\n");
                                    sDelSql.Append(dg.Columns[i].Name.ToString());
                                }
                                else
                                {
                                    sDelSql.Append("\nAND ");
                                    sDelSql.Append(dg.Columns[i].Name.ToString());
                                }

                                if (col_value.Length == 0) //空值
                                {
                                    sDelSql.Append(@" =""");
                                }
                                else if (col_value == null)
                                {
                                    sDelSql.Append(" IS NULL");
                                }
                                else if (
                                    decimal.TryParse(col_value, out t) == true
                                    &&
                                    !(col_value.Substring(0, 1) == "0" && col_value.Length > 1) //'0123'這種不要讓它算數值
                                    )
                                {
                                    sDelSql.Append(" = ");
                                    sDelSql.Append(col_value);
                                }
                                else
                                {
                                    sDelSql.Append("='");
                                    sDelSql.Append(col_value);
                                    sDelSql.Append("'");
                                }
                            }

                            sRslt = "DELETE FROM " + sTableName+ "\nWHERE" + sDelSql.ToString();
                            sDelSql.Clear();
                            sDelSql = null;
                        }

                        return sRslt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("無法產生刪除指令，原因：" + ex.Message);
                        return "";
                    }

                case 3:
                    try
                    {
                        if (dg.SelectedCells[0].Value.ToString() != null)
                        {
                            int iColCnt = dg.Columns.Count; //欄位數
                            int selIndex = dg.SelectedCells[0].OwningRow.Index;
                            StringBuilder sUptSql01 = new StringBuilder(10 * iColCnt); //設值Sql
                            StringBuilder sUptSql02 = new StringBuilder(10 * iColCnt); //條件Sql
                            decimal t;


                            for (int i = 0; i < iColCnt; i++)
                            {
                                sUptSql01.Append("\n");
                                sUptSql01.Append(dg.Columns[i].Name.ToString());
                                sUptSql01.Append(" = ,");

                                if (i == 0)
                                {
                                    sUptSql02.Append("\n");
                                    sUptSql02.Append(dg.Columns[i].Name.ToString());
                                }
                                else
                                {
                                    sUptSql02.Append("\nAND ");
                                    sUptSql02.Append(dg.Columns[i].Name.ToString());
                                }

                                string col_value = dg.Rows[selIndex].Cells[i].Value.ToString();
                                if (col_value.Length == 0) //空值
                                {
                                    sUptSql02.Append(@" = """);
                                }
                                else if (col_value == null)
                                {
                                    sUptSql02.Append(" IS NULL");
                                }
                                else if (decimal.TryParse(col_value, out t) == true
                                    &&
                                    !(col_value.Substring(0, 1) == "0" && col_value.Length > 1) //'0123'這種不要讓它算數值
                                    )
                                {
                                    sUptSql02.Append(" = " + col_value);
                                }
                                else
                                {
                                    sUptSql02.Append("='" + col_value + "'");
                                }
                            }
                            sUptSql01.Remove((sUptSql01.Length - 1), 1);
                            sRslt = "UPDATE " + sTableName + "\nSET " + sUptSql01.ToString() + "\nWHERE" + sUptSql02.ToString();
                            sUptSql01.Clear();
                            sUptSql02.Clear();
                            sUptSql01 = null;
                            sUptSql02 = null;
                        }

                        return sRslt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("無法產生更新指令，原因：" + ex.Message);
                        return "";
                    }
                default:
                    return "";
            }
        }
    }
}
