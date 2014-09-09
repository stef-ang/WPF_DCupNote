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
        public TagNoteBuffer _TGN;
        //public Point _TagPoint;
        //public StackPanel _TagPanel;
        //public TextBox textBox;
        //public Canvas _mainCanvas;

        //Point _anchorPoint;
        //Point _currentPoint;
        //bool _isInDrag;
        //private readonly TranslateTransform _transform = new TranslateTransform();

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
                _TheConnector = new Line();
            }
            catch (Exception x)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(x.Message);
            }
        }

        //public void AddTag(Canvas mainCanvas)
        //{
        //    _TagPoint = new Point();
        //    _TagPanel = new StackPanel();
        //    _TagPanel.Orientation = Orientation.Vertical;
        //    _TagPanel.Width = 200;
        //    _TagPanel.Background = Brushes.AliceBlue;

        //    StackPanel headerTP = new StackPanel();
        //    headerTP.Orientation = Orientation.Horizontal;
        //    headerTP.FlowDirection = FlowDirection.RightToLeft;
        //    headerTP.Background = Brushes.Blue;
        //    headerTP.Name = _IDLine;
        //    headerTP.MouseLeftButtonDown += new MouseButtonEventHandler(headerTP_LeftBtnDown);
        //    headerTP.MouseMove += new MouseEventHandler(headerTP_Move);
        //    headerTP.MouseLeftButtonUp += new MouseButtonEventHandler(headerTP_LeftBtnUp);
        //    _mainCanvas = mainCanvas;

        //    Button delBtn = new Button();
        //    delBtn.Name = _IDLine;
        //    delBtn.Content = "X";
        //    delBtn.FontWeight = FontWeights.Bold;
        //    delBtn.Width = delBtn.Height = 23;
        //    delBtn.FontSize = 12;
        //    delBtn.Click += delBtn_Click;

        //    Button editSaveBtn = new Button();
        //    editSaveBtn.Name = _IDLine;
        //    editSaveBtn.Content = "V";
        //    editSaveBtn.FontWeight = FontWeights.Bold;
        //    editSaveBtn.Width = delBtn.Height = 23;
        //    editSaveBtn.FontSize = 12;
        //    editSaveBtn.Click += editSaveBtn_Click;

        //    Button transparentBtn = new Button();
        //    transparentBtn.Name = _IDLine;
        //    transparentBtn.Content = "_";
        //    transparentBtn.FontWeight = FontWeights.Bold;
        //    transparentBtn.Width = delBtn.Height = 23;
        //    transparentBtn.FontSize = 12;
        //    transparentBtn.Click += transparentBtn_Click;

        //    headerTP.Children.Add(delBtn);
        //    headerTP.Children.Add(editSaveBtn);
        //    headerTP.Children.Add(transparentBtn);

        //    _TagPanel.Children.Add(headerTP);

        //    textBox = new TextBox();
        //    textBox.Height = 23;
        //    textBox.HorizontalAlignment = HorizontalAlignment.Stretch;

        //    _TagPanel.Children.Add(textBox);

        //    mainCanvas.Children.Add(_TagPanel); // kl gbs return type fungsi ini diubah jadi StackPanel
        //    Canvas.SetLeft(_TagPanel, _TheLine.X2);
        //    Canvas.SetTop(_TagPanel, _TheLine.Y2);
        //    Canvas.SetZIndex(_TagPanel, 2);
        //}

        //private void headerTP_LeftBtnUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (!_isInDrag) return;
        //    var element = sender as FrameworkElement;
        //    if (element != null) element.ReleaseMouseCapture();
        //    _isInDrag = false;
        //    e.Handled = true;
        //    textBox.Text += "3";
        //}

        //private void headerTP_LeftBtnDown(object sender, MouseButtonEventArgs e)
        //{
        //    var element = sender as FrameworkElement;
        //    _anchorPoint = e.GetPosition(null);
        //    if (element != null) element.CaptureMouse();
        //    _isInDrag = true;
        //    e.Handled = true;
        //    textBox.Text += "1";
        //}

        //private void headerTP_Move(object sender, MouseEventArgs e)
        //{
        //    if (!_isInDrag) return;
        //    _currentPoint = e.GetPosition(null);

        //    _transform.X += _currentPoint.X - _anchorPoint.X;
        //    _transform.Y += (_currentPoint.Y - _anchorPoint.Y);
        //    RenderTransform = _transform;
        //    _anchorPoint = _currentPoint;
        //    textBox.Text += "2";
        //}

        //private void transparentBtn_Click(object sender, RoutedEventArgs e)
        //{

            
        //}

        //private void editSaveBtn_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        //private void delBtn_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        
    }
}

