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
using TheatreSystem08220.CS;

namespace TheatreSystem08220.Windows
{
    /// <summary>
    /// Interaction logic for seatingDetailedStalls.xaml
    /// </summary>
    public partial class seatingDetailedStalls : Window
    {
        private List<Button> buttons;
        private List<Button> selected;
        private Main mainWindow;

        public seatingDetailedStalls(Main main, Performance p)
        {
            InitializeComponent();
            InitializeButtons(p);
            mainWindow = main;
        }

        public void InitializeButtons(Performance p)
        {
            buttons = new List<Button>();
            selected = new List<Button>();
            foreach (WrapPanel w in innerButtonsGrid.Children.OfType<WrapPanel>())
            {
                foreach (Button b in w.Children.OfType<Button>())
                {
                    if (b.Content.ToString() != "")
                    {
                        buttons.Add(b);
                        b.IsHitTestVisible = true;
                        b.Background = Brushes.LightGray;
                    }
                }
            }
            List<Seat> reserved = new List<Seat>();
            foreach (Seat s in p.getScreen().getStallsList())
            {
                if (s.isReserved())
                    reserved.Add(s);
            }
            foreach (Seat r in reserved)
            {
                string content = r.getRow() + r.getColumn().ToString();
                for (int i = 0; i < buttons.Count; ++i)
                {
                    if (content == (string)buttons[i].Content)
                    {
                        buttons[i].Background = Brushes.Red;
                        buttons[i].IsHitTestVisible = false;
                    }
                }
            }
            buttons.ForEach(b => b.Click += button_Click);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (!selected.Contains(b))
            {
                if (selected.Count < 6)
                {
                    selected.Add(b);
                    b.Background = Brushes.Yellow;
                }
                else
                {
                    MessageBox.Show("Too many seats selected. Maximum of 6 seats per reservation. Please remove some.");
                }
            }
            else
            {
                selected.Remove(b);
                b.Background = Brushes.LightGray;
            }

        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if (selected.Count > 0)
            {
                this.Close();
                Seat[] seatsSelected = new Seat[selected.Count];
                int count = 0;
                foreach (Button b in selected)
                {
                    string seatString = b.Content.ToString();
                    char row = seatString[0];
                    seatString = seatString.Substring(1);
                    int column = int.Parse(seatString);
                    int price = 3; ///TODO replace this with getPrice on performance/screen.
                    seatsSelected[count] = new Seat(row, column, seatType.stalls, price, true);
                    count++;
                }
                mainWindow.bookingConfirm(seatsSelected);
            }
            else {
                MessageBox.Show("No seats selected. Please select the seat/s you wish to add to reservation and press continue, or close the window to cancel.");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button b in selected)
            {
                b.Background = Brushes.LightGray;
            }
            selected.Clear();
        }
    }
}
