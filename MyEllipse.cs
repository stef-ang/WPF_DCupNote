﻿using System;
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
    public class MyEllipse
    {
        public string _IDEllipse;
        public Ellipse _TheEllipse;
        public Point _StartLocE;
        public Point _CenterLocE;   // center point
        public Line _TheConnector;
        public TagNoteBuffer _TNB;

        public MyEllipse(Point start, double thickness, Brush color)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("CounterID.xml");
            XmlNode node = doc.SelectSingleNode("/Counter/CircleID");
            if (node != null)
            {
                int result = Convert.ToInt32(node.InnerText);
                _IDEllipse = "E" + (result++).ToString();
                node.InnerText = result.ToString();
            }
            doc.Save("CounterID.xml");
            doc = null;

            _TheEllipse = new Ellipse();
            _TheEllipse.StrokeThickness = thickness;
            _TheEllipse.Stroke = color;

            _StartLocE = start;
        }

        public void DrawConnector()
        {
            _TheConnector = new Line();

            _TheConnector.X2 = _TNB.TagPoint.X;
            _TheConnector.Y2 = _TNB.TagPoint.Y;
            _TheConnector.X1 = _CenterLocE.X + (_TheEllipse.Width / 2);
            _TheConnector.Y1 = _CenterLocE.Y;
            _TheConnector.StrokeThickness = 1.0;
            _TheConnector.Stroke = _TheEllipse.Stroke;

            Canvas.SetZIndex(_TheConnector, 1);
        }
    }
}
