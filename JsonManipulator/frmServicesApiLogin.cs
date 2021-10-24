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
    public partial class frmServicesApiLogin : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmServicesApiLogin()
        {
            InitializeComponent();
        }

        private async void frmAdd_Click(object sender, EventArgs e)
        {
            await OpenAPIs.ApiManager.LogInAsync(txtLogin.Text.Trim(), txtPassword.Text.Trim());
            ((Form1)Application.OpenForms["Form1"]).UpdateLoginStatusDispaly();
            if (OpenAPIs.ApiManager._IsLoggedIn)
            {
                LocalStorage.SetValue("ModelServicesApiLogin", txtLogin.Text.Trim()); 
                LocalStorage.Save();
                ((Form1)Application.OpenForms["Form1"]).showMessage("Logged in successfully");
            }
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
            txtLogin.Text = LocalStorage.GetValue("ModelServicesApiLogin", ""); 
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }
    }

    

}
