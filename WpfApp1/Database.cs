using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SQLitePCL;
using System.IO;

namespace WpfApp1
{

    static public class SQLiteDatabase
    {
        static public SqliteConnection conn;
        static public void MakeDatabase()
        {
            conn = new SqliteConnection($@"Data Source={ Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName }\\database.db");
            if (CheckIfTableExists())
            {
                ReadData();
            }
        }

        static public bool CheckIfTableExists()
        {
            string check = $"SELECT * FROM Data;";
            conn.Open();
            try
            {
                using (SqliteCommand cmd = new SqliteCommand(check, conn))
                {

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows == true)
                        {
                            rdr.Close();
                            return true;
                        }
                        else
                        {
                            rdr.Close();
                            return false;
                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                conn.Close();
                CreateTable();
                return false ;
            }
            conn.Close();
        }

        public static void CheckIfDatabaseExists()
        {
            string dbPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\database.db";

            if (!File.Exists(dbPath))
            {
                CreateTable();
            }

        }
        static public bool CreateTable()
        {
            

            conn.Open();
            string t1 = "CREATE TABLE Data (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(30),ip VARCHAR (30), port VARCHAR(30));";
            SqliteCommand command = new SqliteCommand(t1, conn); ;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception) { return false; }

            return true;

        }

        static public void InsertData()
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            string insert = "";
            insert += $"INSERT INTO Data (name, ip, port) VALUES ('{MainWindow.Names[MainWindow.Names.Count - 1]}','{MainWindow.Addresses[MainWindow.Addresses.Count - 1]}','{MainWindow.Ports[MainWindow.Ports.Count - 1]}' )";
            command.CommandText = insert;
            command.ExecuteNonQuery();
            conn.Close();

        }
        public static void ReadData()
        {
            conn.Open();
            SqliteDataReader reader;
            SqliteCommand command;
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Data";
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MainWindow.Names.Add(Convert.ToString(reader["name"]));
                    MainWindow.Addresses.Add(Convert.ToString(reader["ip"]));
                    MainWindow.Ports.Add(Convert.ToString(reader["port"]));
                }
            }

            conn.Close();
        }
    }
}
public class Services
{
    public int? Id;
    public string Name { get; set; }
    public string Address { get; set; }
    public string Port { get; set; }
    public Services(string name, string IP, string port)
    {
        Name = name;
        Address = IP;
        Port = port;
    }
}
public class Database
{
    public static List<Services> _itemss = new List<Services>();
    static Database()
    {

    }
    static public List<Services> GetItems => _itemss;
}



