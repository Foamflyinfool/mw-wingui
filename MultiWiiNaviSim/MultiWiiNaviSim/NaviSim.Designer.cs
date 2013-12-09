namespace MultiWiiNaviSim
{
    partial class mainForm
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
            this.cb_serial_port = new System.Windows.Forms.ComboBox();
            this.cb_serial_speed = new System.Windows.Forms.ComboBox();
            this.b_connect = new System.Windows.Forms.Button();
            this.cb_monitor_rate = new System.Windows.Forms.ComboBox();
            this.bkgWorker = new System.ComponentModel.BackgroundWorker();
            this.timer_realtime = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.cbSats = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbMapProviders = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lSpeedLat = new System.Windows.Forms.Label();
            this.lSpeedLon = new System.Windows.Forms.Label();
            this.lAngleLat = new System.Windows.Forms.Label();
            this.lAngleLon = new System.Windows.Forms.Label();
            this.trackBarAngleLat = new System.Windows.Forms.TrackBar();
            this.trackBarAngleLon = new System.Windows.Forms.TrackBar();
            this.trackBarLonWind = new System.Windows.Forms.TrackBar();
            this.lLatWind = new System.Windows.Forms.Label();
            this.trackBarLatWind = new System.Windows.Forms.TrackBar();
            this.lDist = new System.Windows.Forms.Label();
            this.lLonWind = new System.Windows.Forms.Label();
            this.cbLostFix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLonWind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLatWind)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_serial_port
            // 
            this.cb_serial_port.FormattingEnabled = true;
            this.cb_serial_port.Location = new System.Drawing.Point(16, 36);
            this.cb_serial_port.Name = "cb_serial_port";
            this.cb_serial_port.Size = new System.Drawing.Size(121, 21);
            this.cb_serial_port.TabIndex = 0;
            // 
            // cb_serial_speed
            // 
            this.cb_serial_speed.FormattingEnabled = true;
            this.cb_serial_speed.Location = new System.Drawing.Point(153, 36);
            this.cb_serial_speed.Name = "cb_serial_speed";
            this.cb_serial_speed.Size = new System.Drawing.Size(121, 21);
            this.cb_serial_speed.TabIndex = 1;
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(440, 36);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(75, 23);
            this.b_connect.TabIndex = 2;
            this.b_connect.Text = "Start";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // cb_monitor_rate
            // 
            this.cb_monitor_rate.FormattingEnabled = true;
            this.cb_monitor_rate.Location = new System.Drawing.Point(300, 36);
            this.cb_monitor_rate.Name = "cb_monitor_rate";
            this.cb_monitor_rate.Size = new System.Drawing.Size(121, 21);
            this.cb_monitor_rate.TabIndex = 3;
            // 
            // bkgWorker
            // 
            this.bkgWorker.WorkerSupportsCancellation = true;
            this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Refresh Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Serial Speed";
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.cbLostFix);
            this.splitContainerLeft.Panel1.Controls.Add(this.cbSats);
            this.splitContainerLeft.Panel1.Controls.Add(this.button1);
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_serial_port);
            this.splitContainerLeft.Panel1.Controls.Add(this.b_connect);
            this.splitContainerLeft.Panel1.Controls.Add(this.cbMapProviders);
            this.splitContainerLeft.Panel1.Controls.Add(this.label2);
            this.splitContainerLeft.Panel1.Controls.Add(this.label3);
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_monitor_rate);
            this.splitContainerLeft.Panel1.Controls.Add(this.label1);
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_serial_speed);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerLeft.Size = new System.Drawing.Size(884, 462);
            this.splitContainerLeft.SplitterDistance = 76;
            this.splitContainerLeft.SplitterWidth = 1;
            this.splitContainerLeft.TabIndex = 7;
            // 
            // cbSats
            // 
            this.cbSats.AutoSize = true;
            this.cbSats.Location = new System.Drawing.Point(532, 13);
            this.cbSats.Name = "cbSats";
            this.cbSats.Size = new System.Drawing.Size(87, 17);
            this.cbSats.TabIndex = 8;
            this.cbSats.Text = "Sats below 5";
            this.cbSats.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "HALT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbMapProviders
            // 
            this.cbMapProviders.FormattingEnabled = true;
            this.cbMapProviders.Location = new System.Drawing.Point(741, 36);
            this.cbMapProviders.Name = "cbMapProviders";
            this.cbMapProviders.Size = new System.Drawing.Size(121, 21);
            this.cbMapProviders.TabIndex = 0;
            this.cbMapProviders.SelectedIndexChanged += new System.EventHandler(this.cbMapProviders_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lSpeedLat);
            this.splitContainer1.Panel2.Controls.Add(this.lSpeedLon);
            this.splitContainer1.Panel2.Controls.Add(this.lAngleLat);
            this.splitContainer1.Panel2.Controls.Add(this.lAngleLon);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarAngleLat);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarAngleLon);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarLonWind);
            this.splitContainer1.Panel2.Controls.Add(this.lLatWind);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarLatWind);
            this.splitContainer1.Panel2.Controls.Add(this.lDist);
            this.splitContainer1.Panel2.Controls.Add(this.lLonWind);
            this.splitContainer1.Size = new System.Drawing.Size(884, 385);
            this.splitContainer1.SplitterDistance = 561;
            this.splitContainer1.TabIndex = 6;
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
            this.MainMap.Size = new System.Drawing.Size(561, 385);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 18D;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // lSpeedLat
            // 
            this.lSpeedLat.AutoSize = true;
            this.lSpeedLat.Location = new System.Drawing.Point(16, 296);
            this.lSpeedLat.Name = "lSpeedLat";
            this.lSpeedLat.Size = new System.Drawing.Size(166, 13);
            this.lSpeedLat.TabIndex = 11;
            this.lSpeedLat.Text = "Angle induced speed (LAT) 0 m/s";
            // 
            // lSpeedLon
            // 
            this.lSpeedLon.AutoSize = true;
            this.lSpeedLon.Location = new System.Drawing.Point(16, 269);
            this.lSpeedLon.Name = "lSpeedLon";
            this.lSpeedLon.Size = new System.Drawing.Size(168, 13);
            this.lSpeedLon.TabIndex = 10;
            this.lSpeedLon.Text = "Angle induced speed (LON) 0 m/s";
            // 
            // lAngleLat
            // 
            this.lAngleLat.AutoSize = true;
            this.lAngleLat.Location = new System.Drawing.Point(155, 205);
            this.lAngleLat.Name = "lAngleLat";
            this.lAngleLat.Size = new System.Drawing.Size(93, 13);
            this.lAngleLat.TabIndex = 9;
            this.lAngleLat.Text = "Angle (LAT) 0 deg";
            // 
            // lAngleLon
            // 
            this.lAngleLon.AutoSize = true;
            this.lAngleLon.Location = new System.Drawing.Point(155, 154);
            this.lAngleLon.Name = "lAngleLon";
            this.lAngleLon.Size = new System.Drawing.Size(95, 13);
            this.lAngleLon.TabIndex = 8;
            this.lAngleLon.Text = "Angle (LON) 0 deg";
            // 
            // trackBarAngleLat
            // 
            this.trackBarAngleLat.LargeChange = 1;
            this.trackBarAngleLat.Location = new System.Drawing.Point(14, 221);
            this.trackBarAngleLat.Maximum = 45;
            this.trackBarAngleLat.Minimum = -45;
            this.trackBarAngleLat.Name = "trackBarAngleLat";
            this.trackBarAngleLat.Size = new System.Drawing.Size(291, 45);
            this.trackBarAngleLat.TabIndex = 7;
            this.trackBarAngleLat.Scroll += new System.EventHandler(this.trackBarAngleLat_Scroll);
            // 
            // trackBarAngleLon
            // 
            this.trackBarAngleLon.LargeChange = 1;
            this.trackBarAngleLon.Location = new System.Drawing.Point(14, 170);
            this.trackBarAngleLon.Maximum = 45;
            this.trackBarAngleLon.Minimum = -45;
            this.trackBarAngleLon.Name = "trackBarAngleLon";
            this.trackBarAngleLon.Size = new System.Drawing.Size(291, 45);
            this.trackBarAngleLon.TabIndex = 6;
            this.trackBarAngleLon.Scroll += new System.EventHandler(this.trackBarAngleLon_Scroll);
            // 
            // trackBarLonWind
            // 
            this.trackBarLonWind.LargeChange = 1;
            this.trackBarLonWind.Location = new System.Drawing.Point(16, 47);
            this.trackBarLonWind.Minimum = -10;
            this.trackBarLonWind.Name = "trackBarLonWind";
            this.trackBarLonWind.Size = new System.Drawing.Size(291, 45);
            this.trackBarLonWind.TabIndex = 3;
            this.trackBarLonWind.Scroll += new System.EventHandler(this.trackBarLonWind_Scroll);
            // 
            // lLatWind
            // 
            this.lLatWind.AutoSize = true;
            this.lLatWind.Location = new System.Drawing.Point(155, 95);
            this.lLatWind.Name = "lLatWind";
            this.lLatWind.Size = new System.Drawing.Size(125, 13);
            this.lLatWind.TabIndex = 4;
            this.lLatWind.Text = "Wind Speed (LAT) 0 m/s";
            // 
            // trackBarLatWind
            // 
            this.trackBarLatWind.LargeChange = 1;
            this.trackBarLatWind.Location = new System.Drawing.Point(15, 111);
            this.trackBarLatWind.Minimum = -10;
            this.trackBarLatWind.Name = "trackBarLatWind";
            this.trackBarLatWind.Size = new System.Drawing.Size(291, 45);
            this.trackBarLatWind.TabIndex = 2;
            this.trackBarLatWind.Scroll += new System.EventHandler(this.trackBarLatWind_Scroll);
            // 
            // lDist
            // 
            this.lDist.AutoSize = true;
            this.lDist.Location = new System.Drawing.Point(12, 9);
            this.lDist.Name = "lDist";
            this.lDist.Size = new System.Drawing.Size(38, 13);
            this.lDist.TabIndex = 1;
            this.lDist.Text = "Speed";
            // 
            // lLonWind
            // 
            this.lLonWind.AutoSize = true;
            this.lLonWind.Location = new System.Drawing.Point(155, 31);
            this.lLonWind.Name = "lLonWind";
            this.lLonWind.Size = new System.Drawing.Size(127, 13);
            this.lLonWind.TabIndex = 5;
            this.lLonWind.Text = "Wind Speed (LON) 0 m/s";
            // 
            // cbLostFix
            // 
            this.cbLostFix.AutoSize = true;
            this.cbLostFix.Location = new System.Drawing.Point(642, 13);
            this.cbLostFix.Name = "cbLostFix";
            this.cbLostFix.Size = new System.Drawing.Size(62, 17);
            this.cbLostFix.TabIndex = 9;
            this.cbLostFix.Text = "Lost Fix";
            this.cbLostFix.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.splitContainerLeft);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "mainForm";
            this.Text = "MultiWiiNaviSim";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel1.PerformLayout();
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLonWind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLatWind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_serial_port;
        private System.Windows.Forms.ComboBox cb_serial_speed;
        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.ComboBox cb_monitor_rate;
        private System.ComponentModel.BackgroundWorker bkgWorker;
        private System.Windows.Forms.Timer timer_realtime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.ComboBox cbMapProviders;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lLatWind;
        private System.Windows.Forms.TrackBar trackBarLatWind;
        private System.Windows.Forms.Label lDist;
        private System.Windows.Forms.TrackBar trackBarLonWind;
        private System.Windows.Forms.Label lLonWind;
        private System.Windows.Forms.Label lSpeedLat;
        private System.Windows.Forms.Label lSpeedLon;
        private System.Windows.Forms.Label lAngleLat;
        private System.Windows.Forms.Label lAngleLon;
        private System.Windows.Forms.TrackBar trackBarAngleLat;
        private System.Windows.Forms.TrackBar trackBarAngleLon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbSats;
        private System.Windows.Forms.CheckBox cbLostFix;
    }
}

