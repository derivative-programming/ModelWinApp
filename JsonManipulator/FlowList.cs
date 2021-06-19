﻿using JsonManipulator.Enums;
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
    public partial class FlowList : Form
    { 

        public string ReturnValue { get; set; }

        public FlowList()
        {
            InitializeComponent(); 
        }
        private void populateFlows(string filter)
        {
            listObjects.Items.Clear();

            List<string> fullList = Utils.GetNameList(false, false, false, true,false);
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
            populateFlows("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                populateFlows(txtFilter.Text);
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
