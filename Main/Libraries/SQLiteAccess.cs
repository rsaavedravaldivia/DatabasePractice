

using System;
using System.Data.SQLite;
using System.IO;

namespace Main.Libraries
{

    public class SQLiteAccess
    {
        private string connectionString;
        public SQLiteConnection connection;


        public SQLiteAccess()
        {
            connectionString = @"Data Source=" + GetDatabasePath() + ";Version=3;";
            connection = new SQLiteConnection(connectionString);
            Console.WriteLine("Connected");
        }

        private string GetDatabasePath()
        {
            // Get the base directory of the current application domain
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Combine the base directory with the "Data" folder and the filename "Database.db"
            string databasePath = Path.Combine(baseDirectory, "Data", "sqliteDatabase.db");
            return databasePath;
        }





    }
}
