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
        public static double[] ConnectorStart(Point cek, Line line)
        {
            double[] X = {0, 0};

            if (GetDistance(cek.X, cek.Y, line.X1, line.Y1) < GetDistance(cek.X, cek.Y, line.X2, line.Y2))
            {
                X[0] = line.X1;
                X[1] = line.Y1;
            }
            else
            {
                X[0] = line.X2;
                X[1] = line.Y2;
            }

            return X;
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            double dist = 0;
            dist = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return dist;
        }
    }
}
