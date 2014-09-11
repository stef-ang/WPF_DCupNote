using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_DCupNote
{
    partial class MainWindow
    {
        DCNDataClassesDataContext DDC;
        dCupnote dcnOpen;
        BitmapImage imageOpen;
        Image mainImage;
        Size viewSize;

        List<MyLine> ListMyLine;
        List<MyEllipse> ListMyEllipse;
        List<MyRectangle> ListMyRectangle;

        private MyLine drawLine;
        private MyEllipse drawEllipse;
        private MyRectangle drawRectangle;

        private MyLine argMyLine;
        private MyEllipse argMyEllipse;
        private MyRectangle argMyRectangle;

        private string tool = null;
        double shapeThickness;
        private Brush shapeColor;
        private Point start, end;
        public Point locSP = new Point();
        private Point locMove = new Point();
        private TagNoteBuffer tagNoteBuffer;
        private UIElement el;
        private bool SPclick = false;

        private BitmapImage ByteArrayToImage(byte[] bArray)
        {
            using (MemoryStream ms = new System.IO.MemoryStream(bArray))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
