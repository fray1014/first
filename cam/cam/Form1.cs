using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
namespace cam
{
    public partial class Form1 : Form
    {
        private Capture _capture = null;
        private bool _captureInProgress;
        static int th = 100;
        static int cnt = 0;//去抖动计数器
        public Form1()
        {
            InitializeComponent();
            try
            {
                _capture = new Capture(1);//参数0表示默认摄像头，1表示外接摄像头                
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {           
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            Image<Gray, Byte> gray_image = frame.Convert<Gray, Byte>();
            if (cnt <= 100)
                cnt++;
            else
                cnt = 0;
            laplacebox.Image = frame.Laplace(5);
            th=Convert.ToInt32(canny_th.Text);
            cannybox.Image = frame.Canny(20, th);
            captureImageBox.Image = frame;
            //label1.Text = Convert.ToString(cnt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    captureButton.Text = "打开摄像头";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    captureButton.Text = "暂停摄像头";
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
            }           
        }

    }
}
