using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System;

namespace WindowsFormsApp1
{   
    public partial class Form1 : Form
    {
        static string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\Flori\\Documents\\Studium\\ZHAW_B_DotNet_Technologien_1\\Übungen\\9_Ubung\\Vorlagen\\app2020.accdb;";
        static string tableName = "Appointments";
        private DataSet ds;
        private DataView dv;

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

        static void StoreTable(DataSet dsLocal, string tablename)
        {
            OleDbConnection con = new OleDbConnection(strConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + tablename, con);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            cmdBuilder.QuotePrefix = "[";
            cmdBuilder.QuoteSuffix = "]";
            adapter.Update(dsLocal, tablename);
            adapter.Dispose();
            Console.WriteLine("Stored Table: " + tablename);
        }

        static void Print(DataSet dsLocal)
        {
            Console.WriteLine("DataSet {0}", dsLocal.DataSetName);
            Console.WriteLine();
            foreach(DataTable t in dsLocal.Tables)
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
            this.ds = new DataSet();
            this.ds = LoadTable(this.ds, tableName);
            this.dv = this.ds.Tables[tableName].DefaultView;
            dataGridView1.DataSource = this.dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if(this.ds != null) { 
                StoreTable(this.ds, tableName);
                Console.WriteLine("DataSet saved successfully");
            } else {
                Console.WriteLine("DataSet not loaded yet");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime theDate = dateTimePicker1.Value;
            string dateDB = theDate.ToString("MM.dd.yyyy");
            string filter = "Start > #" + dateDB + " 00:00:00# and Start < #" + dateDB + " 23:59:59#";
            this.dv.RowFilter = filter;
        }
    }


}
