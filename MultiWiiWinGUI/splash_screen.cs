using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace MultiWiiWinGUI
{
    public partial class splash_screen : Form
    {
        public splash_screen()
        {
            InitializeComponent();
            l_full_version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

    }
}
