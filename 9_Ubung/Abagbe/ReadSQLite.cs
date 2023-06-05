using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace ConsoleApp2
{
    class ReadSQLite
    {
        private string connStr;
        private IDbConnection conn = null;
        private string command = null;

        public static void Main()
        {
            ReadSQLite appointmentsDb = new ReadSQLite();
            appointmentsDb.setCommand("Select * from Appointments");
            appointmentsDb.openConnectionReadLines();
        }

        ReadSQLite()
        {
            connStr = "Data Source = C:\\Users\\Flori\\Documents\\Studium\\ZHAW_B_DotNet_Technologien_1\\Übungen\\9_Ubung\\Vorlagen\\app2020.db";
        }

        public void setCommand(string command)
        {
            this.command = command;
        }
        public void openConnectionReadLines()
        {
            try
            {
                conn = new SqliteConnection(this.connStr);
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = this.command;
                IDataReader reader = cmd.ExecuteReader();

                object[] dataRow = new object[reader.FieldCount];

                while (reader.Read())
                {
                    int cols = reader.GetValues(dataRow);
                    for (int i = 0; i < cols; i++)
                    {
                        Console.Write("| {0}", dataRow[i]);
                    }
                    Console.WriteLine("");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
