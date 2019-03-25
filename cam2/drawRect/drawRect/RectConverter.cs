using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace drawRect
{
    public class RectConverter
    {
        static public float xstep_20x = 0.32F;
        static public float ystep_20x = 0.23F;

        static public Rectangle rect1st = new Rectangle(77, 77, 247, 500);
        static public Rectangle rect2nd = new Rectangle(477, 77, 247, 500);
        static public Rectangle rect3rd = new Rectangle(877, 77, 247, 500);
        static public Rectangle rect4th = new Rectangle(1277, 77, 247, 500);

        static public Rectangle rect1stROI = new Rectangle(77, 227, 247, 250);
        static public Rectangle rect2ndROI = new Rectangle(477, 227, 247, 250);
        static public Rectangle rect3rdROI = new Rectangle(877, 227, 247, 250);
        static public Rectangle rect4thROI = new Rectangle(1277, 227, 247, 250);


        /* 原始数据
        public PointF lu1 = new PointF(121.689F, 73.5981F);
        public PointF ld1 = new PointF(121.66F, 27.1874F);
        public PointF rd1 = new PointF(96.5164F, 27.236F);
        public PointF ru1 = new PointF(96.3882F, 76.8784F);

        public PointF lu2 = new PointF(93.3491F, 74.125F);
        public PointF ld2 = new PointF(93.3599F, 27.1964F);
        public PointF rd2 = new PointF(68.2347F, 27.252F);
        public PointF ru2 = new PointF(68.0632F, 75.0527F);
        */

        // 修正数据
        static public PointF lu1 = new PointF(121.675F, 74.9136F);
        static public PointF ld1 = new PointF(121.675F, 27.218F);
        static public PointF rd1 = new PointF(96.4523F, 27.218F);
        static public PointF ru1 = new PointF(96.4523F, 74.9136F);

        static public PointF lu2 = new PointF(93.3545F, 74.9136F);
        static public PointF ld2 = new PointF(93.3545F, 27.218F);
        static public PointF rd2 = new PointF(68.1489F, 27.218F);
        static public PointF ru2 = new PointF(68.1489F, 74.9136F);

        static public PointF lu3 = new PointF(65.034F, 74.9136F);
        static public PointF ld3 = new PointF(65.034F, 27.218F);
        static public PointF rd3 = new PointF(39.8455F, 27.218F);
        static public PointF ru3 = new PointF(39.8455F, 74.9136F);

        static public PointF lu4 = new PointF(36.7135F, 74.9136F);
        static public PointF ld4 = new PointF(36.7135F, 27.218F);
        static public PointF rd4 = new PointF(11.5421F, 27.218F);
        static public PointF ru4 = new PointF(11.5421F, 74.9136F);

        static public RectangleF frect1st = new RectangleF(rd1, new SizeF(Math.Abs(ru1.X - lu1.X), Math.Abs(rd1.Y - ru1.Y)));
        static public RectangleF frect2nd = new RectangleF(rd2, new SizeF(Math.Abs(ru2.X - lu2.X), Math.Abs(rd2.Y - ru2.Y)));
        static public RectangleF frect3rd = new RectangleF(rd3, new SizeF(Math.Abs(ru3.X - lu3.X), Math.Abs(rd3.Y - ru3.Y)));
        static public RectangleF frect4th = new RectangleF(rd4, new SizeF(Math.Abs(ru4.X - lu4.X), Math.Abs(rd4.Y - ru4.Y)));

        static public RectangleF[] frects = new RectangleF[4] {
            frect1st, frect2nd, frect3rd, frect4th
        };

        static public Rectangle[] rects = new Rectangle[4] {
            rect1st, rect2nd, rect3rd, rect4th
        };

        public static RectangleF ConvertFromDrawRect(Rectangle rectangle, int idx)
        {
            float xratio = (float)(Math.Abs(rectangle.X - rects[idx].X)) / (float)rects[idx].Width;
            float yratio = (float)(Math.Abs(rectangle.Y - rects[idx].Y)) / (float)rects[idx].Height;
            float wratio = (float)rectangle.Width / (float)rects[idx].Width;
            float hratio = (float)rectangle.Height / (float)rects[idx].Height;

            float x, y, w, h;
            x = frects[idx].X + frects[idx].Width *(1.0F- xratio);
            y = frects[idx].Y + frects[idx].Height * yratio;
            w = frects[idx].Width * wratio;
            h = frects[idx].Height * hratio;
            
            return new RectangleF(x, y, w, h);
        }

        public static Rectangle ConvertToDrawRect(RectangleF frectangle, int idx)
        {
            Rectangle retRect = rects[idx];

            float xratio = (Math.Abs(frectangle.X + frects[idx].Width - frects[idx].X)) / frects[idx].Width;
            float yratio = (Math.Abs(frectangle.Y - frects[idx].Y)) / frects[idx].Height;
            float wratio = frectangle.Width / frects[idx].Width;
            float hratio = frectangle.Height / frects[idx].Height;

            retRect.X = Convert.ToInt32(rects[idx].X - rects[idx].Width * xratio);
            retRect.Y = Convert.ToInt32(rects[idx].Y + rects[idx].Height * yratio);
            retRect.Width = Convert.ToInt32(rects[idx].Width * wratio);
            retRect.Height = Convert.ToInt32(rects[idx].Height * hratio);

            return retRect;
        }

        public static Size GetStepsByRectangleF(RectangleF frectangle)
        {
            Size size = new Size();
            size.Width = Convert.ToInt32(frectangle.Width / xstep_20x);
            size.Height = Convert.ToInt32(frectangle.Height / ystep_20x);
            return size;
        }


        public static PointF[] GetAllPointsByRectangleF(RectangleF frectangle)
        {
            Size size = GetStepsByRectangleF(frectangle);
            PointF[] points = new PointF[size.Width * size.Height];
            PointF stP = new PointF(frectangle.X, frectangle.Y);
            Int32 xstep = 1;
            Int32 x = 0;
            Int32 ptr = 0;

            foreach (Int32 y in Enumerable.Range(0, size.Height))
            {

                if (y % 2 == 1)
                {
                    x = 0; xstep = 1;
                }
                else
                {
                    x = size.Width - 1; xstep = -1;
                }
                foreach (Int32 u in Enumerable.Range(0, size.Width))
                {
                    PointF pt = new PointF(stP.X - x * xstep_20x, stP.Y + y * ystep_20x);
                    points[ptr] = pt;
                    ptr++;
                    x = x + xstep;
                }
            }
            return points;
        }

        public static Point ConvertPointFToPoint(Rectangle rect, RectangleF frect, PointF pt)
        {
            Point ipt = new Point();
            ipt.X = Convert.ToInt32(rect.X + rect.Width * ((frect.X - pt.X) / frect.Width));
            ipt.Y = Convert.ToInt32(rect.Y + rect.Height * ((frect.Y - pt.Y) / frect.Height));
            return ipt;

        }

        public class TaskDesc
        {
            public string filedir;
            public Rectangle rect;
            public RectangleF rectf;
            public PointF[] pts;
            public Size size;
            public DateTime dt;


            public TaskDesc(string filedir, Rectangle rect, RectangleF rectf, PointF[] pts, Size size)
            {
                this.filedir = filedir;
                this.rect = rect;
                this.rectf = rectf;
                this.pts = pts;
                this.size = size;
                this.dt = DateTime.Now;
            }
        }

        public static string GenerateTaskDesc(string filedir, string filename, Rectangle rect, RectangleF rectf, PointF[] pts, Size size)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string taskdesc = Path.Combine(filedir, filename + ".dsc");
            using (StreamWriter sw = new StreamWriter(taskdesc))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, new TaskDesc(taskdesc, rect, rectf, pts, size));
                }
            }
            return filedir;
        }


        public static TaskDesc RestoreTaskDesc(string taskdesc)
        {
            TaskDesc tdsc;

            using (StreamReader sw = new StreamReader(taskdesc))
            {
                tdsc = JsonConvert.DeserializeObject<TaskDesc>(sw.ReadToEnd());
            }

            return tdsc;
        }


    }

}
