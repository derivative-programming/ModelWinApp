﻿using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public static RootObject _model;
        public static string _path;

        private string _initialModelPath = string.Empty;
        private bool _displayModelFeaturesTab = false;
        private bool _displayUserStoriesTab = false;
        private bool _displayLookupValuesTab = false;

        private bool _searchNames = true;
        private bool _searchReportNames = false;
        private bool _searchObjWFNames = false;
        private bool _searchDBObjNames = false;
        private bool _searchReportFilters = false;
        private bool _searchReportColumns = false;
        private bool _searchReportColumnButtonDestinations = false;
        private bool _searchReportButtons = false;
        private bool _searchReportButtonDestinations = false;
        private bool _searchObjWFParams = false;
        private bool _searchObjWFButtons = false;
        private bool _searchObjWFButtonDestinations = false;
        private bool _searchObjWFOutputVars = false;
        private bool _searchDBObjProps = false;
        private string _searchRoleRequired = string.Empty;
        private bool _searchLayoutName = false;
        private bool _isANDSearch = false;
        private bool _isORSearch = true;

        public Form1(string initialModelPath, string fabricationOutputFolderInit)
        {
            InitializeComponent();
            _initialModelPath = initialModelPath;
            if (fabricationOutputFolderInit.Trim().Length > 0)
            {
                LocalStorage.SetValue("FabricationFolder", fabricationOutputFolderInit);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenAPIs.ApiManager.Initialize();
            nodeMenus.TabStop = false;
            nodeMenus.Enabled = false;
            UpdateMenuState();

            splitContainer1.SplitterDistance = System.Convert.ToInt32(LocalStorage.GetValue("Form1.splitContainer1.SplitterDistance", "200"));

            if (this._initialModelPath.Trim().Length > 0 &&
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
            if (Form1._model.root.ProjectCode is null ||
                    Form1._model.root.ProjectCode.Trim().Length == 0)
            {
                Form1._model.root.ProjectCode = Guid.NewGuid().ToString();
            }
            string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText(_path, json);
            ArchiveModel();
            Utils.SortJsonFile(_path);
            ShowNoUnsavedChanges();
            this.UseWaitCursor = false;
        }
        public void ArchiveModel()
        {
            string archiveFilePath = @"ModelArchive\" + System.IO.Path.GetFileNameWithoutExtension(_path) + "_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".json";
            if (Form1._model.root.ProjectCode is null ||
                    Form1._model.root.ProjectCode.Trim().Length == 0)
            {
                Form1._model.root.ProjectCode = Guid.NewGuid().ToString();
            }
            string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            if (!System.IO.Directory.Exists(@"ModelArchive"))
            {
                System.IO.Directory.CreateDirectory(@"ModelArchive");
            }
            File.WriteAllText(archiveFilePath, json);
        }

        private ToolStripMenuItem AddMenu(string Name)
        {
            ToolStripMenuItem FileMenu = new ToolStripMenuItem(Name);
            FileMenu.Text = Name;
            FileMenu.TextAlign = ContentAlignment.MiddleRight;
            FileMenu.ToolTipText = "Click Me";

            return FileMenu;
        }

        public void ClearTreeFilter()
        {
            txtSearch.Text = string.Empty;
            PopulateTree();
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
        public string GetProjectName()
        {
            return _model.root.ProjectName;
        }
        public string GetProjectVersionNumber()
        {
            return _model.root.projectVersionNumber;
        }
        public void populateProjectDetails()
        {

            this.Text = "Project: " + _model.root.ProjectName;
            nodeMenus.Nodes["Project"].Text = _model.root.ProjectName;
            if (nodeMenus.Nodes["Project"].Text.Trim().Length == 0)
            {
                nodeMenus.Nodes["Project"].Text = "Project";
            }
        }
        private void populateDbObjects(string filter)
        {
            nodeMenus.Nodes["dbObjects"].Nodes.Clear();
            NameSpaceObject nameSpaceObject = _model.root.NameSpaceObjects.FirstOrDefault();

            bool isExactMatchRequired = false;
            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                filter = filter.Trim(" .\"".ToCharArray());
                isExactMatchRequired = true;
            }

            if (nameSpaceObject.ObjectMap == null)
                return;

            foreach (ObjectMap dbObj in nameSpaceObject.ObjectMap)
            {
                if (IsMatch(dbObj, filter.Split(Environment.NewLine.ToCharArray())))
                {
                    PopulateTree(dbObj);
                }
            }
        }

        private bool IsMatch(ObjectMap item, string[] filters)
        {
            bool result = false;

            if (this._isANDSearch)
            {
                bool failed = false;
                bool passed = false; //at least one search must exist

                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (!IsMatch(item, filter))
                    {
                        failed = true;
                    }
                    else
                    {
                        passed = true;
                    }
                }

                if (passed && !failed)
                {
                    result = true;
                }

            }
            else
            {
                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (IsMatch(item, filter))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        private bool IsMatch(ObjectMap dbObj, string filter)
        {
            bool result = false;

            if (dbObj == null)
                return result;

            if (this._searchRoleRequired.Trim().Length > 0)
                return result;

            if (filter.Trim().Length == 0)
                return true;


            if (!this._searchNames &&
                !this._searchDBObjNames &&
                !this._searchDBObjProps && 
                (//one non db obj search exists
                    this._searchReportNames ||
                    this._searchReportButtons ||
                    this._searchReportButtonDestinations ||
                    this._searchReportColumns ||
                    this._searchReportColumnButtonDestinations ||
                    this._searchReportFilters ||
                    this._searchObjWFNames ||
                    this._searchObjWFButtons ||
                    this._searchObjWFButtonDestinations ||
                    this._searchObjWFOutputVars ||
                    this._searchObjWFParams ||
                    this._searchRoleRequired.Trim().Length > 0
                )
                )
                return result;

            bool isExactMatchRequired = false;

            filter = filter.Trim(" .".ToCharArray());

            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                isExactMatchRequired = true;
            }

            filter = filter.Trim(" .\"".ToCharArray());

            if (isExactMatchRequired)
            {
                if (this._searchNames &&
                    !dbObj.name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    return result;

                if (this._searchDBObjNames &&
                    !dbObj.name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    return result;

                if (this._searchDBObjProps &&
                    dbObj.property.Where(x => x.name.ToLower().Equals(filter.Trim().ToLower())).ToList().Count == 0)
                    return result;


            }
            else
            {
                if (this._searchNames &&
                    !dbObj.name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    return result;

                if (this._searchDBObjNames &&
                    !dbObj.name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    return result;

                if (this._searchDBObjProps &&
                    dbObj.property.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())).ToList().Count == 0)
                    return result;


            }

            if (!this._searchNames &&
                !this._searchDBObjNames &&
                !this._searchDBObjProps)
                return result;

            result = true;

            return result;
        }

        private void populatePageAndFlows(string filter)
        {
            bool isExactMatchRequired = false;
            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                filter = filter.Trim(" .\"".ToCharArray());
                isExactMatchRequired = true;
            }

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
                if (dbObj.objectWorkflow != null)
                {
                    foreach (objectWorkflow objWF in dbObj.objectWorkflow)
                    {

                        if (IsMatch(objWF, filter.Split(Environment.NewLine.ToCharArray())))
                        {
                            PopulateTree(objWF);
                        }

                    }
                }
                if (dbObj.report != null)
                {
                    foreach (Report rpt in dbObj.report)
                    {
                        if (IsMatch(rpt, filter.Split(Environment.NewLine.ToCharArray())))
                        {
                            PopulateTree(rpt);
                        }

                    }
                }

            }

        }

        private bool IsMatch(objectWorkflow item, string[] filters)
        {
            bool result = false;

            if (this._isANDSearch)
            {
                bool failed = false;
                bool passed = false; //at least one search must exist

                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (!IsMatch(item, filter))
                    {
                        failed = true;
                    }
                    else
                    {
                        passed = true;
                    }
                }

                if (passed && !failed)
                {
                    result = true;
                }

            }
            else
            {
                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (IsMatch(item, filter))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        private bool IsMatch(objectWorkflow objWF, string filter)
        {
            bool result = false;

            if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                return true;

            if (objWF == null)
                return result;


            if (filter.Trim().Length > 0 &&
                !this._searchNames &&
                !this._searchObjWFNames &&
                !this._searchObjWFButtons &&
                !this._searchObjWFButtonDestinations &&
                !this._searchObjWFOutputVars &&
                !this._searchObjWFParams &&
              //  this._searchRoleRequired.Trim().Length == 0 &&
                !this._searchLayoutName &&
                (
                //one non objwf search exists
                this._searchReportNames ||
                this._searchReportButtons ||
                this._searchReportButtonDestinations ||
                this._searchReportColumns ||
                this._searchReportColumnButtonDestinations ||
                this._searchReportFilters ||
                this._searchDBObjNames ||
                this._searchDBObjProps)
                )
                return result;

            bool isExactMatchRequired = false;

            filter = filter.Trim(" .".ToCharArray());

            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                isExactMatchRequired = true;
            }

            filter = filter.Trim(" .\"".ToCharArray());


            bool resultFound = false;

            if (isExactMatchRequired)
            {
                if (this._searchNames &&
                    objWF.Name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchObjWFNames &&
                    objWF.Name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchRoleRequired.Trim().Length > 0 &&
                    objWF.isPage == "true" &&
                    objWF.RoleRequired != null &&
                    objWF.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                    resultFound = true;

                if (this._searchLayoutName &&
                    objWF.isPage == "true" &&
                    objWF.layoutName != null &&
                    objWF.layoutName.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchObjWFButtons &&
                    objWF.objectWorkflowButton.Where(x => x.buttonText != null && x.buttonText.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFButtonDestinations &&
                    objWF.objectWorkflowButton.Where(x => x.destinationTargetName != null && x.destinationTargetName.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFOutputVars &&
                    objWF.objectWorkflowOutputVar.Where(x => x.name.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFParams &&
                    objWF.objectWorkflowParam.Where(x => x.name.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

            }
            else
            {
                if (this._searchNames &&
                    objWF.Name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchObjWFNames &&
                    objWF.Name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                //only check role if no other search performed, otherwise its exclusionary below
                if (this._searchRoleRequired.Trim().Length > 0 &&
                    filter.Trim().Length == 0 &&
                   // objWF.isPage == "true" &&
                    objWF.RoleRequired != null &&
                    objWF.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                    resultFound = true;

                if (this._searchLayoutName &&
                    objWF.isPage == "true" &&
                    objWF.layoutName != null &&
                    objWF.layoutName.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchObjWFButtons &&
                    objWF.objectWorkflowButton.Where(x => x.buttonText != null && x.buttonText.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFButtonDestinations &&
                    objWF.objectWorkflowButton.Where(x => x.destinationTargetName != null && x.destinationTargetName.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFOutputVars &&
                    objWF.objectWorkflowOutputVar.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchObjWFParams &&
                    objWF.objectWorkflowParam.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

            }

            if (this._searchRoleRequired.Trim().Length > 0 &&
               // objWF.isPage == "true" &&
                objWF.RoleRequired != null &&
                !objWF.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                resultFound = false;

            if (this._searchRoleRequired.Trim().Length > 0 && 
                objWF.RoleRequired == null)
                resultFound = false;

            if (!resultFound)
                return result;


            if (!this._searchNames &&
                !this._searchObjWFNames &&
                !this._searchObjWFButtons &&
                !this._searchObjWFButtonDestinations &&
                !this._searchObjWFOutputVars &&
                !this._searchObjWFParams &&
                this._searchRoleRequired.Trim().Length == 0 &&
                !this._searchLayoutName)
                return result;

            result = true;

            return result;

        }

        private bool IsMatch(Report item, string[] filters)
        {
            bool result = false;

            if (this._isANDSearch)
            {
                bool failed = false;
                bool passed = false; //at least one search must exist

                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (!IsMatch(item, filter))
                    {
                        failed = true;
                    }
                    else
                    {
                        passed = true;
                    }
                }

                if (passed && !failed)
                {
                    result = true;
                }

            }
            else
            {
                foreach (string filter in filters)
                {
                    //if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                    //    continue;

                    if (IsMatch(item, filter))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        private bool IsMatch(Report rpt, string filter)
        {
            bool result = false;

            if (filter.Trim().Length == 0 && this._searchRoleRequired.Trim().Length == 0)
                return true;

            if (rpt == null)
                return result;


            if (filter.Trim().Length > 0 &&
                !this._searchNames &&
                !this._searchReportNames &&
                !this._searchReportButtons &&
                !this._searchReportButtonDestinations &&
                !this._searchReportColumns &&
                !this._searchReportColumnButtonDestinations &&
                !this._searchReportFilters &&
               // this._searchRoleRequired.Trim().Length == 0 &&
                !this._searchLayoutName &&
                (   //one non report search exists
                    this._searchObjWFNames ||
                    this._searchObjWFButtons ||
                    this._searchObjWFButtonDestinations ||
                    this._searchObjWFOutputVars ||
                    this._searchObjWFParams ||
                    this._searchDBObjNames ||
                    this._searchDBObjProps
                ))
                return result;

            bool isExactMatchRequired = false;

            filter = filter.Trim(" .".ToCharArray());

            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                isExactMatchRequired = true;
            }

            filter = filter.Trim(" .\"".ToCharArray());

            bool resultFound = false;

            if (isExactMatchRequired)
            {
                if (this._searchNames &&
                    rpt.name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchReportNames &&
                    rpt.name.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                //only check role if no other search performed, otherwise its exclusionary below
                if (this._searchRoleRequired.Trim().Length > 0 &&
                    rpt.isPage == "true" &&
                    filter.Trim().Length == 0 && 
                    rpt.RoleRequired != null &&
                    rpt.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                    resultFound = true;

                if (this._searchLayoutName &&
                    rpt.isPage == "true" &&
                    rpt.layoutName != null &&
                    rpt.layoutName.Trim().ToLower().Equals(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchReportButtons &&
                    rpt.reportButton.Where(x => x.buttonName.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportButtonDestinations &&
                    rpt.reportButton.Where(x => x.destinationTargetName.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportColumns &&
                    rpt.reportColumn.Where(x => x.name.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportColumnButtonDestinations &&
                    rpt.reportColumn.Where(x => x.buttonDestinationTargetName != null && x.buttonDestinationTargetName.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportFilters &&
                    rpt.reportParam.Where(x => x.name.ToLower().Equals(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

            }
            else
            {
                if (this._searchNames &&
                    rpt.name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchReportNames &&
                    rpt.name.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchRoleRequired.Trim().Length > 0 &&
                //    rpt.isPage == "true" &&
                    rpt.RoleRequired != null &&
                    rpt.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                    resultFound = true;

                if (this._searchLayoutName &&
                    rpt.isPage == "true" &&
                    rpt.layoutName != null &&
                    rpt.layoutName.Trim().ToLower().Contains(filter.Trim().ToLower()))
                    resultFound = true;

                if (this._searchReportButtons &&
                    rpt.reportButton.Where(x => x.buttonName.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportButtonDestinations &&
                    rpt.reportButton.Where(x => x.destinationTargetName.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportColumns &&
                    rpt.reportColumn.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportColumnButtonDestinations &&
                    rpt.reportColumn.Where(x => x.buttonDestinationTargetName != null && x.buttonDestinationTargetName.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

                if (this._searchReportFilters &&
                    rpt.reportParam.Where(x => x.name.ToLower().Contains(filter.Trim().ToLower())).ToList().Count > 0)
                    resultFound = true;

            }

            if (this._searchRoleRequired.Trim().Length > 0 &&
             //   rpt.isPage == "true" &&
                rpt.RoleRequired != null &&
                !rpt.RoleRequired.Trim().ToLower().Equals(this._searchRoleRequired.Trim().ToLower()))
                resultFound = false;

            if (this._searchRoleRequired.Trim().Length > 0 &&
                //   rpt.isPage == "true" &&
                rpt.RoleRequired == null)
                resultFound = false;


            if (!resultFound)
                return result;


            if (!this._searchNames &&
                !this._searchReportNames &&
                !this._searchReportButtons &&
                !this._searchReportButtonDestinations &&
                !this._searchReportColumns &&
                !this._searchReportColumnButtonDestinations &&
                !this._searchReportFilters &&
                this._searchRoleRequired.Trim().Length == 0 &&
                !this._searchLayoutName)
                return result;

            result = true;

            return result;


        }


        private void populateAPIs(string filter)
        {
            bool isExactMatchRequired = false;
            if (filter.StartsWith("\"") && filter.EndsWith("\""))
            {
                filter = filter.Trim(" .\"".ToCharArray());
                isExactMatchRequired = true;
            }

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

        public List<string> GetNavDBObjectNames()
        {
            List<string> result = new List<string>();

            foreach (TreeNode node in nodeMenus.Nodes["dbObjects"].Nodes)
            {
                result.Add(node.Text);
            }

            return result;
        }
        public List<string> GetNavFormObjWfNames()
        {
            List<string> result = new List<string>();

            foreach (TreeNode node in nodeMenus.Nodes["pages"].Nodes["Forms"].Nodes)
            {
                result.Add(node.Text);
            }

            return result;
        }
        public List<string> GetNavGeneralObjWfNames()
        {
            List<string> result = new List<string>();

            foreach (TreeNode node in nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowGeneral"].Nodes)
            {
                result.Add(node.Text);
            }

            return result;
        }
        public List<string> GetNavReportNames()
        {
            List<string> result = new List<string>();

            foreach(TreeNode node in nodeMenus.Nodes["pages"].Nodes["Reports"].Nodes)
            {
                result.Add(node.Text);
            }

            return result;
        }

        public void SetSelectedDynaFlowTreeItem(string name)
        {
            nodeMenus.SelectedNode = null;

            foreach (TreeNode tn in nodeMenus.Nodes["nodeFlows"].Nodes["nodeFlowDynaFlow"].Nodes)
            {
                SetSelectedTreeItem(tn, name);
            }
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
                        frmSettings frmSettings = new frmSettings(_model.root, _displayModelFeaturesTab, _displayUserStoriesTab);
                        _displayModelFeaturesTab = false;
                        _displayUserStoriesTab = false;
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
                        frmDbObjSettings frmDbObjSettings = new frmDbObjSettings(objectMap, _displayLookupValuesTab);
                        _displayLookupValuesTab = false;
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
            if (Form1._model.root.ProjectCode is null ||
                       Form1._model.root.ProjectCode.Trim().Length == 0)
            {
                Form1._model.root.ProjectCode = Guid.NewGuid().ToString();
            }
            string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText(_path, json);
            ArchiveModel();
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
            this.mainPanel.Controls.Clear();
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
                if(Form1._model.root.ProjectCode is null ||
                    Form1._model.root.ProjectCode.Trim().Length == 0)
                { 
                    Form1._model.root.ProjectCode = Guid.NewGuid().ToString();
                }
                string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                _path = saveFileDialog1.FileName;  
                File.WriteAllText(_path, json);
                ArchiveModel();
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

           // await Task.Delay(2000);
            if (txtSearch.Text.Length > 2 || txtSearch.Text.Length == 0)
            {
                PopulateTree(txtSearch.Text.TrimEnd(". ".ToCharArray()));
            }
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
            modelChangeReportToolStripMenuItem.Enabled = true;
            modelAIChatToolStripMenuItem.Enabled = true;
            modelValidationToolStripMenuItem.Enabled = true;
            templateSelectionToolStripMenuItem.Enabled = true;
            logOutToolStripMenuItem.Enabled = true;
        }
        public void ShowAsLoggedOut()
        {
            loginToolStripMenuItem.Enabled = true;
            addModelFeaturesToolStripMenuItem.Enabled = false;
            modelAIProcessingToolStripMenuItem.Enabled = false;
            modelFabricationToolStripMenuItem.Enabled = false;
            modelChangeReportToolStripMenuItem.Enabled = false;
            modelAIChatToolStripMenuItem.Enabled = false;
            modelValidationToolStripMenuItem.Enabled = false;
            templateSelectionToolStripMenuItem.Enabled = false;
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
                _model.root.ProjectCode = Guid.NewGuid().ToString();
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

        public void DisplayDBObjectLookupValuesTab(string name)
        {
            _displayLookupValuesTab = true;
            SetSelectedTreeItem(name); 

        }
         

        private void sqlServerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using(var form = new frmAddDbObjectImportSqlServer())
            {
                var result = form.ShowDialog();
                 
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            demoToolStripMenuItem1.Enabled = false;
            codeToolStripMenuItem.Enabled = false;
            diagramsToolStripMenuItem.Enabled = false;

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\";
            string codeFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\code\";
            string documentationFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\Documentation\";

            if (System.IO.Directory.Exists(demoFolder))
            {
                demoToolStripMenuItem1.Enabled = true;
            }
            if (System.IO.Directory.Exists(codeFolder))
            {
                codeToolStripMenuItem.Enabled = true;
            }
            if (System.IO.Directory.Exists(documentationFolder))
            {
                diagramsToolStripMenuItem.Enabled = true;
            }

        }
         

        private void adminUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\bootstrap_5\";

            if (!System.IO.Directory.Exists(demoFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = demoFolder + "CustomerAdminDashboard.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void endUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\bootstrap_5\";

            if (!System.IO.Directory.Exists(demoFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string endUserLoginFilePath = demoFolder + "TacLogin.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = endUserLoginFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void configUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\bootstrap_5\";

            if (!System.IO.Directory.Exists(demoFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string configUserDemoDashboardFilePath = demoFolder +  "PacConfigDashboard.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = configUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void demoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            endUserToolStripMenuItem1.Enabled = false;
            adminUserToolStripMenuItem1.Enabled = false;
            configUserToolStripMenuItem1.Enabled = false;

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\bootstrap_5\";

            if (!System.IO.Directory.Exists(demoFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string endUserLoginFilePath = demoFolder + "TacLogin.html";
            string adminUserDemoDashboardFilePath = demoFolder + "CustomerAdminDashboard.html";
            string configUserDemoDashboardFilePath = demoFolder + "PacConfigDashboard.html";

            //if file path exists, activate menu item
            if (System.IO.File.Exists(endUserLoginFilePath))
            {
                endUserToolStripMenuItem1.Enabled = true;
            }
            if (System.IO.File.Exists(adminUserDemoDashboardFilePath))
            {
                adminUserToolStripMenuItem1.Enabled = true;
            }
            if (System.IO.File.Exists(configUserDemoDashboardFilePath))
            {
                configUserToolStripMenuItem1.Enabled = true;
            }
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string codeFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\code\";

            if (!System.IO.Directory.Exists(codeFolder))
                return;


            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = codeFolder;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            };
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Database/ObjectHeirarchy.mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Web/Pageflow/" + namespaceName + ".mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;
            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch(System.Exception)
            {

            }
        }

        private void endUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Web/Pageflow/Customer/Customer." + namespaceName + ".mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void adminUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Web/Pageflow/Admin/Admin." + namespaceName + ".mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void configUserToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Web/Pageflow/Config/Config." + namespaceName + ".mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void publicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Web/Pageflow/Public/public." + namespaceName + ".mermaid.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }
         

        private void apiToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            using (var form = new frmModelSearch(ModelSearchOptions.API_SITES))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;

                    //get output folder
                    string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
                    if (outputFolder.Trim().Length == 0)
                        return;

                    string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\code\dotnetcore\ApiWeb\" + val + @"\Documentation\";

                    if (!System.IO.Directory.Exists(docFolder))
                        return;
                    //determine file paths for three user types  
                    string adminUserDemoDashboardFilePath = docFolder + val + ".html";

                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = adminUserDemoDashboardFilePath;

                    try
                    {
                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (System.Exception)
                    {

                    }

                }
            }
        }

        private void modelChangeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmServicesApiChangeRptRequestList form = new frmServicesApiChangeRptRequestList();
            form.ShowDialog();
        }

        private void workflowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string docFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\documentation\";

            if (!System.IO.Directory.Exists(docFolder))
                return;
            //determine file paths for three user types 
            string namespaceName = _model.root.NameSpaceObjects.FirstOrDefault().name;
            string adminUserDemoDashboardFilePath = docFolder + "Workflows/" + namespaceName + ".DynaFlows.html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            };
        }

        private void dynaFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddDynaFlow form = new frmAddDynaFlow();
            form.ShowDialog();
        }

        private void navigationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportNavigation frmReportNavigation = new frmReportNavigation();
            frmReportNavigation.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new FrmSearchOptions(
                this._searchNames,
                this._searchReportNames,
                this._searchObjWFNames,
                this._searchDBObjNames,
                this._searchReportFilters,
                this._searchReportColumns,
                this._searchReportColumnButtonDestinations,
                this._searchReportButtons,
                this._searchReportButtonDestinations,
                this._searchObjWFParams,
                this._searchObjWFButtons,
                this._searchObjWFButtonDestinations,
                this._searchObjWFOutputVars,
                this._searchDBObjProps,
                this._searchRoleRequired,
                this._searchLayoutName,
                this._isANDSearch,
                this._isORSearch,
                this.txtSearch.Text))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this._searchNames = form.SearchNames;
                    this._searchReportNames = form.SearchReportNames;
                    this._searchObjWFNames = form.SearchObjWFNames;
                    this._searchDBObjNames = form.SearchDBObjNames;
                    this._searchReportFilters = form.SearchReportFilters;
                    this._searchReportColumns = form.SearchReportColumns;
                    this._searchReportColumnButtonDestinations = form.SearchReportColumnButtonDestinations;
                    this._searchReportButtons = form.SearchReportButtons;
                    this._searchReportButtonDestinations = form.SearchReportButtonDestinations;
                    this._searchObjWFParams = form.SearchObjWFParams;
                    this._searchObjWFButtons = form.SearchObjWFButtons;
                    this._searchObjWFButtonDestinations = form.SearchObjWFButtonDestinations;
                    this._searchObjWFOutputVars = form.SearchObjWFOutputVars;
                    this._searchDBObjProps = form.SearchDBObjProps;
                    this._searchRoleRequired = form.SearchRoleRequired;
                    this._searchLayoutName = form.SearchLayoutName;
                    this._isANDSearch = form.IsANDSearch;
                    this._isORSearch = form.IsORSearch;
                    this.txtSearch.Text = form.SearchText;

                    PopulateTree(txtSearch.Text);
                }

            }
        }

        private void multiSelectFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddMultiSelectFlow frmAddButton = new frmAddMultiSelectFlow(string.Empty);
            frmAddButton.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void templateSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var form = new frmServicesApiTemplateSetList(_model.root))
            {
                var result = form.ShowDialog();
                string json = JsonConvert.SerializeObject(Form1._model, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                File.WriteAllText(_path, json);
                ArchiveModel();
                Utils.SortJsonFile(_path);
                showMessage("File Updated Successfully");
                ShowNoUnsavedChanges();
            }
        }

        private void userStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _displayUserStoriesTab = true;
            nodeMenus.SelectedNode = nodeMenus.Nodes["Project"];
        }

        private void pageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmForm form = new frmForm();
            form.ShowDialog();
        }

        private void addChildPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormAddChild form = new frmFormAddChild();
            form.ShowDialog();
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modelAIChatToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmServicesApiModelChat form = new frmServicesApiModelChat();
            form.Show();
        }

        private void bulkAddPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddObjProp frmProp = new frmAddObjProp(string.Empty);
            frmProp.ShowDialog();
        }

        private void bulkAddColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAddColumn frmAddColumn = new FrmAddColumn();
            frmAddColumn.ShowDialog();
        }

        private void bulkAddControlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAddControl frmControl = new FrmAddControl();
            frmControl.ShowDialog();
        }
    } 
}
