/*
 * MultiWii Windows GUI by Andras Schaffer (EOSBandi)
 * February  2012     V1.0 Beta
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   any later version. see <http://www.gnu.org/licenses/>
 * 
 * LogBrowser is based on ArduPlanner Mega code written by Michael Oborne http://www.diydrones.com 
 * Instrument controls are based on AvionicsInstrument Controls written by Guillaume CHOUTEAU http://www.codeproject.com/Articles/27411/C-Avionic-Instrument-Controls
 * Video capture code is using Aforge.Net Framework http://www.aforgenet.com
 * Graph parts are using ZedGraph control http://sourceforge.net/projects/zedgraph/
 * 
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using MultiWiiGUIControls;
using ZedGraph;

namespace MultiWiiWinGUI
{

    public partial class mainGUI : Form
    {

        #region Common variables (properties)

        static string sPublishVersion = "1.0 Beta";

        static string sOptionsConfigFilename = "optionsconfig";
        const string sGuiSettingsFilename = "gui_settings.xml";
        enum CopterType { Tri = 1, QuadP, QuadX, BI, Gimbal, Y6, Hex6, FlyWing, Y4, Hex6X, Octo8Coax, Octo8P, Octo8X };

        string[] sSerialSpeeds = { "115200", "57600", "38400", "19200", "9600" };
        string[] sRefreshSpeeds = { "20 Hz", "10 Hz", "5 Hz", "2 Hz", "1 Hz" };
        int[] iRefreshIntervals = { 50, 100, 200, 500, 1000 };
        const int rcLow = 1300;
        const int rcMid = 1700;

        const int iPacketSizeM20 = 155;             //M answer packet size for ver latest head
        const int iPacketSizeM19 = 125;             //M answer packet size for ver 1.9
        static int iPacketSizeM;                    //This will contain packet size 
        const string sRelName20 = "SVN r569";
        const string sRelName19 = "1.9";
        static string sRelName;

        //PID value positions is serial stream
        static byte PID_ROLL;
        static byte PID_PITCH;
        static byte PID_YAW;
        static byte PID_ALT;
        static byte PID_VEL;
        static byte PID_GPS;
        static byte PID_LEVEL;
        static byte PID_MAG;

        static SerialPort serialPort;
        static bool isConnected = false;                        //is port connected or not ?
        static bool bSerialError = false;
        static bool isPaused = false;
        static bool isPausedRC = false;
        static int iSelectedTabIndex = 0;                          //Contains the actually selected tab
        static double xTimeStamp = 0;
        static byte[] bSerialBuffer;

        static int iCheckBoxItems = 0;                          //number of checkboxItems (readed from optionsconfig.xml
        static int iPidItems = 8;                                //number if Pid items (const definition)
        static mw_data_gui mw_gui;
        static mw_settings mw_params;
        static GUI_settings gui_settings;
        static bool bOptions_needs_refresh = true;
        static bool bRestartNeeded = false;                     //FC software version changed, must restart

        static string[] option_names;
        static string[] option_desc;
        static byte[] rcOptions1;               //The aux checkbox states are consolidates into these variable (for enable write to FC)
        static byte[] rcOptions2;

        static LineItem curve_acc_roll, curve_acc_pitch, curve_acc_z;
        static LineItem curve_gyro_roll, curve_gyro_pitch, curve_gyro_yaw;
        static LineItem curve_mag_roll, curve_mag_pitch, curve_mag_yaw;
        static LineItem curve_alt, curve_head;
        static LineItem curve_dbg1, curve_dbg2, curve_dbg3, curve_dbg4;


        static RollingPointPairList list_acc_roll, list_acc_pitch, list_acc_z;
        static RollingPointPairList list_gyro_roll, list_gyro_pitch, list_gyro_yaw;
        static RollingPointPairList list_mag_roll, list_mag_pitch, list_mag_yaw;
        static RollingPointPairList list_alt, list_head;
        static RollingPointPairList list_dbg1, list_dbg2, list_dbg3, list_dbg4;

        static Scale xScale;

        CheckBoxEx[, ,] aux;
        System.Windows.Forms.Label[] cb_labels;
        System.Windows.Forms.Label[] aux_labels;
        System.Windows.Forms.Label[,] lmh_labels;


        XmlTextReader reader;
        int z;

        //For video capture 
        static bool bVideoRecording = false;
        static bool bVideoConnected = false;
        static VideoFileWriter vfwWriter;
        static FilterInfoCollection videoDevices;
        static VideoCaptureDevice videoSource;
        static TimeSpan tsFrameTimeStamp;
        static TimeSpan tsFrameRate;

        //For logging
        StreamWriter wLogStream;

        #endregion

        public mainGUI()
        {
            InitializeComponent();

        }

        private void mainGUI_Load(object sender, EventArgs e)
        {

            //First step, check it gui_settings file is exists or not, if not then start settings wizard
            if (!File.Exists(sGuiSettingsFilename))
            {
                setup_wizard panelSetupWizard = new setup_wizard();
                panelSetupWizard.ShowDialog();

            }

            //Now there must be a valid settings file, so we can continue with normal execution

            splash_screen splash = new splash_screen();
            splash.sVersionLabel = sPublishVersion;
            splash.Show();
            splash.Refresh();
            //Start with Settings file read, and parse exit if unsuccessfull
            gui_settings = new GUI_settings();
            if (!gui_settings.read_from_xml(sGuiSettingsFilename))
            {
                Environment.Exit(-1);
            }

            sOptionsConfigFilename = sOptionsConfigFilename + gui_settings.iSoftwareVersion + ".xml";
            read_options_config();                  //read and parse optionsconfig.xml file. sets iCheckBoxItems

            mw_gui = new mw_data_gui(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);
            mw_params = new mw_settings(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);

            //Define FC version dependant thingys :D
            if (gui_settings.iSoftwareVersion == 20)
            {
                PID_ROLL = 0; PID_PITCH = 1; PID_YAW = 2; PID_ALT = 3; PID_VEL = 4; PID_GPS = 5; PID_LEVEL = 6; PID_MAG = 7;
                iPacketSizeM = iPacketSizeM20;
                sRelName = sRelName20;
                splash.sFcVersionLabel = "MultiWii version " + sRelName20;
                splash.Refresh();
            }
            if (gui_settings.iSoftwareVersion == 19)
            {
                PID_ROLL = 0; PID_PITCH = 1; PID_YAW = 2; PID_ALT = 3; PID_VEL = 4; PID_LEVEL = 5; PID_MAG = 6;
                iPacketSizeM = iPacketSizeM19;
                sRelName = sRelName19;
                nPID_level_d.Visible = false;
                groupBoxGPS.Visible = false;
                splash.sFcVersionLabel = "MultiWii version " + sRelName19;
                splash.Refresh();

            }

            bSerialBuffer = new byte[iPacketSizeM];

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            rcOptions1 = new byte[iCheckBoxItems];
            rcOptions2 = new byte[iCheckBoxItems];

            //Fill out settings tab
            l_Capture_folder.Text = gui_settings.sCaptureFolder;
            l_LogFolder.Text = gui_settings.sLogFolder;
            cb_Logging_enabled.Checked = gui_settings.bEnableLogging;
            switch (gui_settings.iSoftwareVersion)
            {
                case 19:
                    rb_sw19.Checked = true;
                    break;
                case 20:
                    rb_sw20.Checked = true;
                    break;
                default:
                    rb_sw20.Checked = true;
                    break;
            }

            //Set log enties checkboxes
            cb_Log1.Checked = gui_settings.logGraw;
            cb_Log2.Checked = gui_settings.logGatt;
            cb_Log3.Checked = gui_settings.logGmag;
            cb_Log4.Checked = gui_settings.logGrcc;
            cb_Log5.Checked = gui_settings.logGrcx;
            cb_Log6.Checked = gui_settings.logGmot;
            cb_Log7.Checked = gui_settings.logGsrv;
            cb_Log8.Checked = gui_settings.logGnav;
            cb_Log9.Checked = gui_settings.logGpar;
            cb_Log10.Checked = gui_settings.logGdbg;


            //Build the RC control checkboxes structure

            aux = new CheckBoxEx[4, 4, iCheckBoxItems];

            int startx = 200;
            int starty = 60;

            int a, b, c;
            for (c = 0; c < 4; c++)
            {
                for (a = 0; a < 3; a++)
                {
                    for (b = 0; b < iCheckBoxItems; b++)
                    {
                        aux[c, a, b] = new CheckBoxEx();
                        aux[c, a, b].Location = new Point(startx + a * 18 + c * 70, starty + b * 25);
                        aux[c, a, b].Visible = true;
                        aux[c, a, b].Text = "";
                        aux[c, a, b].AutoSize = true;
                        aux[c, a, b].Size = new Size(16, 16);
                        aux[c, a, b].UseVisualStyleBackColor = true;
                        aux[c, a, b].CheckedChanged += new System.EventHandler(this.aux_checked_changed_event);
                        //Set info on the given checkbox position
                        aux[c, a, b].aux = c;           //Which aux channel
                        aux[c, a, b].rclevel = a;       //which rc level
                        aux[c, a, b].item = b;          //Which item
                        this.tabPageRC.Controls.Add(aux[c, a, b]);

                    }
                }
            }

            aux_labels = new System.Windows.Forms.Label[4];
            lmh_labels = new System.Windows.Forms.Label[4, 3];          // aux1-4, L,M,H
            string strlmh = "LMH";
            for (a = 0; a < 4; a++)
            {
                aux_labels[a] = new System.Windows.Forms.Label();
                aux_labels[a].Text = "AUX" + String.Format("{0:0}", a + 1);
                aux_labels[a].Location = new Point(startx + a * 70 + 8, starty - 35);
                aux_labels[a].AutoSize = true;
                aux_labels[a].ForeColor = Color.White;
                this.tabPageRC.Controls.Add(aux_labels[a]);
                for (b = 0; b < 3; b++)
                {
                    lmh_labels[a, b] = new System.Windows.Forms.Label();
                    lmh_labels[a, b].Text = strlmh.Substring(b, 1); ;
                    lmh_labels[a, b].Location = new Point(startx + a * 70 + b * 18, starty - 20);
                    lmh_labels[a, b].AutoSize = true;
                    lmh_labels[a, b].ForeColor = Color.White;
                    this.tabPageRC.Controls.Add(lmh_labels[a, b]);
                }

            }

            cb_labels = new System.Windows.Forms.Label[20];

            for (z = 0; z < iCheckBoxItems; z++)
            {
                cb_labels[z] = new System.Windows.Forms.Label();
                cb_labels[z].Text = option_names[z];
                cb_labels[z].Location = new Point(10, starty + z * 25);
                cb_labels[z].Visible = true;
                cb_labels[z].AutoSize = true;
                cb_labels[z].ForeColor = Color.White;
                cb_labels[z].TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(cb_labels[z], option_desc[z]);
                this.tabPageRC.Controls.Add(cb_labels[z]);
            }


            if (gui_settings.iSoftwareVersion == 19)
            {
                //Hide AUX3-AUX4 settings
                aux_labels[2].Visible = false;
                aux_labels[3].Visible = false;
                lmh_labels[2, 0].Visible = false;
                lmh_labels[2, 1].Visible = false;
                lmh_labels[2, 2].Visible = false;
                lmh_labels[3, 0].Visible = false;
                lmh_labels[3, 1].Visible = false;
                lmh_labels[3, 2].Visible = false;

                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    aux[2, 0, i].Visible = false;
                    aux[2, 1, i].Visible = false;
                    aux[2, 2, i].Visible = false;
                    aux[3, 0, i].Visible = false;
                    aux[3, 1, i].Visible = false;
                    aux[3, 2, i].Visible = false;
                }
            }

            this.Refresh();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cb_serial_port.Items.Add(port);
            }
            foreach (string speed in sSerialSpeeds)
            {
                cb_serial_speed.Items.Add(speed);
            }
            cb_serial_speed.SelectedItem = gui_settings.sPreferedSerialSpeed;

            if (cb_serial_port.Items.Count == 0)
            {
                b_connect.Enabled = false;          //Nos serial port, disable connect
            }
            else
            {
                cb_serial_port.SelectedIndex = 0;   //Otherwise select the first available port
            }

            //Init serial port object
            serialPort = new SerialPort();
            //Set up serial port parameters (at least the ones what we know upfront
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = false;               //??

            serialPort.ReadBufferSize = 4096;            //4K byte of read buffer
            serialPort.ReadTimeout = 500;               // 500msec timeout;

            //Init Realtime Monitor panel controls
            foreach (string rate in sRefreshSpeeds)
            {
                cb_monitor_rate.Items.Add(rate);
            }
            cb_monitor_rate.SelectedIndex = 0;              //20Hz is the default

            //Setup timers
            timer_realtime.Tick += new EventHandler(timer_realtime_Tick);
            timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
            timer_realtime.Enabled = true;
            timer_realtime.Stop();

            timer_rc.Tick += new EventHandler(timer_rc_Tick);
            timer_rc.Interval = 100; //(10Hz)
            timer_rc.Enabled = true;
            timer_rc.Stop();

            //Set up zgMonitor control for real time monitoring
            GraphPane myPane = zgMonitor.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

            //Set up pointlists and curves
            list_acc_roll = new RollingPointPairList(300);
            curve_acc_roll = myPane.AddCurve("acc_roll", list_acc_roll, Color.Red, SymbolType.None);

            list_acc_pitch = new RollingPointPairList(300);
            curve_acc_pitch = myPane.AddCurve("acc_pitch", list_acc_pitch, Color.Green, SymbolType.None);

            list_acc_z = new RollingPointPairList(300);
            curve_acc_z = myPane.AddCurve("acc_z", list_acc_z, Color.Blue, SymbolType.None);

            list_gyro_roll = new RollingPointPairList(300);
            curve_gyro_roll = myPane.AddCurve("gyro_roll", list_gyro_roll, Color.Khaki, SymbolType.None);

            list_gyro_pitch = new RollingPointPairList(300);
            curve_gyro_pitch = myPane.AddCurve("gyro_pitch", list_gyro_pitch, Color.Cyan, SymbolType.None);

            list_gyro_yaw = new RollingPointPairList(300);
            curve_gyro_yaw = myPane.AddCurve("gyro_yaw", list_gyro_yaw, Color.Magenta, SymbolType.None);

            list_mag_roll = new RollingPointPairList(300);
            curve_mag_roll = myPane.AddCurve("mag_roll", list_mag_roll, Color.CadetBlue, SymbolType.None);

            list_mag_pitch = new RollingPointPairList(300);
            curve_mag_pitch = myPane.AddCurve("mag_pitch", list_mag_pitch, Color.MediumPurple, SymbolType.None);

            list_mag_yaw = new RollingPointPairList(300);
            curve_mag_yaw = myPane.AddCurve("mag_yaw", list_mag_yaw, Color.DarkGoldenrod, SymbolType.None);

            list_alt = new RollingPointPairList(300);
            curve_alt = myPane.AddCurve("alt", list_alt, Color.White, SymbolType.None);

            list_head = new RollingPointPairList(300);
            curve_head = myPane.AddCurve("head", list_head, Color.Orange, SymbolType.None);

            list_dbg1 = new RollingPointPairList(300);
            curve_dbg1 = myPane.AddCurve("dbg1", list_dbg1, Color.PaleTurquoise, SymbolType.None);

            list_dbg2 = new RollingPointPairList(300);
            curve_dbg2 = myPane.AddCurve("dbg2", list_dbg2, Color.PaleTurquoise, SymbolType.None);

            list_dbg3 = new RollingPointPairList(300);
            curve_dbg3 = myPane.AddCurve("dbg3", list_dbg3, Color.PaleTurquoise, SymbolType.None);

            list_dbg4 = new RollingPointPairList(300);
            curve_dbg4 = myPane.AddCurve("dbg4", list_dbg4, Color.PaleTurquoise, SymbolType.None);

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.IsVisible = false;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.IsVisible = false;
            // Manually set the axis range
            myPane.YAxis.Scale.Min = -150;
            myPane.YAxis.Scale.Max = 150;

            myPane.Chart.Fill = new Fill(Color.DimGray, Color.DarkGray, 45.0f);
            myPane.Fill = new Fill(Color.DimGray, Color.DimGray, 45.0f);
            myPane.Legend.IsVisible = false;
            myPane.XAxis.Scale.IsVisible = false;
            myPane.YAxis.Scale.IsVisible = true;

            myPane.XAxis.Scale.MagAuto = false;
            myPane.YAxis.Scale.MagAuto = false;

            zgMonitor.IsEnableHPan = false;
            zgMonitor.IsEnableHZoom = false;

            foreach (ZedGraph.LineItem li in myPane.CurveList)
            {
                li.Line.Width = 2;
            }


            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 300;

            zgMonitor.ScrollGrace = 0;
            xScale = zgMonitor.GraphPane.XAxis.Scale;
            zgMonitor.AxisChange();

            pictureBox2.BorderStyle = BorderStyle.None;

            //Init video capture dev
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    dropdown_devices.Items.Add(device.Name);
                }
            }
            catch (ApplicationException)
            {
                dropdown_devices.Items.Add("No local capture devices");
                dropdown_devices.Enabled = false;
                b_video_connect.Enabled = false;
            }

            dropdown_devices.SelectedIndex = 0;
            cb_codec.SelectedIndex = 0;

            System.Threading.Thread.Sleep(2000);
            splash.Close();

        } //End of mainGUI_load

        private void timer_rc_Tick(object sender, EventArgs e)
        {
            //Since it's not time critical we can wait for the pervious operation to completed
            if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }

        }

        private void timer_realtime_Tick(object sender, EventArgs e)
        {
            //Since it's not time critical we can wait for the pervious operation to completed
            if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }


        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                b_connect.Text = "Connect";
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                timer_rc.Stop();
                //while (bkgWorker.IsBusy) { ; }
                System.Threading.Thread.Sleep(iRefreshIntervals[cb_monitor_rate.SelectedIndex]);         //Wait for 1 cycle to let backgroundworker finish it's last job.
                serialPort.Close();
                if (gui_settings.bEnableLogging)
                {
                    wLogStream.Flush();
                    wLogStream.Close();
                    wLogStream.Dispose();
                }
            }
            else
            {

                serialPort.PortName = cb_serial_port.Text;
                serialPort.BaudRate = int.Parse(cb_serial_speed.Text);
                serialPort.Open();
                b_connect.Text = "Disconnect";
                isConnected = true;

                //Run BackgroundWorker Once

                //Open Log file if it is enabled
                if (gui_settings.bEnableLogging)
                {
                    wLogStream = new StreamWriter(gui_settings.sLogFolder + "mwguilog" + String.Format("-{0:yymmdd-hhmm}.log", DateTime.Now));
                }

                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }
                if (tabMain.SelectedIndex == 2 && !isPaused) timer_realtime.Start();                             //If we are standing at the monitor page, start timer
                if (tabMain.SelectedIndex == 1 && !isPausedRC) timer_rc.Start();                                //And start it if we stays on rc settings page
            }
        }

        private void cb_monitor_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change refresh rate
            timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabMain.SelectedIndex)
            {
                case 2:
                    timer_rc.Stop();
                    if (isConnected && !isPaused) timer_realtime.Start();
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                case 1:
                    timer_realtime.Stop();
                    if (isConnected && !isPausedRC) timer_rc.Start();
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                case 4:
                    if (isConnected || bVideoRecording)
                    {
                        MessageBoxEx.Show(this, "FC is connected or Video is recording, to change GUI settings please disconnect FC and/or stop video recoding", "Unable to enter GUI settings", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tabMain.SelectedIndex = iSelectedTabIndex;      //go back to the pervious one
                    }
                    break;
                default:
                    timer_realtime.Stop();
                    timer_rc.Stop();
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
            }


        }

        private void b_log_browser_Click(object sender, EventArgs e)
        {
            Form logbrowser = new LogBrowser();
            logbrowser.ShowDialog();


        }

        private void read_options_config()
        {

            option_names = new string[20];
            option_desc = new string[100];
            iCheckBoxItems = 0;

            if (File.Exists(sOptionsConfigFilename))
            {
                reader = new XmlTextReader(sOptionsConfigFilename);
            }
            else
            {
                MessageBoxEx.Show(this, "Options file " + sOptionsConfigFilename + " does not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
            }
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (String.Compare(reader.Name, "aux_option", true) == 0 && reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    if (String.Compare(reader.Name, "name", true) == 0)
                                    {
                                        option_names[iCheckBoxItems] = reader.Value;
                                    }
                                    if (String.Compare(reader.Name, "desc", true) == 0)
                                    {
                                        option_desc[iCheckBoxItems] = reader.Value;
                                    }

                                }
                                iCheckBoxItems++;
                            }
                            if (String.Compare(reader.Name, "number_of_pids", true) == 0 && reader.HasAttributes) { iPidItems = Convert.ToInt16(reader.GetAttribute("value")); }
                            break;
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show(this, "Options file contains invalid data around Line : " + reader.LineNumber, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void trackbar_RC_Expo_Scroll(object sender, EventArgs e)
        {
            nRCExpo.Value = (decimal)trackbar_RC_Expo.Value / 100;
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
        }

        private void nRCExpo_ValueChanged(object sender, EventArgs e)
        {
            trackbar_RC_Expo.Value = (int)(nRCExpo.Value * 100);
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
        }

        private void trackbar_RC_Rate_Scroll(object sender, EventArgs e)
        {
            nRCRate.Value = (decimal)trackbar_RC_Rate.Value / 50;
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);

        }

        private void nRCRate_ValueChanged(object sender, EventArgs e)
        {
            trackbar_RC_Rate.Value = (int)(nRCRate.Value * 50);
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
        }

        private void b_pause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                b_pause.ForeColor = Color.Red;
                b_pause.Text = "Paused";
                timer_realtime.Stop();
            }
            else
            {
                b_pause.ForeColor = Color.Black;
                b_pause.Text = "Pause";
                if (isConnected) { timer_realtime.Start(); }
            }

        }

        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (serialPort.IsOpen)
            {
                //Read whatever we had in the buffer
                serialPort.ReadExisting();
                //Write M for the rest
                try
                {
                    serialPort.Write("M");
                    for (int i = 0; i < iPacketSizeM; i++) { bSerialBuffer[i] = (byte)serialPort.ReadByte(); }
                }
                catch
                {
                    //Timeout occured Assume we are resetting
                    System.Threading.Thread.Sleep(4000);         //Wait for the reset to be completed
                    try
                    {
                        serialPort.Write("M");
                        for (int i = 0; i < iPacketSizeM; i++) { bSerialBuffer[i] = (byte)serialPort.ReadByte(); }
                    }
                    catch
                    {
                        MessageBox.Show("No valid answer from FC!\r\nCheck that your MultiWii software version is maching with the version selected at the GUI Settings tab ("+sRelName+") and it's connected properly.", "Comm error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bSerialError = true;
                        return;
                    }
                }

                //check data packet trailer  M  and throw error message (and exit gracefully) if there is a missmatch
                if (bSerialBuffer[iPacketSizeM - 1] != 'M')
                {
                    MessageBox.Show("Incoming data packet size does not match with expected packet structure\r\nIt seems the version setting in GUI does not match with FC software version.", "Software Version missmatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }

                mw_gui.parse_input_packet(bSerialBuffer);
            }



        }

        private void bkgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (bSerialError)
            {
                b_connect.Text = "Connect";
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                timer_rc.Stop();
                System.Threading.Thread.Sleep(iRefreshIntervals[cb_monitor_rate.SelectedIndex]);         //Wait for 1 cycle to let backgroundworker finish it's last job.
                serialPort.Close();
                bSerialError = false;
                return;
            }

            if (gui_settings.bEnableLogging && wLogStream.BaseStream!=null)
            {
                //RAW Sensor (acc, gyro)
                if (gui_settings.logGraw) { wLogStream.WriteLine("GRAW,{0},{1},{2},{3},{4},{5}", mw_gui.ax, mw_gui.ay, mw_gui.az, mw_gui.gx, mw_gui.gy, mw_gui.gz); }
                //Attitude
                if (gui_settings.logGatt) { wLogStream.WriteLine("GATT,{0},{1}",mw_gui.angx,mw_gui.angy);}
                //Mag, head, baro
                if (gui_settings.logGmag) { wLogStream.WriteLine("GMAG,{0},{1},{2},{3},{4}", mw_gui.magx, mw_gui.magy, mw_gui.magz, mw_gui.heading, mw_gui.baro);}
                //RC controls 
                if (gui_settings.logGrcc) { wLogStream.WriteLine("GRCC,{0},{1},{2},{3}",mw_gui.rcThrottle, mw_gui.rcPitch, mw_gui.rcRoll, mw_gui.rcYaw);}
                //RC Aux controls
                if (gui_settings.logGrcx) { wLogStream.WriteLine("GRCX,{0},{1},{2},{3}",mw_gui.rcAux1, mw_gui.rcAux2, mw_gui.rcAux3, mw_gui.rcAux4);}
                //Motors
                if (gui_settings.logGmot) { wLogStream.WriteLine("GMOT,{0},{1},{2},{3},{4},{5},{6},{7}", mw_gui.motors[0], mw_gui.motors[1], mw_gui.motors[2], mw_gui.motors[3], mw_gui.motors[4], mw_gui.motors[5], mw_gui.motors[6], mw_gui.motors[7]);}
                //Servos
                if (gui_settings.logGsrv) { wLogStream.WriteLine("GSRV,{0},{1},{2},{3},{4},{5},{6},{7}", mw_gui.servos[0], mw_gui.servos[1], mw_gui.servos[2], mw_gui.servos[3], mw_gui.servos[4], mw_gui.servos[5], mw_gui.servos[6], mw_gui.servos[7]);}
                // Nav-GPS
                if (gui_settings.logGnav) { wLogStream.WriteLine("GNAV,{0},{1},{2},{3}", mw_gui.GPS_fix, mw_gui.GPS_numSat, mw_gui.GPS_directionToHome, mw_gui.GPS_distanceToHome);}
                // Housekeeping
                if (gui_settings.logGpar) { wLogStream.WriteLine("GPAR,{0},{1},{2},{3}", mw_gui.cycleTime,mw_gui.i2cErrors, mw_gui.vBat, mw_gui.pMeterSum);}
                //Debug
                if (gui_settings.logGdbg) { wLogStream.WriteLine("GDBG,{0},{1},{2},{3}", mw_gui.debug1, mw_gui.debug2, mw_gui.debug3, mw_gui.debug4); }
            }



            if (tabMain.SelectedIndex == 0 | tabMain.SelectedIndex == 1)        //Common tasks for both panel
            {
                if (bOptions_needs_refresh)
                {
                    update_pid_panel();
                    update_aux_panel();
                    bOptions_needs_refresh = false;
                }
            }

            if (tabMain.SelectedIndex == 1)
            {
                //update RC control values
                rci_Control_settings.SetRCInputParameters(mw_gui.rcThrottle, mw_gui.rcPitch, mw_gui.rcRoll, mw_gui.rcYaw, mw_gui.rcAux1, mw_gui.rcAux2, mw_gui.rcAux3, mw_gui.rcAux4);
                //Show LMH postions above switches
                lmh_labels[0, 0].BackColor = (mw_gui.rcAux1 < rcLow) ? Color.Green : Color.Transparent;
                lmh_labels[0, 1].BackColor = (mw_gui.rcAux1 > rcLow && mw_gui.rcAux1 < rcMid) ? Color.Green : Color.Transparent;
                lmh_labels[0, 2].BackColor = (mw_gui.rcAux1 > rcMid) ? Color.Green : Color.Transparent;

                lmh_labels[1, 0].BackColor = (mw_gui.rcAux2 < rcLow) ? Color.Green : Color.Transparent;
                lmh_labels[1, 1].BackColor = (mw_gui.rcAux2 > rcLow && mw_gui.rcAux2 < rcMid) ? Color.Green : Color.Transparent;
                lmh_labels[1, 2].BackColor = (mw_gui.rcAux2 > rcMid) ? Color.Green : Color.Transparent;

                lmh_labels[2, 0].BackColor = (mw_gui.rcAux3 < rcLow) ? Color.Green : Color.Transparent;
                lmh_labels[2, 1].BackColor = (mw_gui.rcAux3 > rcLow && mw_gui.rcAux3 < rcMid) ? Color.Green : Color.Transparent;
                lmh_labels[2, 2].BackColor = (mw_gui.rcAux3 > rcMid) ? Color.Green : Color.Transparent;

                lmh_labels[3, 0].BackColor = (mw_gui.rcAux4 < rcLow) ? Color.Green : Color.Transparent;
                lmh_labels[3, 1].BackColor = (mw_gui.rcAux4 > rcLow && mw_gui.rcAux4 < rcMid) ? Color.Green : Color.Transparent;
                lmh_labels[3, 2].BackColor = (mw_gui.rcAux4 > rcMid) ? Color.Green : Color.Transparent;

                //evaluate rc_options and recolor mode which supposed to be ON at the current rc values
                byte act1, act2, opt1, opt2;

                //Construct options switch mask based on rcAux input
                opt1 = (byte)(Convert.ToByte(mw_gui.rcAux1 < 1300) + Convert.ToByte(1300 < mw_gui.rcAux1 && mw_gui.rcAux1 < 1700) * 2 + Convert.ToByte(mw_gui.rcAux1 > 1700) * 4 + Convert.ToByte(mw_gui.rcAux2 < 1300) * 8 + Convert.ToByte(1300 < mw_gui.rcAux2 && mw_gui.rcAux2 < 1700) * 16 + Convert.ToByte(mw_gui.rcAux2 > 1700) * 32);
                opt2 = (byte)(Convert.ToByte(mw_gui.rcAux3 < 1300) + Convert.ToByte(1300 < mw_gui.rcAux3 && mw_gui.rcAux3 < 1700) * 2 + Convert.ToByte(mw_gui.rcAux3 > 1700) * 4 + Convert.ToByte(mw_gui.rcAux4 < 1300) * 8 + Convert.ToByte(1300 < mw_gui.rcAux4 && mw_gui.rcAux4 < 1700) * 16 + Convert.ToByte(mw_gui.rcAux4 > 1700) * 32);

                //Compare with switchbox settings
                for (int b = 0; b < iCheckBoxItems; b++)
                {
                    act1 = 0; act2 = 0;
                    for (byte a = 0; a < 3; a++)
                    {
                        if (aux[0, a, b].Checked) act1 += (byte)(1 << a);
                        if (aux[1, a, b].Checked) act1 += (byte)(1 << (3 + a));
                        if (aux[2, a, b].Checked) act2 += (byte)(1 << a);
                        if (aux[3, a, b].Checked) act2 += (byte)(1 << (3 + a));
                    }
                    //Highlight active function name
                    if ((opt1 & act1) != 0 || (opt2 & act2) != 0) { cb_labels[b].BackColor = Color.Red; cb_labels[b].ForeColor = Color.Yellow; } else { cb_labels[b].BackColor = Color.Transparent; cb_labels[b].ForeColor = Color.White; }
                }
            }

            if (tabMain.SelectedIndex == 2)
            {

                if (cb_acc_roll.Checked) { list_acc_roll.Add((double)xTimeStamp, mw_gui.ax); }
                l_acc_roll.Text = "" + mw_gui.ax;

                if (cb_acc_pitch.Checked) { list_acc_pitch.Add((double)xTimeStamp, mw_gui.ay); }
                l_acc_pitch.Text = "" + mw_gui.ay;

                if (cb_acc_z.Checked) { list_acc_z.Add((double)xTimeStamp, mw_gui.az); }
                l_acc_z.Text = "" + mw_gui.az;

                if (cb_gyro_roll.Checked) { list_gyro_roll.Add((double)xTimeStamp, mw_gui.gx); }
                l_gyro_roll.Text = "" + mw_gui.gx;

                if (cb_gyro_pitch.Checked) { list_gyro_pitch.Add((double)xTimeStamp, mw_gui.gy); }
                l_gyro_pitch.Text = "" + mw_gui.gy;

                if (cb_gyro_yaw.Checked) { list_gyro_yaw.Add((double)xTimeStamp, mw_gui.gz); }
                l_gyro_yaw.Text = "" + mw_gui.gz;

                if (cb_mag_roll.Checked) { list_mag_roll.Add((double)xTimeStamp, mw_gui.magx); }
                l_mag_roll.Text = "" + mw_gui.magx;

                if (cb_mag_pitch.Checked) { list_mag_pitch.Add((double)xTimeStamp, mw_gui.magy); }
                l_mag_pitch.Text = "" + mw_gui.magy;

                if (cb_mag_yaw.Checked) { list_mag_yaw.Add((double)xTimeStamp, mw_gui.magz); }
                l_mag_yaw.Text = "" + mw_gui.magz;

                if (cb_alt.Checked) { list_alt.Add((double)xTimeStamp, mw_gui.baro); }
                l_alt.Text = "" + mw_gui.baro;

                if (cb_head.Checked) { list_head.Add((double)xTimeStamp, mw_gui.heading); }
                l_head.Text = "" + mw_gui.heading;

                if (cb_dbg1.Checked) { list_dbg1.Add((double)xTimeStamp, mw_gui.debug1); }
                l_dbg1.Text = "" + mw_gui.debug1;

                if (cb_dbg2.Checked) { list_dbg2.Add((double)xTimeStamp, mw_gui.debug2); }
                l_dbg2.Text = "" + mw_gui.debug2;

                if (cb_dbg3.Checked) { list_dbg3.Add((double)xTimeStamp, mw_gui.debug3); }
                l_dbg3.Text = "" + mw_gui.debug3;

                if (cb_dbg4.Checked) { list_dbg4.Add((double)xTimeStamp, mw_gui.debug4); }
                l_dbg4.Text = "" + mw_gui.debug4;


                xTimeStamp = xTimeStamp + 1;

                if (xTimeStamp > xScale.Max)
                {
                    double range = xScale.Max - xScale.Min;
                    xScale.Max = xScale.Max + 1;
                    xScale.Min = xScale.Max - range;
                }
                zgMonitor.AxisChange();
                zgMonitor.Invalidate();

                rc_input_control1.SetRCInputParameters(mw_gui.rcThrottle, mw_gui.rcPitch, mw_gui.rcRoll, mw_gui.rcYaw, mw_gui.rcAux1, mw_gui.rcAux2, mw_gui.rcAux3, mw_gui.rcAux4);

                curve_acc_roll.IsVisible = cb_acc_roll.Checked;
                curve_acc_pitch.IsVisible = cb_acc_pitch.Checked;
                curve_acc_z.IsVisible = cb_acc_z.Checked;
                curve_gyro_roll.IsVisible = cb_gyro_roll.Checked;
                curve_gyro_pitch.IsVisible = cb_gyro_pitch.Checked;
                curve_gyro_yaw.IsVisible = cb_gyro_yaw.Checked;
                curve_mag_roll.IsVisible = cb_mag_roll.Checked;
                curve_mag_pitch.IsVisible = cb_mag_pitch.Checked;
                curve_mag_yaw.IsVisible = cb_mag_yaw.Checked;
                curve_alt.IsVisible = cb_alt.Checked;
                curve_head.IsVisible = cb_head.Checked;


                headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(mw_gui.heading);
                attitudeIndicatorInstrumentControl1.SetArtificalHorizon(-mw_gui.angy, -mw_gui.angx);
                gpsIndicator.SetGPSIndicatorParameters(mw_gui.GPS_directionToHome, mw_gui.GPS_distanceToHome, mw_gui.GPS_numSat, Convert.ToBoolean(mw_gui.GPS_fix), true, Convert.ToBoolean(mw_gui.GPS_update));

                motorsIndicator1.SetMotorsIndicatorParameters(mw_gui.motors, mw_gui.servos, mw_gui.multiType);




                //update indicator lamps
                indNUNCHUK.SetStatus((mw_gui.present & 1) != 0);
                indACC.SetStatus((mw_gui.present & 2) != 0);
                indBARO.SetStatus((mw_gui.present & 4) != 0);
                indMAG.SetStatus((mw_gui.present & 8) != 0);
                indGPS.SetStatus((mw_gui.present & 16) != 0);

                
                //Update mode lamps
                if (gui_settings.iSoftwareVersion == 19)
                {
                    indLEVEL.SetStatus((mw_gui.mode & 1) != 0);             //0
                    indALTHOLD.SetStatus((mw_gui.mode & 2) != 0);           //1
                    indHHOLD.SetStatus((mw_gui.mode & 4) != 0);             //2
                    indRTH.SetStatus((mw_gui.mode & 8) != 0);               //3
                    indPOS.SetStatus((mw_gui.mode & 16) != 0);              //4
                    indARM.SetStatus((mw_gui.mode & 32) != 0);              //5
                    indHFREE.SetStatus((mw_gui.mode & 64) != 0);            //6
                }
                if (gui_settings.iSoftwareVersion == 20)
                {
                    indLEVEL.SetStatus((mw_gui.activation2[0] & 128) != 0);             //0
                    indALTHOLD.SetStatus((mw_gui.activation2[1] & 128) != 0);           //1
                    indHHOLD.SetStatus((mw_gui.activation2[2] & 128) != 0);             //2
                    indRTH.SetStatus((mw_gui.activation2[6] & 128) != 0);
                    indPOS.SetStatus((mw_gui.activation2[7] & 128) != 0);
                    indARM.SetStatus((mw_gui.activation2[5] & 128) != 0);
                    indHFREE.SetStatus((mw_gui.activation2[9] & 128) != 0);
                    indPASST.SetStatus((mw_gui.activation2[8] & 128) != 0);
                }

                l_cycletime.Text = String.Format("{0:0000} µs", mw_gui.cycleTime);
                l_vbatt.Text = String.Format("{0:0.0} volts", (double)mw_gui.vBat / 10);
                l_powersum.Text = String.Format("{0:0}", mw_gui.pMeterSum);
                l_i2cerrors.Text = String.Format("{0:0}",mw_gui.i2cErrors);

            } //end if tab=realtime;
        }

        private void b_reread_rc_options_Click(object sender, EventArgs e)
        {
            bOptions_needs_refresh = false;
        }

        private void aux_checked_changed_event(object sender, EventArgs e)
        {
            CheckBoxEx cb = ((CheckBoxEx)(sender));

            if (cb.aux < 2) { cb.IsHighlighted = cb.Checked == ((byte)(mw_gui.activation1[cb.item] & (1 << cb.aux * 3 + cb.rclevel)) == 0) ? true : false; }
            else { cb.IsHighlighted = cb.Checked == ((byte)(mw_gui.activation2[cb.item] & (1 << (cb.aux - 2) * 3 + cb.rclevel)) == 0) ? true : false; }
        }

        private void b_stop_live_rc_Click(object sender, EventArgs e)
        {
            isPausedRC = !isPausedRC;
            if (isPausedRC)
            {
                b_pause.ForeColor = Color.Red;
                b_stop_live_rc.Text = "Start Live Read";
                timer_rc.Stop();
                //System.Threading.Thread.Sleep(300);         //Wait for 1 cycle to let backgroundworker finish it's last job.
                //Cleanup highlighting
                //for (int b = 0; b < iCheckBoxItems; b++) { cb_labels[b].BackColor = Color.Transparent; }
                //for (int a = 0; a < 4; a++) { for (int b = 0; b < 3; b++) { lmh_labels[a, b].BackColor = Color.Transparent; } }
                rci_Control_settings.SetRCInputParameters(0, 0, 0, 0, 0, 0, 0, 0);

            }
            else
            {
                b_pause.ForeColor = Color.Black;
                b_stop_live_rc.Text = "Stop Live Read";
                if (isConnected) { timer_rc.Start(); }
            }
        }

        private void b_cal_acc_Click(object sender, EventArgs e)
        {


            if (!isConnected)
            {
                MessageBoxEx.Show(this, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBoxEx.Show(this, "Make sure that your copter is leveled!\r\nPress OK when ready, then keep copter steady for 5 seconds.", "Calibrating Accelerometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                serialPort.Write("S");
            }

        }

        private void b_cal_mag_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBoxEx.Show(this, "You have to connect to the FC first!", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBoxEx.Show(this, "After pressing OK please rotate your copter around all three axes\r\n at least a full 360° turn for each axes. You will have 1 minute to finish", "Calibrating Magnetometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                serialPort.Write("E");
            }
        }

        private void b_read_settings_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                bOptions_needs_refresh = true;
                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }
            }
        }

        private void update_params()
        {
            //Get parameters from GUI

            mw_params.pidP[PID_ROLL] = (byte)(nPID_roll_p.Value * 10);
            mw_params.pidI[PID_ROLL] = (byte)(nPID_roll_i.Value * 1000);
            mw_params.pidD[PID_ROLL] = (byte)(nPID_roll_d.Value);

            mw_params.pidP[PID_PITCH] = (byte)(nPID_pitch_p.Value * 10);
            mw_params.pidI[PID_PITCH] = (byte)(nPID_pitch_i.Value * 1000);
            mw_params.pidD[PID_PITCH] = (byte)(nPID_pitch_d.Value);

            mw_params.pidP[PID_YAW] = (byte)(nPID_yaw_p.Value * 10);
            mw_params.pidI[PID_YAW] = (byte)(nPID_yaw_i.Value * 1000);
            mw_params.pidD[PID_YAW] = (byte)(nPID_yaw_d.Value);

            mw_params.pidP[PID_ALT] = (byte)(nPID_alt_p.Value * 10);
            mw_params.pidI[PID_ALT] = (byte)(nPID_alt_i.Value * 1000);
            mw_params.pidD[PID_ALT] = (byte)(nPID_alt_d.Value);

            mw_params.pidP[PID_VEL] = (byte)(nPID_vel_p.Value * 10);
            mw_params.pidI[PID_VEL] = (byte)(nPID_vel_i.Value * 1000);
            mw_params.pidD[PID_VEL] = (byte)(nPID_vel_d.Value);

            if (gui_settings.iSoftwareVersion == 20)
            {
                mw_params.pidP[PID_GPS] = (byte)(nPID_gps_p.Value * 10);
                mw_params.pidI[PID_GPS] = (byte)(nPID_gps_i.Value * 1000);
                mw_params.pidD[PID_GPS] = (byte)(nPID_gps_d.Value);
            }

            mw_params.pidP[PID_LEVEL] = (byte)(nPID_level_p.Value * 10);
            mw_params.pidI[PID_LEVEL] = (byte)(nPID_level_i.Value * 1000);
            if (gui_settings.iSoftwareVersion == 20) { mw_params.pidD[PID_LEVEL] = (byte)(nPID_level_d.Value); }


            mw_params.pidP[PID_MAG] = (byte)(nPID_mag_p.Value * 10);

            mw_params.RollPitchRate = (byte)(nRATE_rp.Value * 100);
            mw_params.YawRate = (byte)(nRATE_yaw.Value * 100);
            mw_params.DynThrPID = (byte)(nRATE_tpid.Value * 100);

            mw_params.rcExpo = (byte)(nRCExpo.Value * 100);
            mw_params.rcRate = (byte)(nRCRate.Value * 50);

            mw_params.PowerTrigger = (int)nPAlarm.Value;

            for (int b = 0; b < iCheckBoxItems; b++)
            {
                mw_params.activation1[b] = 0;
                mw_params.activation2[b] = 0;
                for (byte a = 0; a < 3; a++)
                {
                    if (aux[0, a, b].Checked) mw_params.activation1[b] += (byte)(1 << a);
                    if (aux[1, a, b].Checked) mw_params.activation1[b] += (byte)(1 << (3 + a));
                    if (aux[2, a, b].Checked) mw_params.activation2[b] += (byte)(1 << a);
                    if (aux[3, a, b].Checked) mw_params.activation2[b] += (byte)(1 << (3 + a));

                }
            }
            mw_params.comment = tComment.Text;
        }

        private void write_parameters()
        {

            bool timer_rc_state = timer_rc.Enabled;
            bool timer_rt_state = timer_realtime.Enabled;

            //Stop all timers
            timer_realtime.Stop();
            timer_rc.Stop();
            while (bkgWorker.IsBusy)                    //Wait bkgWorker to completed
            {
                Application.DoEvents();
            }
            update_params();                            //update parameters object from GUI controls.
            mw_params.write_settings(serialPort);
            System.Threading.Thread.Sleep(1000);
            //Invalidate gui parameters and reread those values
            bOptions_needs_refresh = true;
            while (bkgWorker.IsBusy)
            {
                Application.DoEvents();
            }
            bkgWorker.RunWorkerAsync();

            timer_rc.Enabled = timer_rc_state;
            timer_realtime.Enabled = timer_rt_state;

        }

        private void b_write_settings_Click(object sender, EventArgs e)
        {

            write_parameters();

        }

        private void update_aux_panel()
        {

            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_gui.activation1[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_gui.activation1[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_gui.activation1[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_gui.activation1[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_gui.activation1[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_gui.activation1[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_gui.activation2[i] & (1 << 0)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_gui.activation2[i] & (1 << 1)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_gui.activation2[i] & (1 << 2)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_gui.activation2[i] & (1 << 3)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_gui.activation2[i] & (1 << 4)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_gui.activation2[i] & (1 << 5)) == 0 ? false : true;
            }

            for (int i = 0; i < iCheckBoxItems; i++)
            {

                aux[0, 0, i].IsHighlighted = (aux[0, 0, i].Checked == ((mw_gui.activation1[i] & (1 << 0)) == 0)) ? true : false;
                aux[0, 1, i].IsHighlighted = (aux[0, 1, i].Checked == ((mw_gui.activation1[i] & (1 << 1)) == 0)) ? true : false;
                aux[0, 2, i].IsHighlighted = (aux[0, 2, i].Checked == ((mw_gui.activation1[i] & (1 << 2)) == 0)) ? true : false;
                aux[1, 0, i].IsHighlighted = (aux[1, 0, i].Checked == ((mw_gui.activation1[i] & (1 << 3)) == 0)) ? true : false;
                aux[1, 1, i].IsHighlighted = (aux[1, 1, i].Checked == ((mw_gui.activation1[i] & (1 << 4)) == 0)) ? true : false;
                aux[1, 2, i].IsHighlighted = (aux[1, 2, i].Checked == ((mw_gui.activation1[i] & (1 << 5)) == 0)) ? true : false;
                aux[2, 0, i].IsHighlighted = (aux[2, 0, i].Checked == ((mw_gui.activation2[i] & (1 << 0)) == 0)) ? true : false;
                aux[2, 1, i].IsHighlighted = (aux[2, 1, i].Checked == ((mw_gui.activation2[i] & (1 << 1)) == 0)) ? true : false;
                aux[2, 2, i].IsHighlighted = (aux[2, 2, i].Checked == ((mw_gui.activation2[i] & (1 << 2)) == 0)) ? true : false;
                aux[3, 0, i].IsHighlighted = (aux[3, 0, i].Checked == ((mw_gui.activation2[i] & (1 << 3)) == 0)) ? true : false;
                aux[3, 1, i].IsHighlighted = (aux[3, 1, i].Checked == ((mw_gui.activation2[i] & (1 << 4)) == 0)) ? true : false;
                aux[3, 2, i].IsHighlighted = (aux[3, 2, i].Checked == ((mw_gui.activation2[i] & (1 << 5)) == 0)) ? true : false;
            }


        }

        private void update_pid_panel()
        {
            //fill out PID values from mw_gui. structure
            nPID_roll_p.Value = (decimal)mw_gui.pidP[PID_ROLL] / 10;
            nPID_roll_i.Value = (decimal)mw_gui.pidI[PID_ROLL] / 1000;
            nPID_roll_d.Value = mw_gui.pidD[PID_ROLL];

            nPID_pitch_p.Value = (decimal)mw_gui.pidP[PID_PITCH] / 10;
            nPID_pitch_i.Value = (decimal)mw_gui.pidI[PID_PITCH] / 1000;
            nPID_pitch_d.Value = mw_gui.pidD[PID_PITCH];

            nPID_yaw_p.Value = (decimal)mw_gui.pidP[PID_YAW] / 10;
            nPID_yaw_i.Value = (decimal)mw_gui.pidI[PID_YAW] / 1000;
            nPID_yaw_d.Value = mw_gui.pidD[PID_YAW];

            nPID_alt_p.Value = (decimal)mw_gui.pidP[PID_ALT] / 10;
            nPID_alt_i.Value = (decimal)mw_gui.pidI[PID_ALT] / 1000;
            nPID_alt_d.Value = mw_gui.pidD[PID_ALT];

            nPID_vel_p.Value = (decimal)mw_gui.pidP[PID_VEL] / 10;
            nPID_vel_i.Value = (decimal)mw_gui.pidI[PID_VEL] / 1000;
            nPID_vel_d.Value = mw_gui.pidD[PID_VEL];

            if (gui_settings.iSoftwareVersion == 20)
            {
                nPID_gps_p.Value = (decimal)mw_gui.pidP[PID_GPS] / 10;
                nPID_gps_i.Value = (decimal)mw_gui.pidI[PID_GPS] / 1000;
                nPID_gps_d.Value = mw_gui.pidD[PID_GPS];
            }

            nPID_level_p.Value = (decimal)mw_gui.pidP[PID_LEVEL] / 10;
            nPID_level_i.Value = (decimal)mw_gui.pidI[PID_LEVEL] / 1000;
            if (gui_settings.iSoftwareVersion == 20) { nPID_level_d.Value = (decimal)mw_gui.pidD[PID_LEVEL]; }

            nPID_mag_p.Value = (decimal)mw_gui.pidP[PID_MAG] / 10;

            nRATE_rp.Value = (decimal)mw_gui.RollPitchRate / 100;
            nRATE_yaw.Value = (decimal)mw_gui.YawRate / 100;
            nRATE_tpid.Value = (decimal)mw_gui.DynThrPID / 100;

            trackbar_RC_Expo.Value = mw_gui.rcExpo;
            nRCExpo.Value = (decimal)mw_gui.rcExpo / 100;
            trackbar_RC_Rate.Value = mw_gui.rcRate;
            nRCRate.Value = (decimal)mw_gui.rcRate / 50;
            rc_expo_control1.SetRCExpoParameters((double)mw_gui.rcRate / 50, (double)mw_gui.rcExpo / 100);

            nPAlarm.Value = mw_gui.powerTrigger;



        }

        private void update_gui_from_params()
        {
            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_params.activation1[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_params.activation1[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_params.activation1[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_params.activation1[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_params.activation1[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_params.activation1[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_params.activation2[i] & (1 << 0)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_params.activation2[i] & (1 << 1)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_params.activation2[i] & (1 << 2)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_params.activation2[i] & (1 << 3)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_params.activation2[i] & (1 << 4)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_params.activation2[i] & (1 << 5)) == 0 ? false : true;
            }
            //fill out PID values from mw_gui. structure
            nPID_roll_p.Value = (decimal)mw_params.pidP[PID_ROLL] / 10;
            nPID_roll_i.Value = (decimal)mw_params.pidI[PID_ROLL] / 1000;
            nPID_roll_d.Value = mw_params.pidD[PID_ROLL];

            nPID_pitch_p.Value = (decimal)mw_params.pidP[PID_PITCH] / 10;
            nPID_pitch_i.Value = (decimal)mw_params.pidI[PID_PITCH] / 1000;
            nPID_pitch_d.Value = mw_params.pidD[PID_PITCH];

            nPID_yaw_p.Value = (decimal)mw_params.pidP[PID_YAW] / 10;
            nPID_yaw_i.Value = (decimal)mw_params.pidI[PID_YAW] / 1000;
            nPID_yaw_d.Value = mw_params.pidD[PID_YAW];

            nPID_alt_p.Value = (decimal)mw_params.pidP[PID_ALT] / 10;
            nPID_alt_i.Value = (decimal)mw_params.pidI[PID_ALT] / 1000;
            nPID_alt_d.Value = mw_params.pidD[PID_ALT];

            nPID_vel_p.Value = (decimal)mw_params.pidP[PID_VEL] / 10;
            nPID_vel_i.Value = (decimal)mw_params.pidI[PID_VEL] / 1000;
            nPID_vel_d.Value = mw_params.pidD[PID_VEL];

            if (gui_settings.iSoftwareVersion == 20)
            {
                nPID_gps_p.Value = (decimal)mw_params.pidP[PID_GPS] / 10;
                nPID_gps_i.Value = (decimal)mw_params.pidI[PID_GPS] / 1000;
                nPID_gps_d.Value = mw_params.pidD[PID_GPS];
            }

            nPID_level_p.Value = (decimal)mw_params.pidP[PID_LEVEL] / 10;
            nPID_level_i.Value = (decimal)mw_params.pidI[PID_LEVEL] / 1000;
            if (gui_settings.iSoftwareVersion == 20) { nPID_level_d.Value = (decimal)mw_params.pidD[PID_LEVEL]; }

            nPID_mag_p.Value = (decimal)mw_params.pidP[PID_MAG] / 10;

            nRATE_rp.Value = (decimal)mw_params.RollPitchRate / 100;
            nRATE_yaw.Value = (decimal)mw_params.YawRate / 100;
            nRATE_tpid.Value = (decimal)mw_params.DynThrPID / 100;

            trackbar_RC_Expo.Value = mw_params.rcExpo;
            nRCExpo.Value = (decimal)mw_params.rcExpo / 100;
            trackbar_RC_Rate.Value = mw_params.rcRate;
            nRCRate.Value = (decimal)mw_params.rcRate / 50;
            rc_expo_control1.SetRCExpoParameters((double)mw_params.rcRate / 50, (double)mw_params.rcExpo / 100);

            nPAlarm.Value = mw_params.PowerTrigger;

            tComment.Text = mw_params.comment;

        }

        private void b_write_to_file_Click(object sender, EventArgs e)
        {
            update_params();                    //Move values from GUI to the settings object
            SaveFileDialog sfdSaveParameters = new SaveFileDialog();
            sfdSaveParameters.Filter = "MultiWii Settings File|*.mws";
            sfdSaveParameters.Title = "Save parameters to file";
            sfdSaveParameters.InitialDirectory = gui_settings.sSettingsFolder;

            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0} ]+", invalidChars);
            string fn = Regex.Replace(tComment.Text, invalidReStr, "_");
            fn = fn + String.Format("{0:yymmdd-hhmm}", DateTime.Now);
            sfdSaveParameters.FileName = fn;


            sfdSaveParameters.ShowDialog();

            if (sfdSaveParameters.FileName != "")
            {
                mw_params.save_to_xml(sfdSaveParameters.FileName);
            }
        }

        private void b_load_from_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdLoadParameters = new OpenFileDialog();
            ofdLoadParameters.Filter = "MultiWii Settings File|*.mws";
            ofdLoadParameters.Title = "Load parameters from file";
            ofdLoadParameters.InitialDirectory = gui_settings.sSettingsFolder;
            if (ofdLoadParameters.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { //we have file to open
                if (mw_params.read_from_xml(ofdLoadParameters.FileName))
                { update_gui_from_params(); }
            }

        }

        private void mainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer_realtime.Stop();                       //Stop timer(s), whatever it takes
            timer_rc.Stop();
            System.Threading.Thread.Sleep(iRefreshIntervals[cb_monitor_rate.SelectedIndex] + 200);         //Wait for 1 cycle to let backgroundworker finish it's last job.
            if (isConnected) { serialPort.Close(); }

            if (bVideoRecording)          //If recording stop it.
            {
                vfwWriter.Close();
            }

            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();

        }
        // Open video source
        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // close previous video source
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();

            // start new video source
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();

            this.Cursor = Cursors.Default;
        }

        // New frame received
        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            //                    Graphics g = Graphics.FromImage( image );


            if (bVideoRecording == true)
            {
                tsFrameTimeStamp = tsFrameTimeStamp.Add(tsFrameRate);
                if (vfwWriter != null) { vfwWriter.WriteVideoFrame(image,tsFrameTimeStamp); }
            }

            //                   g.Dispose( );
        }

        private void b_video_connect_Click(object sender, EventArgs e)
        {

            if (!bVideoConnected)
            {
                // create video source
                videoSource = new VideoCaptureDevice(videoDevices[dropdown_devices.SelectedIndex].MonikerString);
                videoSource.DesiredFrameRate = (int)nFrameRate.Value;
                // open it
                OpenVideoSource(videoSource);
                bVideoConnected = true;
                b_video_connect.Text = "Disconnect video device";
            }
            else
            {
                if (bVideoRecording) { vfwWriter.Close(); }
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                b_video_connect.Text = "Connect video device";
                bVideoConnected = false;

            }
        }

        private void b_Record_Click(object sender, EventArgs e)
        {
            if (bVideoConnected)
            {
                if (bVideoRecording == false)
                {
                    if (vfwWriter != null) { vfwWriter.Close(); }

                    l_capture_file.Text = "capture" + String.Format("-{0:yymmdd-hhmm}", DateTime.Now);
                    vfwWriter = new VideoFileWriter();
                    //create new video file
                    vfwWriter.Open(gui_settings.sCaptureFolder + "\\capture" + String.Format("-{0:yymmdd-hhmm}", DateTime.Now) + ".avi", 640, 480, (int)nFrameRate.Value, (VideoCodec)cb_codec.SelectedIndex, (int)(1000000 * nBitRate.Value));
                    b_Record.Text = "Recording";
                    b_Record.BackColor = Color.Red;
                    tsFrameTimeStamp = new TimeSpan(0);
                    tsFrameRate = new TimeSpan(10000000 / (long)nFrameRate.Value);
                    bVideoRecording = true;
                }
                else
                {
                    bVideoRecording = false;
                    System.Threading.Thread.Sleep(50);
                    b_Record.Text = "Start Recording";
                    b_Record.BackColor = Color.Transparent;
                    vfwWriter.Close();
                    l_capture_file.Text = "";
                }
            }
        }

        private void b_select_log_folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sLogFolder = folderBrowserDialog1.SelectedPath;
                l_LogFolder.Text = gui_settings.sLogFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }

        }

        private void b_select_capture_folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sCaptureFolder = folderBrowserDialog1.SelectedPath;
                l_Capture_folder.Text = gui_settings.sCaptureFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }
        }

        private void b_select_settings_folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sSettingsFolder = folderBrowserDialog1.SelectedPath;
                l_Settings_folder.Text = gui_settings.sSettingsFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }

        }


        private void b_save_gui_settings_Click(object sender, EventArgs e)
        {

            if (rb_sw19.Checked) { gui_settings.iSoftwareVersion = 19; }
            if (rb_sw20.Checked) { gui_settings.iSoftwareVersion = 20; }
            gui_settings.save_to_xml(sGuiSettingsFilename);
            b_save_gui_settings.BackColor = Color.Transparent;
            //Save settings to the settings file


            //Check if restart needed
            if (bRestartNeeded)
            {
                MessageBoxEx.Show(this, "For changing MultiWii FC SW version, you have to restart MultiWiiWinGUI. Press OK to close this app, then please start it again manually", "MWWGUI Restart needed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(-1);
            }
        }

        private void rb_sw20_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sw20.Checked && gui_settings.iSoftwareVersion == 20) { bRestartNeeded = false; b_save_gui_settings.BackColor = Color.Transparent; return; }  //no change
            if (rb_sw19.Checked && gui_settings.iSoftwareVersion == 19) { bRestartNeeded = false; b_save_gui_settings.BackColor = Color.Transparent; return; }
            b_save_gui_settings.BackColor = Color.LightCoral;
            bRestartNeeded = true;                              //Restart required when changing MW Software version            

        }

        private void cb_Logging_enabled_Click(object sender, EventArgs e)
        {
            gui_settings.bEnableLogging = cb_Logging_enabled.Checked;
            b_save_gui_settings.BackColor = Color.LightCoral;
        }


        private void b_about_Click(object sender, EventArgs e)
        {
            frmAbout aboutform = new frmAbout();
            aboutform.sVersionLabel = sPublishVersion;
            if (gui_settings.iSoftwareVersion == 20) { aboutform.sFcVersionLabel = "MultiWii version " + sRelName20; }
            if (gui_settings.iSoftwareVersion == 19) { aboutform.sFcVersionLabel = "MultiWii version " + sRelName19; }
            aboutform.ShowDialog();
        }


        private void log_option_Clicked(object sender, EventArgs e)
        {
            gui_settings.logGraw = cb_Log1.Checked;
            gui_settings.logGatt = cb_Log2.Checked;
            gui_settings.logGmag = cb_Log3.Checked;
            gui_settings.logGrcc = cb_Log4.Checked;
            gui_settings.logGrcx = cb_Log5.Checked;
            gui_settings.logGmot = cb_Log6.Checked;
            gui_settings.logGsrv = cb_Log7.Checked;
            gui_settings.logGnav = cb_Log8.Checked;
            gui_settings.logGpar = cb_Log9.Checked;
            gui_settings.logGdbg = cb_Log10.Checked;
            b_save_gui_settings.BackColor = Color.LightCoral;
        }




    }

}
