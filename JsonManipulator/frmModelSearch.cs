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
    public partial class frmModelSearch : Form
    {
        private ModelSearchOptions _modelSearchOptions;
        public string ReturnValue { get; set; }
        public frmModelSearch(ModelSearchOptions modelSearchOptions)
        {
            InitializeComponent();
            _modelSearchOptions = modelSearchOptions;
        }
        private void populate(string filter)
        {
            listObjects.Items.Clear();

            List<string> fullList = new List<string>(); 
            switch(this._modelSearchOptions)
            {
                case ModelSearchOptions.API_SITES:
                    this.Text = "API Sites";
                    fullList = Utils.GetApiSiteNameList();
                    break;
                case ModelSearchOptions.DYNAFLOW_TASKS:
                    this.Text = "Dynaflow Tasks";
                    fullList = Utils.GetDFTList();
                    break;
                case ModelSearchOptions.FLOWS:
                    this.Text = "Flows";
                    fullList = Utils.GetNameList(false, false, false, true, false);
                    break;
                case ModelSearchOptions.FORMS:
                    this.Text = "Pages";
                    fullList = Utils.GetNameList(false, true, true, false, false);
                    break;
                case ModelSearchOptions.OBJECTS:
                    this.Text = "DB Objects";
                    fullList = Utils.GetDBObjectNameList();
                    break;
                case ModelSearchOptions.REPORTS:
                    this.Text = "Reports";
                    fullList = Utils.GetNameList(false, true, false, false, false);
                    break;
                case ModelSearchOptions.ROLES:
                    this.Text = "Roles";
                    fullList = Utils.GetRoleList();
                    break;
                default:
                    break;
            }
            fullList.Add(" No Value");
                
            if (filter.Trim().Length > 0)
            {
                fullList = fullList.Where(x => x.ToLower().Contains(filter.ToLower().Trim())).ToList();
            }
            foreach (string name in fullList)
            {
                listObjects.Items.Add(name);
            } 
            listObjects.Sorted = true;

        }
        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            populate("");
            this.ActiveControl = this.txtFilter;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                populate(txtFilter.Text);
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (listObjects.SelectedItem!=null)
            {
                this.DialogResult = DialogResult.OK;
                this.ReturnValue = listObjects.SelectedItem.ToString(); 
                if(this.ReturnValue == " No Value")
                {
                    this.ReturnValue = null;
                }
            }
            this.Close();
        }
    }
}
