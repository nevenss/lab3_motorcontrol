using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Lab3MC : Form
    {
        string serialDataString = "";
        int mode;
        int speed;

        public Lab3MC()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;
            bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                serialDataString = serialDataString + newByte.ToString() + ", ";
                bytesToRead = serialPort1.BytesToRead;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                button1.Text = "Connect";
                serialPort1.Close();
            }
            else
            {
                serialPort1.PortName = comboBoxCOMPorts.Text;
                serialPort1.Open();
                button1.Text = "Disconnect";
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            speed = trackBarSpeed.Value;
            writeToBoard();
        }

        private void writeToBoard()
        {
            if (speed < 59000)
            {
                mode = 1;
            }
            else if (speed > 61000)
            {
                mode = 2;
                speed = 120000 - speed;
            }
            else mode = 0;
            
            byte[] buffer = new byte[5];
            byte overload = 0;
            byte upper = (byte)(speed >> 8);
            byte lower = (byte)(speed & 0xFF);
            if (upper == 255) overload = 1;
            if (lower == 255)
            {
                if (upper == 255) overload = 3;
                else overload = 2;
            }
            buffer[0] = 255;
            buffer[1] = (byte)mode;
            buffer[2] = upper;
            buffer[3] = lower;
            buffer[4] = overload;
            serialPort1.Write(buffer,0,5);
        }
    }
}