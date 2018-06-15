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

namespace TheatreSystem08220.Windows
{
    /// <summary>
    /// Interaction logic for Seating_View.xaml
    /// </summary>
    public partial class Seating_View : Window
    {
        public Seating_View()
        {
            InitializeComponent();
        }

        private void upperCircleButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.seatingDetailedUpper upperDetailed = new Windows.seatingDetailedUpper();
            upperDetailed.ShowDialog();
        }

        private void dressCircleButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.seatingDetailedDress dressDetailed = new Windows.seatingDetailedDress();
            dressDetailed.ShowDialog();
        }

        private void stallsButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.seatingDetailedStalls stallsDetailed = new Windows.seatingDetailedStalls();
            stallsDetailed.ShowDialog();
        }
    }
}
