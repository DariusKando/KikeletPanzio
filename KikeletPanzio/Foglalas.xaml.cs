using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class Foglalas : Window
    {
        public Foglalas()
        {
            InitializeComponent();
            foreach (var item in MainWindow.szobak.Select(x => x.RoomNum))
            {
                cbxSzobak.Items.Add(item);
            }
            foreach (var item in MainWindow.felhasznalok.Select(x => x.AccID))
            {
                cbxUgyfel.Items.Add(item);
            }
            cbxAllapot.Items.Add("előjegyzett");
            cbxAllapot.Items.Add("teljesült");
            cbxAllapot.Items.Add("lemondott");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime arriveTime = DateTime.Parse(dtpErkezes.SelectedDate.ToString());
            DateTime leaveTime = DateTime.Parse(dtpTavozas.SelectedDate.ToString());
            int personCount = int.Parse(tbxFo.Text);
            MainWindow.foglalasok.Add(
                new Foglalasok(
                    int.Parse(cbxSzobak.SelectedItem.ToString()),
                    cbxUgyfel.SelectedItem.ToString(),
                    arriveTime,
                    leaveTime,
                    personCount,
                    MainWindow.szobak.Where(x => x.RoomNum == (int)cbxSzobak.SelectedItem).Select(x => x.RoomPrice).FirstOrDefault() * personCount * (leaveTime - arriveTime).Days,
                    cbxAllapot.SelectedItem.ToString()
                )
            );
            StreamWriter sw = new StreamWriter("foglalasok.txt");
            foreach (var item in MainWindow.foglalasok)
            {
                sw.WriteLine(item.ToString());
            }
            sw.Close();
        }

        private void cbxSzobak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbxFo.Text = MainWindow.szobak.Where(x => x.RoomNum == (int)cbxSzobak.SelectedItem).Select(x => x.RoomCapacity).FirstOrDefault().ToString();
        }
    }
}