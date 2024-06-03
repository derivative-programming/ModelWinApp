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
        public bool SearchReportNames { get; set; }
        public bool SearchObjWFNames { get; set; }
        public bool SearchDBObjNames { get; set; }
        public bool SearchReportFilters { get; set; }
        public bool SearchReportColumns { get; set; }
        public bool SearchReportColumnButtonDestinations { get; set; }
        public bool SearchReportButtons { get; set; }
        public bool SearchReportButtonDestinations { get; set; }
        public bool SearchObjWFParams { get; set; }
        public bool SearchObjWFButtons { get; set; }
        public bool SearchObjWFButtonDestinations { get; set; }
        public bool SearchObjWFOutputVars { get; set; }
        public bool SearchDBObjProps { get; set; }
        public string SearchRoleRequired { get; set; }
        public bool SearchLayoutName { get; set; }
        public bool IsANDSearch { get; set; }
        public bool IsORSearch { get; set; }
        public string SearchText { get; set; }

        public FrmSearchOptions( 
            bool searchNames,
            bool searchReportNames,
            bool searchObjWFNames,
            bool searchDBObjNames,
            bool searchReportFilters,
            bool searchReportColumns,
            bool searchReportColumnButtonDestinations,
            bool searchReportButtons,
            bool searchReportButtonDestinations,
            bool searchObjWFParams,
            bool searchObjWFButtons,
            bool searchObjWFButtonDestinations,
            bool searchObjWFOutputVars,
            bool searchDBObjProps,
            string searchRoleRequired,
            bool searchLayoutName,
            bool isANDSearch,
            bool isORSearch,
            string searchText)
        {
            InitializeComponent();

            this.SearchDBObjProps = searchDBObjProps;
            this.SearchNames = searchNames;
            this.SearchReportNames = searchReportNames;
            this.SearchObjWFNames = searchObjWFNames;
            this.SearchDBObjNames = searchDBObjNames;
            this.SearchObjWFButtons = searchObjWFButtons;
            this.SearchObjWFButtonDestinations = searchObjWFButtonDestinations;
            this.SearchObjWFOutputVars = searchObjWFOutputVars;
            this.SearchObjWFParams = searchObjWFParams;
            this.SearchReportButtons = searchReportButtons;
            this.SearchReportButtonDestinations = searchReportButtonDestinations;
            this.SearchReportColumns = searchReportColumns;
            this.SearchReportColumnButtonDestinations = searchReportColumnButtonDestinations;
            this.SearchReportFilters = searchReportFilters;
            this.SearchRoleRequired = searchRoleRequired;
            this.SearchLayoutName = searchLayoutName;
            this.IsANDSearch = isANDSearch;
            this.IsORSearch = isORSearch;
            this.SearchText = searchText;

            this.chkName.Checked = this.SearchNames;
            this.chkReport.Checked = this.SearchReportNames;
            this.chkObjWF.Checked = this.SearchObjWFNames;
            this.chkDBObj.Checked = this.SearchDBObjNames;
            this.chkObjProp.Checked = this.SearchDBObjProps;
            this.chkObjWfButton.Checked = this.SearchObjWFButtons; 
            this.chkObjWFButtonDestination.Checked = this.SearchObjWFButtonDestinations;
            this.chkObjWfOutputVar.Checked = this.SearchObjWFOutputVars;
            this.chkObjWfParam.Checked = this.SearchObjWFParams;
            this.chkReportButton.Checked = this.SearchReportButtons;
            this.chkReportButtonDestination.Checked = this.SearchReportButtonDestinations;
            this.chkReportColumn.Checked = this.SearchReportColumns;
            this.chkReportColumnButtonDestination.Checked = this.SearchReportColumnButtonDestinations;
            this.chkReportFilter.Checked = this.SearchReportFilters;
            this.txtRoleRequired.Text = this.SearchRoleRequired;
            this.chkLayoutName.Checked = this.SearchLayoutName;
            this.rbAnd.Checked = this.IsANDSearch;
            this.rbOr.Checked = this.IsORSearch;
            this.rtbSearch.Text = this.SearchText;

        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.SearchDBObjProps = this.chkObjProp.Checked;
            this.SearchNames = this.chkName.Checked;
            this.SearchReportNames = this.chkReport.Checked;
            this.SearchObjWFNames = this.chkObjWF.Checked;
            this.SearchDBObjNames = this.chkDBObj.Checked;
            this.SearchObjWFButtons = this.chkObjWfButton.Checked;
            this.SearchObjWFButtonDestinations = this.chkObjWFButtonDestination.Checked;
            this.SearchObjWFOutputVars = this.chkObjWfOutputVar.Checked;
            this.SearchObjWFParams = this.chkObjWfParam.Checked;
            this.SearchReportButtons = this.chkReportButton.Checked;
            this.SearchReportButtonDestinations = this.chkReportButtonDestination.Checked;
            this.SearchReportColumns = this.chkReportColumn.Checked;
            this.SearchReportColumnButtonDestinations = this.chkReportColumnButtonDestination.Checked;
            this.SearchReportFilters = this.chkReportFilter.Checked;
            this.SearchRoleRequired = this.txtRoleRequired.Text;
            this.SearchLayoutName = this.chkLayoutName.Checked;
            this.IsANDSearch = this.rbAnd.Checked;
            this.IsORSearch = this.rbOr.Checked;
            this.SearchText = this.rtbSearch.Text;
             
            this.Close();

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

        private void rtbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Suppress the default behavior (prevent the button click)
                e.Handled = true;
            }
        }

        private void FrmSearchOptions_Load(object sender, EventArgs e)
        {
             
        }
    }
}
