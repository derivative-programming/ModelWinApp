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
    public partial class FrmAddFilter : Form
    {
        string _name, _parent;
        public FrmAddFilter(string name, string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportParam==null)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportParam = new List<reportParam>();
            }
            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportParam.Add(new reportParam {name = txtName.Text });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Filter created successfully");
            ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setFiltersList();
            this.Close();
        }
    }
}
