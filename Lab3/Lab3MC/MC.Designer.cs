
namespace MECH423Lab1Exercise8
{
    partial class Exercise8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.textBoxSerialDataStream = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAz = new System.Windows.Forms.TextBox();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxItemsInQueue = new System.Windows.Forms.TextBox();
            this.textBoxTempStringLength = new System.Windows.Forms.TextBox();
            this.textBoxBytesToRead = new System.Windows.Forms.TextBox();
            this.textBoxQueue = new System.Windows.Forms.Label();
            this.TempStringLength = new System.Windows.Forms.Label();
            this.asdf = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBoxXPlus = new System.Windows.Forms.PictureBox();
            this.pictureBoxXMinus = new System.Windows.Forms.PictureBox();
            this.pictureBoxYMinus = new System.Windows.Forms.PictureBox();
            this.pictureBoxYPlus = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBoxZMinus = new System.Windows.Forms.PictureBox();
            this.pictureBoxZPlus = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxCurrentState = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBoxGesture = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxAxAverage = new System.Windows.Forms.TextBox();
            this.textBoxAyAverage = new System.Windows.Forms.TextBox();
            this.textBoxAzAverage = new System.Windows.Forms.TextBox();
            this.textBoxOrientation = new System.Windows.Forms.TextBox();
            this.textBoxZSD = new System.Windows.Forms.TextBox();
            this.textBoxYSD = new System.Windows.Forms.TextBox();
            this.textBoxXSD = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 41);
            this.button1.TabIndex = 19;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(257, 33);
            this.comboBoxCOMPorts.TabIndex = 18;
            // 
            // textBoxSerialDataStream
            // 
            this.textBoxSerialDataStream.Location = new System.Drawing.Point(12, 208);
            this.textBoxSerialDataStream.Multiline = true;
            this.textBoxSerialDataStream.Name = "textBoxSerialDataStream";
            this.textBoxSerialDataStream.Size = new System.Drawing.Size(454, 154);
            this.textBoxSerialDataStream.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Serial Data Stream";
            // 
            // textBoxAz
            // 
            this.textBoxAz.Location = new System.Drawing.Point(354, 450);
            this.textBoxAz.Name = "textBoxAz";
            this.textBoxAz.Size = new System.Drawing.Size(112, 31);
            this.textBoxAz.TabIndex = 32;
            // 
            // textBoxAy
            // 
            this.textBoxAy.Location = new System.Drawing.Point(198, 450);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(110, 31);
            this.textBoxAy.TabIndex = 31;
            // 
            // textBoxAx
            // 
            this.textBoxAx.Location = new System.Drawing.Point(45, 450);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(115, 31);
            this.textBoxAx.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Az";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 489);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 25);
            this.label7.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 25);
            this.label8.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 25);
            this.label9.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 488);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 25);
            this.label10.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 25);
            this.label11.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(246, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 25);
            this.label12.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(435, 488);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 25);
            this.label13.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(363, 488);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 25);
            this.label14.TabIndex = 45;
            // 
            // textBoxItemsInQueue
            // 
            this.textBoxItemsInQueue.Location = new System.Drawing.Point(259, 137);
            this.textBoxItemsInQueue.Name = "textBoxItemsInQueue";
            this.textBoxItemsInQueue.Size = new System.Drawing.Size(163, 31);
            this.textBoxItemsInQueue.TabIndex = 54;
            // 
            // textBoxTempStringLength
            // 
            this.textBoxTempStringLength.Location = new System.Drawing.Point(259, 95);
            this.textBoxTempStringLength.Name = "textBoxTempStringLength";
            this.textBoxTempStringLength.Size = new System.Drawing.Size(163, 31);
            this.textBoxTempStringLength.TabIndex = 53;
            // 
            // textBoxBytesToRead
            // 
            this.textBoxBytesToRead.Location = new System.Drawing.Point(259, 56);
            this.textBoxBytesToRead.Name = "textBoxBytesToRead";
            this.textBoxBytesToRead.Size = new System.Drawing.Size(163, 31);
            this.textBoxBytesToRead.TabIndex = 52;
            // 
            // textBoxQueue
            // 
            this.textBoxQueue.AutoSize = true;
            this.textBoxQueue.Location = new System.Drawing.Point(96, 140);
            this.textBoxQueue.Name = "textBoxQueue";
            this.textBoxQueue.Size = new System.Drawing.Size(156, 25);
            this.textBoxQueue.TabIndex = 51;
            this.textBoxQueue.Text = "Items in Queue";
            // 
            // TempStringLength
            // 
            this.TempStringLength.AutoSize = true;
            this.TempStringLength.Location = new System.Drawing.Point(53, 98);
            this.TempStringLength.Name = "TempStringLength";
            this.TempStringLength.Size = new System.Drawing.Size(200, 25);
            this.TempStringLength.TabIndex = 50;
            this.TempStringLength.Text = "Temp String Length";
            // 
            // asdf
            // 
            this.asdf.AutoSize = true;
            this.asdf.Location = new System.Drawing.Point(45, 59);
            this.asdf.Name = "asdf";
            this.asdf.Size = new System.Drawing.Size(208, 25);
            this.asdf.TabIndex = 49;
            this.asdf.Text = "Serial Bytes to Read";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 489);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 25);
            this.label15.TabIndex = 55;
            this.label15.Text = "X+";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 523);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 25);
            this.label16.TabIndex = 56;
            this.label16.Text = "X-";
            // 
            // pictureBoxXPlus
            // 
            this.pictureBoxXPlus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxXPlus.Location = new System.Drawing.Point(91, 490);
            this.pictureBoxXPlus.Name = "pictureBoxXPlus";
            this.pictureBoxXPlus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxXPlus.TabIndex = 57;
            this.pictureBoxXPlus.TabStop = false;
            // 
            // pictureBoxXMinus
            // 
            this.pictureBoxXMinus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxXMinus.Location = new System.Drawing.Point(91, 522);
            this.pictureBoxXMinus.Name = "pictureBoxXMinus";
            this.pictureBoxXMinus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxXMinus.TabIndex = 58;
            this.pictureBoxXMinus.TabStop = false;
            // 
            // pictureBoxYMinus
            // 
            this.pictureBoxYMinus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxYMinus.Location = new System.Drawing.Point(241, 523);
            this.pictureBoxYMinus.Name = "pictureBoxYMinus";
            this.pictureBoxYMinus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxYMinus.TabIndex = 64;
            this.pictureBoxYMinus.TabStop = false;
            // 
            // pictureBoxYPlus
            // 
            this.pictureBoxYPlus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxYPlus.Location = new System.Drawing.Point(241, 491);
            this.pictureBoxYPlus.Name = "pictureBoxYPlus";
            this.pictureBoxYPlus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxYPlus.TabIndex = 63;
            this.pictureBoxYPlus.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(203, 524);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 25);
            this.label17.TabIndex = 62;
            this.label17.Text = "Y-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(203, 490);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 25);
            this.label18.TabIndex = 61;
            this.label18.Text = "Y+";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(274, 489);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 25);
            this.label19.TabIndex = 60;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(202, 489);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 25);
            this.label20.TabIndex = 59;
            // 
            // pictureBoxZMinus
            // 
            this.pictureBoxZMinus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxZMinus.Location = new System.Drawing.Point(394, 524);
            this.pictureBoxZMinus.Name = "pictureBoxZMinus";
            this.pictureBoxZMinus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxZMinus.TabIndex = 70;
            this.pictureBoxZMinus.TabStop = false;
            // 
            // pictureBoxZPlus
            // 
            this.pictureBoxZPlus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxZPlus.Location = new System.Drawing.Point(394, 492);
            this.pictureBoxZPlus.Name = "pictureBoxZPlus";
            this.pictureBoxZPlus.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxZPlus.TabIndex = 69;
            this.pictureBoxZPlus.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(358, 525);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 25);
            this.label21.TabIndex = 68;
            this.label21.Text = "Z-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(358, 491);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 25);
            this.label22.TabIndex = 67;
            this.label22.Text = "Z+";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(429, 490);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 25);
            this.label23.TabIndex = 66;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(357, 490);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 25);
            this.label24.TabIndex = 65;
            // 
            // textBoxCurrentState
            // 
            this.textBoxCurrentState.Location = new System.Drawing.Point(75, 556);
            this.textBoxCurrentState.Name = "textBoxCurrentState";
            this.textBoxCurrentState.Size = new System.Drawing.Size(30, 31);
            this.textBoxCurrentState.TabIndex = 71;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 559);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 25);
            this.label25.TabIndex = 72;
            this.label25.Text = "State";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBoxGesture
            // 
            this.textBoxGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGesture.Location = new System.Drawing.Point(11, 593);
            this.textBoxGesture.Name = "textBoxGesture";
            this.textBoxGesture.Size = new System.Drawing.Size(452, 67);
            this.textBoxGesture.TabIndex = 73;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(30, 380);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 25);
            this.label26.TabIndex = 74;
            this.label26.Text = "Max G";
            // 
            // textBoxAxAverage
            // 
            this.textBoxAxAverage.Location = new System.Drawing.Point(124, 377);
            this.textBoxAxAverage.Name = "textBoxAxAverage";
            this.textBoxAxAverage.Size = new System.Drawing.Size(75, 31);
            this.textBoxAxAverage.TabIndex = 75;
            // 
            // textBoxAyAverage
            // 
            this.textBoxAyAverage.Location = new System.Drawing.Point(208, 377);
            this.textBoxAyAverage.Name = "textBoxAyAverage";
            this.textBoxAyAverage.Size = new System.Drawing.Size(75, 31);
            this.textBoxAyAverage.TabIndex = 76;
            // 
            // textBoxAzAverage
            // 
            this.textBoxAzAverage.Location = new System.Drawing.Point(295, 377);
            this.textBoxAzAverage.Name = "textBoxAzAverage";
            this.textBoxAzAverage.Size = new System.Drawing.Size(75, 31);
            this.textBoxAzAverage.TabIndex = 77;
            // 
            // textBoxOrientation
            // 
            this.textBoxOrientation.Location = new System.Drawing.Point(394, 377);
            this.textBoxOrientation.Name = "textBoxOrientation";
            this.textBoxOrientation.Size = new System.Drawing.Size(49, 31);
            this.textBoxOrientation.TabIndex = 78;
            // 
            // textBoxZSD
            // 
            this.textBoxZSD.Location = new System.Drawing.Point(295, 412);
            this.textBoxZSD.Name = "textBoxZSD";
            this.textBoxZSD.Size = new System.Drawing.Size(75, 31);
            this.textBoxZSD.TabIndex = 82;
            // 
            // textBoxYSD
            // 
            this.textBoxYSD.Location = new System.Drawing.Point(208, 412);
            this.textBoxYSD.Name = "textBoxYSD";
            this.textBoxYSD.Size = new System.Drawing.Size(75, 31);
            this.textBoxYSD.TabIndex = 81;
            // 
            // textBoxXSD
            // 
            this.textBoxXSD.Location = new System.Drawing.Point(124, 412);
            this.textBoxXSD.Name = "textBoxXSD";
            this.textBoxXSD.Size = new System.Drawing.Size(75, 31);
            this.textBoxXSD.TabIndex = 80;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(40, 415);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 25);
            this.label27.TabIndex = 79;
            this.label27.Text = "SD";
            // 
            // Exercise8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 713);
            this.Controls.Add(this.textBoxZSD);
            this.Controls.Add(this.textBoxYSD);
            this.Controls.Add(this.textBoxXSD);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.textBoxOrientation);
            this.Controls.Add(this.textBoxAzAverage);
            this.Controls.Add(this.textBoxAyAverage);
            this.Controls.Add(this.textBoxAxAverage);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBoxGesture);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.textBoxCurrentState);
            this.Controls.Add(this.pictureBoxZMinus);
            this.Controls.Add(this.pictureBoxZPlus);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.pictureBoxYMinus);
            this.Controls.Add(this.pictureBoxYPlus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBoxXMinus);
            this.Controls.Add(this.pictureBoxXPlus);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxItemsInQueue);
            this.Controls.Add(this.textBoxTempStringLength);
            this.Controls.Add(this.textBoxBytesToRead);
            this.Controls.Add(this.textBoxQueue);
            this.Controls.Add(this.TempStringLength);
            this.Controls.Add(this.asdf);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAz);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSerialDataStream);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Name = "Exercise8";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Exercise8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZPlus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.TextBox textBoxSerialDataStream;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAz;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxItemsInQueue;
        private System.Windows.Forms.TextBox textBoxTempStringLength;
        private System.Windows.Forms.TextBox textBoxBytesToRead;
        private System.Windows.Forms.Label textBoxQueue;
        private System.Windows.Forms.Label TempStringLength;
        private System.Windows.Forms.Label asdf;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBoxXPlus;
        private System.Windows.Forms.PictureBox pictureBoxXMinus;
        private System.Windows.Forms.PictureBox pictureBoxYMinus;
        private System.Windows.Forms.PictureBox pictureBoxYPlus;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBoxZMinus;
        private System.Windows.Forms.PictureBox pictureBoxZPlus;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxCurrentState;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBoxGesture;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxAxAverage;
        private System.Windows.Forms.TextBox textBoxAyAverage;
        private System.Windows.Forms.TextBox textBoxAzAverage;
        private System.Windows.Forms.TextBox textBoxOrientation;
        private System.Windows.Forms.TextBox textBoxZSD;
        private System.Windows.Forms.TextBox textBoxYSD;
        private System.Windows.Forms.TextBox textBoxXSD;
        private System.Windows.Forms.Label label27;
    }
}

