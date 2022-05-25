namespace JB_EzOracleSQL
{
    partial class RsltForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RsltForm));
            this.DG_rslt = new System.Windows.Forms.DataGridView();
            this.BT_excel = new System.Windows.Forms.Button();
            this.BT_close = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Bt_auto = new System.Windows.Forms.Button();
            this.LB_Sql = new System.Windows.Forms.Label();
            this.LLB_Sql = new System.Windows.Forms.LinkLabel();
            this.bt_img = new System.Windows.Forms.Button();
            this.LB_cnt = new System.Windows.Forms.Label();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.DG_rslt)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_rslt
            // 
            this.DG_rslt.AllowUserToAddRows = false;
            this.DG_rslt.AllowUserToDeleteRows = false;
            this.DG_rslt.BackgroundColor = System.Drawing.Color.LightYellow;
            this.DG_rslt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_rslt.Location = new System.Drawing.Point(15, 70);
            this.DG_rslt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DG_rslt.Name = "DG_rslt";
            this.DG_rslt.ReadOnly = true;
            this.DG_rslt.RowTemplate.Height = 24;
            this.DG_rslt.Size = new System.Drawing.Size(618, 246);
            this.DG_rslt.TabIndex = 0;
            // 
            // BT_excel
            // 
            this.BT_excel.Location = new System.Drawing.Point(15, 11);
            this.BT_excel.Name = "BT_excel";
            this.BT_excel.Size = new System.Drawing.Size(97, 23);
            this.BT_excel.TabIndex = 1;
            this.BT_excel.Text = "另儲存成Excel";
            this.BT_excel.UseVisualStyleBackColor = true;
            this.BT_excel.Click += new System.EventHandler(this.BT_excel_Click);
            // 
            // BT_close
            // 
            this.BT_close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_close.Location = new System.Drawing.Point(567, 14);
            this.BT_close.Name = "BT_close";
            this.BT_close.Size = new System.Drawing.Size(66, 45);
            this.BT_close.TabIndex = 2;
            this.BT_close.Text = "關閉";
            this.BT_close.UseVisualStyleBackColor = true;
            this.BT_close.Click += new System.EventHandler(this.BT_close_Click);
            // 
            // Bt_auto
            // 
            this.Bt_auto.Location = new System.Drawing.Point(116, 11);
            this.Bt_auto.Name = "Bt_auto";
            this.Bt_auto.Size = new System.Drawing.Size(93, 23);
            this.Bt_auto.TabIndex = 3;
            this.Bt_auto.Text = "自動調整";
            this.Bt_auto.UseVisualStyleBackColor = true;
            this.Bt_auto.Click += new System.EventHandler(this.Bt_auto_Click);
            // 
            // LB_Sql
            // 
            this.LB_Sql.AutoSize = true;
            this.LB_Sql.BackColor = System.Drawing.Color.LightGreen;
            this.LB_Sql.Location = new System.Drawing.Point(343, 14);
            this.LB_Sql.MaximumSize = new System.Drawing.Size(150, 0);
            this.LB_Sql.Name = "LB_Sql";
            this.LB_Sql.Size = new System.Drawing.Size(67, 16);
            this.LB_Sql.TabIndex = 4;
            this.LB_Sql.Text = "查詢的SQL";
            this.LB_Sql.Visible = false;
            // 
            // LLB_Sql
            // 
            this.LLB_Sql.AutoSize = true;
            this.LLB_Sql.Location = new System.Drawing.Point(287, 14);
            this.LLB_Sql.Name = "LLB_Sql";
            this.LLB_Sql.Size = new System.Drawing.Size(50, 16);
            this.LLB_Sql.TabIndex = 5;
            this.LLB_Sql.TabStop = true;
            this.LLB_Sql.Text = "顯示Sql";
            this.LLB_Sql.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_Sql_LinkClicked);
            // 
            // bt_img
            // 
            this.bt_img.Location = new System.Drawing.Point(215, 11);
            this.bt_img.Name = "bt_img";
            this.bt_img.Size = new System.Drawing.Size(66, 23);
            this.bt_img.TabIndex = 7;
            this.bt_img.Text = "抓圖";
            this.bt_img.UseVisualStyleBackColor = true;
            this.bt_img.Click += new System.EventHandler(this.bt_img_Click);
            // 
            // LB_cnt
            // 
            this.LB_cnt.AutoSize = true;
            this.LB_cnt.Location = new System.Drawing.Point(12, 43);
            this.LB_cnt.Name = "LB_cnt";
            this.LB_cnt.Size = new System.Drawing.Size(44, 16);
            this.LB_cnt.TabIndex = 8;
            this.LB_cnt.Text = "資料量";
            // 
            // stsStrip
            // 
            this.stsStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.stsStrip.Location = new System.Drawing.Point(0, 353);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(646, 0);
            this.stsStrip.TabIndex = 9;
            // 
            // RsltForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(646, 353);
            this.Controls.Add(this.stsStrip);
            this.Controls.Add(this.LB_Sql);
            this.Controls.Add(this.bt_img);
            this.Controls.Add(this.LLB_Sql);
            this.Controls.Add(this.Bt_auto);
            this.Controls.Add(this.BT_close);
            this.Controls.Add(this.BT_excel);
            this.Controls.Add(this.DG_rslt);
            this.Controls.Add(this.LB_cnt);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RsltForm";
            this.Text = "結果視窗";
            this.Shown += new System.EventHandler(this.RsltForm_Shown);
            this.Resize += new System.EventHandler(this.RsltForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DG_rslt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DG_rslt;
        private System.Windows.Forms.Button BT_excel;
        private System.Windows.Forms.Button BT_close;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button Bt_auto;
        public System.Windows.Forms.Label LB_Sql;
        private System.Windows.Forms.LinkLabel LLB_Sql;
        private System.Windows.Forms.Button bt_img;
        public System.Windows.Forms.Label LB_cnt;
        private System.Windows.Forms.StatusStrip stsStrip;
    }
}