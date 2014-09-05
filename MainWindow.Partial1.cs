using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF_DCupNote
{
    partial class MainWindow
    {
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
