using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPF_DCupNote
{
    /// <summary>
    /// Interaction logic for newDcupnote.xaml
    /// </summary>
    public partial class newDcupnote : Window
    {
        private dCupnote _dcn;
        private byte[] fileByte;
        private Binary fileBinary;
        private BitmapImage bImage;

        public newDcupnote()
        {
            InitializeComponent();
            setID();
        }

        private void setID()
        {
            DateTime date = DateTime.Now;
            idTB.Text = "DCN" + date.ToShortDateString() + "_" + date.ToLongTimeString();
            idTB.Text = idTB.Text.Replace("/", "");
            idTB.Text = idTB.Text.Replace(":", "");
        }

        public dCupnote GetDCupnote()
        {
            return _dcn;
        }

        private byte[] ImageToByteArray(BitmapImage imageIn)
        {
            Stream stream = imageIn.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                stream.Position = 0;
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }

        private void okeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(idTB.Text) ||
                    image1.Source == null)
                {
                    string message = "";

                    if (String.IsNullOrWhiteSpace(idTB.Text))
                        message += "The ID must be filled.\n";
                    if (image1.Source == null)
                        message += "The Image must be filled.";

                    MessageBox.Show(message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else
                {
                    DCNDataClassesDataContext DDC = new DCNDataClassesDataContext();
                    dCupnote dcupnote = (from p in DDC.dCupnotes
                                         where p.ID_DCN == idTB.Text
                                         select p).FirstOrDefault();

                    if (dcupnote != null && _dcn == null)
                        MessageBox.Show("The ID have been used by another data. Please use another ID.",
                            "Warning!", MessageBoxButton.OK, MessageBoxImage.Stop);

                    else
                    {
                        if (_dcn == null)
                        {
                            _dcn = new dCupnote();
                            _dcn.ID_DCN = idTB.Text;
                        }

                        _dcn.Title = titleTB.Text;
                        _dcn.Note_DCN = noteTB.Text;

                        if (image1.Source != null)
                        {
                            fileByte = ImageToByteArray(bImage);
                            fileBinary = new Binary(fileByte);
                            _dcn.Image = fileBinary;
                        }
                        else
                            _dcn.Image = null;

                        this.DialogResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void clickWindow(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void openBtn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";

                if (ofd.ShowDialog() == true && !String.IsNullOrWhiteSpace(ofd.FileName))
                {
                    image1.Stretch = Stretch.Uniform;
                    bImage = new BitmapImage();
                    bImage.BeginInit();
                    bImage.StreamSource = File.OpenRead(ofd.FileName);
                    bImage.EndInit();
                    image1.Source = bImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
