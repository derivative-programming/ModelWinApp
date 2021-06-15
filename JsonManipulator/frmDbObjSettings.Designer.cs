﻿
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlPropRight = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridPropertiesProp = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPropLeft = new System.Windows.Forms.Panel();
            this.pnlPropLeftBottom = new System.Windows.Forms.Panel();
            this.btnProperties = new System.Windows.Forms.Button();
            this.pnlPropLeftTop = new System.Windows.Forms.Panel();
            this.lstProperties = new System.Windows.Forms.ListBox();
            this.tabPropSubscribers = new System.Windows.Forms.TabPage();
            this.pnlPropSubRight = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridPropSubProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPropSubLeft = new System.Windows.Forms.Panel();
            this.pnlPropSubLeftBottom = new System.Windows.Forms.Panel();
            this.pnlPropSubLeftTop = new System.Windows.Forms.Panel();
            this.lstPropSubs = new System.Windows.Forms.ListBox();
            this.tabModelServiceSubscriptions = new System.Windows.Forms.TabPage();
            this.pnlModelServiceSubRight = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridModelServiceSubProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlModelServiceSubLeft = new System.Windows.Forms.Panel();
            this.pnlModelServiceSubLeftBottom = new System.Windows.Forms.Panel();
            this.pnlModelServiceSubLeftTop = new System.Windows.Forms.Panel();
            this.lstModelServiceSubs = new System.Windows.Forms.ListBox();
            this.grpBoxMain = new System.Windows.Forms.GroupBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).BeginInit();
            this.tabProp.SuspendLayout();
            this.pnlPropRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPropertiesProp)).BeginInit();
            this.pnlPropLeft.SuspendLayout();
            this.pnlPropLeftBottom.SuspendLayout();
            this.pnlPropLeftTop.SuspendLayout();
            this.tabPropSubscribers.SuspendLayout();
            this.pnlPropSubRight.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPropSubProperties)).BeginInit();
            this.pnlPropSubLeft.SuspendLayout();
            this.pnlPropSubLeftTop.SuspendLayout();
            this.tabModelServiceSubscriptions.SuspendLayout();
            this.pnlModelServiceSubRight.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModelServiceSubProperties)).BeginInit();
            this.pnlModelServiceSubLeft.SuspendLayout();
            this.pnlModelServiceSubLeftTop.SuspendLayout();
            this.grpBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabProp);
            this.tabControl1.Controls.Add(this.tabPropSubscribers);
            this.tabControl1.Controls.Add(this.tabModelServiceSubscriptions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(838, 440);
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
            this.tabSettings.Size = new System.Drawing.Size(830, 414);
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
            this.dataProperties.Size = new System.Drawing.Size(824, 408);
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
            this.tabProp.Controls.Add(this.splitter1);
            this.tabProp.Controls.Add(this.pnlPropRight);
            this.tabProp.Controls.Add(this.pnlPropLeft);
            this.tabProp.Location = new System.Drawing.Point(4, 22);
            this.tabProp.Name = "tabProp";
            this.tabProp.Padding = new System.Windows.Forms.Padding(3);
            this.tabProp.Size = new System.Drawing.Size(830, 414);
            this.tabProp.TabIndex = 1;
            this.tabProp.Text = "Props";
            this.tabProp.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(203, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 408);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // pnlPropRight
            // 
            this.pnlPropRight.Controls.Add(this.groupBox1);
            this.pnlPropRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropRight.Location = new System.Drawing.Point(203, 3);
            this.pnlPropRight.Name = "pnlPropRight";
            this.pnlPropRight.Size = new System.Drawing.Size(624, 408);
            this.pnlPropRight.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridPropertiesProp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(624, 408);
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
            this.gridPropertiesProp.Size = new System.Drawing.Size(618, 389);
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
            // pnlPropLeft
            // 
            this.pnlPropLeft.Controls.Add(this.pnlPropLeftBottom);
            this.pnlPropLeft.Controls.Add(this.pnlPropLeftTop);
            this.pnlPropLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPropLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlPropLeft.Name = "pnlPropLeft";
            this.pnlPropLeft.Size = new System.Drawing.Size(200, 408);
            this.pnlPropLeft.TabIndex = 9;
            // 
            // pnlPropLeftBottom
            // 
            this.pnlPropLeftBottom.Controls.Add(this.btnProperties);
            this.pnlPropLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPropLeftBottom.Location = new System.Drawing.Point(0, 308);
            this.pnlPropLeftBottom.Name = "pnlPropLeftBottom";
            this.pnlPropLeftBottom.Size = new System.Drawing.Size(200, 100);
            this.pnlPropLeftBottom.TabIndex = 10;
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(3, 3);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProperties.Size = new System.Drawing.Size(75, 23);
            this.btnProperties.TabIndex = 2;
            this.btnProperties.Text = "Add Prop";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // pnlPropLeftTop
            // 
            this.pnlPropLeftTop.Controls.Add(this.lstProperties);
            this.pnlPropLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPropLeftTop.Name = "pnlPropLeftTop";
            this.pnlPropLeftTop.Size = new System.Drawing.Size(200, 408);
            this.pnlPropLeftTop.TabIndex = 10;
            // 
            // lstProperties
            // 
            this.lstProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProperties.FormattingEnabled = true;
            this.lstProperties.Location = new System.Drawing.Point(0, 0);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstProperties.Size = new System.Drawing.Size(200, 408);
            this.lstProperties.TabIndex = 1;
            this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.lstProperties_SelectedIndexChanged);
            // 
            // tabPropSubscribers
            // 
            this.tabPropSubscribers.Controls.Add(this.splitter2);
            this.tabPropSubscribers.Controls.Add(this.pnlPropSubRight);
            this.tabPropSubscribers.Controls.Add(this.pnlPropSubLeft);
            this.tabPropSubscribers.Location = new System.Drawing.Point(4, 22);
            this.tabPropSubscribers.Name = "tabPropSubscribers";
            this.tabPropSubscribers.Size = new System.Drawing.Size(830, 414);
            this.tabPropSubscribers.TabIndex = 2;
            this.tabPropSubscribers.Text = "Prop Subscribers";
            this.tabPropSubscribers.UseVisualStyleBackColor = true;
            // 
            // pnlPropSubRight
            // 
            this.pnlPropSubRight.Controls.Add(this.groupBox2);
            this.pnlPropSubRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropSubRight.Location = new System.Drawing.Point(200, 0);
            this.pnlPropSubRight.Name = "pnlPropSubRight";
            this.pnlPropSubRight.Size = new System.Drawing.Size(630, 414);
            this.pnlPropSubRight.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridPropSubProperties);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(630, 414);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prop Subscriber Properties";
            // 
            // gridPropSubProperties
            // 
            this.gridPropSubProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPropSubProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPropSubProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gridPropSubProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPropSubProperties.Location = new System.Drawing.Point(3, 16);
            this.gridPropSubProperties.Name = "gridPropSubProperties";
            this.gridPropSubProperties.RowHeadersVisible = false;
            this.gridPropSubProperties.Size = new System.Drawing.Size(624, 395);
            this.gridPropSubProperties.TabIndex = 3;
            this.gridPropSubProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropSubProperties_CellClick);
            this.gridPropSubProperties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.gridPropSubProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropSubProperties_CellEnter);
            this.gridPropSubProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPropSubProperties_CellValueChanged);
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
            // pnlPropSubLeft
            // 
            this.pnlPropSubLeft.Controls.Add(this.pnlPropSubLeftBottom);
            this.pnlPropSubLeft.Controls.Add(this.pnlPropSubLeftTop);
            this.pnlPropSubLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPropSubLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlPropSubLeft.Name = "pnlPropSubLeft";
            this.pnlPropSubLeft.Size = new System.Drawing.Size(200, 414);
            this.pnlPropSubLeft.TabIndex = 10;
            // 
            // pnlPropSubLeftBottom
            // 
            this.pnlPropSubLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPropSubLeftBottom.Location = new System.Drawing.Point(0, 314);
            this.pnlPropSubLeftBottom.Name = "pnlPropSubLeftBottom";
            this.pnlPropSubLeftBottom.Size = new System.Drawing.Size(200, 100);
            this.pnlPropSubLeftBottom.TabIndex = 10;
            // 
            // pnlPropSubLeftTop
            // 
            this.pnlPropSubLeftTop.Controls.Add(this.lstPropSubs);
            this.pnlPropSubLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropSubLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPropSubLeftTop.Name = "pnlPropSubLeftTop";
            this.pnlPropSubLeftTop.Size = new System.Drawing.Size(200, 414);
            this.pnlPropSubLeftTop.TabIndex = 10;
            // 
            // lstPropSubs
            // 
            this.lstPropSubs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPropSubs.FormattingEnabled = true;
            this.lstPropSubs.Location = new System.Drawing.Point(0, 0);
            this.lstPropSubs.Name = "lstPropSubs";
            this.lstPropSubs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstPropSubs.Size = new System.Drawing.Size(200, 414);
            this.lstPropSubs.TabIndex = 1;
            this.lstPropSubs.SelectedIndexChanged += new System.EventHandler(this.lstPropSubs_SelectedIndexChanged);
            // 
            // tabModelServiceSubscriptions
            // 
            this.tabModelServiceSubscriptions.Controls.Add(this.splitter3);
            this.tabModelServiceSubscriptions.Controls.Add(this.pnlModelServiceSubRight);
            this.tabModelServiceSubscriptions.Controls.Add(this.pnlModelServiceSubLeft);
            this.tabModelServiceSubscriptions.Location = new System.Drawing.Point(4, 22);
            this.tabModelServiceSubscriptions.Name = "tabModelServiceSubscriptions";
            this.tabModelServiceSubscriptions.Size = new System.Drawing.Size(830, 414);
            this.tabModelServiceSubscriptions.TabIndex = 3;
            this.tabModelServiceSubscriptions.Text = "Model Service Subscriptions";
            this.tabModelServiceSubscriptions.UseVisualStyleBackColor = true;
            // 
            // pnlModelServiceSubRight
            // 
            this.pnlModelServiceSubRight.Controls.Add(this.groupBox3);
            this.pnlModelServiceSubRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelServiceSubRight.Location = new System.Drawing.Point(200, 0);
            this.pnlModelServiceSubRight.Name = "pnlModelServiceSubRight";
            this.pnlModelServiceSubRight.Size = new System.Drawing.Size(630, 414);
            this.pnlModelServiceSubRight.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridModelServiceSubProperties);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(630, 414);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model Service Subscription Properties";
            // 
            // gridModelServiceSubProperties
            // 
            this.gridModelServiceSubProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridModelServiceSubProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModelServiceSubProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.gridModelServiceSubProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridModelServiceSubProperties.Location = new System.Drawing.Point(3, 16);
            this.gridModelServiceSubProperties.Name = "gridModelServiceSubProperties";
            this.gridModelServiceSubProperties.RowHeadersVisible = false;
            this.gridModelServiceSubProperties.Size = new System.Drawing.Size(624, 395);
            this.gridModelServiceSubProperties.TabIndex = 3;
            this.gridModelServiceSubProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModelServiceSubProperties_CellClick);
            this.gridModelServiceSubProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModelServiceSubProperties_CellEnter);
            this.gridModelServiceSubProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModelServiceSubProperties_CellValueChanged);
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
            // pnlModelServiceSubLeft
            // 
            this.pnlModelServiceSubLeft.Controls.Add(this.pnlModelServiceSubLeftBottom);
            this.pnlModelServiceSubLeft.Controls.Add(this.pnlModelServiceSubLeftTop);
            this.pnlModelServiceSubLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModelServiceSubLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlModelServiceSubLeft.Name = "pnlModelServiceSubLeft";
            this.pnlModelServiceSubLeft.Size = new System.Drawing.Size(200, 414);
            this.pnlModelServiceSubLeft.TabIndex = 10;
            // 
            // pnlModelServiceSubLeftBottom
            // 
            this.pnlModelServiceSubLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModelServiceSubLeftBottom.Location = new System.Drawing.Point(0, 314);
            this.pnlModelServiceSubLeftBottom.Name = "pnlModelServiceSubLeftBottom";
            this.pnlModelServiceSubLeftBottom.Size = new System.Drawing.Size(200, 100);
            this.pnlModelServiceSubLeftBottom.TabIndex = 10;
            // 
            // pnlModelServiceSubLeftTop
            // 
            this.pnlModelServiceSubLeftTop.Controls.Add(this.lstModelServiceSubs);
            this.pnlModelServiceSubLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModelServiceSubLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlModelServiceSubLeftTop.Name = "pnlModelServiceSubLeftTop";
            this.pnlModelServiceSubLeftTop.Size = new System.Drawing.Size(200, 414);
            this.pnlModelServiceSubLeftTop.TabIndex = 10;
            // 
            // lstModelServiceSubs
            // 
            this.lstModelServiceSubs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstModelServiceSubs.FormattingEnabled = true;
            this.lstModelServiceSubs.Location = new System.Drawing.Point(0, 0);
            this.lstModelServiceSubs.Name = "lstModelServiceSubs";
            this.lstModelServiceSubs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstModelServiceSubs.Size = new System.Drawing.Size(200, 414);
            this.lstModelServiceSubs.TabIndex = 1;
            this.lstModelServiceSubs.SelectedIndexChanged += new System.EventHandler(this.lstModelServiceSubs_SelectedIndexChanged);
            // 
            // grpBoxMain
            // 
            this.grpBoxMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBoxMain.Controls.Add(this.tabControl1);
            this.grpBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxMain.Location = new System.Drawing.Point(0, 0);
            this.grpBoxMain.Name = "grpBoxMain";
            this.grpBoxMain.Size = new System.Drawing.Size(844, 459);
            this.grpBoxMain.TabIndex = 1;
            this.grpBoxMain.TabStop = false;
            this.grpBoxMain.Text = "groupBox2";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(200, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 414);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(200, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 414);
            this.splitter3.TabIndex = 12;
            this.splitter3.TabStop = false;
            // 
            // frmDbObjSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(844, 459);
            this.Controls.Add(this.grpBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDbObjSettings";
            this.ShowInTaskbar = false;
            this.Text = "frmDbObjSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDbObjSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmDbObjSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProperties)).EndInit();
            this.tabProp.ResumeLayout(false);
            this.pnlPropRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPropertiesProp)).EndInit();
            this.pnlPropLeft.ResumeLayout(false);
            this.pnlPropLeftBottom.ResumeLayout(false);
            this.pnlPropLeftTop.ResumeLayout(false);
            this.tabPropSubscribers.ResumeLayout(false);
            this.pnlPropSubRight.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPropSubProperties)).EndInit();
            this.pnlPropSubLeft.ResumeLayout(false);
            this.pnlPropSubLeftTop.ResumeLayout(false);
            this.tabModelServiceSubscriptions.ResumeLayout(false);
            this.pnlModelServiceSubRight.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModelServiceSubProperties)).EndInit();
            this.pnlModelServiceSubLeft.ResumeLayout(false);
            this.pnlModelServiceSubLeftTop.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlPropRight;
        private System.Windows.Forms.Panel pnlPropLeft;
        private System.Windows.Forms.Panel pnlPropLeftBottom;
        private System.Windows.Forms.Panel pnlPropLeftTop;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPropSubscribers;
        private System.Windows.Forms.Panel pnlPropSubRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridPropSubProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel pnlPropSubLeft;
        private System.Windows.Forms.Panel pnlPropSubLeftBottom;
        private System.Windows.Forms.Panel pnlPropSubLeftTop;
        private System.Windows.Forms.ListBox lstPropSubs;
        private System.Windows.Forms.TabPage tabModelServiceSubscriptions;
        private System.Windows.Forms.Panel pnlModelServiceSubRight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridModelServiceSubProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel pnlModelServiceSubLeft;
        private System.Windows.Forms.Panel pnlModelServiceSubLeftBottom;
        private System.Windows.Forms.Panel pnlModelServiceSubLeftTop;
        private System.Windows.Forms.ListBox lstModelServiceSubs;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
    }
}