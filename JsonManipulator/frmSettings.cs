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
        public frmSettings(root _root, bool displayModelFeaturesTab)
        {
            InitializeComponent();
            this._root = _root;
            _displayModelFeaturesTab = displayModelFeaturesTab;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        { 
            _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
            setSetting();
                
            setModelFeatureList();
            splitter4.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmSettings.splitter4.SplitPosition", "200"));
            tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmSettings.tabControl1.SelectedIndex", "0"));
            if (_displayModelFeaturesTab)
            {
                tabControl1.SelectedIndex = 1;
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
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().name = value;
                    _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
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
            LocalStorage.SetValue("frmSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            LocalStorage.Save();
        }
    }
}
