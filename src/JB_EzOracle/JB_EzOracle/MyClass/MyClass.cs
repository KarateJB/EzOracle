using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class MyClass
{
    //----------------------------------------------------------
    //類別名稱: cMainMenu
    //說明: 右鍵選單
    //----------------------------------------------------------
    /*
    public class cMenuItemSet
    {
        public string itemName; //物件名稱
        public string itemText; //顯示名稱
        public int Level_Index;     //物件所屬階層
        public int Item_Index;      //物件序號
        public int Parent_Index; //母物件的序號
        public EventHandler eMenuHandler; //對應Click事件
    }
    */
    //----------------------------------------------------------
    //類別名稱: cMainMenu
    //說明: 右鍵選單
    //----------------------------------------------------------
    public class cMainMenu : iContextMenu
    {
        public int iLevel_Index;     //物件所屬階層
        public int iItem_Index;      //物件序號
        public int iParent_Index;  //母物件的序號

        private ToolStripMenuItem sMenuItem;
        private string sMenuName;
        private string sMenuDesc;
        private EventHandler eMenuHandler;

        public ToolStripMenuItem MenuItem
        {
            get { return sMenuItem; }
        }
        public string MenuName
        {
            get { return sMenuName; }
            set { this.MenuName = value; }
        }
        public string MenuDesc
        {
            get { return sMenuDesc; }
            set { this.MenuDesc = value; }
        }
        public EventHandler MenuHandler
        {
            get { return eMenuHandler; }
            set { this.eMenuHandler = value; }
        }

        /*建構子1 (不指定EventHandler ) */
        public cMainMenu(int new_Level_Index, int new_Item_Index, int new_Parent_Index,
            ToolStripMenuItem new_Item, string new_MenuName, string new_MenuDesc)
        {
            iLevel_Index = new_Level_Index;
            iItem_Index = new_Item_Index;
            iParent_Index = new_Parent_Index;
            sMenuItem = new_Item;
            sMenuName = new_MenuName;
            sMenuDesc = new_MenuDesc;
        }
        /* 建構子2 */
        public cMainMenu(int new_Level_Index, int new_Item_Index, int new_Parent_Index,
            ToolStripMenuItem new_Item, string new_MenuName, string new_MenuDesc, EventHandler new_MenuHandler)
        {
            iLevel_Index = new_Level_Index;
            iItem_Index = new_Item_Index;
            iParent_Index = new_Parent_Index;
            sMenuItem = new_Item;
            sMenuName = new_MenuName;
            sMenuDesc = new_MenuDesc;
            eMenuHandler = new_MenuHandler;
        }

        /*設定最上層的母選單，不用指定事件*/
        public void Init_MenuItem_lv1()
        {
            sMenuItem = new ToolStripMenuItem(sMenuDesc);
        }
        /*設定其它層的選單*/
        public void Init_MenuItem(int InitCase)
        {
            switch(InitCase)
            {
                case 0: //下層的子選單才有對應事件
                    sMenuItem = new ToolStripMenuItem(sMenuDesc, null);
                    break;
                case 1:  //該選單有對應事件
                    sMenuItem = new ToolStripMenuItem(sMenuDesc, null, new EventHandler(eMenuHandler));
                    break;
            }
        }
        
        /*解構子*/
        ~cMainMenu()
        {
            sMenuItem = null;
            sMenuName = "";
            sMenuDesc = "";
            eMenuHandler = null;
        }
    }

    //----------------------------------------------------------
    //類別名稱: cContextMenu
    //說明: 右鍵選單
    //----------------------------------------------------------
    public class cContextMenu : iContextMenu
    {
        private ToolStripMenuItem sMenuItem;
        private string sMenuName;
        private string sMenuDesc;
        private EventHandler eMenuHandler;

        public ToolStripMenuItem MenuItem
        {
            get { return sMenuItem; }
        }
        public string MenuName
        {
            get { return sMenuName; }
            set { this.MenuName = value; }
        }
        public string MenuDesc
        {
            get { return sMenuDesc; }
            set { this.MenuDesc = value; }
        }
        public EventHandler MenuHandler
        {
            get { return eMenuHandler; }
            set { this.eMenuHandler = value; }
        }

        /*建構子*/
        public cContextMenu(ToolStripMenuItem new_Item, string new_MenuName, string new_MenuDesc, EventHandler new_MenuHandler)
        {
            sMenuItem = new_Item;
            sMenuName = new_MenuName;
            sMenuDesc = new_MenuDesc;
            eMenuHandler = new_MenuHandler;
        }
        /*設定選單*/
        public void Init_MenuItem(int InitCase)
        {
            sMenuItem = new ToolStripMenuItem(sMenuDesc, null, new EventHandler(eMenuHandler));
        }
        /*解構子*/
        ~cContextMenu()
        {
            sMenuItem = null;
            sMenuName = "";
            sMenuDesc = "";
            eMenuHandler = null;
        }
    }

    //----------------------------------------------------------
    //類別名稱: cMainMenu_Sep
    //說明: 主選單的分隔線
    //----------------------------------------------------------
    public class cMainMenu_Sep : iContextMenu
    {
        public ToolStripSeparator sMenuSp;     //分隔線

        public int iLevel_Index;     //物件所屬階層
        public int iParent_Index;  //母物件的序號

        private ToolStripMenuItem sMenuItem;
        private string sMenuName;
        private string sMenuDesc;
        private EventHandler eMenuHandler;

        public ToolStripMenuItem MenuItem
        {
            get { return sMenuItem; }
        }
        public string MenuName
        {
            get { return sMenuName; }
            set { this.MenuName = value; }
        }
        public string MenuDesc
        {
            get { return sMenuDesc; }
            set { this.MenuDesc = value; }
        }
        public EventHandler MenuHandler
        {
            get { return eMenuHandler; }
            set { this.eMenuHandler = value; }
        }

        /*建構子*/
        public cMainMenu_Sep(int new_Level_Index, int new_Parent_Index, ToolStripSeparator new_MenuSp, string new_MenuName)
        {
            iLevel_Index = new_Level_Index;
            iParent_Index = new_Parent_Index;
            sMenuSp = new_MenuSp;
            sMenuName = new_MenuName;
        }
      
        /*設定選單*/
        public void Init_MenuItem(int InitCase)
        {
            //
        }

        /*解構子*/
        ~cMainMenu_Sep()
        {
            sMenuSp = null;
            sMenuItem = null;
            sMenuName = "";
            sMenuDesc = "";
            eMenuHandler = null;
        }
    }

    //----------------------------------------------------------
    //類別名稱: cSetup
    //說明: 儲存的使用者設定
    //----------------------------------------------------------
    public class cSetup : iSetup
    {
        private String sKeyName; //索引名稱
        private int iKeyType;           //格式
        private String strValue;      //字串
        private Int16  intValue;      //數字
        private bool boolValue;     //布林

        private enum enumType { String, Int, Bool };

        public string KeyName
        {
            get { return sKeyName; }
            set { this.sKeyName = value; }
        }
        public int KeyType
        {
            get { return iKeyType; }
            set { this.iKeyType = value; }
        }
        public string sValue
        {
            get { return strValue; }
            set { this.strValue = value; }
        }
        public Int16 iValue
        {
            get { return intValue; }
            set { this.intValue = value; }
        }
        public bool bValue
        {
            get { return boolValue; }
            set { this.boolValue = value; }
        }
        /*建構子*/
        public cSetup(String key_name)
        {
            sKeyName = key_name;
            iKeyType = 0; //預設型別為字串
        }
        //解構子
        ~cSetup()
        {

        }
        /*設定格式*/
        public void SetType(String MyType)
        {
            switch (MyType)
            {
                case "Bool":
                    iKeyType = (int)enumType.Bool;
                    break;
                case "Int":
                    iKeyType = (int)enumType.Int;
                    break;
                case "String":
                    iKeyType = (int)enumType.String;
                    break;
                default:
                    iKeyType = (int)enumType.String;
                    break;
            }
        }
        /*設定值*/
        public void SetValue(String MyValue)
        {
            strValue = MyValue;
        }
        /*設定值*/
        public void SetValue(bool MyValue)
        {
            boolValue = MyValue;
        }
        /*設定值*/
        public void SetValue(Int16 MyValue)
        {
            intValue = MyValue;
        }
        /*取得格式*/
        public String GetType()
        {
            switch (iKeyType)
            {
                case (int)enumType.Bool:
                    return "Bool";
                case (int)enumType.Int:
                    return "Int";
                case (int)enumType.String:
                    return "String";
                default:
                    return "";
            }
        }
        /*取得值*/
        public String GetValue()
        {
            switch (iKeyType)
            {
                case (int)enumType.Bool:
                    return boolValue.ToString();
                case (int)enumType.Int:
                    return intValue.ToString();
                case (int)enumType.String:
                    return strValue;
                default:
                    return "";
            }
        }
    }

    //----------------------------------------------------------
    //類別名稱: cMenuItem
    //說明: 儲存的使用者設定
    //----------------------------------------------------------
    public class cMenuItem
    {
        public String ItemID;
        public String ItemName;
        public String ItemEventHandler;
        public bool ItemEnabled;
        public cMenuItem(String sItemID, String sItemName, String sItemEventHandler)
        {
            ItemID = sItemID;
            ItemName = sItemName;
            ItemEventHandler = sItemEventHandler;
            ItemEnabled = true;
        }
        public cMenuItem(String sItemID, String sItemName, String sItemEventHandler, bool bItemEnabled)
        {
            ItemID = sItemID;
            ItemName = sItemName;
            ItemEventHandler = sItemEventHandler;
            ItemEnabled = bItemEnabled;
        }
    }

}

