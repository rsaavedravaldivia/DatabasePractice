using System;
using System.Data;
using System.Data.SQLite;

namespace Main.Libraries
{
    public static class ClientTableHandler
    {




        public static DataTable GetClientDataTablefromSQLite(SQLiteAccess sQLiteAccess)
        {
            sQLiteAccess.connection.Open();
            string commandString = "SELECT * FROM clients";
            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteAccess.connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            sQLiteAccess.connection.Close();
            return dataTable;
        }

        public static void InsertClient(SQLiteAccess sQLiteAccess, Client client)
        {
            sQLiteAccess.connection.Open();
            string commandString = "INSERT INTO clients (FirstName, LastName, Phone, Email, Address) VALUES (@FirstName, @LastName, @Phone, @Email, @Address)";

            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteAccess.connection);


            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@Phone", client.Phone);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Address", client.Address);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                sQLiteAccess.connection.Close();
            }
        }

        public static void DeleteClient(SQLiteAccess sQLiteAccess, int ID)
        {
            sQLiteAccess.connection.Open();
            string commandString = "DELETE FROM clients WHERE ID=@ID";
            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteAccess.connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally { sQLiteAccess.connection.Close(); }
        }
    }
}
