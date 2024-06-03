using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Regisztracio : Window
    {
        public Regisztracio()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfCorrectInputs() && idBuilder() != string.Empty)
            {
                bool isVIP = (bool)rbtnIsVIP.IsChecked ? true : false;
                string id = idBuilder();
                MainWindow.felhasznalok.Add(new Felhasznalok(id, tbxName.Text, dtpBirth.SelectedDate.Value, tbxEmail.Text, isVIP));
                this.Close();
            }
            else
            {
                MessageBox.Show("Hibás adat.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string idBuilder()
        {
            string id = $"{tbxName.Text}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}";
            if(MainWindow.felhasznalok.Count < 1)
            {
                return id;
            }
            if (!MainWindow.felhasznalok.Select(x => x.AccID).Contains(id))
            {
                return id;
            }
            else
            {
                MessageBox.Show("ID generation failed. Duplicate ID found.");
                return string.Empty;
            }
        }
        private bool CheckIfCorrectInputs()
        {
            return ((bool)rbtnIsVIP.IsChecked || (bool)rbtnIsNotVIP.IsChecked) &&
                    dtpBirth.SelectedDate.HasValue &&
                    Regex.IsMatch(tbxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
