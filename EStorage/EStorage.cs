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

namespace EStorage
{
    public partial class title : Form
    {
        SerialPort port = new SerialPort();
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

                    port.PortName = comboBox_com.Text;
                    port.BaudRate = 19200;
                    port.Open();
                    //Event Handler
                    port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    progressBar_com.Value = 100;

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
            writeText(text);
        }

        private void writeText(String txt)
        {
            if (textBox_test.InvokeRequired)
            {
                Action safeWrite = delegate { writeText(txt); };
                textBox_test.Invoke(safeWrite);
            }
            else
            {
                textBox_test.Text = txt;
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
        }
    }
}