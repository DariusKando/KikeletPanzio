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
    public partial class FoglalasUI : Window
    {
        public FoglalasUI()
        {
            InitializeComponent();
            string data = "";
            foreach (var item in MainWindow.foglalasok)
            {
                data += item.ToString() + "\n";
            }
            txbData.Text = data;
        }
    }
}
