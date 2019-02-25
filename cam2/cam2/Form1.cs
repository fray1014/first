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
        private Image<Gray, Byte>[] canny_frame = new Image<Gray,Byte>[3];
        private Image<Gray, Byte> canny_out ;
        static int cnt = 0;//消抖计数器
        static int th1 = 5;//canny第一阈值初始化
        static int th2 = 70;//canny第二阈值初始化
        private List<MCvBox2D> regions=new List<MCvBox2D>();//染色区域，regions[0]为玻片位置
        public Form1()
        {
            InitializeComponent();
            Run();
        }
        void Run()
        {
            try
            {
                _cameraCapture = new Capture(0);//参数0为默认摄像头，后续为外接摄像头
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
            stable_frame();           
            imageBox1.Image = frame;           
            cannybox1.Text = Convert.ToString(th1);
            cannybox2.Text = Convert.ToString(th2);
        }
        /*动态消抖*/
        void stable_frame()
        {
            if (cnt < 2)
            {
                canny_frame[cnt] = _cameraCapture.QueryFrame().Canny(th1, th2);
                cnt++;
            }
            else
            {
                int[,] eq_flag = new int[imageBox1.Height, imageBox1.Width];
                canny_frame[cnt] = _cameraCapture.QueryFrame().Canny(th1, th2);
                for (int i = 0; i < imageBox1.Height; i++)
                {
                    for (int j = 0; j < imageBox1.Width; j++)
                    {
                        if (canny_frame[0].Data[i, j, 0] == canny_frame[1].Data[i, j, 0] ||
                            canny_frame[0].Data[i, j, 0] == canny_frame[2].Data[i, j, 0])
                        {
                            eq_flag[i, j] = 0;
                        }
                        else if (canny_frame[1].Data[i, j, 0] == canny_frame[2].Data[i, j, 0])
                        {
                            eq_flag[i, j] = 1;
                        }
                        else
                        {
                            eq_flag[i, j] = 2;
                        }
                        switch (eq_flag[i, j])
                        {
                            case 0:
                                canny_out.Data[i, j, 0] = canny_frame[0].Data[i, j, 0];
                                break;
                            case 1:
                                canny_out.Data[i, j, 0] = canny_frame[1].Data[i, j, 0];
                                break;
                            default:
                                canny_out.Data[i, j, 0] = 0;
                                break;
                        }
                    }
                }
                imageBox2.Image = canny_out;
                microscope_detect();
                cnt = 0;
            }
        }
        /*玻片检测*/
        void microscope_detect()
        {
            LineSegment2D[] lines = canny_out.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel
            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                for (
                   Contour<Point> contours = canny_out.FindContours(
                      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                      storage);
                   contours != null;
                   contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                    if (currentContour.Area > 50) //only consider contours with area greater than 250
                    {                       
                        if (currentContour.Total == 4) //The contour has 4 vertices.
                        {
                            #region determine if all the angles in the contour are within [80, 100] degree
                            bool isRectangle = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 60 || angle > 120)
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }
                            #endregion

                            if (isRectangle) regions.Add(currentContour.GetMinAreaRect());
                        }
                    }
                }
            Image<Bgr, Byte> RectangleImage = frame.CopyBlank();
            foreach (MCvBox2D box in regions)
                RectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
            imageBox3.Image = RectangleImage;
        }
        private void canny_th_up_Click(object sender, EventArgs e)
        {
            th1+=5;
        }

        private void canny_th_down_Click(object sender, EventArgs e)
        {
            th1-=5;
        }

        private void canny_th_up2_Click(object sender, EventArgs e)
        {
            th2+=5;
        }

        private void canny_th_down2_Click(object sender, EventArgs e)
        {
            th2-=5;
        }
    }
}
