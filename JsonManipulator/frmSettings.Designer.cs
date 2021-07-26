
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gridModelFeature = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pnlModelFeatureLeft = new System.Windows.Forms.Panel();
            this.pnlModelFeatureLeftBottom = new System.Windows.Forms.Panel();
            this.btnAddModelFeature = new System.Windows.Forms.Button();
            this.pnlModelFeatureLeftTop = new System.Windows.Forms.Panel();
            this.lstModelFeatures = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlNavButtons = new System.Windows.Forms.Panel();
            this.pnlNavButtonsRightTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbNavButtonsNote = new System.Windows.Forms.RichTextBox();
            this.gridNavButtons = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlNavButtonsLeft = new System.Windows.Forms.Panel();
            this.pnlNavButtonsLeftBottom = new System.Windows.Forms.Panel();
            this.btnAddNavButton = new System.Windows.Forms.Button();
            this.pnlNavButtonsLeftTop = new System.Windows.Forms.Panel();
            this.lstNavButtons = new System.Windows.Forms.ListBox();
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
            this.tabPage1.SuspendLayout();
            this.pnlNavButtons.SuspendLayout();
            this.pnlNavButtonsRightTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNavButtons)).BeginInit();
            this.pnlNavButtonsLeft.SuspendLayout();
            this.pnlNavButtonsLeftBottom.SuspendLayout();
            this.pnlNavButtonsLeftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabModelFeatures);
            this.tabControl1.Controls.Add(this.tabPage1);
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
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(792, 421);
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
            this.dataProperties.RowHeadersWidth = 51;
            this.dataProperties.Size = new System.Drawing.Size(786, 415);
            this.dataProperties.TabIndex = 1;
            this.dataProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellEnter);
            this.dataProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProperties_CellValueChanged);
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.MinimumWidth = 6;
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            // 
            // tabModelFeatures
            // 
            this.tabModelFeatures.Controls.Add(this.pnlModelFeature);
            this.tabModelFeatures.Location = new System.Drawing.Point(4, 25);
            this.tabModelFeatures.Name = "tabModelFeatures";
            this.tabModelFeatures.Size = new System.Drawing.Size(792, 421);
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
            this.pnlModelFeature.Size = new System.Drawing.Size(792, 421);
            this.pnlModelFeature.TabIndex = 2;
            // 
            // pnlModelFeatureRight
            // 
            this.pnlModelFeatureRight.Controls.Add(this.groupBox4);
            this.pnlModelFeatureRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelFeatureRight.Location = new System.Drawing.Point(180, 0);
            this.pnlModelFeatureRight.Name = "pnlModelFeatureRight";
            this.pnlModelFeatureRight.Size = new System.Drawing.Size(612, 421);
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
            this.groupBox4.Size = new System.Drawing.Size(612, 421);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Model Feature Properties";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(3, 322);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // gridModelFeature
            // 
            this.gridModelFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridModelFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModelFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.gridModelFeature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridModelFeature.Location = new System.Drawing.Point(3, 18);
            this.gridModelFeature.MultiSelect = false;
            this.gridModelFeature.Name = "gridModelFeature";
            this.gridModelFeature.RowHeadersVisible = false;
            this.gridModelFeature.RowHeadersWidth = 51;
            this.gridModelFeature.Size = new System.Drawing.Size(606, 400);
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
            this.splitter4.Size = new System.Drawing.Size(3, 421);
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
            this.pnlModelFeatureLeft.Size = new System.Drawing.Size(177, 421);
            this.pnlModelFeatureLeft.TabIndex = 8;
            // 
            // pnlModelFeatureLeftBottom
            // 
            this.pnlModelFeatureLeftBottom.Controls.Add(this.btnAddModelFeature);
            this.pnlModelFeatureLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModelFeatureLeftBottom.Location = new System.Drawing.Point(0, 319);
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
            this.pnlModelFeatureLeftTop.Size = new System.Drawing.Size(177, 421);
            this.pnlModelFeatureLeftTop.TabIndex = 6;
            // 
            // lstModelFeatures
            // 
            this.lstModelFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstModelFeatures.FormattingEnabled = true;
            this.lstModelFeatures.ItemHeight = 16;
            this.lstModelFeatures.Location = new System.Drawing.Point(0, 0);
            this.lstModelFeatures.Name = "lstModelFeatures";
            this.lstModelFeatures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstModelFeatures.Size = new System.Drawing.Size(177, 421);
            this.lstModelFeatures.TabIndex = 1;
            this.lstModelFeatures.SelectedIndexChanged += new System.EventHandler(this.lstModelFeatures_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlNavButtons);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Nav Buttons";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.Controls.Add(this.pnlNavButtonsRightTop);
            this.pnlNavButtons.Controls.Add(this.splitter1);
            this.pnlNavButtons.Controls.Add(this.pnlNavButtonsLeft);
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Size = new System.Drawing.Size(792, 421);
            this.pnlNavButtons.TabIndex = 3;
            // 
            // pnlNavButtonsRightTop
            // 
            this.pnlNavButtonsRightTop.Controls.Add(this.groupBox1);
            this.pnlNavButtonsRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavButtonsRightTop.Location = new System.Drawing.Point(180, 0);
            this.pnlNavButtonsRightTop.Name = "pnlNavButtonsRightTop";
            this.pnlNavButtonsRightTop.Size = new System.Drawing.Size(612, 421);
            this.pnlNavButtonsRightTop.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbNavButtonsNote);
            this.groupBox1.Controls.Add(this.gridNavButtons);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(612, 421);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nav Button Properties";
            // 
            // rtbNavButtonsNote
            // 
            this.rtbNavButtonsNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbNavButtonsNote.Location = new System.Drawing.Point(3, 322);
            this.rtbNavButtonsNote.Name = "rtbNavButtonsNote";
            this.rtbNavButtonsNote.Size = new System.Drawing.Size(606, 96);
            this.rtbNavButtonsNote.TabIndex = 4;
            this.rtbNavButtonsNote.Text = "";
            // 
            // gridNavButtons
            // 
            this.gridNavButtons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNavButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNavButtons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridNavButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNavButtons.Location = new System.Drawing.Point(3, 18);
            this.gridNavButtons.MultiSelect = false;
            this.gridNavButtons.Name = "gridNavButtons";
            this.gridNavButtons.RowHeadersVisible = false;
            this.gridNavButtons.RowHeadersWidth = 51;
            this.gridNavButtons.Size = new System.Drawing.Size(606, 400);
            this.gridNavButtons.TabIndex = 3;
            this.gridNavButtons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNavButtons_CellClick);
            this.gridNavButtons.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNavButtons_CellEnter);
            this.gridNavButtons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNavButtons_CellValueChanged);
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(177, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 421);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // pnlNavButtonsLeft
            // 
            this.pnlNavButtonsLeft.Controls.Add(this.pnlNavButtonsLeftBottom);
            this.pnlNavButtonsLeft.Controls.Add(this.pnlNavButtonsLeftTop);
            this.pnlNavButtonsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavButtonsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlNavButtonsLeft.Name = "pnlNavButtonsLeft";
            this.pnlNavButtonsLeft.Size = new System.Drawing.Size(177, 421);
            this.pnlNavButtonsLeft.TabIndex = 8;
            // 
            // pnlNavButtonsLeftBottom
            // 
            this.pnlNavButtonsLeftBottom.Controls.Add(this.btnAddNavButton);
            this.pnlNavButtonsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavButtonsLeftBottom.Location = new System.Drawing.Point(0, 319);
            this.pnlNavButtonsLeftBottom.Name = "pnlNavButtonsLeftBottom";
            this.pnlNavButtonsLeftBottom.Size = new System.Drawing.Size(177, 102);
            this.pnlNavButtonsLeftBottom.TabIndex = 7;
            // 
            // btnAddNavButton
            // 
            this.btnAddNavButton.Location = new System.Drawing.Point(3, 3);
            this.btnAddNavButton.Name = "btnAddNavButton";
            this.btnAddNavButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddNavButton.Size = new System.Drawing.Size(75, 23);
            this.btnAddNavButton.TabIndex = 2;
            this.btnAddNavButton.Text = "&Add";
            this.btnAddNavButton.UseVisualStyleBackColor = true;
            this.btnAddNavButton.Click += new System.EventHandler(this.btnAddNavButton_Click);
            // 
            // pnlNavButtonsLeftTop
            // 
            this.pnlNavButtonsLeftTop.Controls.Add(this.lstNavButtons);
            this.pnlNavButtonsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavButtonsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlNavButtonsLeftTop.Name = "pnlNavButtonsLeftTop";
            this.pnlNavButtonsLeftTop.Size = new System.Drawing.Size(177, 421);
            this.pnlNavButtonsLeftTop.TabIndex = 6;
            // 
            // lstNavButtons
            // 
            this.lstNavButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNavButtons.FormattingEnabled = true;
            this.lstNavButtons.ItemHeight = 16;
            this.lstNavButtons.Location = new System.Drawing.Point(0, 0);
            this.lstNavButtons.Name = "lstNavButtons";
            this.lstNavButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstNavButtons.Size = new System.Drawing.Size(177, 421);
            this.lstNavButtons.TabIndex = 1;
            this.lstNavButtons.SelectedIndexChanged += new System.EventHandler(this.lstNavButtons_SelectedIndexChanged);
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
            this.tabPage1.ResumeLayout(false);
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlNavButtonsRightTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNavButtons)).EndInit();
            this.pnlNavButtonsLeft.ResumeLayout(false);
            this.pnlNavButtonsLeftBottom.ResumeLayout(false);
            this.pnlNavButtonsLeftTop.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlNavButtons;
        private System.Windows.Forms.Panel pnlNavButtonsRightTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbNavButtonsNote;
        private System.Windows.Forms.DataGridView gridNavButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlNavButtonsLeft;
        private System.Windows.Forms.Panel pnlNavButtonsLeftBottom;
        private System.Windows.Forms.Button btnAddNavButton;
        private System.Windows.Forms.Panel pnlNavButtonsLeftTop;
        private System.Windows.Forms.ListBox lstNavButtons;
    }
}