using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

/*
 {X=77,Y=77,Width=246,Height=745}
{X=477,Y=76,Width=248,Height=746}
{X=877,Y=77,Width=247,Height=746}
{X=1277,Y=77,Width=247,Height=744}
 * 
 */
namespace drawRect
{
    public partial class Form1 : Form
    {


        public Rectangle[] rectsROI = new Rectangle[4];
        public Rectangle[] rects = RectConverter.rects;
        int idxRect = 4;
        Point stPoint;
        bool blnDraw;
        bool isStartPointValid;

        Rectangle rect;
        Rectangle rrect;
        public Form1()
        {
            InitializeComponent();
            rectsROI[0] = RectConverter.rect1stROI;
            rectsROI[1] = RectConverter.rect2ndROI;
            rectsROI[2] = RectConverter.rect3rdROI;
            rectsROI[3] = RectConverter.rect4thROI;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            isStartPointValid = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (blnDraw)
            {
                if (rect != null && rect.Width > 0 && rect.Height > 0)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 3), rect);//重新绘制颜色为红色
                }

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (isStartPointValid)
            {
                rectsROI[idxRect] = rect;

                blnDraw = false;

                using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
                {
                    foreach (Rectangle _rect in rectsROI)
                    {
                        g.DrawRectangle(new Pen(Color.Red, 4), _rect);
                    }
                }

                RectangleF rectf = RectConverter.ConvertFromDrawRect(rect, idxRect);
                //Rectangle retRect = RectConverter.ConvertToDrawRect(rectf, idxRect);

                Size size = RectConverter.GetStepsByRectangleF(rectf);
                PointF[] points = RectConverter.GetAllPointsByRectangleF(rectf);

                Console.WriteLine(points[3].ToString());

                if (RectConverter.frects[idxRect].Contains(points[3]))
                {
                    Console.WriteLine("在里面");
                }
                else
                {
                    Console.WriteLine("不在里面");
                }


                //using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
                //{
                //    foreach(PointF pt in points)
                //    {
                //        Point ipt = RectConverter.ConvertPointFToPoint(rects[idxRect], rectf, pt);
                //        SolidBrush brush = new SolidBrush(Color.Blue);
                //        Rectangle trect = new Rectangle(ipt, new Size(2, 2));
                //        g.FillRectangle(brush, trect);
                //    }
                //}

                string retfile = RectConverter.GenerateTaskDesc(@".\", "task", rect, rectf, points, size);

            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw && isStartPointValid)
            {
                if (e.Button != MouseButtons.Left)//判断是否按下左键
                    return;
                Point tempEndPoint = e.Location; //记录框的位置和大小


                Point validEndPoint = e.Location; // 当前合法的结束坐标点

                if (rects[idxRect].Contains(tempEndPoint))
                {
                    validEndPoint = tempEndPoint;
                }
                else
                {
                    int up = rects[idxRect].Y;
                    int left = rects[idxRect].X;
                    int right = left + rects[idxRect].Width;
                    int down = up + rects[idxRect].Height;

                    if (tempEndPoint.X <= left)
                    {
                        validEndPoint.X = left;
                    }
                    else if (tempEndPoint.X >= right)
                    {
                        validEndPoint.X = right;
                    }

                    if (tempEndPoint.Y <= up)
                    {
                        validEndPoint.Y = up;
                    }
                    else if (tempEndPoint.Y >= down)
                    {
                        validEndPoint.Y = down;
                    }
                }


                rect.Location = new Point(
                Math.Min(stPoint.X, validEndPoint.X),
                Math.Min(stPoint.Y, validEndPoint.Y));
                rect.Size = new Size(
                Math.Abs(stPoint.X - validEndPoint.X),
                Math.Abs(stPoint.Y - validEndPoint.Y));
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stPoint = e.Location;
            Invalidate();
            blnDraw = true;


            isStartPointValid = true;

            if (RectConverter.rect1st.Contains(e.Location))
            {
                Console.WriteLine("attack 1 rect.");
                idxRect = 0;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect2nd.Contains(e.Location))
            {
                Console.WriteLine("attack 2 rect.");
                idxRect = 1;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect3rd.Contains(e.Location))
            {
                Console.WriteLine("attack 3 rect.");
                idxRect = 2;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect4th.Contains(e.Location))
            {
                Console.WriteLine("attack 4 rect.");
                idxRect = 3;
                rrect = rects[idxRect];
            }
            else
            {
                Console.WriteLine("attack null rect.");
                blnDraw = false;
                isStartPointValid = false;
            }

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
            using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
            {
                foreach (Rectangle _rect in rectsROI)
                {
                    g.DrawRectangle(new Pen(Color.Red, 4), _rect);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sfd = new FolderBrowserDialog();
            sfd.SelectedPath = tLocation.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tLocation.Text = sfd.SelectedPath;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DrawRect drawrectform = new DrawRect(tLocation.Text, tName.Text);
            drawrectform.ShowDialog();



            Console.WriteLine(drawrectform.Temp);
            for (int i = 0; i < 4; i++)
            {
                if (drawrectform.broi[i]) Console.WriteLine(drawrectform.setnames[i]);
            }

            var tf = new TaskFactory();
            Thread th = new Thread(TickTick);
            th.Start();
            var t1 = new Task<string>(firstTask, "task");
            t1.Start();
            Console.WriteLine(t1.Result);
            var t2 = CreateTask("name");
            t2.Start();

            Console.WriteLine(t2.Result);
        }

        public void TickTick()
        {
            int time = 10;
            for (int i = time; i > 0; i--)
            {
                Thread.Sleep(1000);
                Console.WriteLine("This is " + DateTime.Now.ToLocalTime());
            }
        }

        public string firstTask(Object obj)
        {
            Console.WriteLine("first");
            string a = obj as string;
            Thread.Sleep(5000);
            Console.WriteLine("Input para = " + a);

            return "A";
        }


        private int secondTask(string name)
        {
            Console.WriteLine("second");

            Thread.Sleep(2000);
            Console.WriteLine("Input para : " + name);
            return 42;
        }

        private Task<int> CreateTask(string name)
        {
            return new Task<int>(() => secondTask(name));
        }

    }
}