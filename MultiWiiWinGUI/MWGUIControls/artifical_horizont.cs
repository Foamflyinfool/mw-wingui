
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Data;

namespace MultiWiiGUIControls
{
    class artifical_horizon : MWGUIControl
    {
        #region Fields

        // Parameters
       private double PitchAngle = 0; // Phi
	   private double RollAngle = 0; // Theta

        // Images
        Bitmap bmpBackground = new Bitmap(MultiWiiWinGUI.MWGUIControls.MWGUIControlsResources.Horizon_Background);
        Bitmap bmpHorizon = new Bitmap(MultiWiiWinGUI.MWGUIControls.MWGUIControlsResources.Horizon_GroundSky);
        Bitmap bmpPlane = new Bitmap(MultiWiiWinGUI.MWGUIControls.MWGUIControlsResources.Maquette_Avion);

        #endregion

        #region Contructor

        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public artifical_horizon()
		{
			// Double bufferisation
			SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region Paint

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);

            Point ptHorizon_sky = new Point(12, - 105);
            Point ptRotation = new Point(75, 75);

            bmpBackground.MakeTransparent(Color.Yellow);
            bmpPlane.MakeTransparent(Color.Yellow);

            //Horizon
            Bitmap bmp = new Bitmap(125, 360);
            Graphics gfx = Graphics.FromImage(bmp);

            gfx.TranslateTransform(62f, 180f);
            gfx.RotateTransform((float)(RollAngle));
            gfx.TranslateTransform(-62f, -180f);
            gfx.TranslateTransform(0,(float)PitchAngle*2);
            gfx.DrawImageUnscaled(bmpHorizon, 0, 0);
            pe.Graphics.DrawImageUnscaled(bmp, 12, -105);

            // diplay mask
            Pen maskPen = new Pen(this.BackColor,30);
            pe.Graphics.DrawRectangle(maskPen, 0, 0, bmpBackground.Width, bmpBackground.Height);

            // display control background
            pe.Graphics.DrawImageUnscaled(bmpBackground, 0, 0, (bmpBackground.Width), (bmpBackground.Height));

            // display aircraft symbol
            pe.Graphics.DrawImageUnscaled(bmpPlane, (int)((0.5 * bmpBackground.Width - 0.5 * bmpPlane.Width)), (int)((0.5 * bmpBackground.Height - 0.5 * bmpPlane.Height)), (bmpPlane.Width), (bmpPlane.Height));

            gfx.Dispose();
            bmp.Dispose();
            maskPen.Dispose();


        }

        #endregion

        #region Methods

        /// <summary>
        /// Define the physical value to be displayed on the indicator
        /// </summary>
        /// <param name="aircraftPitchAngle">The aircraft pitch angle in °deg</param>
        /// <param name="aircraftRollAngle">The aircraft roll angle in °deg</param
        public void SetArtificalHorizon(double aircraftPitchAngle, double aircraftRollAngle)
        {
            PitchAngle = aircraftPitchAngle;
            RollAngle = aircraftRollAngle;

            this.Refresh();
        }

        #endregion

    }
}
