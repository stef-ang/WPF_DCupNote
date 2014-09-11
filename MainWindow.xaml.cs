using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WPF_DCupNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DDC = new DCNDataClassesDataContext();

            InitializeCanvas();
            InitializeToolsDrawing();
            ListMyLine = new List<MyLine>();
            ListMyEllipse = new List<MyEllipse>();
            ListMyRectangle = new List<MyRectangle>();
        }

        private void InitializeToolsDrawing()
        {
            circleBtn.MouseLeftButtonDown += new MouseButtonEventHandler(CircleBtnMouseLeftButtonDown);
            rectangleBtn.MouseLeftButtonDown += new MouseButtonEventHandler(RectangleBtnMouseLeftButtonDown);
            lineBtn.MouseLeftButtonDown += new MouseButtonEventHandler(LineBtnMouseLeftButtonDown);
        }

        private void InitializeCanvas()
        {
            mainCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(MainCanvasMouseLeftButtonDown);
            mainCanvas.MouseMove += new MouseEventHandler(MainCanvasMouseMove);
            mainCanvas.MouseLeftButtonUp += new MouseButtonEventHandler(MainCanvasMouseLeftButtonUp);
        }

        private void closeBtn_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetAfterNewOrOpen(string id)
        {
            try
            {
                dcnOpen = (from dcn in DDC.dCupnotes
                                    where dcn.ID_DCN == id
                                    select dcn).FirstOrDefault();

                if (dcnOpen.Image != null)
                {
                    mainCanvas.Children.Clear();
                    mainImage = new Image();
                    imageOpen = ByteArrayToImage(dcnOpen.Image.ToArray());

                    mainCanvas.Children.Add(mainImage);
                    Canvas.SetLeft(mainImage, 10);
                    Canvas.SetTop(mainImage, 10);
                    Canvas.SetZIndex(mainImage, 1);

                    Size maxSize = new Size();
                    maxSize.Height = 650;
                    maxSize.Width = 1000;

                    viewSize = setMainImage(imageOpen, maxSize);
                    mainImage.Width = viewSize.Width;
                    mainImage.Height = viewSize.Height;
                    mainImage.Stretch = Stretch.UniformToFill;
                    mainImage.Source = imageOpen;
                }
                saveDashboard.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message);
            }
        }

        private Size setMainImage(BitmapImage imgToResize, Size size)
        {
            double sourceWidth = imgToResize.Width;
            double sourceHeight = imgToResize.Height;
            double nPercent = 0;
            double nPercentW = 0;
            double nPercentH = 0;

            nPercentW = ((double)size.Width / sourceWidth);
            nPercentH = ((double)size.Height / sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            Size resultSize = new Size();
            resultSize.Width = sourceWidth * nPercent;
            resultSize.Height = sourceHeight * nPercent;

            return resultSize;
        }

        private void newBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            newDcupnote newForm = new newDcupnote();

            if (newForm.ShowDialog() == true)
            {
                DDC.dCupnotes.InsertOnSubmit(newForm.GetDCupnote());
                DDC.SubmitChanges();

                SetAfterNewOrOpen(newForm.GetDCupnote().ID_DCN);
            }
        }

        private void openBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            openDcupnote openForm = new openDcupnote();

            if (openForm.ShowDialog() == true)
            {
                SetAfterNewOrOpen(openForm.getIdDCN());
            }
        }

        private void clearBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainCanvas.Children.Clear();
            mainImage = null;
            saveDashboard.Visibility = System.Windows.Visibility.Hidden;
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void saveDashboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
