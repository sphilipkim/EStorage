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

        //Select, show only names
        public DataTable SelectNames()
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items";
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

        //Select Search by name
        public DataTable SearchByName(string search)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemName LIKE '%' + @search + '%'";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@search", search);

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

        //Select Search by name and size
        public DataTable SearchByNameSize(string search, string size)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemSize=@size AND itemName LIKE '%' + @search + '%'";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@search", search);

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

        //Select Search by name and category
        public DataTable SearchByNameCat(string search, string category)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemCategory=@category AND itemName LIKE '%' + @search + '%'";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@search", search);

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

        //Select Search by name, size, and category
        public DataTable SearchByNameSizeCat(string search, string size, string catagory)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT itemName FROM items WHERE itemSize=@size AND itemCategory=@category AND itemName LIKE '%' + @search + '%'";
                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@category", catagory);
                cmd.Parameters.AddWithValue("@search", search);

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

        public bool InsertNameCountSize(itemClass i)
        {
            bool success = false;

            SqlConnection connect = new SqlConnection(connString);

            try
            {
                string sql = "INSERT INTO items (itemName, itemCount, itemSize) VALUES (@itemName, @itemCount, @itemSize)";
                SqlCommand cmd = new SqlCommand(sql, connect);

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

        //Delete Data
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
