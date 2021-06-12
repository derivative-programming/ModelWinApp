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
    public partial class frmReportDetail : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmReportDetail()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report == null)
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report = new List<Models.Report>();
            Report rpt = new Report { name = txtName.Text, RoleRequired = txtRole.Text, visualizationType = "Detail",OwnerObject=txtOwner.Text };
            Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report.Add(rpt);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Report Detail was added successfully");
            ((Form1)Application.OpenForms["Form1"]).AddToTree(rpt);
            this.Close();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            ObjectsList objectsList = new ObjectsList(FormObjects.DBOBJECT_RPT_DETAIL);
            objectsList.ShowDialog();
        }

        private void frmReportGrid_Load(object sender, EventArgs e)
        {
           
        }
        public void setOwner(string Owner)
        {
            txtOwner.Text = Owner;
        }
        public void setRole(string Role)
        {
            txtRole.Text = Role;
        }
        private void btnRoles_Click(object sender, EventArgs e)
        {
            RoleList objectsList = new RoleList(FormObjects.DBOBJECT_RPT_DETAIL);
            objectsList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
