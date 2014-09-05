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
            //-------------------------------------------
            //if (bArray == null)
            //{
            //    if (bArray == null)
            //        MessageBox.Show("bArray is null");

            //    MessageBox.Show("Jangan2 sampai sini udah null @@");
            //    return null; }

            //var image = new BitmapImage();
            //using (var mem = new MemoryStream(bArray))
            //{
            //    mem.Position = 0;
            //    image.BeginInit();
            //    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            //    image.CacheOption = BitmapCacheOption.OnLoad;
            //    image.UriSource = null;
            //    image.StreamSource = mem;
            //    image.EndInit();
            //}
            //image.Freeze();
            //return image;
        }
    }
}
