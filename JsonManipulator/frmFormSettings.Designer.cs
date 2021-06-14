﻿
namespace JsonManipulator
{
    partial class frmFormSettings
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
            this.gridProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControls = new System.Windows.Forms.TabPage();
            this.btnControlDown = new System.Windows.Forms.Button();
            this.btnControlUp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridControls = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnControls = new System.Windows.Forms.Button();
            this.lstControl = new System.Windows.Forms.ListBox();
            this.tabButtons = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridButtons = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.lstButtons = new System.Windows.Forms.ListBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.pnlControlsLeft = new System.Windows.Forms.Panel();
            this.pnlControlsRight = new System.Windows.Forms.Panel();
            this.pnlControlsLeftBottom = new System.Windows.Forms.Panel();
            this.pnlControlsLeftTop = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlButtonsLeftTop = new System.Windows.Forms.Panel();
            this.pnlButtonsLeft = new System.Windows.Forms.Panel();
            this.pnlButtonsLeftBottom = new System.Windows.Forms.Panel();
            this.pnlButtonsRight = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProperties)).BeginInit();
            this.tabControls.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControls)).BeginInit();
            this.tabButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).BeginInit();
            this.grpMain.SuspendLayout();
            this.pnlControlsLeft.SuspendLayout();
            this.pnlControlsRight.SuspendLayout();
            this.pnlControlsLeftBottom.SuspendLayout();
            this.pnlControlsLeftTop.SuspendLayout();
            this.pnlButtonsLeftTop.SuspendLayout();
            this.pnlButtonsLeft.SuspendLayout();
            this.pnlButtonsLeftBottom.SuspendLayout();
            this.pnlButtonsRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabControls);
            this.tabControl1.Controls.Add(this.tabButtons);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.gridProperties);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(786, 405);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // gridProperties
            // 
            this.gridProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProperties.Location = new System.Drawing.Point(3, 3);
            this.gridProperties.MultiSelect = false;
            this.gridProperties.Name = "gridProperties";
            this.gridProperties.RowHeadersVisible = false;
            this.gridProperties.Size = new System.Drawing.Size(780, 399);
            this.gridProperties.TabIndex = 1;
            this.gridProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProperties_CellClick);
            this.gridProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProperties_CellEnter);
            this.gridProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProperties_CellValueChanged);
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
            // tabControls
            // 
            this.tabControls.Controls.Add(this.splitter1);
            this.tabControls.Controls.Add(this.pnlControlsRight);
            this.tabControls.Controls.Add(this.pnlControlsLeft);
            this.tabControls.Location = new System.Drawing.Point(4, 22);
            this.tabControls.Name = "tabControls";
            this.tabControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabControls.Size = new System.Drawing.Size(786, 405);
            this.tabControls.TabIndex = 1;
            this.tabControls.Text = "Controls";
            this.tabControls.UseVisualStyleBackColor = true;
            // 
            // btnControlDown
            // 
            this.btnControlDown.Location = new System.Drawing.Point(3, 61);
            this.btnControlDown.Name = "btnControlDown";
            this.btnControlDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnControlDown.Size = new System.Drawing.Size(75, 23);
            this.btnControlDown.TabIndex = 4;
            this.btnControlDown.Text = "Move Down";
            this.btnControlDown.UseVisualStyleBackColor = true;
            this.btnControlDown.Click += new System.EventHandler(this.btnControlDown_Click);
            // 
            // btnControlUp
            // 
            this.btnControlUp.Location = new System.Drawing.Point(3, 32);
            this.btnControlUp.Name = "btnControlUp";
            this.btnControlUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnControlUp.Size = new System.Drawing.Size(75, 23);
            this.btnControlUp.TabIndex = 3;
            this.btnControlUp.Text = "Move Up";
            this.btnControlUp.UseVisualStyleBackColor = true;
            this.btnControlUp.Click += new System.EventHandler(this.btnControlUp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridControls);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(592, 399);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control Properties";
            // 
            // gridControls
            // 
            this.gridControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gridControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControls.Location = new System.Drawing.Point(3, 16);
            this.gridControls.MultiSelect = false;
            this.gridControls.Name = "gridControls";
            this.gridControls.RowHeadersVisible = false;
            this.gridControls.Size = new System.Drawing.Size(586, 380);
            this.gridControls.TabIndex = 5;
            this.gridControls.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridControls_CellClick);
            this.gridControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridControls_CellContentClick);
            this.gridControls.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridControls_CellEnter);
            this.gridControls.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridControls_CellValueChanged);
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
            // btnControls
            // 
            this.btnControls.Location = new System.Drawing.Point(3, 3);
            this.btnControls.Name = "btnControls";
            this.btnControls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnControls.Size = new System.Drawing.Size(75, 23);
            this.btnControls.TabIndex = 2;
            this.btnControls.Text = "Add Control";
            this.btnControls.UseVisualStyleBackColor = true;
            this.btnControls.Click += new System.EventHandler(this.btnControls_Click);
            // 
            // lstControl
            // 
            this.lstControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstControl.FormattingEnabled = true;
            this.lstControl.Location = new System.Drawing.Point(0, 0);
            this.lstControl.Name = "lstControl";
            this.lstControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstControl.Size = new System.Drawing.Size(188, 293);
            this.lstControl.TabIndex = 1;
            this.lstControl.SelectedIndexChanged += new System.EventHandler(this.lstControl_SelectedIndexChanged);
            // 
            // tabButtons
            // 
            this.tabButtons.Controls.Add(this.splitter2);
            this.tabButtons.Controls.Add(this.pnlButtonsRight);
            this.tabButtons.Controls.Add(this.pnlButtonsLeft);
            this.tabButtons.Location = new System.Drawing.Point(4, 22);
            this.tabButtons.Name = "tabButtons";
            this.tabButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabButtons.Size = new System.Drawing.Size(786, 480);
            this.tabButtons.TabIndex = 2;
            this.tabButtons.Text = "Buttons";
            this.tabButtons.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridButtons);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(609, 480);
            this.groupBox1.TabIndex = 5;
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
            this.gridButtons.Size = new System.Drawing.Size(603, 461);
            this.gridButtons.TabIndex = 3;
            this.gridButtons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellClick);
            this.gridButtons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellContentClick);
            this.gridButtons.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridButtons_CellEnter);
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
            // btnAddButton
            // 
            this.btnAddButton.Location = new System.Drawing.Point(3, 3);
            this.btnAddButton.Name = "btnAddButton";
            this.btnAddButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddButton.Size = new System.Drawing.Size(75, 23);
            this.btnAddButton.TabIndex = 2;
            this.btnAddButton.Text = "Add Button";
            this.btnAddButton.UseVisualStyleBackColor = true;
            this.btnAddButton.Click += new System.EventHandler(this.btnAddButton_Click);
            // 
            // lstButtons
            // 
            this.lstButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstButtons.FormattingEnabled = true;
            this.lstButtons.Location = new System.Drawing.Point(0, 0);
            this.lstButtons.Name = "lstButtons";
            this.lstButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstButtons.Size = new System.Drawing.Size(177, 480);
            this.lstButtons.TabIndex = 1;
            this.lstButtons.SelectedIndexChanged += new System.EventHandler(this.lstButtons_SelectedIndexChanged);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tabControl1);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(800, 525);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "groupBox2";
            // 
            // pnlControlsLeft
            // 
            this.pnlControlsLeft.Controls.Add(this.pnlControlsLeftTop);
            this.pnlControlsLeft.Controls.Add(this.pnlControlsLeftBottom);
            this.pnlControlsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlsLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlControlsLeft.Name = "pnlControlsLeft";
            this.pnlControlsLeft.Size = new System.Drawing.Size(188, 399);
            this.pnlControlsLeft.TabIndex = 16;
            // 
            // pnlControlsRight
            // 
            this.pnlControlsRight.Controls.Add(this.groupBox3);
            this.pnlControlsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlsRight.Location = new System.Drawing.Point(191, 3);
            this.pnlControlsRight.Name = "pnlControlsRight";
            this.pnlControlsRight.Size = new System.Drawing.Size(592, 399);
            this.pnlControlsRight.TabIndex = 17;
            // 
            // pnlControlsLeftBottom
            // 
            this.pnlControlsLeftBottom.Controls.Add(this.btnControls);
            this.pnlControlsLeftBottom.Controls.Add(this.btnControlUp);
            this.pnlControlsLeftBottom.Controls.Add(this.btnControlDown);
            this.pnlControlsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlsLeftBottom.Location = new System.Drawing.Point(0, 293);
            this.pnlControlsLeftBottom.Name = "pnlControlsLeftBottom";
            this.pnlControlsLeftBottom.Size = new System.Drawing.Size(188, 106);
            this.pnlControlsLeftBottom.TabIndex = 17;
            // 
            // pnlControlsLeftTop
            // 
            this.pnlControlsLeftTop.Controls.Add(this.lstControl);
            this.pnlControlsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlControlsLeftTop.Name = "pnlControlsLeftTop";
            this.pnlControlsLeftTop.Size = new System.Drawing.Size(188, 293);
            this.pnlControlsLeftTop.TabIndex = 18;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(191, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 399);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // pnlButtonsLeftTop
            // 
            this.pnlButtonsLeftTop.Controls.Add(this.lstButtons);
            this.pnlButtonsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsLeftTop.Name = "pnlButtonsLeftTop";
            this.pnlButtonsLeftTop.Size = new System.Drawing.Size(177, 480);
            this.pnlButtonsLeftTop.TabIndex = 6;
            // 
            // pnlButtonsLeft
            // 
            this.pnlButtonsLeft.Controls.Add(this.pnlButtonsLeftBottom);
            this.pnlButtonsLeft.Controls.Add(this.pnlButtonsLeftTop);
            this.pnlButtonsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtonsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsLeft.Name = "pnlButtonsLeft";
            this.pnlButtonsLeft.Size = new System.Drawing.Size(177, 480);
            this.pnlButtonsLeft.TabIndex = 7;
            // 
            // pnlButtonsLeftBottom
            // 
            this.pnlButtonsLeftBottom.Controls.Add(this.btnAddButton);
            this.pnlButtonsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonsLeftBottom.Location = new System.Drawing.Point(0, 411);
            this.pnlButtonsLeftBottom.Name = "pnlButtonsLeftBottom";
            this.pnlButtonsLeftBottom.Size = new System.Drawing.Size(177, 69);
            this.pnlButtonsLeftBottom.TabIndex = 7;
            // 
            // pnlButtonsRight
            // 
            this.pnlButtonsRight.Controls.Add(this.groupBox1);
            this.pnlButtonsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonsRight.Location = new System.Drawing.Point(177, 0);
            this.pnlButtonsRight.Name = "pnlButtonsRight";
            this.pnlButtonsRight.Size = new System.Drawing.Size(609, 480);
            this.pnlButtonsRight.TabIndex = 7;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(177, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 480);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // frmFormSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFormSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmFormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFormSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmFormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProperties)).EndInit();
            this.tabControls.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControls)).EndInit();
            this.tabButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridButtons)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.pnlControlsLeft.ResumeLayout(false);
            this.pnlControlsRight.ResumeLayout(false);
            this.pnlControlsLeftBottom.ResumeLayout(false);
            this.pnlControlsLeftTop.ResumeLayout(false);
            this.pnlButtonsLeftTop.ResumeLayout(false);
            this.pnlButtonsLeft.ResumeLayout(false);
            this.pnlButtonsLeftBottom.ResumeLayout(false);
            this.pnlButtonsRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabControls;
        private System.Windows.Forms.TabPage tabButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnAddButton;
        private System.Windows.Forms.ListBox lstButtons;
        private System.Windows.Forms.Button btnControlDown;
        private System.Windows.Forms.Button btnControlUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridControls;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnControls;
        private System.Windows.Forms.ListBox lstControl;
        private System.Windows.Forms.DataGridView gridProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlControlsRight;
        private System.Windows.Forms.Panel pnlControlsLeft;
        private System.Windows.Forms.Panel pnlControlsLeftTop;
        private System.Windows.Forms.Panel pnlControlsLeftBottom;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlButtonsRight;
        private System.Windows.Forms.Panel pnlButtonsLeft;
        private System.Windows.Forms.Panel pnlButtonsLeftBottom;
        private System.Windows.Forms.Panel pnlButtonsLeftTop;
    }
}