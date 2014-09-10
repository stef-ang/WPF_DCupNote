using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Xceed.Wpf.Toolkit;
using System.Windows.Input;

namespace WPF_DCupNote
{
    class MyLine
    {
        public string _IDLine;
        public Line _TheLine;
        public Line _TheConnector;
        public TagNoteBuffer _TNB;

        public MyLine(Point start, Point end, double thickness, Brush color)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("CounterID.xml");
                XmlNode node = doc.SelectSingleNode("/Counter/LineID");
                if (node != null)
                {
                    int result = Convert.ToInt32(node.InnerText);
                    _IDLine = "L" + (result++).ToString();
                    node.InnerText = result.ToString();
                }
                doc.Save("CounterID.xml");
                doc = null;
                //XDocument xdoc = XDocument.Load("CounterID.xml");
                //XElement element = xdoc.Elements("LineID").Single();
                //int result = Convert.ToInt32(element.Value);
                //IDLine = "L" + (result++).ToString();
                //element.Value = result.ToString();
                //xdoc.Save("CounterID.xml");
                _TheLine = new Line();
                _TheLine.X1 = start.X;
                _TheLine.Y1 = start.Y;
                _TheLine.X2 = end.X;
                _TheLine.Y2 = end.Y;
                _TheLine.StrokeThickness = thickness;
                _TheLine.Stroke = color;
            }
            catch (Exception x)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(x.Message);
            }
        }

        public void DrawConnector()
        {
            _TheConnector = new Line();

            Point cek = new Point();
            //cek.X = Canvas.GetLeft(_TNB.TagPanel);
            //cek.Y = Canvas.GetTop(_TNB.TagPanel);
            cek.X = _TNB.TagPoint.X;
            cek.Y = _TNB.TagPoint.Y;

            _TheConnector.X2 = cek.X;
            _TheConnector.Y2 = cek.Y;
            _TheConnector.X1 = staticClass.ConnectorStart(cek, _TheLine)[0];
            _TheConnector.Y1 = staticClass.ConnectorStart(cek, _TheLine)[1];
            _TheConnector.StrokeThickness = 1.0;
            _TheConnector.Stroke = _TheLine.Stroke;
        }

        
    }
}

