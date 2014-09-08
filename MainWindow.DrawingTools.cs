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

namespace WPF_DCupNote
{
    partial class MainWindow
    {
        private string tool = null;
        Point start, end;
        Line drawLine;
        
        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (tool)
            {
                case "Line":
                    start = e.GetPosition(mainCanvas);
                    return;
                case "Circle":
                    return;
                case "Rectangle":
                    return;
                default:
                    return;
            }
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (tool)
                {
                    case "Line":
                        // pop line trakhir
                        // push line yg baru
                        end = e.GetPosition(mainCanvas);
                        drawLine = new Line();
                        drawLine.X1 = start.X;
                        drawLine.Y1 = start.Y;
                        drawLine.X2 = end.X;
                        drawLine.Y2 = end.Y;
                        drawLine.StrokeThickness = Convert.ToDouble(((ComboBoxItem)thicknessValue.SelectedItem).Content);
                        drawLine.Stroke = new SolidColorBrush(colPicker.SelectedColor);
                        mainCanvas.Children.Add(drawLine);
                        Canvas.SetZIndex(drawLine, 1);
                        return;
                    case "Circle":
                        return;
                    case "Rectangle":
                        return;
                    default:
                        return;
                }

                // clear
                // gambar 4 stack
            }
        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

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
