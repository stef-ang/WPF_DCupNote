using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_DCupNote
{
    partial class MainWindow
    {
        DCNDataClassesDataContext DDC;
        dCupnote dcnOpen;
        BitmapImage imageOpen;
        Size viewSize;
        List<MyLine> ListMyLine;
        private string tool = null;
        double shapeThickness;
        private Brush shapeColor;
        private Point start, end;
        private MyLine drawLine;
        public Point locSP = new Point();
        private Point locMove = new Point();
        private TagNoteBuffer tagNoteBuffer;
        private UIElement el;
        private bool SPclick = false;
        private MyLine argMyLine;

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
