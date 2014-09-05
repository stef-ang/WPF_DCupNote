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
using System.Windows.Shapes;

namespace WPF_DCupNote
{
    /// <summary>
    /// Interaction logic for openDcupnote.xaml
    /// </summary>
    public partial class openDcupnote : Window
    {
        private DCNDataClassesDataContext DDC;
        private List<dCupnote> listDCN;
        private string idDCN;

        public openDcupnote()
        {
            InitializeComponent();
            DDC = new DCNDataClassesDataContext();
            UpdateWindows();
        }

        private void UpdateWindows()
        {
            wrapPanel.Children.Clear();
            listDCN = DDC.dCupnotes.ToList();

            foreach (dCupnote dcn in listDCN)
            {
                Grid openGrid = new Grid();
                openGrid.Width = 210;
                openGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                openGrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                openGrid.ShowGridLines = true;
                openGrid.Margin = new Thickness(10, 10, 10, 10);
                openGrid.Background = Brushes.White;

                // define the Rows
                RowDefinition rowDef0 = new RowDefinition();
                rowDef0.Height = System.Windows.GridLength.Auto;
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                rowDef0.Height = System.Windows.GridLength.Auto;
                openGrid.RowDefinitions.Add(rowDef0);
                openGrid.RowDefinitions.Add(rowDef1);
                openGrid.RowDefinitions.Add(rowDef2);

                // buat stackPanel untuk id dan title
                StackPanel topStackPanel = new StackPanel();
                topStackPanel.Orientation = Orientation.Vertical;
                Grid.SetRow(topStackPanel, 0);

                TextBlock id = new TextBlock();
                id.Text = dcn.ID_DCN;
                id.FontSize = 14;
                id.FontWeight = FontWeights.Bold;

                TextBlock title = new TextBlock();
                title.Text = "Title: " + dcn.Title;
                title.TextWrapping = TextWrapping.Wrap;
                title.FontSize = 14;
                title.FontWeight = FontWeights.Bold;
                title.FontStyle = FontStyles.Italic;

                topStackPanel.Children.Add(id);
                topStackPanel.Children.Add(title);

                // buat image
                Image image = new Image();
                if (dcn.Image != null)
                {
                    image.Source = ByteArrayToImage(dcn.Image.ToArray());
                    image.Width = 210;
                    image.Height = 168;
                    image.Stretch = Stretch.Uniform;
                    Grid.SetRow(image, 1);
                }

                // buat button delete
                Button delBtn = new Button();
                delBtn.Name = dcn.ID_DCN;
                delBtn.Content = "X";
                delBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                delBtn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                delBtn.FontWeight = FontWeights.Bold;
                delBtn.Width = delBtn.Height = 27;
                delBtn.FontSize = 16;
                delBtn.Click += delBtn_Click;
                Grid.SetRow(delBtn, 2);

                // buat button open
                Button openBtn = new Button();
                openBtn.Name = dcn.ID_DCN;
                openBtn.Content = "Open";
                openBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                openBtn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                openBtn.FontWeight = FontWeights.Bold;
                openBtn.FontSize = 16;
                openBtn.Click += openBtn_Click;
                Grid.SetRow(openBtn, 2);

                openGrid.Children.Add(topStackPanel);
                openGrid.Children.Add(image);
                openGrid.Children.Add(delBtn);
                openGrid.Children.Add(openBtn);

                wrapPanel.Children.Add(openGrid);
            }
        }

        public string getIdDCN()
        {
            return idDCN;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            //Xceed.Wpf.Toolkit.MessageBox.Show(sender.ToString() + "__" + e.ToString() + "___" + e.OriginalSource.ToString());
            Button b = (Button)e.OriginalSource;
            idDCN = b.Name;
            this.DialogResult = true;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.OriginalSource;
            dCupnote delDCN = (from dd in DDC.dCupnotes
                               where dd.ID_DCN == b.Name
                               select dd).FirstOrDefault();

            string nameDelDCN = "";
            if(!String.IsNullOrWhiteSpace(delDCN.Title))
                nameDelDCN = " (" + delDCN.Title + ")";

            if (Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure to delete " + delDCN.ID_DCN + nameDelDCN + "?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DDC.dCupnotes.DeleteOnSubmit(delDCN);
                DDC.SubmitChanges();

                UpdateWindows();
            }
        }

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
