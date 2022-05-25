namespace JB_EzOracleSQL
{
    partial class SetupForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.BT_ok = new System.Windows.Forms.Button();
            this.GB_other = new System.Windows.Forms.GroupBox();
            this.CB_music = new System.Windows.Forms.CheckBox();
            this.CB_alltables = new System.Windows.Forms.CheckBox();
            this.GB_rslt = new System.Windows.Forms.GroupBox();
            this.RB_rslt_small = new System.Windows.Forms.RadioButton();
            this.RB_rslt_mid = new System.Windows.Forms.RadioButton();
            this.RB_rslt_big = new System.Windows.Forms.RadioButton();
            this.LB_rslt_wordsize = new System.Windows.Forms.Label();
            this.CB_ShowRsltForm = new System.Windows.Forms.CheckBox();
            this.CB_backcolor = new System.Windows.Forms.ComboBox();
            this.LB_02 = new System.Windows.Forms.Label();
            this.CB_cellAutoWidth = new System.Windows.Forms.ComboBox();
            this.LB_01 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picbox_theme = new System.Windows.Forms.PictureBox();
            this.CB_maincolor = new System.Windows.Forms.ComboBox();
            this.lb_maincolor = new System.Windows.Forms.Label();
            this.bt_picpath = new System.Windows.Forms.Button();
            this.lb_theme = new System.Windows.Forms.Label();
            this.lb_mainpic = new System.Windows.Forms.Label();
            this.CB_theme = new System.Windows.Forms.ComboBox();
            this.GB_other.SuspendLayout();
            this.GB_rslt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_theme)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ok
            // 
            this.BT_ok.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_ok.Location = new System.Drawing.Point(170, 375);
            this.BT_ok.Name = "BT_ok";
            this.BT_ok.Size = new System.Drawing.Size(75, 33);
            this.BT_ok.TabIndex = 1;
            this.BT_ok.Text = "確定";
            this.BT_ok.UseVisualStyleBackColor = true;
            this.BT_ok.Click += new System.EventHandler(this.BT_ok_Click);
            // 
            // GB_other
            // 
            this.GB_other.BackColor = System.Drawing.Color.LightYellow;
            this.GB_other.Controls.Add(this.CB_music);
            this.GB_other.Controls.Add(this.CB_alltables);
            this.GB_other.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_other.Location = new System.Drawing.Point(29, 23);
            this.GB_other.Name = "GB_other";
            this.GB_other.Size = new System.Drawing.Size(346, 91);
            this.GB_other.TabIndex = 4;
            this.GB_other.TabStop = false;
            this.GB_other.Text = "主要設定";
            // 
            // CB_music
            // 
            this.CB_music.AutoSize = true;
            this.CB_music.Checked = true;
            this.CB_music.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_music.Location = new System.Drawing.Point(16, 56);
            this.CB_music.Name = "CB_music";
            this.CB_music.Size = new System.Drawing.Size(75, 20);
            this.CB_music.TabIndex = 4;
            this.CB_music.Text = "開啟音效";
            this.CB_music.UseVisualStyleBackColor = true;
            // 
            // CB_alltables
            // 
            this.CB_alltables.AutoSize = true;
            this.CB_alltables.Location = new System.Drawing.Point(15, 30);
            this.CB_alltables.Name = "CB_alltables";
            this.CB_alltables.Size = new System.Drawing.Size(241, 20);
            this.CB_alltables.TabIndex = 3;
            this.CB_alltables.Text = "連線時自動列出所有可Select的表格名稱";
            this.CB_alltables.UseVisualStyleBackColor = true;
            // 
            // GB_rslt
            // 
            this.GB_rslt.BackColor = System.Drawing.Color.LightYellow;
            this.GB_rslt.Controls.Add(this.RB_rslt_small);
            this.GB_rslt.Controls.Add(this.RB_rslt_mid);
            this.GB_rslt.Controls.Add(this.RB_rslt_big);
            this.GB_rslt.Controls.Add(this.LB_rslt_wordsize);
            this.GB_rslt.Controls.Add(this.CB_ShowRsltForm);
            this.GB_rslt.Controls.Add(this.CB_backcolor);
            this.GB_rslt.Controls.Add(this.LB_02);
            this.GB_rslt.Controls.Add(this.CB_cellAutoWidth);
            this.GB_rslt.Controls.Add(this.LB_01);
            this.GB_rslt.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_rslt.Location = new System.Drawing.Point(29, 123);
            this.GB_rslt.Name = "GB_rslt";
            this.GB_rslt.Size = new System.Drawing.Size(346, 135);
            this.GB_rslt.TabIndex = 5;
            this.GB_rslt.TabStop = false;
            this.GB_rslt.Text = "查詢結果顯示區";
            // 
            // RB_rslt_small
            // 
            this.RB_rslt_small.AutoSize = true;
            this.RB_rslt_small.Location = new System.Drawing.Point(170, 24);
            this.RB_rslt_small.Name = "RB_rslt_small";
            this.RB_rslt_small.Size = new System.Drawing.Size(38, 20);
            this.RB_rslt_small.TabIndex = 8;
            this.RB_rslt_small.Text = "小";
            this.RB_rslt_small.UseVisualStyleBackColor = true;
            // 
            // RB_rslt_mid
            // 
            this.RB_rslt_mid.AutoSize = true;
            this.RB_rslt_mid.Checked = true;
            this.RB_rslt_mid.Location = new System.Drawing.Point(126, 24);
            this.RB_rslt_mid.Name = "RB_rslt_mid";
            this.RB_rslt_mid.Size = new System.Drawing.Size(38, 20);
            this.RB_rslt_mid.TabIndex = 7;
            this.RB_rslt_mid.TabStop = true;
            this.RB_rslt_mid.Text = "中";
            this.RB_rslt_mid.UseVisualStyleBackColor = true;
            // 
            // RB_rslt_big
            // 
            this.RB_rslt_big.AutoSize = true;
            this.RB_rslt_big.Location = new System.Drawing.Point(82, 24);
            this.RB_rslt_big.Name = "RB_rslt_big";
            this.RB_rslt_big.Size = new System.Drawing.Size(38, 20);
            this.RB_rslt_big.TabIndex = 6;
            this.RB_rslt_big.Text = "大";
            this.RB_rslt_big.UseVisualStyleBackColor = true;
            // 
            // LB_rslt_wordsize
            // 
            this.LB_rslt_wordsize.AutoSize = true;
            this.LB_rslt_wordsize.Location = new System.Drawing.Point(13, 26);
            this.LB_rslt_wordsize.Name = "LB_rslt_wordsize";
            this.LB_rslt_wordsize.Size = new System.Drawing.Size(68, 16);
            this.LB_rslt_wordsize.TabIndex = 5;
            this.LB_rslt_wordsize.Text = "字體大小：";
            // 
            // CB_ShowRsltForm
            // 
            this.CB_ShowRsltForm.AutoSize = true;
            this.CB_ShowRsltForm.Location = new System.Drawing.Point(16, 50);
            this.CB_ShowRsltForm.Name = "CB_ShowRsltForm";
            this.CB_ShowRsltForm.Size = new System.Drawing.Size(123, 20);
            this.CB_ShowRsltForm.TabIndex = 4;
            this.CB_ShowRsltForm.Text = "查詢結果於新視窗";
            this.CB_ShowRsltForm.UseVisualStyleBackColor = true;
            // 
            // CB_backcolor
            // 
            this.CB_backcolor.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_backcolor.ForeColor = System.Drawing.Color.Black;
            this.CB_backcolor.FormattingEnabled = true;
            this.CB_backcolor.Items.AddRange(new object[] {
            "粉紅(預設)",
            "灰色",
            "粉藍",
            "輕黃",
            "青綠"});
            this.CB_backcolor.Location = new System.Drawing.Point(93, 98);
            this.CB_backcolor.Name = "CB_backcolor";
            this.CB_backcolor.Size = new System.Drawing.Size(95, 23);
            this.CB_backcolor.TabIndex = 3;
            // 
            // LB_02
            // 
            this.LB_02.AutoSize = true;
            this.LB_02.Location = new System.Drawing.Point(12, 101);
            this.LB_02.Name = "LB_02";
            this.LB_02.Size = new System.Drawing.Size(80, 16);
            this.LB_02.TabIndex = 2;
            this.LB_02.Text = "單數行底色：";
            // 
            // CB_cellAutoWidth
            // 
            this.CB_cellAutoWidth.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_cellAutoWidth.ForeColor = System.Drawing.Color.Black;
            this.CB_cellAutoWidth.FormattingEnabled = true;
            this.CB_cellAutoWidth.Items.AddRange(new object[] {
            "無調整(預設)",
            "調整所有儲存格的內容 (含標題)  ",
            "調整所有儲存格的內容 (不含標題)  ",
            "調整以適合資料行行首儲存格的內容",
            "調整顯示在螢幕上儲存格的內容 (含標題)",
            "調整顯示在螢幕上儲存格的內容 (不含標題)"});
            this.CB_cellAutoWidth.Location = new System.Drawing.Point(93, 72);
            this.CB_cellAutoWidth.Name = "CB_cellAutoWidth";
            this.CB_cellAutoWidth.Size = new System.Drawing.Size(217, 23);
            this.CB_cellAutoWidth.TabIndex = 1;
            // 
            // LB_01
            // 
            this.LB_01.AutoSize = true;
            this.LB_01.Location = new System.Drawing.Point(12, 75);
            this.LB_01.Name = "LB_01";
            this.LB_01.Size = new System.Drawing.Size(68, 16);
            this.LB_01.TabIndex = 0;
            this.LB_01.Text = "自動寬度：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox1.Controls.Add(this.picbox_theme);
            this.groupBox1.Controls.Add(this.CB_maincolor);
            this.groupBox1.Controls.Add(this.lb_maincolor);
            this.groupBox1.Controls.Add(this.bt_picpath);
            this.groupBox1.Controls.Add(this.lb_theme);
            this.groupBox1.Controls.Add(this.lb_mainpic);
            this.groupBox1.Controls.Add(this.CB_theme);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(29, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "個人主題";
            // 
            // picbox_theme
            // 
            this.picbox_theme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbox_theme.Location = new System.Drawing.Point(234, 17);
            this.picbox_theme.Name = "picbox_theme";
            this.picbox_theme.Size = new System.Drawing.Size(106, 76);
            this.picbox_theme.TabIndex = 15;
            this.picbox_theme.TabStop = false;
            // 
            // CB_maincolor
            // 
            this.CB_maincolor.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_maincolor.ForeColor = System.Drawing.Color.Black;
            this.CB_maincolor.FormattingEnabled = true;
            this.CB_maincolor.Items.AddRange(new object[] {
            "淺藍(預設)",
            "淺綠",
            "淺灰",
            "淺黃",
            "粉紅"});
            this.CB_maincolor.Location = new System.Drawing.Point(93, 47);
            this.CB_maincolor.Name = "CB_maincolor";
            this.CB_maincolor.Size = new System.Drawing.Size(95, 23);
            this.CB_maincolor.TabIndex = 14;
            // 
            // lb_maincolor
            // 
            this.lb_maincolor.AutoSize = true;
            this.lb_maincolor.Location = new System.Drawing.Point(13, 51);
            this.lb_maincolor.Name = "lb_maincolor";
            this.lb_maincolor.Size = new System.Drawing.Size(68, 16);
            this.lb_maincolor.TabIndex = 13;
            this.lb_maincolor.Text = "背景顏色：";
            // 
            // bt_picpath
            // 
            this.bt_picpath.Location = new System.Drawing.Point(93, 75);
            this.bt_picpath.Name = "bt_picpath";
            this.bt_picpath.Size = new System.Drawing.Size(48, 23);
            this.bt_picpath.TabIndex = 12;
            this.bt_picpath.Text = "選擇";
            this.bt_picpath.UseVisualStyleBackColor = true;
            this.bt_picpath.Click += new System.EventHandler(this.bt_picpath_Click);
            // 
            // lb_theme
            // 
            this.lb_theme.AutoSize = true;
            this.lb_theme.Location = new System.Drawing.Point(12, 24);
            this.lb_theme.Name = "lb_theme";
            this.lb_theme.Size = new System.Drawing.Size(68, 16);
            this.lb_theme.TabIndex = 10;
            this.lb_theme.Text = "主題選擇：";
            // 
            // lb_mainpic
            // 
            this.lb_mainpic.AutoSize = true;
            this.lb_mainpic.Location = new System.Drawing.Point(13, 77);
            this.lb_mainpic.Name = "lb_mainpic";
            this.lb_mainpic.Size = new System.Drawing.Size(68, 16);
            this.lb_mainpic.TabIndex = 9;
            this.lb_mainpic.Text = "背景圖片：";
            // 
            // CB_theme
            // 
            this.CB_theme.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_theme.ForeColor = System.Drawing.Color.Black;
            this.CB_theme.FormattingEnabled = true;
            this.CB_theme.Items.AddRange(new object[] {
            "星際大戰(預設)",
            "自行設定"});
            this.CB_theme.Location = new System.Drawing.Point(93, 20);
            this.CB_theme.Name = "CB_theme";
            this.CB_theme.Size = new System.Drawing.Size(95, 23);
            this.CB_theme.TabIndex = 4;
            this.CB_theme.SelectedIndexChanged += new System.EventHandler(this.cb_theme_SelectedIndexChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(405, 421);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GB_rslt);
            this.Controls.Add(this.GB_other);
            this.Controls.Add(this.BT_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "詳細設定";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.GB_other.ResumeLayout(false);
            this.GB_other.PerformLayout();
            this.GB_rslt.ResumeLayout(false);
            this.GB_rslt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_theme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_ok;
        private System.Windows.Forms.GroupBox GB_other;    
        private System.Windows.Forms.GroupBox GB_rslt;
        private System.Windows.Forms.Label LB_01;
        private System.Windows.Forms.Label LB_02;
        private System.Windows.Forms.ComboBox CB_cellAutoWidth;
        private System.Windows.Forms.CheckBox CB_alltables;
        private System.Windows.Forms.ComboBox CB_backcolor;
        private System.Windows.Forms.CheckBox CB_ShowRsltForm;
        private System.Windows.Forms.CheckBox CB_music;
        private System.Windows.Forms.Label LB_rslt_wordsize;
        private System.Windows.Forms.RadioButton RB_rslt_small;
        private System.Windows.Forms.RadioButton RB_rslt_mid;
        private System.Windows.Forms.RadioButton RB_rslt_big;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_maincolor;
        private System.Windows.Forms.Label lb_maincolor;
        private System.Windows.Forms.Button bt_picpath;
        private System.Windows.Forms.Label lb_theme;
        private System.Windows.Forms.Label lb_mainpic;
        private System.Windows.Forms.ComboBox CB_theme;
        private System.Windows.Forms.PictureBox picbox_theme;

        public class Setup_Info //管理SetupForm各元件的class
        {
            private bool v_Set_List_All_Tbs;
            private bool v_Set_CB_music;
            private int v_Set_CB_cellAutoWidth;
            private int v_Set_CB_backcolor;
            private bool v_Set_CB_ShowRsltForm;
            private int v_Set_RB_rslt_wordsize;
            private int v_Set_CB_theme;
            private int v_Set_CB_maincolor;

            public bool Set_List_All_Tbs //列出所有可Select的Table
            {
                get { return v_Set_List_All_Tbs; }
                set { v_Set_List_All_Tbs = value; }
            }
            public int Set_CB_cellAutoWidth //自動寬度
            {
                get { return v_Set_CB_cellAutoWidth; }
                set { v_Set_CB_cellAutoWidth = value; }
            }
            public int Set_CB_backcolor //查詢結果偶數列的底色
            {
                get { return v_Set_CB_backcolor; }
                set { v_Set_CB_backcolor = value; }
            }
            public int Set_RB_rslt_wordsize //查詢結果的字體大小
            {
                get { return v_Set_RB_rslt_wordsize; }
                set { v_Set_RB_rslt_wordsize = value; }
            }
            public bool Set_CB_ShowRsltForm //顯示查詢結果於新視窗
            {
                get { return v_Set_CB_ShowRsltForm; }
                set { v_Set_CB_ShowRsltForm = value; }
            }
            public bool Set_CB_music //是否開啟音效
            {
                get { return v_Set_CB_music; }
                set { v_Set_CB_music = value; }
            }
            public int Set_CB_theme //主題選擇
            {
                get { return v_Set_CB_theme; }
                set { v_Set_CB_theme = value; }
            }
            public int Set_CB_maincolor //背景顏色
            {
                get { return v_Set_CB_maincolor; }
                set { v_Set_CB_maincolor = value; }
            }
        }
    }
}