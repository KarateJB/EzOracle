using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;

namespace JB_EzOracleSQL.Common
{
    public class Setup
    {
        //----------------------------------------------------------
        //函式名稱: Init_SetupList
        //說明: 取得奇數列背景顏色
        //參數: int
        //回傳值: Color
        //----------------------------------------------------------
        public static bool Init_SetupList(ref List<MyClass.cSetup> userSetupList)
        {
            try
            {
                userSetupList.Add(new MyClass.cSetup("列出所有表格"));
                userSetupList.Add(new MyClass.cSetup("開啟音效"));
                userSetupList.Add(new MyClass.cSetup("主題選擇"));
                userSetupList.Add(new MyClass.cSetup("背景顏色"));
                userSetupList.Add(new MyClass.cSetup("查詢結果自動寬度"));
                userSetupList.Add(new MyClass.cSetup("查詢結果單數行底色"));
                userSetupList.Add(new MyClass.cSetup("查詢結果字體大小"));
                userSetupList.Add(new MyClass.cSetup("查詢結果於新視窗"));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! 無法初始化userSetupList, 原因："+ex.Message);
                return false;
            }
        }

        //----------------------------------------------------------
        //函式名稱: GetMySteup
        //說明: 取得使用者儲存的設定值
        //參數: 無
        //回傳值: bool 
        //----------------------------------------------------------
        public static bool GetMySteup(String SetupFileName, ref List<MyClass.cSetup> userSetupList)
        {
            try
            {
                if (File.Exists(SetupFileName))
                {
                    StreamReader sr = new StreamReader(SetupFileName, Encoding.Default);


                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        if (str == "") continue; //若為空白行則跳過

                        //設定標題
                        string title = str.Substring(0, str.IndexOf('='));
                        //對應值
                        string value = str.Substring(str.IndexOf('=') + 1, str.Length - str.IndexOf('=') - 1);

                        //取得該設定標題對應的cSetup物件
                        MyClass.cSetup dic = (from x in userSetupList
                                              where x.KeyName == title
                                              select x).SingleOrDefault();
                        switch (title)
                        {
                            case "列出所有表格":
                            case "開啟音效":
                            case "查詢結果於新視窗":
                                dic.SetType("Bool");
                                dic.SetValue(value == "True" ? true : false);
                                break;
                            case "主題選擇":
                            case "背景顏色":
                            case "查詢結果自動寬度":
                            case "查詢結果字體大小":
                            case "查詢結果單數行底色":
                                dic.SetType("Int");
                                dic.SetValue(Convert.ToInt16(value));
                                break;
                            default:
                                dic.SetType("String");
                                dic.SetValue(value);
                                break;
                        }
                    }
                    sr.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! GetMySteup(), 原因：" + ex.Message);
                return false;
            }
        }

        //----------------------------------------------------------
        //函式名稱: Get_Setup_Value
        //說明: 設定
        //參數: 無
        //回傳值: String
        //----------------------------------------------------------
        public static String Get_Setup_Value(ref List<MyClass.cSetup> setupList, String sKeyName)
        {
            MyClass.cSetup setup = null;
            try
            {
                setup = (from x in setupList
                         where x.KeyName == sKeyName
                         select x).SingleOrDefault();

                if (setup == null)
                {
                    return "";
                }
                else
                {
                    return setup.GetValue();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("錯誤! 無法取得設定，原因：" + ex.Message);
                return "";
            }
        }
    }
}
