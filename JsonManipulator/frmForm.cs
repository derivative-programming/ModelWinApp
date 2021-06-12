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
    public partial class frmForm : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmForm()
        {
            InitializeComponent();
        }

        private void frmAdd_Click(object sender, EventArgs e)
        {
            objectWorkflow form = new objectWorkflow();
            form.Name = txtName.Text;
            form.RoleRequired = txtRole.Text;
            form.OwnerObject = txtOwner.Text;
            if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().objectWorkflow == null)
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
            else
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Add(new ObjectMap { name = txtOwner.Text});
            Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name== txtOwner.Text).FirstOrDefault().objectWorkflow.Add(form);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(form);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Form was added successfully");
            this.Close();
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
        }
        public void setOwner(string Owner)
        {
            txtOwner.Text =Owner;
        }
        private void btnOwner_Click(object sender, EventArgs e)
        {
            
            ObjectsList objectsList = new ObjectsList(FormObjects.FORM);
            objectsList.ShowDialog();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            RoleList roleList = new RoleList(FormObjects.FORM);
            roleList.ShowDialog();
        }
        public void setRole(string Role)
        {
            txtRole.Text =Role;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    

}
