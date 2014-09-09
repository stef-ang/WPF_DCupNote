using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WPF_DCupNote
{
    partial class MainWindow
    {
        private string tool = null;
        double shapeThickness;
        Brush shapeColor;
        Point start, end;
        TagNoteBuffer tagNoteBuffer;
        MyLine drawLine;
        
        //
        Point _anchorPoint;
        Point _currentPoint;
        bool _isInDrag;
        private readonly TranslateTransform _transform = new TranslateTransform();
        //

        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (tool)
            {
                case "Line":
                    shapeThickness = Convert.ToDouble(((ComboBoxItem)thicknessValue.SelectedItem).Content);
                    shapeColor = new SolidColorBrush(colPicker.SelectedColor);
                    start = e.GetPosition(mainCanvas);
                    end = e.GetPosition(mainCanvas);
                    drawLine = new MyLine(start, end, shapeThickness, shapeColor);
                    mainCanvas.Children.Add(drawLine._TheLine);
                    Canvas.SetZIndex(drawLine._TheLine, 1);
                    break;
                case "Circle":
                    break;
                case "Rectangle":
                    break;
                default:
                    break;
            }
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (tool)
                {
                    case "Line":
                        end = e.GetPosition(mainCanvas);
                        drawLine._TheLine.X2 = end.X;
                        drawLine._TheLine.Y2 = end.Y;
                        break;
                    case "Circle":
                        break;
                    case "Rectangle":
                        break;
                    default:
                        break;
                }

            }
        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch (tool)
            {
                case "Line":
                    ListMyLine.Add(drawLine);
                    tagNoteBuffer = new TagNoteBuffer(drawLine._IDLine, drawLine._TheLine.X2, drawLine._TheLine.Y2);
                    mainCanvas.Children.Add(tagNoteBuffer.TagPanel);
                    tagNoteBuffer.textBox.Focus();
                    tagNoteBuffer.headerTP.MouseLeftButtonDown += new MouseButtonEventHandler(TGN_BtnDown);
                    tagNoteBuffer.headerTP.MouseMove += new MouseEventHandler(TGN_Move);
                    tagNoteBuffer.headerTP.MouseLeftButtonUp += new MouseButtonEventHandler(TGN_BtnUp);
                    drawLine._TGN = tagNoteBuffer;
                    break;
                case "Circle":
                    break;
                case "Rectangle":
                    break;
                default:
                    break;
            }
            tool = null;
            NormalizationToolsDrawing();
        }


        private void ToTheThumb()
        {
            ControlTemplate ct = new ControlTemplate();
            
        }

        private void TGN_BtnDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            _anchorPoint = e.GetPosition(null);
            if (element != null) element.CaptureMouse();
            _isInDrag = true;
            e.Handled = true;
            //tagNoteBuffer.textBox.Text += "1";
        }

        private void TGN_Move(object sender, MouseEventArgs e)
        {
            if (!_isInDrag) return;
            _currentPoint = e.GetPosition(null);

            _transform.X += _currentPoint.X - _anchorPoint.X;
            _transform.Y += (_currentPoint.Y - _anchorPoint.Y);
            mainCanvas.RenderTransform = _transform;
            _anchorPoint = _currentPoint;
            //textBox.Text += "2";
        }

        private void TGN_BtnUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isInDrag) return;
            var element = sender as FrameworkElement;
            if (element != null) element.ReleaseMouseCapture();
            _isInDrag = false;
            e.Handled = true;
            //textBox.Text += "3";
        }

        private void NormalizationToolsDrawing()
        {
            lineBtn.Opacity = circleBtn.Opacity = rectangleBtn.Opacity = 1;
        }

        private void LineBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Line")
            {
                tool = "Line";
                lineBtn.Opacity = 0.6;
            }
            else
                tool = null;
        }

        private void RectangleBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Rectangle")
            {
                tool = "Rectangle";
                rectangleBtn.Opacity = 0.6;
            }
            else
                tool = null;
        }

        private void CircleBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Circle")
            {
                tool = "Circle";
                circleBtn.Opacity = 0.6;
            }
            else
                tool = null;
        }
    }
}
