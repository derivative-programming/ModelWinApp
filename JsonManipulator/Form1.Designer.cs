
namespace JsonManipulator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Project");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Db Objects");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Forms");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Pages", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("PageInit");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("DynaFlow");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("DynaFlowTasks");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Flows", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("APIs");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPISiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynaFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiSelectFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChildPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIGetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModelFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelAIProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelValidationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelFabricationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelChangeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.endUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apiToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workflowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeMenus = new System.Windows.Forms.TreeView();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchOptions = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.addToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.demoToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1232, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPISiteToolStripMenuItem,
            this.dBObjectToolStripMenuItem,
            this.flowToolStripMenuItem,
            this.formToolStripMenuItem,
            this.reportPageToolStripMenuItem,
            this.userStoryToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.addToolStripMenuItem.Text = "&Add";
            // 
            // aPISiteToolStripMenuItem
            // 
            this.aPISiteToolStripMenuItem.Name = "aPISiteToolStripMenuItem";
            this.aPISiteToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.aPISiteToolStripMenuItem.Text = "API";
            this.aPISiteToolStripMenuItem.Click += new System.EventHandler(this.aPISiteToolStripMenuItem_Click);
            // 
            // dBObjectToolStripMenuItem
            // 
            this.dBObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.lookupToolStripMenuItem,
            this.importToolStripMenuItem});
            this.dBObjectToolStripMenuItem.Name = "dBObjectToolStripMenuItem";
            this.dBObjectToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.dBObjectToolStripMenuItem.Text = "DB Object";
            this.dBObjectToolStripMenuItem.Click += new System.EventHandler(this.dBObjectToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // lookupToolStripMenuItem
            // 
            this.lookupToolStripMenuItem.Name = "lookupToolStripMenuItem";
            this.lookupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.lookupToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.lookupToolStripMenuItem.Text = "Lookup";
            this.lookupToolStripMenuItem.Click += new System.EventHandler(this.lookupToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sqlServerToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // sqlServerToolStripMenuItem
            // 
            this.sqlServerToolStripMenuItem.Name = "sqlServerToolStripMenuItem";
            this.sqlServerToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.sqlServerToolStripMenuItem.Text = "Sql Server";
            this.sqlServerToolStripMenuItem.Click += new System.EventHandler(this.sqlServerToolStripMenuItem_Click_1);
            // 
            // flowToolStripMenuItem
            // 
            this.flowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem1,
            this.aPIToolStripMenuItem,
            this.dynaFlowToolStripMenuItem,
            this.multiSelectFlowToolStripMenuItem});
            this.flowToolStripMenuItem.Name = "flowToolStripMenuItem";
            this.flowToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.flowToolStripMenuItem.Text = "Flow";
            this.flowToolStripMenuItem.Click += new System.EventHandler(this.flowToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem1
            // 
            this.generalToolStripMenuItem1.Name = "generalToolStripMenuItem1";
            this.generalToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.generalToolStripMenuItem1.Size = new System.Drawing.Size(302, 26);
            this.generalToolStripMenuItem1.Text = "General";
            this.generalToolStripMenuItem1.Click += new System.EventHandler(this.generalToolStripMenuItem1_Click);
            // 
            // aPIToolStripMenuItem
            // 
            this.aPIToolStripMenuItem.Name = "aPIToolStripMenuItem";
            this.aPIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.aPIToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.aPIToolStripMenuItem.Text = "For API Endpoint";
            this.aPIToolStripMenuItem.Click += new System.EventHandler(this.aPIToolStripMenuItem_Click);
            // 
            // dynaFlowToolStripMenuItem
            // 
            this.dynaFlowToolStripMenuItem.Name = "dynaFlowToolStripMenuItem";
            this.dynaFlowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Y)));
            this.dynaFlowToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.dynaFlowToolStripMenuItem.Text = "DynaFlow";
            this.dynaFlowToolStripMenuItem.Click += new System.EventHandler(this.dynaFlowToolStripMenuItem_Click);
            // 
            // multiSelectFlowToolStripMenuItem
            // 
            this.multiSelectFlowToolStripMenuItem.Name = "multiSelectFlowToolStripMenuItem";
            this.multiSelectFlowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.multiSelectFlowToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.multiSelectFlowToolStripMenuItem.Text = "Multi-Select Flow";
            this.multiSelectFlowToolStripMenuItem.Click += new System.EventHandler(this.multiSelectFlowToolStripMenuItem_Click);
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageToolStripMenuItem,
            this.addChildPageToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.formToolStripMenuItem.Text = "Form";
            this.formToolStripMenuItem.Click += new System.EventHandler(this.formToolStripMenuItem_Click);
            // 
            // pageToolStripMenuItem
            // 
            this.pageToolStripMenuItem.Name = "pageToolStripMenuItem";
            this.pageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.pageToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.pageToolStripMenuItem.Text = "Page";
            this.pageToolStripMenuItem.Click += new System.EventHandler(this.pageToolStripMenuItem_Click);
            // 
            // addChildPageToolStripMenuItem
            // 
            this.addChildPageToolStripMenuItem.Name = "addChildPageToolStripMenuItem";
            this.addChildPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.addChildPageToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.addChildPageToolStripMenuItem.Text = "Add Child Page";
            this.addChildPageToolStripMenuItem.Click += new System.EventHandler(this.addChildPageToolStripMenuItem_Click);
            // 
            // reportPageToolStripMenuItem
            // 
            this.reportPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.detailToolStripMenuItem,
            this.aPIGetToolStripMenuItem,
            this.navigationToolStripMenuItem});
            this.reportPageToolStripMenuItem.Name = "reportPageToolStripMenuItem";
            this.reportPageToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.reportPageToolStripMenuItem.Text = "Report Page";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.detailToolStripMenuItem.Text = "Detail";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.detailToolStripMenuItem_Click);
            // 
            // aPIGetToolStripMenuItem
            // 
            this.aPIGetToolStripMenuItem.Name = "aPIGetToolStripMenuItem";
            this.aPIGetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.aPIGetToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.aPIGetToolStripMenuItem.Text = "API Get";
            this.aPIGetToolStripMenuItem.Click += new System.EventHandler(this.aPIGetToolStripMenuItem_Click);
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.navigationToolStripMenuItem.Text = "Navigation";
            this.navigationToolStripMenuItem.Click += new System.EventHandler(this.navigationToolStripMenuItem_Click);
            // 
            // userStoryToolStripMenuItem
            // 
            this.userStoryToolStripMenuItem.Name = "userStoryToolStripMenuItem";
            this.userStoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.userStoryToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.userStoryToolStripMenuItem.Text = "User Story";
            this.userStoryToolStripMenuItem.Click += new System.EventHandler(this.userStoryToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.addModelFeaturesToolStripMenuItem,
            this.modelAIProcessingToolStripMenuItem,
            this.modelValidationToolStripMenuItem,
            this.templateSelectionToolStripMenuItem,
            this.modelFabricationToolStripMenuItem,
            this.modelChangeReportToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.servicesToolStripMenuItem.Text = "&Services";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // addModelFeaturesToolStripMenuItem
            // 
            this.addModelFeaturesToolStripMenuItem.Name = "addModelFeaturesToolStripMenuItem";
            this.addModelFeaturesToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.addModelFeaturesToolStripMenuItem.Text = "Add Model Features";
            this.addModelFeaturesToolStripMenuItem.Click += new System.EventHandler(this.addModelFeaturesToolStripMenuItem_Click);
            // 
            // modelAIProcessingToolStripMenuItem
            // 
            this.modelAIProcessingToolStripMenuItem.Name = "modelAIProcessingToolStripMenuItem";
            this.modelAIProcessingToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.modelAIProcessingToolStripMenuItem.Text = "Model AI Processing";
            this.modelAIProcessingToolStripMenuItem.Click += new System.EventHandler(this.modelAIProcessingToolStripMenuItem_Click);
            // 
            // modelValidationToolStripMenuItem
            // 
            this.modelValidationToolStripMenuItem.Name = "modelValidationToolStripMenuItem";
            this.modelValidationToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.modelValidationToolStripMenuItem.Text = "Model Validation";
            this.modelValidationToolStripMenuItem.Click += new System.EventHandler(this.modelValidationToolStripMenuItem_Click);
            // 
            // templateSelectionToolStripMenuItem
            // 
            this.templateSelectionToolStripMenuItem.Name = "templateSelectionToolStripMenuItem";
            this.templateSelectionToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.templateSelectionToolStripMenuItem.Text = "Blueprint Selection";
            this.templateSelectionToolStripMenuItem.Click += new System.EventHandler(this.templateSelectionToolStripMenuItem_Click);
            // 
            // modelFabricationToolStripMenuItem
            // 
            this.modelFabricationToolStripMenuItem.Name = "modelFabricationToolStripMenuItem";
            this.modelFabricationToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.modelFabricationToolStripMenuItem.Text = "Fabrication";
            this.modelFabricationToolStripMenuItem.Click += new System.EventHandler(this.modelFabricationToolStripMenuItem_Click);
            // 
            // modelChangeReportToolStripMenuItem
            // 
            this.modelChangeReportToolStripMenuItem.Name = "modelChangeReportToolStripMenuItem";
            this.modelChangeReportToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.modelChangeReportToolStripMenuItem.Text = "Model Change Report";
            this.modelChangeReportToolStripMenuItem.Click += new System.EventHandler(this.modelChangeReportToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeToolStripMenuItem,
            this.demoToolStripMenuItem1,
            this.diagramsToolStripMenuItem});
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.demoToolStripMenuItem.Text = "Fa&brication";
            this.demoToolStripMenuItem.Click += new System.EventHandler(this.demoToolStripMenuItem_Click);
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.codeToolStripMenuItem.Text = "Code";
            this.codeToolStripMenuItem.Click += new System.EventHandler(this.codeToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem1
            // 
            this.demoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endUserToolStripMenuItem1,
            this.adminUserToolStripMenuItem1,
            this.configUserToolStripMenuItem1});
            this.demoToolStripMenuItem1.Name = "demoToolStripMenuItem1";
            this.demoToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.demoToolStripMenuItem1.Text = "Demo";
            this.demoToolStripMenuItem1.Click += new System.EventHandler(this.demoToolStripMenuItem1_Click);
            // 
            // endUserToolStripMenuItem1
            // 
            this.endUserToolStripMenuItem1.Name = "endUserToolStripMenuItem1";
            this.endUserToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.endUserToolStripMenuItem1.Text = "End User";
            this.endUserToolStripMenuItem1.Click += new System.EventHandler(this.endUserToolStripMenuItem1_Click);
            // 
            // adminUserToolStripMenuItem1
            // 
            this.adminUserToolStripMenuItem1.Name = "adminUserToolStripMenuItem1";
            this.adminUserToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.adminUserToolStripMenuItem1.Text = "Admin User";
            this.adminUserToolStripMenuItem1.Click += new System.EventHandler(this.adminUserToolStripMenuItem1_Click);
            // 
            // configUserToolStripMenuItem1
            // 
            this.configUserToolStripMenuItem1.Name = "configUserToolStripMenuItem1";
            this.configUserToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.configUserToolStripMenuItem1.Text = "Config User";
            this.configUserToolStripMenuItem1.Click += new System.EventHandler(this.configUserToolStripMenuItem1_Click);
            // 
            // diagramsToolStripMenuItem
            // 
            this.diagramsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apiToolStripMenuItem2,
            this.databaseToolStripMenuItem,
            this.pageFlowToolStripMenuItem,
            this.workflowsToolStripMenuItem});
            this.diagramsToolStripMenuItem.Name = "diagramsToolStripMenuItem";
            this.diagramsToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.diagramsToolStripMenuItem.Text = "Diagrams";
            // 
            // apiToolStripMenuItem2
            // 
            this.apiToolStripMenuItem2.Name = "apiToolStripMenuItem2";
            this.apiToolStripMenuItem2.Size = new System.Drawing.Size(222, 26);
            this.apiToolStripMenuItem2.Text = "Api";
            this.apiToolStripMenuItem2.Click += new System.EventHandler(this.apiToolStripMenuItem2_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.databaseToolStripMenuItem.Text = "Database Hierarchy";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // pageFlowToolStripMenuItem
            // 
            this.pageFlowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.publicToolStripMenuItem,
            this.endUserToolStripMenuItem,
            this.adminUserToolStripMenuItem,
            this.configUserToolStripMenuItem});
            this.pageFlowToolStripMenuItem.Name = "pageFlowToolStripMenuItem";
            this.pageFlowToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.pageFlowToolStripMenuItem.Text = "PageFlow";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // publicToolStripMenuItem
            // 
            this.publicToolStripMenuItem.Name = "publicToolStripMenuItem";
            this.publicToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.publicToolStripMenuItem.Text = "Public";
            this.publicToolStripMenuItem.Click += new System.EventHandler(this.publicToolStripMenuItem_Click);
            // 
            // endUserToolStripMenuItem
            // 
            this.endUserToolStripMenuItem.Name = "endUserToolStripMenuItem";
            this.endUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.endUserToolStripMenuItem.Text = "End User";
            this.endUserToolStripMenuItem.Click += new System.EventHandler(this.endUserToolStripMenuItem_Click);
            // 
            // adminUserToolStripMenuItem
            // 
            this.adminUserToolStripMenuItem.Name = "adminUserToolStripMenuItem";
            this.adminUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.adminUserToolStripMenuItem.Text = "Admin User";
            this.adminUserToolStripMenuItem.Click += new System.EventHandler(this.adminUserToolStripMenuItem_Click);
            // 
            // configUserToolStripMenuItem
            // 
            this.configUserToolStripMenuItem.Name = "configUserToolStripMenuItem";
            this.configUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.configUserToolStripMenuItem.Text = "Config User";
            this.configUserToolStripMenuItem.Click += new System.EventHandler(this.configUserToolStripMenuItem_Click);
            // 
            // workflowsToolStripMenuItem
            // 
            this.workflowsToolStripMenuItem.Name = "workflowsToolStripMenuItem";
            this.workflowsToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.workflowsToolStripMenuItem.Text = "Workflows";
            this.workflowsToolStripMenuItem.Click += new System.EventHandler(this.workflowsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // nodeMenus
            // 
            this.nodeMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeMenus.HideSelection = false;
            this.nodeMenus.ImageIndex = 0;
            this.nodeMenus.ImageList = this.imgIcons;
            this.nodeMenus.Location = new System.Drawing.Point(0, 73);
            this.nodeMenus.Name = "nodeMenus";
            treeNode1.Name = "Project";
            treeNode1.Text = "Project";
            treeNode2.Name = "dbObjects";
            treeNode2.Text = "Db Objects";
            treeNode3.Name = "Forms";
            treeNode3.Text = "Forms";
            treeNode4.Name = "Reports";
            treeNode4.Text = "Reports";
            treeNode5.Name = "pages";
            treeNode5.Text = "Pages";
            treeNode6.Name = "nodeFlowPageInit";
            treeNode6.Text = "PageInit";
            treeNode7.Name = "nodeFlowGeneral";
            treeNode7.Text = "General";
            treeNode8.Name = "nodeFlowDynaFlow";
            treeNode8.Text = "DynaFlow";
            treeNode9.Name = "nodeFlowDynaFlowTask";
            treeNode9.Text = "DynaFlowTasks";
            treeNode10.Name = "nodeFlows";
            treeNode10.Text = "Flows";
            treeNode11.Name = "nodeApis";
            treeNode11.Text = "APIs";
            this.nodeMenus.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode10,
            treeNode11});
            this.nodeMenus.SelectedImageIndex = 0;
            this.nodeMenus.Size = new System.Drawing.Size(185, 511);
            this.nodeMenus.TabIndex = 1;
            this.nodeMenus.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeMenus_AfterSelect);
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "folder.png");
            this.imgIcons.Images.SetKeyName(1, "list.png");
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1043, 584);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 606);
            this.panel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nodeMenus);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1232, 584);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearchOptions);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(185, 73);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSearchOptions
            // 
            this.btnSearchOptions.Location = new System.Drawing.Point(13, 37);
            this.btnSearchOptions.Name = "btnSearchOptions";
            this.btnSearchOptions.Size = new System.Drawing.Size(159, 29);
            this.btnSearchOptions.TabIndex = 2;
            this.btnSearchOptions.Text = "Search Options";
            this.btnSearchOptions.UseVisualStyleBackColor = true;
            this.btnSearchOptions.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(63, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(112, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1232, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 16);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1232, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Project: MyCompanyApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.TreeView nodeMenus;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem flowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPISiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIGetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelAIProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelValidationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelFabricationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModelFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem adminUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem endUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apiToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modelChangeReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workflowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynaFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.Button btnSearchOptions;
        private System.Windows.Forms.ToolStripMenuItem multiSelectFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChildPageToolStripMenuItem;
    }
}

