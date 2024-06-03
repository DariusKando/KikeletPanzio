using System;
using System.Collections.Generic;
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

namespace KikeletPanzio
{
    public partial class Statisztika : Window
    {
        public Statisztika()
        {
            InitializeComponent();
        }
        public static DateTime also = DateTime.Parse("2024.05.01");
        public static DateTime felso = DateTime.Parse("2099.12.31");
        private DatePicker datePicker;
        private DatePicker datePicker2;
        private void rbtnBevetel_Checked(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();


            datePicker = new DatePicker();
            datePicker.Margin = new Thickness(10);
            datePicker.Width = 150;
            datePicker.Name = "dtpAlso";
            datePicker.HorizontalAlignment = HorizontalAlignment.Left;
            spMain.Children.Add(datePicker);

            datePicker2 = new DatePicker();
            datePicker2.Margin = new Thickness(10);
            datePicker2.Width = 150;
            datePicker2.Name = "dtpFelso";
            datePicker2.SelectedDateChanged += dtpFelsoChanged;
            datePicker2.HorizontalAlignment = HorizontalAlignment.Left;
            spMain.Children.Add(datePicker2);
        }

        private void dtpFelsoChanged(object sender, RoutedEventArgs e)
        {
            felso = datePicker2.SelectedDate.Value;
            DateKiiras();
        }
        private void dtpAlsoChanged(object sender, RoutedEventArgs e)
        {
            also = datePicker.SelectedDate.Value;
            DateKiiras();
        }
        private void DateKiiras()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"{MainWindow.foglalasok.Where(x => x.ArriveTime >= also && x.LeaveTime <= felso).Sum(x => x.PriceSum)} Ft";
            textBlock.FontSize = 15;
            textBlock.Margin = new Thickness(10);
            spMain.Children.Add(textBlock);
        }

        private void rbtnLegKiadottSzoba_Checked(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"{MainWindow.foglalasok.GroupBy(x => x.RoomNum).OrderByDescending(x => x.Count()).FirstOrDefault().Key}";
            textBlock.FontSize = 15;
            textBlock.Margin = new Thickness(10);
            spMain.Children.Add(textBlock);
        }

        private void rbtnVendegLista_Checked(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            string embi = "";
            foreach (var item in MainWindow.foglalasok.GroupBy(x => x.PersonName).Select(x => new { PersonName = x.Key, TotalPriceSum = x.Sum(y => y.PriceSum) }).OrderByDescending(x => x.TotalPriceSum).Select(x => x.PersonName))
            {
                embi += item + "\n";
            }
            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"{ embi }";
            textBlock.FontSize = 15;
            textBlock.Margin = new Thickness(10);
            spMain.Children.Add(textBlock);
        }
    }
}
