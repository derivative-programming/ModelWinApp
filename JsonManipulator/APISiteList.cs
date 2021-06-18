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
    public partial class APISiteList : Form
    {

        public APISiteList()
        {
            InitializeComponent(); 
        }
        private void populate(string filter)
        {
            listObjects.Items.Clear();

            List<string> fullList = Utils.GetApiSiteNameList();
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                populate(txtFilter.Text);
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                ((frmAddApiGetReport)Application.OpenForms["frmAddApiGetReport"]).setAPISite(listObjects.SelectedItem.ToString());

            }
            this.Close();
        }
    }
}
