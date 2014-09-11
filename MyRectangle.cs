using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace WPF_DCupNote
{
    public class MyRectangle
    {
        public string _IDRectangle;
        public Rectangle _TheRectangle;
        public Point _StartLocR;
        public Point _CenterLocR;
        public Line _TheConnector;
        public TagNoteBuffer _TNB;

        public MyRectangle(Point start, double thickness, Brush color)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("CounterID.xml");
            XmlNode node = doc.SelectSingleNode("/Counter/RectangleID");
            if (node != null)
            {
                int result = Convert.ToInt32(node.InnerText);
                _IDRectangle = "R" + (result++).ToString();
                node.InnerText = result.ToString();
            }
            doc.Save("CounterID.xml");
            doc = null;

            _TheRectangle = new Rectangle();
            _TheRectangle.StrokeThickness = thickness;
            _TheRectangle.Stroke = color;

            _StartLocR = start;
        }

        public void DrawConnector()
        {
            _TheConnector = new Line();

            _TheConnector.X2 = _TNB.TagPoint.X;
            _TheConnector.Y2 = _TNB.TagPoint.Y;
            _TheConnector.X1 = _CenterLocR.X + (_TheRectangle.Width / 2);
            _TheConnector.Y1 = _CenterLocR.Y - (_TheRectangle.Height / 2);
            _TheConnector.StrokeThickness = 1.0;
            _TheConnector.Stroke = _TheRectangle.Stroke;

            Canvas.SetZIndex(_TheConnector, 1);
        }
    }
}

