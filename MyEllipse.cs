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
    class MyEllipse
    {
        public string _IDEllipse;
        public Ellipse _TheEllipse;
        public Point _LocEllipse;
        public Line _TheConnector;
        public TagNoteBuffer _TNB;

        public MyEllipse(Point start, Point end, double thickness, Brush color)
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
            //Canvas.Se
        }
    }
}
