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
            if (mainImage == null)
                Xceed.Wpf.Toolkit.MessageBox.Show("mainImage is null");

            if (mainImage != null)
            {
                if (tool != null)
                {
                    shapeThickness = Convert.ToDouble(((ComboBoxItem)thicknessValue.SelectedItem).Content);
                    shapeColor = new SolidColorBrush(colPicker.SelectedColor);
                    start = e.GetPosition(mainCanvas);
                    end = e.GetPosition(mainCanvas);
                }
                switch (tool)
                {
                    case "Line":
                        drawLine = new MyLine(start, end, shapeThickness, shapeColor);
                        mainCanvas.Children.Add(drawLine._TheLine);
                        Canvas.SetZIndex(drawLine._TheLine, 1);
                        break;
                    case "Circle":
                        drawEllipse = new MyEllipse(start, shapeThickness, shapeColor);
                        mainCanvas.Children.Add(drawEllipse._TheEllipse);
                        Canvas.SetZIndex(drawEllipse._TheEllipse, 1);
                        break;
                    case "Rectangle":
                        drawRectangle = new MyRectangle(start, shapeThickness, shapeColor);
                        mainCanvas.Children.Add(drawRectangle._TheRectangle);
                        Canvas.SetZIndex(drawRectangle._TheRectangle, 1);
                        break;
                    default:
                        break;
                }
            }
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && tool != null && mainImage != null)
            {
                end = e.GetPosition(mainCanvas);
                switch (tool)
                {
                    case "Line":
                        drawLine._TheLine.X2 = end.X;
                        drawLine._TheLine.Y2 = end.Y;
                        break;
                    case "Circle":
                        drawEllipse._TheEllipse.Width = staticClass.EllipseRectangleWidthHeight(start, end).X;
                        drawEllipse._TheEllipse.Height = staticClass.EllipseRectangleWidthHeight(start, end).Y;
                        drawEllipse._CenterLocE = staticClass.EllipseRectangleCenterPoint(start, end);
                        Canvas.SetLeft(drawEllipse._TheEllipse, staticClass.EllipseRectangleGetPosition(drawEllipse._CenterLocE,
                            drawEllipse._TheEllipse.Width, drawEllipse._TheEllipse.Height).X);
                        Canvas.SetTop(drawEllipse._TheEllipse, staticClass.EllipseRectangleGetPosition(drawEllipse._CenterLocE,
                            drawEllipse._TheEllipse.Width, drawEllipse._TheEllipse.Height).Y);
                        break;
                    case "Rectangle":
                        drawRectangle._TheRectangle.Width = staticClass.EllipseRectangleWidthHeight(start, end).X;
                        drawRectangle._TheRectangle.Height = staticClass.EllipseRectangleWidthHeight(start, end).Y;
                        drawRectangle._CenterLocR = staticClass.EllipseRectangleCenterPoint(start, end);
                        Canvas.SetLeft(drawRectangle._TheRectangle, staticClass.EllipseRectangleGetPosition(drawRectangle._CenterLocR, drawRectangle._TheRectangle.Width, drawRectangle._TheRectangle.Height).X);
                        Canvas.SetTop(drawRectangle._TheRectangle, staticClass.EllipseRectangleGetPosition(drawRectangle._CenterLocR, drawRectangle._TheRectangle.Width, drawRectangle._TheRectangle.Height).Y);
                        break;
                    default:
                        break;
                }

            }
        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mainImage != null)
            {
                switch (tool)
                {
                    case "Line":
                        drawLine._TNB = tagNoteBuffer = new TagNoteBuffer(drawLine._IDLine, drawLine._TheLine.X2 + 20, drawLine._TheLine.Y2);
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
                        drawEllipse._TNB = tagNoteBuffer = new TagNoteBuffer(drawEllipse._IDEllipse, drawEllipse._CenterLocE.X + (drawEllipse._TheEllipse.Width / 2) + 20, drawEllipse._CenterLocE.Y + 20);
                        drawEllipse.DrawConnector();
                        mainCanvas.Children.Add(drawEllipse._TheConnector);
                        ListMyEllipse.Add(drawEllipse);
                        break;
                    case "Rectangle":
                        drawRectangle._TNB = tagNoteBuffer = new TagNoteBuffer(drawRectangle._IDRectangle, drawRectangle._CenterLocR.X + (drawRectangle._TheRectangle.Width / 2) + 20, drawRectangle._CenterLocR.Y - (drawRectangle._TheRectangle.Height / 2) + 20);
                        drawRectangle.DrawConnector();
                        mainCanvas.Children.Add(drawRectangle._TheConnector);
                        ListMyRectangle.Add(drawRectangle);
                        break;
                    default:
                        break;
                }

                if (tool != null)
                {
                    tagNoteBuffer.textBox.Focus();
                    tagNoteBuffer.TagPanel.MouseLeftButtonDown += new MouseButtonEventHandler(TNB_BtnDown);
                    tagNoteBuffer.TagPanel.MouseMove += new MouseEventHandler(TNB_Move);
                    tagNoteBuffer.TagPanel.MouseLeftButtonUp += new MouseButtonEventHandler(TNB_BtnUp);
                    mainCanvas.Children.Add(tagNoteBuffer.TagPanel);
                }

                tool = null;
                NormalizationToolsDrawing();
            }
        }

        private void TNB_BtnDown(object sender, MouseButtonEventArgs e)
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
            argMyEllipse = (from m in ListMyEllipse
                            where m._IDEllipse == sp.Name
                            select m).FirstOrDefault();
            argMyRectangle = (from m in ListMyRectangle
                              where m._IDRectangle == sp.Name
                              select m).FirstOrDefault();
        }

        private void TNB_Move(object sender, MouseEventArgs e)
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

                if(argMyLine != null)
                    UpdateLineConnector(argMyLine);
                if (argMyEllipse != null)
                    UpdateEllipseConnector(argMyEllipse);
                if (argMyRectangle != null)
                    UpdateRectangleConnector(argMyRectangle);

                locMove = temp;
            }
        }

        private void UpdateRectangleConnector(MyRectangle argMyRectangle)
        {
            Point argPoint = new Point();
            argPoint.X = Canvas.GetLeft(argMyRectangle._TNB.TagPanel);
            argPoint.Y = Canvas.GetTop(argMyRectangle._TNB.TagPanel);
            argMyRectangle._TheConnector.X2 = argPoint.X;
            argMyRectangle._TheConnector.Y2 = argPoint.Y;
            argMyRectangle._TheConnector.X1 = staticClass.RectangleConnectorStar(argPoint, argMyRectangle).X;
            argMyRectangle._TheConnector.Y1 = staticClass.RectangleConnectorStar(argPoint, argMyRectangle).Y;
        }

        private void UpdateEllipseConnector(MyEllipse argMyEllipse)
        {
            Point argPoint = new Point();
            argPoint.X = Canvas.GetLeft(argMyEllipse._TNB.TagPanel);
            argPoint.Y = Canvas.GetTop(argMyEllipse._TNB.TagPanel);
            argMyEllipse._TheConnector.X2 = argPoint.X;
            argMyEllipse._TheConnector.Y2 = argPoint.Y;
            argMyEllipse._TheConnector.X1 = staticClass.EllipseConnectorStart(argPoint, argMyEllipse).X;
            argMyEllipse._TheConnector.Y1 = staticClass.EllipseConnectorStart(argPoint, argMyEllipse).Y;
        }

        private void UpdateLineConnector(MyLine argMyLine)
        {
            Point argPoint = new Point();
            argPoint.X = Canvas.GetLeft(argMyLine._TNB.TagPanel);
            argPoint.Y = Canvas.GetTop(argMyLine._TNB.TagPanel);
            argMyLine._TheConnector.X2 = argPoint.X;
            argMyLine._TheConnector.Y2 = argPoint.Y;
            argMyLine._TheConnector.X1 = staticClass.LineConnectorStart(argPoint, argMyLine._TheLine).X;
            argMyLine._TheConnector.Y1 = staticClass.LineConnectorStart(argPoint, argMyLine._TheLine).Y;
        }

        private void TNB_BtnUp(object sender, MouseButtonEventArgs e)
        {
            SPclick = false;
            el.ReleaseMouseCapture();
            tagNoteBuffer.TagPoint = locSP;
            argMyLine = null;
            argMyEllipse = null;
            argMyRectangle = null;
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
