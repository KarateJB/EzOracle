using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//----------------------------------------------------------
//函式名稱: iContextMenu 
//說明: Interface
//參數: 無
//回傳值: 無
//----------------------------------------------------------
interface iContextMenu
{
    //ToolStripMenuItem物件
    ToolStripMenuItem MenuItem { get; }
    //ToolStripMenuItem物件名稱
    string MenuName { get; set; }
    //ToolStripMenuItem顯示名稱
    string MenuDesc { get; set; }
    //ToolStripMenuItem對應事件
    EventHandler MenuHandler { get; set; }

    //建立與設定ToolStripMenuItem
    void Init_MenuItem(int InitCase);
}

//----------------------------------------------------------
//函式名稱: iSetup
//說明: Interface
//參數: 無
//回傳值: 無
//----------------------------------------------------------
interface iSetup
{
    //索引名稱
    String KeyName { get; set; }
    //格式
    int KeyType { get; set; }
    //字串
    String sValue { get; set; }
    //數字
    Int16 iValue { get; set; }
    //布林
    bool bValue { get; set; }

    //設定格式
    void SetType(String x);
    //設定值
    void SetValue(String x);
    //設定值
    void SetValue(Int16 x);
    //設定值
    void SetValue(bool x);
    //取得格式
    String GetType();
    //取得值
    String GetValue();
}
