using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_DCupNote
{
    class TagNoteBuffer
    {
        public string IDTagNote;
        public Point TagPoint;
        public StackPanel TagPanel;
        public StackPanel headerTP;
        public TextBox textBox;
        public Button delBtn;
        public Button editSaveBtn;
        public Button transparentBtn;

        public TagNoteBuffer(string ID, double X, double Y)
        {
            IDTagNote = ID;

            TagPoint = new Point();
            TagPanel = new StackPanel();
            headerTP = new StackPanel();
            textBox = new TextBox();
            delBtn = new Button();
            editSaveBtn = new Button();
            transparentBtn = new Button();

            TagPoint.X = X;
            TagPoint.Y = Y;

            TagPanel.Orientation = Orientation.Vertical;
            TagPanel.Width = 200;
            TagPanel.Background = Brushes.AliceBlue;
            TagPanel.Name = IDTagNote;

            headerTP.Orientation = Orientation.Horizontal;
            headerTP.FlowDirection = FlowDirection.RightToLeft;
            headerTP.Background = Brushes.Blue;
            headerTP.Name = IDTagNote;

            delBtn.Name = IDTagNote;
            delBtn.Content = "X";
            delBtn.FontWeight = FontWeights.Bold;
            delBtn.Width = delBtn.Height = 23;
            delBtn.FontSize = 12;
            delBtn.Click += delBtn_Click;

            editSaveBtn.Name = IDTagNote;
            editSaveBtn.Content = "V";
            editSaveBtn.FontWeight = FontWeights.Bold;
            editSaveBtn.Width = editSaveBtn.Height = 23;
            editSaveBtn.FontSize = 12;
            editSaveBtn.Click += editSaveBtn_Click;

            transparentBtn.Name = IDTagNote;
            transparentBtn.Content = "_";
            transparentBtn.FontWeight = FontWeights.Bold;
            transparentBtn.Width = transparentBtn.Height = 23;
            transparentBtn.FontSize = 12;
            transparentBtn.Click += transparentBtn_Click;

            textBox.Height = 23;
            textBox.HorizontalAlignment = HorizontalAlignment.Stretch;

            headerTP.Children.Add(delBtn);
            headerTP.Children.Add(editSaveBtn);
            headerTP.Children.Add(transparentBtn);

            TagPanel.Children.Add(headerTP);
            TagPanel.Children.Add(textBox);

            Canvas.SetLeft(TagPanel, TagPoint.X);
            Canvas.SetTop(TagPanel, TagPoint.Y);
            Canvas.SetZIndex(TagPanel, 2);
        }

        private void transparentBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void editSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
