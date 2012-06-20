using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MultiWiiWinGUI
{

    #region GUI_settings

    public class GUI_settings
    {
        public string sLogFolder { get; set; }
        public string sCaptureFolder { get; set; }
        public string sSettingsFolder { get; set; }
        public int iSoftwareVersion { get; set; }
        public bool bEnableLogging { get; set; }
        public string sPreferedComPort { get; set; }
        public string sPreferedSerialSpeed { get; set; }
        //Log fields
        public bool logGraw { get; set; }
        public bool logGatt { get; set; }
        public bool logGmag { get; set; }
        public bool logGrcc { get; set; }
        public bool logGrcx { get; set; }
        public bool logGmot { get; set; }
        public bool logGsrv { get; set; }
        public bool logGnav { get; set; }
        public bool logGpar { get; set; }
        public bool logGdbg { get; set; }


        public byte MSP_STATUS_rate_divider { get; set; }
        public byte MSP_RAW_IMU_rate_divider { get; set; }
        public byte MSP_SERVO_rate_divider { get; set; }
        public byte MSP_MOTOR_rate_divider { get; set; }
        public byte MSP_RAW_GPS_rate_divider { get; set; }
        public byte MSP_COMP_GPS_rate_divider { get; set; }
        public byte MSP_ATTITUDE_rate_divider { get; set; }
        public byte MSP_ALTITUDE_rate_divider { get; set; }
        public byte MSP_BAT_rate_divider { get; set; }
        public byte MSP_RC_rate_divider { get; set; }
        public byte MSP_MISC_rate_divider { get; set; }
        public byte MSP_DEBUG_rate_divider { get; set; }




        //Constructor, set default values
        public GUI_settings()
        {
            sLogFolder = Directory.GetCurrentDirectory();
            sCaptureFolder = Directory.GetCurrentDirectory();
            sSettingsFolder = Directory.GetCurrentDirectory();
            iSoftwareVersion = 21;
            bEnableLogging = false;

            //Refreh rate dividers (based on 20Hz refresh rate)
            // 1 = 20Hz, 2=10Hz, 4=5Hz, 8=2.5Hz 10=2Hz 20=1Hz

            MSP_STATUS_rate_divider = 10;
            MSP_RAW_IMU_rate_divider = 1;
            MSP_SERVO_rate_divider = 4;
            MSP_MOTOR_rate_divider = 4;
            MSP_RAW_GPS_rate_divider = 2;
            MSP_COMP_GPS_rate_divider = 2;
            MSP_ATTITUDE_rate_divider = 1;
            MSP_ALTITUDE_rate_divider = 10;
            MSP_BAT_rate_divider = 20;
            MSP_RC_rate_divider = 2;
            MSP_MISC_rate_divider = 10;
            MSP_DEBUG_rate_divider = 2;



        }


        public void save_to_xml(string filename)
        {
            XmlTextWriter tw = new XmlTextWriter(filename, null);
            tw.Formatting = Formatting.Indented;
            tw.Indentation = 4;
            tw.WriteStartDocument();

            // Get the name and version of the current assembly.
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            tw.WriteComment(String.Format("{0}, Version {1}", assemName.Name, ver.ToString()));
            tw.WriteComment("GUI Settings");
            tw.WriteComment("Do not change this file manually, unless you know what are you doing");

            tw.WriteStartElement("PARAMETERS");

            tw.WriteStartElement("FCVERSION value=\"" + iSoftwareVersion + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGFOLDER value=\"" + sLogFolder + "\""); tw.WriteEndElement();
            tw.WriteStartElement("CAPTUREFOLDER value=\"" + sCaptureFolder + "\""); tw.WriteEndElement();
            tw.WriteStartElement("SETTINGSFOLDER value=\"" + sSettingsFolder + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGATCONNECT value=\"" + bEnableLogging + "\""); tw.WriteEndElement();
            tw.WriteStartElement("SERIALPORT value=\"" + sPreferedComPort + "\""); tw.WriteEndElement();
            tw.WriteStartElement("SERIALSPEED value=\"" + sPreferedSerialSpeed + "\""); tw.WriteEndElement();

            tw.WriteStartElement("LOGRAW value=\"" + logGraw + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGATT value=\"" + logGatt + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGMAG value=\"" + logGmag + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGRCC value=\"" + logGrcc + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGRCX value=\"" + logGrcx + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGMOT value=\"" + logGmot + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGSRV value=\"" + logGsrv + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGNAV value=\"" + logGnav + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGPAR value=\"" + logGpar + "\""); tw.WriteEndElement();
            tw.WriteStartElement("LOGDBG value=\"" + logGdbg + "\""); tw.WriteEndElement();

            tw.WriteStartElement("MSP_STATUS_RATE_DIV value=\"" + MSP_STATUS_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_RAW_IMU_RATE_DIV value=\"" + MSP_RAW_IMU_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_SERVO_RATE_DIV value=\"" + MSP_SERVO_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_MOTOR_RATE_DIV value=\"" + MSP_MOTOR_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_RAW_GPS_RATE_DIV value=\"" + MSP_RAW_GPS_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_COMP_GPS_RATE_DIV value=\"" + MSP_COMP_GPS_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_ATTITUDE_RATE_DIV value=\"" + MSP_ATTITUDE_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_ALTITUDE_RATE_DIV value=\"" + MSP_ALTITUDE_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_BAT_RATE_DIV value=\"" + MSP_BAT_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_RC_RATE_DIV value=\"" + MSP_RC_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_MISC_RATE_DIV value=\"" + MSP_MISC_rate_divider + "\""); tw.WriteEndElement();
            tw.WriteStartElement("MSP_DEBUG_RATE_DIV value=\"" + MSP_DEBUG_rate_divider + "\""); tw.WriteEndElement();



            tw.WriteEndElement();

            tw.WriteEndDocument();
            tw.Close();
        }


        public bool read_from_xml(string filename)
        {
            XmlTextReader reader;

            if (!File.Exists(filename))
            {
                MessageBoxEx.Show("Error opening config file :" + filename + "\r\nUnable to continue!!", "Config File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return (false);
            }
            reader = new XmlTextReader(filename);
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (String.Compare(reader.Name, "fcversion", true) == 0 && reader.HasAttributes) { iSoftwareVersion = Convert.ToInt16(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logfolder", true) == 0 && reader.HasAttributes) { sLogFolder = reader.GetAttribute("value"); }
                            if (String.Compare(reader.Name, "capturefolder", true) == 0 && reader.HasAttributes) { sCaptureFolder = reader.GetAttribute("value"); }
                            if (String.Compare(reader.Name, "settingsfolder", true) == 0 && reader.HasAttributes) { sSettingsFolder = reader.GetAttribute("value"); }
                            if (String.Compare(reader.Name, "logatconnect", true) == 0 && reader.HasAttributes) { bEnableLogging = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "serialport", true) == 0 && reader.HasAttributes) { sPreferedComPort = reader.GetAttribute("value"); }
                            if (String.Compare(reader.Name, "serialspeed", true) == 0 && reader.HasAttributes) { sPreferedSerialSpeed = reader.GetAttribute("value"); }

                            if (String.Compare(reader.Name, "lograw", true) == 0 && reader.HasAttributes) { logGraw = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logatt", true) == 0 && reader.HasAttributes) { logGatt = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logmag", true) == 0 && reader.HasAttributes) { logGmag = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logrcc", true) == 0 && reader.HasAttributes) { logGrcc = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logrcx", true) == 0 && reader.HasAttributes) { logGrcx = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logmot", true) == 0 && reader.HasAttributes) { logGmot = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logsrv", true) == 0 && reader.HasAttributes) { logGsrv = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "lognav", true) == 0 && reader.HasAttributes) { logGnav = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logpar", true) == 0 && reader.HasAttributes) { logGpar = Convert.ToBoolean(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "logdbg", true) == 0 && reader.HasAttributes) { logGdbg = Convert.ToBoolean(reader.GetAttribute("value")); }

                            if (String.Compare(reader.Name, "msp_status_rate_divider", true) == 0 && reader.HasAttributes) { MSP_STATUS_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_raw_imu_rate_divider", true) == 0 && reader.HasAttributes) { MSP_RAW_IMU_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_servo_rate_divider", true) == 0 && reader.HasAttributes) { MSP_SERVO_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_motor_rate_divider", true) == 0 && reader.HasAttributes) { MSP_MOTOR_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_raw_gps_rate_divider", true) == 0 && reader.HasAttributes) { MSP_RAW_GPS_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_comp_gps_rate_divider", true) == 0 && reader.HasAttributes) { MSP_COMP_GPS_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_attitude_rate_divider", true) == 0 && reader.HasAttributes) { MSP_ATTITUDE_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_altitude_rate_divider", true) == 0 && reader.HasAttributes) { MSP_ALTITUDE_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_bat_rate_divider", true) == 0 && reader.HasAttributes) { MSP_BAT_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_rc_rate_divider", true) == 0 && reader.HasAttributes) { MSP_RC_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_misc_rate_divider", true) == 0 && reader.HasAttributes) { MSP_MISC_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }
                            if (String.Compare(reader.Name, "msp_debug_rate_divider", true) == 0 && reader.HasAttributes) { MSP_DEBUG_rate_divider = Convert.ToByte(reader.GetAttribute("value")); }



                            break;
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show("Options file contains invalid data around Line : " + reader.LineNumber + "\r\nUnable to continue!!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return (false);

            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return (true);
        }


    }

    #endregion

    #region PID

    public class PID
    {
        //public fields

        public string name;
        public string description;
        public Label pidLabel;

        public byte P;
        public bool Pshown;
        public decimal Pmin;
        public decimal Pmax;
        public int Pprec;
        public Label Plabel;
        public NumericUpDown Pfield;


        public byte I;
        public bool Ishown;
        public decimal Imin;
        public decimal Imax;
        public int Iprec;
        public Label Ilabel;
        public NumericUpDown Ifield;

        public byte D;
        public bool Dshown;
        public decimal Dmin;
        public decimal Dmax;
        public int Dprec;
        public Label Dlabel;
        public NumericUpDown Dfield;

        public PID()
        {

            P = 0;
        }



    }





    #endregion


    #region mw_settings
    public class mw_settings
    {

        //public fields
        
        public byte[] pidP;                 //P values
        public byte[] pidI;                 //I values
        public byte[] pidD;                 //D values

        public byte rcRate; 
        public byte rcExpo;
        public byte RollPitchRate;
        public byte YawRate;
        public byte DynThrPID;
        public byte ThrottleMID;
        public byte ThrottleEXPO;

        public Int16[] activation;

        public int PowerTrigger;

        //For GUI only
        public string comment;


        public string[] pidnames;
        private int iPIDItems, iCheckBoxItems;
        private int iSwVer;

        //Commands
        const int MSP_IDENT = 100;

        const int MSP_STATUS = 101;
        const int MSP_RAW_IMU = 102;
        const int MSP_SERVO = 103;
        const int MSP_MOTOR = 104;
        const int MSP_RC = 105;
        const int MSP_RAW_GPS = 106;
        const int MSP_COMP_GPS = 107;
        const int MSP_ATTITUDE = 108;
        const int MSP_ALTITUDE = 109;
        const int MSP_BAT = 110;
        const int MSP_RC_TUNING = 111;
        const int MSP_PID = 112;
        const int MSP_BOX = 113;
        const int MSP_MISC = 114;

        const int MSP_SET_RAW_RC = 200;
        const int MSP_SET_RAW_GPS = 201;
        const int MSP_SET_PID = 202;
        const int MSP_SET_BOX = 203;
        const int MSP_SET_RC_TUNING = 204;
        const int MSP_ACC_CALIBRATION = 205;
        const int MSP_MAG_CALIBRATION = 206;
        const int MSP_SET_MISC = 207;
        const int MSP_RESET_CONF = 208;

        const int MSP_EEPROM_WRITE = 250;
        const int MSP_DEBUG = 254;

        //Constructor
        public mw_settings(int pidItems, int checkboxItems, int iSoftwareVersion)
        {

            pidP = new byte[pidItems];
            pidI = new byte[pidItems];
            pidD = new byte[pidItems];
            activation = new Int16[checkboxItems];

            iPIDItems = pidItems;
            iCheckBoxItems = checkboxItems;
            iSwVer = iSoftwareVersion;

            pidnames = new string[pidItems];

        }

        public void write_settings( SerialPort serialport)
        {

            byte[] buffer = new byte[250];          //this must be long enough
            int bptr = 0;                           //buffer pointer
            byte[] bInt16 = new byte[2];            //two byte buffer for converting int to two separated bytes
            byte checksum = 0;

            //Write out settings
            if (serialport.IsOpen)
            {

                //Write RC_TUNING
                bptr = 0;
                checksum = 0;
                buffer[bptr++] = (byte)'$';
                buffer[bptr++] = (byte)'M';
                buffer[bptr++] = (byte)'<';
                buffer[bptr++] = 7;
                buffer[bptr++] = (byte)MSP_SET_RC_TUNING;

                buffer[bptr++] = rcRate;
                buffer[bptr++] = rcExpo;
                buffer[bptr++] = RollPitchRate;
                buffer[bptr++] = YawRate;
                buffer[bptr++] = DynThrPID;
                buffer[bptr++] = ThrottleMID;
                buffer[bptr++] = ThrottleEXPO;
                for (int i = 3; i < bptr; i++) checksum ^= buffer[i];
                buffer[bptr++] = checksum;
                serialport.Write(buffer, 0, bptr);

                //Write PID's 
                bptr = 0;
                checksum = 0;
                buffer[bptr++] = (byte)'$';
                buffer[bptr++] = (byte)'M';
                buffer[bptr++] = (byte)'<';
                buffer[bptr++] = (byte)(3 * iPIDItems);
                buffer[bptr++] = (byte)MSP_SET_PID;
                for (int i = 0; i < iPIDItems; i++)
                {
                    buffer[bptr++] = pidP[i];
                    buffer[bptr++] = pidI[i];
                    buffer[bptr++] = pidD[i];
                }
                for (int i = 3; i < bptr; i++) checksum ^= buffer[i];
                buffer[bptr++] = checksum;
                serialport.Write(buffer, 0, bptr);

                //Then write checkboxitems

                bptr = 0;
                checksum = 0;
                buffer[bptr++] = (byte)'$';
                buffer[bptr++] = (byte)'M';
                buffer[bptr++] = (byte)'<';
                buffer[bptr++] = (byte)(2 * iCheckBoxItems);
                buffer[bptr++] = (byte)MSP_SET_BOX;

                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    buffer[bptr++] = (byte)(activation[i] & 0x00ff);
                    buffer[bptr++] = (byte)((activation[i] >> 8) & 0x00ff);
                }
                for (int i = 3; i < bptr; i++) checksum ^= buffer[i];
                buffer[bptr++] = checksum;
                serialport.Write(buffer, 0, bptr);


                //

                //then the rest
                bptr = 0;
                checksum = 0;
                buffer[bptr++] = (byte)'$';
                buffer[bptr++] = (byte)'M';
                buffer[bptr++] = (byte)'<';
                buffer[bptr++] = (byte)(2);
                buffer[bptr++] = (byte)MSP_SET_MISC;

                buffer[bptr++] = (byte)(PowerTrigger & 0x00ff);
                buffer[bptr++] = (byte)((PowerTrigger >> 8) & 0x00ff);

                for (int i = 3; i < bptr; i++) checksum ^= buffer[i];
                buffer[bptr++] = checksum;
                serialport.Write(buffer, 0, bptr);


                byte c = 0;
                byte[] o;
                o = new byte[10];
                // with checksum 
                o[0] = (byte)'$';
                o[1] = (byte)'M';
                o[2] = (byte)'<';
                o[3] = (byte)0; c ^= o[3];       //no payload 
                o[4] = (byte)MSP_EEPROM_WRITE; c ^= o[4];
                o[5] = (byte)c;
                serialport.Write(o, 0, 6);


            }
        }

        public void save_to_xml(string filename)
        {
            XmlTextWriter tw = new XmlTextWriter(filename,null);
            tw.Formatting = Formatting.Indented;
            tw.Indentation = 4;
            tw.WriteStartDocument();

            // Get the name and version of the current assembly.
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            tw.WriteComment(String.Format("{0}, Version {1}", assemName.Name, ver.ToString()));
            tw.WriteComment("MultiWii FC Parameters file");
            tw.WriteComment("MultiWii FC software revision 2.1dev"); 
            
            tw.WriteStartElement("PARAMETERS");

            tw.WriteStartElement("VERSION value=\"" + iSwVer + "\""); tw.WriteEndElement();

            for (int i = 0; i < iPIDItems; i++)
            {
                tw.WriteStartElement("PID id=\"" + i+"\" name=\""+pidnames[i]+"\" p=\""+Convert.ToString(pidP[i])+"\" i=\""+Convert.ToString(pidI[i])+"\" d=\""+Convert.ToString(pidD[i])+"\"");
                tw.WriteEndElement();

            }

            for (int i = 0; i < iCheckBoxItems; i++)
            {
                tw.WriteStartElement("AUXFUNC id=\"" + i + "\" aux1234=\"" + activation[i] + "\"");
                tw.WriteEndElement();
            }

            tw.WriteStartElement("RCRATE value=\"" + rcRate + "\""); tw.WriteEndElement();
            tw.WriteStartElement("RCEXPO value=\"" + rcExpo + "\""); tw.WriteEndElement();
            tw.WriteStartElement("THMID value=\"" + ThrottleMID + "\""); tw.WriteEndElement();
            tw.WriteStartElement("THEXPO value=\"" + ThrottleMID + "\""); tw.WriteEndElement();
            tw.WriteStartElement("ROLLPITCHRATE value=\"" + RollPitchRate + "\""); tw.WriteEndElement();
            tw.WriteStartElement("YAWRATE value=\"" + YawRate + "\""); tw.WriteEndElement();
            tw.WriteStartElement("DYNTHRPID value=\"" + DynThrPID + "\""); tw.WriteEndElement();
            tw.WriteStartElement("POWERTRIGGER value=\"" + PowerTrigger + "\""); tw.WriteEndElement();
            tw.WriteStartElement("COMMENT value=\"" + comment + "\""); tw.WriteEndElement();

            tw.WriteEndElement();
            tw.WriteEndDocument();
            tw.Close();
        }

        public bool read_from_xml(string filename)
        {

                XmlTextReader reader = new XmlTextReader(filename);
                //MessageBox.Show("Options file " + sOptionsConfigFilename + " does not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:

                                if (String.Compare(reader.Name, "version", true) == 0 && reader.HasAttributes)
                                {
                                    if (Convert.ToInt16(reader.GetAttribute("value")) != iSwVer)
                                    {
                                        throw new System.InvalidOperationException("Version of settings file does not match with the version set in GUI");
                                    }
                                }
                                if (String.Compare(reader.Name, "pid", true) == 0 && reader.HasAttributes)
                                {
                                    int tpidID = 0; byte tpidP = 0; byte tpidI = 0; byte tpidD = 0;

                                    tpidID = Convert.ToInt16(reader.GetAttribute("id"));
                                    tpidP = Convert.ToByte(reader.GetAttribute("p"));
                                    tpidI = Convert.ToByte(reader.GetAttribute("i"));
                                    tpidD = Convert.ToByte(reader.GetAttribute("d"));
                                    pidP[tpidID] = tpidP;
                                    pidI[tpidID] = tpidI;
                                    pidD[tpidID] = tpidD;
                                }
                                if (String.Compare(reader.Name, "auxfunc", true) == 0 && reader.HasAttributes)
                                {
                                    int auxID = 0; short a1 = 0; 
                                    auxID = Convert.ToInt16(reader.GetAttribute("id"));
                                    a1 = Convert.ToByte(reader.GetAttribute("aux1234"));
                                    activation[auxID] = a1;
                                }
                                if (String.Compare(reader.Name, "rcrate", true) == 0 && reader.HasAttributes) { rcRate = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "rcexpo", true) == 0 && reader.HasAttributes) { rcExpo = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "thmid", true) == 0 && reader.HasAttributes) { ThrottleMID = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "thexpo", true) == 0 && reader.HasAttributes) { ThrottleEXPO  = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "rollpitchrate", true) == 0 && reader.HasAttributes) { RollPitchRate = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "yawrate", true) == 0 && reader.HasAttributes) { YawRate = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "dynthrpid", true) == 0 && reader.HasAttributes) { DynThrPID = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "powertrigger", true) == 0 && reader.HasAttributes) { PowerTrigger = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "comment", true) == 0 && reader.HasAttributes) { comment = reader.GetAttribute("value"); }
                                break;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    MessageBoxEx.Show(e.Message,"Version mismatch",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return (false);
                }
                catch
                {
                    MessageBoxEx.Show("Options file contains invalid data around Line : " + reader.LineNumber, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return (false);
                }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
                return (true);
        }

    
    
    
    }


    #endregion

    #region mw_data_gui

    public class mw_data_gui
    {

        public int ax;          //AccSmooth
        public int ay;          //AccSmooth
        public int az;          //AccSmooth
        public int gx;          //Gyro Smooth
        public int gy;          //Gyro Smooth
        public int gz;          //Gyro Smooth
        public int magx;    //Magnetometer 
        public int magy;    //Magnetometer 
        public int magz;   //Magnetometer 
        public int baro;
        public int heading;
        public int[] servos;
        public int[] motors;
        public int rcRoll, rcPitch, rcYaw, rcThrottle;
        public int rcAux1, rcAux2, rcAux3, rcAux4;
        public int present;            //What sensors are present?
        public UInt32 mode;               //What mode are we in ?
        public int i2cErrors;
        public int cycleTime;
        public int angx;                //Must be /10
        public int angy;                //Must be /10
        public byte multiType;
        public byte version;
        public byte protocol_version;
        public Int32 capability;
        public byte[] pidP;
        public byte[] pidI;
        public byte[] pidD;
        public byte rcRate;
        public byte rcExpo;
        public byte RollPitchRate;
        public byte YawRate;
        public byte DynThrPID;
        public byte ThrottleMID;
        public byte ThrottleEXPO;
        public Int16[] activation;
        public int GPS_distanceToHome;
        public int GPS_directionToHome;
        public byte GPS_numSat;
        public byte GPS_fix;
        public byte GPS_update;
        public int GPS_latitude;
        public int GPS_longitude;
        public int GPS_altitude;
        public int GPS_speed;
        public int pMeterSum;
        public int powerTrigger;
        public byte vBat;
        public int debug1, debug2, debug3, debug4;

        private int iPIDItems, iCheckBoxItems;
        private int iSwVer;
        private bool bCompatibilityMode;

        //Constructor
        public mw_data_gui(int pidItems, int checkboxItems, int iSoftwareVersion)
        {
            motors = new int[8];
            servos = new int[8];
            pidP = new byte[pidItems];
            pidI = new byte[pidItems];
            pidD = new byte[pidItems];

            activation = new Int16[checkboxItems];

            iPIDItems = pidItems;
            iCheckBoxItems = checkboxItems;
            iSwVer = iSoftwareVersion;


        }


    }
}
    #endregion