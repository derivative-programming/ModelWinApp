using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class FrmSearchOptions : Form
    {
        string _name, _parent;
        ButtonType _type;
         
        public bool SearchNames { get; set; }
        public bool SearchReportFilters { get; set; }
        public bool SearchReportColumns { get; set; }
        public bool SearchReportButtons { get; set; }
        public bool SearchObjWFParams { get; set; }
        public bool SearchObjWFButtons { get; set; }
        public bool SearchObjWFOutputVars { get; set; }
        public bool SearchDBObjProps { get; set; }
        public bool SearchRoleRequired { get; set; }
        public bool SearchLayoutName { get; set; }

        public FrmSearchOptions( 
            bool searchNames,
            bool searchReportFilters,
            bool searchReportColumns,
            bool searchReportButtons,
            bool searchObjWFParams,
            bool searchObjWFButtons,
            bool searchObjWFOutputVars,
            bool searchDBObjProps,
            bool searchRoleRequired,
            bool searchLayoutName)
        {
            InitializeComponent();

            this.SearchDBObjProps = searchDBObjProps;
            this.SearchNames = searchNames;
            this.SearchObjWFButtons = searchObjWFButtons;
            this.SearchObjWFOutputVars = searchObjWFOutputVars;
            this.SearchObjWFParams = searchObjWFParams;
            this.SearchReportButtons = searchReportButtons;
            this.SearchReportColumns = searchReportColumns;
            this.SearchReportFilters = searchReportFilters;
            this.SearchRoleRequired = searchRoleRequired;
            this.SearchLayoutName = searchLayoutName;

            this.chkName.Checked = this.SearchNames;
            this.chkObjProp.Checked = this.SearchDBObjProps;
            this.chkObjWfButton.Checked = this.SearchObjWFButtons;
            this.chkObjWfOutputVar.Checked = this.SearchObjWFOutputVars;
            this.chkObjWfParam.Checked = this.SearchObjWFParams;
            this.chkReportButton.Checked = this.SearchReportButtons;
            this.chkReportColumn.Checked = this.SearchReportColumns;
            this.chkReportFilter.Checked = this.SearchReportFilters;
            this.chkRoleRequired.Checked = this.SearchRoleRequired;
            this.chkLayoutName.Checked = this.SearchLayoutName;

        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.SearchDBObjProps = this.chkObjProp.Checked;
            this.SearchNames = this.chkName.Checked;
            this.SearchObjWFButtons = this.chkObjWfButton.Checked;
            this.SearchObjWFOutputVars = this.chkObjWfOutputVar.Checked;
            this.SearchObjWFParams = this.chkObjWfParam.Checked;
            this.SearchReportButtons = this.chkReportButton.Checked;
            this.SearchReportColumns = this.chkReportColumn.Checked;
            this.SearchReportFilters = this.chkReportFilter.Checked;
            this.SearchRoleRequired = this.chkRoleRequired.Checked;
            this.SearchLayoutName = this.chkLayoutName.Checked;


        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmSearchOptions_Load(object sender, EventArgs e)
        {
             
        }
    }
}
