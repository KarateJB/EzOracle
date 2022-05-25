namespace JB_EzOracleSQL
{
    partial class SchemaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaForm));
            this.cb_TableName = new System.Windows.Forms.ComboBox();
            this.lb_owner = new System.Windows.Forms.Label();
            this.lb_table = new System.Windows.Forms.Label();
            this.tb_owner = new System.Windows.Forms.TextBox();
            this.lb_path = new System.Windows.Forms.Label();
            this.bt_open = new System.Windows.Forms.Button();
            this.gb_set = new System.Windows.Forms.GroupBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_chgpath = new System.Windows.Forms.Button();
            this.lb_newpath = new System.Windows.Forms.Label();
            this.tb_newpath = new System.Windows.Forms.TextBox();
            this.llb_openlog = new System.Windows.Forms.LinkLabel();
            this.bt_close = new System.Windows.Forms.Button();
            this.lb_pathlist = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bt_del = new System.Windows.Forms.Button();
            this.lb_pathlist_sn = new System.Windows.Forms.ListBox();
            this.lb_refresh = new System.Windows.Forms.LinkLabel();
            this.gb_set.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_TableName
            // 
            this.cb_TableName.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.cb_TableName.FormattingEnabled = true;
            this.cb_TableName.Location = new System.Drawing.Point(71, 43);
            this.cb_TableName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_TableName.Name = "cb_TableName";
            this.cb_TableName.Size = new System.Drawing.Size(280, 23);
            this.cb_TableName.TabIndex = 0;
            this.cb_TableName.SelectedIndexChanged += new System.EventHandler(this.cb_TableName_SelectedIndexChanged);
            // 
            // lb_owner
            // 
            this.lb_owner.AutoSize = true;
            this.lb_owner.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_owner.Location = new System.Drawing.Point(14, 22);
            this.lb_owner.Name = "lb_owner";
            this.lb_owner.Size = new System.Drawing.Size(45, 15);
            this.lb_owner.TabIndex = 1;
            this.lb_owner.Text = "Owner:";
            // 
            // lb_table
            // 
            this.lb_table.AutoSize = true;
            this.lb_table.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lb_table.Location = new System.Drawing.Point(14, 48);
            this.lb_table.Name = "lb_table";
            this.lb_table.Size = new System.Drawing.Size(38, 15);
            this.lb_table.TabIndex = 2;
            this.lb_table.Text = "Table:";
            // 
            // tb_owner
            // 
            this.tb_owner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_owner.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.tb_owner.Location = new System.Drawing.Point(71, 19);
            this.tb_owner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_owner.Name = "tb_owner";
            this.tb_owner.ReadOnly = true;
            this.tb_owner.Size = new System.Drawing.Size(116, 22);
            this.tb_owner.TabIndex = 3;
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lb_path.Location = new System.Drawing.Point(14, 73);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(54, 15);
            this.lb_path.TabIndex = 4;
            this.lb_path.Text = "檔案路徑:";
            // 
            // bt_open
            // 
            this.bt_open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_open.Location = new System.Drawing.Point(359, 73);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(58, 58);
            this.bt_open.TabIndex = 6;
            this.bt_open.Text = "開啟";
            this.bt_open.UseVisualStyleBackColor = false;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // gb_set
            // 
            this.gb_set.Controls.Add(this.bt_save);
            this.gb_set.Controls.Add(this.bt_chgpath);
            this.gb_set.Controls.Add(this.lb_newpath);
            this.gb_set.Controls.Add(this.tb_newpath);
            this.gb_set.Controls.Add(this.llb_openlog);
            this.gb_set.Location = new System.Drawing.Point(17, 156);
            this.gb_set.Name = "gb_set";
            this.gb_set.Size = new System.Drawing.Size(400, 109);
            this.gb_set.TabIndex = 8;
            this.gb_set.TabStop = false;
            this.gb_set.Text = "設定";
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(335, 50);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(58, 38);
            this.bt_save.TabIndex = 11;
            this.bt_save.Text = "儲存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_chgpath
            // 
            this.bt_chgpath.Location = new System.Drawing.Point(336, 23);
            this.bt_chgpath.Name = "bt_chgpath";
            this.bt_chgpath.Size = new System.Drawing.Size(58, 21);
            this.bt_chgpath.TabIndex = 9;
            this.bt_chgpath.Text = "選擇";
            this.bt_chgpath.UseVisualStyleBackColor = true;
            this.bt_chgpath.Click += new System.EventHandler(this.bt_chgpath_Click);
            // 
            // lb_newpath
            // 
            this.lb_newpath.AutoSize = true;
            this.lb_newpath.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lb_newpath.Location = new System.Drawing.Point(6, 27);
            this.lb_newpath.Name = "lb_newpath";
            this.lb_newpath.Size = new System.Drawing.Size(43, 15);
            this.lb_newpath.TabIndex = 10;
            this.lb_newpath.Text = "新路徑:";
            // 
            // tb_newpath
            // 
            this.tb_newpath.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.tb_newpath.Location = new System.Drawing.Point(54, 22);
            this.tb_newpath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_newpath.Name = "tb_newpath";
            this.tb_newpath.Size = new System.Drawing.Size(280, 22);
            this.tb_newpath.TabIndex = 9;
            // 
            // llb_openlog
            // 
            this.llb_openlog.AutoSize = true;
            this.llb_openlog.Location = new System.Drawing.Point(332, 91);
            this.llb_openlog.Name = "llb_openlog";
            this.llb_openlog.Size = new System.Drawing.Size(62, 15);
            this.llb_openlog.TabIndex = 8;
            this.llb_openlog.TabStop = true;
            this.llb_openlog.Text = "開啟記錄檔";
            this.llb_openlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_openlog_LinkClicked);
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_close.Location = new System.Drawing.Point(192, 276);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(58, 34);
            this.bt_close.TabIndex = 9;
            this.bt_close.Text = "關閉";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // lb_pathlist
            // 
            this.lb_pathlist.FormattingEnabled = true;
            this.lb_pathlist.HorizontalScrollbar = true;
            this.lb_pathlist.ItemHeight = 15;
            this.lb_pathlist.Location = new System.Drawing.Point(67, 73);
            this.lb_pathlist.Name = "lb_pathlist";
            this.lb_pathlist.Size = new System.Drawing.Size(286, 79);
            this.lb_pathlist.TabIndex = 10;
            // 
            // bt_del
            // 
            this.bt_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_del.Location = new System.Drawing.Point(359, 125);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(58, 27);
            this.bt_del.TabIndex = 11;
            this.bt_del.Text = "刪除";
            this.bt_del.UseVisualStyleBackColor = false;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // lb_pathlist_sn
            // 
            this.lb_pathlist_sn.FormattingEnabled = true;
            this.lb_pathlist_sn.ItemHeight = 15;
            this.lb_pathlist_sn.Location = new System.Drawing.Point(14, 88);
            this.lb_pathlist_sn.Name = "lb_pathlist_sn";
            this.lb_pathlist_sn.Size = new System.Drawing.Size(52, 64);
            this.lb_pathlist_sn.TabIndex = 12;
            // 
            // lb_refresh
            // 
            this.lb_refresh.AutoSize = true;
            this.lb_refresh.Location = new System.Drawing.Point(360, 19);
            this.lb_refresh.Name = "lb_refresh";
            this.lb_refresh.Size = new System.Drawing.Size(51, 15);
            this.lb_refresh.TabIndex = 13;
            this.lb_refresh.TabStop = true;
            this.lb_refresh.Text = "重新整理";
            this.lb_refresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_refresh_LinkClicked);
            // 
            // SchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(437, 323);
            this.ControlBox = false;
            this.Controls.Add(this.lb_refresh);
            this.Controls.Add(this.lb_pathlist_sn);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.lb_pathlist);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.gb_set);
            this.Controls.Add(this.bt_open);
            this.Controls.Add(this.lb_path);
            this.Controls.Add(this.tb_owner);
            this.Controls.Add(this.lb_table);
            this.Controls.Add(this.lb_owner);
            this.Controls.Add(this.cb_TableName);
            this.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 359);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 359);
            this.Name = "SchemaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Table Schema";
            this.Shown += new System.EventHandler(this.SchemaForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchemaForm_FormClosing);
            this.gb_set.ResumeLayout(false);
            this.gb_set.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_TableName;
        private System.Windows.Forms.Label lb_owner;
        private System.Windows.Forms.Label lb_table;
        public System.Windows.Forms.TextBox tb_owner;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.GroupBox gb_set;
        private System.Windows.Forms.LinkLabel llb_openlog;
        private System.Windows.Forms.TextBox tb_newpath;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_chgpath;
        private System.Windows.Forms.Label lb_newpath;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.ListBox lb_pathlist;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.ListBox lb_pathlist_sn;
        private System.Windows.Forms.LinkLabel lb_refresh;
    }
}