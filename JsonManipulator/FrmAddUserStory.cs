using JsonManipulator.Models;
using Newtonsoft.Json;
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
    public partial class FrmAddUserStory : Form
    {  
        public FrmAddUserStory()
        {
            InitializeComponent(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            txtUserStory.Text = txtUserStory.Text.Trim();
            if (ItemExists(txtUserStory.Text))
            {
                ShowValidationError("User story already exists.");
                return;
            } 

            if (txtUserStory.Text.Trim().Length == 0)
            {
                ShowValidationError("User story text is required");
                return;
            }
             

            Models.UserStoryObject userStory = new UserStoryObject();
            userStory.storyText = txtUserStory.Text.Trim();
            userStory.isStoryProcessed = "false";
            Form1._model.root.NameSpaceObjects.FirstOrDefault().UserStoryObject.Add(userStory);
             ((Form1)Application.OpenForms["Form1"]).showMessage("User story created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmSettings)Application.OpenForms["frmSettings"]).setUserStories();
            this.Close();
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().UserStoryObject.Where(x => x.storyText.ToLower().Trim() == name.ToLower().Trim()).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private void FrmAddUserStory_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }

        private void btnBulk_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBulkUserStoryAdd())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    List<string> items = new List<string>();
                    items.AddRange(val.Split("\n".ToCharArray()));
                    for (int i = 0; i < items.Count; i++)
                    {
                        string itemName = items[i].Trim(); 
                         
                        if (itemName.Length > 0 && !ItemExists(itemName))
                        {

                            Models.UserStoryObject userStory = new UserStoryObject();
                            userStory.storyText = itemName;
                            userStory.isStoryProcessed = "false";
                            Form1._model.root.NameSpaceObjects.FirstOrDefault().UserStoryObject.Add(userStory);
                             
                        }
                    } 
                    ((Form1)Application.OpenForms["Form1"]).showMessage("User story created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmSettings)Application.OpenForms["frmSettings"]).setUserStories();
                }
            }
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
    }
}
