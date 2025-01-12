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
    public partial class frmRequestValue : Form
    {
        string _name;

        public string ReturnValue { get; set; }

        List<string> _invalidValues = new List<string>();

        bool _isRequired = false;
        bool _isSpacesAllowed = false;
        int _maxLength = 0;

        string _requiredValidationErrorText = string.Empty;

        public frmRequestValue(string title, string labelText,
            bool isRequired = true, 
            bool isSpacesAllowed = true,
            string defaultValue = "",
            int maxLength = 50,
            string requiredValidationErrorText = "Please enter a value",
            List<string> invalidValues = null)
        {
            InitializeComponent();
            this.Text = title;
            this.lblName.Text = labelText;
            _requiredValidationErrorText = requiredValidationErrorText;
            if(invalidValues != null)
            {
                _invalidValues.AddRange(invalidValues);
            }
            _isRequired = isRequired;
            _isSpacesAllowed = isSpacesAllowed;
            _maxLength = maxLength;
            txtName.Text = defaultValue;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
            {
                ShowValidationError("Already exists.");
                return;
            }

            if (txtName.Text.Trim().Contains(" ") && !_isSpacesAllowed)
            {
                ShowValidationError("Remove Spaces from name.");
                return;
            }
            if (txtName.Text.Trim().Length > _maxLength)
            {
                ShowValidationError("Max property name length is 50.");
                return;
            }
            if (_isRequired && txtName.Text.Trim().Length == 0)
            {
                ShowValidationError("Property name is required.");
                return;
            }

            ReturnValue = txtName.Text.Trim();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if(_invalidValues.Contains(name,StringComparer.OrdinalIgnoreCase))
            {
                result = true;
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void frmRequestValue_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }
         
    }
}
