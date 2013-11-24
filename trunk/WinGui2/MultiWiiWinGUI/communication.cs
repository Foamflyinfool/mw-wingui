using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Text;
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
using System.Reflection;

namespace MultiWiiWinGUI
{

    public partial class mainGUI : Form
    {



        private void b_connect_Click(object sender, EventArgs e)
        {

            //Check if we at GUI Settings, go to first screen when connect
            if (tabMain.SelectedIndex == 4) { tabMain.SelectedIndex = 0; }

            if (serialPort.IsOpen)              //Disconnect
            {
                delete_RC_Checkboxes();
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

                serial_packet_rx_count = 0;
                serial_packet_tx_count = 0;
                serial_error_count = 0;

                telemetry_status_received = 0;
                telemetry_status_sent = 0;


                //Enable buttons that are not working here
                b_reset.Enabled = true;
                b_cal_acc.Enabled = true;
                b_cal_mag.Enabled = true;
                b_read_settings.Enabled = true;
                b_write_settings.Enabled = true;



                //We have to do it for a couple of times to ensure that we will have parameters loaded 
                for (int i = 0; i < 10; i++)
                {

                    MSPquery(MSP.MSP_PID);
                    MSPquery(MSP.MSP_RC_TUNING);
                    MSPquery(MSP.MSP_IDENT);
                    MSPquery(MSP.MSP_BOX);
                    MSPquery(MSP.MSP_BOXNAMES);
                    MSPquery(MSP.MSP_MISC);
                    MSPquery(MSP.MSP_SERVO_CONF);

                }



                //Run BackgroundWorker
                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }



                //if (tabMain.SelectedIndex == 2 && !isPaused) timer_realtime.Start();                             //If we are standing at the monitor page, start timer
                //if (tabMain.SelectedIndex == 1 && !isPausedRC) timer_rc.Start();                                //And start it if we stays on rc settings page
                //if (tabMain.SelectedIndex == 3 && !isPausedGPS) timer_GPS.Start();
                System.Threading.Thread.Sleep(1000);


                int x = 0;
                while (mw_gui.bUpdateBoxNames == false)
                {
                    x++;
                    System.Threading.Thread.Sleep(1);

                    MSPquery(MSP.MSP_PID);
                    MSPquery(MSP.MSP_RC_TUNING);
                    MSPquery(MSP.MSP_IDENT);
                    MSPquery(MSP.MSP_BOX);
                    MSPquery(MSP.MSP_BOXNAMES);
                    MSPquery(MSP.MSP_MISC);
                    MSPquery(MSP.MSP_SERVO_CONF);

                    if (x > 1000)
                    {
                        MessageBoxEx.Show(this, "Please check if you have selected the right com port", "Error device not responding", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        return;
                    }
                }

                serial_packet_rx_count = 0;
                serial_packet_tx_count = 0;
                
                timer_realtime.Start();
                bOptions_needs_refresh = true;
                create_RC_Checkboxes(mw_gui.sBoxNames);
                update_gui();

                //tabMain.SelectedIndex = GUIPages.Realtime;


            }
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

            //while (serialPort.BytesToWrite > 0) ;
            if (telemetry_start==1) serial_packet_tx_count++;

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
            o[4] = (byte)MSP.MSP_WP; c ^= o[4];
            o[5] = (byte)wp; c ^= o[5];
            o[6] = (byte)c;
            serialPort.Write(o, 0, 7) ;
            if (telemetry_start == 1)serial_packet_tx_count++;
        }

        private void write_parameters()
        {

            //Stop all timers
            timer_realtime.Stop();

           // while (serialPort.BytesToWrite > 0) ;
           // while (serialPort.BytesToRead > 0) ;
            
            update_params();                            //update parameters object from GUI controls.
            mw_params.write_settings(serialPort);

//            while (serialPort.BytesToRead > 0) ;
//            while (serialPort.BytesToWrite > 0) ;
//            while (serialPort.BytesToRead > 0) ;

            response_counter = 0;
            MSPquery(MSP.MSP_PID);
            MSPquery(MSP.MSP_RC_TUNING);
            MSPquery(MSP.MSP_IDENT);
            MSPquery(MSP.MSP_BOX);
            MSPquery(MSP.MSP_MISC);
            MSPquery(MSP.MSP_SERVO_CONF);

            DateTime startTime = DateTime.Now;
            bool missing_packets = false;
            //Wait for all the responses from the setting reload. Add 2sec timeout for remote situtations
            while (response_counter < 6)
            {
                if (DateTime.Now.Subtract(startTime).TotalMilliseconds > 2000) { response_counter = 8; missing_packets = true; }

            }

            if (missing_packets) MessageBoxEx.Show("Not all response packets were arrived,\rplease reread parameters and check that save really happened.","Response Packets Lost",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            //Invalidate gui parameters and reread those values

//            while (serialPort.BytesToWrite > 0) ;
//            while (serialPort.BytesToRead > 0) ;

            bOptions_needs_refresh = true;
            update_gui();
            timer_realtime.Start();


        }


    }


}

