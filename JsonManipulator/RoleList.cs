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
    public partial class RoleList : Form
    { 
        public string ReturnValue { get; set; }
        public RoleList()
        {
            InitializeComponent(); 
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            List<string> roleList = Utils.GetRoleList();
            foreach(string name in roleList)
            {
                listObjects.Items.Add(name);
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            List<string> roleList = Utils.GetRoleList();
            if(txtFilter.Text.Trim().Length > 0)
            {
                string filter = txtFilter.Text.Trim().ToLower();
                roleList = roleList.Where(x => x.ToLower().Contains(filter)).ToList();
            }
            foreach (string name in roleList)
            {
                listObjects.Items.Add(name);
            } 
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            if (listObjects.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
                this.ReturnValue = listObjects.SelectedItem.ToString();

            }
            this.Close();
        }
    }
}
