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
     public static  RootObject model;
        List<objectWorkflow> forms;
        List<Report> reports;
        public static string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            forms = new List<objectWorkflow>();
            reports = new List<Report>();
            nodeMenus.TabStop = false;
            nodeMenus.Enabled = false;
            addToolStripMenuItem.Enabled = false;
        }
        private ToolStripMenuItem AddMenu (string Name)
        {
            ToolStripMenuItem FileMenu = new ToolStripMenuItem(Name);
            FileMenu.Text = Name;
            FileMenu.TextAlign = ContentAlignment.MiddleRight;
            FileMenu.ToolTipText = "Click Me";

            return FileMenu;
        }
       
        private void populateDbObjects(string filter)
        {
            nodeMenus.Nodes["dbObjects"].Nodes.Clear();
            NameSpaceObject nameSpaceObject = model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var _object in nameSpaceObject.ObjectMap.Where(x => x.name.Contains(filter)))
            {
                TreeNode node = new TreeNode();
                node.Text = _object.name;
                node.Name = _object.name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                nodeMenus.Nodes["dbObjects"].Nodes.Add(node);
            }
        }
        private void populateForms(string filter)
        {
            nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Clear();
            nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Clear();
            NameSpaceObject nameSpaceObject = model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var _dbObject in nameSpaceObject.ObjectMap)
            {
                if(_dbObject.objectWorkflow !=null)
                {
                    foreach (var _object in _dbObject.objectWorkflow.Where(x=>x.Name.Contains(filter)))
                    {
                        _object.OwnerObject = _dbObject.name;
                        forms.Add(_object);
                        TreeNode node = new TreeNode();
                        node.Text = _object.Name;
                        node.Name = _object.Name;
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Add(node);
                    }
                }
                if(_dbObject.report != null)
                {
                    foreach (var _object in _dbObject.report.Where(x => x.name.Contains(filter)))
                    {
                        _object.OwnerObject = _dbObject.name;
                        reports.Add(_object);
                        TreeNode node = new TreeNode();
                        node.Text = _object.name;
                        node.Name = _object.name;
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Add(node);
                    }
                }
                
            }
           
        }
        protected void populateReports(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            NameSpaceObject nameSpaceObject = model.root.NameSpaceObjects.FirstOrDefault();
            ObjectMap map = nameSpaceObject.ObjectMap.Where(x => x.name == button.Text).FirstOrDefault();
            if(map!=null && map.report!=null)
            {
                foreach (var _object in map.report)
                {
                    Button btn = new Button();
                    btn.Text = _object.name;
                    btn.Dock = DockStyle.Top;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                   // pnlReports.Padding = new Padding(20, 0, 0, 0);
                 //   pnlReports.Controls.Add(btn);
                }
            }
            
}

        private void dBObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDbObject frm = new frmDbObject();
            frm.ShowDialog();
        }

        private void nodeMenus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.mainPanel.Controls.Clear();
            int level = e.Node.Level;
            NameSpaceObject nameSpaceObject = model.root.NameSpaceObjects.FirstOrDefault();
            switch (level)
            {
                case 0:
                    if (e.Node.Name == "MyCompanyApp")
                    {
                        frmSettings frmSettings = new frmSettings(model.root);
                        frmSettings.TopLevel = false;
                        frmSettings.AutoScroll = true;
                        frmSettings.Height = this.mainPanel.Height;
                        frmSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmSettings);
                        frmSettings.Show();
                    }
                    break;
                case 1: //Db Objects
                    if(e.Node.Parent.Name == "dbObjects")
                    {
                        if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
                            ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).Close();
                        ObjectMap objectMap = nameSpaceObject.ObjectMap.Where(x => x.name == e.Node.Name).FirstOrDefault();
                        frmDbObjSettings frmDbObjSettings = new frmDbObjSettings(objectMap);
                        frmDbObjSettings.TopLevel = false;
                        frmDbObjSettings.AutoScroll = true;
                        frmDbObjSettings.Height = this.mainPanel.Height;
                        frmDbObjSettings.Width = this.mainPanel.Width;
                        this.mainPanel.Controls.Add(frmDbObjSettings);
                        frmDbObjSettings.Show();
                    }
                    break;
                case 2:
                    switch(e.Node.Parent.Name)
                    {
                        case "Reports":
                            if (((frmReportSettings)Application.OpenForms["frmReportSettings"]) != null)
                                ((frmReportSettings)Application.OpenForms["frmReportSettings"]).Close();
                            Report rpt = reports.Where(x => x.name == e.Node.Name).FirstOrDefault();
                            frmReportSettings frmReportSettings = new frmReportSettings(rpt);
                            frmReportSettings.TopLevel = false;
                            frmReportSettings.AutoScroll = true;
                            frmReportSettings.Height = this.mainPanel.Height;
                            frmReportSettings.Width = this.mainPanel.Width;
                            this.mainPanel.Controls.Add(frmReportSettings);
                            frmReportSettings.Show();
                            break;
                        case "Forms":
                            if (((frmFormSettings)Application.OpenForms["frmFormSettings"]) != null)
                                ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
                            objectWorkflow form = forms.Where(x => x.Name == e.Node.Name).FirstOrDefault();
                            frmFormSettings frmFormSettings = new frmFormSettings(form);
                            frmFormSettings.TopLevel = false;
                            frmFormSettings.AutoScroll = true;
                            frmFormSettings.Height = this.mainPanel.Height;
                            frmFormSettings.Width = this.mainPanel.Width;
                            this.mainPanel.Controls.Add(frmFormSettings);
                            frmFormSettings.Show();
                            break;
                    }
                    break;
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(Form1.model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText(path, json);
            showMessage("File Updated Successfully");
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
            OpenFileDialog.Title = "Open A JSON File";
            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.CheckPathExists = true;
            OpenFileDialog.DefaultExt = "json";
            OpenFileDialog.Filter = "Json files (*.json)|*.json";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader r = new StreamReader(OpenFileDialog.FileName))
                {
                    string json = r.ReadToEnd();
                    model = JsonConvert.DeserializeObject<RootObject>(json);
                    this.Text = model.root.DatabaseName;

                }
                populateDbObjects("");
                populateForms("");
                nodeMenus.Enabled = true;
                addToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                path = OpenFileDialog.FileName;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.TopLevel = false;
            frmHelp.Height = this.mainPanel.Height;
            frmHelp.Width = this.mainPanel.Width;
            this.mainPanel.Controls.Add(frmHelp);
            frmHelp.Show();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "Json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string json = JsonConvert.SerializeObject(Form1.model, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                File.WriteAllText(saveFileDialog1.FileName, json);
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
            populateDbObjects("");
            populateForms("");
            switch (itemtype)
            {
                case 0://object
                    nodeMenus.SelectedNode = nodeMenus.Nodes["dbObjects"].Nodes[name];
                    break;
                case 1://form
                    nodeMenus.SelectedNode = nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes[name];
                    break;
                case 2://report
                    nodeMenus.SelectedNode = nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes[name];
                    break;
            }
            nodeMenus.Focus();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Clear();
            nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Clear();
            nodeMenus.Nodes["dbObjects"].Nodes.Clear();
            populateDbObjects(txtSearch.Text);
            populateForms(txtSearch.Text);
           // nodeMenus.Sort();
        }
        public void AddToTree(objectWorkflow objectWorkflow,int action=0) //0=add 1=update
        {
            if(((frmFormSettings)Application.OpenForms["frmFormSettings"])!=null)
            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).Close();
            forms.Add(objectWorkflow);
            TreeNode node = new TreeNode();
            node.Text = objectWorkflow.Name;
            node.Name = objectWorkflow.Name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes.Add(node);
            nodeMenus.SelectedNode = nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes[objectWorkflow.Name];
        }
        public void AddToTree(ObjectMap objectMap)
        {
            if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
                ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).Close();
            TreeNode node = new TreeNode();
            node.Text = objectMap.name;
            node.Name = objectMap.name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["dbObjects"].Nodes.Add(node);
            nodeMenus.SelectedNode = nodeMenus.Nodes["dbObjects"].Nodes[objectMap.name];
        }
        public void AddToTree(Report report)
        {
            if (((frmReportSettings)Application.OpenForms["frmReportSettings"]) != null)
                ((frmReportSettings)Application.OpenForms["frmReportSettings"]).Close();
            reports.Add(report);
            TreeNode node = new TreeNode();
            node.Text = report.name;
            node.Name = report.name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes.Add(node);
            nodeMenus.SelectedNode = nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes[report.name];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
