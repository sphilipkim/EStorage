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

namespace EStorage
{
    public partial class title : Form
    {
        SerialPort port = new SerialPort();
        itemClass i = new itemClass();
        public title()
        {
            InitializeComponent();
            list_available_ports();
        }

        private void button_search_Click(object sender, EventArgs e)
        {

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
                        textBox_item_name.Text = st[1];
                        textBox_item_count.Text = st[2];
                        comboBox_item_size.Text = st[3];
                        comboBox_item_category.Text = st[4];
                        success = true;
                    }
                }
                else //Else make one
                {
                    i.itemName = text;
                    i.itemCount = 0;

                    success = i.InsertNameCount(i);

                    searchItem(text);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SCAN ERROR: " + ex);
            }


            return success;
        }
        private void writeText(String txt)
        {
            /*if (textBox_test.InvokeRequired)
            {
                Action safeWrite = delegate { writeText(txt); };
                textBox_test.Invoke(safeWrite);
            }
            else
            {
                textBox_test.Text = txt;
            }*/
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
        }

        private void button_item_update_size_Click(object sender, EventArgs e)
        {

        }

        private void button_item_update_category_Click(object sender, EventArgs e)
        {

        }

        private void button_item_add_Click(object sender, EventArgs e)
        {

        }

        private void button_item_remove_Click(object sender, EventArgs e)
        {

        }
    }
}