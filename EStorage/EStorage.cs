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
using System.IO;

namespace EStorage
{
    public partial class title : Form
    {
        //Variables
        SerialPort port = new SerialPort();
        itemClass i = new itemClass();
        string searchSize = "";
        string searchCategory = "";
        string searchName = "";
        string[] searchItems;
        bool isAdmin = false;

        //Initialization
        public title()
        {
            InitializeComponent();
            list_available_ports();
        }

        //On UI load
        private void title_Load(object sender, EventArgs e)
        {
            //Debug line for easier readability
            Debug.WriteLine("************OPENED************");
            //Initializes search list alphabetically
            InitializeSearchList();
            //Log opening
            addToHistory("Application Opened");
        }

        //Show available ports to choose from
        private void list_available_ports()
        {
            String[] ports = SerialPort.GetPortNames();
            //Add ports to comboBox
            comboBox_com.Items.AddRange(ports);
        }

        //On changing comboBox, open new port
        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Close previous port
                port.Close();
                progressBar_com.Value = 0;

                //Set new port
                port.PortName = comboBox_com.Text;
                port.BaudRate = 19200;
                port.Open();

                //Port Event Handler
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                progressBar_com.Value = 100;
                label_scanner_status.Text = "Ready";

                //Log
                addToHistory("Connected to Scanner Port: " + port.PortName);
            }
            catch (Exception ex)
            {
                //Debug and log
                Debug.WriteLine("ERROR: " + ex);
                addToHistory("Scanner Port Error: " + ex.Message);
            }
        }

        //On Scanner Read
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String text = port.ReadLine();
            addToHistory("Scanned Barcode: " + text);
            //Search for item
            SearchItemByName(text);
        }

        //Select item from searchBox
        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            SearchItemByName(listBox_search.SelectedItem.ToString());
        }

        //Search the database by item name
        private bool SearchItemByName(string text)
        {
            //Return variable
            bool success = false;

            //Try catch
            try
            {
                //Data table
                DataTable dt = i.SelectByName(text);
                //If item exists
                if (dt.Rows.Count > 0)
                {
                    //String array converted from data table
                    string[] st = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();

                    //If UI needs thread invoke
                    if (textBox_item_name.InvokeRequired)
                    {
                        //Delegate and invoke
                        Action safeSearch = delegate { SearchItemByName(text); };
                        textBox_item_name.Invoke(safeSearch);
                    }
                    else
                    {
                        //Set item data from data table
                        i.itemID = Int32.Parse(st[0]);
                        i.itemName = st[1];
                        i.itemCount = Int32.Parse(st[2]);
                        i.itemSize = st[3];
                        i.itemCategory = st[4];
                        success = true;
                        //Log item found
                        addToHistory("Item Found: " + i.itemName);
                        //Update item group
                        displayItem(i);
                    }
                }
                else //Create item if it doesn't exist
                {
                    //Set name and default count at 0
                    i.itemName = text;
                    i.itemCount = 0;

                    //Set Size based on Suffix
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

                        //If size set, insert with size, otherwise insert without size
                        if (i.itemSize.Length > 0)
                        {
                            i.InsertNameCountSize(i);
                        }
                        else
                        {
                            i.InsertNameCount(i);
                        }

                    }

                    //Log insert
                    addToHistory("Created New Entry - Name: " + i.itemName + ", Count: " + i.itemCount + ", Size: " + i.itemSize);

                    //If UI needs thread invoke
                    if (textBox_item_name.InvokeRequired)
                    {
                        //Delegate and invoke
                        Action safeSearch = delegate { SearchItemByName(text); };
                        textBox_item_name.Invoke(safeSearch);
                    }
                    else
                    {
                        //Refresh UI
                        displayItem(i);
                    }

                }
            }
            catch (Exception ex)
            {
                //Debug and Log error
                Debug.WriteLine("SCAN ERROR: " + ex);
                addToHistory("Scanning Error: " + ex.Message);
            }

            //Return
            return success;
        }

        //Initialize Search Table
        private bool InitializeSearchList()
        {
            //Return variable
            bool success = false;

            //Try Catch
            try
            {
                //Get table of only names
                DataTable dt = i.SelectNames();
                //If items exists
                if (dt.Rows.Count > 0)
                {
                    //Data table entries into string array
                    string[] st = new string[dt.Rows.Count];
                    for (int i = 0; i < st.Length; i++)
                    {
                        st[i] = dt.Rows[i][0].ToString();
                    }

                    //If UI needs Invoke
                    if (listBox_search.InvokeRequired)
                    {
                        Action safeSearch = delegate { InitializeSearchList(); };
                        listBox_search.Invoke(safeSearch);
                    }
                    else
                    {
                        //Update search list
                        displaySearch(st);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Debug and Log
                Debug.WriteLine("LOOKUP ERROR: " + ex);
                addToHistory("Searching Initialize Error: " + ex.Message);
            }

            //Return
            return success;
        }

        //Update item info
        private void button_item_update_Click(object sender, EventArgs e)
        {
            //Check if item exists
            if (i.itemName.Length == 0)
            {
                MessageBox.Show("Please select an item first!");
            }
            else
            {
                //Store item's previous settings for Log
                string prevSize = i.itemSize;
                string prevCat = i.itemCategory;

                //Set new item values
                i.itemName = textBox_item_name.Text;
                i.itemCount = Int32.Parse(textBox_item_count.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                //Debug.Write("**********\n" + i.itemID.ToString() + "\n" + i.itemName + "\n" + i.itemCount.ToString() + "\n" + i.itemSize + "\n" + i.itemCategory + "\n**********");

                //Update table and Log results
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

        //Add count to selected item
        private void button_item_add_Click(object sender, EventArgs e)
        {
            try
            {
                //Set new item values
                i.itemName = textBox_item_name.Text;
                i.itemCount += Int32.Parse(textBox_add_sub.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                //Update table and Log results
                if (i.Update(i))
                {
                    addToHistory("Updated Item: " + i.itemName + " - Amount: +" + textBox_add_sub.Text);
                    //Clear add/sub textbox
                    textBox_add_sub.Text = "";
                }
                else
                {
                    addToHistory("Data Update Error: unable to update data for item " + i.itemName);
                }
            }
            catch (Exception ex)
            {
                //Debug and Log Error
                Debug.WriteLine("ADD ERROR: " + ex);
                addToHistory("Add Error: Unable to add - " + ex.Message);
            }

            //Refresh
            displayItem(i);
        }

        //Subtract count to selected item
        private void button_item_remove_Click(object sender, EventArgs e)
        {
            try
            {
                //Set new item values
                i.itemName = textBox_item_name.Text;
                i.itemCount -= Int32.Parse(textBox_add_sub.Text);
                i.itemSize = comboBox_item_size.Text;
                i.itemCategory = comboBox_item_category.Text;

                //Update table and Log results
                if (i.Update(i))
                {
                    addToHistory("Updated Item: " + i.itemName + " - Amount: -" + textBox_add_sub.Text);
                    //Clear add/sub textbox
                    textBox_add_sub.Text = "";
                }
                else
                {
                    addToHistory("Data Update Error: unable to update data for item " + i.itemName);
                }
            }
            catch (Exception ex)
            {
                //Debug and Log Error
                Debug.WriteLine("SUB ERROR: " + ex);
                addToHistory("Subtract Error: Unable to add - " + ex.Message);
            }

            //Refresh
            displayItem(i);
        }

        //Update searchSize on search query
        private void comboBox_search_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchSize = comboBox_search_size.Text;
            updateSearch();
        }

        //Update searchCategory on search query
        private void comboBox_search_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchCategory = comboBox_search_category.Text;
            updateSearch();
        }

        //Update name on search query
        private void textBox_search_name_TextChanged(object sender, EventArgs e)
        {
            searchName = textBox_search_name.Text;
            updateSearch();
        }

        //Update the search list depending on query tags
        private void updateSearch()
        {
            //Data table to dump info into
            DataTable dt = new DataTable();

            //Only name
            if (searchSize.Length <= 0 && searchCategory.Length <= 0)
            {
                //Try Catch
                try
                {
                    //Query
                    dt = i.SearchByName(searchName);
                    Debug.WriteLine(dt.ToString());
                }
                catch (Exception ex)
                {
                    //Debug and Log Error
                    Debug.WriteLine("SEARCH ERROR(n): " + ex);
                    addToHistory("Search(n) Error: " + ex.Message);
                }
            }
            //Name and Size
            else if (searchSize.Length > 0 && searchCategory.Length <= 0)
            {
                //Try Catch
                try
                {
                    //Query
                    dt = i.SearchByNameSize(searchName, searchSize);
                }
                catch (Exception ex)
                {
                    //Debug and Log Error
                    Debug.WriteLine("SEARCH ERROR(n,s): " + ex);
                    addToHistory("Search(n,s) Error: " + ex.Message);
                }
            }
            //Name and Category
            else if (searchSize.Length <= 0 && searchCategory.Length > 0)
            {
                //Try Catch
                try
                {
                    //Query
                    dt = i.SearchByNameCat(searchName, searchCategory);
                }
                catch (Exception ex)
                {
                    //Debug and Log Error
                    Debug.WriteLine("SEARCH ERROR(n,c): " + ex);
                    addToHistory("Search(n,c) Error: " + ex.Message);
                }
            }
            //Name, Size, and Category
            else if (searchSize.Length > 0 && searchCategory.Length > 0)
            {
                //Try Catch
                try
                {
                    //Query
                    dt = i.SearchByNameSizeCat(searchName, searchSize, searchCategory);
                }
                catch (Exception ex)
                {
                    //Debug and Log Error
                    Debug.WriteLine("SEARCH ERROR(n,s,c): " + ex);
                    addToHistory("Search(n,s,c) Error: " + ex.Message);
                }
            }

            //If items exists
            //Data table into String array
            string[] st = new string[dt.Rows.Count];
            for (int i = 0; i < st.Length; i++)
            {
                st[i] = dt.Rows[i][0].ToString();
                Debug.WriteLine(st[i]);
            }

            //If UI requires Invoke
            if (listBox_search.InvokeRequired)
            {
                Action safeSearch = delegate { updateSearch(); };
                listBox_search.Invoke(safeSearch);
            }
            else
            {
                //Refresh Search UI
                displaySearch(st);
            }
        }

        //Add text to history list and Log file
        private void addToHistory(string text)
        {
            //Current time
            string hist = DateTime.Now.ToString("H:mm:ss");
            //Current date for logging
            string today = DateTime.Now.ToString("M-dd-yyyy");

            //Concat time and log text
            hist += ": " + text;

            //Try Catch
            try
            {
                //AppdataPath
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E-Storage");
                Debug.WriteLine(path);

                //Concatenate to the Log file
                using (StreamWriter sw = File.AppendText(path + "\\" + today + ".txt"))
                {
                    sw.WriteLine(hist);
                }

            }
            catch (Exception ex)
            {
                //Debug and Log Error
                Debug.WriteLine("FILE CREATE ERROR: " + ex);
                addToHistory("Log File Create/Write Error: " + ex.Message);
            }

            

            //If UI requires Invoke
            if (listBox_history.InvokeRequired)
            {
                Action safeSearch = delegate { addToHistory(text); };
                listBox_history.Invoke(safeSearch);
            }
            else
            {
                //Add history
                listBox_history.Items.Add(hist);
                //Keeps scroll at the bottom
                listBox_history.TopIndex = listBox_history.Items.Count - 1;
            }
        }

        //Toggle Admin Mode
        private void button_item_admin_Click(object sender, EventArgs e)
        {
            if (isAdmin == false)
            {
                button_remove_item.Enabled = true;
                button_add_item.Enabled = true;
                textBox_item_name.ReadOnly = false;
                textBox_item_count.ReadOnly = false;
                comboBox_item_size.Enabled = true;
                comboBox_item_category.Enabled = true;
                button_item_admin.Text = "Admin ON!";

                isAdmin = true;

                addToHistory("Toggled Admin Mode ON");
            }
            else
            {
                button_remove_item.Enabled = false;
                button_add_item.Enabled = false;
                textBox_item_name.ReadOnly = true;
                textBox_item_count.ReadOnly = true;
                button_item_admin.Text = "Admin Mode";

                isAdmin = false;

                addToHistory("Toggled Admin Mode OFF");
            }

        }

        //Remove item using Admin Mode
        private void button_remove_item_Click(object sender, EventArgs e)
        {
            //Set itembox items to item
            i.itemName = textBox_item_name.Text;

            //Check item does exist
            if (i.SelectByName(i.itemName).Rows.Count <= 0)
            {
                //Throw error window and Log
                MessageBox.Show("This item doesn't exists!");
                addToHistory("Removing Item Error: " + i.itemName + " doesn't exist.");
                return;
            }

            //Delete and Log results
            if (i.Delete(i))
            {
                addToHistory("Removed item: " + i.itemName);
                //Update search screen to reflect
                updateSearch();
            }
            else
            {
                addToHistory("Delete Data Error: Item could not be deleted from the database.");
            }
        }

        //Add new item using Admin Mode
        private void button_add_item_Click(object sender, EventArgs e)
        {
            //Set itembox items to item
            i.itemName = textBox_item_name.Text;
            i.itemCount = Int32.Parse(textBox_item_count.Text);
            i.itemSize = comboBox_item_size.Text;
            i.itemCategory = comboBox_item_category.Text;

            //Check item doesn't exist
            if (i.SelectByName(i.itemName).Rows.Count > 0)
            {
                //Throw error window and Log
                MessageBox.Show("This item already exists!");
                addToHistory("Adding Item Error: " + i.itemName + " already exists.");
                return;
            }

            //Insert item and Log results
            if (i.Insert(i))
            {
                addToHistory("Added new item: " + i.itemName + ", Amount: " + i.itemCount + ", Size: " + i.itemSize + ", Category" + i.itemCategory);
                //Update search screen to reflect
                updateSearch();
            }
            else
            {
                addToHistory("Insert Data Error: Item could not be inserted into the database.");
            }

        }

        //Updates UI elements (item group)
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

        //Updates UI elements (search list)
        private void displaySearch(string[] names)
        {
            //Clear and reinsert items
            listBox_search.Items.Clear();
            if (names.Length > 0)
            {
                foreach (string name in names)
                {
                    listBox_search.Items.Add(name);
                }
            }
        }

        //On Application Exit
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
    }
}