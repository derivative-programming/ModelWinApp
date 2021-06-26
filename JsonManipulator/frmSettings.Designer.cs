
namespace JsonManipulator
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.dataProperties = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabModelFeatures = new System.Windows.Forms.TabPage();
            this.pnlModelFeature = new System.Windows.Forms.Panel();
            this.pnlModelFeatureRight = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gridModelFeature = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pnlModelFeatureLeft = new System.Windows.Forms.Panel();
            this.pnlModelFeatureLeftBottom = new System.Windows.Forms.Panel();
            this.btnAddModelFeature = new System.Windows.Forms.Button();
            this.pnlModelFeatureLeftTop = new System.Windows.Forms.Panel();
            this.lstModelFeatures = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabModelFeatures.SuspendLayout();
            this.pnlModelFeature.SuspendLayout();
            this.pnlModelFeatureRight.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModelFeature)).BeginInit();
            this.pnlModelFeatureLeft.SuspendLayout();
            this.pnlModelFeatureLeftBottom.SuspendLayout();
            this.pnlModelFeatureLeftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabModelFeatures);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.dataProperties);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(792, 424);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // dataProperties
            // 
            this.dataProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.dataProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProperties.Location = new System.Drawing.Point(3, 3);
            this.dataProperties.Name = "dataProperties";
            this.dataProperties.RowHeadersVisible = false;
            this.dataProperties.Size = new System.Drawing.Size(786, 418);
            this.dataProperties.TabIndex = 1;
            this.dataProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellEnter);
            this.dataProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellValueChanged);
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // tabModelFeatures
            // 
            this.tabModelFeatures.Controls.Add(this.pnlModelFeature);
            this.tabModelFeatures.Location = new System.Drawing.Point(4, 22);
            this.tabModelFeatures.Name = "tabModelFeatures";
            this.tabModelFeatures.Size = new System.Drawing.Size(792, 424);
            this.tabModelFeatures.TabIndex = 1;
            this.tabModelFeatures.Text = "Model Features";
            this.tabModelFeatures.UseVisualStyleBackColor = true;
            // 
            // pnlModelFeature
            // 
            this.pnlModelFeature.Controls.Add(this.pnlModelFeatureRight);
            this.pnlModelFeature.Controls.Add(this.splitter4);
            this.pnlModelFeature.Controls.Add(this.pnlModelFeatureLeft);
            this.pnlModelFeature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelFeature.Location = new System.Drawing.Point(0, 0);
            this.pnlModelFeature.Name = "pnlModelFeature";
            this.pnlModelFeature.Size = new System.Drawing.Size(792, 424);
            this.pnlModelFeature.TabIndex = 2;
            // 
            // pnlModelFeatureRight
            // 
            this.pnlModelFeatureRight.Controls.Add(this.groupBox4);
            this.pnlModelFeatureRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelFeatureRight.Location = new System.Drawing.Point(180, 0);
            this.pnlModelFeatureRight.Name = "pnlModelFeatureRight";
            this.pnlModelFeatureRight.Size = new System.Drawing.Size(612, 424);
            this.pnlModelFeatureRight.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Controls.Add(this.gridModelFeature);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(612, 424);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Model Feature Properties";
            // 
            // gridModelFeature
            // 
            this.gridModelFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridModelFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModelFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.gridModelFeature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridModelFeature.Location = new System.Drawing.Point(3, 16);
            this.gridModelFeature.MultiSelect = false;
            this.gridModelFeature.Name = "gridModelFeature";
            this.gridModelFeature.RowHeadersVisible = false;
            this.gridModelFeature.RowHeadersWidth = 51;
            this.gridModelFeature.Size = new System.Drawing.Size(606, 405);
            this.gridModelFeature.TabIndex = 3;
            this.gridModelFeature.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModelFeature_CellEnter);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Property";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Value";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(177, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 424);
            this.splitter4.TabIndex = 9;
            this.splitter4.TabStop = false;
            // 
            // pnlModelFeatureLeft
            // 
            this.pnlModelFeatureLeft.Controls.Add(this.pnlModelFeatureLeftBottom);
            this.pnlModelFeatureLeft.Controls.Add(this.pnlModelFeatureLeftTop);
            this.pnlModelFeatureLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModelFeatureLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlModelFeatureLeft.Name = "pnlModelFeatureLeft";
            this.pnlModelFeatureLeft.Size = new System.Drawing.Size(177, 424);
            this.pnlModelFeatureLeft.TabIndex = 8;
            // 
            // pnlModelFeatureLeftBottom
            // 
            this.pnlModelFeatureLeftBottom.Controls.Add(this.btnAddModelFeature);
            this.pnlModelFeatureLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModelFeatureLeftBottom.Location = new System.Drawing.Point(0, 322);
            this.pnlModelFeatureLeftBottom.Name = "pnlModelFeatureLeftBottom";
            this.pnlModelFeatureLeftBottom.Size = new System.Drawing.Size(177, 102);
            this.pnlModelFeatureLeftBottom.TabIndex = 7;
            // 
            // btnAddModelFeature
            // 
            this.btnAddModelFeature.Location = new System.Drawing.Point(3, 3);
            this.btnAddModelFeature.Name = "btnAddModelFeature";
            this.btnAddModelFeature.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddModelFeature.Size = new System.Drawing.Size(75, 23);
            this.btnAddModelFeature.TabIndex = 2;
            this.btnAddModelFeature.Text = "&Add";
            this.btnAddModelFeature.UseVisualStyleBackColor = true;
            this.btnAddModelFeature.Click += new System.EventHandler(this.btnAddModelFeature_Click);
            // 
            // pnlModelFeatureLeftTop
            // 
            this.pnlModelFeatureLeftTop.Controls.Add(this.lstModelFeatures);
            this.pnlModelFeatureLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelFeatureLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlModelFeatureLeftTop.Name = "pnlModelFeatureLeftTop";
            this.pnlModelFeatureLeftTop.Size = new System.Drawing.Size(177, 424);
            this.pnlModelFeatureLeftTop.TabIndex = 6;
            // 
            // lstModelFeatures
            // 
            this.lstModelFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstModelFeatures.FormattingEnabled = true;
            this.lstModelFeatures.Location = new System.Drawing.Point(0, 0);
            this.lstModelFeatures.Name = "lstModelFeatures";
            this.lstModelFeatures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstModelFeatures.Size = new System.Drawing.Size(177, 424);
            this.lstModelFeatures.TabIndex = 1;
            this.lstModelFeatures.SelectedIndexChanged += new System.EventHandler(this.lstModelFeatures_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(3, 325);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabModelFeatures.ResumeLayout(false);
            this.pnlModelFeature.ResumeLayout(false);
            this.pnlModelFeatureRight.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModelFeature)).EndInit();
            this.pnlModelFeatureLeft.ResumeLayout(false);
            this.pnlModelFeatureLeftBottom.ResumeLayout(false);
            this.pnlModelFeatureLeftTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView dataProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TabPage tabModelFeatures;
        private System.Windows.Forms.Panel pnlModelFeature;
        private System.Windows.Forms.Panel pnlModelFeatureRight;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gridModelFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel pnlModelFeatureLeft;
        private System.Windows.Forms.Panel pnlModelFeatureLeftBottom;
        private System.Windows.Forms.Button btnAddModelFeature;
        private System.Windows.Forms.Panel pnlModelFeatureLeftTop;
        private System.Windows.Forms.ListBox lstModelFeatures;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}