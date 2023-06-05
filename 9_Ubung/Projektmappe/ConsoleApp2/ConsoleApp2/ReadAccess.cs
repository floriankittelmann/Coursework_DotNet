using System;
using System.Data;
using System.Data.OleDb;

namespace ConsoleApp2
{
    class ReadAccess
    {
        public static void Main()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\Flori\\Documents\\Studium\\ZHAW_B_DotNet_Technologien_1\\Übungen\\9_Ubung\\Vorlagen\\app2020accdb;";
            IDbConnection conn = null;
            try {
                conn = new OleDbConnection(connStr);
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = ""; // TODO:
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

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                try {
                    if(conn != null) { 
                        conn.Close();
                    }
                } catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }
        }   

    }
}
