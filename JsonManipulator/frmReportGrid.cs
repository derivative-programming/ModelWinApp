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
    public partial class frmReportGrid : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmReportGrid()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report == null)
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report = new List<Models.Report>();
            Report rpt = new Report { name = txtName.Text, RoleRequired = txtRole.Text, TargetChildObject = txtChild.Text, visualizationType = "Grid",OwnerObject=txtOwner.Text };
            Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text).FirstOrDefault().report.Add(rpt);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Report Grid was added successfully");
            ((Form1)Application.OpenForms["Form1"]).AddToTree(rpt);
            this.Close();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            ObjectsList objectsList = new ObjectsList(FormObjects.REPORT);
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
        public void setChild(string Child)
        {
            txtChild.Text = Child;
        }
        private void btnRoles_Click(object sender, EventArgs e)
        {
            RoleList objectsList = new RoleList(FormObjects.REPORT);
            objectsList.ShowDialog();
        }

        private void btnChild_Click(object sender, EventArgs e)
        {
            ObjectsList objectsList = new ObjectsList(FormObjects.REPORT_CHILD);
            objectsList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
