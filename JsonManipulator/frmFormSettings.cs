using JsonManipulator.Enums;
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
    public partial class frmFormSettings : Form
    {
        objectWorkflow _form;
        ObjectMap _ownerObject;
        List<objectWorkflowParam> _controls;
        List<objectWorkflowButton> _buttons;
        List<objectWorkflowOutputVar> _outputVars;
        bool _isLoadingPropSubscriptions = false;
        public frmFormSettings(string objWFName)
        {
            InitializeComponent();
            this._form = Utils.GetObjWFModelItem(objWFName);
            this._ownerObject = Utils.GetOwnerObject(objWFName);
        }

        private void frmFormSettings_Load(object sender, EventArgs e)
        {
            _controls = new List<objectWorkflowParam>();
            _buttons = new List<objectWorkflowButton>();
            _outputVars = new List<objectWorkflowOutputVar>();
            if(Utils.IsObjectWorkflowAForm(this._form))
            { 
                tabControl1.TabPages["tabControls"].Text = "Controls";
            }
            if (Utils.IsObjectWorkflowAFlow(this._form))
            {
                tabControl1.TabPages.RemoveByKey("tabButtons");
                tabControl1.TabPages["tabControls"].Text = "Input";
            }
            if (this._form.isRequestRunViaDynaFlowAllowed != null && this._form.isRequestRunViaDynaFlowAllowed == "true")
            {
                tabControl1.TabPages.RemoveByKey("tabControls");
                tabControl1.TabPages.RemoveByKey("tabButtons");
                tabControl1.TabPages.RemoveByKey("tabOutput"); 
            }
            else
            {
                tabControl1.TabPages.RemoveByKey("tabDynaFlowTasks");
            }
            setSetting();
            grpMain.Text = _form.Name;
            setControlsList();
            SetPropSubscriptionCheckboxes();

            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter1.SplitPosition", "200"));
            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                setButtonsList();
                splitter2.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter2.SplitPosition", "200"));
            }

            setOutputVarList();
            splitter3.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter3.SplitPosition", "200"));

            setDFTList();
            splitter4.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter4.SplitPosition", "200"));


            if (System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.tabControl1.SelectedIndex", "0")) <= tabControl1.TabPages.Count)
                tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.tabControl1.SelectedIndex", "0"));
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            List<string> ignoreList = new List<string>();
            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                ignoreList = Utils.GetFormPropertiesToIgnore();
            }
            if (Utils.IsObjectWorkflowAFlow(this._form))
            {
                ignoreList = Utils.GetFlowPropertiesToIgnore();
            }
            foreach (var prop in _form.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_form) ?? "").ToString() }); ;
            }
            gridProperties.Columns.Clear();
            gridProperties.DataSource = propertyValues;
            if (gridProperties.Columns.Count > 0)
            {
                gridProperties.Columns[0].ReadOnly = true;
            }
        }
        public void setControlsList()
        {
            lstControl.Items.Clear();
            if(_form.objectWorkflowParam!=null)
            {
                foreach (var param in _form.objectWorkflowParam)
                {
                    lstControl.Items.Add(param.name);
                    _controls.Add(param);
                }
                if (lstControl.Items.Count > 0)
                    lstControl.SelectedIndex = lstControl.Items.Count - 1;
            }

        }

        public void SetPropSubscriptionCheckboxes()
        {
            _isLoadingPropSubscriptions = true;
            chkSubscribeToOwnerObject.Checked = Utils.IsPropSubscriptionEnabledFor(_ownerObject, _form.Name);
            if (_form.targetChildObject != null &&
                _form.targetChildObject.Length > 0)
            {
                Models.ObjectMap objectMap = Utils.GetObjectModelItem(_form.targetChildObject);
                chkSubscribeToTargetChild.Enabled = true;
                chkSubscribeToTargetChild.Checked = Utils.IsPropSubscriptionEnabledFor(objectMap, _form.Name);
            }
            else
            {
                chkSubscribeToTargetChild.Enabled = false;
                chkSubscribeToTargetChild.Checked = false;
            }
            _isLoadingPropSubscriptions = false;
        }

        public void setButtonsList()
        {
            lstButtons.Items.Clear();
            if(_form.objectWorkflowButton!=null)
            {
                foreach (var param in _form.objectWorkflowButton)
                {
                    string buttonText = string.Empty;
                    if(param.buttonText != null)
                    {
                        buttonText = param.buttonText;
                    }
                    lstButtons.Items.Add(buttonText);
                    _buttons.Add(param);
                }
                if (lstButtons.Items.Count > 0)
                    lstButtons.SelectedIndex = lstButtons.Items.Count - 1;
            }
            
        }

        public void setOutputVarList()
        { 
            lstOutputVars.Items.Clear();
            if (_form.objectWorkflowOutputVar != null)
            {
                foreach (var param in _form.objectWorkflowOutputVar)
                {
                    lstOutputVars.Items.Add(param.name);
                    _outputVars.Add(param);
                }
                if (lstOutputVars.Items.Count > 0)
                    lstOutputVars.SelectedIndex = lstOutputVars.Items.Count - 1;
            }
        }


        public void setDFTList()
        {
            lstDFT.Items.Clear();
            if (_form.dynaFlowTask != null)
            {
                foreach (var param in _form.dynaFlowTask)
                {
                    lstDFT.Items.Add(param.name); 
                }
                if (lstDFT.Items.Count > 0)
                    lstDFT.SelectedIndex = lstDFT.Items.Count - 1;
            }
        }

        private void lstControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstControl.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormParamPropertiesToIgnore();
                objectWorkflowParam frmControl = _form.objectWorkflowParam.Where(x => x.name == controlName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridControls.Columns.Clear();
                gridControls.DataSource = propertyValues;
                if (gridControls.Columns.Count > 0)
                {
                    gridControls.Columns[0].ReadOnly = true;
                }
            }
            
        }

        private void lstButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstButtons.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String buttonName = lstButtons.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormButtonPropertiesToIgnore();
                objectWorkflowButton frmControl = _form.objectWorkflowButton.Where(x => x.buttonText == buttonName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridButtons.Columns.Clear();
                gridButtons.DataSource = propertyValues;
                if (gridButtons.Columns.Count > 0)
                {
                    gridButtons.Columns[0].ReadOnly = true;
                }
            }

        }
        private void lstOutputVars_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String itemName = lstOutputVars.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormOutputVarPropertiesToIgnore();
                objectWorkflowOutputVar frmControl = _form.objectWorkflowOutputVar.Where(x => x.name == itemName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridOutput.Columns.Clear();
                gridOutput.DataSource = propertyValues;
                if (gridOutput.Columns.Count > 0)
                {
                    gridOutput.Columns[0].ReadOnly = true;
                }
            }
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            FrmAddControl frmControl = new FrmAddControl(_form.Name, _ownerObject.name);
            frmControl.ShowDialog();
        }

        private void btnControlUp_Click(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex, true);
            }
           
        }

        private void btnControlDown_Click(object sender, EventArgs e)
        {
            if (lstControl.SelectedItem != null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex,true);
            }
                
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            FrmAddButton frmAddButton = new FrmAddButton(_form.Name, _ownerObject.name, ButtonType.FORM);
            frmAddButton.ShowDialog();
        }


        private void btnOutputVar_Click(object sender, EventArgs e)
        {
            FrmAddOutputVar frmControl = new FrmAddOutputVar(_form.Name, _ownerObject.name);
            frmControl.ShowDialog();

        }

        private void btnOutputVarUp_Click(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                int selectedIndex = lstOutputVars.SelectedIndex;
                objectWorkflowOutputVar item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Insert(newIndex, item);
                setOutputVarList();
                lstOutputVars.SetSelected(newIndex, true);
            }
        }

        private void btnOutputVarDown_Click(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                int selectedIndex = lstOutputVars.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Count;
                objectWorkflowOutputVar item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Insert(newIndex, item);
                setOutputVarList();
                lstOutputVars.SetSelected(newIndex, true);
            }
        }

        private void gridProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProperties.DataSource != null)
            {
                string property = gridProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                objectWorkflow temp = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault(); 
                typeof(objectWorkflow).GetProperty(property).SetValue(temp, value);
                //if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow == null)
                //    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
                //Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow.Add(temp);
                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 1);
                }
                if (property.Equals("OwnerObject") || property.Equals("targetChildObject"))
                {
                    SetPropSubscriptionCheckboxes();
                }
                if (property.Equals("isDynaFlowTask") || property.Equals("isRequestRunViaDynaFlowAllowed"))
                {
                    ((Form1)Application.OpenForms["Form1"]).PopulateTree(); 
                }

            }
        }

        private void gridControls_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridControls.DataSource != null && lstControl.SelectedItem!=null)
            {
                string property = gridControls.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstControl.SelectedIndex;
                typeof(objectWorkflowParam).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(lstControl.SelectedIndex), value); ;
                setControlsList();
                lstControl.SetSelected(index, true);
            }
        }

        private void gridButtons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridButtons.DataSource != null && lstButtons.SelectedItem!=null)
            {
                string property = gridButtons.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property.ToLower() == "destinationTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(objectWorkflowButton).GetProperty("destinationContextObjectName").SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(lstButtons.SelectedIndex), destinationOwnerObject.name); ;

                }
                int index = lstButtons.SelectedIndex;
                typeof(objectWorkflowButton).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(lstButtons.SelectedIndex), value); ;
                setButtonsList();
                lstButtons.SetSelected(index, true);
            }
        }
         
        private void gridOutput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridOutput.DataSource != null && lstOutputVars.SelectedItem != null)
            {
                string property = gridOutput.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstOutputVars.SelectedIndex;
                typeof(objectWorkflowOutputVar).GetProperty(property).SetValue(
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(lstOutputVars.SelectedIndex), value); ;
                setOutputVarList();
                lstOutputVars.SetSelected(index, true);
            }
        }

        private void gridProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell(); 
                string propertyName = gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                
                if (propertyName.Equals("RoleRequired", StringComparison.OrdinalIgnoreCase))
                {
                    using (var form = new frmModelSearch(ModelSearchOptions.ROLES))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("OwnerObject", StringComparison.OrdinalIgnoreCase) ||
                    propertyName.Equals("targetChildObject", StringComparison.OrdinalIgnoreCase))
                {
                    using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
            }
        }
        public void setData(string value,int row,int cell)
        {
           
            gridProperties.Rows[row].Cells[cell].Value = value;
            gridProperties.RefreshEdit();
        }

        private void gridControls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >0)
            {
                
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("AutoCompleteAddressTargetType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getAutoCompleteAddressTargetTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("SourceObjectName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setControlData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("SourcePropertyName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview    
                    if (lstControl.SelectedItem != null)
                    {
                        List<PropertyValue> propertyValues = new List<PropertyValue>();
                        String controlName = lstControl.SelectedItem.ToString();
                        List<string> ignoreList = Utils.GetFormParamPropertiesToIgnore();
                        objectWorkflowParam frmControl = _form.objectWorkflowParam.Where(x => x.name == controlName).FirstOrDefault();

                        if (frmControl.sourceObjectName != null && frmControl.sourceObjectName.Trim().Length > 0)
                        {
                            using (var form = new FrmSelectObjProps(frmControl.sourceObjectName, false))
                            {
                                var result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    string propList = string.Empty;
                                    if (form.results.Count > 0)
                                    {
                                        string val = form.results[0].Split(".".ToCharArray())[1];
                                        setControlData(val, e.RowIndex, e.ColumnIndex);
                                    }
                                    else
                                    {
                                        setControlData(string.Empty, e.RowIndex, e.ColumnIndex);

                                    }
                                }
                            }
                        }
                    }
                    
                }

            }
        }

        private void gridButtons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("ButtonType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getButtons(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("destinationTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.REPORTS_AND_FORMS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setButtonData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
            }

        }
        public void setButtonData(string value, int row, int column)
        {
            gridButtons.Rows[row].Cells[column].Value = value;
            gridButtons.RefreshEdit();
        }

        public void setControlData(string value, int row, int column)
        {
            gridControls.Rows[row].Cells[column].Value = value;
            gridControls.RefreshEdit();
        }


        private void gridOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridOutput[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridOutput[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }

                if (propertyName.Equals("SourceObjectName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setOutputData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("SourcePropertyName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview    
                    if (lstControl.SelectedItem != null)
                    { 
                        String itemName = lstOutputVars.SelectedItem.ToString();
                        List<string> ignoreList = Utils.GetFormOutputVarPropertiesToIgnore();
                        objectWorkflowOutputVar frmControl = _form.objectWorkflowOutputVar.Where(x => x.name == itemName).FirstOrDefault();
  
                        if (frmControl.sourceObjectName != null && frmControl.sourceObjectName.Trim().Length > 0)
                        {
                            using (var form = new FrmSelectObjProps(frmControl.sourceObjectName, false))
                            {
                                var result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    string propList = string.Empty;
                                    if (form.results.Count > 0)
                                    {
                                        string val = form.results[0].Split(".".ToCharArray())[1];
                                        setOutputData(val, e.RowIndex, e.ColumnIndex);
                                    }
                                    else
                                    {
                                        setOutputData(string.Empty, e.RowIndex, e.ColumnIndex);

                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        public void setOutputData(string value, int row, int column)
        {
            gridOutput.Rows[row].Cells[column].Value = value;
            gridOutput.RefreshEdit();
        }

        private void gridProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControls_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridButtons_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void gridOutput_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridButtons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmFormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalStorage.SetValue("frmFormSettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());



            LocalStorage.SetValue("frmFormSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                LocalStorage.SetValue("frmFormSettings.splitter2.SplitPosition", splitter2.SplitPosition.ToString());
            }
             
            LocalStorage.SetValue("frmFormSettings.splitter3.SplitPosition", splitter3.SplitPosition.ToString());

            LocalStorage.SetValue("frmFormSettings.splitter4.SplitPosition", splitter4.SplitPosition.ToString());

            LocalStorage.Save();

        }

        private void btnButtonUp_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                objectWorkflowButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void btnButtonDown_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Count;
                objectWorkflowButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void rtbJSON_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbJSON.Text = JsonConvert.SerializeObject(this._form, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        }

        private void chkSubscribeToOwnerObject_CheckedChanged(object sender, EventArgs e)
        { 
            if (_isLoadingPropSubscriptions)
                return;
            if (chkSubscribeToOwnerObject.Checked)
            {
                Utils.AddPropSubscriptionFor(_ownerObject, _form.Name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(_ownerObject, _form.Name);
            }
        }

        private void chkSubscribeToTargetChild_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingPropSubscriptions)
                return;
            Models.ObjectMap objectMap = Utils.GetObjectModelItem(_form.targetChildObject);
            if (chkSubscribeToTargetChild.Checked)
            {
                Utils.AddPropSubscriptionFor(objectMap, _form.Name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(objectMap, _form.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDFT_Click(object sender, EventArgs e)
        {

            using (var form = new frmModelSearch(ModelSearchOptions.DYNAFLOW_TASKS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    AddDFT(val);
                }
            }
        }

        private void AddDFT(string name)
        {

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask = new List<Models.dynaFlowTask>();
            dynaFlowTask dynaFlowTask = new dynaFlowTask { name = name};

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Where(x => x.name == name).ToList().Count == 0)
            { 
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Add(dynaFlowTask);
                setDFTList();
            }
        }

        private void lstDFT_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstDFT.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstDFT.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormDFTPropertiesToIgnore();
                dynaFlowTask dynaFlowTask = _form.dynaFlowTask.Where(x => x.name == controlName).FirstOrDefault();
                foreach (var prop in dynaFlowTask.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(dynaFlowTask) ?? "").ToString() });
                }
                gridDFT.Columns.Clear();
                gridDFT.DataSource = propertyValues;
                if (gridDFT.Columns.Count > 0)
                {
                    gridDFT.Columns[0].ReadOnly = true;
                }
            }
        }

        private void gridDFT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridDFT.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridDFT[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
            }
        }

        private void gridDFT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gridDFT.DataSource != null && lstDFT.SelectedItem != null)
            {
                string property = gridDFT.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridDFT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridDFT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstDFT.SelectedIndex;
                typeof(dynaFlowTask).GetProperty(property).SetValue(
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.ElementAt(lstDFT.SelectedIndex), value); ;
                setDFTList();
                lstDFT.SetSelected(index, true);
            }
        }

        private void gridDFT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnDFTUp_Click(object sender, EventArgs e)
        {

            if (lstDFT.SelectedItem != null)
            {
                int selectedIndex = lstDFT.SelectedIndex;
                dynaFlowTask item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Insert(newIndex, item);
                setDFTList();
                lstDFT.SetSelected(newIndex, true);
            }
        }

        private void btnDFTDown_Click(object sender, EventArgs e)
        {

            if (lstDFT.SelectedItem != null)
            {
                int selectedIndex = lstDFT.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Count;
                dynaFlowTask item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().dynaFlowTask.Insert(newIndex, item);
                setDFTList();
                lstDFT.SetSelected(newIndex, true);
            }
        }

        private void gridDFT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ShowUnsavedChanges()
        {
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
        }

        private void btnAddNewDFT_Click(object sender, EventArgs e)
        {

            using (var form = new frmAddDynaFlowTask())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    AddDFT(val);
                    ((Form1)Application.OpenForms["Form1"]).SetSelectedDynaFlowTreeItem(_form.Name);
                }
            }
        }

        private void btnCopyList_Click(object sender, EventArgs e)
        {

            string itemList = string.Empty;


            foreach (var prop in _form.objectWorkflowParam)
            {
                itemList = itemList + prop.name + Environment.NewLine;
            }

            Clipboard.SetText(itemList);
        }

        private void btnAddLookup_Click(object sender, EventArgs e)
        {

            using (var form = new frmModelSearch(ModelSearchOptions.LOOKUPS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue + "Code";

                    if (ItemExists(val))
                    {
                        ((Form1)Application.OpenForms["Form1"]).showMessage("Name already exists."); 
                        return;
                    } 


                    this._form.objectWorkflowParam.Add(new objectWorkflowParam { name = val, dataType = "uniqueidentifier", fKObjectName = form.ReturnValue, isFK = "true", isFKList = "true", isFKLookup = "true", isFKListInactiveIncluded = "true" });
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Control created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    setControlsList();
                }
            }
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if (this._form.objectWorkflowParam.Where(x => x.name == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                objectWorkflowButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(selectedIndex);
                
                if (item != null &&
                    item.destinationTargetName != null &&
                    item.destinationTargetName.Trim().Length > 0)
                {
                    ((Form1)Application.OpenForms["Form1"]).SetSelectedTreeItem(item.destinationTargetName);
                }
            }
        }

        private void btnViewInDemo_Click(object sender, EventArgs e)
        {

            //get output folder
            string outputFolder = LocalStorage.GetValue("FabricationFolder", "");
            if (outputFolder.Trim().Length == 0)
                return;

            string demoFolder = outputFolder.TrimEnd(@"\".ToCharArray()) + @"\demo\bootstrap_5\";

            if (!System.IO.Directory.Exists(demoFolder))
                return;
            //determine file paths for three user types 
            string adminUserDemoDashboardFilePath = demoFolder + _form.Name + ".html";

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = adminUserDemoDashboardFilePath;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }

        private void btnCloneReport_Click(object sender, EventArgs e)
        {
            if (_form.RoleRequired.Length > 0)
            {
                using (var form = new frmModelSearch(ModelSearchOptions.ROLES))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string val = form.ReturnValue;


                        if (!val.Equals(_form.RoleRequired, StringComparison.OrdinalIgnoreCase))
                        {
                            string json = JsonConvert.SerializeObject(_form, Formatting.Indented, new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

                            objectWorkflow newItem = JsonConvert.DeserializeObject<objectWorkflow>(json);
                            newItem.Name = newItem.Name.Replace(_form.RoleRequired, val); 
                            for (int i = 0; i < newItem.objectWorkflowParam.Count; i++)
                            {
                                newItem.objectWorkflowParam[i].codeDescription = newItem.objectWorkflowParam[i].codeDescription.Replace(" " + _form.RoleRequired + " ", " " + val + " ");
                            }
                            newItem.RoleRequired = val;
                            newItem.layoutName = val + "Layout";
                            newItem.initObjectWorkflowName = newItem.Name + "InitObjWF"; 


                            List<string> existingNames = Utils.GetNameList(false, true, true, true, true);
                            if (existingNames.Where(x => x.ToLower().Equals(newItem.Name.Trim().ToLower())).ToList().Count == 0)
                            {
                                _ownerObject.objectWorkflow.Add(newItem);
                                ((Form1)Application.OpenForms["Form1"]).showMessage("Object Workflow was cloned successfully");
                                ((Form1)Application.OpenForms["Form1"]).AddToTree(newItem);
                            }

                        }
                    }
                }
            }
        }

        private void btnCloneToSameRole_Click(object sender, EventArgs e)
        {
            


            List<string> existingNames = Utils.GetNameList(false, true, true, true, true);
            using (var form = new frmRequestValue(
                "New Form Name", "Form Name", true, false, _form.Name, 50, "Please enter a value", existingNames))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string newName = form.ReturnValue;
                    string json = JsonConvert.SerializeObject(_form, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    objectWorkflow newItem = JsonConvert.DeserializeObject<objectWorkflow>(json);
                    newItem.Name = newName; // _form.Name + "Clone"; 

                    int i = 1;

                    while (existingNames.Where(x => x.ToLower().Equals(newItem.Name.Trim().ToLower())).ToList().Count > 0)
                    {
                        i++;
                        newItem.Name = _form.Name + "Clone" + i.ToString();
                    }

                    newItem.initObjectWorkflowName = newItem.Name + "InitObjWF";

                    _ownerObject.objectWorkflow.Add(newItem);
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Object Workflow was cloned successfully");
                    ((Form1)Application.OpenForms["Form1"]).AddToTree(newItem);
                }
            }
        }

        private void btnReverseControls_Click(object sender, EventArgs e)
        {
            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Reverse();
            if (lstControl.SelectedItem != null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count;

                int newIndex = count - 1 - selectedIndex;

                setControlsList();
                lstControl.SetSelected(newIndex, true);
            }
            else
            {
                setControlsList();
            }
        }

        private void btnImportOutputVars_Click(object sender, EventArgs e)
        {
            if (Utils.IsObjectWorkflowAPageInitFlow(this._form))
            {
                using (var form = new frmModelSearch(ModelSearchOptions.INIT_PAGE_FLOWS))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string val = form.ReturnValue;

                        var sourceObjWF = Utils.GetObjWFModelItem(val);

                        var itemsToCopy = sourceObjWF.objectWorkflowOutputVar.ToList();


                        List<string> existingItemNameList = this._form.objectWorkflowOutputVar.Select(x => x.name).ToList();

                        for (int i = 0; i < itemsToCopy.Count; i++)
                        {
                            if (existingItemNameList.Contains(itemsToCopy[i].name, StringComparer.OrdinalIgnoreCase))
                            {
                                continue;
                            }

                            var origItem = itemsToCopy[i];

                            var clonedItem = new objectWorkflowOutputVar
                            {
                                buttonText = origItem.buttonText,
                                conditionalVisiblePropertyName = origItem.conditionalVisiblePropertyName,
                                isIgnored = origItem.isIgnored,
                                isVisible = origItem.isVisible,
                                buttonNavURL = origItem.buttonNavURL,
                                buttonObjectWFName = origItem.buttonObjectWFName,
                                dataSize = origItem.dataSize,
                                dataType = origItem.dataType,
                                defaultValue = origItem.defaultValue,
                                fKObjectName = origItem.fKObjectName,
                                headerLabelText = origItem.headerLabelText,
                                isAutoRedirectURL = origItem.isAutoRedirectURL,
                                isFK = origItem.isFK,
                                isFKLookup = origItem.isFKLookup,
                                isHeaderLabelVisible = origItem.isHeaderLabelVisible,
                                isHeaderText = origItem.isHeaderText,
                                isLink = origItem.isLink,
                                name = origItem.name,
                                sourceObjectName = origItem.sourceObjectName,
                                sourcePropertyName = origItem.sourcePropertyName
                            };

                            this._form.objectWorkflowOutputVar.Add(clonedItem);


                        }

                        ((Form1)Application.OpenForms["Form1"]).showMessage("Output Vars imported successfully");
                        ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();

                        setOutputVarList();
                    }
                }
            }
        }
    }
}
