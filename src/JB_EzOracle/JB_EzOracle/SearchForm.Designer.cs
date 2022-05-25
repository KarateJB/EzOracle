namespace JB_EzOracleSQL
{
    partial class SearchForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.CB_search = new System.Windows.Forms.ComboBox();
            this.BT_close = new System.Windows.Forms.Button();
            this.RTB_des = new System.Windows.Forms.RichTextBox();
            this.cMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // CB_search
            // 
            this.CB_search.BackColor = System.Drawing.Color.LightGreen;
            this.CB_search.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.CB_search.FormattingEnabled = true;
            this.CB_search.Items.AddRange(new object[] {
            "[Sql Plus]兩資料庫間搬資料",
            "[Sql]Create表格",
            "[Sql]新增刪除Primary Key",
            "[Sql]建立Unique Index",
            "[Sql]新增刪除欄位",
            "[Sql]列出欄位名稱及型態",
            "[Sql]Grant權限",
            "[Sql]轉換欄位型態",
            "[Sql]日期加減",
            "[Sys]計算資料庫的使用量",
            "[Sys]搬Table Space和 Index",
            "[Sql]空值轉換",
            "[Sql]字串語法",
            "[Sql]強制ORACLE使用PLAN",
            "[Sql]排序+序號",
            "[Sql]排序+Partition",
            "[Sql]HAVING",
            "[Math]餘式",
            "[Math]四捨五入"});
            this.CB_search.Location = new System.Drawing.Point(14, 15);
            this.CB_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_search.Name = "CB_search";
            this.CB_search.Size = new System.Drawing.Size(332, 24);
            this.CB_search.TabIndex = 0;
            this.CB_search.SelectedIndexChanged += new System.EventHandler(this.CB_search_SelectedIndexChanged);
            // 
            // BT_close
            // 
            this.BT_close.Location = new System.Drawing.Point(365, 16);
            this.BT_close.Name = "BT_close";
            this.BT_close.Size = new System.Drawing.Size(60, 23);
            this.BT_close.TabIndex = 1;
            this.BT_close.Text = "關閉";
            this.BT_close.UseVisualStyleBackColor = true;
            this.BT_close.Click += new System.EventHandler(this.BT_close_Click);
            // 
            // RTB_des
            // 
            this.RTB_des.BackColor = System.Drawing.SystemColors.Window;
            this.RTB_des.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTB_des.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.RTB_des.Location = new System.Drawing.Point(14, 56);
            this.RTB_des.Name = "RTB_des";
            this.RTB_des.ReadOnly = true;
            this.RTB_des.Size = new System.Drawing.Size(411, 189);
            this.RTB_des.TabIndex = 2;
            this.RTB_des.Text = "";
            // 
            // cMenuStrip
            // 
            this.cMenuStrip.Name = "cMenuStrip";
            this.cMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(439, 291);
            this.Controls.Add(this.RTB_des);
            this.Controls.Add(this.BT_close);
            this.Controls.Add(this.CB_search);
            this.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchForm";
            this.Text = "說明";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_search;
        private System.Windows.Forms.Button BT_close;
        private System.Windows.Forms.RichTextBox RTB_des;
        private System.Windows.Forms.ContextMenuStrip cMenuStrip;
    }
}