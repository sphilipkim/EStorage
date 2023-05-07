using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStorage.Classes
{
    internal class itemClass
    {
        public int itemID { get; set; }

        public string itemName { get; set; }

        public int itemCount { get; set; }

        public string itemSize { get; set; }

        public string itemCategory { get; set; }

        static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        //Selecting Data
        public DataTable Select()
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM items";
                SqlCommand cmd = new SqlCommand(sql, connect);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);

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

        //Select by Name
        public DataTable SelectByName(string name)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM items WHERE itemName=@itemName";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", name);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);

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

        //Inserting Data
        public bool Insert(itemClass i)
        {
            bool success = false;

            SqlConnection connect = new SqlConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount, itemSize, itemCategory) VALUES (@itemName, @itemCount, @itemSize, @itemCategory)";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);
                cmd.Parameters.AddWithValue("@itemSize", i.itemSize);
                cmd.Parameters.AddWithValue("@itemCategory", i.itemCategory);

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

        //Insert name and count
        public bool InsertNameCount(itemClass i)
        {
            bool success = false;

            SqlConnection connect = new SqlConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount) VALUES (@itemName, @itemCount)";
                SqlCommand cmd = new SqlCommand(sql, connect);

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

        //Update Data
        public bool Update(itemClass i)
        {
            bool success = false;

            SqlConnection connect = new SqlConnection(connString);

            try
            {
                string sql = "UPDATE items SET itemName=@itemName, itemCount=@itemCount, itemSize=@itemSize, itemCategory=@itemCategory WHERE itemID=@itemID";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemID", i.itemID);
                cmd.Parameters.AddWithValue("@itemName", i.itemName);
                cmd.Parameters.AddWithValue("@itemCount", i.itemCount);
                cmd.Parameters.AddWithValue("@itemSize", i.itemSize);
                cmd.Parameters.AddWithValue("@itemCategory", i.itemCategory);

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

        public bool Delete(itemClass i)
        {
            bool success = false;

            SqlConnection connect = new SqlConnection(connString);

            try
            {
                string sql = "DELETE FROM items WHERE itemID=@itemID";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@itemID", i.itemID);

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
