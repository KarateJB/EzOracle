namespace JB_EzOracleSQL
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BT_excel = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.StatusStrip01 = new System.Windows.Forms.StatusStrip();
            this.TSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSPB = new System.Windows.Forms.ToolStripProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.LB_tablename = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage01 = new System.Windows.Forms.TabPage();
            this.RTB01 = new System.Windows.Forms.RichTextBox();
            this.tabPage02 = new System.Windows.Forms.TabPage();
            this.RTB02 = new System.Windows.Forms.RichTextBox();
            this.tabPage03 = new System.Windows.Forms.TabPage();
            this.RTB03 = new System.Windows.Forms.RichTextBox();
            this.tabPage04 = new System.Windows.Forms.TabPage();
            this.RTB04 = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.rsltPage01 = new System.Windows.Forms.TabPage();
            this.dG_table01 = new System.Windows.Forms.DataGridView();
            this.rsltPage02 = new System.Windows.Forms.TabPage();
            this.dG_table02 = new System.Windows.Forms.DataGridView();
            this.rsltPage03 = new System.Windows.Forms.TabPage();
            this.dG_table03 = new System.Windows.Forms.DataGridView();
            this.rsltPage04 = new System.Windows.Forms.TabPage();
            this.dG_table04 = new System.Windows.Forms.DataGridView();
            this.GB_top = new System.Windows.Forms.GroupBox();
            this.LLB_viewSql = new System.Windows.Forms.LinkLabel();
            this.CB_rollback = new System.Windows.Forms.CheckBox();
            this.TB_maxrow = new System.Windows.Forms.TextBox();
            this.CB_restrict = new System.Windows.Forms.CheckBox();
            this.LLB_col = new System.Windows.Forms.LinkLabel();
            this.LLB_dquery = new System.Windows.Forms.LinkLabel();
            this.LLB_constraint = new System.Windows.Forms.LinkLabel();
            this.LLB_refresh = new System.Windows.Forms.LinkLabel();
            this.LB_07 = new System.Windows.Forms.Label();
            this.CB_sqlstyle = new System.Windows.Forms.ComboBox();
            this.LLB_01 = new System.Windows.Forms.LinkLabel();
            this.LB_04 = new System.Windows.Forms.Label();
            this.CB_tablename = new System.Windows.Forms.ComboBox();
            this.BT_add1 = new System.Windows.Forms.Button();
            this.LB_05 = new System.Windows.Forms.Label();
            this.CLB_column = new System.Windows.Forms.CheckedListBox();
            this.LLB_03 = new System.Windows.Forms.LinkLabel();
            this.LLB_04 = new System.Windows.Forms.LinkLabel();
            this.GB_db = new System.Windows.Forms.GroupBox();
            this.BT_conn = new System.Windows.Forms.Button();
            this.LB_HN = new System.Windows.Forms.Label();
            this.TB_host = new System.Windows.Forms.TextBox();
            this.LB_OWNER = new System.Windows.Forms.Label();
            this.TB_owner = new System.Windows.Forms.TextBox();
            this.LB_PD = new System.Windows.Forms.Label();
            this.TB_pwd = new System.Windows.Forms.TextBox();
            this.LLB_edit01 = new System.Windows.Forms.LinkLabel();
            this.LB_QL = new System.Windows.Forms.Label();
            this.CB_quickload = new System.Windows.Forms.ComboBox();
            this.BT_down2 = new System.Windows.Forms.Button();
            this.BT_top2 = new System.Windows.Forms.Button();
            this.BT_left = new System.Windows.Forms.Button();
            this.BT_right = new System.Windows.Forms.Button();
            this.BT_top = new System.Windows.Forms.Button();
            this.BT_down = new System.Windows.Forms.Button();
            this.BT_query = new System.Windows.Forms.Button();
            this.LLB_EditBigSql = new System.Windows.Forms.LinkLabel();
            this.LB_cnt = new System.Windows.Forms.Label();
            this.llb_newpage = new System.Windows.Forms.LinkLabel();
            this.bgWorker_export = new System.ComponentModel.BackgroundWorker();
            this.tabControl_Func = new System.Windows.Forms.TabControl();
            this.tP_SpeWord = new System.Windows.Forms.TabPage();
            this.GB_sp = new System.Windows.Forms.GroupBox();
            this.LLB_refreshkeyword = new System.Windows.Forms.LinkLabel();
            this.LLB_edit02 = new System.Windows.Forms.LinkLabel();
            this.LB_keyword = new System.Windows.Forms.ListBox();
            this.tP_Msg = new System.Windows.Forms.TabPage();
            this.RTB_SysMsg = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage01.SuspendLayout();
            this.tabPage02.SuspendLayout();
            this.tabPage03.SuspendLayout();
            this.tabPage04.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.rsltPage01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_table01)).BeginInit();
            this.rsltPage02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_table02)).BeginInit();
            this.rsltPage03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_table03)).BeginInit();
            this.rsltPage04.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_table04)).BeginInit();
            this.GB_top.SuspendLayout();
            this.GB_db.SuspendLayout();
            this.tabControl_Func.SuspendLayout();
            this.tP_SpeWord.SuspendLayout();
            this.GB_sp.SuspendLayout();
            this.tP_Msg.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_excel
            // 
            this.BT_excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BT_excel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_excel.Location = new System.Drawing.Point(721, 448);
            this.BT_excel.Name = "BT_excel";
            this.BT_excel.Size = new System.Drawing.Size(92, 23);
            this.BT_excel.TabIndex = 8;
            this.BT_excel.Text = "另存EXCEL";
            this.BT_excel.UseVisualStyleBackColor = false;
            this.BT_excel.Click += new System.EventHandler(this.BT_excel_Click);
            // 
            // StatusStrip01
            // 
            this.StatusStrip01.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.StatusStrip01.Font = new System.Drawing.Font("新細明體", 9F);
            this.StatusStrip01.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusStrip01.Location = new System.Drawing.Point(0, 482);
            this.StatusStrip01.Name = "StatusStrip01";
            this.StatusStrip01.Size = new System.Drawing.Size(849, 22);
            this.StatusStrip01.TabIndex = 39;
            this.StatusStrip01.Text = "StatusStrip01";
            // 
            // TSSL
            // 
            this.TSSL.Name = "TSSL";
            this.TSSL.Size = new System.Drawing.Size(50, 23);
            // 
            // TSPB
            // 
            this.TSPB.Name = "TSPB";
            this.TSPB.Size = new System.Drawing.Size(100, 15);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LB_tablename
            // 
            this.LB_tablename.BackColor = System.Drawing.Color.LightYellow;
            this.LB_tablename.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_tablename.FormattingEnabled = true;
            this.LB_tablename.HorizontalScrollbar = true;
            this.LB_tablename.ItemHeight = 16;
            this.LB_tablename.Location = new System.Drawing.Point(856, 32);
            this.LB_tablename.Name = "LB_tablename";
            this.LB_tablename.Size = new System.Drawing.Size(228, 436);
            this.LB_tablename.TabIndex = 41;
            this.LB_tablename.Visible = false;
            this.LB_tablename.SelectedIndexChanged += new System.EventHandler(this.LB_tablename_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage01);
            this.tabControl.Controls.Add(this.tabPage02);
            this.tabControl.Controls.Add(this.tabPage03);
            this.tabControl.Controls.Add(this.tabPage04);
            this.tabControl.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl.Location = new System.Drawing.Point(252, 180);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(570, 264);
            this.tabControl.TabIndex = 42;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // tabPage01
            // 
            this.tabPage01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage01.Controls.Add(this.RTB01);
            this.tabPage01.Location = new System.Drawing.Point(4, 25);
            this.tabPage01.Name = "tabPage01";
            this.tabPage01.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage01.Size = new System.Drawing.Size(562, 235);
            this.tabPage01.TabIndex = 0;
            this.tabPage01.Text = "主要指令區(1)";
            this.tabPage01.UseVisualStyleBackColor = true;
            // 
            // RTB01
            // 
            this.RTB01.BackColor = System.Drawing.Color.Silver;
            this.RTB01.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB01.ForeColor = System.Drawing.Color.Black;
            this.RTB01.Location = new System.Drawing.Point(2, 3);
            this.RTB01.Name = "RTB01";
            this.RTB01.Size = new System.Drawing.Size(566, 232);
            this.RTB01.TabIndex = 19;
            this.RTB01.Text = "";
            this.RTB01.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            // 
            // tabPage02
            // 
            this.tabPage02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage02.Controls.Add(this.RTB02);
            this.tabPage02.Location = new System.Drawing.Point(4, 25);
            this.tabPage02.Name = "tabPage02";
            this.tabPage02.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage02.Size = new System.Drawing.Size(562, 235);
            this.tabPage02.TabIndex = 1;
            this.tabPage02.Text = "其他指令(2)";
            this.tabPage02.UseVisualStyleBackColor = true;
            // 
            // RTB02
            // 
            this.RTB02.BackColor = System.Drawing.Color.Silver;
            this.RTB02.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB02.ForeColor = System.Drawing.Color.Black;
            this.RTB02.Location = new System.Drawing.Point(2, 3);
            this.RTB02.Name = "RTB02";
            this.RTB02.Size = new System.Drawing.Size(566, 232);
            this.RTB02.TabIndex = 20;
            this.RTB02.Text = "";
            this.RTB02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            // 
            // tabPage03
            // 
            this.tabPage03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage03.Controls.Add(this.RTB03);
            this.tabPage03.Location = new System.Drawing.Point(4, 25);
            this.tabPage03.Name = "tabPage03";
            this.tabPage03.Size = new System.Drawing.Size(562, 235);
            this.tabPage03.TabIndex = 2;
            this.tabPage03.Text = "其他指令(3)";
            this.tabPage03.UseVisualStyleBackColor = true;
            // 
            // RTB03
            // 
            this.RTB03.BackColor = System.Drawing.Color.Silver;
            this.RTB03.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB03.ForeColor = System.Drawing.Color.Black;
            this.RTB03.Location = new System.Drawing.Point(2, 3);
            this.RTB03.Name = "RTB03";
            this.RTB03.Size = new System.Drawing.Size(566, 232);
            this.RTB03.TabIndex = 20;
            this.RTB03.Text = "";
            this.RTB03.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            // 
            // tabPage04
            // 
            this.tabPage04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage04.Controls.Add(this.RTB04);
            this.tabPage04.Location = new System.Drawing.Point(4, 25);
            this.tabPage04.Name = "tabPage04";
            this.tabPage04.Size = new System.Drawing.Size(562, 235);
            this.tabPage04.TabIndex = 3;
            this.tabPage04.Text = "其他指令(4)";
            this.tabPage04.UseVisualStyleBackColor = true;
            // 
            // RTB04
            // 
            this.RTB04.BackColor = System.Drawing.Color.Silver;
            this.RTB04.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB04.ForeColor = System.Drawing.Color.Black;
            this.RTB04.Location = new System.Drawing.Point(2, 3);
            this.RTB04.Name = "RTB04";
            this.RTB04.Size = new System.Drawing.Size(566, 232);
            this.RTB04.TabIndex = 20;
            this.RTB04.Text = "";
            this.RTB04.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.rsltPage01);
            this.tabControl2.Controls.Add(this.rsltPage02);
            this.tabControl2.Controls.Add(this.rsltPage03);
            this.tabControl2.Controls.Add(this.rsltPage04);
            this.tabControl2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl2.Location = new System.Drawing.Point(27, 474);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(795, 140);
            this.tabControl2.TabIndex = 44;
            this.tabControl2.Visible = false;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // rsltPage01
            // 
            this.rsltPage01.BackColor = System.Drawing.SystemColors.WindowText;
            this.rsltPage01.Controls.Add(this.dG_table01);
            this.rsltPage01.Location = new System.Drawing.Point(4, 28);
            this.rsltPage01.Name = "rsltPage01";
            this.rsltPage01.Padding = new System.Windows.Forms.Padding(3);
            this.rsltPage01.Size = new System.Drawing.Size(787, 108);
            this.rsltPage01.TabIndex = 0;
            this.rsltPage01.Text = "主要結果(1)";
            this.rsltPage01.UseVisualStyleBackColor = true;
            // 
            // dG_table01
            // 
            this.dG_table01.AllowUserToOrderColumns = true;
            this.dG_table01.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dG_table01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dG_table01.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dG_table01.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dG_table01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_table01.Location = new System.Drawing.Point(0, 0);
            this.dG_table01.Name = "dG_table01";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dG_table01.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dG_table01.RowTemplate.Height = 24;
            this.dG_table01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_table01.Size = new System.Drawing.Size(787, 108);
            this.dG_table01.TabIndex = 8;
            // 
            // rsltPage02
            // 
            this.rsltPage02.BackColor = System.Drawing.SystemColors.WindowText;
            this.rsltPage02.Controls.Add(this.dG_table02);
            this.rsltPage02.Location = new System.Drawing.Point(4, 28);
            this.rsltPage02.Name = "rsltPage02";
            this.rsltPage02.Padding = new System.Windows.Forms.Padding(3);
            this.rsltPage02.Size = new System.Drawing.Size(787, 108);
            this.rsltPage02.TabIndex = 1;
            this.rsltPage02.Text = "結果(2)";
            this.rsltPage02.UseVisualStyleBackColor = true;
            // 
            // dG_table02
            // 
            this.dG_table02.AllowUserToOrderColumns = true;
            this.dG_table02.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dG_table02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dG_table02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_table02.Location = new System.Drawing.Point(0, 0);
            this.dG_table02.Name = "dG_table02";
            this.dG_table02.RowTemplate.Height = 24;
            this.dG_table02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_table02.Size = new System.Drawing.Size(787, 108);
            this.dG_table02.TabIndex = 9;
            // 
            // rsltPage03
            // 
            this.rsltPage03.BackColor = System.Drawing.SystemColors.WindowText;
            this.rsltPage03.Controls.Add(this.dG_table03);
            this.rsltPage03.Location = new System.Drawing.Point(4, 28);
            this.rsltPage03.Name = "rsltPage03";
            this.rsltPage03.Size = new System.Drawing.Size(787, 108);
            this.rsltPage03.TabIndex = 2;
            this.rsltPage03.Text = "結果(3)";
            this.rsltPage03.UseVisualStyleBackColor = true;
            // 
            // dG_table03
            // 
            this.dG_table03.AllowUserToOrderColumns = true;
            this.dG_table03.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dG_table03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dG_table03.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_table03.Location = new System.Drawing.Point(0, 0);
            this.dG_table03.Name = "dG_table03";
            this.dG_table03.RowTemplate.Height = 24;
            this.dG_table03.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_table03.Size = new System.Drawing.Size(787, 108);
            this.dG_table03.TabIndex = 9;
            // 
            // rsltPage04
            // 
            this.rsltPage04.BackColor = System.Drawing.SystemColors.WindowText;
            this.rsltPage04.Controls.Add(this.dG_table04);
            this.rsltPage04.Location = new System.Drawing.Point(4, 28);
            this.rsltPage04.Name = "rsltPage04";
            this.rsltPage04.Size = new System.Drawing.Size(787, 108);
            this.rsltPage04.TabIndex = 3;
            this.rsltPage04.Text = "結果(4)";
            this.rsltPage04.UseVisualStyleBackColor = true;
            // 
            // dG_table04
            // 
            this.dG_table04.AllowUserToOrderColumns = true;
            this.dG_table04.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dG_table04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dG_table04.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_table04.Location = new System.Drawing.Point(0, 0);
            this.dG_table04.Name = "dG_table04";
            this.dG_table04.RowTemplate.Height = 24;
            this.dG_table04.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_table04.Size = new System.Drawing.Size(787, 108);
            this.dG_table04.TabIndex = 9;
            // 
            // GB_top
            // 
            this.GB_top.Controls.Add(this.LLB_viewSql);
            this.GB_top.Controls.Add(this.CB_rollback);
            this.GB_top.Controls.Add(this.TB_maxrow);
            this.GB_top.Controls.Add(this.CB_restrict);
            this.GB_top.Controls.Add(this.LLB_col);
            this.GB_top.Controls.Add(this.LLB_dquery);
            this.GB_top.Controls.Add(this.LLB_constraint);
            this.GB_top.Controls.Add(this.LLB_refresh);
            this.GB_top.Controls.Add(this.LB_07);
            this.GB_top.Controls.Add(this.CB_sqlstyle);
            this.GB_top.Controls.Add(this.LLB_01);
            this.GB_top.Controls.Add(this.LB_04);
            this.GB_top.Controls.Add(this.CB_tablename);
            this.GB_top.Controls.Add(this.BT_add1);
            this.GB_top.Controls.Add(this.LB_05);
            this.GB_top.Controls.Add(this.CLB_column);
            this.GB_top.Controls.Add(this.LLB_03);
            this.GB_top.Controls.Add(this.LLB_04);
            this.GB_top.Location = new System.Drawing.Point(252, 25);
            this.GB_top.Margin = new System.Windows.Forms.Padding(1);
            this.GB_top.Name = "GB_top";
            this.GB_top.Padding = new System.Windows.Forms.Padding(1);
            this.GB_top.Size = new System.Drawing.Size(567, 151);
            this.GB_top.TabIndex = 45;
            this.GB_top.TabStop = false;
            // 
            // LLB_viewSql
            // 
            this.LLB_viewSql.AutoSize = true;
            this.LLB_viewSql.Enabled = false;
            this.LLB_viewSql.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_viewSql.Location = new System.Drawing.Point(158, 106);
            this.LLB_viewSql.Name = "LLB_viewSql";
            this.LLB_viewSql.Size = new System.Drawing.Size(40, 16);
            this.LLB_viewSql.TabIndex = 50;
            this.LLB_viewSql.TabStop = true;
            this.LLB_viewSql.Text = "(檢視)";
            this.LLB_viewSql.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_viewSql_LinkClicked);
            // 
            // CB_rollback
            // 
            this.CB_rollback.AutoSize = true;
            this.CB_rollback.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_rollback.Location = new System.Drawing.Point(67, 106);
            this.CB_rollback.Name = "CB_rollback";
            this.CB_rollback.Size = new System.Drawing.Size(99, 20);
            this.CB_rollback.TabIndex = 49;
            this.CB_rollback.Text = "啟用資料還原";
            this.CB_rollback.UseVisualStyleBackColor = true;
            this.CB_rollback.CheckedChanged += new System.EventHandler(this.CB_rollback_CheckedChanged);
            // 
            // TB_maxrow
            // 
            this.TB_maxrow.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TB_maxrow.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_maxrow.ForeColor = System.Drawing.Color.DarkGreen;
            this.TB_maxrow.Location = new System.Drawing.Point(204, 125);
            this.TB_maxrow.Name = "TB_maxrow";
            this.TB_maxrow.Size = new System.Drawing.Size(45, 22);
            this.TB_maxrow.TabIndex = 48;
            this.TB_maxrow.Text = "1000";
            // 
            // CB_restrict
            // 
            this.CB_restrict.AutoSize = true;
            this.CB_restrict.Checked = true;
            this.CB_restrict.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_restrict.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_restrict.Location = new System.Drawing.Point(66, 127);
            this.CB_restrict.Name = "CB_restrict";
            this.CB_restrict.Size = new System.Drawing.Size(138, 20);
            this.CB_restrict.TabIndex = 47;
            this.CB_restrict.Text = "只顯示最多資料筆數:";
            this.CB_restrict.UseVisualStyleBackColor = true;
            // 
            // LLB_col
            // 
            this.LLB_col.AutoSize = true;
            this.LLB_col.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_col.Location = new System.Drawing.Point(64, 72);
            this.LLB_col.Name = "LLB_col";
            this.LLB_col.Size = new System.Drawing.Size(65, 16);
            this.LLB_col.TabIndex = 46;
            this.LLB_col.TabStop = true;
            this.LLB_col.Text = "欄位資訊...";
            this.LLB_col.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_col_LinkClicked);
            // 
            // LLB_dquery
            // 
            this.LLB_dquery.AutoSize = true;
            this.LLB_dquery.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_dquery.Location = new System.Drawing.Point(201, 72);
            this.LLB_dquery.Name = "LLB_dquery";
            this.LLB_dquery.Size = new System.Drawing.Size(77, 16);
            this.LLB_dquery.TabIndex = 45;
            this.LLB_dquery.TabStop = true;
            this.LLB_dquery.Text = "直接查詢(F6)";
            this.LLB_dquery.Click += new System.EventHandler(this.tsmi_201_Click);
            // 
            // LLB_constraint
            // 
            this.LLB_constraint.AutoSize = true;
            this.LLB_constraint.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_constraint.Location = new System.Drawing.Point(133, 72);
            this.LLB_constraint.Name = "LLB_constraint";
            this.LLB_constraint.Size = new System.Drawing.Size(65, 16);
            this.LLB_constraint.TabIndex = 44;
            this.LLB_constraint.TabStop = true;
            this.LLB_constraint.Text = "更多資訊...";
            this.LLB_constraint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_constraint_LinkClicked);
            // 
            // LLB_refresh
            // 
            this.LLB_refresh.AutoSize = true;
            this.LLB_refresh.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_refresh.Location = new System.Drawing.Point(303, 48);
            this.LLB_refresh.Name = "LLB_refresh";
            this.LLB_refresh.Size = new System.Drawing.Size(32, 16);
            this.LLB_refresh.TabIndex = 33;
            this.LLB_refresh.TabStop = true;
            this.LLB_refresh.Text = "重整";
            this.LLB_refresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_refresh_LinkClicked);
            // 
            // LB_07
            // 
            this.LB_07.AutoSize = true;
            this.LB_07.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_07.Location = new System.Drawing.Point(9, 26);
            this.LB_07.Name = "LB_07";
            this.LB_07.Size = new System.Drawing.Size(53, 15);
            this.LB_07.TabIndex = 32;
            this.LB_07.Text = "SQL類型:";
            // 
            // CB_sqlstyle
            // 
            this.CB_sqlstyle.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_sqlstyle.ForeColor = System.Drawing.Color.Red;
            this.CB_sqlstyle.FormattingEnabled = true;
            this.CB_sqlstyle.Items.AddRange(new object[] {
            "SELECT",
            "CREATE",
            "INSERT",
            "DELETE",
            "UPDATE",
            "TRUNCATE",
            "DROP",
            "查看欄位型態長度"});
            this.CB_sqlstyle.Location = new System.Drawing.Point(65, 21);
            this.CB_sqlstyle.Name = "CB_sqlstyle";
            this.CB_sqlstyle.Size = new System.Drawing.Size(145, 24);
            this.CB_sqlstyle.TabIndex = 31;
            // 
            // LLB_01
            // 
            this.LLB_01.AutoSize = true;
            this.LLB_01.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_01.Location = new System.Drawing.Point(303, 64);
            this.LLB_01.Name = "LLB_01";
            this.LLB_01.Size = new System.Drawing.Size(32, 16);
            this.LLB_01.TabIndex = 30;
            this.LLB_01.TabStop = true;
            this.LLB_01.Text = "加入";
            this.LLB_01.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_01_LinkClicked);
            // 
            // LB_04
            // 
            this.LB_04.AutoSize = true;
            this.LB_04.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_04.Location = new System.Drawing.Point(7, 55);
            this.LB_04.Name = "LB_04";
            this.LB_04.Size = new System.Drawing.Size(54, 15);
            this.LB_04.TabIndex = 10;
            this.LB_04.Text = "表格名稱:";
            // 
            // CB_tablename
            // 
            this.CB_tablename.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_tablename.FormattingEnabled = true;
            this.CB_tablename.Location = new System.Drawing.Point(66, 49);
            this.CB_tablename.Name = "CB_tablename";
            this.CB_tablename.Size = new System.Drawing.Size(237, 24);
            this.CB_tablename.TabIndex = 11;
            this.CB_tablename.SelectedIndexChanged += new System.EventHandler(this.CB_tablename_SelectedIndexChanged);
            this.CB_tablename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // BT_add1
            // 
            this.BT_add1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_add1.Location = new System.Drawing.Point(521, 41);
            this.BT_add1.Name = "BT_add1";
            this.BT_add1.Size = new System.Drawing.Size(41, 94);
            this.BT_add1.TabIndex = 28;
            this.BT_add1.Text = "加入";
            this.BT_add1.UseVisualStyleBackColor = true;
            this.BT_add1.Click += new System.EventHandler(this.BT_add1_Click);
            // 
            // LB_05
            // 
            this.LB_05.AutoSize = true;
            this.LB_05.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_05.Location = new System.Drawing.Point(339, 22);
            this.LB_05.Name = "LB_05";
            this.LB_05.Size = new System.Drawing.Size(51, 15);
            this.LB_05.TabIndex = 13;
            this.LB_05.Text = "Column:";
            // 
            // CLB_column
            // 
            this.CLB_column.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CLB_column.ForeColor = System.Drawing.Color.DarkGreen;
            this.CLB_column.FormattingEnabled = true;
            this.CLB_column.Location = new System.Drawing.Point(341, 41);
            this.CLB_column.Name = "CLB_column";
            this.CLB_column.Size = new System.Drawing.Size(178, 94);
            this.CLB_column.TabIndex = 19;
            // 
            // LLB_03
            // 
            this.LLB_03.AutoSize = true;
            this.LLB_03.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_03.Location = new System.Drawing.Point(453, 21);
            this.LLB_03.Name = "LLB_03";
            this.LLB_03.Size = new System.Drawing.Size(32, 16);
            this.LLB_03.TabIndex = 22;
            this.LLB_03.TabStop = true;
            this.LLB_03.Text = "全選";
            this.LLB_03.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_03_LinkClicked);
            // 
            // LLB_04
            // 
            this.LLB_04.AutoSize = true;
            this.LLB_04.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.LLB_04.Location = new System.Drawing.Point(491, 21);
            this.LLB_04.Name = "LLB_04";
            this.LLB_04.Size = new System.Drawing.Size(32, 16);
            this.LLB_04.TabIndex = 23;
            this.LLB_04.TabStop = true;
            this.LLB_04.Text = "取消";
            this.LLB_04.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_04_LinkClicked);
            // 
            // GB_db
            // 
            this.GB_db.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GB_db.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.bayonetta01;
            this.GB_db.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GB_db.Controls.Add(this.BT_conn);
            this.GB_db.Controls.Add(this.LB_HN);
            this.GB_db.Controls.Add(this.TB_host);
            this.GB_db.Controls.Add(this.LB_OWNER);
            this.GB_db.Controls.Add(this.TB_owner);
            this.GB_db.Controls.Add(this.LB_PD);
            this.GB_db.Controls.Add(this.TB_pwd);
            this.GB_db.Controls.Add(this.LLB_edit01);
            this.GB_db.Controls.Add(this.LB_QL);
            this.GB_db.Controls.Add(this.CB_quickload);
            this.GB_db.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GB_db.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_db.Location = new System.Drawing.Point(27, 25);
            this.GB_db.Name = "GB_db";
            this.GB_db.Size = new System.Drawing.Size(221, 151);
            this.GB_db.TabIndex = 53;
            this.GB_db.TabStop = false;
            // 
            // BT_conn
            // 
            this.BT_conn.BackColor = System.Drawing.Color.Yellow;
            this.BT_conn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_conn.Image = ((System.Drawing.Image)(resources.GetObject("BT_conn.Image")));
            this.BT_conn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BT_conn.Location = new System.Drawing.Point(169, 16);
            this.BT_conn.Name = "BT_conn";
            this.BT_conn.Size = new System.Drawing.Size(40, 45);
            this.BT_conn.TabIndex = 50;
            this.BT_conn.Text = "連線";
            this.BT_conn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BT_conn.UseVisualStyleBackColor = false;
            this.BT_conn.Click += new System.EventHandler(this.tsmi_1_1_Click);
            // 
            // LB_HN
            // 
            this.LB_HN.AutoSize = true;
            this.LB_HN.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_HN.Location = new System.Drawing.Point(10, 69);
            this.LB_HN.Name = "LB_HN";
            this.LB_HN.Size = new System.Drawing.Size(72, 16);
            this.LB_HN.TabIndex = 41;
            this.LB_HN.Text = "Host name:";
            // 
            // TB_host
            // 
            this.TB_host.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_host.ForeColor = System.Drawing.Color.Brown;
            this.TB_host.Location = new System.Drawing.Point(90, 67);
            this.TB_host.Name = "TB_host";
            this.TB_host.Size = new System.Drawing.Size(116, 23);
            this.TB_host.TabIndex = 42;
            // 
            // LB_OWNER
            // 
            this.LB_OWNER.AutoSize = true;
            this.LB_OWNER.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_OWNER.Location = new System.Drawing.Point(10, 95);
            this.LB_OWNER.Name = "LB_OWNER";
            this.LB_OWNER.Size = new System.Drawing.Size(51, 16);
            this.LB_OWNER.TabIndex = 43;
            this.LB_OWNER.Text = "Owner :";
            // 
            // TB_owner
            // 
            this.TB_owner.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_owner.ForeColor = System.Drawing.Color.Brown;
            this.TB_owner.Location = new System.Drawing.Point(90, 93);
            this.TB_owner.Name = "TB_owner";
            this.TB_owner.Size = new System.Drawing.Size(116, 23);
            this.TB_owner.TabIndex = 44;
            // 
            // LB_PD
            // 
            this.LB_PD.AutoSize = true;
            this.LB_PD.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_PD.Location = new System.Drawing.Point(10, 120);
            this.LB_PD.Name = "LB_PD";
            this.LB_PD.Size = new System.Drawing.Size(67, 16);
            this.LB_PD.TabIndex = 45;
            this.LB_PD.Text = "Password :";
            // 
            // TB_pwd
            // 
            this.TB_pwd.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TB_pwd.ForeColor = System.Drawing.Color.Brown;
            this.TB_pwd.Location = new System.Drawing.Point(90, 119);
            this.TB_pwd.Name = "TB_pwd";
            this.TB_pwd.PasswordChar = '*';
            this.TB_pwd.Size = new System.Drawing.Size(116, 23);
            this.TB_pwd.TabIndex = 46;
            // 
            // LLB_edit01
            // 
            this.LLB_edit01.AutoSize = true;
            this.LLB_edit01.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LLB_edit01.Location = new System.Drawing.Point(119, 14);
            this.LLB_edit01.Name = "LLB_edit01";
            this.LLB_edit01.Size = new System.Drawing.Size(42, 17);
            this.LLB_edit01.TabIndex = 49;
            this.LLB_edit01.TabStop = true;
            this.LLB_edit01.Text = "(編輯)";
            this.LLB_edit01.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LB_QL
            // 
            this.LB_QL.AutoSize = true;
            this.LB_QL.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_QL.Location = new System.Drawing.Point(10, 15);
            this.LB_QL.Name = "LB_QL";
            this.LB_QL.Size = new System.Drawing.Size(78, 16);
            this.LB_QL.TabIndex = 47;
            this.LB_QL.Text = "Quick Load :";
            // 
            // CB_quickload
            // 
            this.CB_quickload.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_quickload.ForeColor = System.Drawing.Color.Red;
            this.CB_quickload.FormattingEnabled = true;
            this.CB_quickload.Location = new System.Drawing.Point(15, 34);
            this.CB_quickload.Name = "CB_quickload";
            this.CB_quickload.Size = new System.Drawing.Size(148, 24);
            this.CB_quickload.TabIndex = 48;
            this.CB_quickload.SelectedIndexChanged += new System.EventHandler(this.CB_quickload_SelectedIndexChanged);
            // 
            // BT_down2
            // 
            this.BT_down2.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.down;
            this.BT_down2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_down2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_down2.Location = new System.Drawing.Point(826, 446);
            this.BT_down2.Name = "BT_down2";
            this.BT_down2.Size = new System.Drawing.Size(20, 20);
            this.BT_down2.TabIndex = 51;
            this.BT_down2.UseVisualStyleBackColor = true;
            this.BT_down2.Click += new System.EventHandler(this.BT_down2_Click);
            // 
            // BT_top2
            // 
            this.BT_top2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_top2.BackgroundImage")));
            this.BT_top2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_top2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_top2.Location = new System.Drawing.Point(826, 447);
            this.BT_top2.Name = "BT_top2";
            this.BT_top2.Size = new System.Drawing.Size(20, 20);
            this.BT_top2.TabIndex = 50;
            this.BT_top2.UseVisualStyleBackColor = true;
            this.BT_top2.Visible = false;
            this.BT_top2.Click += new System.EventHandler(this.BT_top2_Click);
            // 
            // BT_left
            // 
            this.BT_left.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.left;
            this.BT_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_left.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_left.Location = new System.Drawing.Point(825, 205);
            this.BT_left.Name = "BT_left";
            this.BT_left.Size = new System.Drawing.Size(20, 20);
            this.BT_left.TabIndex = 49;
            this.BT_left.UseVisualStyleBackColor = true;
            this.BT_left.Visible = false;
            this.BT_left.Click += new System.EventHandler(this.BT_left_Click);
            // 
            // BT_right
            // 
            this.BT_right.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.right;
            this.BT_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_right.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_right.Location = new System.Drawing.Point(826, 205);
            this.BT_right.Name = "BT_right";
            this.BT_right.Size = new System.Drawing.Size(20, 20);
            this.BT_right.TabIndex = 48;
            this.BT_right.UseVisualStyleBackColor = true;
            this.BT_right.Click += new System.EventHandler(this.BT_right_Click);
            // 
            // BT_top
            // 
            this.BT_top.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BT_top.BackgroundImage")));
            this.BT_top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_top.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_top.Location = new System.Drawing.Point(826, 156);
            this.BT_top.Name = "BT_top";
            this.BT_top.Size = new System.Drawing.Size(20, 20);
            this.BT_top.TabIndex = 47;
            this.BT_top.UseVisualStyleBackColor = true;
            this.BT_top.Click += new System.EventHandler(this.BT_top_Click);
            // 
            // BT_down
            // 
            this.BT_down.BackgroundImage = global::JB_EzOracleSQL.Properties.Resources.down;
            this.BT_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT_down.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_down.Location = new System.Drawing.Point(826, 156);
            this.BT_down.Name = "BT_down";
            this.BT_down.Size = new System.Drawing.Size(20, 20);
            this.BT_down.TabIndex = 46;
            this.BT_down.UseVisualStyleBackColor = true;
            this.BT_down.Click += new System.EventHandler(this.BT_down_Click);
            // 
            // BT_query
            // 
            this.BT_query.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BT_query.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_query.Image = ((System.Drawing.Image)(resources.GetObject("BT_query.Image")));
            this.BT_query.Location = new System.Drawing.Point(520, 448);
            this.BT_query.Name = "BT_query";
            this.BT_query.Size = new System.Drawing.Size(195, 23);
            this.BT_query.TabIndex = 6;
            this.BT_query.Text = "查詢(F5)";
            this.BT_query.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BT_query.UseVisualStyleBackColor = false;
            this.BT_query.Click += new System.EventHandler(this.BT_query_Click);
            // 
            // LLB_EditBigSql
            // 
            this.LLB_EditBigSql.AutoSize = true;
            this.LLB_EditBigSql.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LLB_EditBigSql.Location = new System.Drawing.Point(325, 451);
            this.LLB_EditBigSql.Name = "LLB_EditBigSql";
            this.LLB_EditBigSql.Size = new System.Drawing.Size(76, 16);
            this.LLB_EditBigSql.TabIndex = 54;
            this.LLB_EditBigSql.TabStop = true;
            this.LLB_EditBigSql.Text = "放大編輯(W)";
            this.LLB_EditBigSql.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_EditBigSql_LinkClicked);
            // 
            // LB_cnt
            // 
            this.LB_cnt.AutoSize = true;
            this.LB_cnt.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_cnt.Location = new System.Drawing.Point(29, 453);
            this.LB_cnt.Name = "LB_cnt";
            this.LB_cnt.Size = new System.Drawing.Size(56, 16);
            this.LB_cnt.TabIndex = 55;
            this.LB_cnt.Text = "顯示筆數";
            // 
            // llb_newpage
            // 
            this.llb_newpage.AutoSize = true;
            this.llb_newpage.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.llb_newpage.Location = new System.Drawing.Point(245, 451);
            this.llb_newpage.Name = "llb_newpage";
            this.llb_newpage.Size = new System.Drawing.Size(74, 16);
            this.llb_newpage.TabIndex = 56;
            this.llb_newpage.TabStop = true;
            this.llb_newpage.Text = "新增分頁(N)";
            this.llb_newpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_newpage_LinkClicked);
            // 
            // tabControl_Func
            // 
            this.tabControl_Func.Controls.Add(this.tP_SpeWord);
            this.tabControl_Func.Controls.Add(this.tP_Msg);
            this.tabControl_Func.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl_Func.Location = new System.Drawing.Point(27, 182);
            this.tabControl_Func.Name = "tabControl_Func";
            this.tabControl_Func.SelectedIndex = 0;
            this.tabControl_Func.Size = new System.Drawing.Size(211, 262);
            this.tabControl_Func.TabIndex = 57;
            // 
            // tP_SpeWord
            // 
            this.tP_SpeWord.Controls.Add(this.GB_sp);
            this.tP_SpeWord.Location = new System.Drawing.Point(4, 24);
            this.tP_SpeWord.Name = "tP_SpeWord";
            this.tP_SpeWord.Padding = new System.Windows.Forms.Padding(3);
            this.tP_SpeWord.Size = new System.Drawing.Size(203, 234);
            this.tP_SpeWord.TabIndex = 0;
            this.tP_SpeWord.Text = "特殊字";
            this.tP_SpeWord.UseVisualStyleBackColor = true;
            // 
            // GB_sp
            // 
            this.GB_sp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GB_sp.Controls.Add(this.LLB_refreshkeyword);
            this.GB_sp.Controls.Add(this.LLB_edit02);
            this.GB_sp.Controls.Add(this.LB_keyword);
            this.GB_sp.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_sp.Location = new System.Drawing.Point(-4, 6);
            this.GB_sp.Name = "GB_sp";
            this.GB_sp.Size = new System.Drawing.Size(200, 224);
            this.GB_sp.TabIndex = 28;
            this.GB_sp.TabStop = false;
            this.GB_sp.Text = "Double click to add";
            // 
            // LLB_refreshkeyword
            // 
            this.LLB_refreshkeyword.AutoSize = true;
            this.LLB_refreshkeyword.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LLB_refreshkeyword.Location = new System.Drawing.Point(154, 0);
            this.LLB_refreshkeyword.Name = "LLB_refreshkeyword";
            this.LLB_refreshkeyword.Size = new System.Drawing.Size(42, 17);
            this.LLB_refreshkeyword.TabIndex = 39;
            this.LLB_refreshkeyword.TabStop = true;
            this.LLB_refreshkeyword.Text = "(重整)";
            this.LLB_refreshkeyword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_refreshkeyword_LinkClicked);
            // 
            // LLB_edit02
            // 
            this.LLB_edit02.AutoSize = true;
            this.LLB_edit02.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LLB_edit02.Location = new System.Drawing.Point(115, 0);
            this.LLB_edit02.Name = "LLB_edit02";
            this.LLB_edit02.Size = new System.Drawing.Size(42, 17);
            this.LLB_edit02.TabIndex = 39;
            this.LLB_edit02.TabStop = true;
            this.LLB_edit02.Text = "(編輯)";
            this.LLB_edit02.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLB_edit02_LinkClicked);
            // 
            // LB_keyword
            // 
            this.LB_keyword.BackColor = System.Drawing.Color.White;
            this.LB_keyword.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_keyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB_keyword.FormattingEnabled = true;
            this.LB_keyword.HorizontalScrollbar = true;
            this.LB_keyword.ItemHeight = 15;
            this.LB_keyword.Location = new System.Drawing.Point(8, 23);
            this.LB_keyword.Name = "LB_keyword";
            this.LB_keyword.Size = new System.Drawing.Size(187, 199);
            this.LB_keyword.TabIndex = 36;
            this.LB_keyword.DoubleClick += new System.EventHandler(this.LB_keyword_DoubleClick);
            // 
            // tP_Msg
            // 
            this.tP_Msg.Controls.Add(this.RTB_SysMsg);
            this.tP_Msg.Location = new System.Drawing.Point(4, 24);
            this.tP_Msg.Name = "tP_Msg";
            this.tP_Msg.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Msg.Size = new System.Drawing.Size(203, 234);
            this.tP_Msg.TabIndex = 1;
            this.tP_Msg.Text = "系統訊息";
            this.tP_Msg.UseVisualStyleBackColor = true;
            // 
            // RTB_SysMsg
            // 
            this.RTB_SysMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RTB_SysMsg.Location = new System.Drawing.Point(3, 6);
            this.RTB_SysMsg.Name = "RTB_SysMsg";
            this.RTB_SysMsg.Size = new System.Drawing.Size(194, 222);
            this.RTB_SysMsg.TabIndex = 0;
            this.RTB_SysMsg.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(849, 504);
            this.Controls.Add(this.tabControl_Func);
            this.Controls.Add(this.llb_newpage);
            this.Controls.Add(this.LB_cnt);
            this.Controls.Add(this.LLB_EditBigSql);
            this.Controls.Add(this.GB_db);
            this.Controls.Add(this.BT_down2);
            this.Controls.Add(this.BT_top2);
            this.Controls.Add(this.BT_left);
            this.Controls.Add(this.BT_right);
            this.Controls.Add(this.BT_top);
            this.Controls.Add(this.BT_down);
            this.Controls.Add(this.GB_top);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.LB_tablename);
            this.Controls.Add(this.StatusStrip01);
            this.Controls.Add(this.BT_excel);
            this.Controls.Add(this.BT_query);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1100, 680);
            this.MinimumSize = new System.Drawing.Size(865, 540);
            this.Name = "MainForm";
            this.Text = "JBEzOracleSQL v2.8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.tabControl.ResumeLayout(false);
            this.tabPage01.ResumeLayout(false);
            this.tabPage02.ResumeLayout(false);
            this.tabPage03.ResumeLayout(false);
            this.tabPage04.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.rsltPage01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG_table01)).EndInit();
            this.rsltPage02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG_table02)).EndInit();
            this.rsltPage03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG_table03)).EndInit();
            this.rsltPage04.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG_table04)).EndInit();
            this.GB_top.ResumeLayout(false);
            this.GB_top.PerformLayout();
            this.GB_db.ResumeLayout(false);
            this.GB_db.PerformLayout();
            this.tabControl_Func.ResumeLayout(false);
            this.tP_SpeWord.ResumeLayout(false);
            this.GB_sp.ResumeLayout(false);
            this.GB_sp.PerformLayout();
            this.tP_Msg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_query;
        private System.Windows.Forms.Button BT_excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label LB_04;
        private System.Windows.Forms.ComboBox CB_tablename;
        private System.Windows.Forms.Label LB_05;
        private System.Windows.Forms.CheckedListBox CLB_column;
        private System.Windows.Forms.LinkLabel LLB_03;
        private System.Windows.Forms.LinkLabel LLB_04;
        private System.Windows.Forms.Button BT_add1;
        private System.Windows.Forms.LinkLabel LLB_01;
        private System.Windows.Forms.ComboBox CB_sqlstyle;
        private System.Windows.Forms.Label LB_07;
        private System.Windows.Forms.LinkLabel LLB_refresh;
        private System.Windows.Forms.StatusStrip StatusStrip01;
        private System.Windows.Forms.ToolStripProgressBar TSPB;
        private System.Windows.Forms.ToolStripStatusLabel TSSL;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ListBox LB_tablename;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage01;
        private System.Windows.Forms.TabPage tabPage02;
        public System.Windows.Forms.RichTextBox RTB01;
        private System.Windows.Forms.TabPage tabPage03;
        private System.Windows.Forms.TabPage tabPage04;
        public System.Windows.Forms.RichTextBox RTB02;
        public System.Windows.Forms.RichTextBox RTB03;
        public System.Windows.Forms.RichTextBox RTB04;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage rsltPage01;
        private System.Windows.Forms.TabPage rsltPage02;
        public System.Windows.Forms.DataGridView dG_table01;
        private System.Windows.Forms.TabPage rsltPage03;
        private System.Windows.Forms.TabPage rsltPage04;
        public System.Windows.Forms.DataGridView dG_table02;
        public System.Windows.Forms.DataGridView dG_table03;
        public System.Windows.Forms.DataGridView dG_table04;
        private System.Windows.Forms.GroupBox GB_top;
        private System.Windows.Forms.Button BT_down;
        private System.Windows.Forms.Button BT_top;
        private System.Windows.Forms.Button BT_right;
        private System.Windows.Forms.Button BT_left;
        private System.Windows.Forms.Button BT_top2;
        private System.Windows.Forms.Button BT_down2;
        private System.Windows.Forms.LinkLabel LLB_constraint;
        private System.Windows.Forms.GroupBox GB_db;
        private System.Windows.Forms.Button BT_conn;
        private System.Windows.Forms.Label LB_HN;
        private System.Windows.Forms.TextBox TB_host;
        private System.Windows.Forms.Label LB_OWNER;
        private System.Windows.Forms.TextBox TB_owner;
        private System.Windows.Forms.Label LB_PD;
        private System.Windows.Forms.TextBox TB_pwd;
        private System.Windows.Forms.LinkLabel LLB_edit01;
        private System.Windows.Forms.Label LB_QL;
        private System.Windows.Forms.ComboBox CB_quickload;
        private System.Windows.Forms.LinkLabel LLB_col;
        private System.Windows.Forms.LinkLabel LLB_dquery;
        private System.Windows.Forms.TextBox TB_maxrow;
        private System.Windows.Forms.CheckBox CB_restrict;
        private System.Windows.Forms.LinkLabel LLB_EditBigSql;
        private System.Windows.Forms.Label LB_cnt;
        private System.Windows.Forms.LinkLabel llb_newpage;
        private System.ComponentModel.BackgroundWorker bgWorker_export;
        private System.Windows.Forms.TabControl tabControl_Func;
        private System.Windows.Forms.TabPage tP_SpeWord;
        private System.Windows.Forms.GroupBox GB_sp;
        private System.Windows.Forms.LinkLabel LLB_refreshkeyword;
        private System.Windows.Forms.LinkLabel LLB_edit02;
        private System.Windows.Forms.ListBox LB_keyword;
        private System.Windows.Forms.TabPage tP_Msg;
        private System.Windows.Forms.RichTextBox RTB_SysMsg;
        private System.Windows.Forms.CheckBox CB_rollback;
        private System.Windows.Forms.LinkLabel LLB_viewSql;

    }
}

