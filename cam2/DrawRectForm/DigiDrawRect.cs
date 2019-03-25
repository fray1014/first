using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DatabaseAccess;
using FullSlideScanHelper;
using TangoDriver;

namespace SpectrumToolset.DrawRectForm
{
    public partial class DigiDrawRect : Form
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
        public Int32 rectFRoiTotalPoints;
        public bool[] broi = new bool[4] { false, false, false, false };


        int idxRect = 4;
        bool blnDraw;
        bool isStartPointValid;
        bool isSetName = false;
        bool[] isimporttask = new bool[4] { false, false, false, false };
        FullSlideScanHelper.RectConverter.TaskDesc[] tdscs = new FullSlideScanHelper.RectConverter.TaskDesc[4];
        string[] tdscs_storepath = new string[4];

        Point stPoint;
        Rectangle rect;
        Rectangle rrect;
        ColorConfig colorconfig;

        PointF tp_lu;
        PointF tp_ru;
        PointF tp_ld;
        PointF tp_rd;

        string GeneralPath;
        string GeneralName;


        int amp;
        float x_step = 0.0F;
        float y_step = 0.0F;

        public bool is_amp_ok = false;

        Form thisForm;

        public string Temp
        {
            get;
            set;
        }

        public DigiDrawRect()
        {
            InitializeComponent();
            thisForm = this;
        }

        public DigiDrawRect(ColorConfig _colorconfig)
        {
            InitializeComponent();
            thisForm = this;

            rectFRoiTotalPoints = 0;
            this.colorconfig = _colorconfig;

            rectsBLK[0] = rect1stBLK;
            rectsROI[0] = RectConverter.rect1stROI;
            rectsBLK[1] = rect2ndBLK;
            rectsROI[1] = RectConverter.rect2ndROI;
            rectsBLK[2] = rect3rdBLK;
            rectsROI[2] = RectConverter.rect3rdROI;
            rectsBLK[3] = rect4thBLK;
            rectsROI[3] = RectConverter.rect4thROI;

            for (int i = 0; i < 4; i++)
            {
                setnames[i] = _colorconfig.name + "-" + i.ToString();
            }

            for (int i = 0; i < RectConverter.eyepieces.Length; ++i)
            {
                if (RectConverter.eyepieces[i] == colorconfig.amp)
                {
                    amp = i;
                    break;
                }
            }

            if (amp == 1)
            {
                x_step = RectConverter.xstep_20x;
                y_step = RectConverter.ystep_20x;
            }
            else if (amp == 2)
            {
                x_step = RectConverter.xstep_40x;
                y_step = RectConverter.ystep_40x;
            }

            if (x_step == 0.0F || y_step == 0.0F)
            {
                is_amp_ok = false;
                MessageBox.Show("扫描目前仅支持20x或40x的放大倍数，请重新选择。");
            }
            else
            {
                is_amp_ok = true;
            }

            InfoPanelUtil.MyConsoleWrite(ref thisForm, "hello");

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


                RectangleF debugrectf = RectConverter.ConvertFromDrawRect(rect, idxRect);
                SizeF sizef = debugrectf.Size;
                tp_lu = debugrectf.Location;
                tp_ru = new PointF(debugrectf.Left - sizef.Width, debugrectf.Top);
                tp_ld = new PointF(debugrectf.Left, debugrectf.Top - sizef.Height);
                tp_rd = new PointF(debugrectf.Left - sizef.Width, debugrectf.Top - sizef.Height);

                label6.Text = tp_lu.ToString();
                label7.Text = tp_ru.ToString();
                label8.Text = tp_ld.ToString();
                label9.Text = tp_rd.ToString();
                int x_total_steps = (int)((tp_ld.X - tp_rd.X) / x_step);
                int y_total_steps = (int)((tp_ld.Y - tp_lu.Y) / y_step);
                label10.Text = "size: (" + Math.Abs(x_total_steps+1).ToString() + ", " + Math.Abs(y_total_steps+1).ToString() + ")";


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

                InfoPanelUtil.MyConsoleWrite(ref thisForm, "Done");
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
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "attack 1 rect.");
                idxRect = 0;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect2nd.Contains(e.Location))
            {
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "attack 2 rect.");
                idxRect = 1;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect3rd.Contains(e.Location))
            {
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "attack 3 rect.");
                idxRect = 2;
                rrect = rects[idxRect];
            }

            else if (RectConverter.rect4th.Contains(e.Location))
            {
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "attack 4 rect.");
                idxRect = 3;
                rrect = rects[idxRect];
            }
            else
            {
                InfoPanelUtil.MyConsoleWrite(ref thisForm, "attack null rect.");
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
                rectFRoiTotalPoints = 0;
                if (MessageBox.Show(generateConfirmMessage(), "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                }
                else
                {
                    RectangleF rectFRoiRecord;
                    Rectangle rectRoiRecord;
                    PointF[] rectFRoiPoints;
                    Size rectRoiSize;

                    RectangleF rectFBlkRecord;
                    Rectangle rectBlkRecord;
                    PointF[] rectFBlkPoints;
                    Size rectBlkSize;


                    for (int i = 0; i < 4; i++)
                    {
                        if (broi[i])
                        {
                            //if (isimporttask[i])
                            //{
                            //    rectFRoiTotalPoints += tdscs[i].rectRoiSize.Width * tdscs[i].rectRoiSize.Height;
                            //    rectFRoiTotalPoints += tdscs[i].rectBlkPts.Length;

                            //    rectRoiRecord = rectsROI[i];
                            //    rectFRoiRecord = RectConverter.ConvertFromDrawRect(rectsROI[i], i);
                            //    rectFRoiPoints = RectConverter.GetAllPointsByRectangleF(rectFRoiRecord, amp);
                            //    rectRoiSize = RectConverter.GetStepsByRectangleF(rectFRoiRecord, amp);
                            //    rectFRoiTotalPoints += rectRoiSize.Width * rectRoiSize.Height;

                            //    rectBlkRecord = rectsBLK[i];
                            //    rectFBlkRecord = RectConverter.ConvertFromDrawRect(rectsBLK[i], i);
                            //    // Cal two Points.
                            //    rectFBlkPoints = new PointF[2];
                            //    rectFBlkPoints[0] = new PointF(rectFBlkRecord.Left - rectFBlkRecord.Width / 3, rectFBlkRecord.Top + rectFBlkRecord.Height / 2);
                            //    rectFBlkPoints[1] = new PointF(rectFBlkRecord.Left - rectFBlkRecord.Width * 2 / 3, rectFBlkRecord.Top + rectFBlkRecord.Height / 2);
                            //    rectBlkSize = RectConverter.GetStepsByRectangleF(rectFBlkRecord, amp);
                            //    rectFRoiTotalPoints += rectFBlkPoints.Length;

                            //    Temp = RectConverter.GenerateTaskDesc(colorconfig.location, setnames[i],
                            //        rectRoiRecord, rectFRoiRecord, rectFRoiPoints, rectRoiSize,
                            //        rectBlkRecord, rectFBlkRecord, rectFBlkPoints, rectBlkSize,
                            //        i);

                            //}
                            //else
                            //{
                            rectRoiRecord = rectsROI[i];
                            rectFRoiRecord = RectConverter.ConvertFromDrawRect(rectsROI[i], i);
                            rectFRoiPoints = RectConverter.GetAllPointsByRectangleF(rectFRoiRecord, amp);
                            rectRoiSize = RectConverter.GetStepsByRectangleF(rectFRoiRecord, amp);
                            rectFRoiTotalPoints += rectRoiSize.Width * rectRoiSize.Height;

                            rectBlkRecord = rectsBLK[i];
                            rectFBlkRecord = RectConverter.ConvertFromDrawRect(rectsBLK[i], i);
                            // Cal two Points.
                            rectFBlkPoints = new PointF[2];
                            rectFBlkPoints[0] = new PointF(rectFBlkRecord.Left - rectFBlkRecord.Width / 3, rectFBlkRecord.Top + rectFBlkRecord.Height / 2);
                            rectFBlkPoints[1] = new PointF(rectFBlkRecord.Left - rectFBlkRecord.Width * 2 / 3, rectFBlkRecord.Top + rectFBlkRecord.Height / 2);
                            rectBlkSize = RectConverter.GetStepsByRectangleF(rectFBlkRecord, amp);
                            rectFRoiTotalPoints += rectFBlkPoints.Length;

                            Temp = RectConverter.GenerateTaskDesc(colorconfig.location, setnames[i],
                                rectRoiRecord, rectFRoiRecord, rectFRoiPoints, rectRoiSize,
                                rectBlkRecord, rectFBlkRecord, rectFBlkPoints, rectBlkSize,
                                i);
                            //}
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



        private void btnSetName_Click(object sender, EventArgs e)
        {

            DrawRectSetName setNameForm = new DrawRectSetName(colorconfig.location, colorconfig.name, broi, setnames);
            setNameForm.StartPosition = FormStartPosition.CenterParent;

            setNameForm.ShowDialog();
            this.setnames = setNameForm.setnames;


            RefreshPictureBox();

            isSetName = true;
        }

        private void btnImportTask_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = colorconfig.location;
            ofd.Filter = "dsc任务描述文件|*.dsc|所有文件|*.*";
            ofd.Multiselect = true;
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            // clear status 
            broi[0] = broi[1] = broi[2] = broi[3] = false;
            isimporttask[0] = isimporttask[1] = isimporttask[2] = isimporttask[3] = false;
            tdscs[0] = tdscs[1] = tdscs[2] = tdscs[3] = null;
            tdscs_storepath[0] =
                tdscs_storepath[1] =
                tdscs_storepath[2] =
                tdscs_storepath[3] = @"";
            GC.Collect();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Refresh();
                foreach (var filename in ofd.FileNames)
                {
                    FullSlideScanHelper.RectConverter.TaskDesc tdsc = RectConverter.RestoreTaskDesc(filename);
                    tdscs[tdsc.slideid] = tdsc;

                    tdscs_storepath[tdsc.slideid] = filename;
                    broi[tdsc.slideid] = true;
                    //setnames[tdsc.slideid] = Path.GetFileNameWithoutExtension(filename);

                    rectsROI[tdsc.slideid] = tdsc.rectRoi;
                    rectsBLK[tdsc.slideid] = tdsc.rectBlk;

                    isimporttask[tdsc.slideid] = true;
                    RefreshUI();

                    rect = rectsROI[tdsc.slideid];
                    idxRect = tdsc.slideid;

                    RectangleF debugrectf = tdsc.rectRoiF;
                    SizeF sizef = debugrectf.Size;
                    tp_lu = debugrectf.Location;
                    tp_ru = new PointF(debugrectf.Left - sizef.Width, debugrectf.Top);
                    tp_ld = new PointF(debugrectf.Left, debugrectf.Top - sizef.Height);
                    tp_rd = new PointF(debugrectf.Left - sizef.Width, debugrectf.Top - sizef.Height);

                    label6.Text = tp_lu.ToString();
                    label7.Text = tp_ru.ToString();
                    label8.Text = tp_ld.ToString();
                    label9.Text = tp_rd.ToString();
                    int x_total_steps = (int)((tp_ld.X - tp_rd.X) / x_step);
                    int y_total_steps = (int)((tp_ld.Y - tp_lu.Y) / y_step);
                    label10.Text = "size: (" + Math.Abs(x_total_steps).ToString() + ", " + Math.Abs(y_total_steps).ToString() + ")";
                }
            }
        }

        private void RefreshUI()
        {

            for (int i = 0; i < 4; i++)
            {
                SlideChose.SetItemChecked(i, broi[i]);
            }

            RefreshPictureBox();
        }

        private void RefreshPictureBox()
        {
            Refresh();
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

        private void btntestmove_Click(object sender, EventArgs e)
        {

            RectangleF testmoveRF = RectConverter.ConvertFromDrawRect(rect, idxRect);
            PointF testmovePt = RectConverter.GetAllPointsByRectangleF(testmoveRF, amp)[0];
            double testmovezp = TangoController.TangoGetZPos();

            TangoController.TangoMoveAbs(1, testmovePt.X, testmovePt.Y, testmovezp, 0, true);
        }

        private void btnDrawBLK_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
            rectSel = 2;

            RefreshPictureBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double testmovezp = TangoController.TangoGetZPos();
            TangoController.TangoMoveAbs(1, tp_lu.X, tp_lu.Y, testmovezp, 0, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double testmovezp = TangoController.TangoGetZPos();
            TangoController.TangoMoveAbs(1, tp_ru.X, tp_ru.Y, testmovezp, 0, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double testmovezp = TangoController.TangoGetZPos();
            TangoController.TangoMoveAbs(1, tp_ld.X, tp_ld.Y, testmovezp, 0, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double testmovezp = TangoController.TangoGetZPos();
            TangoController.TangoMoveAbs(1, tp_rd.X, tp_rd.Y, testmovezp, 0, true);

        }

        private void DigiDrawRect_Load(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            isStartPointValid = false;
        }

        private void SlideChose_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            broi[e.Index] = (e.NewValue == CheckState.Checked);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

    }
}
