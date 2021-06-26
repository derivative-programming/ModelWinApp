using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmAddDbObjectImportSqlServer : Form
    {
        public frmAddDbObjectImportSqlServer()
        {
            InitializeComponent();
        }
         

        private void frmDbObject_Load(object sender, EventArgs e)
        { 

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string lastJson = string.Empty;
            this.UseWaitCursor = true;
            Application.DoEvents();
            try
            {

                String str = rtbConnectionString.Text.Trim();

                List<ObjectMap> foundObjects = new List<ObjectMap>();
                using (SqlConnection cnn = new SqlConnection(str))
                using (SqlCommand cmd = new SqlCommand(System.IO.File.ReadAllText("DBObjectImportSqlServer.txt"), cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows) 
                        {
                            while (rdr.Read())
                            {
                                string dbObjJson = rdr.GetString(0);
                                lastJson = dbObjJson;
                                Models.ObjectMap dbObj = new ObjectMap();

                                dbObj = JsonConvert.DeserializeObject<ObjectMap>(dbObjJson.TrimEnd(','));
                                foundObjects.Add(dbObj);
                            }
                        }
                    }
                }
                for (int i = 0; i < foundObjects.Count; i++)
                {
                    if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == foundObjects[i].name).ToList().Count == 0)
                    { 
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Add(foundObjects[i]);
                    }

                }
                ((Form1)Application.OpenForms["Form1"]).PopulateTree();
                MessageBox.Show("Import Completed");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error during import");
            }
            this.UseWaitCursor = false;
            this.Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {

                String str = rtbConnectionString.Text.Trim();

                String query = "select * from data";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                DataSet ds = new DataSet();

                MessageBox.Show("Connection Succeeded!");

                con.Close();

            }
            catch(System.Exception)
            {
                MessageBox.Show("Connection Failed");

            }
        }
    }
}
