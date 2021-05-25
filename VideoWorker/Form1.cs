using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.IO;

namespace VideoWorker
{
    public partial class Form1 : Form
    {
        private static CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        private static VideoCapture vc = null;
        private static Mat mat = new Mat();
        private static Image<Bgr, byte> iplImage = null;
        private static string path = "";

        public Form1()
        {
            InitializeComponent();
        }

        //public Image<Bgr, byte> = null;

        private void openFile_Click(object sender, EventArgs e)
        {
            setVideo.Filter = "Video files (*.mp4, *.wm, *.asf, *.wmv, *.avi, *.wtv, *.mpeg, *.mpg, *.mpe, *.m1v, *.mp2, *.mpv2, *.vob) | *.mp4; *.wm; *.asf; *.wmv; *.avi; *.wtv; *.mpeg; *.mpg; *.mpe; *.m1v; *.mp2; *.mpv2; *.vob";
            if (setVideo.ShowDialog() == DialogResult.OK)
            {
                vc = new VideoCapture(setVideo.FileName);
                path = setVideo.FileName;
                player.URL = path;
                player.Ctlcontrols.stop();
            }
        }

        private void setRect_Click(object sender, EventArgs e)
        {
            int i = 1;
            try
            {
                using (var video = new VideoCapture(path))
                using (var img = new Mat())
                {
                    while (video.Grab())
                    {
                        video.Retrieve(img);
                        var filename = Path.Combine(@"D:\fgh", $"{i}.png");
                        CvInvoke.Imwrite(filename, img);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
