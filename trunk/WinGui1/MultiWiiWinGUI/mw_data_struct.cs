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

        public bool bSupressI2CErrorData { get; set; }

        //Constructor, set default values
        public GUI_settings()
        {
            sLogFolder = Directory.GetCurrentDirectory();
            sCaptureFolder = Directory.GetCurrentDirectory();
            sSettingsFolder = Directory.GetCurrentDirectory();
            iSoftwareVersion = 19;
            bEnableLogging = false;
            bSupressI2CErrorData = false;
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

            tw.WriteComment("Change this to TRUE if you using 20120203 release, this will depreciate serial protocol change in SVN r569");
            tw.WriteComment("This will work only when FCVERSION==20");
            tw.WriteStartElement("SUPRESSI2CERRORDATA value=\"" + bSupressI2CErrorData + "\""); tw.WriteEndElement();

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

                            if (String.Compare(reader.Name, "supressi2cerrordata", true) == 0 && reader.HasAttributes) { bSupressI2CErrorData = Convert.ToBoolean(reader.GetAttribute("value")); }

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

        public byte[] activation1;
        public byte[] activation2;

        public int PowerTrigger;

        //For GUI only
        public string comment;


        private string[] pidnames;
        private int iPIDItems, iCheckBoxItems;
        private int iSwVer;

        //Constructor
        public mw_settings(int pidItems, int checkboxItems, int iSoftwareVersion)
        {

            pidP = new byte[pidItems];
            pidI = new byte[pidItems];
            pidD = new byte[pidItems];
            activation1 = new byte[checkboxItems];
            activation2 = new byte[checkboxItems];

            iPIDItems = pidItems;
            iCheckBoxItems = checkboxItems;
            iSwVer = iSoftwareVersion;

            if (iSoftwareVersion == 20) { pidnames = new String[] { "ROLL", "PITCH", "YAW", "ALT", "VEL", "GPS", "LEVEL", "MAG" }; }
            if (iSoftwareVersion == 19) { pidnames = new String[] { "ROLL", "PITCH", "YAW", "ALT", "VEL", "LEVEL", "MAG" }; }


        }

        public void write_settings( SerialPort serialport)
        {

            byte[] buffer = new byte[250];          //this must be long enough
            int bptr = 0;                           //buffer pointer
            byte[] bInt16 = new byte[2];            //two byte buffer for converting int to two separated bytes

            //Write out settings
            if (serialport.IsOpen)
            {
                #region SoftwareVer == 20
                if (iSwVer == 20)
                {
                    buffer[bptr++] = 87;                    // W
                    for (int i = 0; i < iPIDItems; i++)
                    {
                        buffer[bptr++] = pidP[i];
                        buffer[bptr++] = pidI[i];
                        buffer[bptr++] = pidD[i];
                    }
                    buffer[bptr++] = rcRate;
                    buffer[bptr++] = rcExpo;
                    buffer[bptr++] = RollPitchRate;
                    buffer[bptr++] = YawRate;
                    buffer[bptr++] = DynThrPID;
                    for (int i = 0; i < iCheckBoxItems; i++)
                    {
                        buffer[bptr++] = activation1[i];
                        buffer[bptr++] = activation2[i];
                    }

                    bInt16 = System.BitConverter.GetBytes(PowerTrigger);

                    buffer[bptr++] = bInt16[0];
                    buffer[bptr++] = bInt16[1];
                }
                #endregion
                #region SoftwareVer == 19
                if (iSwVer == 19)
                {
                    buffer[bptr++] = 87;                    // W
                    for (int i = 0; i < 5; i++)
                    {
                        buffer[bptr++] = pidP[i];
                        buffer[bptr++] = pidI[i];
                        buffer[bptr++] = pidD[i];
                    }
                    buffer[bptr++] = pidP[5];           //Level P
                    buffer[bptr++] = pidI[5];           //Level I

                    buffer[bptr++] = pidP[6];           //Mag P

                    buffer[bptr++] = rcRate;
                    buffer[bptr++] = rcExpo;
                    buffer[bptr++] = RollPitchRate;
                    buffer[bptr++] = YawRate;
                    buffer[bptr++] = DynThrPID;
                    for (int i = 0; i < iCheckBoxItems; i++)
                    {
                        buffer[bptr++] = activation1[i];
                        //buffer[bptr++] = activation2[i];
                    }

                    bInt16 = System.BitConverter.GetBytes(PowerTrigger);

                    buffer[bptr++] = bInt16[0];
                    buffer[bptr++] = bInt16[1];
                }

                #endregion
                serialport.Write(buffer, 0, bptr);

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
            if (iSwVer == 20) { tw.WriteComment("MultiWii FC software revision DEV20120203"); }
            if (iSwVer == 19) { tw.WriteComment("MultiWii FC software revision 1.9 released"); }

            tw.WriteStartElement("PARAMETERS");

            tw.WriteStartElement("VERSION value=\"" + iSwVer + "\""); tw.WriteEndElement();

            for (int i = 0; i < iPIDItems; i++)
            {
                tw.WriteStartElement("PID id=\"" + i+"\" name=\""+pidnames[i]+"\" p=\""+Convert.ToString(pidP[i])+"\" i=\""+Convert.ToString(pidI[i])+"\" d=\""+Convert.ToString(pidD[i])+"\"");
                tw.WriteEndElement();

            }

            for (int i = 0; i < iCheckBoxItems; i++)
            {
                tw.WriteStartElement("AUXFUNC id=\"" + i + "\" aux12=\"" + activation1[i] + "\" aux34=\"" + activation2[i] + "\"");
                tw.WriteEndElement();
            }

            tw.WriteStartElement("RCRATE value=\"" + rcRate + "\""); tw.WriteEndElement();
            tw.WriteStartElement("RCEXPO value=\"" + rcExpo + "\""); tw.WriteEndElement();
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
                                    int auxID = 0; byte a1 = 0; byte a2 = 0;
                                    auxID = Convert.ToInt16(reader.GetAttribute("id"));
                                    a1 = Convert.ToByte(reader.GetAttribute("aux12"));
                                    a2 = Convert.ToByte(reader.GetAttribute("aux34"));
                                    activation1[auxID] = a1;
                                    activation2[auxID] = a2;
                                }
                                if (String.Compare(reader.Name, "rcrate", true) == 0 && reader.HasAttributes) { rcRate = Convert.ToByte(reader.GetAttribute("value")); }
                                if (String.Compare(reader.Name, "rcexpo", true) == 0 && reader.HasAttributes) { rcExpo = Convert.ToByte(reader.GetAttribute("value")); }
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
        public byte present;            //What sensors are present?
        public byte mode;               //What mode are we in ?
        public int i2cErrors;
        public int cycleTime;
        public int angx;                //Must be /10
        public int angy;                //Must be /10
        public byte multiType;
        public byte[] pidP;
        public byte[] pidI;
        public byte[] pidD;
        public byte rcRate;
        public byte rcExpo;
        public byte RollPitchRate;
        public byte YawRate;
        public byte DynThrPID;
        public byte[] activation1;
        public byte[] activation2;
        public int GPS_distanceToHome;
        public int GPS_directionToHome;
        public byte GPS_numSat;
        public byte GPS_fix;
        public byte GPS_update;
        public int pMeterSum;
        public int powerTrigger;
        public byte vBat;
        public int debug1, debug2, debug3,debug4;

        private int iPIDItems, iCheckBoxItems;
        private int iSwVer;
        private bool bCompatibilityMode;

        //Constructor
        public mw_data_gui(int pidItems,int checkboxItems, int iSoftwareVersion, bool bCompatibility)
        {
            motors = new int[8];
            servos = new int[8];
            pidP = new byte[pidItems];
            pidI = new byte[pidItems];
            pidD = new byte[pidItems];
            activation1 = new byte[checkboxItems];
            activation2 = new byte[checkboxItems];

            iPIDItems = pidItems;
            iCheckBoxItems = checkboxItems;
            iSwVer = iSoftwareVersion;
            bCompatibilityMode = bCompatibility;


        }

        public void parse_input_packet( byte[] packet)
        {

            int o = 2;                  //start offset (M and ver)
            const int i16 = 2;          //one int16

            #region SwVer = 20

            if (iSwVer == 20)
            {
                ax = BitConverter.ToInt16(packet, o); o += i16;
                ay = BitConverter.ToInt16(packet, o); o += i16;
                az = BitConverter.ToInt16(packet, o); o += i16;

                gx = BitConverter.ToInt16(packet, o) / 8; o += i16;
                gy = BitConverter.ToInt16(packet, o) / 8; o += i16;
                gz = BitConverter.ToInt16(packet, o) / 8; o += i16;

                magx = BitConverter.ToInt16(packet, o) / 3; o += i16;
                magy = BitConverter.ToInt16(packet, o) / 3; o += i16;
                magz = BitConverter.ToInt16(packet, o) / 3; o += i16;

                baro = BitConverter.ToInt16(packet, o); o += i16;
                heading = BitConverter.ToInt16(packet, o); o += i16;

                for (int i = 0; i < 8; i++)
                {
                    servos[i] = BitConverter.ToInt16(packet, o); o += i16;
                }
                for (int i = 0; i < 8; i++)
                {
                    motors[i] = BitConverter.ToInt16(packet, o); o += i16;
                }

                rcRoll = BitConverter.ToInt16(packet, o); o += i16;
                rcPitch = BitConverter.ToInt16(packet, o); o += i16;
                rcYaw = BitConverter.ToInt16(packet, o); o += i16;
                rcThrottle = BitConverter.ToInt16(packet, o); o += i16;

                rcAux1 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux2 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux3 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux4 = BitConverter.ToInt16(packet, o); o += i16;

                present = packet[o++];
                mode = packet[o++];
                cycleTime = BitConverter.ToInt16(packet, o); o += i16;
                //For 20120203dev compatibity
                if (!bCompatibilityMode) { i2cErrors = BitConverter.ToInt16(packet, o); o += i16; }
                angx = BitConverter.ToInt16(packet, o) / 10; o += i16;
                angy = BitConverter.ToInt16(packet, o) / 10; o += i16;
                multiType = packet[o++];

                for (int i = 0; i < iPIDItems; i++)
                {
                    pidP[i] = packet[o++];
                    pidI[i] = packet[o++];
                    pidD[i] = packet[o++];
                }
                rcRate = packet[o++];
                rcExpo = packet[o++];
                RollPitchRate = packet[o++];
                YawRate = packet[o++];
                DynThrPID = packet[o++];

                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    activation1[i] = packet[o++];
                    activation2[i] = packet[o++];
                }
                GPS_distanceToHome = BitConverter.ToInt16(packet, o); o += i16;
                GPS_directionToHome = BitConverter.ToInt16(packet, o); o += i16;
                GPS_numSat = packet[o++];
                GPS_fix = packet[o++];
                GPS_update = packet[o++];
                pMeterSum = BitConverter.ToInt16(packet, o); o += i16;
                powerTrigger = BitConverter.ToInt16(packet, o); o += i16;
                vBat = packet[o++];

                debug1 = BitConverter.ToInt16(packet, o); o += i16;
                debug2 = BitConverter.ToInt16(packet, o); o += i16;
                debug3 = BitConverter.ToInt16(packet, o); o += i16;
                debug4 = BitConverter.ToInt16(packet, o); o += i16;
            }
            #endregion

            #region SwVer = 19

            if (iSwVer == 19)
            {
                ax = BitConverter.ToInt16(packet, o); o += i16;
                ay = BitConverter.ToInt16(packet, o); o += i16;
                az = BitConverter.ToInt16(packet, o); o += i16;

                gx = BitConverter.ToInt16(packet, o); o += i16;
                gy = BitConverter.ToInt16(packet, o); o += i16;
                gz = BitConverter.ToInt16(packet, o); o += i16;

                magx = BitConverter.ToInt16(packet, o); o += i16;
                magy = BitConverter.ToInt16(packet, o); o += i16;
                magz = BitConverter.ToInt16(packet, o); o += i16;

                baro = BitConverter.ToInt16(packet, o); o += i16;
                heading = BitConverter.ToInt16(packet, o); o += i16;

                for (int i = 0; i < 4; i++)
                {
                    servos[i] = BitConverter.ToInt16(packet, o); o += i16;
                }
                for (int i = 0; i < 8; i++)
                {
                    motors[i] = BitConverter.ToInt16(packet, o); o += i16;
                }

                rcRoll = BitConverter.ToInt16(packet, o); o += i16;
                rcPitch = BitConverter.ToInt16(packet, o); o += i16;
                rcYaw = BitConverter.ToInt16(packet, o); o += i16;
                rcThrottle = BitConverter.ToInt16(packet, o); o += i16;

                rcAux1 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux2 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux3 = BitConverter.ToInt16(packet, o); o += i16;
                rcAux4 = BitConverter.ToInt16(packet, o); o += i16;

                present = packet[o++];
                mode = packet[o++];
                cycleTime = BitConverter.ToInt16(packet, o); o += i16;
                angx = BitConverter.ToInt16(packet, o); o += i16;
                angy = BitConverter.ToInt16(packet, o); o += i16;
                multiType = packet[o++];

                for (int i = 0; i < 5; i++)
                {
                    pidP[i] = packet[o++];
                    pidI[i] = packet[o++];
                    pidD[i] = packet[o++];
                }
                pidP[5] = packet[o++];          //Level P
                pidI[5] = packet[o++];          //level I
                pidP[6] = packet[o++];          //Mag P
                rcRate = packet[o++];
                rcExpo = packet[o++];
                RollPitchRate = packet[o++];
                YawRate = packet[o++];
                DynThrPID = packet[o++];

                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    activation1[i] = packet[o++];
                    //activation2[i] = packet[o++];
                }
                GPS_distanceToHome = BitConverter.ToInt16(packet, o); o += i16;
                GPS_directionToHome = BitConverter.ToInt16(packet, o); o += i16;
                GPS_numSat = packet[o++];
                GPS_fix = packet[o++];
                GPS_update = packet[o++];
                pMeterSum = BitConverter.ToInt16(packet, o); o += i16;
                powerTrigger = BitConverter.ToInt16(packet, o); o += i16;
                vBat = packet[o++];

                debug1 = BitConverter.ToInt16(packet, o); o += i16;
                debug2 = BitConverter.ToInt16(packet, o); o += i16;
                debug3 = BitConverter.ToInt16(packet, o); o += i16;
                debug4 = BitConverter.ToInt16(packet, o); o += i16;
            }
            #endregion

        }

    }
#endregion


}
