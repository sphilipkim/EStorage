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

        //Initialization
        public title()
        {
            InitializeComponent();
            list_available_ports();
        }

        //Show available ports to choose from
        private void list_available_ports()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox_com.Items.AddRange(ports);
        }

        //On changing comboBox, open new port
        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                port.Close();
                progressBar_com.Value = 0;

                port.PortName = comboBox_com.Text;
                port.BaudRate = 19200;
                port.Open();
                //Event Handler
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                progressBar_com.Value = 100;
                label_scanner_status.Text = "Ready";
                addToHistory("Connected to Scanner Port: " + port.PortName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
                addToHistory("Scanner Port Error: " + ex.Message);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String text = port.ReadLine();
            addToHistory("Scanned Barcode: " + text);
            ScanItem(text);
        }

        private bool ScanItem(string text)
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
                        Action safeSearch = delegate { ScanItem(text); };
                        textBox_item_name.Invoke(safeSearch);
                    }
                    else
                    {
                        i.itemID = Int32.Parse(st[0]);
                        i.itemName = st[1];
                        i.itemCount = Int32.Parse(st[2]);
                        i.itemSize = st[3];
                        i.itemCategory = st[4];
                        success = true;
                        addToHistory("Item Found: " + i.itemName);
                        displayItem(i);
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

                    addToHistory("Created New Entry - Name: " + i.itemName + ", Count: " + i.itemCount + ", Size: " + i.itemSize);

                    ScanItem(text);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SCAN ERROR: " + ex);
                addToHistory("Scanning Error: " + ex.Message);
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
                addToHistory("Searching Initialize Error: " + ex.Message);
            }
            return success;
        }

        private void displayItem(itemClass item)
        {
            //Show item info
            textBox_item_name.Text = item.itemName;
            textBox_item_count.Text = item.itemCount.ToString();
            comboBox_item_size.Text = item.itemSize;
            comboBox_item_category.Text = item.itemCategory;

            //Enable buttons and boxes
            comboBox_item_size.Enabled = true;
            comboBox_item_category.Enabled = true;
            button_item_update.Enabled = true;
            textBox_add_sub.Enabled = true;
            button_item_add.Enabled = true;
            button_item_remove.Enabled = true;
        }

        private void displaySearch(string[] names)
        {
            listBox_search.Items.Clear();
            foreach (string name in names)
            {
                listBox_search.Items.Add(name);
            }
        }

        private void title_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("************CLOSED************");
            try
            {
                addToHistory("Application Closed");

                if (comboBox_com.Text != "")
                {
                    port.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXIT ERROR: " + ex);
                addToHistory("Closing Error: " + ex.Message);
            }
        }

        private void title_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("************OPENED************");
            lookUpTable();
            addToHistory("Application Opened");
        }

        private void button_item_update_Click(object sender, EventArgs e)
        {
            if (textBox_item_name.Text.Length == 0)
            {
                MessageBox.Show("Please select an item first!");
            }
            else
            {
                //Set item's previous settings
                string prevSize = i.itemSize;
                string prevCat = i.itemCategory;

                //Set itembox items to item
                i.itemName = textBox_item_name.Text;
                i.itemCount = Int32.Parse(textBox_item_count.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                //Debug.Write("**********\n" + i.itemID.ToString() + "\n" + i.itemName + "\n" + i.itemCount.ToString() + "\n" + i.itemSize + "\n" + i.itemCategory + "\n**********");
                if (i.Update(i))
                {
                    addToHistory("Updated Item: " + i.itemName + " - Size: " + (!(prevSize.Equals(i.itemSize)) ? prevSize + " --> " + i.itemSize : i.itemSize) + ", Category: " + (!(prevCat.Equals(i.itemCategory)) ? prevCat + " --> " + i.itemCategory : i.itemCategory));
                }
                else
                {
                    addToHistory("Data Update Error: unable to update data for item " + i.itemName);
                }

            }
        }

        private void button_item_add_Click(object sender, EventArgs e)
        {
            try
            {
                //Set item's previous settings
                int prevCount = i.itemCount;

                //Set itembox items to item
                i.itemName = textBox_item_name.Text;
                i.itemCount += Int32.Parse(textBox_add_sub.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                if (i.Update(i))
                {
                    addToHistory("Updated Item: " + i.itemName + " - Amount: +" + textBox_add_sub.Text);
                    textBox_add_sub.Text = "";
                }
                else
                {
                    addToHistory("Data Update Error: unable to update data for item " + i.itemName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ADD ERROR: " + ex);
                addToHistory("Add Error: Unable to add - " + ex.Message);
            }

            //Refresh
            displayItem(i);
        }

        private void button_item_remove_Click(object sender, EventArgs e)
        {
            try
            {
                //Set item's previous settings
                int prevCount = i.itemCount;

                //Set itembox items to item
                i.itemName = textBox_item_name.Text;
                i.itemCount -= Int32.Parse(textBox_add_sub.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                if (i.Update(i))
                {
                    addToHistory("Updated Item: " + i.itemName + " - Amount: -" + textBox_add_sub.Text);
                    textBox_add_sub.Text = "";
                }
                else
                {
                    addToHistory("Data Update Error: unable to update data for item " + i.itemName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SUB ERROR: " + ex);
                addToHistory("Subtract Error: Unable to add - " + ex.Message);
            }

            //Refresh
            displayItem(i);
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
                    Debug.WriteLine("SEARCH ERROR(n): " + ex);
                    addToHistory("Search(n) Error: " + ex.Message);
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
                    Debug.WriteLine("SEARCH ERROR(n,s): " + ex);
                    addToHistory("Search(n,s) Error: " + ex.Message);
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
                    Debug.WriteLine("SEARCH ERROR(n,c): " + ex);
                    addToHistory("Search(n,c) Error: " + ex.Message);
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
                    Debug.WriteLine("SEARCH ERROR(n,s,c): " + ex);
                    addToHistory("Search(n,s,c) Error: " + ex.Message);
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
                if (listBox_search.InvokeRequired)
                {
                    Action safeSearch = delegate { updateSearch(); };
                    listBox_search.Invoke(safeSearch);
                }
                else
                {
                    displaySearch(st);
                }
            }
        }

        private void addToHistory(string text)
        {
            string hist = DateTime.Now.ToString("H:mm:ss");
            string today = DateTime.Now.ToString("M-dd-yyyy");
            hist += ": " + text;

            //Create log file
            try
            {
                //Check if it exists
                if (!File.Exists("C:\\Users\\Philip\\Desktop\\Storage Proj\\EStorage\\EStorage\\Logs\\" + today + ".txt"))
                {
                    MessageBox.Show("File Created");
                    File.Create("C:\\Users\\Philip\\Desktop\\Storage Proj\\EStorage\\EStorage\\Logs\\" + today + ".txt");
                }

                using (StreamWriter sw = File.AppendText("C:\\Users\\Philip\\Desktop\\Storage Proj\\EStorage\\EStorage\\Logs\\" + today + ".txt"))
                {
                    sw.WriteLine(hist);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("FILE CREATE ERROR: " + ex);
                addToHistory("Log File Create/Write Error: " + ex.Message);
            }

            if (listBox_history.InvokeRequired)
            {
                Action safeSearch = delegate { addToHistory(text); };
                listBox_history.Invoke(safeSearch);
            }
            else
            {
                listBox_history.Items.Add(hist);
            }

            //Keeps scroll at the bottom
            listBox_history.TopIndex = listBox_history.Items.Count - 1;
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            ScanItem(listBox_search.SelectedItem.ToString());
            //MessageBox.Show(listBox.SelectedItem.ToString());
        }

        private void button_item_admin_Click(object sender, EventArgs e)
        {
            if (i.itemName != null)
            {
                button_remove_item.Enabled = !button_remove_item.Enabled;
                textBox_item_name.Enabled = !textBox_item_name.Enabled;
                textBox_item_name.ReadOnly = !textBox_item_name.ReadOnly;
                textBox_item_count.Enabled = !textBox_item_count.Enabled;
                textBox_item_count.ReadOnly = !textBox_item_count.ReadOnly;
                button_item_admin.Text = (button_remove_item.Enabled == true) ? "Admin ON!" : "Admin Mode";

                addToHistory("Toggled Admin Mode " + ((button_remove_item.Enabled == true) ? "ON" : "OFF"));
            }
        }

        private void button_remove_item_Click(object sender, EventArgs e)
        {

        }
    }
}