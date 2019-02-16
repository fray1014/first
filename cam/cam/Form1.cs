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
        public Form1()
        {
            InitializeComponent();
            try
            {
                _capture = new Capture(0);//参数0表示默认摄像头，1表示外接摄像头
                
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
            //int test = frame.[1,1,1];

            captureImageBox.Image = frame;
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
