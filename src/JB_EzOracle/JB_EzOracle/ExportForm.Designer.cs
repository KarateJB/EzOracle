namespace JB_EzOracleSQL
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.gb_setup = new System.Windows.Forms.GroupBox();
            this.cb_SetCol = new System.Windows.Forms.CheckBox();
            this.clb_SetCol = new System.Windows.Forms.CheckedListBox();
            this.llb_open = new System.Windows.Forms.LinkLabel();
            this.bt_browse = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.rb_txt = new System.Windows.Forms.RadioButton();
            this.rb_Excel = new System.Windows.Forms.RadioButton();
            this.lb_path = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.bgWorker_excel = new System.ComponentModel.BackgroundWorker();
            this.bgWorker_txt = new System.ComponentModel.BackgroundWorker();
            this.lb_alert = new System.Windows.Forms.Label();
            this.lb_SelAll = new System.Windows.Forms.LinkLabel();
            this.lb_CnlAll = new System.Windows.Forms.LinkLabel();
            this.gb_setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_setup
            // 
            this.gb_setup.Controls.Add(this.lb_CnlAll);
            this.gb_setup.Controls.Add(this.lb_SelAll);
            this.gb_setup.Controls.Add(this.cb_SetCol);
            this.gb_setup.Controls.Add(this.clb_SetCol);
            this.gb_setup.Controls.Add(this.llb_open);
            this.gb_setup.Controls.Add(this.bt_browse);
            this.gb_setup.Controls.Add(this.tb_path);
            this.gb_setup.Controls.Add(this.rb_txt);
            this.gb_setup.Controls.Add(this.rb_Excel);
            this.gb_setup.Controls.Add(this.lb_path);
            this.gb_setup.Location = new System.Drawing.Point(12, 13);
            this.gb_setup.Name = "gb_setup";
            this.gb_setup.Size = new System.Drawing.Size(405, 272);
            this.gb_setup.TabIndex = 0;
            this.gb_setup.TabStop = false;
            this.gb_setup.Text = "類型";
            // 
            // cb_SetCol
            // 
            this.cb_SetCol.AutoSize = true;
            this.cb_SetCol.Location = new System.Drawing.Point(34, 57);
            this.cb_SetCol.Name = "cb_SetCol";
            this.cb_SetCol.Size = new System.Drawing.Size(195, 20);
            this.cb_SetCol.TabIndex = 12;
            this.cb_SetCol.Text = "我要指定哪些欄位為文字格式：";
            this.cb_SetCol.UseVisualStyleBackColor = true;
            this.cb_SetCol.CheckedChanged += new System.EventHandler(this.cb_SetCol_CheckedChanged);
            // 
            // clb_SetCol
            // 
            this.clb_SetCol.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clb_SetCol.FormattingEnabled = true;
            this.clb_SetCol.Location = new System.Drawing.Point(34, 78);
            this.clb_SetCol.Name = "clb_SetCol";
            this.clb_SetCol.Size = new System.Drawing.Size(296, 89);
            this.clb_SetCol.TabIndex = 11;
            // 
            // llb_open
            // 
            this.llb_open.AutoSize = true;
            this.llb_open.Location = new System.Drawing.Point(298, 246);
            this.llb_open.Name = "llb_open";
            this.llb_open.Size = new System.Drawing.Size(32, 16);
            this.llb_open.TabIndex = 9;
            this.llb_open.TabStop = true;
            this.llb_open.Text = "開啟";
            this.llb_open.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_open_LinkClicked);
            // 
            // bt_browse
            // 
            this.bt_browse.Location = new System.Drawing.Point(336, 221);
            this.bt_browse.Name = "bt_browse";
            this.bt_browse.Size = new System.Drawing.Size(63, 23);
            this.bt_browse.TabIndex = 5;
            this.bt_browse.Text = "瀏覽";
            this.bt_browse.UseVisualStyleBackColor = true;
            this.bt_browse.Click += new System.EventHandler(this.bt_browse_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(95, 221);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(235, 23);
            this.tb_path.TabIndex = 4;
            // 
            // rb_txt
            // 
            this.rb_txt.AutoSize = true;
            this.rb_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_txt.Location = new System.Drawing.Point(16, 183);
            this.rb_txt.Name = "rb_txt";
            this.rb_txt.Size = new System.Drawing.Size(74, 20);
            this.rb_txt.TabIndex = 3;
            this.rb_txt.Text = "純文字檔";
            this.rb_txt.UseVisualStyleBackColor = false;
            // 
            // rb_Excel
            // 
            this.rb_Excel.AutoSize = true;
            this.rb_Excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rb_Excel.Checked = true;
            this.rb_Excel.Location = new System.Drawing.Point(16, 31);
            this.rb_Excel.Name = "rb_Excel";
            this.rb_Excel.Size = new System.Drawing.Size(55, 20);
            this.rb_Excel.TabIndex = 2;
            this.rb_Excel.TabStop = true;
            this.rb_Excel.Text = "Excel";
            this.rb_Excel.UseVisualStyleBackColor = false;
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Location = new System.Drawing.Point(29, 225);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(68, 16);
            this.lb_path.TabIndex = 1;
            this.lb_path.Text = "儲存路徑：";
            // 
            // bt_ok
            // 
            this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_ok.Location = new System.Drawing.Point(423, 23);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(63, 95);
            this.bt_ok.TabIndex = 6;
            this.bt_ok.Text = "確定";
            this.bt_ok.UseVisualStyleBackColor = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(423, 124);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(63, 34);
            this.bt_close.TabIndex = 7;
            this.bt_close.Text = "關閉";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bgWorker_excel
            // 
            this.bgWorker_excel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_excel_DoWork);
            this.bgWorker_excel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_excel_RunWorkerCompleted);
            // 
            // bgWorker_txt
            // 
            this.bgWorker_txt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_txt_DoWork);
            this.bgWorker_txt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_txt_RunWorkerCompleted);
            // 
            // lb_alert
            // 
            this.lb_alert.AutoSize = true;
            this.lb_alert.ForeColor = System.Drawing.Color.Red;
            this.lb_alert.Location = new System.Drawing.Point(9, 288);
            this.lb_alert.Name = "lb_alert";
            this.lb_alert.Size = new System.Drawing.Size(125, 16);
            this.lb_alert.TabIndex = 8;
            this.lb_alert.Text = "資料匯出中，請稍候...";
            // 
            // lb_SelAll
            // 
            this.lb_SelAll.AutoSize = true;
            this.lb_SelAll.Location = new System.Drawing.Point(333, 134);
            this.lb_SelAll.Name = "lb_SelAll";
            this.lb_SelAll.Size = new System.Drawing.Size(32, 16);
            this.lb_SelAll.TabIndex = 13;
            this.lb_SelAll.TabStop = true;
            this.lb_SelAll.Text = "全選";
            this.lb_SelAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_SelAll_LinkClicked);
            // 
            // lb_CnlAll
            // 
            this.lb_CnlAll.AutoSize = true;
            this.lb_CnlAll.Location = new System.Drawing.Point(333, 151);
            this.lb_CnlAll.Name = "lb_CnlAll";
            this.lb_CnlAll.Size = new System.Drawing.Size(56, 16);
            this.lb_CnlAll.TabIndex = 14;
            this.lb_CnlAll.TabStop = true;
            this.lb_CnlAll.Text = "全部取消";
            this.lb_CnlAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_CnlAll_LinkClicked);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(499, 313);
            this.ControlBox = false;
            this.Controls.Add(this.lb_alert);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.gb_setup);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExportForm";
            this.Text = "匯出資料";
            this.gb_setup.ResumeLayout(false);
            this.gb_setup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_setup;
        private System.Windows.Forms.RadioButton rb_Excel;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.Button bt_browse;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.RadioButton rb_txt;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_close;
        private System.ComponentModel.BackgroundWorker bgWorker_excel;
        private System.ComponentModel.BackgroundWorker bgWorker_txt;
        private System.Windows.Forms.Label lb_alert;
        private System.Windows.Forms.LinkLabel llb_open;
        private System.Windows.Forms.CheckedListBox clb_SetCol;
        private System.Windows.Forms.CheckBox cb_SetCol;
        private System.Windows.Forms.LinkLabel lb_CnlAll;
        private System.Windows.Forms.LinkLabel lb_SelAll;
    }
}