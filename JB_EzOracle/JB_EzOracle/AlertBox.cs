#define MODIFYING
//#undef MODIFYING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JB_EzOracleSQL
{
    public partial class AlertBox : Form
    {
        public AlertBox()
        {
            InitializeComponent();
        }

        private void BT_ok_Click(object sender, EventArgs e)
        {
            //Release個人圖片的lock
            PicBox_theme.BackgroundImage.Dispose(); 
            //隱藏Form 
            this.Close();
        }

        private void AlertBox_Shown(object sender, EventArgs e)
        {
            MainForm form1 = (MainForm)this.Owner;

#if(MODIFYING)
            Int16 iTheme_index = Convert.ToInt16( Common.Setup.Get_Setup_Value(ref form1.userSetupList, "主題選擇") );
            switch (iTheme_index)
            {
                case 0:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\Theme_Spe.jpg");
                    break;
                case 1:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\Theme.jpg");
                    break;
                default:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\error.jpg");
                    break;
            }
#else
            switch (form1.Theme_index)
            {
                case 0:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\Bayonetta.jpg");
                    break;
                case 1:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\Theme.jpg");
                    break;
                default:
                    PicBox_theme.BackgroundImage = new Bitmap(@"Theme\\error.jpg");
                    break;
            }
#endif
            form1 = null;
        }
    }
}