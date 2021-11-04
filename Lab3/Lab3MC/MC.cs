using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace MECH423Lab1Exercise8
{
    public partial class Exercise8 : Form
    {
        string serialDataString = "";
        int stateAcceleration = 0;
        int checkFlag = 0;
        int state;
        int resetState;
        int dataCount;
        int timer2Switch;
        int x = 0;
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> averageAx = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> averageAy = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> averageAz = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AxQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> maxaccelAx = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> maxaccelAy = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> maxaccelAz = new ConcurrentQueue<Int32>();

        int[] averageAxArray = new int[100];
        int[] averageAyArray = new int[100];
        int[] averageAzArray = new int[100];
        int[] maxAxArray = new int[100];
        int[] maxAyArray = new int[100];
        int[] maxAzArray = new int[100];
        double[] Xvar = new double[100];
        double[] Yvar = new double[100];
        double[] Zvar = new double[100];

        public Exercise8()
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
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int resultData;
            int garbage;
            stateAcceleration = 0;
            if (serialPort1.IsOpen)
            {
                textBoxBytesToRead.Text = serialPort1.BytesToRead.ToString();
                textBoxTempStringLength.Text = serialDataString.Length.ToString();
                textBoxItemsInQueue.Text = dataQueue.Count.ToString();
                while (dataQueue.Count != 0)
                {
                    dataQueue.TryDequeue(out resultData);
                    switch (stateAcceleration)
                    {
                        case 0:
                            break;
                        case 1:
                            averageAx.Enqueue(resultData);
                            maxaccelAx.Enqueue(resultData);
                            if (x > 100) averageAx.TryDequeue(out garbage);
                            if (x > 500) maxaccelAx.TryDequeue(out garbage);
                            textBoxAx.Text = resultData.ToString();
                            if (checkFlag == 1) AxQueue.Enqueue(resultData);
                            stateAcceleration++;
                            if (resultData > 136)
                            {
                                pictureBoxXPlus.BackColor = Color.Red;
                                pictureBoxXMinus.BackColor = Color.White;
                                textBoxOrientation.Text = "X+";
                            }
                            else if (resultData < 116)
                            {
                                pictureBoxXMinus.BackColor = Color.Red;
                                pictureBoxXPlus.BackColor = Color.White;
                                textBoxOrientation.Text = "X-";
                            }
                            else
                            {
                                pictureBoxXPlus.BackColor = Color.White;
                                pictureBoxXMinus.BackColor = Color.White;
                            }
                            break;
                        case 2:
                            averageAy.Enqueue(resultData);
                            maxaccelAy.Enqueue(resultData);
                            if (x > 100) averageAy.TryDequeue(out garbage);
                            if (x > 500) maxaccelAy.TryDequeue(out garbage);
                            textBoxAy.Text = resultData.ToString();
                            if (checkFlag == 1 & AxQueue.Count > 0) AyQueue.Enqueue(resultData);
                            stateAcceleration++;
                            if (resultData > 136)
                            {
                                pictureBoxYPlus.BackColor = Color.Red;
                                pictureBoxYMinus.BackColor = Color.White;
                                textBoxOrientation.Text = "Y+";
                            }
                            else if (resultData < 116)
                            {
                                pictureBoxYMinus.BackColor = Color.Red;
                                pictureBoxYPlus.BackColor = Color.White;
                                textBoxOrientation.Text = "Y-";
                            }
                            else
                            {
                                pictureBoxYPlus.BackColor = Color.White;
                                pictureBoxYMinus.BackColor = Color.White;
                            }
                            break;
                        case 3:
                            averageAz.Enqueue(resultData);
                            maxaccelAz.Enqueue(resultData);
                            if (x > 100) averageAz.TryDequeue(out garbage);
                            if (x > 500) maxaccelAz.TryDequeue(out garbage);
                            textBoxAz.Text = resultData.ToString();
                            if (checkFlag == 1 & AxQueue.Count > 0) AzQueue.Enqueue(resultData);
                            stateAcceleration = 0;
                            if (resultData > 136)
                            {
                                pictureBoxZPlus.BackColor = Color.Red;
                                pictureBoxZMinus.BackColor = Color.White;
                                textBoxOrientation.Text = "Z+";
                            }
                            else if (resultData < 116)
                            {
                                pictureBoxZMinus.BackColor = Color.Red;
                                pictureBoxZPlus.BackColor = Color.White;
                                textBoxOrientation.Text = "Z-";
                            }
                            else
                            {
                                pictureBoxZPlus.BackColor = Color.White;
                                pictureBoxZMinus.BackColor = Color.White;
                            }
                            StateMachine();
                            break;
                        default:
                            break;
                    }
                    if (stateAcceleration == 0 & resultData == 255)
                    {
                        stateAcceleration++;
                    }
                    textBoxSerialDataStream.AppendText(resultData.ToString());
                    textBoxSerialDataStream.AppendText(", ");
                    
                }
                serialDataString = "";
                averages();
            }
        }
        private void averages()
        {
            if (maxaccelAx.IsEmpty == false)
            {
                maxAxArray = maxaccelAx.ToArray();
                maxAyArray = maxaccelAy.ToArray();
                maxAzArray = maxaccelAz.ToArray();
                double xMax = maxAxArray.Max() - 125;
                double yMax = maxAyArray.Max() - 125;
                double zMax = maxAzArray.Max() - 125;
                if ((125 - maxAxArray.Min()) > xMax) xMax = maxAxArray.Min() - 125;
                if ((125 - maxAyArray.Min()) > yMax) yMax = maxAyArray.Min() - 125;
                if ((125 - maxAzArray.Min()) > zMax) zMax = maxAzArray.Min() - 125;
                textBoxAxAverage.Text = (xMax / 28).ToString();
                textBoxAyAverage.Text = (yMax / 28).ToString();
                textBoxAzAverage.Text = (zMax / 28).ToString();
                averageAxArray = averageAx.ToArray();
                averageAyArray = averageAy.ToArray();
                averageAzArray = averageAz.ToArray();
                if (x < 100)
                {
                    //for (int i = 0; i < x; i++)
                    //{
                    Xvar[x] = Math.Abs((double)averageAxArray[x] - averageAxArray.Average());
                    Xvar[x] = Math.Pow(Xvar[x], 2);
                    Yvar[x] = Math.Abs((double)averageAyArray[x] - averageAyArray.Average());
                    Yvar[x] = Math.Pow(Yvar[x], 2);
                    Zvar[x] = Math.Abs((double)averageAzArray[x] - averageAzArray.Average());
                    Zvar[x] = Math.Pow(Zvar[x], 2);
                    //Xvar[i] = Math.Abs((double)averageAxArray[i] - averageAx.Average());
                    //Xvar[i] = Math.Pow(Xvar[i], 2);
                    //Yvar[i] = Math.Abs((double)averageAyArray[i] - averageAy.Average());
                    //Yvar[i] = Math.Pow(Yvar[i], 2);
                    //Zvar[i] = Math.Abs((double)averageAzArray[i] - averageAz.Average());
                    //Zvar[i] = Math.Pow(Zvar[i], 2);
                    //}
                    textBoxXSD.Text = ((Math.Sqrt(Xvar.Sum() / x)) / 28).ToString();
                    textBoxYSD.Text = ((Math.Sqrt(Yvar.Sum() / x)) / 28).ToString();
                    textBoxZSD.Text = ((Math.Sqrt(Zvar.Sum() / x)) / 28).ToString();
                }
                else
                {
                    int y = x % 100;
                    //for (int i = 0; i < 100; i++)
                    //{
                    Xvar[y] = Math.Abs((double)averageAxArray[y] - averageAx.Average());
                    Xvar[y] = Math.Pow(Xvar[y], 2);
                    Yvar[y] = Math.Abs((double)averageAyArray[y] - averageAy.Average());
                    Yvar[y] = Math.Pow(Yvar[y], 2);
                    Zvar[y] = Math.Abs((double)averageAzArray[y] - averageAz.Average());
                    Zvar[y] = Math.Pow(Zvar[y], 2);
                    //Xvar[i] = Math.Abs((double)averageAxArray[i] - averageAx.Average());
                    //Xvar[i] = Math.Pow(Xvar[i], 2);
                    //Yvar[i] = Math.Abs((double)averageAyArray[i] - averageAy.Average());
                    //Yvar[i] = Math.Pow(Yvar[i], 2);
                    //Zvar[i] = Math.Abs((double)averageAzArray[i] - averageAz.Average());
                    //Zvar[i] = Math.Pow(Zvar[i], 2);
                    //}
                    textBoxXSD.Text = ((Math.Sqrt(Xvar.Sum() / 100)) / 28).ToString();
                    textBoxYSD.Text = ((Math.Sqrt(Yvar.Sum() / 100)) / 28).ToString();
                    textBoxZSD.Text = ((Math.Sqrt(Zvar.Sum() / 100)) / 28).ToString();
                }
                //textBoxAxAverage.Text= averageAxArray.Average().ToString();
                //textBoxAyAverage.Text = averageAyArray.Average().ToString();
                //textBoxAzAverage.Text = averageAzArray.Average().ToString();
                x++;
            }
        }
        private void StateMachine()
        {
            int dataCountLimit = 10;
            int resetState = 0;
            switch (state)
            {
                case 0: //neutral state
                    if (Convert.ToInt32(textBoxAz.Text) > 170) //Z+
                    {
                        dataCount = dataCountLimit;
                        state = 1;
                        goto case 1;
                    }
                    if (Convert.ToInt32(textBoxAz.Text) < 120) //Z-
                    {
                        dataCount = dataCountLimit;
                        state = 2;
                        goto case 2;
                    }
                    break;
                case 1: //Z+
                    if (Convert.ToInt32(textBoxAy.Text) > 180)
                    {
                        dataCount = dataCountLimit;
                        state = 4;
                        goto case 4;
                    }
                    else dataCount = dataCount - 1;
                    if (dataCount == 0) state = 0;
                    break;
                case 2: //-Z
                    if (Convert.ToInt32(textBoxAx.Text) > 160)
                    {
                        dataCount = dataCountLimit;
                        goto case 3;
                    }
                    else dataCount = dataCount - 1;
                    if (dataCount == 0)
                    {
                        textBoxGesture.Text = "Free Fall!";
                        turnOnGesture();
                        resetState = 1;
                    }
                    break;
                case 3: //+X
                    textBoxGesture.Text = "Grave Digger!";
                    turnOnGesture();
                    resetState = 1;
                    break;
                case 4: //WAVE
                    if (Convert.ToInt32(textBoxAy.Text) < 100)
                    {
                        dataCount = dataCountLimit;
                        goto case 5;
                    }
                    else dataCount = dataCount - 1;
                    if (dataCount == 0) resetState = 1;
                    break;
                case 5: //(+Z, after +X and +Y) right hook
                    textBoxGesture.Text = "Wave!";
                    turnOnGesture();
                    state = 5;
                    resetState = 1;
                    break;
                default:
                    break;
            }
            textBoxCurrentState.Text = state.ToString();
            if (resetState == 1)
            {
                state = 0;
                resetState = 0;
            }
        }
        private void Exercise8_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
            timer1.Enabled = true;
            timer2.Enabled = true;
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
                //serialPort1.Write("A");
                button1.Text = "Disconnect";
            }
        }
        private void turnOnGesture()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\jorda\Desktop\slap.wav";
            player.Play();
            //System.Media.SystemSounds.Beep.Play();
            textBoxGesture.BackColor = Color.Red;
            textBoxGesture.ForeColor = Color.Yellow;
            timer2Switch = 0;
            timer2Switch = 1;
            timer2.Enabled = true;
        }         
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer2Switch == 1)
            {
                textBoxGesture.BackColor = Color.White;
                textBoxGesture.ForeColor = Color.White;
                textBoxGesture.Text = "";
                timer2.Enabled = false;
            }
            else timer2Switch = 0;
        }
    }
}