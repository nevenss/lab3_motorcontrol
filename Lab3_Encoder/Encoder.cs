using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Encoder
{
    public partial class Encoder : Form
    {
        int mode;
        int speed;
        double time = 0;
        string v = "Velocity";


        public Encoder()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;
            int encoder_count;
            bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                int frequency = 50;
                encoder_count = serialPort1.ReadByte();
                double velocity = (encoder_count * (1 / frequency));
                textBoxVelocityHz.Text = (velocity).ToString();
            }
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
            adjustSpeed();
        }

        private void adjustSpeed()
        {
            if (speed < 56000)
            {
                mode = 1;
            }
            else if (speed > 64000)
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
            serialPort1.Write(buffer, 0, 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            byte[] buffer = new byte[5];
            byte overload = 0;
            byte upper = 0;
            byte lower = 0;
            byte mode = 3;

            buffer[0] = 255;
            buffer[1] = (byte)mode;
            buffer[2] = upper;
            buffer[3] = lower;
            buffer[4] = overload;
            serialPort1.Write(buffer, 0, 5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[5];
            byte overload = 0;
            byte upper = 0;
            byte lower = 0;
            byte mode = 4;

            buffer[0] = 255;
            buffer[1] = (byte)mode;
            buffer[2] = upper;
            buffer[3] = lower;
            buffer[4] = overload;
            serialPort1.Write(buffer, 0, 5);
        }

        private void Encoder_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
            var objChart = chartVelocity.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //month 1-12
            objChart.AxisX.Minimum = 0;
            objChart.AxisX.Maximum = 10;
            //temperature
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = -20;
            objChart.AxisY.Maximum = 20;
            //clear
            chartVelocity.Series.Clear();
            //random color
            Random random = new Random();
            //initial chart addition
            chartVelocity.Series.Add(v);
            chartVelocity.Series[v].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            chartVelocity.Series[v].Legend = "Legend1";
            chartVelocity.Series[v].ChartArea = "ChartArea1";
            chartVelocity.Series[v].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var objChart = chartVelocity.ChartAreas[0];
            var vel = Convert.ToDouble(textBoxVelocityRPM);
            time = time + 0.1;
            if(time > 10)
            {
                objChart.AxisX.Minimum = time-10;
                objChart.AxisX.Maximum = time;
            }
            //Add data every 0.1s?
            chartVelocity.Series[v].Points.AddXY(time, vel);
        }
    }
}