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
    public partial class SzobakUI : Window
    {
        public SzobakUI()
        {
            InitializeComponent();

            int columns = 3;

            int row = 0, col = 0;
            foreach (var room in MainWindow.szobak)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Margin = new Thickness(5);

                Label label1 = new Label();
                label1.Content = $"RoomNum: {room.RoomNum}";

                Label label2 = new Label();
                label2.Content = $"RoomCapacity: {room.RoomCapacity}";

                Label label3 = new Label();
                label3.Content = $"RoomPrice: {room.RoomPrice}";

                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(label3);

                Grid.SetRow(stackPanel, row);
                Grid.SetColumn(stackPanel, col);
                MainGrid.Children.Add(stackPanel);

                col++;
                if (col >= columns)
                {
                    col = 0;
                    row++;
                }
            }
        }
    }
}