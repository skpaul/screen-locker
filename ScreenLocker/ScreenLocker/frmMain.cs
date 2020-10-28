using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenLocker
{
    public partial class frmMain : Form
    {
        string currentPassword = string.Empty;
        string configPassword = string.Empty;

        public frmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;

            //the order of code is important and will not work if you change the place of WindwosState and FormBorderStyle.
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.ShowInTaskbar = false;
            double OpacityValue = 4.0 / 100;
            this.Opacity = OpacityValue;
            this.TopMost = true;
        }

        private void FormOnLoad(object sender, EventArgs e)
        {
            String path = Path.Combine(Application.StartupPath, "Config.txt");
            CreateFile(path);
            using (StreamReader sr = new StreamReader(path))
            {
                configPassword = sr.ReadToEnd();
            }

            path = Path.Combine(Application.StartupPath, "ClickLog.txt");
            CreateFile(path);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.P && e.Modifiers == (Keys.Control | Keys.Shift | Keys.Alt))
            //{
            //    this.Close();
            //}
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (String.Equals(currentPassword, configPassword))
                {
                    this.Close();
                }
                else
                {
                    currentPassword = "";
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                currentPassword = "";
            }
            else
            {
                string value = e.KeyChar.ToString();
                currentPassword += value;
            }
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            //String mousePosition =  MousePosition.ToString();
            //string path = Path.Combine(Application.StartupPath, "ClickLog.txt");
            //using (StreamWriter writer=new StreamWriter(path,true))
            //{
            //    writer.WriteLine(mousePosition + " On " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") );
            //}

            Bitmap screenShot = CaptureScreen(true);
            string directory = Application.StartupPath;
            string fileName = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + ".jpg";
            string path = Path.Combine(directory,fileName);
            if (!File.Exists(path))
            {
                screenShot.Save(path);
            }
            
        }

        private void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        #region Screen shot taking code

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        public static Bitmap CaptureScreen(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (CaptureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        #endregion

    }
}
