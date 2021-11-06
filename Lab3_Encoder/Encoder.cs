using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Lab3_Encoder
{
    public partial class Encoder : Form
    {
        //INPUTS
        long i = 0;
        double frequency = 50;
        double ratio = 250; // 1/(4mm)
        double counts_per_rev = 980;
        double circumference = Math.PI* 0.004;

        //INTERMEDIATE PARAMETERS
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        double max_y;
        double max_y2;
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
            while(bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
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
                timer1.Enabled = true;
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
            //timer1.Enabled = true;
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
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = -1;
            objChart.AxisY.Maximum = 1;
            objChart.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY2.Minimum = -1;
            objChart.AxisY2.Maximum = 1;
            //clear
            chartVelocity.Series.Clear();
            //random color
            Random random = new Random();
            //initial chart addition
            chartVelocity.Series.Add(v);
            chartVelocity.Series[v].Color = Color.FromArgb(0,255,0);
            chartVelocity.Series[v].Legend = "Legend1";
            chartVelocity.Series[v].ChartArea = "ChartArea1";
            chartVelocity.Series[v].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartVelocity.Series.Add(p);
            chartVelocity.Series[p].Color = Color.FromArgb(255,0,0);
            chartVelocity.Series[p].Legend = "Legend1";
            chartVelocity.Series[p].ChartArea = "ChartArea1";
            chartVelocity.Series[p].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartVelocity.Series[p].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            objChart.AxisY2.LabelStyle.Format = "0.00";
            //objChart.AxisY2.Enabled = AxisEnabled.True;
            //chartVelocity.Series["Series 1"].YAxisType = AxisType.Secondary;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int enc_counts = 0;
            encoder_count = 0;
            while (dataQueue.Count != 0)
            {
                dataQueue.TryDequeue(out int result);
                if (result == 255)
                {
                    enc_counts++;
                    dataQueue.TryDequeue(out result);
                    direction = result;
                    if (direction == 2) direction = -1;
                    if (dataQueue.TryDequeue(out result) == false) enc_counts--;
                    encoder_count = encoder_count + result * direction;
                }
            }
            distance = (double)encoder_count * 0.004 / counts_per_rev;
            velocityRPM = (((double)encoder_count / ((1 / frequency)*enc_counts)) / counts_per_rev); //encoder_count = counts/period, divide by counts/rev
            velocityHz = velocityRPM * 60; //Hz = cycles/s... 1 cycle = 1 rev
            if (direction == 2) distance = distance * -1;
            position = position + distance;
            textBoxPosition.Text = position.ToString();
            textBoxVelocityRPM.Text = velocityRPM.ToString();
            textBoxVelocityHz.Text = velocityHz.ToString();
            old_distance = distance;

            var objChart = chartVelocity.ChartAreas[0];
            time = time + 0.1;
            if (time > 10)
            {
                objChart.AxisX.Minimum = (int)time - 9;
                objChart.AxisX.Maximum = (int)time + 1;
            }
            if ((max_y - max_y*0.1) < velocityRPM)
            {
                max_y = velocityRPM + velocityRPM * 0.5;
                objChart.AxisY.Minimum = 0;
                objChart.AxisY.Maximum = (int)max_y;
            }
            if (((max_y2 - max_y2 * 0.1) < position) & (position>0.01))
            {
                max_y2 = position + position * 0.5;
                objChart.AxisY2.Minimum = 0;
                objChart.AxisY2.Maximum = max_y2;
            }
            //Add data every 0.1s
            chartVelocity.Series[v].Points.AddXY(time, velocityRPM);
            chartVelocity.Series[p].Points.AddXY(time, position);
        }
    }
}