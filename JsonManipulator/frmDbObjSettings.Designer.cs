
namespace JsonManipulator
{
    partial class frmDbObjSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.dataProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabProp = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridPropertiesProp = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProperties = new System.Windows.Forms.Button();
            this.lstProperties = new System.Windows.Forms.ListBox();
            this.grpBoxMain = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabProp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPropertiesProp)).BeginInit();
            this.grpBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabProp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 648);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.AutoScroll = true;
            this.tabSettings.Controls.Add(this.dataProperties);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabSettings.Size = new System.Drawing.Size(840, 622);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // dataProperties
            // 
            this.dataProperties.AllowUserToAddRows = false;
            this.dataProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProperties.Location = new System.Drawing.Point(3, 3);
            this.dataProperties.Name = "dataProperties";
            this.dataProperties.RowHeadersVisible = false;
            this.dataProperties.Size = new System.Drawing.Size(834, 616);
            this.dataProperties.TabIndex = 1;
            this.dataProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellClick);
            this.dataProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellEnter);
            this.dataProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellValueChanged);
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
            // tabProp
            // 
            this.tabProp.AutoScroll = true;
            this.tabProp.Controls.Add(this.groupBox1);
            this.tabProp.Controls.Add(this.btnProperties);
            this.tabProp.Controls.Add(this.lstProperties);
            this.tabProp.Location = new System.Drawing.Point(4, 22);
            this.tabProp.Name = "tabProp";
            this.tabProp.Padding = new System.Windows.Forms.Padding(3);
            this.tabProp.Size = new System.Drawing.Size(840, 622);
            this.tabProp.TabIndex = 1;
            this.tabProp.Text = "Prop";
            this.tabProp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridPropertiesProp);
            this.groupBox1.Location = new System.Drawing.Point(144, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(640, 408);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prop Properties";
            // 
            // gridPropertiesProp
            // 
            this.gridPropertiesProp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPropertiesProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPropertiesProp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.gridPropertiesProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPropertiesProp.Location = new System.Drawing.Point(3, 16);
            this.gridPropertiesProp.Name = "gridPropertiesProp";
            this.gridPropertiesProp.RowHeadersVisible = false;
            this.gridPropertiesProp.Size = new System.Drawing.Size(634, 389);
            this.gridPropertiesProp.TabIndex = 3;
            this.gridPropertiesProp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropertiesProp_CellClick);
            this.gridPropertiesProp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropertiesProp_CellContentClick);
            this.gridPropertiesProp.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropertiesProp_CellEnter);
            this.gridPropertiesProp.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropertiesProp_CellValueChanged);
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
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(8, 382);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProperties.Size = new System.Drawing.Size(75, 23);
            this.btnProperties.TabIndex = 2;
            this.btnProperties.Text = "Add Prop";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // lstProperties
            // 
            this.lstProperties.FormattingEnabled = true;
            this.lstProperties.Location = new System.Drawing.Point(8, 8);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstProperties.Size = new System.Drawing.Size(120, 368);
            this.lstProperties.TabIndex = 1;
            this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.lstProperties_SelectedIndexChanged);
            // 
            // grpBoxMain
            // 
            this.grpBoxMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBoxMain.Controls.Add(this.tabControl1);
            this.grpBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxMain.Location = new System.Drawing.Point(0, 0);
            this.grpBoxMain.Name = "grpBoxMain";
            this.grpBoxMain.Size = new System.Drawing.Size(854, 667);
            this.grpBoxMain.TabIndex = 1;
            this.grpBoxMain.TabStop = false;
            this.grpBoxMain.Text = "groupBox2";
            // 
            // frmDbObjSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(854, 667);
            this.Controls.Add(this.grpBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDbObjSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmDbObjSettings";
            this.Load += new System.EventHandler(this.frmDbObjSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabProp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPropertiesProp)).EndInit();
            this.grpBoxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabProp;
        private System.Windows.Forms.DataGridView dataProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridPropertiesProp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.ListBox lstProperties;
        private System.Windows.Forms.GroupBox grpBoxMain;
    }
}