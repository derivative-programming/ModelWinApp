using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{ 
    public partial class frmServicesApiTemplateSetList : Form
    {
        public class GridItem
        {
            public string InternalName { get; set; }
            public string Name { get; set; } 
            public string Version { get; set; }
            public bool IsSelected { get; set; } 
            public GridItem(TemplateSetListModelItem item)
            {
                this.InternalName = item.Name;
                this.Name = item.Title; 
                this.Version = item.DisplayVersion;
                this.IsSelected = false;

            }
            public GridItem(TemplateSetObject item)
            {
                this.InternalName = item.name;
                this.Name = item.title; 
                this.Version = item.version;
                this.IsSelected = false;
                if (item.isDisabled == "false")
                {
                    IsSelected = true;
                }
            }
        }

        private List<GridItem> _itemList = new List<GridItem>();
        private TemplateSetListModel _apiList = null;
         
         
        root _root = null;
        public frmServicesApiTemplateSetList(root root)
        {
            InitializeComponent();
            _root = root;
            if (_root.templateSet == null)
                _root.templateSet = new List<TemplateSetObject>();
        }

        private void BuildGrid()
        {
            this.UseWaitCursor = true;
            _itemList.Clear();

            foreach (TemplateSetListModelItem item in _apiList.Items)
            {

                _itemList.Add(new GridItem(item));
            }

            //sync with current list
            foreach (TemplateSetObject existingItem in _root.templateSet)
            {
                if (_itemList.Where(x => x.InternalName == existingItem.name && x.Version == existingItem.version).ToList().Count > 0)
                {
                    GridItem gridItem = _itemList.Where(x => x.InternalName == existingItem.name && x.Version == existingItem.version).ToList()[0];
                    gridItem.IsSelected = true;
                    if (existingItem.isDisabled == "true")
                    {
                        gridItem.IsSelected = false;
                    }

                }
                else
                {
                    _itemList.Add(new GridItem(existingItem));
                }
            }


            _itemList = _itemList.OrderBy(x => x.Name).ToList();

            //gridRequestList.Rows.Clear();
            gridRequestList.Columns.Clear();


            gridRequestList.DataSource = null;
            gridRequestList.DataSource = ToDataTable(_itemList);


            var col = gridRequestList.Columns["InternalName"];
            col.Visible = false;

            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();
            detailButtonColumn.Name = "select_button_column";
            detailButtonColumn.Text = "Select";
            detailButtonColumn.HeaderText = "";
            detailButtonColumn.UseColumnTextForButtonValue = true;

            gridRequestList.Columns.Add(detailButtonColumn);

            //foreach (DataGridViewColumn column in gridRequestList.Columns)
            //{
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    int widthCol = column.Width;
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    column.Width = widthCol;
            //}
            this.UseWaitCursor = false;
        }
        private async Task LoadItemsAsync()
        {
            _apiList = await OpenAPIs.ApiManager.GetTemplateSetListAsync();

            if (_apiList == null)
                return;

            BuildGrid();
        }
         

        //private async void ViewItem(string InternalName)
        //{
        //    var item = GetItem(InternalName);
        //    //if(item != null)
        //    //{
        //    //    using (var form = new frmServicesApiTemplateSetDetail(item))
        //    //    {
        //    //        var result = form.ShowDialog(); 
        //    //    }
        //    //}
        //}

        //private TemplateSetListModelItem GetItem(string internalName)
        //{
        //    TemplateSetListModelItem result = null;
        //    foreach (TemplateSetListModelItem item in _apiList.Items)
        //    {
        //        if(item.Name == internalName)
        //        {
        //            result = item;
        //            break;
        //        } 
        //    }
        //    return result;
        //} 

        private async void frmForm_Load(object sender, EventArgs e)
        {
            await LoadItemsAsync();
        }

        private void gridRequestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridRequestList.Columns["select_button_column"].Index)
            {
                string internalName = gridRequestList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string version = gridRequestList.Rows[e.RowIndex].Cells[2].Value.ToString();
                ToggleSelectedItem(internalName, version); 
            }
        }
         
        //private bool IsComItem(string internalName)
        //{
        //    bool result = false;
        //    if (_root.templateSet.Where(x => x.name == internalName).ToList().Count > 0)
        //    {
        //        result = true;
        //    }
        //    return result;

        //}

        private void ToggleSelectedItem(string internalName, string version)
        {
            TemplateSetObject currentSelectedItem = _root.templateSet.Find(x => x.name == internalName && x.version == version);
            GridItem gridItem = _itemList.Where(x => x.InternalName == internalName && x.Version == version).ToList()[0];
            if(currentSelectedItem == null)
            {
                TemplateSetListModelItem apiItem = _apiList.Items.Where(x => x.Name == internalName && x.DisplayVersion == version).ToList()[0];


                TemplateSetObject item = new TemplateSetObject();
                item.name = internalName;
                item.version = apiItem.DisplayVersion;
                item.title = apiItem.Title;
                item.isDisabled = "false";
                _root.templateSet.Add(item);
                gridItem.IsSelected = true;
            }
            else
            { 
                if(currentSelectedItem.isDisabled == "true")
                {
                    gridItem.IsSelected = true;
                    currentSelectedItem.isDisabled = "false";
                }
                else
                {
                    gridItem.IsSelected = false;
                    currentSelectedItem.isDisabled = "true";
                } 
            }
            BuildGrid();
        }
         

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }

    

}
