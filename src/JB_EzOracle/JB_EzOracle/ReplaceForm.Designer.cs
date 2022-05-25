namespace JB_EzOracleSQL
{
    partial class ReplaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceForm));
            this.lb_01 = new System.Windows.Forms.Label();
            this.tb_ReplaceText = new System.Windows.Forms.TextBox();
            this.lb_02 = new System.Windows.Forms.Label();
            this.tb_NewText = new System.Windows.Forms.TextBox();
            this.bt_Next = new System.Windows.Forms.Button();
            this.bt_Replace = new System.Windows.Forms.Button();
            this.bt_ReplaceAll = new System.Windows.Forms.Button();
            this.lb_Alert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_01
            // 
            this.lb_01.AutoSize = true;
            this.lb_01.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_01.Location = new System.Drawing.Point(12, 23);
            this.lb_01.Name = "lb_01";
            this.lb_01.Size = new System.Drawing.Size(68, 16);
            this.lb_01.TabIndex = 0;
            this.lb_01.Text = "尋找目標：";
            // 
            // tb_ReplaceText
            // 
            this.tb_ReplaceText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_ReplaceText.Location = new System.Drawing.Point(75, 20);
            this.tb_ReplaceText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_ReplaceText.Name = "tb_ReplaceText";
            this.tb_ReplaceText.Size = new System.Drawing.Size(200, 23);
            this.tb_ReplaceText.TabIndex = 1;
            // 
            // lb_02
            // 
            this.lb_02.AutoSize = true;
            this.lb_02.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_02.Location = new System.Drawing.Point(12, 58);
            this.lb_02.Name = "lb_02";
            this.lb_02.Size = new System.Drawing.Size(68, 16);
            this.lb_02.TabIndex = 2;
            this.lb_02.Text = "取代文字：";
            // 
            // tb_NewText
            // 
            this.tb_NewText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_NewText.Location = new System.Drawing.Point(75, 52);
            this.tb_NewText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_NewText.Name = "tb_NewText";
            this.tb_NewText.Size = new System.Drawing.Size(200, 23);
            this.tb_NewText.TabIndex = 3;
            // 
            // bt_Next
            // 
            this.bt_Next.Location = new System.Drawing.Point(280, 20);
            this.bt_Next.Name = "bt_Next";
            this.bt_Next.Size = new System.Drawing.Size(66, 24);
            this.bt_Next.TabIndex = 4;
            this.bt_Next.Text = "下一個";
            this.bt_Next.UseVisualStyleBackColor = true;
            this.bt_Next.Click += new System.EventHandler(this.bt_Next_Click);
            // 
            // bt_Replace
            // 
            this.bt_Replace.Location = new System.Drawing.Point(280, 50);
            this.bt_Replace.Name = "bt_Replace";
            this.bt_Replace.Size = new System.Drawing.Size(66, 24);
            this.bt_Replace.TabIndex = 5;
            this.bt_Replace.Text = "取代";
            this.bt_Replace.UseVisualStyleBackColor = true;
            this.bt_Replace.Click += new System.EventHandler(this.bt_Replace_Click);
            // 
            // bt_ReplaceAll
            // 
            this.bt_ReplaceAll.Location = new System.Drawing.Point(352, 50);
            this.bt_ReplaceAll.Name = "bt_ReplaceAll";
            this.bt_ReplaceAll.Size = new System.Drawing.Size(66, 24);
            this.bt_ReplaceAll.TabIndex = 6;
            this.bt_ReplaceAll.Text = "全部取代";
            this.bt_ReplaceAll.UseVisualStyleBackColor = true;
            this.bt_ReplaceAll.Click += new System.EventHandler(this.bt_ReplaceAll_Click);
            // 
            // lb_Alert
            // 
            this.lb_Alert.AutoSize = true;
            this.lb_Alert.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_Alert.ForeColor = System.Drawing.Color.Red;
            this.lb_Alert.Location = new System.Drawing.Point(72, 89);
            this.lb_Alert.Name = "lb_Alert";
            this.lb_Alert.Size = new System.Drawing.Size(65, 16);
            this.lb_Alert.TabIndex = 7;
            this.lb_Alert.Text = "提示文字...";
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 114);
            this.Controls.Add(this.lb_Alert);
            this.Controls.Add(this.bt_ReplaceAll);
            this.Controls.Add(this.bt_Replace);
            this.Controls.Add(this.bt_Next);
            this.Controls.Add(this.tb_NewText);
            this.Controls.Add(this.lb_02);
            this.Controls.Add(this.tb_ReplaceText);
            this.Controls.Add(this.lb_01);
            this.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 150);
            this.Name = "ReplaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "尋找和取代";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReplaceForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_01;
        private System.Windows.Forms.TextBox tb_ReplaceText;
        private System.Windows.Forms.Label lb_02;
        private System.Windows.Forms.TextBox tb_NewText;
        private System.Windows.Forms.Button bt_Next;
        private System.Windows.Forms.Button bt_Replace;
        private System.Windows.Forms.Button bt_ReplaceAll;
        private System.Windows.Forms.Label lb_Alert;
    }
}