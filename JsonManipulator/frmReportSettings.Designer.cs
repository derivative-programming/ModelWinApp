
namespace JsonManipulator
{
    partial class frmReportSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabPage tabSettings;
            this.dataProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFilters = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlFiltersRight = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridFilters = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFiltersLeft = new System.Windows.Forms.Panel();
            this.pnlFitlerLeftTop = new System.Windows.Forms.Panel();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.pnlFiltersLeftBottom = new System.Windows.Forms.Panel();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnFilterMoveUp = new System.Windows.Forms.Button();
            this.btnFilterMoveDown = new System.Windows.Forms.Button();
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlColumnsRight = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridColumns = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlColumnsLeft = new System.Windows.Forms.Panel();
            this.pnlColumnsLeftTop = new System.Windows.Forms.Panel();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.pnlColumnsLeftBottom = new System.Windows.Forms.Panel();
            this.btnCopyList = new System.Windows.Forms.Button();
            this.chkSubscribeToOwnerObject = new System.Windows.Forms.CheckBox();
            this.chkSubscribeToTargetChild = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddColumnButton = new System.Windows.Forms.Button();
            this.btnColumnsAdd = new System.Windows.Forms.Button();
            this.btnColumnsMoveUp = new System.Windows.Forms.Button();
            this.btnColumnsMoveDown = new System.Windows.Forms.Button();
            this.tabButtons = new System.Windows.Forms.TabPage();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlButtonsRight = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridButtons = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtonsLeft = new System.Windows.Forms.Panel();
            this.pnlButtonsLeftTop = new System.Windows.Forms.Panel();
            this.lstButtons = new System.Windows.Forms.ListBox();
            this.pnlButtonsLeftBottom = new System.Windows.Forms.Panel();
            this.btnFollowButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddMultiSelectButton = new System.Windows.Forms.Button();
            this.btnButtonMoveUp = new System.Windows.Forms.Button();
            this.btnButtonMoveDown = new System.Windows.Forms.Button();
            this.btnButtonAdd = new System.Windows.Forms.Button();
            this.tabJSON = new System.Windows.Forms.TabPage();
            this.rtbJSON = new System.Windows.Forms.RichTextBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.btnFollow2 = new System.Windows.Forms.Button();
            this.chkVisibleColumnsOnly = new System.Windows.Forms.CheckBox();
            tabSettings = new System.Windows.Forms.TabPage();
            tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFilters.SuspendLayout();
            this.pnlFiltersRight.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilters)).BeginInit();
            this.pnlFiltersLeft.SuspendLayout();
            this.pnlFitlerLeftTop.SuspendLayout();
            this.pnlFiltersLeftBottom.SuspendLayout();
            this.tabColumns.SuspendLayout();
            this.pnlColumnsRight.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).BeginInit();
            this.pnlColumnsLeft.SuspendLayout();
            this.pnlColumnsLeftTop.SuspendLayout();
            this.pnlColumnsLeftBottom.SuspendLayout();
            this.tabButtons.SuspendLayout();
            this.pnlButtonsRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).BeginInit();
            this.pnlButtonsLeft.SuspendLayout();
            this.pnlButtonsLeftTop.SuspendLayout();
            this.pnlButtonsLeftBottom.SuspendLayout();
            this.tabJSON.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(this.dataProperties);
            tabSettings.Location = new System.Drawing.Point(4, 25);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new System.Windows.Forms.Padding(3);
            tabSettings.Size = new System.Drawing.Size(786, 446);
            tabSettings.TabIndex = 0;
            tabSettings.Text = "Settings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // dataProperties
            // 
            this.dataProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProperties.Location = new System.Drawing.Point(3, 3);
            this.dataProperties.MultiSelect = false;
            this.dataProperties.Name = "dataProperties";
            this.dataProperties.RowHeadersVisible = false;
            this.dataProperties.RowHeadersWidth = 51;
            this.dataProperties.Size = new System.Drawing.Size(780, 440);
            this.dataProperties.TabIndex = 1;
            this.dataProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellClick);
            this.dataProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellEnter);
            this.dataProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Property";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(tabSettings);
            this.tabControl1.Controls.Add(this.tabFilters);
            this.tabControl1.Controls.Add(this.tabColumns);
            this.tabControl1.Controls.Add(this.tabButtons);
            this.tabControl1.Controls.Add(this.tabJSON);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 475);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabFilters
            // 
            this.tabFilters.Controls.Add(this.splitter1);
            this.tabFilters.Controls.Add(this.pnlFiltersRight);
            this.tabFilters.Controls.Add(this.pnlFiltersLeft);
            this.tabFilters.Location = new System.Drawing.Point(4, 25);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabFilters.Size = new System.Drawing.Size(786, 446);
            this.tabFilters.TabIndex = 1;
            this.tabFilters.Text = "Filters";
            this.tabFilters.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(203, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 440);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // pnlFiltersRight
            // 
            this.pnlFiltersRight.Controls.Add(this.groupBox3);
            this.pnlFiltersRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltersRight.Location = new System.Drawing.Point(203, 3);
            this.pnlFiltersRight.Name = "pnlFiltersRight";
            this.pnlFiltersRight.Size = new System.Drawing.Size(580, 440);
            this.pnlFiltersRight.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridFilters);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(580, 440);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control Properties";
            // 
            // gridFilters
            // 
            this.gridFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gridFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFilters.Location = new System.Drawing.Point(3, 18);
            this.gridFilters.MultiSelect = false;
            this.gridFilters.Name = "gridFilters";
            this.gridFilters.RowHeadersVisible = false;
            this.gridFilters.RowHeadersWidth = 51;
            this.gridFilters.Size = new System.Drawing.Size(574, 419);
            this.gridFilters.TabIndex = 5;
            this.gridFilters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFilters_CellClick);
            this.gridFilters.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFilters_CellEnter);
            this.gridFilters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFilters_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Property";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // pnlFiltersLeft
            // 
            this.pnlFiltersLeft.Controls.Add(this.pnlFitlerLeftTop);
            this.pnlFiltersLeft.Controls.Add(this.pnlFiltersLeftBottom);
            this.pnlFiltersLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFiltersLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltersLeft.Name = "pnlFiltersLeft";
            this.pnlFiltersLeft.Size = new System.Drawing.Size(200, 440);
            this.pnlFiltersLeft.TabIndex = 11;
            // 
            // pnlFitlerLeftTop
            // 
            this.pnlFitlerLeftTop.Controls.Add(this.lstFilters);
            this.pnlFitlerLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFitlerLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFitlerLeftTop.Name = "pnlFitlerLeftTop";
            this.pnlFitlerLeftTop.Size = new System.Drawing.Size(200, 340);
            this.pnlFitlerLeftTop.TabIndex = 5;
            // 
            // lstFilters
            // 
            this.lstFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 16;
            this.lstFilters.Location = new System.Drawing.Point(0, 0);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstFilters.Size = new System.Drawing.Size(200, 340);
            this.lstFilters.TabIndex = 1;
            this.lstFilters.SelectedIndexChanged += new System.EventHandler(this.lstFilters_SelectedIndexChanged);
            // 
            // pnlFiltersLeftBottom
            // 
            this.pnlFiltersLeftBottom.Controls.Add(this.btnAddFilter);
            this.pnlFiltersLeftBottom.Controls.Add(this.btnFilterMoveUp);
            this.pnlFiltersLeftBottom.Controls.Add(this.btnFilterMoveDown);
            this.pnlFiltersLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltersLeftBottom.Location = new System.Drawing.Point(0, 340);
            this.pnlFiltersLeftBottom.Name = "pnlFiltersLeftBottom";
            this.pnlFiltersLeftBottom.Size = new System.Drawing.Size(200, 100);
            this.pnlFiltersLeftBottom.TabIndex = 6;
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(3, 3);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 2;
            this.btnAddFilter.Text = "&Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // btnFilterMoveUp
            // 
            this.btnFilterMoveUp.Location = new System.Drawing.Point(3, 32);
            this.btnFilterMoveUp.Name = "btnFilterMoveUp";
            this.btnFilterMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFilterMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnFilterMoveUp.TabIndex = 3;
            this.btnFilterMoveUp.Text = "Move &Up";
            this.btnFilterMoveUp.UseVisualStyleBackColor = true;
            this.btnFilterMoveUp.Click += new System.EventHandler(this.btnFilterMoveUp_Click);
            // 
            // btnFilterMoveDown
            // 
            this.btnFilterMoveDown.Location = new System.Drawing.Point(3, 61);
            this.btnFilterMoveDown.Name = "btnFilterMoveDown";
            this.btnFilterMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFilterMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnFilterMoveDown.TabIndex = 4;
            this.btnFilterMoveDown.Text = "Move &Down";
            this.btnFilterMoveDown.UseVisualStyleBackColor = true;
            this.btnFilterMoveDown.Click += new System.EventHandler(this.btnFilterMoveDown_Click);
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.splitter2);
            this.tabColumns.Controls.Add(this.pnlColumnsRight);
            this.tabColumns.Controls.Add(this.pnlColumnsLeft);
            this.tabColumns.Location = new System.Drawing.Point(4, 25);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Size = new System.Drawing.Size(786, 446);
            this.tabColumns.TabIndex = 2;
            this.tabColumns.Text = "Columns";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(219, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 446);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // pnlColumnsRight
            // 
            this.pnlColumnsRight.Controls.Add(this.groupBox2);
            this.pnlColumnsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumnsRight.Location = new System.Drawing.Point(219, 0);
            this.pnlColumnsRight.Name = "pnlColumnsRight";
            this.pnlColumnsRight.Size = new System.Drawing.Size(567, 446);
            this.pnlColumnsRight.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridColumns);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 446);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control Properties";
            // 
            // gridColumns
            // 
            this.gridColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColumns.Location = new System.Drawing.Point(3, 18);
            this.gridColumns.MultiSelect = false;
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.RowHeadersVisible = false;
            this.gridColumns.RowHeadersWidth = 51;
            this.gridColumns.Size = new System.Drawing.Size(561, 347);
            this.gridColumns.TabIndex = 5;
            this.gridColumns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellClick);
            this.gridColumns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellContentClick);
            this.gridColumns.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellEnter);
            this.gridColumns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Property";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(3, 365);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(561, 78);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "If you are subscribed to an object\'s props, then will be added when the \'Model AI" +
    " Processing\' service is performed.";
            // 
            // pnlColumnsLeft
            // 
            this.pnlColumnsLeft.Controls.Add(this.pnlColumnsLeftTop);
            this.pnlColumnsLeft.Controls.Add(this.pnlColumnsLeftBottom);
            this.pnlColumnsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColumnsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlColumnsLeft.Name = "pnlColumnsLeft";
            this.pnlColumnsLeft.Size = new System.Drawing.Size(219, 446);
            this.pnlColumnsLeft.TabIndex = 6;
            // 
            // pnlColumnsLeftTop
            // 
            this.pnlColumnsLeftTop.Controls.Add(this.lstColumns);
            this.pnlColumnsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumnsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlColumnsLeftTop.Name = "pnlColumnsLeftTop";
            this.pnlColumnsLeftTop.Size = new System.Drawing.Size(219, 163);
            this.pnlColumnsLeftTop.TabIndex = 8;
            // 
            // lstColumns
            // 
            this.lstColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.ItemHeight = 16;
            this.lstColumns.Location = new System.Drawing.Point(0, 0);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(219, 163);
            this.lstColumns.TabIndex = 1;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // pnlColumnsLeftBottom
            // 
            this.pnlColumnsLeftBottom.Controls.Add(this.chkVisibleColumnsOnly);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnFollow2);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnCopyList);
            this.pnlColumnsLeftBottom.Controls.Add(this.chkSubscribeToOwnerObject);
            this.pnlColumnsLeftBottom.Controls.Add(this.chkSubscribeToTargetChild);
            this.pnlColumnsLeftBottom.Controls.Add(this.button1);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnAddColumnButton);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnColumnsAdd);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnColumnsMoveUp);
            this.pnlColumnsLeftBottom.Controls.Add(this.btnColumnsMoveDown);
            this.pnlColumnsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlColumnsLeftBottom.Location = new System.Drawing.Point(0, 163);
            this.pnlColumnsLeftBottom.Name = "pnlColumnsLeftBottom";
            this.pnlColumnsLeftBottom.Size = new System.Drawing.Size(219, 283);
            this.pnlColumnsLeftBottom.TabIndex = 7;
            // 
            // btnCopyList
            // 
            this.btnCopyList.Location = new System.Drawing.Point(5, 200);
            this.btnCopyList.Name = "btnCopyList";
            this.btnCopyList.Size = new System.Drawing.Size(52, 23);
            this.btnCopyList.TabIndex = 9;
            this.btnCopyList.Text = "Copy";
            this.btnCopyList.UseVisualStyleBackColor = true;
            this.btnCopyList.Click += new System.EventHandler(this.btnCopyList_Click);
            // 
            // chkSubscribeToOwnerObject
            // 
            this.chkSubscribeToOwnerObject.AutoSize = true;
            this.chkSubscribeToOwnerObject.Location = new System.Drawing.Point(5, 229);
            this.chkSubscribeToOwnerObject.Name = "chkSubscribeToOwnerObject";
            this.chkSubscribeToOwnerObject.Size = new System.Drawing.Size(245, 21);
            this.chkSubscribeToOwnerObject.TabIndex = 8;
            this.chkSubscribeToOwnerObject.Text = "Subscribe To Owner Object Props";
            this.chkSubscribeToOwnerObject.UseVisualStyleBackColor = true;
            this.chkSubscribeToOwnerObject.CheckedChanged += new System.EventHandler(this.chkSubscribeToOwnerObject_CheckedChanged);
            // 
            // chkSubscribeToTargetChild
            // 
            this.chkSubscribeToTargetChild.AutoSize = true;
            this.chkSubscribeToTargetChild.Location = new System.Drawing.Point(3, 256);
            this.chkSubscribeToTargetChild.Name = "chkSubscribeToTargetChild";
            this.chkSubscribeToTargetChild.Size = new System.Drawing.Size(281, 21);
            this.chkSubscribeToTargetChild.TabIndex = 7;
            this.chkSubscribeToTargetChild.Text = "Subscribe To Target Child Object Props";
            this.chkSubscribeToTargetChild.UseVisualStyleBackColor = true;
            this.chkSubscribeToTargetChild.CheckedChanged += new System.EventHandler(this.chkSubscribeToTargetChild_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Async &Flow Button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddColumnButton
            // 
            this.btnAddColumnButton.Location = new System.Drawing.Point(3, 32);
            this.btnAddColumnButton.Name = "btnAddColumnButton";
            this.btnAddColumnButton.Size = new System.Drawing.Size(136, 23);
            this.btnAddColumnButton.TabIndex = 5;
            this.btnAddColumnButton.Text = "Add Destination &Button";
            this.btnAddColumnButton.UseVisualStyleBackColor = true;
            this.btnAddColumnButton.Click += new System.EventHandler(this.btnAddColumnButton_Click);
            // 
            // btnColumnsAdd
            // 
            this.btnColumnsAdd.Location = new System.Drawing.Point(3, 3);
            this.btnColumnsAdd.Name = "btnColumnsAdd";
            this.btnColumnsAdd.Size = new System.Drawing.Size(136, 23);
            this.btnColumnsAdd.TabIndex = 2;
            this.btnColumnsAdd.Text = "&Add Column";
            this.btnColumnsAdd.UseVisualStyleBackColor = true;
            this.btnColumnsAdd.Click += new System.EventHandler(this.btnColumnsAdd_Click);
            // 
            // btnColumnsMoveUp
            // 
            this.btnColumnsMoveUp.Location = new System.Drawing.Point(3, 142);
            this.btnColumnsMoveUp.Name = "btnColumnsMoveUp";
            this.btnColumnsMoveUp.Size = new System.Drawing.Size(136, 23);
            this.btnColumnsMoveUp.TabIndex = 3;
            this.btnColumnsMoveUp.Text = "Move &Up";
            this.btnColumnsMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnsMoveUp.Click += new System.EventHandler(this.btnColumnsMoveUp_Click);
            // 
            // btnColumnsMoveDown
            // 
            this.btnColumnsMoveDown.Location = new System.Drawing.Point(3, 171);
            this.btnColumnsMoveDown.Name = "btnColumnsMoveDown";
            this.btnColumnsMoveDown.Size = new System.Drawing.Size(136, 23);
            this.btnColumnsMoveDown.TabIndex = 4;
            this.btnColumnsMoveDown.Text = "Move &Down";
            this.btnColumnsMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnsMoveDown.Click += new System.EventHandler(this.btnColumnsMoveDown_Click);
            // 
            // tabButtons
            // 
            this.tabButtons.Controls.Add(this.splitter3);
            this.tabButtons.Controls.Add(this.pnlButtonsRight);
            this.tabButtons.Controls.Add(this.pnlButtonsLeft);
            this.tabButtons.Location = new System.Drawing.Point(4, 25);
            this.tabButtons.Name = "tabButtons";
            this.tabButtons.Size = new System.Drawing.Size(786, 446);
            this.tabButtons.TabIndex = 3;
            this.tabButtons.Text = "Buttons";
            this.tabButtons.UseVisualStyleBackColor = true;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(180, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 446);
            this.splitter3.TabIndex = 5;
            this.splitter3.TabStop = false;
            // 
            // pnlButtonsRight
            // 
            this.pnlButtonsRight.Controls.Add(this.groupBox1);
            this.pnlButtonsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonsRight.Location = new System.Drawing.Point(180, 0);
            this.pnlButtonsRight.Name = "pnlButtonsRight";
            this.pnlButtonsRight.Size = new System.Drawing.Size(606, 446);
            this.pnlButtonsRight.TabIndex = 4;
            this.pnlButtonsRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridButtons);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 446);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button Properties";
            // 
            // gridButtons
            // 
            this.gridButtons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridButtons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.gridButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridButtons.Location = new System.Drawing.Point(3, 18);
            this.gridButtons.MultiSelect = false;
            this.gridButtons.Name = "gridButtons";
            this.gridButtons.RowHeadersVisible = false;
            this.gridButtons.RowHeadersWidth = 51;
            this.gridButtons.Size = new System.Drawing.Size(600, 425);
            this.gridButtons.TabIndex = 3;
            this.gridButtons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellClick);
            this.gridButtons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellContentClick);
            this.gridButtons.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellEnter);
            this.gridButtons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellValueChanged);
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.MinimumWidth = 6;
            this.Property.Name = "Property";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            // 
            // pnlButtonsLeft
            // 
            this.pnlButtonsLeft.Controls.Add(this.pnlButtonsLeftTop);
            this.pnlButtonsLeft.Controls.Add(this.pnlButtonsLeftBottom);
            this.pnlButtonsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtonsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsLeft.Name = "pnlButtonsLeft";
            this.pnlButtonsLeft.Size = new System.Drawing.Size(180, 446);
            this.pnlButtonsLeft.TabIndex = 3;
            // 
            // pnlButtonsLeftTop
            // 
            this.pnlButtonsLeftTop.Controls.Add(this.lstButtons);
            this.pnlButtonsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsLeftTop.Name = "pnlButtonsLeftTop";
            this.pnlButtonsLeftTop.Size = new System.Drawing.Size(180, 249);
            this.pnlButtonsLeftTop.TabIndex = 4;
            // 
            // lstButtons
            // 
            this.lstButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstButtons.FormattingEnabled = true;
            this.lstButtons.ItemHeight = 16;
            this.lstButtons.Location = new System.Drawing.Point(0, 0);
            this.lstButtons.Name = "lstButtons";
            this.lstButtons.Size = new System.Drawing.Size(180, 249);
            this.lstButtons.TabIndex = 1;
            this.lstButtons.SelectedIndexChanged += new System.EventHandler(this.lstButtons_SelectedIndexChanged);
            // 
            // pnlButtonsLeftBottom
            // 
            this.pnlButtonsLeftBottom.Controls.Add(this.btnFollowButton);
            this.pnlButtonsLeftBottom.Controls.Add(this.button2);
            this.pnlButtonsLeftBottom.Controls.Add(this.btnAddMultiSelectButton);
            this.pnlButtonsLeftBottom.Controls.Add(this.btnButtonMoveUp);
            this.pnlButtonsLeftBottom.Controls.Add(this.btnButtonMoveDown);
            this.pnlButtonsLeftBottom.Controls.Add(this.btnButtonAdd);
            this.pnlButtonsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonsLeftBottom.Location = new System.Drawing.Point(0, 249);
            this.pnlButtonsLeftBottom.Name = "pnlButtonsLeftBottom";
            this.pnlButtonsLeftBottom.Size = new System.Drawing.Size(180, 197);
            this.pnlButtonsLeftBottom.TabIndex = 5;
            // 
            // btnFollowButton
            // 
            this.btnFollowButton.Location = new System.Drawing.Point(3, 111);
            this.btnFollowButton.Name = "btnFollowButton";
            this.btnFollowButton.Size = new System.Drawing.Size(169, 23);
            this.btnFollowButton.TabIndex = 9;
            this.btnFollowButton.Text = "&Follow Button";
            this.btnFollowButton.UseVisualStyleBackColor = true;
            this.btnFollowButton.Click += new System.EventHandler(this.btnFollowButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add &Breadcrumb Button";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddMultiSelectButton
            // 
            this.btnAddMultiSelectButton.Location = new System.Drawing.Point(5, 32);
            this.btnAddMultiSelectButton.Name = "btnAddMultiSelectButton";
            this.btnAddMultiSelectButton.Size = new System.Drawing.Size(169, 23);
            this.btnAddMultiSelectButton.TabIndex = 7;
            this.btnAddMultiSelectButton.Text = "Add &Multi-Select Button";
            this.btnAddMultiSelectButton.UseVisualStyleBackColor = true;
            this.btnAddMultiSelectButton.Click += new System.EventHandler(this.btnAddMultiSelectButton_Click);
            // 
            // btnButtonMoveUp
            // 
            this.btnButtonMoveUp.Location = new System.Drawing.Point(3, 140);
            this.btnButtonMoveUp.Name = "btnButtonMoveUp";
            this.btnButtonMoveUp.Size = new System.Drawing.Size(169, 23);
            this.btnButtonMoveUp.TabIndex = 5;
            this.btnButtonMoveUp.Text = "Move &Up";
            this.btnButtonMoveUp.UseVisualStyleBackColor = true;
            this.btnButtonMoveUp.Click += new System.EventHandler(this.btnButtonMoveUp_Click);
            // 
            // btnButtonMoveDown
            // 
            this.btnButtonMoveDown.Location = new System.Drawing.Point(5, 169);
            this.btnButtonMoveDown.Name = "btnButtonMoveDown";
            this.btnButtonMoveDown.Size = new System.Drawing.Size(169, 23);
            this.btnButtonMoveDown.TabIndex = 6;
            this.btnButtonMoveDown.Text = "Move &Down";
            this.btnButtonMoveDown.UseVisualStyleBackColor = true;
            this.btnButtonMoveDown.Click += new System.EventHandler(this.btnButtonMoveDown_Click);
            // 
            // btnButtonAdd
            // 
            this.btnButtonAdd.Location = new System.Drawing.Point(5, 3);
            this.btnButtonAdd.Name = "btnButtonAdd";
            this.btnButtonAdd.Size = new System.Drawing.Size(169, 23);
            this.btnButtonAdd.TabIndex = 2;
            this.btnButtonAdd.Text = "&Add Button";
            this.btnButtonAdd.UseVisualStyleBackColor = true;
            this.btnButtonAdd.Click += new System.EventHandler(this.btnButtonAdd_Click);
            // 
            // tabJSON
            // 
            this.tabJSON.Controls.Add(this.rtbJSON);
            this.tabJSON.Location = new System.Drawing.Point(4, 25);
            this.tabJSON.Name = "tabJSON";
            this.tabJSON.Size = new System.Drawing.Size(786, 446);
            this.tabJSON.TabIndex = 4;
            this.tabJSON.Text = "JSON";
            this.tabJSON.UseVisualStyleBackColor = true;
            // 
            // rtbJSON
            // 
            this.rtbJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbJSON.Location = new System.Drawing.Point(0, 0);
            this.rtbJSON.Name = "rtbJSON";
            this.rtbJSON.ReadOnly = true;
            this.rtbJSON.Size = new System.Drawing.Size(786, 446);
            this.rtbJSON.TabIndex = 2;
            this.rtbJSON.Text = "";
            this.rtbJSON.TabIndexChanged += new System.EventHandler(this.rtbJSON_TabIndexChanged);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tabControl1);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(800, 496);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "grpMain";
            // 
            // btnFollow2
            // 
            this.btnFollow2.Location = new System.Drawing.Point(5, 113);
            this.btnFollow2.Name = "btnFollow2";
            this.btnFollow2.Size = new System.Drawing.Size(136, 23);
            this.btnFollow2.TabIndex = 10;
            this.btnFollow2.Text = "&Follow Button";
            this.btnFollow2.UseVisualStyleBackColor = true;
            this.btnFollow2.Click += new System.EventHandler(this.btnFollow2_Click);
            // 
            // chkVisibleColumnsOnly
            // 
            this.chkVisibleColumnsOnly.AutoSize = true;
            this.chkVisibleColumnsOnly.Location = new System.Drawing.Point(6, 86);
            this.chkVisibleColumnsOnly.Name = "chkVisibleColumnsOnly";
            this.chkVisibleColumnsOnly.Size = new System.Drawing.Size(162, 21);
            this.chkVisibleColumnsOnly.TabIndex = 11;
            this.chkVisibleColumnsOnly.Text = "Visible Columns Only";
            this.chkVisibleColumnsOnly.UseVisualStyleBackColor = true;
            this.chkVisibleColumnsOnly.CheckedChanged += new System.EventHandler(this.chkVisibleColumnsOnly_CheckedChanged);
            // 
            // frmReportSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmReportSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmReportSettings_Load);
            tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFilters.ResumeLayout(false);
            this.pnlFiltersRight.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFilters)).EndInit();
            this.pnlFiltersLeft.ResumeLayout(false);
            this.pnlFitlerLeftTop.ResumeLayout(false);
            this.pnlFiltersLeftBottom.ResumeLayout(false);
            this.tabColumns.ResumeLayout(false);
            this.pnlColumnsRight.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).EndInit();
            this.pnlColumnsLeft.ResumeLayout(false);
            this.pnlColumnsLeftTop.ResumeLayout(false);
            this.pnlColumnsLeftBottom.ResumeLayout(false);
            this.pnlColumnsLeftBottom.PerformLayout();
            this.tabButtons.ResumeLayout(false);
            this.pnlButtonsRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).EndInit();
            this.pnlButtonsLeft.ResumeLayout(false);
            this.pnlButtonsLeftTop.ResumeLayout(false);
            this.pnlButtonsLeftBottom.ResumeLayout(false);
            this.tabJSON.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFilters;
        private System.Windows.Forms.TabPage tabColumns;
        private System.Windows.Forms.TabPage tabButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridButtons;
        private System.Windows.Forms.Button btnButtonAdd;
        private System.Windows.Forms.ListBox lstButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnColumnsMoveDown;
        private System.Windows.Forms.Button btnColumnsMoveUp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnColumnsAdd;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.DataGridView dataProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnFilterMoveDown;
        private System.Windows.Forms.Button btnFilterMoveUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlFiltersRight;
        private System.Windows.Forms.DataGridView gridFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel pnlFiltersLeft;
        private System.Windows.Forms.Panel pnlFiltersLeftBottom;
        private System.Windows.Forms.Panel pnlFitlerLeftTop;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlColumnsRight;
        private System.Windows.Forms.Panel pnlColumnsLeft;
        private System.Windows.Forms.Panel pnlColumnsLeftTop;
        private System.Windows.Forms.Panel pnlColumnsLeftBottom;
        private System.Windows.Forms.Panel pnlButtonsRight;
        private System.Windows.Forms.Panel pnlButtonsLeft;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pnlButtonsLeftBottom;
        private System.Windows.Forms.Panel pnlButtonsLeftTop;
        private System.Windows.Forms.Button btnButtonMoveUp;
        private System.Windows.Forms.Button btnButtonMoveDown;
        private System.Windows.Forms.TabPage tabJSON;
        private System.Windows.Forms.RichTextBox rtbJSON;
        private System.Windows.Forms.Button btnAddColumnButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkSubscribeToOwnerObject;
        private System.Windows.Forms.CheckBox chkSubscribeToTargetChild;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnCopyList;
        private System.Windows.Forms.Button btnAddMultiSelectButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFollowButton;
        private System.Windows.Forms.Button btnFollow2;
        private System.Windows.Forms.CheckBox chkVisibleColumnsOnly;
    }
}