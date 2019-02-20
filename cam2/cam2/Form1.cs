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
namespace cam2
{
    public partial class Form1 : Form
    {
        private static Capture _cameraCapture;
        private Image<Bgr, Byte> frame ;
        private Image<Gray, Byte>[] canny_frame = new Image<Gray,Byte>[2];
        private Image<Gray, Byte> canny_out ;
        static int cnt = 0;//消抖计数器
        static int th = 100;//canny第二阈值初始化
        public Form1()
        {
            InitializeComponent();
            Run();
        }
        void Run()
        {
            try
            {
                _cameraCapture = new Capture(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            Application.Idle += ProcessFrame;
        }
        void ProcessFrame(object sender, EventArgs e)
        {
            frame = _cameraCapture.QueryFrame();
            canny_out = frame.Convert<Gray, Byte>();
            //frame._SmoothGaussian(3); //filter out noises
            if (cnt<1)
            {
                canny_frame[cnt] = _cameraCapture.QueryFrame().Canny(50, th);
                cnt++;
            }
            else
            {
                canny_frame[cnt] = _cameraCapture.QueryFrame().Canny(50, th);
                for(int i=0;i<imageBox1.Height;i++)
                {
                    for(int j=0;j<imageBox1.Width;j++)
                    {
                        if(canny_frame[0].Data[i,j,0]==canny_frame[1].Data[i,j,0])
                        {
                            canny_out.Data[i, j, 0] = canny_frame[0].Data[i, j, 0];
                        }
                        else
                        {
                            canny_out.Data[i, j, 0] = 0;
                        }
                    }
                }
                imageBox2.Image = canny_out;
                cnt = 0;
            }
            imageBox1.Image = frame;
            //imageBox2.Image = frame.Canny(50, th);
            cannybox.Text = Convert.ToString(th);
        }

        private void canny_th_up_Click(object sender, EventArgs e)
        {
            th++;
        }

        private void canny_th_down_Click(object sender, EventArgs e)
        {
            th--;
        }
    }
}
