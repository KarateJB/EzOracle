namespace JB_EzOracleSQL
{
    partial class ConstraintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConstraintForm));
            this.DG_constraint = new System.Windows.Forms.DataGridView();
            this.BT_adjust = new System.Windows.Forms.Button();
            this.BT_close = new System.Windows.Forms.Button();
            this.DG_pkey = new System.Windows.Forms.DataGridView();
            this.LB_01 = new System.Windows.Forms.Label();
            this.LB_02 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DG_constraint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_pkey)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_constraint
            // 
            this.DG_constraint.AllowUserToAddRows = false;
            this.DG_constraint.AllowUserToDeleteRows = false;
            this.DG_constraint.BackgroundColor = System.Drawing.Color.LightBlue;
            this.DG_constraint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_constraint.Location = new System.Drawing.Point(25, 263);
            this.DG_constraint.Margin = new System.Windows.Forms.Padding(4);
            this.DG_constraint.Name = "DG_constraint";
            this.DG_constraint.RowTemplate.Height = 24;
            this.DG_constraint.Size = new System.Drawing.Size(444, 128);
            this.DG_constraint.TabIndex = 0;
            // 
            // BT_adjust
            // 
            this.BT_adjust.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_adjust.Location = new System.Drawing.Point(25, 23);
            this.BT_adjust.Margin = new System.Windows.Forms.Padding(4);
            this.BT_adjust.Name = "BT_adjust";
            this.BT_adjust.Size = new System.Drawing.Size(88, 31);
            this.BT_adjust.TabIndex = 1;
            this.BT_adjust.Text = "自動調整";
            this.BT_adjust.UseVisualStyleBackColor = true;
            this.BT_adjust.Click += new System.EventHandler(this.BT_adjust_Click);
            // 
            // BT_close
            // 
            this.BT_close.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_close.Location = new System.Drawing.Point(121, 23);
            this.BT_close.Margin = new System.Windows.Forms.Padding(4);
            this.BT_close.Name = "BT_close";
            this.BT_close.Size = new System.Drawing.Size(63, 31);
            this.BT_close.TabIndex = 2;
            this.BT_close.Text = "關閉";
            this.BT_close.UseVisualStyleBackColor = true;
            this.BT_close.Click += new System.EventHandler(this.BT_close_Click);
            // 
            // DG_pkey
            // 
            this.DG_pkey.AllowUserToAddRows = false;
            this.DG_pkey.AllowUserToDeleteRows = false;
            this.DG_pkey.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.DG_pkey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_pkey.Location = new System.Drawing.Point(25, 80);
            this.DG_pkey.Margin = new System.Windows.Forms.Padding(4);
            this.DG_pkey.Name = "DG_pkey";
            this.DG_pkey.RowTemplate.Height = 24;
            this.DG_pkey.Size = new System.Drawing.Size(444, 144);
            this.DG_pkey.TabIndex = 3;
            // 
            // LB_01
            // 
            this.LB_01.AutoSize = true;
            this.LB_01.ForeColor = System.Drawing.Color.Red;
            this.LB_01.Location = new System.Drawing.Point(22, 60);
            this.LB_01.Name = "LB_01";
            this.LB_01.Size = new System.Drawing.Size(79, 16);
            this.LB_01.TabIndex = 4;
            this.LB_01.Text = "Primary Key :";
            // 
            // LB_02
            // 
            this.LB_02.AutoSize = true;
            this.LB_02.ForeColor = System.Drawing.Color.Red;
            this.LB_02.Location = new System.Drawing.Point(22, 243);
            this.LB_02.Name = "LB_02";
            this.LB_02.Size = new System.Drawing.Size(71, 16);
            this.LB_02.TabIndex = 5;
            this.LB_02.Text = "Constraint :";
            // 
            // ConstraintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(496, 416);
            this.Controls.Add(this.LB_02);
            this.Controls.Add(this.LB_01);
            this.Controls.Add(this.DG_pkey);
            this.Controls.Add(this.BT_close);
            this.Controls.Add(this.BT_adjust);
            this.Controls.Add(this.DG_constraint);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConstraintForm";
            this.Text = "表格資訊";
            this.Resize += new System.EventHandler(this.ConstraintForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DG_constraint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_pkey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DG_constraint;
        private System.Windows.Forms.Button BT_adjust;
        private System.Windows.Forms.Button BT_close;
        public System.Windows.Forms.DataGridView DG_pkey;
        private System.Windows.Forms.Label LB_01;
        private System.Windows.Forms.Label LB_02;
    }
}