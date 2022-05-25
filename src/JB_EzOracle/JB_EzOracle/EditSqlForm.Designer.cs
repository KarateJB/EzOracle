namespace JB_EzOracleSQL
{
    partial class EditSqlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSqlForm));
            this.RTB_SQL = new System.Windows.Forms.RichTextBox();
            this.BT_save = new System.Windows.Forms.Button();
            this.BT_close = new System.Windows.Forms.Button();
            this.LLB_ColInfo = new System.Windows.Forms.LinkLabel();
            this.LB_wordsize = new System.Windows.Forms.Label();
            this.RB_big = new System.Windows.Forms.RadioButton();
            this.RB_mid = new System.Windows.Forms.RadioButton();
            this.RB_small = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // RTB_SQL
            // 
            this.RTB_SQL.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB_SQL.Location = new System.Drawing.Point(12, 42);
            this.RTB_SQL.Name = "RTB_SQL";
            this.RTB_SQL.Size = new System.Drawing.Size(560, 495);
            this.RTB_SQL.TabIndex = 0;
            this.RTB_SQL.Text = "";
            this.RTB_SQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_SQL_KeyDown);
            // 
            // BT_save
            // 
            this.BT_save.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_save.Location = new System.Drawing.Point(12, 12);
            this.BT_save.Name = "BT_save";
            this.BT_save.Size = new System.Drawing.Size(100, 23);
            this.BT_save.TabIndex = 1;
            this.BT_save.Text = "回存";
            this.BT_save.UseVisualStyleBackColor = true;
            this.BT_save.Click += new System.EventHandler(this.BT_save_Click);
            // 
            // BT_close
            // 
            this.BT_close.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_close.Location = new System.Drawing.Point(118, 13);
            this.BT_close.Name = "BT_close";
            this.BT_close.Size = new System.Drawing.Size(75, 23);
            this.BT_close.TabIndex = 2;
            this.BT_close.Text = "關閉";
            this.BT_close.UseVisualStyleBackColor = true;
            this.BT_close.Click += new System.EventHandler(this.BT_close_Click);
            // 
            // LLB_ColInfo
            // 
            this.LLB_ColInfo.AutoSize = true;
            this.LLB_ColInfo.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LLB_ColInfo.LinkColor = System.Drawing.Color.Yellow;
            this.LLB_ColInfo.Location = new System.Drawing.Point(209, 19);
            this.LLB_ColInfo.Name = "LLB_ColInfo";
            this.LLB_ColInfo.Size = new System.Drawing.Size(65, 16);
            this.LLB_ColInfo.TabIndex = 3;
            this.LLB_ColInfo.TabStop = true;
            this.LLB_ColInfo.Text = "欄位資訊...";
            this.LLB_ColInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_ColInfo_LinkClicked);
            // 
            // LB_wordsize
            // 
            this.LB_wordsize.AutoSize = true;
            this.LB_wordsize.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_wordsize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LB_wordsize.Location = new System.Drawing.Point(382, 18);
            this.LB_wordsize.Name = "LB_wordsize";
            this.LB_wordsize.Size = new System.Drawing.Size(56, 16);
            this.LB_wordsize.TabIndex = 4;
            this.LB_wordsize.Text = "字體大小";
            // 
            // RB_big
            // 
            this.RB_big.AutoSize = true;
            this.RB_big.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RB_big.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RB_big.Location = new System.Drawing.Point(444, 15);
            this.RB_big.Name = "RB_big";
            this.RB_big.Size = new System.Drawing.Size(38, 20);
            this.RB_big.TabIndex = 5;
            this.RB_big.Text = "大";
            this.RB_big.UseVisualStyleBackColor = true;
            this.RB_big.Click += new System.EventHandler(this.RB_wordsize_CheckedChanged);
            // 
            // RB_mid
            // 
            this.RB_mid.AutoSize = true;
            this.RB_mid.Checked = true;
            this.RB_mid.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RB_mid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RB_mid.Location = new System.Drawing.Point(488, 15);
            this.RB_mid.Name = "RB_mid";
            this.RB_mid.Size = new System.Drawing.Size(38, 20);
            this.RB_mid.TabIndex = 6;
            this.RB_mid.TabStop = true;
            this.RB_mid.Text = "中";
            this.RB_mid.UseVisualStyleBackColor = true;
            this.RB_mid.Click += new System.EventHandler(this.RB_wordsize_CheckedChanged);
            // 
            // RB_small
            // 
            this.RB_small.AutoSize = true;
            this.RB_small.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RB_small.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RB_small.Location = new System.Drawing.Point(532, 15);
            this.RB_small.Name = "RB_small";
            this.RB_small.Size = new System.Drawing.Size(38, 20);
            this.RB_small.TabIndex = 7;
            this.RB_small.Text = "小";
            this.RB_small.UseVisualStyleBackColor = true;
            this.RB_small.Click += new System.EventHandler(this.RB_wordsize_CheckedChanged);
            // 
            // EditSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(584, 564);
            this.Controls.Add(this.RB_small);
            this.Controls.Add(this.RB_mid);
            this.Controls.Add(this.RB_big);
            this.Controls.Add(this.LB_wordsize);
            this.Controls.Add(this.LLB_ColInfo);
            this.Controls.Add(this.BT_close);
            this.Controls.Add(this.BT_save);
            this.Controls.Add(this.RTB_SQL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "EditSqlForm";
            this.Text = "SQL編輯區";
            this.Resize += new System.EventHandler(this.EditSqlForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox RTB_SQL;
        private System.Windows.Forms.Button BT_save;
        private System.Windows.Forms.Button BT_close;
        private System.Windows.Forms.LinkLabel LLB_ColInfo;
        private System.Windows.Forms.Label LB_wordsize;
        private System.Windows.Forms.RadioButton RB_big;
        private System.Windows.Forms.RadioButton RB_mid;
        private System.Windows.Forms.RadioButton RB_small;

    }
}