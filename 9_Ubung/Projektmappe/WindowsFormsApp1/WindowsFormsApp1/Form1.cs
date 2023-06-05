using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System;

namespace WindowsFormsApp1
{   
    public partial class Form1 : Form
    {
        static string path = "";
        static string strConnection = "";
        static string tableName = "Appointments";
                
        public Form1()
        {
            InitializeComponent();
        }

        static DataSet LoadTable(DataSet ds, string tablename)
        {
            OleDbConnection con = new OleDbConnection(strConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + tablename, con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds, tablename);
            if(ds.HasErrors) { 
                ds.RejectChanges();
                throw new Exception("Error Loading Data");
            } else {
                ds.AcceptChanges();
                adapter.Dispose();
                Console.WriteLine("Loaded Table: " + tablename);
            }
            return ds;
        }

        static void StoreTable(DataSet ds, string tablename)
        {
            OleDbConnection con = new OleDbConnection(strConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + tablename, con);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            cmdBuilder.QuotePrefix = "[";
            cmdBuilder.QuoteSuffix = "]";
            adapter.Update(ds, tablename);
            adapter.Dispose();
            Console.WriteLine("Stored Table: " + tablename);
        }

        static void Print(DataSet ds)
        {
            Console.WriteLine("DataSet {0}", ds.DataSetName);
            Console.WriteLine();
            foreach(DataTable t in ds.Tables)
            {
                Print(t);
                Console.WriteLine();
            }
        }

        static void Print(DataTable t)
        {
            Console.WriteLine("Tabelle {0}:", t.TableName);
            foreach(DataColumn col in t.Columns){
                Console.Write(col.ColumnName + "|");
            }
            Console.WriteLine();
            for (int i=0; i < 40; i++){
                Console.WriteLine("-");
            }
            Console.WriteLine();
            int nrOfCols = t.Columns.Count;
            foreach(DataRow row in t.Rows) {
                for(int i=0; i < nrOfCols; i++){
                    Console.Write(row[i]);
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = LoadTable(ds, tableName);
            DataView dv = ds.Tables[tableName].DefaultView;
            dataGridView1.DataSource = dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //StoreTable();
        }

    }


}
