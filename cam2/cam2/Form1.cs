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
        public Form1()
        {
            InitializeComponent();
            Run();
        }
        void Run()
        {
            try
            {
                _cameraCapture = new Capture();
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
            Image<Bgr, Byte> frame = _cameraCapture.QueryFrame();
            frame._SmoothGaussian(3); //filter out noises
            imageBox1.Image = frame;
        }
    }
}
