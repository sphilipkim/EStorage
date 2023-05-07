using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using EStorage.Classes;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms.VisualStyles;

namespace EStorage
{
    public partial class title : Form
    {
        SerialPort port = new SerialPort();
        itemClass i = new itemClass();
        string searchSize = "";
        string searchCategory = "";
        string searchName = "";
        string[] searchItems;
        public title()
        {
            InitializeComponent();
            list_available_ports();
        }

        private void list_available_ports()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox_com.Items.AddRange(ports);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_com.Text != "")
                {
                    port.Close();
                    progressBar_com.Value = 0;
                    label_scanner_status.Text = "No Port";

                    port.PortName = comboBox_com.Text;
                    port.BaudRate = 19200;
                    port.Open();
                    //Event Handler
                    port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    progressBar_com.Value = 100;
                    label_scanner_status.Text = "Ready";

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String text = port.ReadLine();

            if (searchItem(text))
            {
                //label_scanner_status.Text = "Scanned!";
            }
            else
            {
                //label_scanner_status.Text = "Scan Failed!";
            }
        }

        private bool searchItem(string text)
        {
            bool success = false;

            try
            {
                DataTable dt = i.SelectByName(text);
                //If item exists
                if (dt.Rows.Count > 0)
                {
                    string[] st = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                    if (textBox_item_name.InvokeRequired)
                    {
                        Action safeSearch = delegate { searchItem(text); };
                        textBox_item_name.Invoke(safeSearch);
                    }
                    else
                    {
                        i.itemID = Int32.Parse(st[0]);
                        i.itemName = st[1];
                        i.itemCount = Int32.Parse(st[2]);
                        i.itemSize = st[3];
                        i.itemCategory = st[4];

                        displayItem(i);
                        success = true;
                    }
                }
                else //Create item if it doesn't exist
                {
                    i.itemName = text;
                    i.itemCount = 0;

                    string size = "";
                    string[] tokens = text.Split(' ');

                    size = tokens[tokens.Length - 1];

                    if (size.Length > 0)
                    {
                        switch (size.ToLower())
                        {
                            case "l":
                                i.itemSize = "Large";
                                break;
                            case "m":
                                i.itemSize = "Medium";
                                break;
                            case "s":
                                i.itemSize = "Small";
                                break;
                            case "lt":
                                i.itemSize = "Large Tumbler";
                                break;
                            case "mt":
                                i.itemSize = "Medium Tumbler";
                                break;
                            case "st":
                                i.itemSize = "Small Tumbler";
                                break;
                        }

                        if (i.itemSize.Length > 0)
                        {
                            i.InsertNameCountSize(i);
                        }
                        else
                        {
                            i.InsertNameCount(i);
                        }

                    }




                    searchItem(text);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SCAN ERROR: " + ex);
            }


            return success;
        }

        private bool lookUpTable()
        {
            bool success = false;
            try
            {
                DataTable dt = i.SelectNames();
                //If items exists
                if (dt.Rows.Count > 0)
                {
                    string[] st = new string[dt.Rows.Count];
                    for (int i = 0; i < st.Length; i++)
                    {
                        st[i] = dt.Rows[i][0].ToString();
                    }
                    if (textBox_item_name.InvokeRequired)
                    {
                        Action safeSearch = delegate { lookUpTable(); };
                        textBox_item_name.Invoke(safeSearch);
                    }
                    else
                    {
                        displaySearch(st);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LOOKUP ERROR: " + ex);
            }
            return success;
        }

        private void displayItem(itemClass item)
        {
            textBox_item_name.Text = item.itemName;
            textBox_item_count.Text = item.itemCount.ToString();
            comboBox_item_size.Text = item.itemSize;
            comboBox_item_category.Text = item.itemCategory;
        }

        private void displaySearch(string[] names)
        {
            listBox.Items.Clear();
            foreach (string name in names)
            {
                listBox.Items.Add(name);
            }
        }

        private void title_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("************CLOSED************");
            try
            {
                if (comboBox_com.Text != "")
                {
                    port.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXIT ERROR: " + ex);
            }
        }

        private void title_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("************OPENED************");
            lookUpTable();
        }

        private void button_item_update_size_Click(object sender, EventArgs e)
        {

        }

        private void button_item_update_Click(object sender, EventArgs e)
        {
            if (textBox_item_name.Text.Length == 0)
            {
                MessageBox.Show("Please select an item first!");
            }
            else
            {
                //Set itembox items to item
                i.itemName = textBox_item_name.Text;
                i.itemCount = Int32.Parse(textBox_item_count.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                //Debug.Write("**********\n" + i.itemID.ToString() + "\n" + i.itemName + "\n" + i.itemCount.ToString() + "\n" + i.itemSize + "\n" + i.itemCategory + "\n**********");
                if (i.Update(i))
                {
                    MessageBox.Show("Update Success");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }

            }
        }

        private void button_item_add_Click(object sender, EventArgs e)
        {

        }

        private void button_item_remove_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_search_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchSize = comboBox_search_size.Text;
            updateSearch();
        }

        private void comboBox_search_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchCategory = comboBox_search_category.Text;
            updateSearch();
        }

        private void textBox_search_name_TextChanged(object sender, EventArgs e)
        {
            searchName = textBox_search_name.Text;
            updateSearch();
        }

        private void updateSearch()
        {
            DataTable dt = new DataTable();
            if (searchSize.Length <= 0 && searchCategory.Length <= 0)
            {
                try
                {
                    dt = i.SearchByName(searchName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SEARCH ERROR: " + ex);
                }
            }
            else if (searchSize.Length > 0 && searchCategory.Length <= 0)
            {
                try
                {
                    dt = i.SearchByNameSize(searchName, searchSize);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SEARCH ERROR: " + ex);
                }
            }
            else if (searchSize.Length <= 0 && searchCategory.Length > 0)
            {
                try
                {
                    dt = i.SearchByNameCat(searchName, searchCategory);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SEARCH ERROR: " + ex);
                }
            }
            else if (searchSize.Length > 0 && searchCategory.Length > 0)
            {
                try
                {
                    dt = i.SearchByNameSizeCat(searchName, searchSize, searchCategory);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("SEARCH ERROR: " + ex);
                }
            }
            //If items exists
            if (dt.Rows.Count > 0)
            {
                string[] st = new string[dt.Rows.Count];
                for (int i = 0; i < st.Length; i++)
                {
                    st[i] = dt.Rows[i][0].ToString();
                }
                if (listBox.InvokeRequired)
                {
                    Action safeSearch = delegate { updateSearch(); };
                    listBox.Invoke(safeSearch);
                }
                else
                {
                    displaySearch(st);
                }
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            searchItem(listBox.SelectedItem.ToString());
            //MessageBox.Show(listBox.SelectedItem.ToString());
        }
    }
}