namespace MultiWiiWinGUI
{
    partial class mainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainGUI));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPagePID = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nTEXPO = new System.Windows.Forms.NumericUpDown();
            this.nTMID = new System.Windows.Forms.NumericUpDown();
            this.trackBar_T_EXPO = new System.Windows.Forms.TrackBar();
            this.trackBar_T_MID = new System.Windows.Forms.TrackBar();
            this.trackbar_RC_Rate = new System.Windows.Forms.TrackBar();
            this.label65 = new System.Windows.Forms.Label();
            this.trackbar_RC_Expo = new System.Windows.Forms.TrackBar();
            this.nRCRate = new System.Windows.Forms.NumericUpDown();
            this.nRCExpo = new System.Windows.Forms.NumericUpDown();
            this.label66 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nPAlarm = new System.Windows.Forms.NumericUpDown();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label_sok = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.nRATE_tpid = new System.Windows.Forms.NumericUpDown();
            this.nRATE_yaw = new System.Windows.Forms.NumericUpDown();
            this.nRATE_rp = new System.Windows.Forms.NumericUpDown();
            this.tabPageRC = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageRealtime = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.b_cal_acc = new System.Windows.Forms.Button();
            this.cb_monitor_rate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_pause = new System.Windows.Forms.Button();
            this.b_cal_mag = new System.Windows.Forms.Button();
            this.l_cycletime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.zgMonitor = new ZedGraph.ZedGraphControl();
            this.label28 = new System.Windows.Forms.Label();
            this.cb_dbg1 = new System.Windows.Forms.CheckBox();
            this.l_dbg1 = new System.Windows.Forms.Label();
            this.cb_dbg2 = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.l_dbg2 = new System.Windows.Forms.Label();
            this.cb_dbg3 = new System.Windows.Forms.CheckBox();
            this.l_dbg4 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.l_dbg3 = new System.Windows.Forms.Label();
            this.cb_dbg4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_uncheck_all_ACC = new System.Windows.Forms.Button();
            this.b_check_all_ACC = new System.Windows.Forms.Button();
            this.l_acc_z = new System.Windows.Forms.Label();
            this.l_acc_pitch = new System.Windows.Forms.Label();
            this.l_acc_roll = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cb_acc_z = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_acc_pitch = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_acc_roll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_uncheck_all_GYRO = new System.Windows.Forms.Button();
            this.b_check_all_GYRO = new System.Windows.Forms.Button();
            this.l_gyro_yaw = new System.Windows.Forms.Label();
            this.l_gyro_pitch = new System.Windows.Forms.Label();
            this.l_gyro_roll = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cb_gyro_yaw = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cb_gyro_pitch = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cb_gyro_roll = new System.Windows.Forms.CheckBox();
            this.cb_alt = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_uncheck_all_MAG = new System.Windows.Forms.Button();
            this.b_check_all_MAG = new System.Windows.Forms.Button();
            this.l_mag_yaw = new System.Windows.Forms.Label();
            this.l_mag_pitch = new System.Windows.Forms.Label();
            this.l_mag_roll = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cb_mag_yaw = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cb_mag_pitch = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cb_mag_roll = new System.Windows.Forms.CheckBox();
            this.l_alt = new System.Windows.Forms.Label();
            this.cb_head = new System.Windows.Forms.CheckBox();
            this.l_head = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.l_i2cerrors = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_vbatt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.l_powersum = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.b_fetch_tiles = new System.Windows.Forms.Button();
            this.b_Clear_Route = new System.Windows.Forms.Button();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.tb_mapzoom = new System.Windows.Forms.TrackBar();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.LMousePos = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cbMapProviders = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.l_GPS_numsat = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lGPS_lon = new System.Windows.Forms.Label();
            this.l_GPS_alt = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lGPS_lat = new System.Windows.Forms.Label();
            this.tabPageFlighDeck = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.dropdown_devices = new System.Windows.Forms.ComboBox();
            this.b_video_connect = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.b_Record = new System.Windows.Forms.Button();
            this.cb_codec = new System.Windows.Forms.ComboBox();
            this.nFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nBitRate = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.l_capture_file = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.l_i2cdatasupress = new System.Windows.Forms.Label();
            this.b_check_update = new System.Windows.Forms.Button();
            this.b_select_settings_folder = new System.Windows.Forms.Button();
            this.l_Settings_folder = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cb_Log10 = new System.Windows.Forms.CheckBox();
            this.cb_Log9 = new System.Windows.Forms.CheckBox();
            this.cb_Log8 = new System.Windows.Forms.CheckBox();
            this.cb_Log7 = new System.Windows.Forms.CheckBox();
            this.cb_Log6 = new System.Windows.Forms.CheckBox();
            this.cb_Log5 = new System.Windows.Forms.CheckBox();
            this.cb_Log4 = new System.Windows.Forms.CheckBox();
            this.cb_Log3 = new System.Windows.Forms.CheckBox();
            this.cb_Log2 = new System.Windows.Forms.CheckBox();
            this.cb_Log1 = new System.Windows.Forms.CheckBox();
            this.b_save_gui_settings = new System.Windows.Forms.Button();
            this.cb_Logging_enabled = new System.Windows.Forms.CheckBox();
            this.b_select_capture_folder = new System.Windows.Forms.Button();
            this.l_Capture_folder = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.b_select_log_folder = new System.Windows.Forms.Button();
            this.l_LogFolder = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPageCLI = new System.Windows.Forms.TabPage();
            this.gbTerminal = new System.Windows.Forms.GroupBox();
            this.cmdCLISend = new System.Windows.Forms.Button();
            this.txtCLICommand = new System.Windows.Forms.TextBox();
            this.txtCLIResult = new System.Windows.Forms.TextBox();
            this.timer_realtime = new System.Windows.Forms.Timer(this.components);
            this.bkgWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cb_serial_port = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cb_serial_speed = new System.Windows.Forms.ToolStripComboBox();
            this.b_connect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.b_read_settings = new System.Windows.Forms.ToolStripButton();
            this.b_write_settings = new System.Windows.Forms.ToolStripButton();
            this.b_reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.b_load_from_file = new System.Windows.Forms.ToolStripButton();
            this.b_write_to_file = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.b_log = new System.Windows.Forms.ToolStripButton();
            this.b_start_KML_log = new System.Windows.Forms.ToolStripButton();
            this.b_log_browser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.b_about = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.throttle_expo_control1 = new MultiWiiGUIControls.throttle_expo_control();
            this.rc_expo_control1 = new MultiWiiGUIControls.rc_expo_control();
            this.rci_Control_settings = new MultiWiiGUIControls.rc_input_control();
            this.rc_input_control1 = new MultiWiiGUIControls.rc_input_control();
            this.motorsIndicator1 = new MultiWiiGUIControls.MWGUIMotors();
            this.gpsIndicator = new MultiWiiGUIControls.GpsIndicatorInstrumentControl();
            this.attitudeIndicatorInstrumentControl1 = new MultiWiiGUIControls.artifical_horizon();
            this.headingIndicatorInstrumentControl1 = new MultiWiiGUIControls.heading_indicator();
            this.indACC = new MultiWiiGUIControls.indicator_lamp();
            this.indBARO = new MultiWiiGUIControls.indicator_lamp();
            this.indMAG = new MultiWiiGUIControls.indicator_lamp();
            this.indSONAR = new MultiWiiGUIControls.indicator_lamp();
            this.indGPS = new MultiWiiGUIControls.indicator_lamp();
            this.indOPTIC = new MultiWiiGUIControls.indicator_lamp();
            this.label46 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabPagePID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTEXPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTMID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_EXPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_MID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Expo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCExpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPAlarm)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_tpid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_yaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_rp)).BeginInit();
            this.tabPageRC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageRealtime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_mapzoom)).BeginInit();
            this.tabPageFlighDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFrameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBitRate)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPageCLI.SuspendLayout();
            this.gbTerminal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPagePID);
            this.tabMain.Controls.Add(this.tabPageRC);
            this.tabMain.Controls.Add(this.tabPageRealtime);
            this.tabMain.Controls.Add(this.tabPageMap);
            this.tabMain.Controls.Add(this.tabPageFlighDeck);
            this.tabMain.Controls.Add(this.tabPageSettings);
            this.tabMain.Controls.Add(this.tabPageCLI);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 54);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(990, 478);
            this.tabMain.TabIndex = 9;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPagePID
            // 
            this.tabPagePID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPagePID.Controls.Add(this.label2);
            this.tabPagePID.Controls.Add(this.label1);
            this.tabPagePID.Controls.Add(this.nTEXPO);
            this.tabPagePID.Controls.Add(this.nTMID);
            this.tabPagePID.Controls.Add(this.trackBar_T_EXPO);
            this.tabPagePID.Controls.Add(this.trackBar_T_MID);
            this.tabPagePID.Controls.Add(this.throttle_expo_control1);
            this.tabPagePID.Controls.Add(this.trackbar_RC_Rate);
            this.tabPagePID.Controls.Add(this.label65);
            this.tabPagePID.Controls.Add(this.trackbar_RC_Expo);
            this.tabPagePID.Controls.Add(this.nRCRate);
            this.tabPagePID.Controls.Add(this.nRCExpo);
            this.tabPagePID.Controls.Add(this.label66);
            this.tabPagePID.Controls.Add(this.label10);
            this.tabPagePID.Controls.Add(this.label9);
            this.tabPagePID.Controls.Add(this.tComment);
            this.tabPagePID.Controls.Add(this.label8);
            this.tabPagePID.Controls.Add(this.nPAlarm);
            this.tabPagePID.Controls.Add(this.rc_expo_control1);
            this.tabPagePID.Controls.Add(this.groupBox12);
            this.tabPagePID.Location = new System.Drawing.Point(4, 22);
            this.tabPagePID.Name = "tabPagePID";
            this.tabPagePID.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePID.Size = new System.Drawing.Size(982, 452);
            this.tabPagePID.TabIndex = 1;
            this.tabPagePID.Text = "Parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(458, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Thr. EXPO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(458, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Thr. MID";
            // 
            // nTEXPO
            // 
            this.nTEXPO.BackColor = System.Drawing.Color.LightGray;
            this.nTEXPO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nTEXPO.DecimalPlaces = 2;
            this.nTEXPO.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTEXPO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nTEXPO.Location = new System.Drawing.Point(458, 257);
            this.nTEXPO.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTEXPO.Name = "nTEXPO";
            this.nTEXPO.Size = new System.Drawing.Size(55, 18);
            this.nTEXPO.TabIndex = 29;
            this.nTEXPO.ValueChanged += new System.EventHandler(this.nTEXPO_ValueChanged);
            // 
            // nTMID
            // 
            this.nTMID.BackColor = System.Drawing.Color.LightGray;
            this.nTMID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nTMID.DecimalPlaces = 2;
            this.nTMID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTMID.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nTMID.Location = new System.Drawing.Point(458, 211);
            this.nTMID.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTMID.Name = "nTMID";
            this.nTMID.Size = new System.Drawing.Size(55, 18);
            this.nTMID.TabIndex = 28;
            this.nTMID.ValueChanged += new System.EventHandler(this.nTMID_ValueChanged);
            // 
            // trackBar_T_EXPO
            // 
            this.trackBar_T_EXPO.AutoSize = false;
            this.trackBar_T_EXPO.LargeChange = 1;
            this.trackBar_T_EXPO.Location = new System.Drawing.Point(453, 312);
            this.trackBar_T_EXPO.Maximum = 100;
            this.trackBar_T_EXPO.Name = "trackBar_T_EXPO";
            this.trackBar_T_EXPO.Size = new System.Drawing.Size(224, 20);
            this.trackBar_T_EXPO.TabIndex = 27;
            this.trackBar_T_EXPO.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_T_EXPO.Value = 100;
            this.trackBar_T_EXPO.Scroll += new System.EventHandler(this.trackBar_T_EXPO_Scroll);
            // 
            // trackBar_T_MID
            // 
            this.trackBar_T_MID.AutoSize = false;
            this.trackBar_T_MID.Location = new System.Drawing.Point(453, 295);
            this.trackBar_T_MID.Maximum = 100;
            this.trackBar_T_MID.Name = "trackBar_T_MID";
            this.trackBar_T_MID.Size = new System.Drawing.Size(224, 20);
            this.trackBar_T_MID.TabIndex = 26;
            this.trackBar_T_MID.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_T_MID.Value = 80;
            this.trackBar_T_MID.Scroll += new System.EventHandler(this.trackBar_T_MID_Scroll);
            // 
            // trackbar_RC_Rate
            // 
            this.trackbar_RC_Rate.AutoSize = false;
            this.trackbar_RC_Rate.LargeChange = 1;
            this.trackbar_RC_Rate.Location = new System.Drawing.Point(451, 160);
            this.trackbar_RC_Rate.Maximum = 250;
            this.trackbar_RC_Rate.Name = "trackbar_RC_Rate";
            this.trackbar_RC_Rate.Size = new System.Drawing.Size(224, 20);
            this.trackbar_RC_Rate.TabIndex = 17;
            this.trackbar_RC_Rate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackbar_RC_Rate.Value = 100;
            this.trackbar_RC_Rate.Scroll += new System.EventHandler(this.trackbar_RC_Rate_Scroll);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ForeColor = System.Drawing.Color.Gainsboro;
            this.label65.Location = new System.Drawing.Point(455, 92);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(48, 13);
            this.label65.TabIndex = 18;
            this.label65.Text = "RC Rate";
            // 
            // trackbar_RC_Expo
            // 
            this.trackbar_RC_Expo.AutoSize = false;
            this.trackbar_RC_Expo.Location = new System.Drawing.Point(451, 143);
            this.trackbar_RC_Expo.Maximum = 100;
            this.trackbar_RC_Expo.Name = "trackbar_RC_Expo";
            this.trackbar_RC_Expo.Size = new System.Drawing.Size(224, 20);
            this.trackbar_RC_Expo.TabIndex = 16;
            this.trackbar_RC_Expo.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackbar_RC_Expo.Value = 80;
            this.trackbar_RC_Expo.Scroll += new System.EventHandler(this.trackbar_RC_Expo_Scroll);
            // 
            // nRCRate
            // 
            this.nRCRate.BackColor = System.Drawing.Color.LightGray;
            this.nRCRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRCRate.DecimalPlaces = 2;
            this.nRCRate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRCRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRCRate.Location = new System.Drawing.Point(458, 109);
            this.nRCRate.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nRCRate.Name = "nRCRate";
            this.nRCRate.Size = new System.Drawing.Size(55, 18);
            this.nRCRate.TabIndex = 20;
            this.nRCRate.ValueChanged += new System.EventHandler(this.nRCRate_ValueChanged);
            // 
            // nRCExpo
            // 
            this.nRCExpo.BackColor = System.Drawing.Color.LightGray;
            this.nRCExpo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRCExpo.DecimalPlaces = 2;
            this.nRCExpo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRCExpo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRCExpo.Location = new System.Drawing.Point(458, 58);
            this.nRCExpo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRCExpo.Name = "nRCExpo";
            this.nRCExpo.Size = new System.Drawing.Size(55, 18);
            this.nRCExpo.TabIndex = 21;
            this.nRCExpo.ValueChanged += new System.EventHandler(this.nRCExpo_ValueChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ForeColor = System.Drawing.Color.Gainsboro;
            this.label66.Location = new System.Drawing.Point(455, 42);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(49, 13);
            this.label66.TabIndex = 19;
            this.label66.Text = "RC Expo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(856, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "max 40 character";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(704, 356);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Comments";
            // 
            // tComment
            // 
            this.tComment.BackColor = System.Drawing.Color.LightGray;
            this.tComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tComment.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tComment.Location = new System.Drawing.Point(706, 372);
            this.tComment.MaxLength = 40;
            this.tComment.Name = "tComment";
            this.tComment.Size = new System.Drawing.Size(239, 15);
            this.tComment.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(705, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Power Meter Alarm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nPAlarm
            // 
            this.nPAlarm.BackColor = System.Drawing.Color.LightGray;
            this.nPAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nPAlarm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nPAlarm.Location = new System.Drawing.Point(824, 396);
            this.nPAlarm.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.nPAlarm.Name = "nPAlarm";
            this.nPAlarm.Size = new System.Drawing.Size(68, 18);
            this.nPAlarm.TabIndex = 6;
            this.nPAlarm.ValueChanged += new System.EventHandler(this.nPAlarm_ValueChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.label_sok);
            this.groupBox12.Controls.Add(this.label60);
            this.groupBox12.Controls.Add(this.nRATE_tpid);
            this.groupBox12.Controls.Add(this.nRATE_yaw);
            this.groupBox12.Controls.Add(this.nRATE_rp);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.White;
            this.groupBox12.Location = new System.Drawing.Point(708, 19);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(247, 95);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Rates/Expo";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.White;
            this.label50.Location = new System.Drawing.Point(15, 70);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(144, 13);
            this.label50.TabIndex = 5;
            this.label50.Text = "Throttle PID attenuation";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_sok
            // 
            this.label_sok.AutoSize = true;
            this.label_sok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sok.ForeColor = System.Drawing.Color.White;
            this.label_sok.Location = new System.Drawing.Point(15, 44);
            this.label_sok.Name = "label_sok";
            this.label_sok.Size = new System.Drawing.Size(68, 13);
            this.label_sok.TabIndex = 4;
            this.label_sok.Text = "Yaw RATE";
            this.label_sok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(15, 18);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(101, 13);
            this.label60.TabIndex = 3;
            this.label60.Text = "Roll/Pitch RATE";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nRATE_tpid
            // 
            this.nRATE_tpid.BackColor = System.Drawing.Color.LightGray;
            this.nRATE_tpid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRATE_tpid.DecimalPlaces = 2;
            this.nRATE_tpid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_tpid.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_tpid.Location = new System.Drawing.Point(160, 68);
            this.nRATE_tpid.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_tpid.Name = "nRATE_tpid";
            this.nRATE_tpid.Size = new System.Drawing.Size(68, 18);
            this.nRATE_tpid.TabIndex = 2;
            this.nRATE_tpid.ValueChanged += new System.EventHandler(this.nRATE_tpid_ValueChanged);
            // 
            // nRATE_yaw
            // 
            this.nRATE_yaw.BackColor = System.Drawing.Color.LightGray;
            this.nRATE_yaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRATE_yaw.DecimalPlaces = 2;
            this.nRATE_yaw.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_yaw.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_yaw.Location = new System.Drawing.Point(160, 42);
            this.nRATE_yaw.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_yaw.Name = "nRATE_yaw";
            this.nRATE_yaw.Size = new System.Drawing.Size(68, 18);
            this.nRATE_yaw.TabIndex = 1;
            this.nRATE_yaw.ValueChanged += new System.EventHandler(this.nRATE_yaw_ValueChanged);
            // 
            // nRATE_rp
            // 
            this.nRATE_rp.BackColor = System.Drawing.Color.LightGray;
            this.nRATE_rp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nRATE_rp.DecimalPlaces = 2;
            this.nRATE_rp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_rp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_rp.Location = new System.Drawing.Point(160, 16);
            this.nRATE_rp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_rp.Name = "nRATE_rp";
            this.nRATE_rp.Size = new System.Drawing.Size(68, 18);
            this.nRATE_rp.TabIndex = 0;
            this.nRATE_rp.ValueChanged += new System.EventHandler(this.nRATE_rp_ValueChanged);
            // 
            // tabPageRC
            // 
            this.tabPageRC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageRC.Controls.Add(this.label5);
            this.tabPageRC.Controls.Add(this.label4);
            this.tabPageRC.Controls.Add(this.pictureBox1);
            this.tabPageRC.Controls.Add(this.rci_Control_settings);
            this.tabPageRC.Location = new System.Drawing.Point(4, 22);
            this.tabPageRC.Name = "tabPageRC";
            this.tabPageRC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRC.Size = new System.Drawing.Size(982, 452);
            this.tabPageRC.TabIndex = 0;
            this.tabPageRC.Text = "RC Control Settings";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(839, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Live RC data";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(635, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Orange border indicates, that setting was changed but not written to FC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::MultiWiiWinGUI.Properties.Resources.checkbox_legend;
            this.pictureBox1.Location = new System.Drawing.Point(596, 429);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tabPageRealtime
            // 
            this.tabPageRealtime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageRealtime.Controls.Add(this.splitContainer1);
            this.tabPageRealtime.ForeColor = System.Drawing.Color.White;
            this.tabPageRealtime.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealtime.Name = "tabPageRealtime";
            this.tabPageRealtime.Size = new System.Drawing.Size(982, 452);
            this.tabPageRealtime.TabIndex = 2;
            this.tabPageRealtime.Text = "Realtime Data";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.b_cal_acc);
            this.splitContainer1.Panel1.Controls.Add(this.cb_monitor_rate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.b_pause);
            this.splitContainer1.Panel1.Controls.Add(this.b_cal_mag);
            this.splitContainer1.Panel1.Controls.Add(this.l_cycletime);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(982, 452);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 108;
            // 
            // b_cal_acc
            // 
            this.b_cal_acc.ForeColor = System.Drawing.Color.Black;
            this.b_cal_acc.Location = new System.Drawing.Point(222, 3);
            this.b_cal_acc.Name = "b_cal_acc";
            this.b_cal_acc.Size = new System.Drawing.Size(84, 21);
            this.b_cal_acc.TabIndex = 78;
            this.b_cal_acc.Text = "Calibrate ACC";
            this.b_cal_acc.UseVisualStyleBackColor = true;
            this.b_cal_acc.Click += new System.EventHandler(this.b_cal_acc_Click);
            // 
            // cb_monitor_rate
            // 
            this.cb_monitor_rate.BackColor = System.Drawing.Color.DimGray;
            this.cb_monitor_rate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_monitor_rate.ForeColor = System.Drawing.Color.White;
            this.cb_monitor_rate.FormattingEnabled = true;
            this.cb_monitor_rate.Location = new System.Drawing.Point(4, 3);
            this.cb_monitor_rate.Name = "cb_monitor_rate";
            this.cb_monitor_rate.Size = new System.Drawing.Size(57, 21);
            this.cb_monitor_rate.TabIndex = 3;
            this.cb_monitor_rate.SelectedIndexChanged += new System.EventHandler(this.cb_monitor_rate_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(65, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Refresh Rate";
            // 
            // b_pause
            // 
            this.b_pause.ForeColor = System.Drawing.Color.Black;
            this.b_pause.Location = new System.Drawing.Point(147, 3);
            this.b_pause.Name = "b_pause";
            this.b_pause.Size = new System.Drawing.Size(69, 21);
            this.b_pause.TabIndex = 77;
            this.b_pause.Text = "Pause";
            this.b_pause.UseVisualStyleBackColor = true;
            this.b_pause.Click += new System.EventHandler(this.b_pause_Click);
            // 
            // b_cal_mag
            // 
            this.b_cal_mag.ForeColor = System.Drawing.Color.Black;
            this.b_cal_mag.Location = new System.Drawing.Point(312, 3);
            this.b_cal_mag.Name = "b_cal_mag";
            this.b_cal_mag.Size = new System.Drawing.Size(84, 21);
            this.b_cal_mag.TabIndex = 79;
            this.b_cal_mag.Text = "Calibrate Mag";
            this.b_cal_mag.UseVisualStyleBackColor = true;
            this.b_cal_mag.Click += new System.EventHandler(this.b_cal_mag_Click);
            // 
            // l_cycletime
            // 
            this.l_cycletime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l_cycletime.AutoSize = true;
            this.l_cycletime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_cycletime.Location = new System.Drawing.Point(916, 9);
            this.l_cycletime.Name = "l_cycletime";
            this.l_cycletime.Size = new System.Drawing.Size(55, 15);
            this.l_cycletime.TabIndex = 98;
            this.l_cycletime.Text = "0000 ms";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(847, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 15);
            this.label11.TabIndex = 99;
            this.label11.Text = "Cycle Time:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gpsIndicator);
            this.splitContainer2.Panel2.Controls.Add(this.l_i2cerrors);
            this.splitContainer2.Panel2.Controls.Add(this.label44);
            this.splitContainer2.Panel2.Controls.Add(this.attitudeIndicatorInstrumentControl1);
            this.splitContainer2.Panel2.Controls.Add(this.label21);
            this.splitContainer2.Panel2.Controls.Add(this.label43);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.l_vbatt);
            this.splitContainer2.Panel2.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label42);
            this.splitContainer2.Panel2.Controls.Add(this.l_powersum);
            this.splitContainer2.Panel2.Controls.Add(this.indACC);
            this.splitContainer2.Panel2.Controls.Add(this.label41);
            this.splitContainer2.Panel2.Controls.Add(this.indBARO);
            this.splitContainer2.Panel2.Controls.Add(this.indMAG);
            this.splitContainer2.Panel2.Controls.Add(this.indSONAR);
            this.splitContainer2.Panel2.Controls.Add(this.indGPS);
            this.splitContainer2.Panel2.Controls.Add(this.indOPTIC);
            this.splitContainer2.Size = new System.Drawing.Size(982, 416);
            this.splitContainer2.SplitterDistance = 256;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rc_input_control1);
            this.splitContainer3.Panel2.Controls.Add(this.motorsIndicator1);
            this.splitContainer3.Size = new System.Drawing.Size(982, 256);
            this.splitContainer3.SplitterDistance = 597;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer4.Panel2.Controls.Add(this.cb_alt);
            this.splitContainer4.Panel2.Controls.Add(this.label22);
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Panel2.Controls.Add(this.l_alt);
            this.splitContainer4.Panel2.Controls.Add(this.cb_head);
            this.splitContainer4.Panel2.Controls.Add(this.l_head);
            this.splitContainer4.Panel2.Controls.Add(this.label26);
            this.splitContainer4.Size = new System.Drawing.Size(597, 256);
            this.splitContainer4.SplitterDistance = 474;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.zgMonitor);
            this.splitContainer5.Panel1MinSize = 10;
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.label28);
            this.splitContainer5.Panel2.Controls.Add(this.cb_dbg1);
            this.splitContainer5.Panel2.Controls.Add(this.l_dbg1);
            this.splitContainer5.Panel2.Controls.Add(this.cb_dbg2);
            this.splitContainer5.Panel2.Controls.Add(this.label33);
            this.splitContainer5.Panel2.Controls.Add(this.l_dbg2);
            this.splitContainer5.Panel2.Controls.Add(this.cb_dbg3);
            this.splitContainer5.Panel2.Controls.Add(this.l_dbg4);
            this.splitContainer5.Panel2.Controls.Add(this.label38);
            this.splitContainer5.Panel2.Controls.Add(this.label40);
            this.splitContainer5.Panel2.Controls.Add(this.l_dbg3);
            this.splitContainer5.Panel2.Controls.Add(this.cb_dbg4);
            this.splitContainer5.Panel2MinSize = 10;
            this.splitContainer5.Size = new System.Drawing.Size(474, 256);
            this.splitContainer5.SplitterDistance = 227;
            this.splitContainer5.TabIndex = 0;
            // 
            // zgMonitor
            // 
            this.zgMonitor.AutoSize = true;
            this.zgMonitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zgMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zgMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgMonitor.IsZoomOnMouseCenter = true;
            this.zgMonitor.Location = new System.Drawing.Point(0, 0);
            this.zgMonitor.Name = "zgMonitor";
            this.zgMonitor.ScrollGrace = 0D;
            this.zgMonitor.ScrollMaxX = 0D;
            this.zgMonitor.ScrollMaxY = 0D;
            this.zgMonitor.ScrollMaxY2 = 0D;
            this.zgMonitor.ScrollMinX = 0D;
            this.zgMonitor.ScrollMinY = 0D;
            this.zgMonitor.ScrollMinY2 = 0D;
            this.zgMonitor.Size = new System.Drawing.Size(474, 227);
            this.zgMonitor.TabIndex = 5;
            this.zgMonitor.Load += new System.EventHandler(this.zgMonitor_Load);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(39, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 14);
            this.label28.TabIndex = 60;
            this.label28.Text = "DBG1";
            // 
            // cb_dbg1
            // 
            this.cb_dbg1.AutoSize = true;
            this.cb_dbg1.Location = new System.Drawing.Point(26, 0);
            this.cb_dbg1.Name = "cb_dbg1";
            this.cb_dbg1.Size = new System.Drawing.Size(15, 14);
            this.cb_dbg1.TabIndex = 59;
            this.cb_dbg1.UseVisualStyleBackColor = true;
            // 
            // l_dbg1
            // 
            this.l_dbg1.AutoSize = true;
            this.l_dbg1.Location = new System.Drawing.Point(83, 1);
            this.l_dbg1.Name = "l_dbg1";
            this.l_dbg1.Size = new System.Drawing.Size(13, 13);
            this.l_dbg1.TabIndex = 61;
            this.l_dbg1.Text = "0";
            // 
            // cb_dbg2
            // 
            this.cb_dbg2.AutoSize = true;
            this.cb_dbg2.Location = new System.Drawing.Point(130, -1);
            this.cb_dbg2.Name = "cb_dbg2";
            this.cb_dbg2.Size = new System.Drawing.Size(15, 14);
            this.cb_dbg2.TabIndex = 62;
            this.cb_dbg2.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(143, -1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 14);
            this.label33.TabIndex = 63;
            this.label33.Text = "DBG2";
            // 
            // l_dbg2
            // 
            this.l_dbg2.AutoSize = true;
            this.l_dbg2.Location = new System.Drawing.Point(187, 0);
            this.l_dbg2.Name = "l_dbg2";
            this.l_dbg2.Size = new System.Drawing.Size(13, 13);
            this.l_dbg2.TabIndex = 64;
            this.l_dbg2.Text = "0";
            // 
            // cb_dbg3
            // 
            this.cb_dbg3.AutoSize = true;
            this.cb_dbg3.Location = new System.Drawing.Point(235, -1);
            this.cb_dbg3.Name = "cb_dbg3";
            this.cb_dbg3.Size = new System.Drawing.Size(15, 14);
            this.cb_dbg3.TabIndex = 65;
            this.cb_dbg3.UseVisualStyleBackColor = true;
            // 
            // l_dbg4
            // 
            this.l_dbg4.AutoSize = true;
            this.l_dbg4.Location = new System.Drawing.Point(413, 0);
            this.l_dbg4.Name = "l_dbg4";
            this.l_dbg4.Size = new System.Drawing.Size(13, 13);
            this.l_dbg4.TabIndex = 70;
            this.l_dbg4.Text = "0";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(248, -1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 14);
            this.label38.TabIndex = 66;
            this.label38.Text = "DBG3";
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(366, -1);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 14);
            this.label40.TabIndex = 69;
            this.label40.Text = "DBG4";
            // 
            // l_dbg3
            // 
            this.l_dbg3.AutoSize = true;
            this.l_dbg3.Location = new System.Drawing.Point(292, 0);
            this.l_dbg3.Name = "l_dbg3";
            this.l_dbg3.Size = new System.Drawing.Size(13, 13);
            this.l_dbg3.TabIndex = 67;
            this.l_dbg3.Text = "0";
            // 
            // cb_dbg4
            // 
            this.cb_dbg4.AutoSize = true;
            this.cb_dbg4.Location = new System.Drawing.Point(353, -1);
            this.cb_dbg4.Name = "cb_dbg4";
            this.cb_dbg4.Size = new System.Drawing.Size(15, 14);
            this.cb_dbg4.TabIndex = 68;
            this.cb_dbg4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.b_uncheck_all_ACC);
            this.groupBox1.Controls.Add(this.b_check_all_ACC);
            this.groupBox1.Controls.Add(this.l_acc_z);
            this.groupBox1.Controls.Add(this.l_acc_pitch);
            this.groupBox1.Controls.Add(this.l_acc_roll);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cb_acc_z);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cb_acc_pitch);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cb_acc_roll);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 69);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accelerometer";
            // 
            // b_uncheck_all_ACC
            // 
            this.b_uncheck_all_ACC.ForeColor = System.Drawing.Color.Black;
            this.b_uncheck_all_ACC.Location = new System.Drawing.Point(88, 45);
            this.b_uncheck_all_ACC.Name = "b_uncheck_all_ACC";
            this.b_uncheck_all_ACC.Size = new System.Drawing.Size(20, 20);
            this.b_uncheck_all_ACC.TabIndex = 105;
            this.b_uncheck_all_ACC.Text = "X";
            this.b_uncheck_all_ACC.UseVisualStyleBackColor = true;
            this.b_uncheck_all_ACC.Click += new System.EventHandler(this.b_uncheck_all_ACC_Click);
            // 
            // b_check_all_ACC
            // 
            this.b_check_all_ACC.ForeColor = System.Drawing.Color.Black;
            this.b_check_all_ACC.Location = new System.Drawing.Point(88, 12);
            this.b_check_all_ACC.Name = "b_check_all_ACC";
            this.b_check_all_ACC.Size = new System.Drawing.Size(20, 20);
            this.b_check_all_ACC.TabIndex = 104;
            this.b_check_all_ACC.Text = "+";
            this.b_check_all_ACC.UseVisualStyleBackColor = true;
            this.b_check_all_ACC.Click += new System.EventHandler(this.b_check_all_ACC_Click);
            // 
            // l_acc_z
            // 
            this.l_acc_z.AutoSize = true;
            this.l_acc_z.Location = new System.Drawing.Point(66, 45);
            this.l_acc_z.Name = "l_acc_z";
            this.l_acc_z.Size = new System.Drawing.Size(13, 13);
            this.l_acc_z.TabIndex = 52;
            this.l_acc_z.Text = "0";
            // 
            // l_acc_pitch
            // 
            this.l_acc_pitch.AutoSize = true;
            this.l_acc_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_acc_pitch.Name = "l_acc_pitch";
            this.l_acc_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_acc_pitch.TabIndex = 51;
            this.l_acc_pitch.Text = "0";
            // 
            // l_acc_roll
            // 
            this.l_acc_roll.AutoSize = true;
            this.l_acc_roll.Location = new System.Drawing.Point(66, 16);
            this.l_acc_roll.Name = "l_acc_roll";
            this.l_acc_roll.Size = new System.Drawing.Size(13, 13);
            this.l_acc_roll.TabIndex = 50;
            this.l_acc_roll.Text = "0";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Blue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(22, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 14);
            this.label18.TabIndex = 49;
            this.label18.Text = "Z";
            // 
            // cb_acc_z
            // 
            this.cb_acc_z.AutoSize = true;
            this.cb_acc_z.Checked = true;
            this.cb_acc_z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_z.Location = new System.Drawing.Point(9, 44);
            this.cb_acc_z.Name = "cb_acc_z";
            this.cb_acc_z.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_z.TabIndex = 48;
            this.cb_acc_z.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Green;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 14);
            this.label16.TabIndex = 47;
            this.label16.Text = "PITCH";
            // 
            // cb_acc_pitch
            // 
            this.cb_acc_pitch.AutoSize = true;
            this.cb_acc_pitch.Checked = true;
            this.cb_acc_pitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_acc_pitch.Name = "cb_acc_pitch";
            this.cb_acc_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_pitch.TabIndex = 46;
            this.cb_acc_pitch.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Red;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 14);
            this.label14.TabIndex = 45;
            this.label14.Text = "ROLL";
            // 
            // cb_acc_roll
            // 
            this.cb_acc_roll.AutoSize = true;
            this.cb_acc_roll.Checked = true;
            this.cb_acc_roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_acc_roll.Name = "cb_acc_roll";
            this.cb_acc_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_roll.TabIndex = 44;
            this.cb_acc_roll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.b_uncheck_all_GYRO);
            this.groupBox2.Controls.Add(this.b_check_all_GYRO);
            this.groupBox2.Controls.Add(this.l_gyro_yaw);
            this.groupBox2.Controls.Add(this.l_gyro_pitch);
            this.groupBox2.Controls.Add(this.l_gyro_roll);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.cb_gyro_yaw);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.cb_gyro_pitch);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.cb_gyro_roll);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 69);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gyroscope";
            // 
            // b_uncheck_all_GYRO
            // 
            this.b_uncheck_all_GYRO.ForeColor = System.Drawing.Color.Black;
            this.b_uncheck_all_GYRO.Location = new System.Drawing.Point(88, 45);
            this.b_uncheck_all_GYRO.Name = "b_uncheck_all_GYRO";
            this.b_uncheck_all_GYRO.Size = new System.Drawing.Size(20, 20);
            this.b_uncheck_all_GYRO.TabIndex = 108;
            this.b_uncheck_all_GYRO.Text = "X";
            this.b_uncheck_all_GYRO.UseVisualStyleBackColor = true;
            this.b_uncheck_all_GYRO.Click += new System.EventHandler(this.b_uncheck_all_GYRO_Click);
            // 
            // b_check_all_GYRO
            // 
            this.b_check_all_GYRO.ForeColor = System.Drawing.Color.Black;
            this.b_check_all_GYRO.Location = new System.Drawing.Point(88, 12);
            this.b_check_all_GYRO.Name = "b_check_all_GYRO";
            this.b_check_all_GYRO.Size = new System.Drawing.Size(20, 20);
            this.b_check_all_GYRO.TabIndex = 107;
            this.b_check_all_GYRO.Text = "+";
            this.b_check_all_GYRO.UseVisualStyleBackColor = true;
            this.b_check_all_GYRO.Click += new System.EventHandler(this.b_check_all_GYRO_Click);
            // 
            // l_gyro_yaw
            // 
            this.l_gyro_yaw.AutoSize = true;
            this.l_gyro_yaw.Location = new System.Drawing.Point(66, 45);
            this.l_gyro_yaw.Name = "l_gyro_yaw";
            this.l_gyro_yaw.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_yaw.TabIndex = 52;
            this.l_gyro_yaw.Text = "0";
            // 
            // l_gyro_pitch
            // 
            this.l_gyro_pitch.AutoSize = true;
            this.l_gyro_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_gyro_pitch.Name = "l_gyro_pitch";
            this.l_gyro_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_pitch.TabIndex = 51;
            this.l_gyro_pitch.Text = "0";
            // 
            // l_gyro_roll
            // 
            this.l_gyro_roll.AutoSize = true;
            this.l_gyro_roll.Location = new System.Drawing.Point(66, 16);
            this.l_gyro_roll.Name = "l_gyro_roll";
            this.l_gyro_roll.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_roll.TabIndex = 50;
            this.l_gyro_roll.Text = "0";
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Magenta;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(22, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 14);
            this.label29.TabIndex = 49;
            this.label29.Text = "YAW";
            // 
            // cb_gyro_yaw
            // 
            this.cb_gyro_yaw.AutoSize = true;
            this.cb_gyro_yaw.Checked = true;
            this.cb_gyro_yaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_yaw.Location = new System.Drawing.Point(9, 44);
            this.cb_gyro_yaw.Name = "cb_gyro_yaw";
            this.cb_gyro_yaw.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_yaw.TabIndex = 48;
            this.cb_gyro_yaw.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Cyan;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(22, 30);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 14);
            this.label30.TabIndex = 47;
            this.label30.Text = "PITCH";
            // 
            // cb_gyro_pitch
            // 
            this.cb_gyro_pitch.AutoSize = true;
            this.cb_gyro_pitch.Checked = true;
            this.cb_gyro_pitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_gyro_pitch.Name = "cb_gyro_pitch";
            this.cb_gyro_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_pitch.TabIndex = 46;
            this.cb_gyro_pitch.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Khaki;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(22, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 14);
            this.label31.TabIndex = 45;
            this.label31.Text = "ROLL";
            // 
            // cb_gyro_roll
            // 
            this.cb_gyro_roll.AutoSize = true;
            this.cb_gyro_roll.Checked = true;
            this.cb_gyro_roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_gyro_roll.Name = "cb_gyro_roll";
            this.cb_gyro_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_roll.TabIndex = 44;
            this.cb_gyro_roll.UseVisualStyleBackColor = true;
            // 
            // cb_alt
            // 
            this.cb_alt.AutoSize = true;
            this.cb_alt.Location = new System.Drawing.Point(12, 214);
            this.cb_alt.Name = "cb_alt";
            this.cb_alt.Size = new System.Drawing.Size(15, 14);
            this.cb_alt.TabIndex = 53;
            this.cb_alt.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Gainsboro;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(25, 214);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 14);
            this.label22.TabIndex = 54;
            this.label22.Text = "ALT";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.b_uncheck_all_MAG);
            this.groupBox3.Controls.Add(this.b_check_all_MAG);
            this.groupBox3.Controls.Add(this.l_mag_yaw);
            this.groupBox3.Controls.Add(this.l_mag_pitch);
            this.groupBox3.Controls.Add(this.l_mag_roll);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.cb_mag_yaw);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.cb_mag_pitch);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.cb_mag_roll);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(3, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 69);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Magnetometer";
            // 
            // b_uncheck_all_MAG
            // 
            this.b_uncheck_all_MAG.ForeColor = System.Drawing.Color.Black;
            this.b_uncheck_all_MAG.Location = new System.Drawing.Point(88, 44);
            this.b_uncheck_all_MAG.Name = "b_uncheck_all_MAG";
            this.b_uncheck_all_MAG.Size = new System.Drawing.Size(20, 20);
            this.b_uncheck_all_MAG.TabIndex = 107;
            this.b_uncheck_all_MAG.Text = "X";
            this.b_uncheck_all_MAG.UseVisualStyleBackColor = true;
            this.b_uncheck_all_MAG.Click += new System.EventHandler(this.b_uncheck_all_MAG_Click);
            // 
            // b_check_all_MAG
            // 
            this.b_check_all_MAG.ForeColor = System.Drawing.Color.Black;
            this.b_check_all_MAG.Location = new System.Drawing.Point(88, 12);
            this.b_check_all_MAG.Name = "b_check_all_MAG";
            this.b_check_all_MAG.Size = new System.Drawing.Size(20, 20);
            this.b_check_all_MAG.TabIndex = 106;
            this.b_check_all_MAG.Text = "+";
            this.b_check_all_MAG.UseVisualStyleBackColor = true;
            this.b_check_all_MAG.Click += new System.EventHandler(this.b_check_all_MAG_Click);
            // 
            // l_mag_yaw
            // 
            this.l_mag_yaw.AutoSize = true;
            this.l_mag_yaw.Location = new System.Drawing.Point(66, 45);
            this.l_mag_yaw.Name = "l_mag_yaw";
            this.l_mag_yaw.Size = new System.Drawing.Size(13, 13);
            this.l_mag_yaw.TabIndex = 52;
            this.l_mag_yaw.Text = "0";
            // 
            // l_mag_pitch
            // 
            this.l_mag_pitch.AutoSize = true;
            this.l_mag_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_mag_pitch.Name = "l_mag_pitch";
            this.l_mag_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_mag_pitch.TabIndex = 51;
            this.l_mag_pitch.Text = "0";
            // 
            // l_mag_roll
            // 
            this.l_mag_roll.AutoSize = true;
            this.l_mag_roll.Location = new System.Drawing.Point(66, 16);
            this.l_mag_roll.Name = "l_mag_roll";
            this.l_mag_roll.Size = new System.Drawing.Size(13, 13);
            this.l_mag_roll.TabIndex = 50;
            this.l_mag_roll.Text = "0";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(22, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(41, 14);
            this.label35.TabIndex = 49;
            this.label35.Text = "YAW";
            // 
            // cb_mag_yaw
            // 
            this.cb_mag_yaw.AutoSize = true;
            this.cb_mag_yaw.Location = new System.Drawing.Point(9, 44);
            this.cb_mag_yaw.Name = "cb_mag_yaw";
            this.cb_mag_yaw.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_yaw.TabIndex = 48;
            this.cb_mag_yaw.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.MediumPurple;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(22, 30);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 14);
            this.label36.TabIndex = 47;
            this.label36.Text = "PITCH";
            // 
            // cb_mag_pitch
            // 
            this.cb_mag_pitch.AutoSize = true;
            this.cb_mag_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_mag_pitch.Name = "cb_mag_pitch";
            this.cb_mag_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_pitch.TabIndex = 46;
            this.cb_mag_pitch.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.CadetBlue;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(22, 16);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 14);
            this.label37.TabIndex = 45;
            this.label37.Text = "ROLL";
            // 
            // cb_mag_roll
            // 
            this.cb_mag_roll.AutoSize = true;
            this.cb_mag_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_mag_roll.Name = "cb_mag_roll";
            this.cb_mag_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_roll.TabIndex = 44;
            this.cb_mag_roll.UseVisualStyleBackColor = true;
            // 
            // l_alt
            // 
            this.l_alt.AutoSize = true;
            this.l_alt.Location = new System.Drawing.Point(69, 215);
            this.l_alt.Name = "l_alt";
            this.l_alt.Size = new System.Drawing.Size(13, 13);
            this.l_alt.TabIndex = 55;
            this.l_alt.Text = "0";
            // 
            // cb_head
            // 
            this.cb_head.AutoSize = true;
            this.cb_head.Location = new System.Drawing.Point(12, 231);
            this.cb_head.Name = "cb_head";
            this.cb_head.Size = new System.Drawing.Size(15, 14);
            this.cb_head.TabIndex = 56;
            this.cb_head.UseVisualStyleBackColor = true;
            // 
            // l_head
            // 
            this.l_head.AutoSize = true;
            this.l_head.Location = new System.Drawing.Point(69, 232);
            this.l_head.Name = "l_head";
            this.l_head.Size = new System.Drawing.Size(13, 13);
            this.l_head.TabIndex = 58;
            this.l_head.Text = "0";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Orange;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(25, 231);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 14);
            this.label26.TabIndex = 57;
            this.label26.Text = "HEAD";
            // 
            // l_i2cerrors
            // 
            this.l_i2cerrors.AutoSize = true;
            this.l_i2cerrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_i2cerrors.Location = new System.Drawing.Point(726, 7);
            this.l_i2cerrors.Name = "l_i2cerrors";
            this.l_i2cerrors.Size = new System.Drawing.Size(35, 15);
            this.l_i2cerrors.TabIndex = 102;
            this.l_i2cerrors.Text = "0000";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(464, 140);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 13);
            this.label44.TabIndex = 107;
            this.label44.Text = "Packet error";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(639, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 15);
            this.label21.TabIndex = 101;
            this.label21.Text = "I²C Error count:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(464, 127);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(92, 13);
            this.label43.TabIndex = 106;
            this.label43.Text = "Packet\'s received";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(636, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 94;
            this.label6.Text = "Battery Voltage:";
            // 
            // l_vbatt
            // 
            this.l_vbatt.AutoSize = true;
            this.l_vbatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_vbatt.Location = new System.Drawing.Point(726, 20);
            this.l_vbatt.Name = "l_vbatt";
            this.l_vbatt.Size = new System.Drawing.Size(51, 15);
            this.l_vbatt.TabIndex = 97;
            this.l_vbatt.Text = "0.0 volts";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(653, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 95;
            this.label7.Text = "Power Sum:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(557, 127);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(13, 13);
            this.label42.TabIndex = 105;
            this.label42.Text = "0";
            // 
            // l_powersum
            // 
            this.l_powersum.AutoSize = true;
            this.l_powersum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_powersum.Location = new System.Drawing.Point(726, 35);
            this.l_powersum.Name = "l_powersum";
            this.l_powersum.Size = new System.Drawing.Size(35, 15);
            this.l_powersum.TabIndex = 96;
            this.l_powersum.Text = "0000";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(557, 140);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(13, 13);
            this.label41.TabIndex = 104;
            this.label41.Text = "0";
            // 
            // tabPageMap
            // 
            this.tabPageMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageMap.Controls.Add(this.splitContainer7);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(982, 452);
            this.tabPageMap.TabIndex = 5;
            this.tabPageMap.Text = "Map";
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.b_fetch_tiles);
            this.splitContainer7.Panel1.Controls.Add(this.b_Clear_Route);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(982, 452);
            this.splitContainer7.SplitterDistance = 31;
            this.splitContainer7.TabIndex = 10;
            // 
            // b_fetch_tiles
            // 
            this.b_fetch_tiles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.b_fetch_tiles.Location = new System.Drawing.Point(803, 3);
            this.b_fetch_tiles.Name = "b_fetch_tiles";
            this.b_fetch_tiles.Size = new System.Drawing.Size(75, 23);
            this.b_fetch_tiles.TabIndex = 10;
            this.b_fetch_tiles.Text = "Fetch MAP";
            this.b_fetch_tiles.UseVisualStyleBackColor = true;
            this.b_fetch_tiles.Click += new System.EventHandler(this.b_fetch_tiles_Click);
            // 
            // b_Clear_Route
            // 
            this.b_Clear_Route.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.b_Clear_Route.Location = new System.Drawing.Point(888, 3);
            this.b_Clear_Route.Name = "b_Clear_Route";
            this.b_Clear_Route.Size = new System.Drawing.Size(75, 23);
            this.b_Clear_Route.TabIndex = 9;
            this.b_Clear_Route.Text = "Clear Route";
            this.b_Clear_Route.UseVisualStyleBackColor = true;
            this.b_Clear_Route.Click += new System.EventHandler(this.b_Clear_Route_Click);
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.splitContainer9);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.label23);
            this.splitContainer8.Panel2.Controls.Add(this.cbMapProviders);
            this.splitContainer8.Panel2.Controls.Add(this.label25);
            this.splitContainer8.Panel2.Controls.Add(this.l_GPS_numsat);
            this.splitContainer8.Panel2.Controls.Add(this.label32);
            this.splitContainer8.Panel2.Controls.Add(this.label39);
            this.splitContainer8.Panel2.Controls.Add(this.lGPS_lon);
            this.splitContainer8.Panel2.Controls.Add(this.l_GPS_alt);
            this.splitContainer8.Panel2.Controls.Add(this.label34);
            this.splitContainer8.Panel2.Controls.Add(this.lGPS_lat);
            this.splitContainer8.Size = new System.Drawing.Size(982, 417);
            this.splitContainer8.SplitterDistance = 771;
            this.splitContainer8.TabIndex = 0;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.tb_mapzoom);
            this.splitContainer9.Panel1.Controls.Add(this.MainMap);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.label46);
            this.splitContainer9.Panel2.Controls.Add(this.LMousePos);
            this.splitContainer9.Panel2.Controls.Add(this.label45);
            this.splitContainer9.Size = new System.Drawing.Size(771, 417);
            this.splitContainer9.SplitterDistance = 321;
            this.splitContainer9.TabIndex = 0;
            // 
            // tb_mapzoom
            // 
            this.tb_mapzoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_mapzoom.LargeChange = 1;
            this.tb_mapzoom.Location = new System.Drawing.Point(726, 0);
            this.tb_mapzoom.Maximum = 19;
            this.tb_mapzoom.Minimum = 2;
            this.tb_mapzoom.Name = "tb_mapzoom";
            this.tb_mapzoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_mapzoom.Size = new System.Drawing.Size(45, 321);
            this.tb_mapzoom.TabIndex = 32;
            this.tb_mapzoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tb_mapzoom.Value = 19;
            this.tb_mapzoom.Scroll += new System.EventHandler(this.tb_mapzoom_Scroll);
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 19;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(771, 321);
            this.MainMap.TabIndex = 33;
            this.MainMap.Zoom = 0D;
            // 
            // LMousePos
            // 
            this.LMousePos.AutoSize = true;
            this.LMousePos.ForeColor = System.Drawing.Color.White;
            this.LMousePos.Location = new System.Drawing.Point(8, 16);
            this.LMousePos.Name = "LMousePos";
            this.LMousePos.Size = new System.Drawing.Size(22, 13);
            this.LMousePos.TabIndex = 35;
            this.LMousePos.Text = "0,0";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(8, 3);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(72, 13);
            this.label45.TabIndex = 34;
            this.label45.Text = "POS@Mouse";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(54, 306);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 33;
            this.label23.Text = "Map Provider";
            // 
            // cbMapProviders
            // 
            this.cbMapProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMapProviders.FormattingEnabled = true;
            this.cbMapProviders.Location = new System.Drawing.Point(54, 325);
            this.cbMapProviders.Name = "cbMapProviders";
            this.cbMapProviders.Size = new System.Drawing.Size(145, 21);
            this.cbMapProviders.TabIndex = 32;
            this.cbMapProviders.SelectedIndexChanged += new System.EventHandler(this.cbMapProviders_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(3, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "Latitude";
            // 
            // l_GPS_numsat
            // 
            this.l_GPS_numsat.AutoSize = true;
            this.l_GPS_numsat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_GPS_numsat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.l_GPS_numsat.Location = new System.Drawing.Point(3, 109);
            this.l_GPS_numsat.Name = "l_GPS_numsat";
            this.l_GPS_numsat.Size = new System.Drawing.Size(16, 16);
            this.l_GPS_numsat.TabIndex = 8;
            this.l_GPS_numsat.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label32.Location = new System.Drawing.Point(3, 29);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(54, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "Longitude";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label39.Location = new System.Drawing.Point(3, 96);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(23, 13);
            this.label39.TabIndex = 7;
            this.label39.Text = "Sat";
            // 
            // lGPS_lon
            // 
            this.lGPS_lon.AutoSize = true;
            this.lGPS_lon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGPS_lon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lGPS_lon.Location = new System.Drawing.Point(3, 42);
            this.lGPS_lon.Name = "lGPS_lon";
            this.lGPS_lon.Size = new System.Drawing.Size(16, 16);
            this.lGPS_lon.TabIndex = 3;
            this.lGPS_lon.Text = "0";
            // 
            // l_GPS_alt
            // 
            this.l_GPS_alt.AutoSize = true;
            this.l_GPS_alt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_GPS_alt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.l_GPS_alt.Location = new System.Drawing.Point(3, 80);
            this.l_GPS_alt.Name = "l_GPS_alt";
            this.l_GPS_alt.Size = new System.Drawing.Size(16, 16);
            this.l_GPS_alt.TabIndex = 6;
            this.l_GPS_alt.Text = "0";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label34.Location = new System.Drawing.Point(3, 67);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 13);
            this.label34.TabIndex = 5;
            this.label34.Text = "GPS alt";
            // 
            // lGPS_lat
            // 
            this.lGPS_lat.AutoSize = true;
            this.lGPS_lat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGPS_lat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lGPS_lat.Location = new System.Drawing.Point(3, 13);
            this.lGPS_lat.Name = "lGPS_lat";
            this.lGPS_lat.Size = new System.Drawing.Size(16, 16);
            this.lGPS_lat.TabIndex = 4;
            this.lGPS_lat.Text = "0";
            // 
            // tabPageFlighDeck
            // 
            this.tabPageFlighDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageFlighDeck.Controls.Add(this.splitContainer6);
            this.tabPageFlighDeck.Controls.Add(this.l_capture_file);
            this.tabPageFlighDeck.Location = new System.Drawing.Point(4, 22);
            this.tabPageFlighDeck.Name = "tabPageFlighDeck";
            this.tabPageFlighDeck.Size = new System.Drawing.Size(982, 452);
            this.tabPageFlighDeck.TabIndex = 3;
            this.tabPageFlighDeck.Text = "VideoCapture";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.videoSourcePlayer);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.dropdown_devices);
            this.splitContainer6.Panel2.Controls.Add(this.b_video_connect);
            this.splitContainer6.Panel2.Controls.Add(this.label19);
            this.splitContainer6.Panel2.Controls.Add(this.b_Record);
            this.splitContainer6.Panel2.Controls.Add(this.cb_codec);
            this.splitContainer6.Panel2.Controls.Add(this.nFrameRate);
            this.splitContainer6.Panel2.Controls.Add(this.label17);
            this.splitContainer6.Panel2.Controls.Add(this.label12);
            this.splitContainer6.Panel2.Controls.Add(this.label15);
            this.splitContainer6.Panel2.Controls.Add(this.nBitRate);
            this.splitContainer6.Panel2.Controls.Add(this.label13);
            this.splitContainer6.Size = new System.Drawing.Size(982, 452);
            this.splitContainer6.SplitterDistance = 766;
            this.splitContainer6.TabIndex = 13;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Padding = new System.Windows.Forms.Padding(10);
            this.videoSourcePlayer.Size = new System.Drawing.Size(766, 452);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.SizeChanged += new System.EventHandler(this.videoSourcePlayer_SizeChanged);
            // 
            // dropdown_devices
            // 
            this.dropdown_devices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdown_devices.BackColor = System.Drawing.Color.Gray;
            this.dropdown_devices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdown_devices.FormattingEnabled = true;
            this.dropdown_devices.Location = new System.Drawing.Point(14, 12);
            this.dropdown_devices.Name = "dropdown_devices";
            this.dropdown_devices.Size = new System.Drawing.Size(190, 21);
            this.dropdown_devices.TabIndex = 1;
            // 
            // b_video_connect
            // 
            this.b_video_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_video_connect.Location = new System.Drawing.Point(14, 40);
            this.b_video_connect.Name = "b_video_connect";
            this.b_video_connect.Size = new System.Drawing.Size(190, 23);
            this.b_video_connect.TabIndex = 2;
            this.b_video_connect.Text = "Connect video device";
            this.b_video_connect.UseVisualStyleBackColor = true;
            this.b_video_connect.Click += new System.EventHandler(this.b_video_connect_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(36, 337);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "CODEC";
            // 
            // b_Record
            // 
            this.b_Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Record.Location = new System.Drawing.Point(14, 70);
            this.b_Record.Name = "b_Record";
            this.b_Record.Size = new System.Drawing.Size(190, 23);
            this.b_Record.TabIndex = 3;
            this.b_Record.Text = "Record";
            this.b_Record.UseVisualStyleBackColor = true;
            this.b_Record.Click += new System.EventHandler(this.b_Record_Click);
            // 
            // cb_codec
            // 
            this.cb_codec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_codec.FormattingEnabled = true;
            this.cb_codec.Items.AddRange(new object[] {
            "MPEG4 part2",
            "WMV-7",
            "WMV-8",
            "MS-MPEG4v2",
            "MS-MPEG4v3",
            "H.263+",
            "FLV",
            "MPEG2",
            "RAW"});
            this.cb_codec.Location = new System.Drawing.Point(86, 334);
            this.cb_codec.Name = "cb_codec";
            this.cb_codec.Size = new System.Drawing.Size(104, 21);
            this.cb_codec.TabIndex = 10;
            // 
            // nFrameRate
            // 
            this.nFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nFrameRate.Location = new System.Drawing.Point(86, 387);
            this.nFrameRate.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nFrameRate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nFrameRate.Name = "nFrameRate";
            this.nFrameRate.Size = new System.Drawing.Size(49, 20);
            this.nFrameRate.TabIndex = 4;
            this.nFrameRate.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(141, 363);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Mbit/sec";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(21, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "FrameRate";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(141, 389);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "FPS";
            // 
            // nBitRate
            // 
            this.nBitRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nBitRate.DecimalPlaces = 1;
            this.nBitRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nBitRate.Location = new System.Drawing.Point(86, 361);
            this.nBitRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nBitRate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nBitRate.Name = "nBitRate";
            this.nBitRate.Size = new System.Drawing.Size(49, 20);
            this.nBitRate.TabIndex = 6;
            this.nBitRate.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(36, 363);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "BitRate";
            // 
            // l_capture_file
            // 
            this.l_capture_file.AutoSize = true;
            this.l_capture_file.ForeColor = System.Drawing.Color.Gainsboro;
            this.l_capture_file.Location = new System.Drawing.Point(1218, 895);
            this.l_capture_file.Name = "l_capture_file";
            this.l_capture_file.Size = new System.Drawing.Size(0, 13);
            this.l_capture_file.TabIndex = 12;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageSettings.Controls.Add(this.l_i2cdatasupress);
            this.tabPageSettings.Controls.Add(this.b_check_update);
            this.tabPageSettings.Controls.Add(this.b_select_settings_folder);
            this.tabPageSettings.Controls.Add(this.l_Settings_folder);
            this.tabPageSettings.Controls.Add(this.label27);
            this.tabPageSettings.Controls.Add(this.groupBox11);
            this.tabPageSettings.Controls.Add(this.b_save_gui_settings);
            this.tabPageSettings.Controls.Add(this.cb_Logging_enabled);
            this.tabPageSettings.Controls.Add(this.b_select_capture_folder);
            this.tabPageSettings.Controls.Add(this.l_Capture_folder);
            this.tabPageSettings.Controls.Add(this.label24);
            this.tabPageSettings.Controls.Add(this.b_select_log_folder);
            this.tabPageSettings.Controls.Add(this.l_LogFolder);
            this.tabPageSettings.Controls.Add(this.label20);
            this.tabPageSettings.ForeColor = System.Drawing.Color.White;
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(982, 452);
            this.tabPageSettings.TabIndex = 4;
            this.tabPageSettings.Text = "GUI Settings";
            // 
            // l_i2cdatasupress
            // 
            this.l_i2cdatasupress.AutoSize = true;
            this.l_i2cdatasupress.Location = new System.Drawing.Point(154, 50);
            this.l_i2cdatasupress.Name = "l_i2cdatasupress";
            this.l_i2cdatasupress.Size = new System.Drawing.Size(0, 13);
            this.l_i2cdatasupress.TabIndex = 29;
            // 
            // b_check_update
            // 
            this.b_check_update.ForeColor = System.Drawing.Color.Black;
            this.b_check_update.Location = new System.Drawing.Point(831, 420);
            this.b_check_update.Name = "b_check_update";
            this.b_check_update.Size = new System.Drawing.Size(146, 23);
            this.b_check_update.TabIndex = 28;
            this.b_check_update.Text = "Check for Update";
            this.b_check_update.UseVisualStyleBackColor = true;
            this.b_check_update.Click += new System.EventHandler(this.b_check_update_Click);
            // 
            // b_select_settings_folder
            // 
            this.b_select_settings_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_select_settings_folder.ForeColor = System.Drawing.Color.Black;
            this.b_select_settings_folder.Location = new System.Drawing.Point(11, 119);
            this.b_select_settings_folder.Name = "b_select_settings_folder";
            this.b_select_settings_folder.Size = new System.Drawing.Size(35, 27);
            this.b_select_settings_folder.TabIndex = 26;
            this.b_select_settings_folder.Text = "...";
            this.b_select_settings_folder.UseVisualStyleBackColor = true;
            this.b_select_settings_folder.Click += new System.EventHandler(this.b_select_settings_folder_Click);
            // 
            // l_Settings_folder
            // 
            this.l_Settings_folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Settings_folder.Location = new System.Drawing.Point(48, 126);
            this.l_Settings_folder.Name = "l_Settings_folder";
            this.l_Settings_folder.Size = new System.Drawing.Size(462, 19);
            this.l_Settings_folder.TabIndex = 25;
            this.l_Settings_folder.Text = "C:\\Hello world\\kisfaszom";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(45, 113);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "Settings folder";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cb_Log10);
            this.groupBox11.Controls.Add(this.cb_Log9);
            this.groupBox11.Controls.Add(this.cb_Log8);
            this.groupBox11.Controls.Add(this.cb_Log7);
            this.groupBox11.Controls.Add(this.cb_Log6);
            this.groupBox11.Controls.Add(this.cb_Log5);
            this.groupBox11.Controls.Add(this.cb_Log4);
            this.groupBox11.Controls.Add(this.cb_Log3);
            this.groupBox11.Controls.Add(this.cb_Log2);
            this.groupBox11.Controls.Add(this.cb_Log1);
            this.groupBox11.ForeColor = System.Drawing.Color.White;
            this.groupBox11.Location = new System.Drawing.Point(12, 167);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(162, 244);
            this.groupBox11.TabIndex = 23;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "LOG Datasets";
            // 
            // cb_Log10
            // 
            this.cb_Log10.AutoSize = true;
            this.cb_Log10.Location = new System.Drawing.Point(14, 214);
            this.cb_Log10.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log10.Name = "cb_Log10";
            this.cb_Log10.Size = new System.Drawing.Size(58, 17);
            this.cb_Log10.TabIndex = 22;
            this.cb_Log10.Text = "Debug";
            this.cb_Log10.UseVisualStyleBackColor = true;
            this.cb_Log10.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log9
            // 
            this.cb_Log9.AutoSize = true;
            this.cb_Log9.Location = new System.Drawing.Point(14, 193);
            this.cb_Log9.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log9.Name = "cb_Log9";
            this.cb_Log9.Size = new System.Drawing.Size(140, 17);
            this.cb_Log9.TabIndex = 21;
            this.cb_Log9.Text = "Cycle, I2CErrors, Battery";
            this.cb_Log9.UseVisualStyleBackColor = true;
            this.cb_Log9.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log8
            // 
            this.cb_Log8.AutoSize = true;
            this.cb_Log8.Location = new System.Drawing.Point(14, 172);
            this.cb_Log8.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log8.Name = "cb_Log8";
            this.cb_Log8.Size = new System.Drawing.Size(71, 17);
            this.cb_Log8.TabIndex = 20;
            this.cb_Log8.Text = "GPS Nav";
            this.cb_Log8.UseVisualStyleBackColor = true;
            this.cb_Log8.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log7
            // 
            this.cb_Log7.AutoSize = true;
            this.cb_Log7.Location = new System.Drawing.Point(14, 151);
            this.cb_Log7.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log7.Name = "cb_Log7";
            this.cb_Log7.Size = new System.Drawing.Size(59, 17);
            this.cb_Log7.TabIndex = 19;
            this.cb_Log7.Text = "Servos";
            this.cb_Log7.UseVisualStyleBackColor = true;
            this.cb_Log7.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log6
            // 
            this.cb_Log6.AutoSize = true;
            this.cb_Log6.Location = new System.Drawing.Point(14, 130);
            this.cb_Log6.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log6.Name = "cb_Log6";
            this.cb_Log6.Size = new System.Drawing.Size(58, 17);
            this.cb_Log6.TabIndex = 18;
            this.cb_Log6.Text = "Motors";
            this.cb_Log6.UseVisualStyleBackColor = true;
            this.cb_Log6.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log5
            // 
            this.cb_Log5.AutoSize = true;
            this.cb_Log5.Location = new System.Drawing.Point(14, 109);
            this.cb_Log5.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log5.Name = "cb_Log5";
            this.cb_Log5.Size = new System.Drawing.Size(112, 17);
            this.cb_Log5.TabIndex = 17;
            this.cb_Log5.Text = "RC AUX channels";
            this.cb_Log5.UseVisualStyleBackColor = true;
            this.cb_Log5.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log4
            // 
            this.cb_Log4.AutoSize = true;
            this.cb_Log4.Location = new System.Drawing.Point(14, 88);
            this.cb_Log4.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log4.Name = "cb_Log4";
            this.cb_Log4.Size = new System.Drawing.Size(82, 17);
            this.cb_Log4.TabIndex = 16;
            this.cb_Log4.Text = "RC Controls";
            this.cb_Log4.UseVisualStyleBackColor = true;
            this.cb_Log4.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log3
            // 
            this.cb_Log3.AutoSize = true;
            this.cb_Log3.Location = new System.Drawing.Point(14, 67);
            this.cb_Log3.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log3.Name = "cb_Log3";
            this.cb_Log3.Size = new System.Drawing.Size(119, 17);
            this.cb_Log3.TabIndex = 15;
            this.cb_Log3.Text = "Mag and Barometer";
            this.cb_Log3.UseVisualStyleBackColor = true;
            this.cb_Log3.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log2
            // 
            this.cb_Log2.AutoSize = true;
            this.cb_Log2.Location = new System.Drawing.Point(14, 46);
            this.cb_Log2.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log2.Name = "cb_Log2";
            this.cb_Log2.Size = new System.Drawing.Size(119, 17);
            this.cb_Log2.TabIndex = 14;
            this.cb_Log2.Text = "Attitude (Roll, Pitch)";
            this.cb_Log2.UseVisualStyleBackColor = true;
            this.cb_Log2.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // cb_Log1
            // 
            this.cb_Log1.AutoSize = true;
            this.cb_Log1.Location = new System.Drawing.Point(14, 25);
            this.cb_Log1.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Log1.Name = "cb_Log1";
            this.cb_Log1.Size = new System.Drawing.Size(114, 17);
            this.cb_Log1.TabIndex = 13;
            this.cb_Log1.Text = "RAW Sensor Data";
            this.cb_Log1.UseVisualStyleBackColor = true;
            this.cb_Log1.Click += new System.EventHandler(this.log_option_Clicked);
            // 
            // b_save_gui_settings
            // 
            this.b_save_gui_settings.BackColor = System.Drawing.Color.Transparent;
            this.b_save_gui_settings.ForeColor = System.Drawing.Color.Black;
            this.b_save_gui_settings.Location = new System.Drawing.Point(407, 406);
            this.b_save_gui_settings.Name = "b_save_gui_settings";
            this.b_save_gui_settings.Size = new System.Drawing.Size(104, 37);
            this.b_save_gui_settings.TabIndex = 7;
            this.b_save_gui_settings.Text = "Save Settings";
            this.b_save_gui_settings.UseVisualStyleBackColor = false;
            this.b_save_gui_settings.Click += new System.EventHandler(this.b_save_gui_settings_Click);
            // 
            // cb_Logging_enabled
            // 
            this.cb_Logging_enabled.AutoSize = true;
            this.cb_Logging_enabled.Location = new System.Drawing.Point(12, 426);
            this.cb_Logging_enabled.Name = "cb_Logging_enabled";
            this.cb_Logging_enabled.Size = new System.Drawing.Size(164, 17);
            this.cb_Logging_enabled.TabIndex = 6;
            this.cb_Logging_enabled.Text = "Start data logging at Connect";
            this.cb_Logging_enabled.UseVisualStyleBackColor = true;
            this.cb_Logging_enabled.Click += new System.EventHandler(this.cb_Logging_enabled_Click);
            // 
            // b_select_capture_folder
            // 
            this.b_select_capture_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_select_capture_folder.ForeColor = System.Drawing.Color.Black;
            this.b_select_capture_folder.Location = new System.Drawing.Point(12, 78);
            this.b_select_capture_folder.Name = "b_select_capture_folder";
            this.b_select_capture_folder.Size = new System.Drawing.Size(35, 27);
            this.b_select_capture_folder.TabIndex = 5;
            this.b_select_capture_folder.Text = "...";
            this.b_select_capture_folder.UseVisualStyleBackColor = true;
            this.b_select_capture_folder.Click += new System.EventHandler(this.b_select_capture_folder_Click);
            // 
            // l_Capture_folder
            // 
            this.l_Capture_folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Capture_folder.Location = new System.Drawing.Point(49, 85);
            this.l_Capture_folder.Name = "l_Capture_folder";
            this.l_Capture_folder.Size = new System.Drawing.Size(462, 19);
            this.l_Capture_folder.TabIndex = 4;
            this.l_Capture_folder.Text = "C:\\Hello world\\kisfaszom";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(46, 72);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 13);
            this.label24.TabIndex = 3;
            this.label24.Text = "Video capture folder";
            // 
            // b_select_log_folder
            // 
            this.b_select_log_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_select_log_folder.ForeColor = System.Drawing.Color.Black;
            this.b_select_log_folder.Location = new System.Drawing.Point(11, 35);
            this.b_select_log_folder.Name = "b_select_log_folder";
            this.b_select_log_folder.Size = new System.Drawing.Size(35, 27);
            this.b_select_log_folder.TabIndex = 2;
            this.b_select_log_folder.Text = "...";
            this.b_select_log_folder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_select_log_folder.UseVisualStyleBackColor = true;
            this.b_select_log_folder.Click += new System.EventHandler(this.b_select_log_folder_Click);
            // 
            // l_LogFolder
            // 
            this.l_LogFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_LogFolder.Location = new System.Drawing.Point(48, 42);
            this.l_LogFolder.Name = "l_LogFolder";
            this.l_LogFolder.Size = new System.Drawing.Size(462, 19);
            this.l_LogFolder.TabIndex = 1;
            this.l_LogFolder.Text = "C:\\Hello world\\kisfaszom";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Data logging folder";
            // 
            // tabPageCLI
            // 
            this.tabPageCLI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageCLI.Controls.Add(this.gbTerminal);
            this.tabPageCLI.Location = new System.Drawing.Point(4, 22);
            this.tabPageCLI.Name = "tabPageCLI";
            this.tabPageCLI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCLI.Size = new System.Drawing.Size(982, 452);
            this.tabPageCLI.TabIndex = 6;
            this.tabPageCLI.Text = "CLI";
            // 
            // gbTerminal
            // 
            this.gbTerminal.Controls.Add(this.cmdCLISend);
            this.gbTerminal.Controls.Add(this.txtCLICommand);
            this.gbTerminal.Controls.Add(this.txtCLIResult);
            this.gbTerminal.Location = new System.Drawing.Point(8, 6);
            this.gbTerminal.Name = "gbTerminal";
            this.gbTerminal.Size = new System.Drawing.Size(966, 438);
            this.gbTerminal.TabIndex = 1;
            this.gbTerminal.TabStop = false;
            this.gbTerminal.Text = "Terminal";
            // 
            // cmdCLISend
            // 
            this.cmdCLISend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLISend.Location = new System.Drawing.Point(885, 410);
            this.cmdCLISend.Name = "cmdCLISend";
            this.cmdCLISend.Size = new System.Drawing.Size(75, 22);
            this.cmdCLISend.TabIndex = 1;
            this.cmdCLISend.Text = "Send";
            this.cmdCLISend.UseVisualStyleBackColor = true;
            this.cmdCLISend.Click += new System.EventHandler(this.cmdCLISend_Click);
            // 
            // txtCLICommand
            // 
            this.txtCLICommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCLICommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCLICommand.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCLICommand.Location = new System.Drawing.Point(6, 410);
            this.txtCLICommand.Name = "txtCLICommand";
            this.txtCLICommand.Size = new System.Drawing.Size(873, 20);
            this.txtCLICommand.TabIndex = 0;
            // 
            // txtCLIResult
            // 
            this.txtCLIResult.AllowDrop = true;
            this.txtCLIResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCLIResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCLIResult.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCLIResult.Location = new System.Drawing.Point(6, 19);
            this.txtCLIResult.Multiline = true;
            this.txtCLIResult.Name = "txtCLIResult";
            this.txtCLIResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCLIResult.Size = new System.Drawing.Size(954, 385);
            this.txtCLIResult.TabIndex = 0;
            // 
            // timer_realtime
            // 
            this.timer_realtime.Tick += new System.EventHandler(this.timer_realtime_Tick);
            // 
            // bkgWorker
            // 
            this.bkgWorker.WorkerSupportsCancellation = true;
            this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cb_serial_port,
            this.toolStripLabel2,
            this.cb_serial_speed,
            this.b_connect,
            this.toolStripSeparator1,
            this.b_read_settings,
            this.b_write_settings,
            this.b_reset,
            this.toolStripSeparator2,
            this.b_load_from_file,
            this.b_write_to_file,
            this.toolStripSeparator3,
            this.b_log,
            this.b_start_KML_log,
            this.b_log_browser,
            this.toolStripSeparator4,
            this.b_about,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(990, 54);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 51);
            this.toolStripLabel1.Text = "Port";
            // 
            // cb_serial_port
            // 
            this.cb_serial_port.Name = "cb_serial_port";
            this.cb_serial_port.Size = new System.Drawing.Size(75, 54);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 51);
            this.toolStripLabel2.Text = "Speed";
            // 
            // cb_serial_speed
            // 
            this.cb_serial_speed.Name = "cb_serial_speed";
            this.cb_serial_speed.Size = new System.Drawing.Size(75, 54);
            // 
            // b_connect
            // 
            this.b_connect.Image = global::MultiWiiWinGUI.Properties.Resources.connect;
            this.b_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(56, 51);
            this.b_connect.Text = "Connect";
            this.b_connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // b_read_settings
            // 
            this.b_read_settings.Image = global::MultiWiiWinGUI.Properties.Resources.read_settings;
            this.b_read_settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_read_settings.Name = "b_read_settings";
            this.b_read_settings.Size = new System.Drawing.Size(82, 51);
            this.b_read_settings.Text = "Read Settings";
            this.b_read_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_read_settings.Click += new System.EventHandler(this.b_read_settings_Click);
            // 
            // b_write_settings
            // 
            this.b_write_settings.Image = global::MultiWiiWinGUI.Properties.Resources.write_settings;
            this.b_write_settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_write_settings.Name = "b_write_settings";
            this.b_write_settings.Size = new System.Drawing.Size(84, 51);
            this.b_write_settings.Text = "Write Settings";
            this.b_write_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_write_settings.Click += new System.EventHandler(this.b_write_settings_Click);
            // 
            // b_reset
            // 
            this.b_reset.Image = global::MultiWiiWinGUI.Properties.Resources.reset;
            this.b_reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(83, 51);
            this.b_reset.Text = "Load Defaults";
            this.b_reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_reset.Click += new System.EventHandler(this.b_reset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // b_load_from_file
            // 
            this.b_load_from_file.Image = global::MultiWiiWinGUI.Properties.Resources.load_from_file;
            this.b_load_from_file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_load_from_file.Name = "b_load_from_file";
            this.b_load_from_file.Size = new System.Drawing.Size(87, 51);
            this.b_load_from_file.Text = "Load from File";
            this.b_load_from_file.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_load_from_file.Click += new System.EventHandler(this.b_load_from_file_Click);
            // 
            // b_write_to_file
            // 
            this.b_write_to_file.Image = global::MultiWiiWinGUI.Properties.Resources.write_to_file;
            this.b_write_to_file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_write_to_file.Name = "b_write_to_file";
            this.b_write_to_file.Size = new System.Drawing.Size(70, 51);
            this.b_write_to_file.Text = "Save to File";
            this.b_write_to_file.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_write_to_file.Click += new System.EventHandler(this.b_write_to_file_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // b_log
            // 
            this.b_log.Image = global::MultiWiiWinGUI.Properties.Resources.start_log;
            this.b_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_log.Name = "b_log";
            this.b_log.Size = new System.Drawing.Size(58, 51);
            this.b_log.Text = "Start Log";
            this.b_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_log.Click += new System.EventHandler(this.b_log_Click);
            // 
            // b_start_KML_log
            // 
            this.b_start_KML_log.BackColor = System.Drawing.Color.Gray;
            this.b_start_KML_log.Image = global::MultiWiiWinGUI.Properties.Resources.earth_3;
            this.b_start_KML_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_start_KML_log.Name = "b_start_KML_log";
            this.b_start_KML_log.Size = new System.Drawing.Size(79, 51);
            this.b_start_KML_log.Text = "Start GPS log";
            this.b_start_KML_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_start_KML_log.Click += new System.EventHandler(this.b_start_KML_log_Click);
            // 
            // b_log_browser
            // 
            this.b_log_browser.Image = global::MultiWiiWinGUI.Properties.Resources.logbrowser;
            this.b_log_browser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_log_browser.Name = "b_log_browser";
            this.b_log_browser.Size = new System.Drawing.Size(76, 51);
            this.b_log_browser.Text = "Log Browser";
            this.b_log_browser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_log_browser.Click += new System.EventHandler(this.b_log_browser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // b_about
            // 
            this.b_about.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.b_about.Image = global::MultiWiiWinGUI.Properties.Resources.about;
            this.b_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_about.Name = "b_about";
            this.b_about.Size = new System.Drawing.Size(44, 51);
            this.b_about.Text = "About";
            this.b_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_about.Click += new System.EventHandler(this.b_about_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(45, 51);
            this.toolStripButton1.Text = "LogDL";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // throttle_expo_control1
            // 
            this.throttle_expo_control1.Location = new System.Drawing.Point(521, 189);
            this.throttle_expo_control1.Name = "throttle_expo_control1";
            this.throttle_expo_control1.Size = new System.Drawing.Size(150, 100);
            this.throttle_expo_control1.TabIndex = 25;
            this.throttle_expo_control1.Text = "throttle_expo_control1";
            // 
            // rc_expo_control1
            // 
            this.rc_expo_control1.Location = new System.Drawing.Point(519, 37);
            this.rc_expo_control1.Name = "rc_expo_control1";
            this.rc_expo_control1.Size = new System.Drawing.Size(150, 100);
            this.rc_expo_control1.TabIndex = 15;
            this.rc_expo_control1.Text = "rc_expo_control1";
            // 
            // rci_Control_settings
            // 
            this.rci_Control_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rci_Control_settings.Location = new System.Drawing.Point(774, 6);
            this.rci_Control_settings.Name = "rci_Control_settings";
            this.rci_Control_settings.Size = new System.Drawing.Size(200, 225);
            this.rci_Control_settings.TabIndex = 15;
            this.rci_Control_settings.Text = "rc_input_control2";
            // 
            // rc_input_control1
            // 
            this.rc_input_control1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rc_input_control1.Location = new System.Drawing.Point(178, 6);
            this.rc_input_control1.Name = "rc_input_control1";
            this.rc_input_control1.Size = new System.Drawing.Size(200, 225);
            this.rc_input_control1.TabIndex = 76;
            this.rc_input_control1.Text = "rc_input_control1";
            // 
            // motorsIndicator1
            // 
            this.motorsIndicator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.motorsIndicator1.Location = new System.Drawing.Point(6, 6);
            this.motorsIndicator1.Name = "motorsIndicator1";
            this.motorsIndicator1.Size = new System.Drawing.Size(170, 200);
            this.motorsIndicator1.TabIndex = 75;
            this.motorsIndicator1.Text = "motorsIndicator1";
            // 
            // gpsIndicator
            // 
            this.gpsIndicator.Location = new System.Drawing.Point(0, 3);
            this.gpsIndicator.Name = "gpsIndicator";
            this.gpsIndicator.Size = new System.Drawing.Size(150, 150);
            this.gpsIndicator.TabIndex = 74;
            this.gpsIndicator.Text = "gpsIndicator";
            // 
            // attitudeIndicatorInstrumentControl1
            // 
            this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(156, 3);
            this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(150, 150);
            this.attitudeIndicatorInstrumentControl1.TabIndex = 71;
            this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Click += new System.EventHandler(this.attitudeIndicatorInstrumentControl1_Click);
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(312, 3);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(150, 150);
            this.headingIndicatorInstrumentControl1.TabIndex = 72;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // indACC
            // 
            this.indACC.Location = new System.Drawing.Point(466, 3);
            this.indACC.Margin = new System.Windows.Forms.Padding(1);
            this.indACC.Name = "indACC";
            this.indACC.Size = new System.Drawing.Size(50, 17);
            this.indACC.TabIndex = 82;
            this.indACC.Text = "ACC";
            // 
            // indBARO
            // 
            this.indBARO.Location = new System.Drawing.Point(518, 3);
            this.indBARO.Margin = new System.Windows.Forms.Padding(1);
            this.indBARO.Name = "indBARO";
            this.indBARO.Size = new System.Drawing.Size(50, 17);
            this.indBARO.TabIndex = 83;
            this.indBARO.Text = "BARO";
            // 
            // indMAG
            // 
            this.indMAG.Location = new System.Drawing.Point(570, 3);
            this.indMAG.Margin = new System.Windows.Forms.Padding(1);
            this.indMAG.Name = "indMAG";
            this.indMAG.Size = new System.Drawing.Size(50, 17);
            this.indMAG.TabIndex = 84;
            this.indMAG.Text = "MAG";
            // 
            // indSONAR
            // 
            this.indSONAR.Location = new System.Drawing.Point(518, 22);
            this.indSONAR.Margin = new System.Windows.Forms.Padding(1);
            this.indSONAR.Name = "indSONAR";
            this.indSONAR.Size = new System.Drawing.Size(50, 17);
            this.indSONAR.TabIndex = 85;
            this.indSONAR.Text = "SONAR";
            // 
            // indGPS
            // 
            this.indGPS.Location = new System.Drawing.Point(466, 22);
            this.indGPS.Margin = new System.Windows.Forms.Padding(1);
            this.indGPS.Name = "indGPS";
            this.indGPS.Size = new System.Drawing.Size(50, 17);
            this.indGPS.TabIndex = 86;
            this.indGPS.Text = "GPS";
            // 
            // indOPTIC
            // 
            this.indOPTIC.Location = new System.Drawing.Point(570, 22);
            this.indOPTIC.Margin = new System.Windows.Forms.Padding(1);
            this.indOPTIC.Name = "indOPTIC";
            this.indOPTIC.Size = new System.Drawing.Size(50, 17);
            this.indOPTIC.TabIndex = 103;
            this.indOPTIC.Text = "OPTIC";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label46.Location = new System.Drawing.Point(405, 42);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(41, 13);
            this.label46.TabIndex = 36;
            this.label46.Text = "label46";
            // 

            // mainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(990, 532);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1006, 570);
            this.Name = "mainGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiWiiGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainGUI_FormClosing);
            this.Load += new System.EventHandler(this.mainGUI_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPagePID.ResumeLayout(false);
            this.tabPagePID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTEXPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTMID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_EXPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_MID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Expo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCExpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPAlarm)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_tpid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_yaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_rp)).EndInit();
            this.tabPageRC.ResumeLayout(false);
            this.tabPageRC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageRealtime.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageMap.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel1.PerformLayout();
            this.splitContainer9.Panel2.ResumeLayout(false);
            this.splitContainer9.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_mapzoom)).EndInit();
            this.tabPageFlighDeck.ResumeLayout(false);
            this.tabPageFlighDeck.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nFrameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBitRate)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPageCLI.ResumeLayout(false);
            this.gbTerminal.ResumeLayout(false);
            this.gbTerminal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageRC;
        private System.Windows.Forms.TabPage tabPagePID;
        private System.Windows.Forms.TabPage tabPageRealtime;
        private System.Windows.Forms.Timer timer_realtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_monitor_rate;
        private ZedGraph.ZedGraphControl zgMonitor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cb_acc_roll;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox cb_acc_z;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cb_acc_pitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_acc_z;
        private System.Windows.Forms.Label l_acc_pitch;
        private System.Windows.Forms.Label l_acc_roll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label l_mag_yaw;
        private System.Windows.Forms.Label l_mag_pitch;
        private System.Windows.Forms.Label l_mag_roll;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox cb_mag_yaw;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox cb_mag_pitch;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox cb_mag_roll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label l_gyro_yaw;
        private System.Windows.Forms.Label l_gyro_pitch;
        private System.Windows.Forms.Label l_gyro_roll;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cb_gyro_yaw;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox cb_gyro_pitch;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox cb_gyro_roll;
        private System.Windows.Forms.Label l_head;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox cb_head;
        private System.Windows.Forms.Label l_alt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cb_alt;
        private System.Windows.Forms.Label l_dbg4;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.CheckBox cb_dbg4;
        private System.Windows.Forms.Label l_dbg3;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox cb_dbg3;
        private System.Windows.Forms.Label l_dbg2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox cb_dbg2;
        private System.Windows.Forms.Label l_dbg1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox cb_dbg1;
        private MultiWiiGUIControls.artifical_horizon attitudeIndicatorInstrumentControl1;
        private MultiWiiGUIControls.heading_indicator headingIndicatorInstrumentControl1;
        private MultiWiiGUIControls.GpsIndicatorInstrumentControl gpsIndicator;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label_sok;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.NumericUpDown nRATE_tpid;
        private System.Windows.Forms.NumericUpDown nRATE_yaw;
        private System.Windows.Forms.NumericUpDown nRATE_rp;
        private MultiWiiGUIControls.MWGUIMotors motorsIndicator1;
        private System.Windows.Forms.TabPage tabPageFlighDeck;
        private MultiWiiGUIControls.rc_input_control rc_input_control1;
        private System.Windows.Forms.Button b_pause;
        private MultiWiiGUIControls.rc_input_control rci_Control_settings;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TrackBar trackbar_RC_Rate;
        private System.Windows.Forms.TrackBar trackbar_RC_Expo;
        private MultiWiiGUIControls.rc_expo_control rc_expo_control1;
        private System.ComponentModel.BackgroundWorker bkgWorker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nRCExpo;
        private System.Windows.Forms.NumericUpDown nRCRate;
        private System.Windows.Forms.Button b_cal_acc;
        private System.Windows.Forms.Button b_cal_mag;
        private MultiWiiGUIControls.indicator_lamp indGPS;
        private MultiWiiGUIControls.indicator_lamp indSONAR;
        private MultiWiiGUIControls.indicator_lamp indMAG;
        private MultiWiiGUIControls.indicator_lamp indBARO;
        private MultiWiiGUIControls.indicator_lamp indACC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label l_cycletime;
        private System.Windows.Forms.Label l_vbatt;
        private System.Windows.Forms.Label l_powersum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nPAlarm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tComment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_video_connect;
        private System.Windows.Forms.ComboBox dropdown_devices;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button b_Record;
        private System.Windows.Forms.ComboBox cb_codec;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nBitRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nFrameRate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button b_select_log_folder;
        private System.Windows.Forms.Label l_LogFolder;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button b_select_capture_folder;
        private System.Windows.Forms.Label l_Capture_folder;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button b_save_gui_settings;
        private System.Windows.Forms.CheckBox cb_Logging_enabled;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label l_capture_file;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox cb_Log10;
        private System.Windows.Forms.CheckBox cb_Log9;
        private System.Windows.Forms.CheckBox cb_Log8;
        private System.Windows.Forms.CheckBox cb_Log7;
        private System.Windows.Forms.CheckBox cb_Log6;
        private System.Windows.Forms.CheckBox cb_Log5;
        private System.Windows.Forms.CheckBox cb_Log4;
        private System.Windows.Forms.CheckBox cb_Log3;
        private System.Windows.Forms.CheckBox cb_Log2;
        private System.Windows.Forms.CheckBox cb_Log1;
        private System.Windows.Forms.Label l_i2cerrors;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button b_select_settings_folder;
        private System.Windows.Forms.Label l_Settings_folder;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button b_check_update;
        private System.Windows.Forms.Label l_i2cdatasupress;
        private System.Windows.Forms.TrackBar trackBar_T_EXPO;
        private System.Windows.Forms.TrackBar trackBar_T_MID;
        private MultiWiiGUIControls.throttle_expo_control throttle_expo_control1;
        private System.Windows.Forms.NumericUpDown nTEXPO;
        private System.Windows.Forms.NumericUpDown nTMID;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cb_serial_port;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cb_serial_speed;
        private System.Windows.Forms.ToolStripButton b_connect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton b_read_settings;
        private System.Windows.Forms.ToolStripButton b_write_settings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton b_load_from_file;
        private System.Windows.Forms.ToolStripButton b_write_to_file;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton b_log;
        private System.Windows.Forms.ToolStripButton b_log_browser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton b_about;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MultiWiiGUIControls.indicator_lamp indOPTIC;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lGPS_lat;
        private System.Windows.Forms.Label lGPS_lon;
        private System.Windows.Forms.ToolStripButton b_start_KML_log;
        private System.Windows.Forms.Label l_GPS_numsat;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label l_GPS_alt;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button b_Clear_Route;
        private System.Windows.Forms.Button b_uncheck_all_ACC;
        private System.Windows.Forms.Button b_check_all_ACC;
        private System.Windows.Forms.Button b_uncheck_all_MAG;
        private System.Windows.Forms.Button b_check_all_MAG;
        private System.Windows.Forms.Button b_uncheck_all_GYRO;
        private System.Windows.Forms.Button b_check_all_GYRO;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbMapProviders;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.TrackBar tb_mapzoom;
        private System.Windows.Forms.Label LMousePos;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button b_fetch_tiles;
        private System.Windows.Forms.ToolStripButton b_reset;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabPageCLI;
        private System.Windows.Forms.GroupBox gbTerminal;
        private System.Windows.Forms.Button cmdCLISend;
        private System.Windows.Forms.TextBox txtCLICommand;
        private System.Windows.Forms.TextBox txtCLIResult;
        private System.Windows.Forms.Label label46;
    }
}

