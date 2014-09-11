using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace WPF_DCupNote
{
    public static class staticClass
    {
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            double dist = 0;
            dist = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return dist;
        }

        // for lines
        public static Point LineConnectorStart(Point cek, Line line)
        {
            Point X = new Point();

            if (GetDistance(cek.X, cek.Y, line.X1, line.Y1) < GetDistance(cek.X, cek.Y, line.X2, line.Y2))
            {
                X.X = line.X1;
                X.Y = line.Y1;
            }
            else
            {
                X.X = line.X2;
                X.Y = line.Y2;
            }

            return X;
        }
        // end for line

        // for ellipse and rectangle
        public static Point EllipseRectangleWidthHeight(Point start, Point end)
        {
            Point res = new Point();

            // widht value
            res.X = Math.Abs(start.X - end.X);
            // height value
            res.Y = Math.Abs(start.Y - end.Y);

            return res;
        }
        
        public static Point EllipseRectangleGetPosition(Point center, double width, double height)
        {
            Point res = new Point();

            // left value
            res.X = center.X - (width / 2);
            // top value
            res.Y = center.Y - (height / 2);

            return res;
        }

        public static Point EllipseRectangleCenterPoint(Point start, Point end)
        {
            Point res = new Point();

            res.X = (start.X + end.X) / 2;
            res.Y = (start.Y + end.Y) / 2;

            return res;
        }
        // end for ellipse and rectangle

        // for ellipse
        public static Point EllipseConnectorStart(Point cek, MyEllipse ellipse)
        {
            Point res = new Point();
            double distance = GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X + (ellipse._TheEllipse.Width / 2), ellipse._CenterLocE.Y);
            res.X = ellipse._CenterLocE.X + (ellipse._TheEllipse.Width / 2);
            res.Y = ellipse._CenterLocE.Y;

            if (distance > GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X, ellipse._CenterLocE.Y + (ellipse._TheEllipse.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X, ellipse._CenterLocE.Y + (ellipse._TheEllipse.Height / 2));
                res.X = ellipse._CenterLocE.X;
                res.Y = ellipse._CenterLocE.Y + (ellipse._TheEllipse.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X - (ellipse._TheEllipse.Width / 2), ellipse._CenterLocE.Y))
            {
                distance = GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X - (ellipse._TheEllipse.Width / 2), ellipse._CenterLocE.Y);
                res.X = ellipse._CenterLocE.X - (ellipse._TheEllipse.Width / 2);
                res.Y = ellipse._CenterLocE.Y;
            }
            if (distance > GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X, ellipse._CenterLocE.Y - (ellipse._TheEllipse.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, ellipse._CenterLocE.X, ellipse._CenterLocE.Y - (ellipse._TheEllipse.Height / 2));
                res.X = ellipse._CenterLocE.X;
                res.Y = ellipse._CenterLocE.Y - (ellipse._TheEllipse.Height / 2);
            }

            return res;
        }
        // end for ellipse

        // for rectangle
        public static Point RectangleConnectorStar(Point cek, MyRectangle rectangle)
        {
            Point res = new Point();
            double distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y);
            res.X = rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2);
            res.Y = rectangle._CenterLocR.Y;

            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2);
                res.Y = rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X, rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X, rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X;
                res.Y = rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2);
                res.Y = rectangle._CenterLocR.Y + (rectangle._TheRectangle.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y);
                res.X = rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2);
                res.Y = rectangle._CenterLocR.Y;
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X - (rectangle._TheRectangle.Width / 2);
                res.Y = rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X, rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X, rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X;
                res.Y = rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2);
            }
            if (distance > GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2)))
            {
                distance = GetDistance(cek.X, cek.Y, rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2), rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2));
                res.X = rectangle._CenterLocR.X + (rectangle._TheRectangle.Width / 2);
                res.Y = rectangle._CenterLocR.Y - (rectangle._TheRectangle.Height / 2);
            }

            return res;
        }
        // end for rectangle
    }
}
