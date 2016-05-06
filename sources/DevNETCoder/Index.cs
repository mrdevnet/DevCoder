using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;
using System.Data.SqlClient;
using DevNETCoder.Static;

namespace DevNETCoder
{
    public partial class Index : DevExpress.XtraEditors.XtraForm
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = false;
                UpdateFormDisplay(this.BackgroundImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }
        protected override CreateParams CreateParams {
	        get {
		        CreateParams cp = base.CreateParams;
		        cp.ExStyle = cp.ExStyle | 0x80000;
		        return cp;
	        }
        }


        public void UpdateFormDisplay(Image backgroundImage)
        {
	        IntPtr screenDc = API.GetDC(IntPtr.Zero);
	        IntPtr memDc = API.CreateCompatibleDC(screenDc);
	        IntPtr hBitmap = IntPtr.Zero;
	        IntPtr oldBitmap = IntPtr.Zero;

	        try {
		        //Display-image
		        Bitmap bmp = new Bitmap(backgroundImage);
		        hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
		        //Set the fact that background is transparent
		        oldBitmap = API.SelectObject(memDc, hBitmap);

		        //Display-rectangle
		        Size size = bmp.Size;
		        Point pointSource = new Point(0, 0);
		        Point topPos = new Point(this.Left, this.Top);

		        //Set up blending options
		        API.BLENDFUNCTION blend = new API.BLENDFUNCTION();
		        blend.BlendOp = API.AC_SRC_OVER;
		        blend.BlendFlags = 0;
		        blend.SourceConstantAlpha = 255;
		        blend.AlphaFormat = API.AC_SRC_ALPHA;

                API.UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref  size, memDc, ref  pointSource, 0, ref  blend, API.ULW_ALPHA);

		        //Clean-up
		        bmp.Dispose();
		        API.ReleaseDC(IntPtr.Zero, screenDc);
		        if (hBitmap != IntPtr.Zero) {
			        API.SelectObject(memDc, oldBitmap);
			        API.DeleteObject(hBitmap);
		        }
		        API.DeleteDC(memDc);
	        } catch  {
	        }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
	        UpdateFormDisplay(this.BackgroundImage);
        }

        private void Index_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Save.Servers == null)
                {
                    Save.Servers = SmoApplication.EnumAvailableSqlServers(false);
                }
                this.Hide();
                SForm.LoginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
           
        }
   }
    internal class API
    {
        public const byte AC_SRC_OVER = 0x0;
        public const byte AC_SRC_ALPHA = 0x1;

        public const Int32 ULW_ALPHA = 0x2;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]


        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern bool DeleteDC(IntPtr hdc);


        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern bool DeleteObject(IntPtr hObject);
    }
}