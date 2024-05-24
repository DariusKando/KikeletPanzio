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

namespace KikeletPanzio
{
    public partial class MainWindow : Window
    {
        public static List<Szobak> szobak = new List<Szobak>();
        public static List<Felhasznalok> felhasznalok = new List<Felhasznalok>();
        public static List<Foglalasok> foglalasok = new List<Foglalasok>();

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }
        private void Setup()
        {
            foreach (var sor in File.ReadAllLines("szobak.txt"))
            {
                szobak.Add(new Szobak(sor));
            }
            foreach (var sor in File.ReadAllLines("felhasznalok.txt"))
            {
                felhasznalok.Add(new Felhasznalok(sor));
            }
            foreach (var sor in File.ReadAllLines("foglalasok.txt"))
            {
                foglalasok.Add(new Foglalasok(sor));
            }


            //dtgSzobak.ItemsSource = szobak;
            //dtgSzobak.ItemsSource = felhasznalok;
            //dtgSzobak.ItemsSource = foglalasok;
        }
        private void miReg_Click(object sender, RoutedEventArgs e)
        {
            Regisztracio ujablak = new Regisztracio();
            ujablak.ShowDialog();
        }

        private void miRes_Click(object sender, RoutedEventArgs e)
        {
            if (felhasznalok.Count > 0)
            {
                Foglalas ujablak = new Foglalas();
                ujablak.ShowDialog();

                File.WriteAllLines("felhasznalok.txt", felhasznalok.Select(x => x.ToString()));
                dtgSzobak.ItemsSource = felhasznalok;
            }
            else
            {
                MessageBox.Show("Legalább egy regisztráció szükséges.");
            }
        }

        private void miStat_Click(object sender, RoutedEventArgs e)
        {
            if (foglalasok.Count > 0)
            {
                Statisztika ujablak = new Statisztika();
                ujablak.ShowDialog();
            }
            else
            {
                MessageBox.Show("Legalább egy foglalás szükséges.");
            }
        }
    }
}