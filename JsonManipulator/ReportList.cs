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
    public partial class ReportList : Form
    { 
        public string ReturnValue { get; set; }
        public ReportList()
        {
            InitializeComponent(); 
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            List<string> nameList = Utils.GetNameList(false, true, false, false, false);
            foreach(string name in nameList)
            {
                listObjects.Items.Add(name);
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            List<string> nameList = Utils.GetNameList(false, true, false, false, false);
            if (txtFilter.Text.Trim().Length > 0)
            {
                string filter = txtFilter.Text.Trim().ToLower();
                nameList = nameList.Where(x => x.ToLower().Contains(filter)).ToList();
            }
            foreach (string name in nameList)
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
