namespace JB_EzOracleSQL
{
    partial class AlertBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertBox));
            this.BT_ok = new System.Windows.Forms.Button();
            this.lb_alert = new System.Windows.Forms.Label();
            this.PicBox_theme = new System.Windows.Forms.PictureBox();
            this.pic_back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_theme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ok
            // 
            this.BT_ok.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_ok.Location = new System.Drawing.Point(265, 103);
            this.BT_ok.Name = "BT_ok";
            this.BT_ok.Size = new System.Drawing.Size(75, 23);
            this.BT_ok.TabIndex = 1;
            this.BT_ok.Text = "確定";
            this.BT_ok.UseVisualStyleBackColor = true;
            this.BT_ok.Click += new System.EventHandler(this.BT_ok_Click);
            // 
            // lb_alert
            // 
            this.lb_alert.AutoEllipsis = true;
            this.lb_alert.AutoSize = true;
            this.lb_alert.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lb_alert.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_alert.Location = new System.Drawing.Point(102, 17);
            this.lb_alert.Name = "lb_alert";
            this.lb_alert.Size = new System.Drawing.Size(56, 16);
            this.lb_alert.TabIndex = 2;
            this.lb_alert.Text = "警告訊息";
            // 
            // PicBox_theme
            // 
            this.PicBox_theme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBox_theme.Location = new System.Drawing.Point(7, 71);
            this.PicBox_theme.Name = "PicBox_theme";
            this.PicBox_theme.Size = new System.Drawing.Size(65, 54);
            this.PicBox_theme.TabIndex = 3;
            this.PicBox_theme.TabStop = false;
            // 
            // pic_back
            // 
            this.pic_back.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.AlertBox;
            this.pic_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_back.Location = new System.Drawing.Point(74, 2);
            this.pic_back.Name = "pic_back";
            this.pic_back.Size = new System.Drawing.Size(277, 95);
            this.pic_back.TabIndex = 0;
            this.pic_back.TabStop = false;
            // 
            // AlertBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(364, 144);
            this.ControlBox = false;
            this.Controls.Add(this.PicBox_theme);
            this.Controls.Add(this.lb_alert);
            this.Controls.Add(this.BT_ok);
            this.Controls.Add(this.pic_back);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(380, 180);
            this.MinimumSize = new System.Drawing.Size(380, 180);
            this.Name = "AlertBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "警告訊息";
            this.Shown += new System.EventHandler(this.AlertBox_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_theme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_back;
        private System.Windows.Forms.Button BT_ok;
        public System.Windows.Forms.Label lb_alert;
        private System.Windows.Forms.PictureBox PicBox_theme;
    }
}