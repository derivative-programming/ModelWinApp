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
    public partial class frmServicesApiModelFeatureList : Form
    {
        public class GridItem
        {
            public string InternalName { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsSelected { get; set; }
            public bool IsCompleted { get; set; }
            public GridItem(ModelFeatureListModelItem item)
            {
                this.InternalName = item.Name;
                this.Name = item.DisplayName;
                this.Description = item.Description;

            }
            public GridItem(ModelFeatureObject item)
            {
                this.InternalName = item.name;
                this.Name = item.name;
                this.Description = string.Empty;

            }
        }

        private List<GridItem> _itemList = new List<GridItem>();
        private ModelFeatureListModel _result = null;

        private BindingSource _BindingSource = null;
        private BindingList<GridItem> _BindingList = null;
         
        root _root = null;
        public frmServicesApiModelFeatureList(root root)
        {
            InitializeComponent();
            _root = root;
        }

        private async Task LoadItemsAsync()
        {
            _result = await OpenAPIs.ApiManager.GetModelFeatureListAsync();

            if (_result == null)
                return;

            this.UseWaitCursor = true;
            _itemList.Clear();

            foreach(ModelFeatureListModelItem item in _result.Items)
            {

                _itemList.Add(new GridItem(item));
            }

            //sync with current list
            foreach (ModelFeatureObject existingItem in _root.ModelFeatureObject)
            {
                if(_itemList.Where(x => x.InternalName == existingItem.name).ToList().Count > 0)
                {
                    GridItem gridItem = _itemList.Where(x => x.InternalName == existingItem.name).ToList()[0];
                    gridItem.IsSelected = true;
                    if(existingItem.isCompleted == "true")
                    {
                        gridItem.IsCompleted = true;
                    }
                }
                else
                {
                    _itemList.Add(new GridItem(existingItem));
                }
            }


            _itemList = _itemList.OrderByDescending(x => x.Name).ToList(); 

            gridRequestList.Rows.Clear();
            gridRequestList.Columns.Clear();

            _BindingList = new BindingList<GridItem>(_itemList);
            _BindingSource = new BindingSource(_BindingList, null);
              

            gridRequestList.DataSource = null;
            gridRequestList.DataSource = _BindingSource;
             

            var col = gridRequestList.Columns["InternalName"];
            col.Visible = false;

            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();
            detailButtonColumn.Name = "select_button_column";
            detailButtonColumn.Text = "Select";
            detailButtonColumn.HeaderText = "";
            detailButtonColumn.UseColumnTextForButtonValue = true;

            gridRequestList.Columns.Add(detailButtonColumn);

            foreach (DataGridViewColumn column in gridRequestList.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol = column.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Width = widthCol;
            }
            this.UseWaitCursor = false;
        }
         

        private async void ViewItem(string InternalName)
        {
            var item = GetItem(InternalName);
            //if(item != null)
            //{
            //    using (var form = new frmServicesApiModelFeatureDetail(item))
            //    {
            //        var result = form.ShowDialog(); 
            //    }
            //}
        }

        private ModelFeatureListModelItem GetItem(string internalName)
        {
            ModelFeatureListModelItem result = null;
            foreach (ModelFeatureListModelItem item in _result.Items)
            {
                if(item.Name == internalName)
                {
                    result = item;
                    break;
                } 
            }
            return result;
        } 

        private async void frmForm_Load(object sender, EventArgs e)
        {
            await LoadItemsAsync();
        }

        private void gridRequestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridRequestList.Columns["select_button_column"].Index)
            {
                string internalName = gridRequestList.Rows[e.RowIndex].Cells[0].Value.ToString();
                ToggleSelectedItem(internalName);
                gridRequestList.Invalidate();
            }
        }
         
        private bool IsComItem(string internalName)
        {
            bool result = false;
            if (_root.ModelFeatureObject.Where(x => x.name == internalName).ToList().Count > 0)
            {
                result = true;
            }
            return result;

        }

        private void ToggleSelectedItem(string internalName)
        {
            ModelFeatureObject currentSelectedItem = _root.ModelFeatureObject.Find(x => x.name == internalName);
            GridItem gridItem = _itemList.Where(x => x.InternalName == internalName).ToList()[0];
            if(currentSelectedItem == null)
            {

                ModelFeatureObject item = new ModelFeatureObject();
                item.name = internalName;
                item.version = "";
                _root.ModelFeatureObject.Add(item);
                gridItem.IsSelected = true;
            }
            else
            {
                if(currentSelectedItem.isCompleted == "true")
                {
                    //cant change selected state
                }
                else
                {
                    gridItem.IsSelected = false;
                    _root.ModelFeatureObject = _root.ModelFeatureObject.Where(x => x.name != internalName).ToList();
                }
            }
            _BindingSource.ResetBindings(false);
            gridRequestList.Refresh();
        }
         

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }
         
         
    }

    

}
