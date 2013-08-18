using System;


namespace MultiWiiWinGUI
{

    public class GUIPages
    {
        public const int FlighTune = 0;
        public const int Config = 1;
        public const int RC = 2;
        public const int Realtime = 3;
        public const int Mission = 4;
        public const int Video = 5;
        public const int GUISettings = 6;
        public const int CLI = 7;
    }

    public class MSP
    {
        public const byte MSP_IDENT = 100;   //out message         multitype + multiwii version + protocol version + capability variable
        public const byte MSP_STATUS = 101;   //out message         cycletime & errors_count & sensor present & box activation & current setting number
        public const byte MSP_RAW_IMU = 102;   //out message         9 DOF
        public const byte MSP_SERVO = 103;   //out message         8 servos
        public const byte MSP_MOTOR = 104;   //out message         8 motors
        public const byte MSP_RC = 105;   //out message         8 rc chan and more
        public const byte MSP_RAW_GPS = 106;   //out message         fix, numsat, lat, lon, alt, speed, ground course
        public const byte MSP_COMP_GPS = 107;   //out message         distance home, direction home
        public const byte MSP_ATTITUDE = 108;   //out message         2 angles 1 heading
        public const byte MSP_ALTITUDE = 109;   //out message         altitude, variometer
        public const byte MSP_ANALOG = 110;   //out message         vbat, powermetersum, rssi if available on RX
        public const byte MSP_RC_TUNING = 111;   //out message         rc rate, rc expo, rollpitch rate, yaw rate, dyn throttle PID
        public const byte MSP_PID = 112;   //out message         P I D coeff (9 are used currently)
        public const byte MSP_BOX = 113;   //out message         BOX setup (number is dependant of your setup)
        public const byte MSP_MISC = 114;   //out message         powermeter trig
        public const byte MSP_MOTOR_PINS = 115;   //out message         which pins are in use for motors & servos, for GUI 
        public const byte MSP_BOXNAMES = 116;   //out message         the aux switch names
        public const byte MSP_PIDNAMES = 117;   //out message         the PID names
        public const byte MSP_WP = 118;   //out message         get a WP, WP# is in the payload, returns (WP#, lat, lon, alt, flags) WP#0-home, WP#16-poshold
        public const byte MSP_BOXIDS = 119;   //out message         get the permanent IDs associated to BOXes
        public const byte MSP_SERVO_CONF = 120;   //out message         Servo settings

        public const byte MSP_SET_RAW_RC = 200;   //in message          8 rc chan
        public const byte MSP_SET_RAW_GPS = 201;   //in message          fix, numsat, lat, lon, alt, speed
        public const byte MSP_SET_PID = 202;   //in message          P I D coeff (9 are used currently)
        public const byte MSP_SET_BOX = 203;   //in message          BOX setup (number is dependant of your setup)
        public const byte MSP_SET_RC_TUNING = 204;   //in message          rc rate, rc expo, rollpitch rate, yaw rate, dyn throttle PID
        public const byte MSP_ACC_CALIBRATION = 205;   //in message          no param
        public const byte MSP_MAG_CALIBRATION = 206;   //in message          no param
        public const byte MSP_SET_MISC = 207;   //in message          powermeter trig + 8 free for future use
        public const byte MSP_RESET_CONF = 208;   //in message          no param
        public const byte MSP_SET_WP = 209;   //in message          sets a given WP (WP#,lat, lon, alt, flags)
        public const byte MSP_SELECT_SETTING = 210;   //in message          Select Setting Number (0-2)
        public const byte MSP_SET_HEAD = 211;   //in message          define a new heading hold direction
        public const byte MSP_SET_SERVO_CONF = 212;   //in message          Servo settings
        public const byte MSP_SET_MOTOR = 214;   //in message          PropBalance function

        public const byte MSP_BIND = 240;   //in message          no param

        public const byte MSP_EEPROM_WRITE = 250;   //in message          no param

        public const byte MSP_DEBUGMSG = 253;   //out message         debug string buffer
        public const byte MSP_DEBUG = 254;   //out message         debug1,debug2,debug3,debug4

    }



}
