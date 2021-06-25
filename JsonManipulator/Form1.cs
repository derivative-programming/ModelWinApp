using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class Form1 : Form
    {
        public static  RootObject _model;   
        public static string _path;

        private string _initialModelPath = string.Empty;
        private bool _displayModelFeaturesTab = false;

        public Form1(string initialModelPath)
        {
            InitializeComponent();
            _initialModelPath = initialModelPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenAPIs.ApiManager.Initialize();
            nodeMenus.TabStop = false;
            nodeMenus.Enabled = false; 
            UpdateMenuState();

            splitContainer1.SplitterDistance = System.Convert.ToInt32(LocalStorage.GetValue("Form1.splitContainer1.SplitterDistance", "200"));
        
            if(this._initialModelPath.Trim().Length > 0 &&
                System.IO.File.Exists(this._initialModelPath))
            {
                LoadModelFile(this._initialModelPath);
            }
            UpdateLoginStatusDispaly();
        }

        public string GetModelPath()
        {
            return _path;
        }

        public void SaveModel()
        {
            this.UseWaitCursor = true;
            string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }); 
            File.WriteAllText(_path, json);
            Utils.SortJsonFile(_path);
            ShowNoUnsavedChanges();
            this.UseWaitCursor = false;
        }

        private ToolStripMenuItem AddMenu (string Name)
        {
            ToolStripMenuItem FileMenu = new ToolStripMenuItem(Name);
            FileMenu.Text = Name;
            FileMenu.TextAlign = ContentAlignment.MiddleRight;
            FileMenu.ToolTipText = "Click Me";

            return FileMenu;
        }

        public void PopulateTree()
        {
            PopulateTree(txtSearch.Text); 
        }
        public void PopulateTree(string filter)
        {

            populateProjectDetails();
            populateDbObjects(filter);
            populatePageAndFlows(filter);  
            populateAPIs(filter);
        }
        public void populateProjectDetails()
        {

            this.Text = "Project: " + _model.root.ProjectName;
            nodeMenus.Nodes["Project"].Text = _model.root.ProjectName;
            if(nodeMenus.Nodes["Project"].Text.Trim().Length == 0)
            {
                nodeMenus.Nodes["Project"].Text = "Project";
            }
        }
        private void populateDbObjects(string filter)
        {
            nodeMenus.Nodes["dbObjects"].Nodes.Clear();
            NameSpaceObject nameSpaceObject = _model.root.NameSpaceObjects.FirstOrDefault();

            if (nameSpaceObject.ObjectMap == null)
                return;

            foreach (var dbObj in nameSpaceObject.ObjectMap.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())))
            {
                PopulateTree(dbObj); 
            }
        }
        private void populatePageAndFlows(string filter)
        {
            nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Clear();
            nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Clear();
            nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowPageInit"].Nodes.Clear();
            nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowGeneral"].Nodes.Clear();
            nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowDynaFlow"].Nodes.Clear();
            nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowDynaFlowTask"].Nodes.Clear();
            NameSpaceObject nameSpaceObject = _model.root.NameSpaceObjects.FirstOrDefault();

            if (nameSpaceObject.ObjectMap == null)
                return;

            foreach (var dbObj in nameSpaceObject.ObjectMap)
            {
                if(dbObj.objectWorkflow !=null)
                {
                    foreach (var objWF in dbObj.objectWorkflow.Where(x=>x.Name.Trim().ToLower().Contains(filter.Trim().ToLower())))
                    {
                        PopulateTree(objWF); 
                    }
                }
                if(dbObj.report != null)
                {
                    foreach (var rpt in dbObj.report.Where(x => x.name.Trim().ToLower().Contains(filter.Trim().ToLower())))
                    {
                        PopulateTree(rpt); 
                    }
                }
                
            }
           
        } 

         

        private void populateAPIs(string filter)
        {
            nodeMenus.Nodes["nodeApis"].Nodes.Clear();

            NameSpaceObject nameSpaceObject = _model.root.NameSpaceObjects.FirstOrDefault();

            if (nameSpaceObject.apiSite == null)
                return;

            foreach (var api in nameSpaceObject.apiSite)
            {
                TreeNode node = new TreeNode();
                node.Text = api.name;
                node.Name = api.name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["nodeApis"].Nodes.Add(node);
            }

        }

        private TreeNode PopulateTree(Models.objectWorkflow objWF)
        {
            TreeNode result = null;

            if (!Utils.IsObjectWorkflowAFlow(objWF))
            {
                TreeNode node = new TreeNode();
                node.Text = objWF.Name;
                node.Name = objWF.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Add(node);
                result = node;

            } 
            else if (Utils.IsObjectWorkflowAPageInitFlow(objWF))
            {

                TreeNode node = new TreeNode();
                node.Text = objWF.Name;
                node.Name = objWF.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowPageInit"].Nodes.Add(node);
                result = node;
            }
            else if (Utils.IsObjectWorkflowADynaFlow(objWF))
            {

                TreeNode node = new TreeNode();
                node.Text = objWF.Name;
                node.Name = objWF.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowDynaFlow"].Nodes.Add(node);
                result = node;
            }
            else if (Utils.IsObjectWorkflowADynaFlowTask(objWF))
            {

                TreeNode node = new TreeNode();
                node.Text = objWF.Name;
                node.Name = objWF.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowDynaFlowTask"].Nodes.Add(node);
                result = node;
            }
            else
            {

                TreeNode node = new TreeNode();
                node.Text = objWF.Name;
                node.Name = objWF.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowGeneral"].Nodes.Add(node);
                result = node;
            }
            return result;
        }

        public TreeNode PopulateTree(ObjectMap objectMap)
        {
            TreeNode result = null;

            TreeNode node = new TreeNode();
            node.Text = objectMap.name;
            node.Name = objectMap.name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["dbObjects"].Nodes.Add(node);
            result = node;

            return result;
        }
        public TreeNode PopulateTree(Report report)
        {
            TreeNode result = null;

            TreeNode node = new TreeNode();
            node.Text = report.name;
            node.Name = report.name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Add(node);
            result = node;

            return result;
        }
        public TreeNode PopulateTree(Models.apiSite apiSite)
        {
            TreeNode result = null;

            if (((frmAPISettings)Application.OpenForms["frmAPISettings"]) != null)
                ((frmAPISettings)Application.OpenForms["frmAPISettings"]).Close();
            TreeNode node = new TreeNode();
            node.Text = apiSite.name;
            node.Name = apiSite.name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["nodeApis"].Nodes.Add(node);
            result = node;

            return result;
        }
         
        public void SetSelectedTreeItem(string name)
        {
            nodeMenus.SelectedNode = null;
             
            foreach (TreeNode tn in nodeMenus.Nodes)
            {
                SetSelectedTreeItem(tn, name);
            }
        }
        public void SetSelectedTreeItem(TreeNode node, string name)
        {
            if(node.Text == name)
            {
                nodeMenus.SelectedNode = node; 
            }
            if(nodeMenus.SelectedNode != null)
            {
                return;
            }
            foreach (TreeNode tn in node.Nodes)
            {
                SetSelectedTreeItem(tn, name);
            }
        }
        private void dBObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nodeMenus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.mainPanel.Controls.Clear();
            int level = e.Node.Level;
            NameSpaceObject nameSpaceObject = _model.root.NameSpaceObjects.FirstOrDefault();
            switch (level)
            {
                case 0:
                    if (e.Node.Name == "Project")
                    {
                        frmSettings frmSettings = new frmSettings(_model.root, _displayModelFeaturesTab);
                        _displayModelFeaturesTab = false;
                        frmSettings.TopLevel = false;
                        frmSettings.AutoScroll = true;
                        frmSettings.Dock = DockStyle.Fill;
                        //frmSettings.Height = this.mainPanel.Height;
                        //frmSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmSettings);
                        frmSettings.Show();
                    }
                    break;
                case 1: //Db Objects,Flows
                    if(e.Node.Parent.Name == "dbObjects")
                    {
                        if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
                            ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).Close();
                        ObjectMap objectMap = nameSpaceObject.ObjectMap.Where(x => x.name == e.Node.Name).FirstOrDefault();
                        frmDbObjSettings frmDbObjSettings = new frmDbObjSettings(objectMap);
                        frmDbObjSettings.TopLevel = false;
                        frmDbObjSettings.AutoScroll = true;
                        frmDbObjSettings.Dock = DockStyle.Fill;
                        //frmDbObjSettings.Height = this.mainPanel.Height;
                        //frmDbObjSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmDbObjSettings);
                        frmDbObjSettings.Show();
                    }
                    if (e.Node.Parent.Name == "nodeFlows")
                    {
                        //if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                        //    ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close(); 
                        //frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                        //frmFormSettings.TopLevel = false;
                        //frmFormSettings.AutoScroll = true;
                        //frmFormSettings.Dock = DockStyle.Fill;
                        ////frmFormSettings.Height = this.mainPanel.Height;
                        ////frmFormSettings.Width = this.mainPanel.Width;
                        //this.mainPanel.Controls.Add(frmFormSettings);
                        //frmFormSettings.Show();
                        //break;
                    }
                    if (e.Node.Parent.Name == "nodeApis")
                    {
                        if (((frmAPISettings)Application.OpenForms["frmAPISettings"]) != null)
                            ((frmAPISettings)Application.OpenForms["frmAPISettings"]).Close();
                        frmAPISettings frmAPISettings = new frmAPISettings(e.Node.Name);
                        frmAPISettings.TopLevel = false;
                        frmAPISettings.AutoScroll = true;
                        frmAPISettings.Dock = DockStyle.Fill;
                        //frmFormSettings.Height = this.mainPanel.Height;
                        //frmFormSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmAPISettings);
                        frmAPISettings.Show();
                        break;
                    }
                    break;
                case 2:
                    switch(e.Node.Parent.Name)
                    {
                        case "Reports":
                            if (((frmReportSettings)Application.OpenForms["frmReportSettings"]) != null)
                                ((frmReportSettings)Application.OpenForms["frmReportSettings"]).Close(); 
                            frmReportSettings frmReportSettings = new frmReportSettings(e.Node.Name);
                            frmReportSettings.TopLevel = false;
                            frmReportSettings.AutoScroll = true;
                            frmReportSettings.Dock = DockStyle.Fill;
                            //frmReportSettings.Height = this.mainPanel.Height;
                            //frmReportSettings.Width = this.mainPanel.Width;
                            this.mainPanel.Controls.Add(frmReportSettings);
                            frmReportSettings.Show();
                            break;
                        case "Forms":
                            if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                                ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close(); 
                            frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                            frmFormSettings.TopLevel = false;
                            frmFormSettings.AutoScroll = true;
                            frmFormSettings.Dock = DockStyle.Fill;
                            //frmFormSettings.Height = this.mainPanel.Height;
                            //frmFormSettings.Width = this.mainPanel.Width;
                            this.mainPanel.Controls.Add(frmFormSettings);
                            frmFormSettings.Show();
                            break;
                    }
                    if (e.Node.Parent.Name == "nodeFlowPageInit")
                    {
                        if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
                        frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                        frmFormSettings.TopLevel = false;
                        frmFormSettings.AutoScroll = true;
                        frmFormSettings.Dock = DockStyle.Fill;
                        //frmFormSettings.Height = this.mainPanel.Height;
                        //frmFormSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmFormSettings);
                        frmFormSettings.Show();
                        break;
                    }
                    else if (e.Node.Parent.Name == "nodeFlowGeneral")
                    {
                        if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
                        frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                        frmFormSettings.TopLevel = false;
                        frmFormSettings.AutoScroll = true;
                        frmFormSettings.Dock = DockStyle.Fill;
                        //frmFormSettings.Height = this.mainPanel.Height;
                        //frmFormSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmFormSettings);
                        frmFormSettings.Show();
                        break;
                    }
                    else if (e.Node.Parent.Name == "nodeFlowDynaFlow")
                    {
                        if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
                        frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                        frmFormSettings.TopLevel = false;
                        frmFormSettings.AutoScroll = true;
                        frmFormSettings.Dock = DockStyle.Fill;
                        //frmFormSettings.Height = this.mainPanel.Height;
                        //frmFormSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmFormSettings);
                        frmFormSettings.Show();
                        break;
                    }
                    else if (e.Node.Parent.Name == "nodeFlowDynaFlowTask")
                    {
                        if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
                        frmFormSettings frmFormSettings = new frmFormSettings(e.Node.Name);
                        frmFormSettings.TopLevel = false;
                        frmFormSettings.AutoScroll = true;
                        frmFormSettings.Dock = DockStyle.Fill;
                        //frmFormSettings.Height = this.mainPanel.Height;
                        //frmFormSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmFormSettings);
                        frmFormSettings.Show();
                        break;
                    }


                    break;
                     
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText(_path, json);
            Utils.SortJsonFile(_path);
            showMessage("File Updated Successfully");
            ShowNoUnsavedChanges();
        }

        private void formPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmForm form = new frmForm();
            form.ShowDialog();
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportGrid reportGrid = new frmReportGrid();
            reportGrid.ShowDialog();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportDetail frmReportGridDetails = new frmReportDetail();
            frmReportGridDetails.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Open A Model JSON File";
            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.CheckPathExists = true;
            OpenFileDialog.DefaultExt = "json";
            OpenFileDialog.Filter = "Json files (*.json)|*.json";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadModelFile(OpenFileDialog.FileName);
            }
        }

        public void LoadModelFile(string modelFilePath)
        {
            this.UseWaitCursor = true;
            using (StreamReader r = new StreamReader(modelFilePath))
            {
                string json = r.ReadToEnd();
                _model = JsonConvert.DeserializeObject<RootObject>(json);
                this.Text = _model.root.DatabaseName;

            }
            PopulateTree(); 
            nodeMenus.Enabled = true; 
            _path = modelFilePath;
            UpdateMenuState();
            ShowNoUnsavedChanges();
            this.UseWaitCursor = false;
        }

        private void UpdateMenuState()
        {
            if(_path != null && _path == "new")
            {
                addToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = true;
                servicesToolStripMenuItem.Enabled = true;
            }
            else if(_path != null && _path.Trim().Length > 0 && _path != "new")
            {
                addToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                servicesToolStripMenuItem.Enabled = true;
            }
            else
            {
                addToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                servicesToolStripMenuItem.Enabled = false;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.TopLevel = false;
            frmHelp.Dock = DockStyle.Fill;
            //frmHelp.Height = this.mainPanel.Height;
            //frmHelp.Width = this.mainPanel.Width;
            this.mainPanel.Controls.Add(frmHelp);
            frmHelp.Show();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save As Model JSON File";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "Json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                _path = saveFileDialog1.FileName;  
                File.WriteAllText(_path, json);
                Utils.SortJsonFile(_path);
                UpdateMenuState();
                showMessage("File Updated Successfully");
                ShowNoUnsavedChanges();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            //{
            //    string json = JsonConvert.SerializeObject(Form1.model, Formatting.Indented, new JsonSerializerSettings
            //    {
            //        NullValueHandling = NullValueHandling.Ignore
            //    });
            //    File.WriteAllText(path, json);
            //    showMessage("File Updated Successfully");
            //   // DialogResult result = MessageBox.Show(, "File Updates");
            //    // Do what you want here
            //    e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            //}
        }
        public void showMessage(string message)
        {
            statusText.Text = message;
            var t = new Timer();
            t.Interval = 5000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                statusText.Text = "";
                t.Stop();
            };
            t.Start();
            
        }
        public void updateTree(string name,int itemtype)
        {
            PopulateTree();
            SetSelectedTreeItem(name); 
            nodeMenus.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        { 
            PopulateTree(txtSearch.Text);  
        }
        public void AddToTree(objectWorkflow objectWorkflow,int action=0) //0=add 1=update
        {
            if(((frmFormSettings)Application.OpenForms["frmFormSettings"])!=null)
            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
            nodeMenus.SelectedNode = PopulateTree(objectWorkflow);
            ShowUnsavedChanges();

        }
        public void AddToTree(ObjectMap objectMap)
        {
            if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
                ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).Close();
            nodeMenus.SelectedNode = PopulateTree(objectMap);
            ShowUnsavedChanges();
        }
        public void AddToTree(Report report)
        {
            if (((frmReportSettings)Application.OpenForms["frmReportSettings"]) != null)
                ((frmReportSettings)Application.OpenForms["frmReportSettings"]).Close();
            nodeMenus.SelectedNode = PopulateTree(report);
            ShowUnsavedChanges();
        }
        public void AddToTree(Models.apiSite apiSite)
        {
            if (((frmAPISettings)Application.OpenForms["frmAPISettings"]) != null)
                ((frmAPISettings)Application.OpenForms["frmAPISettings"]).Close();
            nodeMenus.SelectedNode = PopulateTree(apiSite);
            ShowUnsavedChanges();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalStorage.SetValue("Form1.splitContainer1.SplitterDistance", splitContainer1.SplitterDistance.ToString());
            LocalStorage.Save();
        }

        private void flowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aPISiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddApiSite form = new frmAddApiSite();
            form.ShowDialog();

        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDbObject frm = new frmDbObject();
            frm.ShowDialog();
        }

        private void lookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddDBObjectLookup frm = new frmAddDBObjectLookup();
            frm.ShowDialog();
        }

        private void aPIGetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddApiGetReport frmAddApiGetReport = new frmAddApiGetReport();
            frmAddApiGetReport.ShowDialog();
        }

        private void generalToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmAddFlow form = new frmAddFlow();
            form.ShowDialog();
        }

        private void aPIToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddAPIFlow form = new frmAddAPIFlow();
            form.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicesApiLogin  form = new frmServicesApiLogin();
            form.ShowDialog();

        }

        private void modelAIProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmServicesApiPrepRequestList form = new frmServicesApiPrepRequestList();
            form.ShowDialog();
        }

        private void modelValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmServicesApiValidationRequestList form = new frmServicesApiValidationRequestList();
            form.ShowDialog();
        }

        private void modelFabricationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmServicesApiFabricationRequestList form = new frmServicesApiFabricationRequestList();
            form.ShowDialog();
        }

        public void UpdateLoginStatusDispaly()
        {
            if(OpenAPIs.ApiManager._IsLoggedIn)
            {
                ShowAsLoggedIn();
            }
            else
            {
                ShowAsLoggedOut();
            }
        }

        public void ShowAsLoggedIn()
        {
            loginToolStripMenuItem.Enabled = false;
            addModelFeaturesToolStripMenuItem.Enabled = true;
            modelAIProcessingToolStripMenuItem.Enabled = true;
            modelFabricationToolStripMenuItem.Enabled = true;
            modelValidationToolStripMenuItem.Enabled = true;
            logOutToolStripMenuItem.Enabled = true;
        }
        public void ShowAsLoggedOut()
        {
            loginToolStripMenuItem.Enabled = true;
            addModelFeaturesToolStripMenuItem.Enabled = false;
            modelAIProcessingToolStripMenuItem.Enabled = false;
            modelFabricationToolStripMenuItem.Enabled = false;
            modelValidationToolStripMenuItem.Enabled = false;
            logOutToolStripMenuItem.Enabled = false;

        }

        public void ShowUnsavedChanges()
        {
            if(!this.Text.StartsWith("*"))
            {
                this.Text = "*" + this.Text;
            }
        }

        public void ShowNoUnsavedChanges()
        {
            if (this.Text.StartsWith("*"))
            {
                this.Text = this.Text.Remove(0, 1);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAPIs.ApiManager._ApiKey = string.Empty;
            OpenAPIs.ApiManager._ApiKeyExpirationDateTime = DateTime.MinValue;
            OpenAPIs.ApiManager._IsLoggedIn = false;
            LocalStorage.SetValue("ModelServicesApiKey", "");
            LocalStorage.SetValue("ModelServicesApiKeyExpirationUTCDateTime", DateTime.MinValue.ToString());
            LocalStorage.Save();
            UpdateLoginStatusDispaly();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            using (StreamReader r = new StreamReader("new.model.json"))
            {
                string json = r.ReadToEnd();
                _model = JsonConvert.DeserializeObject<RootObject>(json);
                this.Text = _model.root.DatabaseName;

            }
            PopulateTree();
            nodeMenus.Enabled = true; 
            _path = "new"; 
            UpdateMenuState();
            ShowNoUnsavedChanges();
            this.UseWaitCursor = false;
        }

        private void addModelFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _displayModelFeaturesTab = true;
            nodeMenus.SelectedNode = nodeMenus.Nodes["Project"];
        }
    }
}
