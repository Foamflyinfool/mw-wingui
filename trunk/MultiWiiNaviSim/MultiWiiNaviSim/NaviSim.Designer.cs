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
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMapProviders = new System.Windows.Forms.ComboBox();
            this.lDist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_serial_port);
            this.splitContainerLeft.Panel1.Controls.Add(this.b_connect);
            this.splitContainerLeft.Panel1.Controls.Add(this.label2);
            this.splitContainerLeft.Panel1.Controls.Add(this.label3);
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_monitor_rate);
            this.splitContainerLeft.Panel1.Controls.Add(this.label1);
            this.splitContainerLeft.Panel1.Controls.Add(this.cb_serial_speed);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.MainMap);
            this.splitContainerLeft.Size = new System.Drawing.Size(884, 462);
            this.splitContainerLeft.SplitterDistance = 76;
            this.splitContainerLeft.SplitterWidth = 1;
            this.splitContainerLeft.TabIndex = 7;
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
            this.MainMap.Size = new System.Drawing.Size(884, 385);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 18D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lDist);
            this.panel1.Controls.Add(this.cbMapProviders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(562, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 462);
            this.panel1.TabIndex = 8;
            // 
            // cbMapProviders
            // 
            this.cbMapProviders.FormattingEnabled = true;
            this.cbMapProviders.Location = new System.Drawing.Point(16, 429);
            this.cbMapProviders.Name = "cbMapProviders";
            this.cbMapProviders.Size = new System.Drawing.Size(121, 21);
            this.cbMapProviders.TabIndex = 0;
            this.cbMapProviders.SelectedIndexChanged += new System.EventHandler(this.cbMapProviders_SelectedIndexChanged);
            // 
            // lDist
            // 
            this.lDist.AutoSize = true;
            this.lDist.Location = new System.Drawing.Point(16, 13);
            this.lDist.Name = "lDist";
            this.lDist.Size = new System.Drawing.Size(35, 13);
            this.lDist.TabIndex = 1;
            this.lDist.Text = "label4";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMapProviders;
        private System.Windows.Forms.Label lDist;
    }
}

