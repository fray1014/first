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
using Emgu.CV.CvEnum;
using Emgu.Util;
using Newtonsoft.Json;
using System.IO;

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
        private int size_of_slide = 60*200;//玻片检测大小初始化
        private int size_of_roi = 6000;//染色区域大小初始化
        private MCvBox2D tempbox = new MCvBox2D();//用于标注玻片位置
        private Rectangle roi = new Rectangle();//染色区域
        private Rectangle slide = new Rectangle();//玻片
        private Image<Bgr, Byte> slide_img;
        private Image<Gray, Byte> slide_gray_img;
        private static bool is_slide = false;//玻片检测标志
        public Form1()
        {
            InitializeComponent();
            Run();
        }
        //Backgroundworker多线程
        //System.thread多线程
        //visual assistant X查看代码工具
        void Run()
        {
            try
            {
                _cameraCapture = new Capture(1);//参数0为默认摄像头，后续为外接摄像头
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
            Stable_Frame();
            imageBox1.Image = frame;           
            cannybox1.Text = Convert.ToString(th1);
            cannybox2.Text = Convert.ToString(th2);
        }
        /*动态消抖*/
        void Stable_Frame()//传参Image<Gray, Byte> image
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
                canny_out._Dilate(1);//形态学滤波：膨胀（3*3矩形结构元素），参数为迭代次数
                Slide_Detection();
                Region_Detection();
                cnt = 0;
            }
        }
        /*玻片检测*/
        void Slide_Detection()
        {
            Rectangle_Detection();
            if(is_slide)
            {
                slide = tempbox.MinAreaRect();//外接面积最小矩形
                slide_img = frame.GetSubRect(slide);
                slide_gray_img = canny_out.GetSubRect(slide);
                imageBox4.Image = slide_img;
                is_slide = false;
            }
            else
                Slide_Detection();
        }
        /*矩形检测*/
        void Rectangle_Detection()
        {
            using (MemStorage storage = new MemStorage()) //allocate storage for contour(轮廓) approximation
                for (
                   Contour<Point> contours = canny_out.FindContours(
                      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                      storage);
                   contours != null;
                   contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);//逼近多边形曲线
                    if (currentContour.Area > size_of_slide && is_slide==false) //only consider contours with area greater than 250
                    {
                        if (currentContour.Total == 4) //The contour has 4 vertices(顶点).
                        {
                            #region determine if all the angles in the contour are within [80, 100] degree
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle >= 60 || angle <= 120)
                                {
                                    is_slide = true;
                                    break;
                                }
                            }
                            #endregion
                            if (is_slide)
                            {
                                Slide_Size.Text = Convert.ToString(size_of_slide);
                                tempbox = currentContour.GetMinAreaRect();
                                Image<Bgr, Byte> RectangleImage = frame;
                                RectangleImage.Draw(tempbox, new Bgr(Color.DarkOrange), 2);
                                imageBox3.Image = RectangleImage;
                                break;
                            }
                        }
                    }
                }
        }
        /*ROI检测*/
        void Region_Detection()
        { 
            using (MemStorage storage = new MemStorage()) //allocate storage for contour(轮廓) approximation
                for (
                   Contour<Point> contours = slide_gray_img.FindContours(
                      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                      storage);
                   contours != null;
                   contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);//逼近多边形曲线
                    if (currentContour.Area < size_of_roi) //only consider contours with area greater than 250
                    {
                        tempbox = currentContour.GetMinAreaRect();
                        Image<Bgr, Byte> RectangleImage = slide_img;
                        RectangleImage.Draw(tempbox, new Bgr(Color.Blue), 1);
                        roi = tempbox.MinAreaRect();
                        imageBox4.Image = RectangleImage;
                        break;
                    }
                }
        }

        private void Canny_th_up_Click(object sender, EventArgs e)
        {
            th1+=5;
        }

        private void Canny_th_down_Click(object sender, EventArgs e)
        {
            th1-=5;
        }

        private void Canny_th_up2_Click(object sender, EventArgs e)
        {
            th2+=5;
        }

        private void Canny_th_down2_Click(object sender, EventArgs e)
        {
            th2-=5;
        }

        private void Slide_Size_Up_Click(object sender, EventArgs e)
        {
            size_of_slide += 5;
        }

        private void Slide_Size_Down_Click(object sender, EventArgs e)
        {
            size_of_slide -= 5;
        }

        public class TaskDesc
        {
            public string filedir;
            public DateTime dt;
            public int slideid;

            public Rectangle rectRoi;
            public RectangleF rectRoiF;
            public PointF[] rectRoiPts;
            public Size rectRoiSize;

            public Rectangle rectBlk;
            public RectangleF rectBlkF;
            public PointF[] rectBlkPts;
            public Size rectBlkSize;

            public TaskDesc(string filedir, Rectangle rectRoi, RectangleF rectRoiF, PointF[] rectRoiPts, Size rectRoiSize,
                                            Rectangle rectBlk, RectangleF rectBlkF, PointF[] rectBlkPts, Size rectBlkSize,
                            int slideid)
            {
                this.filedir = filedir;
                this.dt = DateTime.Now;
                this.slideid = slideid;

                this.rectRoi = rectRoi;
                this.rectRoiF = rectRoiF;
                this.rectRoiPts = rectRoiPts;
                this.rectRoiSize = rectRoiSize;

                this.rectBlk = rectBlk;
                this.rectBlkF = rectBlkF;
                this.rectBlkPts = rectBlkPts;
                this.rectBlkSize = rectBlkSize;
            }
        }

        public static string GenerateTaskDesc(string filedir, string filename,
            Rectangle rectRoi, RectangleF rectRoiF, PointF[] rectRoiPts, Size rectRoiSize,
            Rectangle rectBlk, RectangleF rectBlkF, PointF[] rectBlkPts, Size rectBlkSize, int slideid)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string taskdesc = Path.Combine(filedir, filename + ".dsc");
            using (StreamWriter sw = new StreamWriter(taskdesc))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, new TaskDesc(taskdesc,
                        rectRoi, rectRoiF, rectRoiPts, rectRoiSize,
                        rectBlk, rectBlkF, rectBlkPts, rectBlkSize,
                        slideid));
                }
            }
            return filedir;
        }
    }
}
