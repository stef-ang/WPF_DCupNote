using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_DCupNote
{
    partial class MainWindow
    {
        private string tool = null;

        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // cek
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void NormalizationToolsDrawing()
        {
            this.tool = null;
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
        }

        private void RectangleBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Rectangle")
            {
                tool = "Rectangle";
                rectangleBtn.Opacity = 0.6;
            }
        }

        private void CircleBtnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NormalizationToolsDrawing();

            if (tool != "Circle")
            {
                tool = "Circle";
                circleBtn.Opacity = 0.6;
            }
        }
    }
}
