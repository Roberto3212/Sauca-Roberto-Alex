using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;

namespace Proiect_MIP
{
    public class SQLiteHandler
    {
        private static SQLiteHandler instance;
        private SQLiteConnection conn;

        private SQLiteHandler()
        {
        }

        public static SQLiteHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new SQLiteHandler();
            }
            return instance;
        }

        public void ConnectToDb(string path)
        {
            if (conn != null)
                return;

            string connStr = "Data Source=" + path + ";Version=3;";
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }

        public void DisconnectFromDb()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        public List<string> GetAllKeywords()
        {
            List<string> result = new List<string>();

            string sql = "SELECT keyword FROM Keywords";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }

            reader.Close();
            cmd.Dispose();

            return result;
        }

        public void AddKeyword(string k)
        {
            string sql = "INSERT INTO Keywords(keyword) VALUES(@k)";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@k", k);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void DeleteKeyword(string k)
        {
            string sql = "DELETE FROM Keywords WHERE keyword = @k";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@k", k);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
