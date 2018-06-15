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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheatreSystem08220;

namespace TheatreSystem08220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void playScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Schedule scheduleWindow = new Windows.Schedule();
            scheduleWindow.ShowDialog();
        }

        private void bookingButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Seating_View seatingWindow = new Windows.Seating_View();
            seatingWindow.ShowDialog();
        }
    }

}
