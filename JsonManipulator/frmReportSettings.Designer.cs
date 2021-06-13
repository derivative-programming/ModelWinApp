
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
            this.btnFilterMoveDown = new System.Windows.Forms.Button();
            this.btnFilterMoveUp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridFilters = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.btnColumnsMoveDown = new System.Windows.Forms.Button();
            this.btnColumnsMoveUp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridColumns = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnColumnsAdd = new System.Windows.Forms.Button();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.tabButtons = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridButtons = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnButtonAdd = new System.Windows.Forms.Button();
            this.lstButtons = new System.Windows.Forms.ListBox();
            tabSettings = new System.Windows.Forms.TabPage();
            tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFilters.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilters)).BeginInit();
            this.tabColumns.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).BeginInit();
            this.tabButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(this.dataProperties);
            tabSettings.Location = new System.Drawing.Point(4, 22);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new System.Windows.Forms.Padding(3);
            tabSettings.Size = new System.Drawing.Size(792, 424);
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
            this.dataProperties.Size = new System.Drawing.Size(786, 418);
            this.dataProperties.TabIndex = 1;
            this.dataProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellClick);
            this.dataProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Property";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(tabSettings);
            this.tabControl1.Controls.Add(this.tabFilters);
            this.tabControl1.Controls.Add(this.tabColumns);
            this.tabControl1.Controls.Add(this.tabButtons);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFilters
            // 
            this.tabFilters.Controls.Add(this.btnFilterMoveDown);
            this.tabFilters.Controls.Add(this.btnFilterMoveUp);
            this.tabFilters.Controls.Add(this.groupBox3);
            this.tabFilters.Controls.Add(this.btnAddFilter);
            this.tabFilters.Controls.Add(this.lstFilters);
            this.tabFilters.Location = new System.Drawing.Point(4, 22);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabFilters.Size = new System.Drawing.Size(792, 424);
            this.tabFilters.TabIndex = 1;
            this.tabFilters.Text = "Filters";
            this.tabFilters.UseVisualStyleBackColor = true;
            // 
            // btnFilterMoveDown
            // 
            this.btnFilterMoveDown.Location = new System.Drawing.Point(8, 375);
            this.btnFilterMoveDown.Name = "btnFilterMoveDown";
            this.btnFilterMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFilterMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnFilterMoveDown.TabIndex = 12;
            this.btnFilterMoveDown.Text = "Move Down";
            this.btnFilterMoveDown.UseVisualStyleBackColor = true;
            this.btnFilterMoveDown.Click += new System.EventHandler(this.btnFilterMoveDown_Click);
            // 
            // btnFilterMoveUp
            // 
            this.btnFilterMoveUp.Location = new System.Drawing.Point(8, 346);
            this.btnFilterMoveUp.Name = "btnFilterMoveUp";
            this.btnFilterMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFilterMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnFilterMoveUp.TabIndex = 11;
            this.btnFilterMoveUp.Text = "Move Up";
            this.btnFilterMoveUp.UseVisualStyleBackColor = true;
            this.btnFilterMoveUp.Click += new System.EventHandler(this.btnFilterMoveUp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridFilters);
            this.groupBox3.Location = new System.Drawing.Point(144, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(640, 408);
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
            this.gridFilters.Location = new System.Drawing.Point(3, 16);
            this.gridFilters.MultiSelect = false;
            this.gridFilters.Name = "gridFilters";
            this.gridFilters.RowHeadersVisible = false;
            this.gridFilters.Size = new System.Drawing.Size(634, 389);
            this.gridFilters.TabIndex = 0;
            this.gridFilters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFilters_CellClick);
            this.gridFilters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFilters_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Property";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(8, 317);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 9;
            this.btnAddFilter.Text = "Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(8, 8);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstFilters.Size = new System.Drawing.Size(120, 303);
            this.lstFilters.TabIndex = 8;
            this.lstFilters.SelectedIndexChanged += new System.EventHandler(this.lstFilters_SelectedIndexChanged);
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.btnColumnsMoveDown);
            this.tabColumns.Controls.Add(this.btnColumnsMoveUp);
            this.tabColumns.Controls.Add(this.groupBox2);
            this.tabColumns.Controls.Add(this.btnColumnsAdd);
            this.tabColumns.Controls.Add(this.lstColumns);
            this.tabColumns.Location = new System.Drawing.Point(4, 22);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Size = new System.Drawing.Size(792, 424);
            this.tabColumns.TabIndex = 2;
            this.tabColumns.Text = "Columns";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // btnColumnsMoveDown
            // 
            this.btnColumnsMoveDown.Location = new System.Drawing.Point(8, 375);
            this.btnColumnsMoveDown.Name = "btnColumnsMoveDown";
            this.btnColumnsMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnColumnsMoveDown.TabIndex = 7;
            this.btnColumnsMoveDown.Text = "Move Down";
            this.btnColumnsMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnsMoveDown.Click += new System.EventHandler(this.btnColumnsMoveDown_Click);
            // 
            // btnColumnsMoveUp
            // 
            this.btnColumnsMoveUp.Location = new System.Drawing.Point(8, 346);
            this.btnColumnsMoveUp.Name = "btnColumnsMoveUp";
            this.btnColumnsMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnColumnsMoveUp.TabIndex = 6;
            this.btnColumnsMoveUp.Text = "Move Up";
            this.btnColumnsMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnsMoveUp.Click += new System.EventHandler(this.btnColumnsMoveUp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridColumns);
            this.groupBox2.Location = new System.Drawing.Point(144, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 408);
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
            this.gridColumns.Location = new System.Drawing.Point(3, 16);
            this.gridColumns.MultiSelect = false;
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.RowHeadersVisible = false;
            this.gridColumns.Size = new System.Drawing.Size(634, 389);
            this.gridColumns.TabIndex = 0;
            this.gridColumns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellClick);
            this.gridColumns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColumns_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Property";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btnColumnsAdd
            // 
            this.btnColumnsAdd.Location = new System.Drawing.Point(8, 317);
            this.btnColumnsAdd.Name = "btnColumnsAdd";
            this.btnColumnsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnColumnsAdd.TabIndex = 4;
            this.btnColumnsAdd.Text = "Add Column";
            this.btnColumnsAdd.UseVisualStyleBackColor = true;
            this.btnColumnsAdd.Click += new System.EventHandler(this.btnColumnsAdd_Click);
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(8, 8);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(120, 303);
            this.lstColumns.TabIndex = 3;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // tabButtons
            // 
            this.tabButtons.Controls.Add(this.groupBox1);
            this.tabButtons.Controls.Add(this.btnButtonAdd);
            this.tabButtons.Controls.Add(this.lstButtons);
            this.tabButtons.Location = new System.Drawing.Point(4, 22);
            this.tabButtons.Name = "tabButtons";
            this.tabButtons.Size = new System.Drawing.Size(792, 424);
            this.tabButtons.TabIndex = 3;
            this.tabButtons.Text = "Buttons";
            this.tabButtons.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridButtons);
            this.groupBox1.Location = new System.Drawing.Point(144, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 408);
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
            this.gridButtons.Location = new System.Drawing.Point(3, 16);
            this.gridButtons.MultiSelect = false;
            this.gridButtons.Name = "gridButtons";
            this.gridButtons.RowHeadersVisible = false;
            this.gridButtons.Size = new System.Drawing.Size(634, 389);
            this.gridButtons.TabIndex = 0;
            this.gridButtons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellClick);
            this.gridButtons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellValueChanged);
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // btnButtonAdd
            // 
            this.btnButtonAdd.Location = new System.Drawing.Point(8, 382);
            this.btnButtonAdd.Name = "btnButtonAdd";
            this.btnButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.btnButtonAdd.TabIndex = 1;
            this.btnButtonAdd.Text = "Add Button";
            this.btnButtonAdd.UseVisualStyleBackColor = true;
            this.btnButtonAdd.Click += new System.EventHandler(this.btnButtonAdd_Click);
            // 
            // lstButtons
            // 
            this.lstButtons.FormattingEnabled = true;
            this.lstButtons.Location = new System.Drawing.Point(8, 8);
            this.lstButtons.Name = "lstButtons";
            this.lstButtons.Size = new System.Drawing.Size(120, 368);
            this.lstButtons.TabIndex = 0;
            this.lstButtons.SelectedIndexChanged += new System.EventHandler(this.lstButtons_SelectedIndexChanged);
            // 
            // frmReportSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmReportSettings";
            this.Load += new System.EventHandler(this.frmReportSettings_Load);
            tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFilters.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFilters)).EndInit();
            this.tabColumns.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).EndInit();
            this.tabButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).EndInit();
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
        private System.Windows.Forms.DataGridView gridFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.ListBox lstFilters;
    }
}