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
                    drawLine._TNB = tagNoteBuffer = new TagNoteBuffer(drawLine._IDLine, drawLine._TheLine.X2, drawLine._TheLine.Y2);
                    //drawLine._TNB.textBox.Focus();
                    //drawLine._TNB.TagPanel.MouseMove += new MouseEventHandler(TGN_Move);
                    //drawLine._TNB.TagPanel.MouseLeftButtonUp += new MouseButtonEventHandler(TGN_BtnUp);
                    //drawLine._TNB.TagPanel.MouseLeftButtonDown += new MouseButtonEventHandler(TGN_BtnDown);
                    //mainCanvas.Children.Add(drawLine._TNB.TagPanel);
                    drawLine.DrawConnector();
                    mainCanvas.Children.Add(drawLine._TheConnector);
                    ListMyLine.Add(drawLine);
                    break;
                case "Circle":
                    break;
                case "Rectangle":
                    break;
                default:
                    break;
            }

            if (tool != null)
            {
                tagNoteBuffer.textBox.Focus();
                tagNoteBuffer.TagPanel.MouseLeftButtonDown += new MouseButtonEventHandler(TGN_BtnDown);
                tagNoteBuffer.TagPanel.MouseMove += new MouseEventHandler(TGN_Move);
                tagNoteBuffer.TagPanel.MouseLeftButtonUp += new MouseButtonEventHandler(TGN_BtnUp);
                mainCanvas.Children.Add(tagNoteBuffer.TagPanel);
            }

            tool = null;
            NormalizationToolsDrawing();
        }

        private void TGN_BtnDown(object sender, MouseButtonEventArgs e)
        {
            SPclick = true;
            el = (UIElement)sender;
            el.CaptureMouse();
            locMove = e.GetPosition(mainCanvas);
            locSP.X = Canvas.GetLeft(el);
            locSP.Y = Canvas.GetTop(el);

            StackPanel sp = (StackPanel)sender;
            argMyLine = (from m in ListMyLine
                         where m._IDLine == sp.Name
                         select m).FirstOrDefault();
        }

        private void TGN_Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && SPclick)
            {
                

                Point temp = new Point();
                temp = e.GetPosition(mainCanvas);

                double deltaX = temp.X - locMove.X;
                double deltaY = temp.Y - locMove.Y;

                Canvas.SetLeft(el, locSP.X + deltaX);
                Canvas.SetTop(el, locSP.Y + deltaY);
                locSP.X = Canvas.GetLeft(el);
                locSP.Y = Canvas.GetTop(el);

                UpdateConnector(argMyLine);

                locMove = temp;
            }
        }

        private void UpdateConnector(MyLine argMyLine)
        {
            Point argPoint = new Point();
            argPoint.X = Canvas.GetLeft(argMyLine._TNB.TagPanel);
            argPoint.Y = Canvas.GetTop(argMyLine._TNB.TagPanel);
            argMyLine._TheConnector.X2 = argPoint.X;
            argMyLine._TheConnector.Y2 = argPoint.Y;
            argMyLine._TheConnector.X1 = staticClass.ConnectorStart(argPoint, argMyLine._TheLine)[0];
            argMyLine._TheConnector.Y1 = staticClass.ConnectorStart(argPoint, argMyLine._TheLine)[1];
        }

        private void TGN_BtnUp(object sender, MouseButtonEventArgs e)
        {
            SPclick = false;
            el.ReleaseMouseCapture();
            tagNoteBuffer.TagPoint = locSP;
            Xceed.Wpf.Toolkit.MessageBox.Show(argMyLine._TNB.TagPanel.Name);
        }

        private void NormalizationToolsDrawing()
        {
            lineBtn.Opacity = circleBtn.Opacity = rectangleBtn.Opacity = 0.6;
        }

        private void LineBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Line")
            {
                tool = "Line";
                lineBtn.Opacity = 1;
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
                rectangleBtn.Opacity = 1;
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
                circleBtn.Opacity = 1;
            }
            else
                tool = null;
        }
    }
}
