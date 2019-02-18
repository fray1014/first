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
            /*for (int i=0;i<100;i++)
            {
                for (int j=0;j<100;j++)
                {
                    Bgr temp = frame[i, j];
                    frame[i, j] = frame[i + 100, j + 100];
                    frame[i + 100, j + 100] = temp;
                }
            }*/
            laplacebox.Image = frame.Laplace(5);
            captureImageBox.Image = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    captureButton.Text = "打开摄像头";
                    label1.Text = Convert.ToString(_capture.QueryFrame()[100, 100].Blue);
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
