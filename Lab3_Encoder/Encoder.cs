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
        //INPUTS
        double frequency = 50;
        double ratio = 250; // 1/(4mm)
        int counts_per_rev = 980;

        //INTERMEDIATE PARAMETERS
        Queue<Int32> dataQueue = new Queue<Int32>();
        int direction = 0;
        int state = 0;
        int speed = 0;
        int newByte = 0;
        int bytesToRead;
        double distance;
        double position;
        double velocityRPM;
        double velocityHz;
        int encoder_count;
        double old_distance = 0;
        int mode;
        double time = 0;
        
        string v = "Velocity";
        string p = "Position";

        public Encoder()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                if (newByte == 255) state = 1;  //update to next state
                else if (state == 1)            //take in direction
                {
                    direction = newByte;
                    state = 2;
                }
                else if (state == 2)            //take in encoder count
                {
                    encoder_count = newByte;
                    state = 0;
                }
                bytesToRead = serialPort1.BytesToRead;
            }
            timer1.Enabled = true;
            
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
                //serialPort1.Open();
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

        private void Encoder_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
            var objChart = chartVelocity.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
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
            chartVelocity.Series.Add(p);
            chartVelocity.Series[p].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            chartVelocity.Series[p].Legend = "Legend1";
            chartVelocity.Series[p].ChartArea = "ChartArea1";
            chartVelocity.Series[p].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            distance = (double)encoder_count / ratio;
            velocityRPM = ((encoder_count/(1/frequency))/counts_per_rev); //encoder_count = counts/period, divide by counts/rev
            velocityHz = velocityRPM * 60; //Hz = cycles/s... 1 cycle = 1 rev
            if (direction == 2) distance = distance * -1;
            position = distance + old_distance;
            textBoxPosition.Text = position.ToString();
            textBoxVelocityRPM.Text = velocityRPM.ToString();
            textBoxVelocityHz.Text = velocityHz.ToString();
            old_distance = distance;

            var objChart = chartVelocity.ChartAreas[0];
            //var vel = Convert.ToDouble(textBoxVelocityRPM);
            time = time + 0.1;
            if(time > 10)
            {
                objChart.AxisX.Minimum = (int)time-9;
                objChart.AxisX.Maximum = (int)time+1;
            }
            //Add data every 0.1s
            chartVelocity.Series[v].Points.AddXY(time, velocityRPM);
            chartVelocity.Series[p].Points.AddXY(time, position);
        }
    }
}