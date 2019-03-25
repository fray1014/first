using System;
using System.Drawing;
using System.Windows.Forms;
/*
 {X=77,Y=77,Width=246,Height=745}
{X=477,Y=76,Width=248,Height=746}
{X=877,Y=77,Width=247,Height=746}
{X=1277,Y=77,Width=247,Height=744}
 * 
 */
namespace drawRect
{
    public partial class DrawRect : Form
    {


        public Rectangle rect1stBLK = new Rectangle(125, 115, 150, 30);
        public Rectangle rect2ndBLK = new Rectangle(525, 115, 150, 30);
        public Rectangle rect3rdBLK = new Rectangle(925, 115, 150, 30);
        public Rectangle rect4thBLK = new Rectangle(1325, 115, 150, 30);
        public Rectangle[] rectsBLK = new Rectangle[4];
        int rectSel = 0;


        public Rectangle[] rectsROI = new Rectangle[4];
        public Rectangle[] rects = RectConverter.rects;
        public string[] setnames = new string[4];
        public bool[] broi = new bool[4] { false, false, false, false };

        int idxRect = 4;
        bool blnDraw;
        bool isStartPointValid;
        bool isSetName = false;

        Point stPoint;
        Rectangle rect;
        Rectangle rrect;

        string filename;
        string filedir;
        public string Temp
        {
            get;
            set;
        }

        /*
        public DrawRect(MonoConfig _monoconfig)
        {
            InitializeComponent();
            this.monoconfig = _monoconfig;
            rectsROI[0] = RectConverter.rect1stROI;
            rectsROI[1] = RectConverter.rect2ndROI;
            rectsROI[2] = RectConverter.rect3rdROI;
            rectsROI[3] = RectConverter.rect4thROI;

        }
         */

        public DrawRect(string _filedir, string _filename)
        {
            InitializeComponent();
            this.filedir = _filedir;
            this.filename = _filename;
            rectsBLK[0] = rect1stBLK;
            rectsROI[0] = RectConverter.rect1stROI;
            rectsBLK[1] = rect2ndBLK;
            rectsROI[1] = RectConverter.rect2ndROI;
            rectsBLK[2] = rect3rdBLK;
            rectsROI[2] = RectConverter.rect3rdROI;
            rectsBLK[3] = rect4thBLK;
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
                Pen pen;
                if (rectSel == 1) pen = new Pen(Color.Red, 4);
                else if (rectSel == 2) pen = new Pen(Color.Blue, 4);
                else pen = new Pen(Color.Red, 4);

                if (rect != null && rect.Width > 0 && rect.Height > 0)
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isStartPointValid)
            {
                blnDraw = false;
                if (rectSel == 1)
                    rectsROI[idxRect] = rect;
                else if (rectSel == 2)
                    rectsBLK[idxRect] = rect;


                using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
                {
                    foreach (Rectangle _rect in rectsROI)
                    {
                        g.DrawRectangle(new Pen(Color.Red, 4), _rect);
                    }

                    foreach (Rectangle _rect in rectsBLK)
                    {
                        g.DrawRectangle(new Pen(Color.Blue, 4), _rect);
                    }
                    
                }

                /*
                RectangleF rectf = RectConverter.ConvertFromDrawRect(rect, idxRect);
                Rectangle retRect = RectConverter.ConvertToDrawRect(rectf, idxRect);
                Size size = RectConverter.GetStepsByRectangleF(rectf);
                PointF[] points = RectConverter.GetAllPointsByRectangleF(rectf);
                
                using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
                {
                    foreach(PointF pt in points)
                    {
                        Point ipt = RectConverter.ConvertPointFToPoint(retRect, rectf, pt);
                        SolidBrush brush = new SolidBrush(Color.Blue);
                        Rectangle trect = new Rectangle(ipt, new Size(2, 2));
                        g.FillRectangle(brush, trect);
                    }
                }
                */



                Console.WriteLine("Done");
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
            rectSel = 1;
            using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
            {
                foreach (Rectangle _rect in rectsROI)
                {
                    g.DrawRectangle(new Pen(Color.Red, 4), _rect);
                }
                foreach (Rectangle _rect in rectsBLK)
                {
                    g.DrawRectangle(new Pen(Color.Blue, 4), _rect);
                }
            }
        }

        private string generateConfirmMessage()
        {
            string retStr = "请确认信息,将扫描如下玻片:\n";
            for (int i = 0; i < 4; i++)
            {
                if (broi[i])
                {
                    retStr += "\t" + (i + 1).ToString() + "#: " + this.setnames[i] + " \n";
                }
            }
            return retStr;
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            if (isSetName)
            {
                if (MessageBox.Show(generateConfirmMessage(), "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                }
                else
                {
                    RectangleF FinalRectF;
                    Rectangle FinalRect;
                    Size FinalSize;
                    PointF[] FinalPoints;

                    for (int i = 0; i < 4; i++)
                    {
                        if (broi[i])
                        {
                            FinalRectF = RectConverter.ConvertFromDrawRect(rectsROI[i], i);
                            FinalRect = rectsROI[i];
                            FinalSize = RectConverter.GetStepsByRectangleF(FinalRectF);
                            FinalPoints = RectConverter.GetAllPointsByRectangleF(FinalRectF);

                            Temp = RectConverter.GenerateTaskDesc(this.filedir, this.filename + "_" + i.ToString(),
                                FinalRect, FinalRectF, FinalPoints, FinalSize);
                        }
                    }

                    this.Close();
                }
            }
            else
            {

                MessageBox.Show("请先设置扫描玻片的名字");
            }
        }

        private void SlideChose_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            broi[e.Index] = (e.NewValue == CheckState.Checked);
        }

        private void btnSetName_Click(object sender, EventArgs e)
        {

            DrawRectSetName setNameForm = new DrawRectSetName(this.filedir, this.filename, broi);
            //Point stp = new Point(this.Location.X + this.Size.Width / 2 - setNameForm.Width/2 , this.Location.Y + this.Size.Height /2 - setNameForm.Height/2);
            setNameForm.StartPosition = FormStartPosition.CenterParent;

            setNameForm.ShowDialog();
            this.setnames = setNameForm.setnames;

            this.Refresh();
            using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
            {
                foreach (Rectangle _rect in rectsROI)
                {
                    g.DrawRectangle(new Pen(Color.Red, 4), _rect);
                }
            }

            isSetName = true;
        }

        private void btnblank_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
            rectSel = 2;
            using (Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle))
            {
                foreach (Rectangle _rect in rectsBLK)
                {
                    g.DrawRectangle(new Pen(Color.Blue, 4), _rect);
                }
            }
        }
    }
}