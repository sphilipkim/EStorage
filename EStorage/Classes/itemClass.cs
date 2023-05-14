using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EStorage.Classes
{
    internal class itemClass
    {
        //Variables
        public int itemID { get; set; }
        public string itemName { get; set; }
        public int itemCount { get; set; }
        public string itemSize { get; set; }

        //SQL connection

        private static string DBpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E-Storage\\Data\\StorageData.db");
        private static string connString = "Data Source=" + DBpath + ";Version=3;";

        //Select all items
        public DataTable Select()
        {
            SQLiteConnection connect = new SQLiteConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM items";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);

                connect.Open();
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB SELECT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return dt;
        }

        //Select all items, show only names (search list initialization)
        public DataTable SelectNames()
        {
            SQLiteConnection connect = new SQLiteConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items ORDER BY itemName ASC";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);

                connect.Open();
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB SELECT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return dt;
        }

        //Search by name
        public DataTable SearchByName(string search)
        {
            SQLiteConnection connect = new SQLiteConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemName LIKE @search ORDER BY itemName ASC";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);

                connect.Open();
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB SELECT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return dt;
        }

        //Search by name and size
        public DataTable SearchByNameSize(string search, string size)
        {
            SQLiteConnection connect = new SQLiteConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemSize=@size AND itemName LIKE @search ORDER BY itemName ASC";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);

                connect.Open();
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB SELECT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return dt;
        }

        //Select by Name (Scan + Search double click)
        public DataTable SelectByName(string name)
        {
            SQLiteConnection connect = new SQLiteConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM items WHERE itemName=@itemName";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", name);

                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);

                connect.Open();
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB SELECT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return dt;
        }

        //Inserting item (Add new item)
        public bool Insert(itemClass i)
        {
            bool success = false;

            SQLiteConnection connect = new SQLiteConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount, itemSize) VALUES (@itemName, @itemCount, @itemSize)";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);
                cmd.Parameters.AddWithValue("@itemSize", i.itemSize);

                connect.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB INSERT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }


            return success;
        }

        //Insert name and count (New item on Scan)
        public bool InsertNameCount(itemClass i)
        {
            bool success = false;

            SQLiteConnection connect = new SQLiteConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount) VALUES (@itemName, @itemCount)";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);

                connect.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB INSERT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }


            return success;
        }

        //Insert name, count, and size (New item on Scan)
        public bool InsertNameCountSize(itemClass i)
        {
            bool success = false;

            SQLiteConnection connect = new SQLiteConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount, itemSize) VALUES (@itemName, @itemCount, @itemSize)";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);
                cmd.Parameters.AddWithValue("@itemSize", i.itemSize);

                connect.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB INSERT ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }


            return success;
        }

        //Update item
        public bool Update(itemClass i)
        {
            bool success = false;

            SQLiteConnection connect = new SQLiteConnection(connString);

            try
            {
                string sql = "UPDATE items SET itemName=@itemName, itemCount=@itemCount, itemSize=@itemSize WHERE itemID=@itemID";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemID", i.itemID);
                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);
                cmd.Parameters.AddWithValue("@itemSize", i.itemSize);

                connect.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB UPDATE ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return success;
        }

        //Delete item
        public bool Delete(itemClass i)
        {
            bool success = false;

            SQLiteConnection connect = new SQLiteConnection(connString);

            try
            {
                string sql = "DELETE FROM items WHERE itemName=@itemName";
                SQLiteCommand cmd = new SQLiteCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", i.itemName);

                connect.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB DELETE ERROR: " + ex);
            }
            finally
            {
                connect.Close();
            }

            return success;
        }

    }
}
