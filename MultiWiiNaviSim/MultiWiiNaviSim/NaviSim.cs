using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;


namespace MultiWiiNaviSim
{
    public partial class mainForm : Form
    {


        static SerialPort serialPort;
        static bool isConnected = false;                        //is port connected or not ?
        static bool bSerialError = false;
        static bool isPaused = false;
        string[] sSerialSpeeds = { "115200", "57600", "38400", "19200", "9600" };
        string[] sRefreshSpeeds = { "10 Hz"};
        int[] iRefreshIntervals = { 100 };


        static int GPS_lat_old, GPS_lon_old;
        static bool GPSPresent = true;

        //Routes on Map
        static GMapRoute GMRouteFlightPath;
        static GMapRoute GMRouteMission;

        //Map Overlays
        static GMapOverlay GMOverlayFlightPath;// static so can update from gcs
        static GMapOverlay GMOverlayWaypoints;
        static GMapOverlay GMOverlayMission;
        static GMapOverlay GMOverlayLiveData;

        static GMapProvider[] mapProviders;
        static PointLatLng copterPos = new PointLatLng(47.402489, 19.071558);       //Just the corrds of my flying place

        

        static bool isMouseDown = false;
        static bool isMouseDraging = false;

        static bool bPosholdRecorded = false;
        static bool bHomeRecorded = false;

        // markers
        GMapMarker currentMarker;
        GMapMarker center = new GMapMarkerCross(new PointLatLng(0.0, 0.0));
        GMapMarkerGoogleRed markerGoToClick;
        GMapMarkerRect CurentRectMarker;

        List<PointLatLng> points = new List<PointLatLng>();

        PointLatLng GPS_pos, GPS_pos_old;
        PointLatLng end;
        PointLatLng start;

       


        public mainForm()
        {
            InitializeComponent();

            GPS_pos.Lat = 47.402489;
            GPS_pos.Lng = 19.071558;

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
            cbMapProviders.SelectedIndex = 1;


            // map events

            MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
            MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

            currentMarker = new GMapMarkerGoogleRed(MainMap.Position);
            //MainMap.MapScaleInfoEnabled = true;

            MainMap.ForceDoubleBuffer = true;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;

            MainMap.Position = copterPos;

            Pen penRoute = new Pen(Color.Yellow, 3);
            Pen penScale = new Pen(Color.Blue, 3);

            MainMap.ScalePen = penScale;

            GMOverlayFlightPath = new GMapOverlay(MainMap, "flightpath");
            MainMap.Overlays.Add(GMOverlayFlightPath);

            GMOverlayWaypoints = new GMapOverlay(MainMap, "waypoints");
            MainMap.Overlays.Add(GMOverlayWaypoints);

            GMOverlayMission = new GMapOverlay(MainMap, "missionroute");
            MainMap.Overlays.Add(GMOverlayMission);

            GMOverlayLiveData = new GMapOverlay(MainMap, "livedata");
            MainMap.Overlays.Add(GMOverlayLiveData);

            GMOverlayLiveData.Markers.Clear();
            GMapMarker m = new GMapMarkerGoogleGreen(copterPos);
            GMapMarkerRect mBorders = new GMapMarkerRect(copterPos);
            mBorders.InnerMarker = m;
            mBorders.wprad = (int)float.Parse("5");
            mBorders.MainMap = MainMap;
            GMOverlayLiveData.Markers.Add(m);
            GMOverlayLiveData.Markers.Add(mBorders);


            GMRouteFlightPath = new GMapRoute(points, "flightpath");
            GMRouteFlightPath.Stroke = penRoute;
            GMOverlayFlightPath.Routes.Add(GMRouteFlightPath);

            center = new GMapMarkerCross(MainMap.Position);


            #endregion

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //bSerialBuffer = new byte[65];
            //inBuf = new byte[300];   //init input buffer

            serial_ports_enumerate();
            foreach (string speed in sSerialSpeeds)
            {
                cb_serial_speed.Items.Add(speed);
            }
            cb_serial_speed.SelectedItem = "115200";

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
            cb_monitor_rate.SelectedIndex = 0;              //10Hz is the default and the only possibility


            //Setup timers
            timer_realtime.Tick += new EventHandler(timer_realtime_Tick);
            timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
            timer_realtime.Enabled = true;
            timer_realtime.Stop();


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

            //if prefered port is not available then select the first one 
            if (cb_serial_port.Text == "")
            {
                if (cb_serial_port.Items.Count > 0) { cb_serial_port.SelectedIndex = 0; }
            }

            //Thisable connect button if there is no selected com port
            if (cb_serial_port.Items.Count == 0) { b_connect.Enabled = false; }
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)              //Disconnect
            {
                b_connect.Text = "Connect";
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                //timer_rc.Stop();
                bkgWorker.CancelAsync();
                System.Threading.Thread.Sleep(500);         //Wait bkworker to finish
                serialPort.Close();


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
                    MessageBox.Show(this, "Please check that your USB cable is still connected.\r\nAfter you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    serial_ports_enumerate();
                    return; //Exit without connecting;
                }
                //Set button text and status
                b_connect.Text = "Disconnect";
                isConnected = true;

                //Run BackgroundWorker
                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }
                //System.Threading.Thread.Sleep(1000);


                timer_realtime.Start();

            }

        }

        private void timer_realtime_Tick(object sender, EventArgs e)
        {

            GPS_pos_old = GPS_pos;

            GPS_pos.Lat -= 0.000011;
            GPS_pos.Lng += 0.000001;

            double distance = MainMap.MapProvider.Projection.GetDistance(GPS_pos, GPS_pos_old);
            distance = distance * 1000; //convert it to meters;

            double speed = distance * 10;


            //lDist.Text = distance.ToString();
            lDist.Text = String.Format("{0:N2}m/s",speed);

            GMOverlayLiveData.Markers.Clear();
            GMapMarker m = new GMapMarkerGoogleGreen(GPS_pos);
            GMapMarkerRect mBorders = new GMapMarkerRect(GPS_pos);
            mBorders.InnerMarker = m;
            mBorders.wprad = (int)float.Parse("5");
            mBorders.MainMap = MainMap;
            GMOverlayLiveData.Markers.Add(m);
            GMOverlayLiveData.Markers.Add(mBorders);
            
            GMRouteFlightPath.Points.Add(GPS_pos);
            MainMap.Position = GPS_pos;
            MainMap.Invalidate();

            if (serialPort.BytesToRead == 0)
            {
                //Do some cool stuff
            }

        }

        private void cbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            MainMap.MapProvider = (GMapProvider)cbMapProviders.SelectedItem;
            MainMap.MaxZoom = 19;
            MainMap.Invalidate();


            this.Cursor = Cursors.Default;

        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 0)
            {
                //tb_mapzoom.Value = (int)(MainMap.Zoom);
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
            //LMousePos.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);

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
                        //addWP("WAYPOINT", 0, currentMarker.Position.Lat, currentMarker.Position.Lng, iDefAlt);
                    }
                }
                else
                {
                    if (CurentRectMarker != null)
                    {
                        //dragMarkerCallback(CurentRectMarker.InnerMarker.Tag.ToString(), currentMarker.Position.Lat, currentMarker.Position.Lng, -1);
                        //update existing point in datagrid
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
                //LMousePos.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);
                if (GMRouteMission != null)
                {
                    if (GMRouteMission.Points.Count >= 1)
                    {
                        double dist_from_last = MainMap.MapProvider.Projection.GetDistance(GMRouteMission.Points[GMRouteMission.Points.Count - 1], point);
                        //lDistLastWP.Text = String.Format("Dist. from last WP:{0:N1}m", dist_from_last * 1000);
                    }
                }
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
                else
                {
                    PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);
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



    }

    /// <summary>
    /// used to override the drawing of the waypoint box bounding
    /// </summary>
    public class GMapMarkerRect : GMapMarker
    {
        public Pen Pen = new Pen(Brushes.White, 2);

        public Color Color { get { return Pen.Color; } set { Pen.Color = value; } }

        public GMapMarker InnerMarker;

        public int wprad = 0;
        public GMapControl MainMap;

        public GMapMarkerRect(PointLatLng p)
            : base(p)
        {
            Pen.DashStyle = DashStyle.Dash;

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(50, 50);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2 - 20);
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);

            if (wprad == 0 || MainMap == null)
                return;

            // undo autochange in mouse over
            if (Pen.Color == Color.Blue)
                Pen.Color = Color.White;

            double width = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Width, 0)) * 1000.0);
            double height = (MainMap.MapProvider.Projection.GetDistance(MainMap.FromLocalToLatLng(0, 0), MainMap.FromLocalToLatLng(MainMap.Height, 0)) * 1000.0);
            double m2pixelwidth = MainMap.Width / width;
            double m2pixelheight = MainMap.Height / height;

            GPoint loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * wprad * 2)), LocalPosition.Y);// MainMap.FromLatLngToLocal(wpradposition);

            g.DrawArc(Pen, new System.Drawing.Rectangle(LocalPosition.X - Offset.X - (Math.Abs(loc.X - LocalPosition.X) / 2), LocalPosition.Y - Offset.Y - Math.Abs(loc.X - LocalPosition.X) / 2, Math.Abs(loc.X - LocalPosition.X), Math.Abs(loc.X - LocalPosition.X)), 0, 360);

        }
    }




}
