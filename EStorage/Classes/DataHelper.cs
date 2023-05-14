using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Data;

public static class DataHelper
{
    private static string LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E-Storage");
    private static string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E-Storage\\Data");
    private static string DBpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E-Storage\\Data\\StorageData.db");
    private static string conn = "Data Source=" + DBpath + ";Version=3;";

    //Current date for file creation
    private static string today = DateTime.Now.ToString("M-dd-yyyy");

    public static void InitializeLogs()
    {
        //Create E-Storage folder if it doesn't exist
        if (!Directory.Exists(LogPath))
        {
            Directory.CreateDirectory(LogPath);
        }

        //Create E-Storage/Data folder if it doesn't exist
        if (!Directory.Exists(DataPath))
        {
            Directory.CreateDirectory(DataPath);
        }

        //Create file if it doesn't exist
        if (!File.Exists(LogPath + "\\" + today + ".txt"))
        {
            //MessageBox.Show("File Created");
            File.Create(LogPath + "\\" + today + ".txt").Dispose();
        }
    }

    //Creates local DB if it does not exist
    public static void InitializeDB()
    {
        //Create SQLite database if it doesn't exist
        if (!File.Exists(DBpath))
        {
            SQLiteConnection.CreateFile(DBpath);
        }

        using (var db = new SQLiteConnection(conn))
        {
            db.Open();

            //Create table
            string createItemTableQuery = @"
                CREATE TABLE IF NOT EXISTS items (
                    itemID INTEGER PRIMARY KEY AUTOINCREMENT,
                    itemName TEXT NOT NULL,
                    itemCount INTEGER NOT NULL,
                    itemSize TEXT NULL,
                    itemCategory TEXT NULL
                );";

            using (var cmd = new SQLiteCommand(db))
            {
                cmd.CommandText = createItemTableQuery;
                cmd.ExecuteNonQuery();
            }
        }
    }

    //Updates items DB (1.0.3 --> 1.0.4) Removes itemCategory Column
    public static void UpdateDB()
    {
        //Create SQLite database if it doesn't exist
        if (File.Exists(DBpath))
        {
            using (var db = new SQLiteConnection(conn))
            {
                db.Open();

                DataTable table = db.GetSchema("Columns");

                //Check if column itemCategory exists
                if (table.Select("COLUMN_NAME='itemCategory' AND TABLE_NAME='items'").Length > 0)
                {
                    //Create table
                    string createItemTableQuery = @"ALTER TABLE items DROP COLUMN itemCategory";

                    using (var cmd = new SQLiteCommand(db))
                    {
                        cmd.CommandText = createItemTableQuery;
                        cmd.ExecuteNonQuery();
                    }
                }

                db.Close();
            }
        }
    }
}
