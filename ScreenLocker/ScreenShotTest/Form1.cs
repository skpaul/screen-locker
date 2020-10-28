using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ScreenShotTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap screenShot = CaptureScreen(true);
            //string directory = Application.StartupPath;
            //string fileName = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + ".jpg";
            //string path = Path.Combine(directory, fileName);
            //if (!File.Exists(path))
            //{
            //    screenShot.Save(path);
            //}

            try
            {
                var connectionString = "mongodb://skpaul:somehowiknow1!@ds053139.mongolab.com:53139/mdp";
                var client = new MongoClient(connectionString);
                var server = client.GetServer();
                var database = server.GetDatabase("mdp");

                var logs = database.GetCollection<BsonDocument>("KMLog");
                var log = new KMLog();
                log.ComputerName = "MySelf";
                log.EventName = "TestEvent";
                log.IpAddress = "test";
                log.LogDateTime = DateTime.Now.ToString();
                log.Image = screenShot;
                logs.Insert(log);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Bitmap CaptureScreen(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                }
            }
            catch
            {
                result = null;
            }

            return result;
        }
    }
}
