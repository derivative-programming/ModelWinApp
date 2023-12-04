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
    public partial class frmSettings : Form
    {
        root _root = new root();
        private bool _displayModelFeaturesTab = false;
        private bool _displayUserStoriesTab = false;
        public frmSettings(root _root, bool displayModelFeaturesTab, bool displayUserStoriesTab)
        {
            InitializeComponent();
            this._root = _root;
            _displayModelFeaturesTab = displayModelFeaturesTab;
            _displayUserStoriesTab = displayUserStoriesTab;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        { 
            _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
            setSetting();
                
            setModelFeatureList();
            setNavButtonsList();
            setLexicon();
            setUserStories();
            splitter4.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmSettings.splitter4.SplitPosition", "200"));
            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmSettings.splitter1.SplitPosition", "200"));
            tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmSettings.tabControl1.SelectedIndex", "0"));
            if (_displayModelFeaturesTab)
            {
                tabControl1.SelectedIndex = 1;
            }
            if (_displayUserStoriesTab)
            {
                tabControl1.SelectedIndex = 4;
            }
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            List<string> ignoreList = Utils.GetRootPropertiesToIgnore();
            foreach (var prop   in _root.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;

                if (!prop.PropertyType.IsGenericType)
                propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_root) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if (dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true;
            } 
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dataProperties.DataSource!=null)
            {
                string property = dataProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property == "CodeNameSpaceSecondaryName")
                {
                    value = Utils.ReplaceSpecialCharacters(value);
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().name = value;
                    _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
                    setSetting();
                }
                else if (property == "CodeNameSpaceRootName")
                {
                    value = Utils.ReplaceSpecialCharacters(value);
                    Form1._model.root.CodeNameSpaceRootName = value; 
                    setSetting();
                }
                else
                {
                    
                    typeof(root).GetProperty(property).SetValue(Form1._model.root, value);
                }

                ((Form1)Application.OpenForms["Form1"]).populateProjectDetails();
            }
           
        }

        private void dataProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridModelFeature_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddModelFeature(string name, string version)
        {

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject = new List<Models.ModelFeatureObject>();
            ModelFeatureObject item = new ModelFeatureObject { name = name ,version = version};

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject.Where(x => x.name == name).ToList().Count == 0)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject.Add(item);
                setModelFeatureList();
            }
        }
        private void lstModelFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstModelFeatures.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstModelFeatures.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetModelFeaturePropertiesToIgnore();
                ModelFeatureObject modelFeatureObject = _root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject.Where(x => x.name == controlName).FirstOrDefault();
                foreach (var prop in modelFeatureObject.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(modelFeatureObject) ?? "").ToString() });
                }
                gridModelFeature.Columns.Clear();
                gridModelFeature.DataSource = propertyValues;
                if (gridModelFeature.Columns.Count > 0)
                {
                    gridModelFeature.Columns[0].ReadOnly = true;
                    gridModelFeature.Columns[1].ReadOnly = true;
                }
            }
        }

        private void btnAddModelFeature_Click(object sender, EventArgs e)
        {
             
            using (var form = new frmServicesApiModelFeatureList(_root))
            {
                var result = form.ShowDialog(); 
                setModelFeatureList();
            }
        }

        public void setModelFeatureList()
        {
            lstModelFeatures.Items.Clear();
            if (_root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject != null)
            {
                foreach (var param in _root.NameSpaceObjects.FirstOrDefault().ModelFeatureObject)
                {
                    lstModelFeatures.Items.Add(param.name);
                }
                if (lstModelFeatures.Items.Count > 0)
                    lstModelFeatures.SelectedIndex = lstModelFeatures.Items.Count - 1;
            }
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            LocalStorage.SetValue("frmSettings.splitter4.SplitPosition", splitter4.SplitPosition.ToString());
            LocalStorage.SetValue("frmSettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());
            LocalStorage.SetValue("frmSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            LocalStorage.Save();
        }

        private void lstNavButtons_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstNavButtons.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstNavButtons.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetNavButtonPropertiesToIgnore();
                navButton navButtonObject = _root.navButton.Where(x => x.buttonName == controlName).FirstOrDefault();
                foreach (var prop in navButtonObject.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(navButtonObject) ?? "").ToString() });
                }
                gridNavButtons.Columns.Clear();
                gridNavButtons.DataSource = propertyValues;
                if (gridNavButtons.Columns.Count > 0)
                {
                    gridNavButtons.Columns[0].ReadOnly = true; 
                }
            }
        }

        private void btnAddNavButton_Click(object sender, EventArgs e)
        {
            //FrmAddButton frmAddButton = new FrmAddButton(string.Empty, string.Empty,  ButtonType.NAV_BUTTON);
            //frmAddButton.ShowDialog();

            FrmAddNavButton frmAddNavButton = new FrmAddNavButton();
            frmAddNavButton.ShowDialog();

            setNavButtonsList();
        }


        public void setNavButtonsList()
        {
            lstNavButtons.Items.Clear();
            if (_root.navButton != null)
            {
                foreach (var param in _root.navButton)
                {
                    lstNavButtons.Items.Add(param.buttonName);
                }
                if (lstNavButtons.Items.Count > 0)
                    lstNavButtons.SelectedIndex = lstNavButtons.Items.Count - 1;
            }
        }

        private void gridNavButtons_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridNavButtons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridNavButtons.DataSource != null && lstNavButtons.SelectedItem != null)
            {
                string property = gridNavButtons.Rows[gridNavButtons.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridNavButtons.Rows[gridNavButtons.CurrentCell.RowIndex].Cells[gridNavButtons.CurrentCell.ColumnIndex].Value != null)
                {
                    value = gridNavButtons.Rows[gridNavButtons.CurrentCell.RowIndex].Cells[gridNavButtons.CurrentCell.ColumnIndex].Value.ToString();
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
                        gridNavButtons.Rows[gridNavButtons.CurrentCell.RowIndex].Cells[gridNavButtons.CurrentCell.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(reportButton).GetProperty("destinationContextObjectName").SetValue(Form1._model.root.navButton.ElementAt(lstNavButtons.SelectedIndex), destinationOwnerObject.name);

                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property.ToLower() == "buttontype".ToLower())
                {
                    if (value != null && !Utils.getNavButtonList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstNavButtons.SelectedIndex;
                typeof(reportButton).GetProperty(property).SetValue(Form1._model.root.navButton.ElementAt(lstNavButtons.SelectedIndex), value);
                setNavButtonsList();
                lstNavButtons.SetSelected(index, true);
            }
        }

        private void gridNavButtons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridNavButtons.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("ButtonType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridNavButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getNavButtonTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridNavButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("destinationTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    using (var form = new frmModelSearch(ModelSearchOptions.FORMS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setNavButtonData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
            }
        }
        public void setNavButtonData(string value, int row, int column)
        {
            gridNavButtons.Rows[row].Cells[column].Value = value;
            gridNavButtons.RefreshEdit();
        }

        private void btnColumnsMoveUp_Click(object sender, EventArgs e)
        {
            if (lstNavButtons.SelectedItem != null)
            {
                int selectedIndex = lstNavButtons.SelectedIndex;
                navButton item = Form1._model.root.navButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.navButton.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.navButton.RemoveAt(selectedIndex);
                Form1._model.root.navButton.Insert(newIndex, item);
                setNavButtonsList();
                lstNavButtons.SetSelected(newIndex, true);
            }
        }

        private void btnColumnsMoveDown_Click(object sender, EventArgs e)
        {
            if (lstNavButtons.SelectedItem != null)
            {
                int selectedIndex = lstNavButtons.SelectedIndex;
                int count = Form1._model.root.navButton.Count;
                navButton item = Form1._model.root.navButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.navButton.RemoveAt(selectedIndex);
                Form1._model.root.navButton.Insert(newIndex, item);
                setNavButtonsList();
                lstNavButtons.SetSelected(newIndex, true);
            }
        }

        private void btnColumnsDelete_Click(object sender, EventArgs e)
        {
            if (lstNavButtons.SelectedItem != null)
            {
                int selectedIndex = lstNavButtons.SelectedIndex;
                int count = Form1._model.root.navButton.Count;
                navButton item = Form1._model.root.navButton.ElementAt(selectedIndex); 
                Form1._model.root.navButton.RemoveAt(selectedIndex); 
                setNavButtonsList(); 
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        private void setLexicon()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            gridLexicon.Columns.Clear();
            if (_root.NameSpaceObjects[0].LexiconObject != null)
            {
                foreach (var prop in _root.NameSpaceObjects[0].LexiconObject.OrderBy(x => x.internalTextValue).ToList())
                {
                    propertyValues.Add(new PropertyValue { Property = prop.internalTextValue, Value = prop.displayTextValue }); ;
                }
            }
            gridLexicon.DataSource = propertyValues;
            if (gridLexicon.Columns.Count > 0)
            {
                gridLexicon.Columns[0].ReadOnly = true;
            }
        }

        private void gridLexicon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLexicon.DataSource != null)
            {
                string property = gridLexicon.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridLexicon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridLexicon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                _root.NameSpaceObjects[0].LexiconObject.Where(x => x.internalTextValue == property).ToList()[0].displayTextValue = value; 
                 
            }
        }


        public void setUserStories()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            gridUserStories.Columns.Clear();

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().UserStoryObject == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().UserStoryObject = new List<Models.UserStoryObject>();

            foreach (var prop in _root.NameSpaceObjects[0].UserStoryObject.OrderBy(x => x.storyText).ToList())
            {
                propertyValues.Add(new PropertyValue { Property = prop.storyText, Value = prop.isIgnored }); ;
            }

            gridUserStories.DataSource = propertyValues;
            if (gridUserStories.Columns.Count > 0)
            {
                gridUserStories.Columns[0].ReadOnly = true;
                gridUserStories.Columns[0].HeaderText = "User Story";
                gridUserStories.Columns[1].HeaderText = "Is Ignored";
            }
        }

        private void gridUserStories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUserStories.DataSource != null && e.RowIndex > -1)
            {
                string property = gridUserStories.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;

                if (gridUserStories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridUserStories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (value != null && !Utils.getBooleanList().Contains(value))
                { 
                    return;
                }
                _root.NameSpaceObjects[0].UserStoryObject.Where(x => x.storyText == property).ToList()[0].isIgnored = value;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmAddUserStory frmAddUserStory = new FrmAddUserStory();
            frmAddUserStory.ShowDialog();
        }

        private void gridUserStories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridUserStories.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                // On click of datagridview cell, attched combobox with this click cell of datagridview  
                gridUserStories[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                l_objGridDropbox.ValueMember = "Value";
                l_objGridDropbox.DisplayMember = "Display";
                l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                

            }
        }
    }
}
