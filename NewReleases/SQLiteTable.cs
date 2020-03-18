using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace NewReleases
{
    public class SQLiteTable
    {
        SQLiteConnection conn;
        public SQLiteTable()
        {
            conn = new SQLiteConnection("data source = database.db");
            conn.Open();
            SQLiteCommand cmd;
            string createTab = "CREATE TABLE IF NOT EXISTS Favourite (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name VARCHAR (200), Title VARCHAR (200), Genre VARCHAR (100));";
            cmd = conn.CreateCommand();
            cmd.CommandText = createTab;
            cmd.ExecuteNonQuery();
        }

        public void InsertData(string Name, string Title, string Genre)
        {
            //string query = $"INSERT INTO Favourite (Name, Title, Genre, Notes) VALUES (?,?,?,?);";
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Favourite (Name, Title, Genre) VALUES ($eName,$eTitle,$eGenre);", conn);
            cmd.Parameters.Add("$eName", System.Data.DbType.String).Value = Name;
            cmd.Parameters.Add("$eTitle", System.Data.DbType.String).Value = Title;
            cmd.Parameters.Add("$eGenre", System.Data.DbType.String).Value = Genre;
            //cmd = conn.CreateCommand();
            //cmd.CommandText = "INSERT INTO Favourite (Name, Title, Genre, Notes) VALUES (?,?,?,?);";
            cmd.ExecuteNonQuery();
        }

        public List<List<string>> ReadData(List<List<string>> lista)
        {
                SQLiteDataReader read;
                SQLiteCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Favourite";
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string name = read.GetString(1);
                    string title = read.GetString(2);
                    string genre = read.GetString(3);
                    //create a list of a list<string> so that can be accessed by binding in the Favourite Screen
                    lista.Add(new List<string>() { name, title, genre });
                }
                return lista;
        }

        public void DeleteAll()
        {
            string symbol = "%";
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Favourite WHERE Id LIKE $sym;", conn);
            cmd.Parameters.Add("$sym", System.Data.DbType.String).Value = symbol;
            cmd.ExecuteNonQuery();
        }

        public void DeleteEntry(string Album)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Favourite WHERE Title LIKE $art", conn);
            cmd.Parameters.Add("$art", System.Data.DbType.String).Value = Album;
            cmd.ExecuteNonQuery();
        
        }

    }
}
