using System;
using System.Data;
using System.Data.OleDb;

namespace ConsoleApp2
{
    class ReadAccess
    {
        private string connStr;
        private IDbConnection conn = null;
        private string command = null;

        public static void Main()
        {
            ReadAccess appointmentsDb = new ReadAccess();
            appointmentsDb.setCommand("Select * from Appointments");
            appointmentsDb.openConnectionReadLines();
        }

        ReadAccess()
        {
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\Flori\\Documents\\Studium\\ZHAW_B_DotNet_Technologien_1\\Übungen\\9_Ubung\\Vorlagen\\app2020.accdb;";
        }
        
        public void setCommand(string command)
        {
            this.command = command;
        }
        public void openConnectionReadLines()
        {
            try
            {
                conn = new OleDbConnection(this.connStr);
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = this.command;
                IDataReader reader = cmd.ExecuteReader();

                object[] dataRow = new object[reader.FieldCount];

                while (reader.Read()) {
                    int cols = reader.GetValues(dataRow);
                    for (int i = 0; i < cols; i++)
                    {
                        Console.Write("| {0}", dataRow[i]);
                    }
                    Console.WriteLine("");
                }

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                try {
                    if (conn != null) {
                        conn.Close();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
