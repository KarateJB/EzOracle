using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JB_EzOracleSQL
{
    public partial class ConstraintForm : Form
    {
        public ConstraintForm()
        {
            InitializeComponent();
            DG_constraint.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DG_pkey.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //----------------------------------------------------------
        //函式名稱: BT_adjust_Click
        //說明: DataGrid自動調整欄寬
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_adjust_Click(object sender, EventArgs e)
        {
            DG_pkey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DG_constraint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //----------------------------------------------------------
        //函式名稱: ConstraintForm_Resize
        //說明: 隨視窗大小改變DataGrid大小
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void ConstraintForm_Resize(object sender, EventArgs e)
        {
            DG_pkey.Width = this.Width - 65;
            DG_constraint.Width = this.Width - 65;
            DG_constraint.Height = this.Height - 320;
        }

        //----------------------------------------------------------
        //函式名稱: BT_close_Click
        //說明: 關閉視窗
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void BT_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}