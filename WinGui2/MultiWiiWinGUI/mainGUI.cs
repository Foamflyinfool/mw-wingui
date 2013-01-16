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
using System.Xml.Linq;
using System.Collections.Generic;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using MultiWiiGUIControls;
using ZedGraph;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Globalization;

namespace MultiWiiWinGUI
{

    public partial class mainGUI : Form
    {

        #region Common variables (properties)

        const string sVersion = "2.1";
        const string sVersionUrl = "http://mw-wingui.googlecode.com/svn/trunk/WinGui2/version.xml";
        private string sVersionFromSVN;
        private XDocument doc;

        static string sOptionsConfigFilename = "optionsconfig";
        const string sGuiSettingsFilename = "gui_settings.xml";
        enum CopterType { Tri = 1, QuadP, QuadX, BI, Gimbal, Y6, Hex6, FlyWing, Y4, Hex6X, Octo8Coax, Octo8P, Octo8X };

        string[] sSerialSpeeds = { "115200", "57600", "38400", "19200", "9600" };
        string[] sRefreshSpeeds = { "20 Hz", "10 Hz", "5 Hz", "2 Hz", "1 Hz" };
        int[] iRefreshIntervals = { 50, 100, 200, 500, 1000 };
        const int rcLow = 1300;
        const int rcMid = 1700;

        const string sRelName = "2.1";

        //PID values
        static PID[] Pid;


        static SerialPort serialPort;
        static bool isConnected = false;                        //is port connected or not ?
        static bool bSerialError = false;
        static bool isPaused = false;

        static int iRefreshDivider = 20;                         //This used to force slower refresh for certain parameters


        static int iSelectedTabIndex = 0;                          //Contains the actually selected tab
        static double xTimeStamp = 0;
        static byte[] bSerialBuffer;

        static int iCheckBoxItems = 0;                          //number of checkboxItems (readed from optionsconfig.xml
        static int iPidItems = 0;                                //number if Pid items (const definition)
        static mw_data_gui mw_gui;
        static mw_settings mw_params;
        static GUI_settings gui_settings;
        static bool bOptions_needs_refresh = true;
        static bool bRestartNeeded = false;                     //FC software version changed, must restart

        static string[] option_names;
        static string[] option_indicators;
        static string[] option_desc;

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
        indicator_lamp[] indicators;

        System.Windows.Forms.Label[] cb_labels;
        System.Windows.Forms.Label[] aux_labels;
        System.Windows.Forms.Label[,] lmh_labels;
        
        CultureInfo culture = new CultureInfo("en-US");


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


        static Pen drawPen;
        static System.Drawing.SolidBrush drawBrush;
        static System.Drawing.Font drawFont;

        //For logging
        StreamWriter wLogStream;
        StreamWriter wKMLLogStream;
        static bool bLogRunning = false;
        static bool bKMLLogRunning = false;

        static int GPS_lat_old, GPS_lon_old;
        static bool GPSPresent = true;


        //Map Overlays
        GMapOverlay overlayCopterPosition;
        GMapOverlay drawnpolygons;
        static GMapOverlay routes;// static so can update from gcs
        GMapOverlay markers;
        GMapOverlay polygons;
        GMapOverlay positions;
        
        
        static GMapProvider[] mapProviders;
        static PointLatLng copterPos = new PointLatLng(47.402489, 19.071558);       //Just the corrds of my flying place
        static bool isMouseDown = false;
        static bool isMouseDraging = false;

        static bool bPosholdRecorded = false;
        static bool bHomeRecorded = false;

        // marker
        GMapMarker currentMarker;
        GMapMarkerRect CurentRectMarker = null;
        GMapMarker center = new GMapMarkerCross(new PointLatLng(0.0, 0.0));

        GMapPolygon drawnpolygon;
        GMapPolygon polygon;


        // layers
        static GMapRoute Grout;
        List<PointLatLng> points = new List<PointLatLng>();

        GMapMarkerCross copterPosMarker;
        PointLatLng GPS_pos;
        PointLatLng end;
        PointLatLng start;


        //Commands
         const int MSP_IDENT                =100;

         const int MSP_STATUS               =101;
         const int MSP_RAW_IMU              =102;
         const int MSP_SERVO                =103;
         const int MSP_MOTOR                =104;
         const int MSP_RC                   =105;
         const int MSP_RAW_GPS              =106;
         const int MSP_COMP_GPS             =107;
         const int MSP_ATTITUDE             =108;
         const int MSP_ALTITUDE             =109;
         const int MSP_BAT                  =110;
         const int MSP_RC_TUNING            =111;
         const int MSP_PID                  =112;
         const int MSP_BOX                  =113;
         const int MSP_MISC                 =114;
         const int MSP_MOTOR_PINS = 115;
         const int MSP_BOXNAMES = 116;
         const int MSP_PIDNAMES = 117;
         const int MSP_WP = 118;


         const int MSP_SET_RAW_RC           =200;
         const int MSP_SET_RAW_GPS          =201;
         const int MSP_SET_PID              =202;
         const int MSP_SET_BOX              =203;
         const int MSP_SET_RC_TUNING        =204;
         const int MSP_ACC_CALIBRATION      =205;
         const int MSP_MAG_CALIBRATION      =206;
         const int MSP_SET_MISC             =207;
         const int MSP_RESET_CONF           =208;
         const int MSP_SET_WP = 209;

         const int MSP_EEPROM_WRITE         =250;
         const int MSP_DEBUG                =254;



          const byte IDLE = 0;
          const byte HEADER_START = 1;
          const byte HEADER_M = 2;
          const byte HEADER_ARROW = 3;
          const byte HEADER_SIZE = 4;
          const byte HEADER_CMD = 5;
          const byte HEADER_ERR = 6;

         static byte[] inBuf;


         static byte c_state = IDLE;
         static Boolean err_rcvd = false;
         static byte offset = 0;
         static byte dataSize = 0;
         static byte checksum = 0;
         static byte cmd;
         static int serial_error_count = 0;
         static int serial_packet_count = 0;


        #endregion

        public mainGUI()
        {
            InitializeComponent();
            #region map_setup
            // config map             
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 20;
            MainMap.CacheLocation = Path.GetDirectoryName(Application.ExecutablePath) + "/mapcache/";

            mapProviders = new GMapProvider[6];
            mapProviders[0] = GMapProviders.BingHybridMap;
            mapProviders[1] = GMapProviders.BingSatelliteMap;
            mapProviders[2] = GMapProviders.GoogleHybridMap;
            mapProviders[3] = GMapProviders.GoogleSatelliteMap;
            mapProviders[4] = GMapProviders.OviHybridMap;
            mapProviders[5] = GMapProviders.OviSatelliteMap;

            for (int i = 0; i < 6; i++)
            {
                cbMapProviders.Items.Add(mapProviders[i]);
            }


            // map events

            MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            //MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
            MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

            currentMarker = new GMapMarkerGoogleRed(MainMap.Position);
            MainMap.MapScaleInfoEnabled = true;

            MainMap.ForceDoubleBuffer = true;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;

            MainMap.Position = copterPos;

            Pen penRoute = new Pen(Color.Yellow, 3);
            Pen penScale = new Pen(Color.Blue, 3);

            MainMap.ScalePen = penScale;

            routes = new GMapOverlay(MainMap, "routes");
            MainMap.Overlays.Add(routes);

            drawnpolygons = new GMapOverlay(MainMap, "drawnpolygons");
            MainMap.Overlays.Add(drawnpolygons);

            markers = new GMapOverlay(MainMap, "objects");
            MainMap.Overlays.Add(markers);

            polygons = new GMapOverlay(MainMap, "polygons");
            MainMap.Overlays.Add(polygons);

            positions = new GMapOverlay(MainMap, "positions");
            MainMap.Overlays.Add(positions);

            positions.Markers.Clear();
            positions.Markers.Add(new GMapMarkerQuad(copterPos, 0, 0, 0));

            Grout = new GMapRoute(points, "track");
            Grout.Stroke = penRoute;
            routes.Routes.Add(Grout);

            center = new GMapMarkerCross(MainMap.Position);

            #endregion

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
            splash.sVersionLabel = sVersion;
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


            splash.sFcVersionLabel = "MultiWii version " + sRelName;
            splash.sStatus = "Connecting to MAP server...";
            splash.Refresh();




            //Quick hack to get pid names to mw_params untill redo the structures
            for (int i = 0; i < iPidItems; i++)
            {
                mw_params.pidnames[i] = Pid[i].name;
            }


            cbMapProviders.SelectedIndex = gui_settings.iMapProviderSelectedIndex;
            MainMap.MapProvider = mapProviders[gui_settings.iMapProviderSelectedIndex];
            tb_mapzoom.Value = MainMap.MaxZoom;
            MainMap.Zoom = MainMap.MaxZoom;

            splash.sStatus = "Building up GUI elements...";
            splash.Refresh();

            bSerialBuffer = new byte[65];
            inBuf = new byte[300];   //init input buffer

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //rcOptions1 = new byte[iCheckBoxItems];
            //rcOptions2 = new byte[iCheckBoxItems];

            //Fill out settings tab
            l_Capture_folder.Text = gui_settings.sCaptureFolder;
            l_LogFolder.Text = gui_settings.sLogFolder;
            l_Settings_folder.Text = gui_settings.sSettingsFolder;

            cb_Logging_enabled.Checked = gui_settings.bEnableLogging;

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

            //Build indicator lamps array
            indicators = new indicator_lamp[iCheckBoxItems];
            int row=0; int col=0;
            int startx =800; int starty = 3;
            for (int i=0;i<iCheckBoxItems;i++)
            {
                indicators[i] = new indicator_lamp();
                indicators[i].Location = new Point(startx + col * 52, starty + row * 19);
                indicators[i].Visible = true;
                indicators[i].Text = option_indicators[i];
                indicators[i].indicator_color = 1;
                indicators[i].Anchor = AnchorStyles.Right;
                this.splitContainer2.Panel2.Controls.Add(indicators[i]);
                col++;
                if (col == 3) { col = 0; row++; }
            }


            //Build the RC control checkboxes structure


            aux = new CheckBoxEx[4, 4, iCheckBoxItems];

            startx = 200;
            starty = 60;

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

            //Build PID control structure based on the Pid structure.

            const int iLineSpace = 36;
            const int iRow1 = 30;
            const int iRow2 = 125;
            const int iRow3 = 220;
            const int iTopY = 25;
            Font fontField = new Font("Tahoma", 9, FontStyle.Bold);
            Size fieldSize = new Size(70, 25);

            for (int i = 0; i < iPidItems; i++)
            {
                Pid[i].pidLabel = new System.Windows.Forms.Label();
                Pid[i].pidLabel.Text = Pid[i].name;
                Pid[i].pidLabel.Location = new Point(iRow1, 10 + i * iLineSpace);
                Pid[i].pidLabel.Visible = true;
                Pid[i].pidLabel.AutoSize = true;
                Pid[i].pidLabel.ForeColor = Color.White;
                Pid[i].pidLabel.TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(Pid[i].pidLabel, Pid[i].description);
                this.tabPagePID.Controls.Add(Pid[i].pidLabel);

                if (Pid[i].Pshown)
                {
                    Pid[i].Pfield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Pfield.ValueChanged += new EventHandler(pfield_valuechange);
                    Pid[i].Pfield.Location = new Point(iRow1, iTopY + i * iLineSpace);
                    Pid[i].Pfield.Size = fieldSize;
                    Pid[i].Pfield.Font = fontField;
                    Pid[i].Pfield.BorderStyle = BorderStyle.None;
                    Pid[i].Pfield.Maximum = Pid[i].Pmax;
                    Pid[i].Pfield.Minimum = Pid[i].Pmin;
                    Pid[i].Pfield.DecimalPlaces = decimals(Pid[i].Pprec);
                    Pid[i].Pfield.Increment = 1/(decimal)Pid[i].Pprec;
                    this.tabPagePID.Controls.Add(Pid[i].Pfield);

                    Pid[i].Plabel = new System.Windows.Forms.Label();
                    Pid[i].Plabel.Text = "P";
                    Pid[i].Plabel.Font = fontField;
                    Pid[i].Plabel.ForeColor = Color.White;
                    Pid[i].Plabel.Location = new Point(iRow1 - 20, iTopY + i * iLineSpace);
                    this.tabPagePID.Controls.Add(Pid[i].Plabel);



                }
                if (Pid[i].Ishown)
                {
                    Pid[i].Ifield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Ifield.ValueChanged += new EventHandler(ifield_valuechange);
                    Pid[i].Ifield.Location = new Point(iRow2, iTopY + i * iLineSpace);
                    Pid[i].Ifield.Size = fieldSize;
                    Pid[i].Ifield.Font = fontField;
                    Pid[i].Ifield.BorderStyle = BorderStyle.None;
                    Pid[i].Ifield.Maximum = Pid[i].Imax;
                    Pid[i].Ifield.Minimum = Pid[i].Imin;
                    Pid[i].Ifield.DecimalPlaces = decimals(Pid[i].Iprec);
                    Pid[i].Ifield.Increment = 1 / (decimal)Pid[i].Iprec;
                    this.tabPagePID.Controls.Add(Pid[i].Ifield);

                    Pid[i].Ilabel = new System.Windows.Forms.Label();
                    Pid[i].Ilabel.Text = "I";
                    Pid[i].Ilabel.Font = fontField;
                    Pid[i].Ilabel.ForeColor = Color.White;
                    Pid[i].Ilabel.Location = new Point(iRow2 - 20, iTopY + i * iLineSpace);
                    this.tabPagePID.Controls.Add(Pid[i].Ilabel);



                }
                if (Pid[i].Dshown)
                {
                    Pid[i].Dfield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Dfield.ValueChanged += new EventHandler(dfield_valuechange);
                    Pid[i].Dfield.Location = new Point(iRow3, iTopY + i * iLineSpace);
                    Pid[i].Dfield.Size = fieldSize;
                    Pid[i].Dfield.Font = fontField;
                    Pid[i].Dfield.BorderStyle = BorderStyle.None;
                    Pid[i].Dfield.Maximum = Pid[i].Dmax;
                    Pid[i].Dfield.Minimum = Pid[i].Dmin;
                    Pid[i].Dfield.DecimalPlaces = decimals(Pid[i].Dprec);
                    Pid[i].Dfield.Increment = 1 / (decimal)Pid[i].Dprec;
                    this.tabPagePID.Controls.Add(Pid[i].Dfield);

                    Pid[i].Dlabel = new System.Windows.Forms.Label();
                    Pid[i].Dlabel.Text = "D";
                    Pid[i].Dlabel.Font = fontField;
                    Pid[i].Dlabel.ForeColor = Color.White;
                    Pid[i].Dlabel.Location = new Point(iRow3-20, iTopY + i * iLineSpace);
                    this.tabPagePID.Controls.Add(Pid[i].Dlabel);

                }


            }


            toolTip1.SetToolTip(b_check_all_ACC, "Select all ACC values");
            toolTip1.SetToolTip(b_uncheck_all_ACC, "Deselect all ACC values");




            this.Refresh();




            serial_ports_enumerate();
            foreach (string speed in sSerialSpeeds)
            {
                cb_serial_speed.Items.Add(speed);
            }
            cb_serial_speed.SelectedItem = gui_settings.sPreferedSerialSpeed;

            if (cb_serial_port.Items.Count == 0)
            {
                b_connect.Enabled = false;          //Nos serial port, disable connect
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

            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = false;

            zgMonitor.IsEnableHPan = true;
            zgMonitor.IsEnableHZoom = true;

            foreach (ZedGraph.LineItem li in myPane.CurveList)
            {
                li.Line.Width = 1;
            }


            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 300;
            myPane.XAxis.Type = AxisType.Linear;
            
            
            
            zgMonitor.ScrollGrace = 0;
            xScale = zgMonitor.GraphPane.XAxis.Scale;
            zgMonitor.AxisChange();

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

            //Drawing stuff for OSD
            drawPen = new Pen(Color.White, 1);
            drawFont = new System.Drawing.Font(FontFamily.GenericMonospace, 16.0F);
            drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);


            //Disable buttons that are not working till connected
            b_reset.Enabled = false;
            b_cal_acc.Enabled = false;
            b_cal_mag.Enabled = false;
            b_read_settings.Enabled = false;
            b_write_settings.Enabled = false;


            //System.Threading.Thread.Sleep(2000);
            splash.Close();



        }


        private void timer_realtime_Tick(object sender, EventArgs e)
        {

            
            if (serialPort.BytesToRead == 0)
            {

                if ((iRefreshDivider % gui_settings.MSP_STATUS_rate_divider) == 0) MSPquery(MSP_STATUS);
                if ((iRefreshDivider % gui_settings.MSP_RAW_IMU_rate_divider) == 0) MSPquery(MSP_RAW_IMU);
                if ((iRefreshDivider % gui_settings.MSP_SERVO_rate_divider) == 0) MSPquery(MSP_SERVO);
                if ((iRefreshDivider % gui_settings.MSP_MOTOR_rate_divider) == 0) MSPquery(MSP_MOTOR);
                if ((iRefreshDivider % gui_settings.MSP_RAW_GPS_rate_divider) == 0) MSPquery(MSP_RAW_GPS);
                if ((iRefreshDivider % gui_settings.MSP_COMP_GPS_rate_divider) == 0) MSPquery(MSP_COMP_GPS);
                if ((iRefreshDivider % gui_settings.MSP_ATTITUDE_rate_divider) == 0) MSPquery(MSP_ATTITUDE);
                if ((iRefreshDivider % gui_settings.MSP_ALTITUDE_rate_divider) == 0) MSPquery(MSP_ALTITUDE);
                if ((iRefreshDivider % gui_settings.MSP_BAT_rate_divider) == 0) MSPquery(MSP_BAT);
                if ((iRefreshDivider % gui_settings.MSP_RC_rate_divider) == 0) MSPquery(MSP_RC);
                if ((iRefreshDivider % gui_settings.MSP_MISC_rate_divider) == 0) MSPquery(MSP_MISC);
                if ((iRefreshDivider % gui_settings.MSP_DEBUG_rate_divider) == 0) MSPquery(MSP_DEBUG);

                if ((mw_gui.mode & (1 << 5)) > 0)
                {                         //armed
                    if ((iRefreshDivider % 20) == 0) MSPqueryWP(0);         //get home position
                }
                else { mw_gui.GPS_home_lon = 0; mw_gui.GPS_home_lat = 0; bHomeRecorded = false; }
                
                if ((mw_gui.mode & (1 << 7)) > 0)
                {                         //poshold
                    if ((iRefreshDivider % 20) == 0) MSPqueryWP(16);         //get hold position
                }
                else { mw_gui.GPS_poshold_lon = 0; mw_gui.GPS_poshold_lat = 0; bPosholdRecorded = false; }




            }
            update_gui();
            iRefreshDivider--;
            if (iRefreshDivider == 0) iRefreshDivider = 20;      //reset

        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            //Check if we at GUI Settings, go to first screen when connect
            if (tabMain.SelectedIndex == 4) { tabMain.SelectedIndex = 0; }

            if (serialPort.IsOpen)              //Disconnect
            {
                b_connect.Text = "Connect";
                b_connect.Image = Properties.Resources.connect;
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                //timer_rc.Stop();
                bkgWorker.CancelAsync();
                System.Threading.Thread.Sleep(500);         //Wait bkworker to finish
                serialPort.Close();
                if (bLogRunning)
                {
                    closeLog();
                }

                //Disable buttons that are not working here
                b_reset.Enabled = false;
                b_cal_acc.Enabled = false;
                b_cal_mag.Enabled = false;
                b_read_settings.Enabled = false;
                b_write_settings.Enabled = false;



            }
            else                               //Connect
            {

                if (cb_serial_port.Text == "") { return; }  //if no port selected then do nothin' at connect
                //Assume that the selection in the combobox for port is still valid
                serialPort.PortName = cb_serial_port.Text;
                serialPort.BaudRate = int.Parse(cb_serial_speed.Text);
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    //WRONG, it seems that the combobox selection pointed to a port which is no longer available
                    MessageBoxEx.Show(this, "Please check that your USB cable is still connected.\r\nAfter you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    serial_ports_enumerate();
                    return; //Exit without connecting;
                }
                //Set button text and status
                b_connect.Text = "Disconnect";
                b_connect.Image = Properties.Resources.disconnect;
                isConnected = true;

                //Open Log file if it is enabled
                if (gui_settings.bEnableLogging)
                {
                    openLog();
                }

                serial_packet_count = 0;
                serial_error_count = 0;

                //Enable buttons that are not working here
                b_reset.Enabled = true;
                b_cal_acc.Enabled = true;
                b_cal_mag.Enabled = true;
                b_read_settings.Enabled = true;
                b_write_settings.Enabled = true;



                //We have to do it for a couple of times to ensure that we will have parameters loaded 
                for (int i=0;i<10;i++) {

                MSPquery(MSP_PID);
                MSPquery(MSP_RC_TUNING);
                MSPquery(MSP_IDENT);
                MSPquery(MSP_BOX);
                MSPquery(MSP_MISC);
                }

                
                
                //Run BackgroundWorker
                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }

                timer_realtime.Start();

                //if (tabMain.SelectedIndex == 2 && !isPaused) timer_realtime.Start();                             //If we are standing at the monitor page, start timer
                //if (tabMain.SelectedIndex == 1 && !isPausedRC) timer_rc.Start();                                //And start it if we stays on rc settings page
                //if (tabMain.SelectedIndex == 3 && !isPausedGPS) timer_GPS.Start();
                System.Threading.Thread.Sleep(1000);

                bOptions_needs_refresh = true;
                update_gui();

             


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
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                case 1:
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                case 3:                 //MAP
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;

                case 5:
                    if (isConnected || bVideoRecording)
                    {
                        MessageBoxEx.Show(this, "FC is connected or Video is recording, to change GUI settings please disconnect FC and/or stop video recoding", "Unable to enter GUI settings", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tabMain.SelectedIndex = iSelectedTabIndex;      //go back to the pervious one
                    }
                    break;
                default:
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
            }


        }

        private void b_log_browser_Click(object sender, EventArgs e)
        {
            LogBrowser logbrowser = new LogBrowser();
            logbrowser.sInitialDirectory = gui_settings.sLogFolder;
            logbrowser.ShowDialog();
            logbrowser.Dispose();
        }





        private void l_ports_label_DoubleClick(object sender, EventArgs e)
        {
            serial_ports_enumerate();
        }

        private void serial_ports_enumerate()
        {
            //Enumerate all serial ports
            b_connect.Enabled = true;           //Enable the connect button

            string[] ports = SerialPort.GetPortNames();
            cb_serial_port.Items.Clear();
            foreach (string port in ports)
            {
                cb_serial_port.Items.Add(port);
            }
            cb_serial_port.SelectedIndex = cb_serial_port.FindStringExact(gui_settings.sPreferedComPort);

            //if prefered port is not available then select the first one 
            if (cb_serial_port.Text == "")
            {
                if (cb_serial_port.Items.Count > 0) { cb_serial_port.SelectedIndex = 0; }
            }

            //Thisable connect button if there is no selected com port
            if (cb_serial_port.Items.Count == 0) { b_connect.Enabled = false; }
        }

        private void read_options_config()
        {

            option_names = new string[20];
            option_indicators = new string[20];
            option_desc = new string[100];


            int iPidID = 0;

            Pid = new PID[20];          //Max 20 PID values if we have more then we will ignore it

            iCheckBoxItems = 0;
            iPidItems = 0;

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
                                    if (String.Compare(reader.Name, "ind", true) == 0)
                                    {
                                        option_indicators[iCheckBoxItems] = reader.Value;
                                    }

                                }
                                iCheckBoxItems++;
                            }




                            if (String.Compare(reader.Name, "pid", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                Pid[iPidID] = new PID();
                                reader.MoveToAttribute("name");
                                Pid[iPidID].name = reader.GetAttribute("name");
                                reader.MoveToAttribute("desc");
                                Pid[iPidID].description = reader.GetAttribute("desc");
                                iPidItems++;
                            }
                            if (String.Compare(reader.Name, "p", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Pshown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Pmin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Pmax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Pprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }
                            if (String.Compare(reader.Name, "i", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Ishown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Imin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Imax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Iprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }
                            if (String.Compare(reader.Name, "d", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Dshown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Dmin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Dmax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Dprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }


                            
                            
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


        private byte read8(SerialPort s)
        {

            return ((byte)s.ReadByte());
        }

        private int read16(SerialPort s)
        {
            byte[] buffer = {0,0};
            int retval;

            buffer[0] = (byte)s.ReadByte();
            buffer[1] = (byte)s.ReadByte();

            retval = BitConverter.ToInt16(buffer,0);

            return (retval);
        }


        private void evaluate_command(byte cmd)
        {

            byte ptr; 

            switch (cmd)
            {
                case MSP_IDENT:
                    ptr = 0;
                    mw_gui.version = (byte)inBuf[ptr++];
                    mw_gui.multiType = (byte)inBuf[ptr];
                    mw_gui.protocol_version = (byte)inBuf[ptr++];
                    mw_gui.capability = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_STATUS:
                    ptr = 0;
                    mw_gui.cycleTime = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.i2cErrors = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.present = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.mode = BitConverter.ToUInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_RAW_IMU:
                    ptr = 0;
                    mw_gui.ax = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.ay = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.az = BitConverter.ToInt16(inBuf, ptr); ptr += 2;

                    mw_gui.gx = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
                    mw_gui.gy = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
                    mw_gui.gz = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;

                    mw_gui.magx = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    mw_gui.magy = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    mw_gui.magz = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    break;
                case MSP_SERVO:
                    ptr = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        mw_gui.servos[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_MOTOR:
                    ptr = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        mw_gui.motors[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_RC:
                    ptr = 0;
                    mw_gui.rcRoll = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcPitch = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcYaw = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcThrottle = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_RAW_GPS:
                    ptr = 0;
                    mw_gui.GPS_fix = (byte)inBuf[ptr++];
                    mw_gui.GPS_numSat = (byte)inBuf[ptr++];
                    mw_gui.GPS_latitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    mw_gui.GPS_longitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    mw_gui.GPS_altitude = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_speed = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_COMP_GPS:
                    ptr = 0;
                    mw_gui.GPS_distanceToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_directionToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_update = (byte)inBuf[ptr++];
                    break;
                case MSP_ATTITUDE:
                    ptr = 0;
                    mw_gui.angx = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
                    mw_gui.angy = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
                    mw_gui.heading = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_ALTITUDE:
                    ptr = 0;
                    mw_gui.baro = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_BAT:
                    ptr = 0;
                    mw_gui.vBat = (byte)inBuf[ptr++];
                    mw_gui.pMeterSum = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_RC_TUNING:
                    ptr = 0;
                    mw_gui.rcRate = (byte)inBuf[ptr++];
                    mw_gui.rcExpo = (byte)inBuf[ptr++];
                    mw_gui.RollPitchRate = (byte)inBuf[ptr++];
                    mw_gui.YawRate = (byte)inBuf[ptr++];
                    mw_gui.DynThrPID = (byte)inBuf[ptr++];
                    mw_gui.ThrottleMID = (byte)inBuf[ptr++];
                    mw_gui.ThrottleEXPO = (byte)inBuf[ptr++];
                    break;
                case MSP_PID:
                    ptr = 0;
                    for (int i = 0; i < iPidItems; i++)
                    {
                        mw_gui.pidP[i] = (byte)inBuf[ptr++];
                        mw_gui.pidI[i] = (byte)inBuf[ptr++];
                        mw_gui.pidD[i] = (byte)inBuf[ptr++];
                    }
                    bOptions_needs_refresh = true;
                    break;
                case MSP_BOX:
                    ptr = 0;
                    for (int i = 0; i < iCheckBoxItems; i++)
                    {
                        mw_gui.activation[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_MISC:
                    ptr = 0;
                    mw_gui.powerTrigger = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_DEBUG:
                    ptr = 0;
                    mw_gui.debug1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_WP:
                    ptr = 0;
                    byte wp_no = (byte)inBuf[ptr++];
                    if (wp_no == 0)
                    {
                        mw_gui.GPS_home_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_home_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_home_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                        //flag comes here but not care
                    }
                    if (wp_no == 16)
                    {
                        mw_gui.GPS_poshold_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_poshold_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_poshold_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;


            }
        }




        



        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            byte c;

            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;
            
            try
            {
                bool bIsPortOpen = serialPort.IsOpen;
            }
            catch
            {
                //Hmm, if this throws an exception it should mean that we have an issue here
                bSerialError = true;
                return;
            }

            bSerialError = false;

            while (!bw.CancellationPending)                // backgroundworker runs continously
            {

                if (serialPort.IsOpen)
                {
                    //Just process what is received. Get received commands and put them into 
                    while (serialPort.BytesToRead > 0)
                    {
                        c = (byte)serialPort.ReadByte();


                        switch (c_state)
                        {
                            case IDLE:
                                c_state = (c == '$') ? HEADER_START : IDLE;
                                break;
                            case HEADER_START:
                                c_state = (c == 'M') ? HEADER_M : IDLE;
                                break;

                            case HEADER_M:
                                if (c == '>')
                                {
                                    c_state = HEADER_ARROW;
                                }
                                else if (c == '!')
                                {
                                    c_state = HEADER_ERR;
                                }
                                else
                                {
                                    c_state = IDLE;
                                }
                                break;

                            case HEADER_ARROW:
                            case HEADER_ERR:
                                /* is this an error message? */
                                err_rcvd = (c_state == HEADER_ERR);        /* now we are expecting the payload size */
                                dataSize = c;
                                /* reset index variables */
                                offset = 0;
                                checksum = 0;
                                checksum ^= c;
                                c_state = HEADER_SIZE;
                                if (dataSize > 100) { c_state = IDLE; }

                                break;
                            case HEADER_SIZE:
                                cmd = c;
                                checksum ^= c;
                                c_state = HEADER_CMD;
                                break;
                            case HEADER_CMD:
                                if (offset < dataSize)
                                {
                                    checksum ^= c;
                                    inBuf[offset++] = c;
                                }
                                else
                                {

                                    /* compare calculated and transferred checksum */
                                    if (checksum == c)
                                    {
                                        if (err_rcvd)
                                        {
                                            // Console.WriteLine("Copter did not understand request type " + err_rcvd);
                                        }
                                        else
                                        {
                                            /* we got a valid response packet, evaluate it */
                                            serial_packet_count++;
                                            evaluate_command(cmd);
                                        }
                                    }
                                    else
                                    {
                                        /*
                                        Console.WriteLine("invalid checksum for command " + cmd + ": " + checksum + " expected, got " + c);
                                        Console.Write("<" + cmd + " " + dataSize + "> {");
                                        for (int i = 0; i < dataSize; i++)
                                        {
                                            if (i != 0) { Console.Write(' '); }
                                            Console.Write(inBuf[i]);
                                        }
                                        Console.WriteLine("} [" + c + "]");
                                         */

                                        serial_error_count++;

                                    }
                                    c_state = IDLE;
                                }
                                break;
                        }
                    }
                    
                }
                else   //port not opened, (it could happen when U disconnect the usb cable while connected
                {
                    //bSerialError = true; //do nothing
                    //return;
                }

            }// while

            e.Cancel = true;

        }

        private void update_gui()
        {


            label41.Text = Convert.ToString(serial_error_count);
            label42.Text = Convert.ToString(serial_packet_count);


            if (bSerialError)
            {
                //Background worker returned error, disconnect serial port
                b_connect.Text = "Connect";
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                System.Threading.Thread.Sleep(iRefreshIntervals[cb_monitor_rate.SelectedIndex]);         //Wait for 1 cycle to let backgroundworker finish it's last job.
                try
                {
                    serialPort.Close();
                }
                catch
                {
                    MessageBoxEx.Show(this, "An error condition detected on the Serial port, check that your USB cable is connected", "Comm Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bSerialError = false;
                return;
            }

            if (bLogRunning && wLogStream.BaseStream!=null)
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

            if (bKMLLogRunning)
            {

                if (GPS_lat_old != mw_gui.GPS_latitude || GPS_lon_old != mw_gui.GPS_longitude)
                {
                    wKMLLogStream.WriteLine("{0},{1},{2}", (decimal)mw_gui.GPS_longitude / 10000000, (decimal)mw_gui.GPS_latitude / 10000000,mw_gui.GPS_altitude);
                    GPS_lat_old = mw_gui.GPS_latitude;
                    GPS_lon_old = mw_gui.GPS_longitude;
                }

                if (!bHomeRecorded && (mw_gui.GPS_home_lon != 0))
                {
                    addKMLMarker("Home position", mw_gui.GPS_home_lon, mw_gui.GPS_home_lat, mw_gui.GPS_altitude);
                    bHomeRecorded = true;
                }


                if (!bPosholdRecorded && (mw_gui.GPS_poshold_lon != 0))
                {
                    addKMLMarker("PosHold", mw_gui.GPS_poshold_lon, mw_gui.GPS_poshold_lat, mw_gui.GPS_altitude);
                    bPosholdRecorded = true;
                }  


            }


            if (tabMain.SelectedIndex == 0 | tabMain.SelectedIndex == 1)        //Common tasks for both panel
            {

                throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
                if (bOptions_needs_refresh)
                {
                    update_pid_panel();
                    update_aux_panel();
                    bOptions_needs_refresh = false;
                    
                }
            }


            //TAB MAP
            if (tabMain.SelectedIndex == 3)
            {

                if (mw_gui.GPS_latitude != 0)
                {

                    lGPS_lat.Text = Convert.ToString((decimal)mw_gui.GPS_latitude / 10000000);
                    lGPS_lon.Text = Convert.ToString((decimal)mw_gui.GPS_longitude / 10000000);
                    GPS_pos.Lat = (double)mw_gui.GPS_latitude / 10000000;
                    GPS_pos.Lng = (double)mw_gui.GPS_longitude / 10000000;

                    positions.Markers.Clear();


                    if (((mw_gui.mode & (1 << 5)) > 0) && (mw_gui.GPS_home_lon!=0))       //ARMED
                    {
                        PointLatLng GPS_home = new PointLatLng((double)mw_gui.GPS_home_lat / 10000000, (double)mw_gui.GPS_home_lon / 10000000);
                        positions.Markers.Add(new GMapMarkerHome(GPS_home));
                    } 
                        

                    if (((mw_gui.mode & (1 << 7)) > 0) && (mw_gui.GPS_poshold_lon!=0))       //poshold
                    {
                        PointLatLng GPS_poshold = new PointLatLng((double)mw_gui.GPS_poshold_lat / 10000000, (double)mw_gui.GPS_poshold_lon / 10000000);
                        positions.Markers.Add(new  GMapMarkerGoogleRed(GPS_poshold));
                    }                        


                    positions.Markers.Add(new GMapMarkerQuad(GPS_pos, mw_gui.heading, 0, 0));
                    
                    Grout.Points.Add(GPS_pos);
                    MainMap.Position = GPS_pos;
                    MainMap.Invalidate();


                    l_GPS_alt.Text = Convert.ToString(mw_gui.GPS_altitude) + " meter";
                    l_GPS_numsat.Text = Convert.ToString(mw_gui.GPS_numSat);



                }
            }




            // TAB RCControl
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

            // TAB realtime
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

                if (cb_alt.Checked) { list_alt.Add((double)xTimeStamp, mw_gui.baro/100); }
                l_alt.Text = "" + (double)mw_gui.baro/100;

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

                //indNUNCHUK.SetStatus((mw_gui.present & 1) != 0);
                indACC.SetStatus((mw_gui.present & 1) != 0);
                indBARO.SetStatus((mw_gui.present & 2) != 0);
                indMAG.SetStatus((mw_gui.present & 4) != 0);
                indGPS.SetStatus((mw_gui.present & 8) != 0);
                indSONAR.SetStatus((mw_gui.present & 16) != 0);



                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    if ((mw_gui.mode & (1 << i)) > 0) indicators[i].SetStatus(true);
                    else indicators[i].SetStatus(false);
                }



                l_cycletime.Text = String.Format("{0:0000} µs", mw_gui.cycleTime);
                l_vbatt.Text = String.Format("{0:0.0} volts", (double)mw_gui.vBat / 10);
                l_powersum.Text = String.Format("{0:0}", mw_gui.pMeterSum);
                l_i2cerrors.Text = String.Format("{0:0}",mw_gui.i2cErrors);

            } //end if tab=realtime;
        }

        private void b_reread_rc_options_Click(object sender, EventArgs e)
        {
            MSPquery(MSP_BOX);
            bOptions_needs_refresh = true;
        }

        private void aux_checked_changed_event(object sender, EventArgs e)
        {
            CheckBoxEx cb = ((CheckBoxEx)(sender));

            cb.IsHighlighted = cb.Checked == ((byte)(mw_gui.activation[cb.item] & (1 << cb.aux * 3 + cb.rclevel)) == 0) ? true : false; 

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
                MSPquery(MSP_ACC_CALIBRATION);
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

                MSPquery(MSP_MAG_CALIBRATION);

            }
        }

        private void b_read_settings_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                MSPquery(MSP_PID);
                MSPquery(MSP_RC_TUNING);
                MSPquery(MSP_IDENT);
                MSPquery(MSP_BOX);
                MSPquery(MSP_MISC);
                System.Threading.Thread.Sleep(500); 
                bOptions_needs_refresh = true;
                update_gui();
            }
        }

        private void update_params()
        {
            //Get parameters from GUI

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { mw_gui.pidP[i] = (byte)(Pid[i].Pfield.Value * Pid[i].Pprec); }
                if (Pid[i].Ishown) { mw_gui.pidI[i] = (byte)(Pid[i].Ifield.Value * Pid[i].Iprec); }
                if (Pid[i].Dshown) { mw_gui.pidD[i] = (byte)(Pid[i].Dfield.Value * Pid[i].Dprec); }

                mw_params.pidP[i] = mw_gui.pidP[i];
                mw_params.pidI[i] = mw_gui.pidI[i];
                mw_params.pidD[i] = mw_gui.pidD[i];
            }

            mw_params.RollPitchRate = (byte)(nRATE_rp.Value * 100);
            mw_params.YawRate = (byte)(nRATE_yaw.Value * 100);
            mw_params.DynThrPID = (byte)(nRATE_tpid.Value * 100);

            mw_params.rcExpo = (byte)(nRCExpo.Value * 100);
            mw_params.rcRate = (byte)(nRCRate.Value * 100);
            mw_params.ThrottleMID = (byte)(nTMID.Value * 100);
            mw_params.ThrottleEXPO = (byte)(nTEXPO.Value * 100);

            mw_params.PowerTrigger = (int)nPAlarm.Value;

            for (int b = 0; b < iCheckBoxItems; b++)
            {
                mw_params.activation[b] = 0;
                for (byte a = 0; a < 3; a++)
                {
                    if (aux[0, a, b].Checked) mw_params.activation[b] += (short)(1 << a);
                    if (aux[1, a, b].Checked) mw_params.activation[b] += (short)(1 << (3 + a));
                    if (aux[2, a, b].Checked) mw_params.activation[b] += (short)(1 << (6 + a));
                    if (aux[3, a, b].Checked) mw_params.activation[b] += (short)(1 << (9 + a));

                }
            }

            mw_params.comment = tComment.Text;
        }

        private void write_parameters()
        {

            //bool timer_rt_state = timer_realtime.Enabled;

            //Stop all timers
            timer_realtime.Stop();
            //System.Threading.Thread.Sleep(500); //Wait for a while to flush incoming buffers
            update_params();                            //update parameters object from GUI controls.

            mw_params.write_settings(serialPort);
            System.Threading.Thread.Sleep(1000);

            MSPquery(MSP_PID);
            MSPquery(MSP_RC_TUNING);
            MSPquery(MSP_IDENT);
            MSPquery(MSP_BOX);
            MSPquery(MSP_MISC);
            //Invalidate gui parameters and reread those values

            timer_realtime.Start();
            System.Threading.Thread.Sleep(500);
            bOptions_needs_refresh = true;
            update_gui();           


        }

        private void b_write_settings_Click(object sender, EventArgs e)
        {

            write_parameters();

        }

        private void update_aux_panel()
        {

            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_gui.activation[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_gui.activation[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_gui.activation[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_gui.activation[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_gui.activation[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_gui.activation[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_gui.activation[i] & (1 << 6)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_gui.activation[i] & (1 << 7)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_gui.activation[i] & (1 << 8)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_gui.activation[i] & (1 << 9)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_gui.activation[i] & (1 << 10)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_gui.activation[i] & (1 << 11)) == 0 ? false : true;
            }

            for (int i = 0; i < iCheckBoxItems; i++)
            {

                aux[0, 0, i].IsHighlighted = (aux[0, 0, i].Checked == ((mw_gui.activation[i] & (1 << 0)) == 0)) ? true : false;
                aux[0, 1, i].IsHighlighted = (aux[0, 1, i].Checked == ((mw_gui.activation[i] & (1 << 1)) == 0)) ? true : false;
                aux[0, 2, i].IsHighlighted = (aux[0, 2, i].Checked == ((mw_gui.activation[i] & (1 << 2)) == 0)) ? true : false;
                aux[1, 0, i].IsHighlighted = (aux[1, 0, i].Checked == ((mw_gui.activation[i] & (1 << 3)) == 0)) ? true : false;
                aux[1, 1, i].IsHighlighted = (aux[1, 1, i].Checked == ((mw_gui.activation[i] & (1 << 4)) == 0)) ? true : false;
                aux[1, 2, i].IsHighlighted = (aux[1, 2, i].Checked == ((mw_gui.activation[i] & (1 << 5)) == 0)) ? true : false;
                aux[2, 0, i].IsHighlighted = (aux[2, 0, i].Checked == ((mw_gui.activation[i] & (1 << 6)) == 0)) ? true : false;
                aux[2, 1, i].IsHighlighted = (aux[2, 1, i].Checked == ((mw_gui.activation[i] & (1 << 7)) == 0)) ? true : false;
                aux[2, 2, i].IsHighlighted = (aux[2, 2, i].Checked == ((mw_gui.activation[i] & (1 << 8)) == 0)) ? true : false;
                aux[3, 0, i].IsHighlighted = (aux[3, 0, i].Checked == ((mw_gui.activation[i] & (1 << 9)) == 0)) ? true : false;
                aux[3, 1, i].IsHighlighted = (aux[3, 1, i].Checked == ((mw_gui.activation[i] & (1 << 10)) == 0)) ? true : false;
                aux[3, 2, i].IsHighlighted = (aux[3, 2, i].Checked == ((mw_gui.activation[i] & (1 << 11)) == 0)) ? true : false;
            }


        }

        private void update_pid_panel()
        {
            //fill out PID values from mw_gui. structure

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { Pid[i].Pfield.Value = (decimal)mw_gui.pidP[i] / Pid[i].Pprec; Pid[i].Pfield.BackColor = Color.White; }
                if (Pid[i].Ishown) { Pid[i].Ifield.Value = (decimal)mw_gui.pidI[i] / Pid[i].Iprec; Pid[i].Ifield.BackColor = Color.White; }
                if (Pid[i].Dshown) { Pid[i].Dfield.Value = (decimal)mw_gui.pidD[i] / Pid[i].Dprec; Pid[i].Dfield.BackColor = Color.White; }

            }

            nRATE_rp.Value = (decimal)mw_gui.RollPitchRate / 100;
            nRATE_rp.BackColor = Color.White;
            nRATE_yaw.Value = (decimal)mw_gui.YawRate / 100;
            nRATE_yaw.BackColor = Color.White;
            nRATE_tpid.Value = (decimal)mw_gui.DynThrPID / 100;
            nRATE_tpid.BackColor = Color.White;

            trackbar_RC_Expo.Value = mw_gui.rcExpo;
            nRCExpo.Value = (decimal)mw_gui.rcExpo / 100;
            nRCExpo.BackColor = Color.White;
            trackbar_RC_Rate.Value = mw_gui.rcRate;
            nRCRate.Value = (decimal)mw_gui.rcRate / 100;
            nRCRate.BackColor = Color.White;

            rc_expo_control1.SetRCExpoParameters((double)mw_gui.rcRate / 100, (double)mw_gui.rcExpo / 100);

            nTEXPO.Value = (decimal)mw_gui.ThrottleEXPO / 100;
            nTEXPO.BackColor = Color.White;
            trackBar_T_EXPO.Value = mw_gui.ThrottleEXPO;
            nTMID.Value = (decimal)mw_gui.ThrottleMID / 100;
            nTMID.BackColor = Color.White;
            trackBar_T_MID.Value = mw_gui.ThrottleMID;
            throttle_expo_control1.SetRCExpoParameters((double)mw_gui.ThrottleMID/100, (double)mw_gui.ThrottleEXPO / 100,mw_gui.rcThrottle);

            nPAlarm.Value = mw_gui.powerTrigger;
            nPAlarm.BackColor = Color.White;



        }

        private void update_gui_from_params()
        {
            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_params.activation[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_params.activation[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_params.activation[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_params.activation[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_params.activation[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_params.activation[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_params.activation[i] & (1 << 6)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_params.activation[i] & (1 << 7)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_params.activation[i] & (1 << 8)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_params.activation[i] & (1 << 9)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_params.activation[i] & (1 << 10)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_params.activation[i] & (1 << 11)) == 0 ? false : true;
            }
            //fill out PID values from mw_gui. structure

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { Pid[i].Pfield.Value = (decimal)mw_params.pidP[i] / Pid[i].Pprec; }
                if (Pid[i].Ishown) { Pid[i].Ifield.Value = (decimal)mw_params.pidI[i] / Pid[i].Iprec; }
                if (Pid[i].Dshown) { Pid[i].Dfield.Value = (decimal)mw_params.pidD[i] / Pid[i].Dprec; }

            }
            
            nRATE_rp.Value = (decimal)mw_params.RollPitchRate / 100;
            nRATE_yaw.Value = (decimal)mw_params.YawRate / 100;
            nRATE_tpid.Value = (decimal)mw_params.DynThrPID / 100;

            trackbar_RC_Expo.Value = mw_params.rcExpo;
            nRCExpo.Value = (decimal)mw_params.rcExpo / 100;
            trackbar_RC_Rate.Value = mw_params.rcRate;
            nRCRate.Value = (decimal)mw_params.rcRate / 100;
            rc_expo_control1.SetRCExpoParameters((double)mw_params.rcRate / 100, (double)mw_params.rcExpo / 100);

            nTEXPO.Value = (decimal)mw_params.ThrottleEXPO / 100;
            trackBar_T_EXPO.Value = mw_params.ThrottleEXPO;
            nTMID.Value = (decimal)mw_params.ThrottleMID / 100;
            trackBar_T_MID.Value = mw_params.ThrottleMID;
            throttle_expo_control1.SetRCExpoParameters((double)mw_params.ThrottleMID / 100, (double)mw_params.ThrottleEXPO / 100,mw_gui.rcThrottle);

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
            bkgWorker.CancelAsync();
            System.Threading.Thread.Sleep(500);         //Wait for 1 cycle to let backgroundworker finish it's last job.
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

            //add asynch layer
            AsyncVideoSource asyncSource = new AsyncVideoSource(source, true);
            // set NewFrame event handler
            asyncSource.NewFrame += new NewFrameEventHandler(videoSourcePlayer_NewFrame);
            // start the video source
            asyncSource.Start();


            // start new video source
            videoSourcePlayer.VideoSource = asyncSource;
            videoSourcePlayer.Start();

            this.Cursor = Cursors.Default;
        }
        // New frame received
        private void videoSourcePlayer_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = eventArgs.Frame;
            //Graphics g = Graphics.FromImage(image);

            //g.DrawString(String.Format("{0:0}", mw_gui.angx), drawFont, drawBrush, 100,100);


            if (bVideoRecording == true)
            {
                tsFrameTimeStamp = tsFrameTimeStamp.Add(tsFrameRate); 
                if (vfwWriter != null)
                {
                    vfwWriter.WriteVideoFrame(image, tsFrameTimeStamp);
                }
            }
            //g.Dispose();

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
                    vfwWriter.Open(gui_settings.sCaptureFolder + "\\capture" + String.Format("-{0:yyMMdd-hhmm}", DateTime.Now) + ".avi", 640, 480, (int)nFrameRate.Value, (VideoCodec)cb_codec.SelectedIndex, (int)(1000000 * nBitRate.Value));
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
            folderBrowserDialog1.SelectedPath = gui_settings.sLogFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sLogFolder = folderBrowserDialog1.SelectedPath;
                l_LogFolder.Text = gui_settings.sLogFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }

        }

        private void b_select_capture_folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = gui_settings.sCaptureFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sCaptureFolder = folderBrowserDialog1.SelectedPath;
                l_Capture_folder.Text = gui_settings.sCaptureFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }
        }

        private void b_select_settings_folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = gui_settings.sSettingsFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gui_settings.sSettingsFolder = folderBrowserDialog1.SelectedPath;
                l_Settings_folder.Text = gui_settings.sSettingsFolder;
                b_save_gui_settings.BackColor = Color.LightCoral;
            }

        }

        private void b_save_gui_settings_Click(object sender, EventArgs e)
        {

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

        private void cb_Logging_enabled_Click(object sender, EventArgs e)
        {
            gui_settings.bEnableLogging = cb_Logging_enabled.Checked;
            b_save_gui_settings.BackColor = Color.LightCoral;
        }

        private void b_about_Click(object sender, EventArgs e)
        {
            frmAbout aboutform = new frmAbout();
            aboutform.sVersionLabel = sVersion;
            aboutform.sFcVersionLabel = "MultiWii version " + sRelName;
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

        private void b_check_update_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                doc = XDocument.Load(sVersionUrl, LoadOptions.None);
                sVersionFromSVN = doc.Element("application").Element("version").Value;
                string sCommentFromSVN = doc.Element("application").Element("comment").Value;
                this.Cursor = Cursors.Default;
                if (String.Compare(sVersionFromSVN, sVersion) == 0)
                {
                    MessageBoxEx.Show(this, "You have the latest version : " + sVersionFromSVN, "No update available",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {

                    MessageBoxEx.Show(this, "A new version : " + sVersionFromSVN + " is available\r\n"+sCommentFromSVN+"\r\nYou can download it from http://code.google.com/p/mw-wingui/downloads/list","Update available",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBoxEx.Show(this, "Not Able to connect to SVN for version info");
            }

        }

        private void attitudeIndicatorInstrumentControl1_Click(object sender, EventArgs e)
        {
            Point c = System.Windows.Forms.Cursor.Position;
            Point p = attitudeIndicatorInstrumentControl1.PointToClient(c);

            attitudeIndicatorInstrumentControl1.ToggleArtificalHorizonType();

        }



        private void MSPquery(int command)
        {
            byte c = 0;
            byte[] o;
            o = new byte[10];
            // with checksum 
            o[0] = (byte)'$';
            o[1] = (byte)'M';
            o[2] = (byte)'<';
            o[3] = (byte)0; c ^= o[3];       //no payload 
            o[4] = (byte)command; c ^= o[4];
            o[5] = (byte)c;
            serialPort.Write(o, 0, 6);
            

        }

        private void MSPqueryWP(int wp)
        {
            byte c = 0;
            byte[] o;
            o = new byte[10];
            // with checksum 
            o[0] = (byte)'$';
            o[1] = (byte)'M';
            o[2] = (byte)'<';
            o[3] = (byte)1; c ^= o[3];       //one byte payload
            o[4] = (byte)MSP_WP; c ^= o[4];
            o[5] = (byte)wp; c ^= o[5];
            o[6] = (byte)c;
            serialPort.Write(o, 0, 7);
        }



        private int decimals(int prec)
        {
            if (prec == 1) return (0);
            if (prec == 10) return (1);
            if (prec == 100) return (2);
            if (prec == 1000) return (3);

            return (0);
        }

        private void trackBar_T_MID_Scroll(object sender, EventArgs e)
        {
            nTMID.Value = (decimal)trackBar_T_MID.Value / 100;
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value,mw_gui.rcThrottle);
        }

        private void trackBar_T_EXPO_Scroll(object sender, EventArgs e)
        {
            nTEXPO.Value = (decimal)trackBar_T_EXPO.Value / 100;
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
        }

        private void nTMID_ValueChanged(object sender, EventArgs e)
        {
            trackBar_T_MID.Value = (int)(nTMID.Value * 100);
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
            if ((int)(nTMID.Value * 100) != mw_gui.ThrottleMID)
            {
                nTMID.BackColor = Color.IndianRed;
            }
            else
            {
                nTMID.BackColor = Color.White;
            }

        }

        private void nTEXPO_ValueChanged(object sender, EventArgs e)
        {
            trackBar_T_EXPO.Value = (int)(nTEXPO.Value * 100);
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
            if ((int)(nTEXPO.Value * 100) != mw_gui.ThrottleEXPO)
            {
                nTEXPO.BackColor = Color.IndianRed;
            }
            else
            {
                nTEXPO.BackColor = Color.White;
            }

        }     




        private void b_log_Click(object sender, EventArgs e)
        {
            if (bLogRunning)        //Close
            {

                closeLog();
                b_log.Text = "Start Log";
                b_log.BackColor = Color.Gray;
                b_log.Image = Properties.Resources.start_log;

            }
            else
            {
                openLog();
                if (bLogRunning)
                {
                    b_log.Text = "Stop Log";
                    b_log.BackColor = Color.IndianRed;
                    b_log.Image = Properties.Resources.stop_log;
                }
            }
        }


        void openLog()
        {
            try
            {
                wLogStream = new StreamWriter(gui_settings.sLogFolder + "\\mwguilog" + String.Format("-{0:yymmdd-hhmm}.log", DateTime.Now));
            }
            catch
            {
                MessageBox.Show("Unable to open log file at " + gui_settings.sLogFolder + "\\mwguilog" + String.Format("-{0:yymmdd-hhmm}.log", DateTime.Now), "Error opening log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (wLogStream != null)
            {
                bLogRunning = true;
            }

        }

        void closeLog()
        {
            wLogStream.Flush();
            wLogStream.Close();
            wLogStream.Dispose();
            bLogRunning = false;
        }

        void openKMLLog()
        {

            try
            {
                wKMLLogStream = new StreamWriter(gui_settings.sLogFolder + "\\mwgpstrack" + String.Format("-{0:yymmdd-hhmm}.kml", DateTime.Now));
            }
            catch
            {
                MessageBox.Show("Unable to open KMLlog file at " + gui_settings.sLogFolder + "\\mwgpstrack" + String.Format("-{0:yymmdd-hhmm}.kml", DateTime.Now), "Error opening KMLlog", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (wKMLLogStream != null)
            {
                wKMLLogStream.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                wKMLLogStream.WriteLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\">");
                wKMLLogStream.WriteLine("<Document>");
                wKMLLogStream.WriteLine("<Placemark>");
                wKMLLogStream.WriteLine("<Style><LineStyle><color>#ef00ffff</color><width>5</width></LineStyle></Style>");
                wKMLLogStream.WriteLine("<name>MultiWii flight log</name>");
                wKMLLogStream.WriteLine("<LineString>");
                wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>");
                wKMLLogStream.WriteLine("<tessellate>1</tessellate>");
                wKMLLogStream.WriteLine("<coordinates>");
                bKMLLogRunning = true;
            }
        }
        void closeKMLLog()
        {

            wKMLLogStream.WriteLine("</coordinates>");
            wKMLLogStream.WriteLine("</LineString>");
            wKMLLogStream.WriteLine("</Placemark>");
            wKMLLogStream.WriteLine("</Document>");
            wKMLLogStream.WriteLine("</kml>");
            wKMLLogStream.Flush();
            wKMLLogStream.Close();
            wKMLLogStream.Dispose();
            bKMLLogRunning = false;
        }


        void addKMLMarker(string description, double lon, double lat, double alt)
        {
            //Close open LineStringPlacemark
            wKMLLogStream.WriteLine("</coordinates>");
            wKMLLogStream.WriteLine("</LineString>");
            wKMLLogStream.WriteLine("</Placemark>");

            wKMLLogStream.WriteLine("<Placemark>");
            wKMLLogStream.WriteLine("<name>"+description+"</name>");
            wKMLLogStream.WriteLine("<Point>");
            wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>");
            wKMLLogStream.WriteLine("<coordinates>");
            wKMLLogStream.WriteLine("{0},{1},{2}", (decimal)lon / 10000000, (decimal)lat / 10000000, alt);
            wKMLLogStream.WriteLine("</coordinates>");
            wKMLLogStream.WriteLine("</Point>");
            wKMLLogStream.WriteLine("</Placemark>");

            //open another LineString
            wKMLLogStream.WriteLine("<Placemark>");
            wKMLLogStream.WriteLine("<Style><LineStyle><color>#ef00ffff</color><width>5</width></LineStyle></Style>");
            wKMLLogStream.WriteLine("<name>MultiWii flight log</name>");
            wKMLLogStream.WriteLine("<LineString>");
            wKMLLogStream.WriteLine("<altitudeMode>absolute</altitudeMode>");
            wKMLLogStream.WriteLine("<tessellate>1</tessellate>");
            wKMLLogStream.WriteLine("<coordinates>");


        }





/*
        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
//            start = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {

//                copterPosMarker.Position = start;
 //               points.Add(new PointLatLng(copterPos.Lat, copterPos.Lng));
 //               Grout.Points.Add(start);
//                    = new GMapRoute(points, "track");
 //               //routes.Routes.Add(Grout);
 //               MainMap.Position = start;
//                MainMap.Invalidate();



            }
        }

        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
            currentMarker.Position = point;



        }
*/

        private void addpolygonmarker(string tag, double lng, double lat, int alt, Color? color)
        {
                PointLatLng point = new PointLatLng(lat, lng);
                GMapMarkerGoogleGreen m = new GMapMarkerGoogleGreen(point);
                m.ToolTipMode = MarkerTooltipMode.Always;
                m.ToolTipText = tag;
                m.Tag = tag;

                //ArdupilotMega.GMapMarkerRectWPRad mBorders = new ArdupilotMega.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                    mBorders.wprad = (int)float.Parse("5");
                    mBorders.MainMap = MainMap;
                    if (color.HasValue)
                    {
                        mBorders.Color = color.Value;
                    }
                }

                markers.Markers.Add(m);
                markers.Markers.Add(mBorders);
        }

        void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            if (markers == null)
                return;

            foreach (GMapMarker m in markers.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = polygonPoints.Count;
                    polygonPoints.Add(m.Position);
                }
            }

            if (polygon == null)
            {
                polygon = new GMapPolygon(polygonPoints, "polygon test");
                polygons.Polygons.Add(polygon);
            }
            else
            {
                polygon.Points.Clear();
                polygon.Points.AddRange(polygonPoints);

                polygon.Stroke = new Pen(Color.Yellow, 4);
                polygon.Fill = Brushes.Transparent;

                if (polygons.Polygons.Count == 0)
                {
                    polygons.Polygons.Add(polygon);
                }
                else
                {
                        MainMap.UpdatePolygonLocalPosition(polygon);
                }
            }
        }


        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 0)
            {
                tb_mapzoom.Value = (int)(MainMap.Zoom);
                center.Position = MainMap.Position;
            }
        }


        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            if (point.Lat > 90) { point.Lat = 90; }
            if (point.Lat < -90) { point.Lat = -90; }
            if (point.Lng > 180) { point.Lng = 180; }
            if (point.Lng < -180) { point.Lng = -180; }
            center.Position = point;
            LMousePos.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);
        }

        void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    CurentRectMarker = null;

                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Blue;
                    MainMap.Invalidate(false);
                }
            }
        }

        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (!isMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    GMapMarkerRect rc = item as GMapMarkerRect;
                    rc.Pen.Color = Color.Red;
                    MainMap.Invalidate(false);

                    CurentRectMarker = rc;
                }
            }
        }


        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            end = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Right) // ignore right clicks
            {
                return;
            }

            if (isMouseDown) // mouse down on some other object and dragged to here.
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = false;
                }
                if (!isMouseDraging)
                {
                    if (CurentRectMarker != null)
                    {
                        // cant add WP in existing rect
                    }
                    else
                    {
                        //callMe(currentMarker.Position.Lat, currentMarker.Position.Lng, 0);
                        //Adding waypoint will come here
                        //addpolygonmarker("X", currentMarker.Position.Lng, currentMarker.Position.Lat, 0,Color.Pink);
                        //RegeneratePolygon();


                    }
                }
                else
                {
                    if (CurentRectMarker != null)
                    {
                        if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                        {
                            drawnpolygon.Points[int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] = new PointLatLng(end.Lat, end.Lng);
                            MainMap.UpdatePolygonLocalPosition(drawnpolygon);
                        }
                        else
                        {
                            //callMeDrag(CurentRectMarker.InnerMarker.Tag.ToString(), currentMarker.Position.Lat, currentMarker.Position.Lng, -1);
                            //update existing point in datagrid
                        }
                        CurentRectMarker = null;
                    }
                }
            }

            isMouseDraging = false;
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            start = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Alt)
            {
                isMouseDown = true;
                isMouseDraging = false;

                if (currentMarker.IsVisible)
                {
                   currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
            }
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);

            currentMarker.Position = point;

            if (!isMouseDown)
            {
                LMousePos.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);
            }

            //draging
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                isMouseDraging = true;
                if (CurentRectMarker == null) // left click pan
                {
                    double latdif = start.Lat - point.Lat;
                    double lngdif = start.Lng - point.Lng;
                    MainMap.Position = new PointLatLng(center.Position.Lat + latdif, center.Position.Lng + lngdif);
                }
                else // move rect marker
                {
                    try
                    {
                        if (CurentRectMarker.InnerMarker.Tag.ToString().Contains("grid"))
                        {
                            drawnpolygon.Points[int.Parse(CurentRectMarker.InnerMarker.Tag.ToString().Replace("grid", "")) - 1] = new PointLatLng(point.Lat, point.Lng);
                            MainMap.UpdatePolygonLocalPosition(drawnpolygon);
                        }
                    }
                    catch { }

                    PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);

                    int? pIndex = (int?)CurentRectMarker.Tag;
                    if (pIndex.HasValue)
                    {
                        if (pIndex < polygon.Points.Count)
                        {
                            polygon.Points[pIndex.Value] = pnew;
                                MainMap.UpdatePolygonLocalPosition(polygon);
                        }
                    }

                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = pnew;
                    }
                    CurentRectMarker.Position = pnew;

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        CurentRectMarker.InnerMarker.Position = pnew;
                    }
                }
            }

        }






        private void cbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            MainMap.MapProvider = (GMapProvider)cbMapProviders.SelectedItem;
            MainMap.MaxZoom = 19;
            MainMap.Invalidate();
            gui_settings.iMapProviderSelectedIndex = cbMapProviders.SelectedIndex;
            gui_settings.save_to_xml(sGuiSettingsFilename);


            this.Cursor = Cursors.Default;

        }



        private void b_start_KML_log_Click(object sender, EventArgs e)
        {
            if (bKMLLogRunning)
            {
                b_start_KML_log.Text = "Start GPS Log";
                b_start_KML_log.BackColor = Color.Gray;
                this.Refresh();
                closeKMLLog();
            }
            else
            {
                openKMLLog();
                if (bKMLLogRunning)
                {
                    b_start_KML_log.Text = "Stop STOP Log";
                    b_start_KML_log.BackColor = Color.IndianRed;
                    this.Refresh();
                }
            }
        }

        private void b_Clear_Route_Click(object sender, EventArgs e)
        {
            Grout.Points.Clear();
        }


        #region ValueChangedEvents

        private void pfield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown)
                {
                    if (Pid[i].Pfield.Value != (decimal)mw_gui.pidP[i] / Pid[i].Pprec)
                    {
                        Pid[i].Pfield.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        Pid[i].Pfield.BackColor = Color.White;
                    }
                }
            }
        
        }

        private void ifield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Ishown)
                {

                    if (Pid[i].Ifield.Value != (decimal)mw_gui.pidI[i] / Pid[i].Iprec)
                    {
                        Pid[i].Ifield.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        Pid[i].Ifield.BackColor = Color.White;
                    }
                }
            }
        }

        private void dfield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Dshown)
                {
                    if (Pid[i].Dfield.Value != (decimal)mw_gui.pidD[i] / Pid[i].Dprec)
                    {
                        Pid[i].Dfield.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        Pid[i].Dfield.BackColor = Color.White;
                    }
                }
            }
        }

        private void nRATE_rp_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_rp.Value != (decimal)mw_gui.RollPitchRate / 100)  { nRATE_rp.BackColor = Color.IndianRed; }
            else { nRATE_rp.BackColor = Color.White; }
        }

        private void nRATE_yaw_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_yaw.Value != (decimal)mw_gui.YawRate / 100) { nRATE_yaw.BackColor = Color.IndianRed; }
            else { nRATE_yaw.BackColor = Color.White; }
        }

        private void nRATE_tpid_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_tpid.Value != (decimal)mw_gui.DynThrPID / 100) { nRATE_tpid.BackColor = Color.IndianRed; }
            else { nRATE_tpid.BackColor = Color.White; }
        }

        private void nPAlarm_ValueChanged(object sender, EventArgs e)
        {
            if (nPAlarm.Value != (decimal)mw_gui.powerTrigger ) { nPAlarm.BackColor = Color.IndianRed; }
            else { nPAlarm.BackColor = Color.White; }
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

            if ((int)(nRCExpo.Value * 100) != mw_gui.rcExpo)
            {
                nRCExpo.BackColor = Color.IndianRed;
            }
            else
            {
                nRCExpo.BackColor = Color.White;
            }


        }

        private void trackbar_RC_Rate_Scroll(object sender, EventArgs e)
        {
            nRCRate.Value = (decimal)trackbar_RC_Rate.Value / 100;
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);

        }

        private void nRCRate_ValueChanged(object sender, EventArgs e)
        {
            trackbar_RC_Rate.Value = (int)(nRCRate.Value * 100);
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
            if ((int)(nRCRate.Value * 100) != mw_gui.rcRate)
            {
                nRCRate.BackColor = Color.IndianRed;
            }
            else
            {
                nRCRate.BackColor = Color.White;
            }

        }

        #endregion

        private void b_check_all_ACC_Click(object sender, EventArgs e)
        {
            cb_acc_pitch.Checked = true;
            cb_acc_roll.Checked = true;
            cb_acc_z.Checked = true;
        }

        private void b_uncheck_all_ACC_Click(object sender, EventArgs e)
        {
            cb_acc_pitch.Checked = false;
            cb_acc_roll.Checked = false;
            cb_acc_z.Checked = false;

        }

        private void b_check_all_GYRO_Click(object sender, EventArgs e)
        {
            cb_gyro_pitch.Checked = true;
            cb_gyro_roll.Checked = true;
            cb_gyro_yaw.Checked = true;
        }

        private void b_uncheck_all_GYRO_Click(object sender, EventArgs e)
        {
            cb_gyro_pitch.Checked = false;
            cb_gyro_roll.Checked = false;
            cb_gyro_yaw.Checked = false;
        }

        private void b_check_all_MAG_Click(object sender, EventArgs e)
        {
            cb_mag_pitch.Checked = true;
            cb_mag_roll.Checked = true;
            cb_mag_yaw.Checked = true;
        }

        private void b_uncheck_all_MAG_Click(object sender, EventArgs e)
        {
            cb_mag_pitch.Checked = false;
            cb_mag_roll.Checked = false;
            cb_mag_yaw.Checked = false;
        }

        private void videoSourcePlayer_SizeChanged(object sender, EventArgs e)
        {

            Size currentSize = videoSourcePlayer.Size;
            currentSize.Width = currentSize.Height / 3 * 4;

            if (splitContainer6.Panel1.Size.Width < currentSize.Width)
            {
                currentSize.Width = splitContainer6.Panel1.Size.Width;
                currentSize.Height = currentSize.Width / 4 * 3;
            }

            videoSourcePlayer.Size = currentSize;


        }

        private void tb_mapzoom_Scroll(object sender, EventArgs e)
        {

            MainMap.Zoom = (double)tb_mapzoom.Value;

        }

        private void b_fetch_tiles_Click(object sender, EventArgs e)
        {
            RectLatLng area = MainMap.SelectedArea;
            if (area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("No ripp area defined, ripp displayed on screen?", "Rip", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    area = MainMap.CurrentViewArea;
                }
            }

            if (!area.IsEmpty)
            {
                DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + (int)MainMap.Zoom + " ?", "GMap.NET", MessageBoxButtons.YesNo);

                for (int i = 1; i <= MainMap.MaxZoom; i++)
                {
                    if (res == DialogResult.Yes)
                    {
                        TilePrefetcher obj = new TilePrefetcher();
                        obj.ShowCompleteMessage = false;
                        obj.Start(area, i, MainMap.MapProvider, 100);
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            //bool timer_rt_state = timer_realtime.Enabled;

            //Stop all timers
            timer_realtime.Stop();
            MSPquery(MSP_RESET_CONF);
            System.Threading.Thread.Sleep(1000);

            MSPquery(MSP_PID);
            MSPquery(MSP_RC_TUNING);
            MSPquery(MSP_IDENT);
            MSPquery(MSP_BOX);
            MSPquery(MSP_MISC);
            //Invalidate gui parameters and reread those values

            timer_realtime.Start();
            System.Threading.Thread.Sleep(500);
            bOptions_needs_refresh = true;
            update_gui();   
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            if (isConnected)
            {
                MessageBoxEx.Show(this, "Please disconnect from flight controller before entering Log Download mode", "Disconnect First", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            log_downloader logDL = new log_downloader();
            logDL.sLogDirectory = gui_settings.sLogFolder;
            logDL.sSerialPortName = cb_serial_port.Text;
            logDL.iSerialPortBaudrate = int.Parse(cb_serial_speed.Text);
            logDL.ShowDialog();
            logDL.Dispose();




        }





        

    }

}
