
namespace JsonManipulator
{
    partial class frmAPISettings
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
            this.tabEnvironments = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlEnvironmentsRight = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridEnvironments = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEnvironmentsLeft = new System.Windows.Forms.Panel();
            this.pnlEnvironmentsLeftBottom = new System.Windows.Forms.Panel();
            this.btnAddEnvironment = new System.Windows.Forms.Button();
            this.btnEnvironmentMoveUp = new System.Windows.Forms.Button();
            this.btnEnvironmentMoveDown = new System.Windows.Forms.Button();
            this.pnlEnvironmentLeftTop = new System.Windows.Forms.Panel();
            this.lstEnvironments = new System.Windows.Forms.ListBox();
            this.tabEndpoints = new System.Windows.Forms.TabPage();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlEndPointsRight = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridEndPoints = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEndPointsLeft = new System.Windows.Forms.Panel();
            this.pnlEndPointsLeftTop = new System.Windows.Forms.Panel();
            this.lstEndPoints = new System.Windows.Forms.ListBox();
            this.pnlEndPointsLeftBottom = new System.Windows.Forms.Panel();
            this.btnEndPointsAdd = new System.Windows.Forms.Button();
            this.btnColumnsMoveUp = new System.Windows.Forms.Button();
            this.btnColumnsMoveDown = new System.Windows.Forms.Button();
            this.grpMain = new System.Windows.Forms.GroupBox();
            tabSettings = new System.Windows.Forms.TabPage();
            tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEnvironments.SuspendLayout();
            this.pnlEnvironmentsRight.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnvironments)).BeginInit();
            this.pnlEnvironmentsLeft.SuspendLayout();
            this.pnlEnvironmentsLeftBottom.SuspendLayout();
            this.pnlEnvironmentLeftTop.SuspendLayout();
            this.tabEndpoints.SuspendLayout();
            this.pnlEndPointsRight.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEndPoints)).BeginInit();
            this.pnlEndPointsLeft.SuspendLayout();
            this.pnlEndPointsLeftTop.SuspendLayout();
            this.pnlEndPointsLeftBottom.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(this.dataProperties);
            tabSettings.Location = new System.Drawing.Point(4, 22);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new System.Windows.Forms.Padding(3);
            tabSettings.Size = new System.Drawing.Size(786, 451);
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
            this.dataProperties.Size = new System.Drawing.Size(780, 445);
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
            this.tabControl1.Controls.Add(this.tabEnvironments);
            this.tabControl1.Controls.Add(this.tabEndpoints);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 477);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEnvironments
            // 
            this.tabEnvironments.Controls.Add(this.splitter1);
            this.tabEnvironments.Controls.Add(this.pnlEnvironmentsRight);
            this.tabEnvironments.Controls.Add(this.pnlEnvironmentsLeft);
            this.tabEnvironments.Location = new System.Drawing.Point(4, 22);
            this.tabEnvironments.Name = "tabEnvironments";
            this.tabEnvironments.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnvironments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabEnvironments.Size = new System.Drawing.Size(786, 451);
            this.tabEnvironments.TabIndex = 1;
            this.tabEnvironments.Text = "Environments";
            this.tabEnvironments.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(203, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 445);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // pnlEnvironmentsRight
            // 
            this.pnlEnvironmentsRight.Controls.Add(this.groupBox3);
            this.pnlEnvironmentsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEnvironmentsRight.Location = new System.Drawing.Point(203, 3);
            this.pnlEnvironmentsRight.Name = "pnlEnvironmentsRight";
            this.pnlEnvironmentsRight.Size = new System.Drawing.Size(580, 445);
            this.pnlEnvironmentsRight.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridEnvironments);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(580, 445);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Environment Properties";
            // 
            // gridEnvironments
            // 
            this.gridEnvironments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEnvironments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnvironments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gridEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEnvironments.Location = new System.Drawing.Point(3, 16);
            this.gridEnvironments.MultiSelect = false;
            this.gridEnvironments.Name = "gridEnvironments";
            this.gridEnvironments.RowHeadersVisible = false;
            this.gridEnvironments.RowHeadersWidth = 51;
            this.gridEnvironments.Size = new System.Drawing.Size(574, 426);
            this.gridEnvironments.TabIndex = 5;
            this.gridEnvironments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEnvironments_CellClick);
            this.gridEnvironments.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEnvironments_CellEnter);
            this.gridEnvironments.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEnvironments_CellValueChanged);
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
            // pnlEnvironmentsLeft
            // 
            this.pnlEnvironmentsLeft.Controls.Add(this.pnlEnvironmentsLeftBottom);
            this.pnlEnvironmentsLeft.Controls.Add(this.pnlEnvironmentLeftTop);
            this.pnlEnvironmentsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEnvironmentsLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlEnvironmentsLeft.Name = "pnlEnvironmentsLeft";
            this.pnlEnvironmentsLeft.Size = new System.Drawing.Size(200, 445);
            this.pnlEnvironmentsLeft.TabIndex = 11;
            // 
            // pnlEnvironmentsLeftBottom
            // 
            this.pnlEnvironmentsLeftBottom.Controls.Add(this.btnAddEnvironment);
            this.pnlEnvironmentsLeftBottom.Controls.Add(this.btnEnvironmentMoveUp);
            this.pnlEnvironmentsLeftBottom.Controls.Add(this.btnEnvironmentMoveDown);
            this.pnlEnvironmentsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEnvironmentsLeftBottom.Location = new System.Drawing.Point(0, 345);
            this.pnlEnvironmentsLeftBottom.Name = "pnlEnvironmentsLeftBottom";
            this.pnlEnvironmentsLeftBottom.Size = new System.Drawing.Size(200, 100);
            this.pnlEnvironmentsLeftBottom.TabIndex = 6;
            // 
            // btnAddEnvironment
            // 
            this.btnAddEnvironment.Location = new System.Drawing.Point(3, 3);
            this.btnAddEnvironment.Name = "btnAddEnvironment";
            this.btnAddEnvironment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddEnvironment.Size = new System.Drawing.Size(75, 23);
            this.btnAddEnvironment.TabIndex = 2;
            this.btnAddEnvironment.Text = "Add Environment";
            this.btnAddEnvironment.UseVisualStyleBackColor = true;
            this.btnAddEnvironment.Click += new System.EventHandler(this.btnAddEnvironment_Click);
            // 
            // btnEnvironmentMoveUp
            // 
            this.btnEnvironmentMoveUp.Location = new System.Drawing.Point(3, 32);
            this.btnEnvironmentMoveUp.Name = "btnEnvironmentMoveUp";
            this.btnEnvironmentMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEnvironmentMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnEnvironmentMoveUp.TabIndex = 3;
            this.btnEnvironmentMoveUp.Text = "Move Up";
            this.btnEnvironmentMoveUp.UseVisualStyleBackColor = true;
            this.btnEnvironmentMoveUp.Click += new System.EventHandler(this.btnEnvironmentMoveUp_Click);
            // 
            // btnEnvironmentMoveDown
            // 
            this.btnEnvironmentMoveDown.Location = new System.Drawing.Point(3, 61);
            this.btnEnvironmentMoveDown.Name = "btnEnvironmentMoveDown";
            this.btnEnvironmentMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEnvironmentMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnEnvironmentMoveDown.TabIndex = 4;
            this.btnEnvironmentMoveDown.Text = "Move Down";
            this.btnEnvironmentMoveDown.UseVisualStyleBackColor = true;
            this.btnEnvironmentMoveDown.Click += new System.EventHandler(this.btnEnvironmentMoveDown_Click);
            // 
            // pnlEnvironmentLeftTop
            // 
            this.pnlEnvironmentLeftTop.Controls.Add(this.lstEnvironments);
            this.pnlEnvironmentLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEnvironmentLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlEnvironmentLeftTop.Name = "pnlEnvironmentLeftTop";
            this.pnlEnvironmentLeftTop.Size = new System.Drawing.Size(200, 445);
            this.pnlEnvironmentLeftTop.TabIndex = 5;
            // 
            // lstEnvironments
            // 
            this.lstEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEnvironments.FormattingEnabled = true;
            this.lstEnvironments.Location = new System.Drawing.Point(0, 0);
            this.lstEnvironments.Name = "lstEnvironments";
            this.lstEnvironments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstEnvironments.Size = new System.Drawing.Size(200, 445);
            this.lstEnvironments.TabIndex = 1;
            this.lstEnvironments.SelectedIndexChanged += new System.EventHandler(this.lstEnvironments_SelectedIndexChanged);
            // 
            // tabEndpoints
            // 
            this.tabEndpoints.Controls.Add(this.splitter2);
            this.tabEndpoints.Controls.Add(this.pnlEndPointsRight);
            this.tabEndpoints.Controls.Add(this.pnlEndPointsLeft);
            this.tabEndpoints.Location = new System.Drawing.Point(4, 22);
            this.tabEndpoints.Name = "tabEndpoints";
            this.tabEndpoints.Size = new System.Drawing.Size(786, 451);
            this.tabEndpoints.TabIndex = 2;
            this.tabEndpoints.Text = "EndPoints";
            this.tabEndpoints.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(219, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 451);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // pnlEndPointsRight
            // 
            this.pnlEndPointsRight.Controls.Add(this.groupBox2);
            this.pnlEndPointsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEndPointsRight.Location = new System.Drawing.Point(219, 0);
            this.pnlEndPointsRight.Name = "pnlEndPointsRight";
            this.pnlEndPointsRight.Size = new System.Drawing.Size(567, 451);
            this.pnlEndPointsRight.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridEndPoints);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 451);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EndPoint Properties";
            // 
            // gridEndPoints
            // 
            this.gridEndPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEndPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEndPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridEndPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEndPoints.Location = new System.Drawing.Point(3, 16);
            this.gridEndPoints.MultiSelect = false;
            this.gridEndPoints.Name = "gridEndPoints";
            this.gridEndPoints.RowHeadersVisible = false;
            this.gridEndPoints.RowHeadersWidth = 51;
            this.gridEndPoints.Size = new System.Drawing.Size(561, 432);
            this.gridEndPoints.TabIndex = 5;
            this.gridEndPoints.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEndPoints_CellClick);
            this.gridEndPoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEndPoints_CellContentClick);
            this.gridEndPoints.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEndPoints_CellEnter);
            this.gridEndPoints.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEndPoints_CellValueChanged);
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
            // pnlEndPointsLeft
            // 
            this.pnlEndPointsLeft.Controls.Add(this.pnlEndPointsLeftTop);
            this.pnlEndPointsLeft.Controls.Add(this.pnlEndPointsLeftBottom);
            this.pnlEndPointsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEndPointsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlEndPointsLeft.Name = "pnlEndPointsLeft";
            this.pnlEndPointsLeft.Size = new System.Drawing.Size(219, 451);
            this.pnlEndPointsLeft.TabIndex = 6;
            // 
            // pnlEndPointsLeftTop
            // 
            this.pnlEndPointsLeftTop.Controls.Add(this.lstEndPoints);
            this.pnlEndPointsLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEndPointsLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlEndPointsLeftTop.Name = "pnlEndPointsLeftTop";
            this.pnlEndPointsLeftTop.Size = new System.Drawing.Size(219, 362);
            this.pnlEndPointsLeftTop.TabIndex = 8;
            // 
            // lstEndPoints
            // 
            this.lstEndPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEndPoints.FormattingEnabled = true;
            this.lstEndPoints.Location = new System.Drawing.Point(0, 0);
            this.lstEndPoints.Name = "lstEndPoints";
            this.lstEndPoints.Size = new System.Drawing.Size(219, 362);
            this.lstEndPoints.TabIndex = 1;
            this.lstEndPoints.SelectedIndexChanged += new System.EventHandler(this.lstEndPoints_SelectedIndexChanged);
            // 
            // pnlEndPointsLeftBottom
            // 
            this.pnlEndPointsLeftBottom.Controls.Add(this.btnEndPointsAdd);
            this.pnlEndPointsLeftBottom.Controls.Add(this.btnColumnsMoveUp);
            this.pnlEndPointsLeftBottom.Controls.Add(this.btnColumnsMoveDown);
            this.pnlEndPointsLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEndPointsLeftBottom.Location = new System.Drawing.Point(0, 362);
            this.pnlEndPointsLeftBottom.Name = "pnlEndPointsLeftBottom";
            this.pnlEndPointsLeftBottom.Size = new System.Drawing.Size(219, 89);
            this.pnlEndPointsLeftBottom.TabIndex = 7;
            // 
            // btnEndPointsAdd
            // 
            this.btnEndPointsAdd.Location = new System.Drawing.Point(3, 3);
            this.btnEndPointsAdd.Name = "btnEndPointsAdd";
            this.btnEndPointsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnEndPointsAdd.TabIndex = 2;
            this.btnEndPointsAdd.Text = "Add EndPoint";
            this.btnEndPointsAdd.UseVisualStyleBackColor = true;
            this.btnEndPointsAdd.Click += new System.EventHandler(this.btnColumnsAdd_Click);
            // 
            // btnColumnsMoveUp
            // 
            this.btnColumnsMoveUp.Location = new System.Drawing.Point(3, 32);
            this.btnColumnsMoveUp.Name = "btnColumnsMoveUp";
            this.btnColumnsMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnColumnsMoveUp.TabIndex = 3;
            this.btnColumnsMoveUp.Text = "Move Up";
            this.btnColumnsMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnsMoveUp.Click += new System.EventHandler(this.btnColumnsMoveUp_Click);
            // 
            // btnColumnsMoveDown
            // 
            this.btnColumnsMoveDown.Location = new System.Drawing.Point(3, 61);
            this.btnColumnsMoveDown.Name = "btnColumnsMoveDown";
            this.btnColumnsMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnColumnsMoveDown.TabIndex = 4;
            this.btnColumnsMoveDown.Text = "Move Down";
            this.btnColumnsMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnsMoveDown.Click += new System.EventHandler(this.btnColumnsMoveDown_Click);
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
            // frmAPISettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAPISettings";
            this.ShowInTaskbar = false;
            this.Text = "frmReportSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAPISettings_FormClosing);
            this.Load += new System.EventHandler(this.frmReportSettings_Load);
            tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabEnvironments.ResumeLayout(false);
            this.pnlEnvironmentsRight.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEnvironments)).EndInit();
            this.pnlEnvironmentsLeft.ResumeLayout(false);
            this.pnlEnvironmentsLeftBottom.ResumeLayout(false);
            this.pnlEnvironmentLeftTop.ResumeLayout(false);
            this.tabEndpoints.ResumeLayout(false);
            this.pnlEndPointsRight.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEndPoints)).EndInit();
            this.pnlEndPointsLeft.ResumeLayout(false);
            this.pnlEndPointsLeftTop.ResumeLayout(false);
            this.pnlEndPointsLeftBottom.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEnvironments;
        private System.Windows.Forms.TabPage tabEndpoints;
        private System.Windows.Forms.Button btnColumnsMoveDown;
        private System.Windows.Forms.Button btnColumnsMoveUp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridEndPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnEndPointsAdd;
        private System.Windows.Forms.ListBox lstEndPoints;
        private System.Windows.Forms.DataGridView dataProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnEnvironmentMoveDown;
        private System.Windows.Forms.Button btnEnvironmentMoveUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddEnvironment;
        private System.Windows.Forms.ListBox lstEnvironments;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlEnvironmentsRight;
        private System.Windows.Forms.DataGridView gridEnvironments;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel pnlEnvironmentsLeft;
        private System.Windows.Forms.Panel pnlEnvironmentsLeftBottom;
        private System.Windows.Forms.Panel pnlEnvironmentLeftTop;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlEndPointsRight;
        private System.Windows.Forms.Panel pnlEndPointsLeft;
        private System.Windows.Forms.Panel pnlEndPointsLeftTop;
        private System.Windows.Forms.Panel pnlEndPointsLeftBottom;
    }
}