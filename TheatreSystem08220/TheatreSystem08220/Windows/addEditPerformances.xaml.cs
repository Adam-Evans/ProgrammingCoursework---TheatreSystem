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
using TheatreSystem08220.CS;

namespace TheatreSystem08220.Windows
{
    /// <summary>
    /// Interaction logic for addEditPerformances.xaml
    /// </summary>
    public partial class addEditPerformances : Window
    {

        static bool isEditMode = false;
        static string id = "";
        static Theatre thisTheatre;
         
        public addEditPerformances(Theatre theatre)
        {
            InitializeComponent();
            deleteButton.IsEnabled = false;
            isEditMode = false;
            id = "";
            thisTheatre = theatre;
        }

        public addEditPerformances(string pId, Theatre theatre)
        {
            InitializeComponent();
            deleteButton.IsEnabled = true;
            isEditMode = true;
            id = pId;
            int idInt = int.Parse(id);
            Performance p = theatre.getPerformances().Find(x => x.getID() == idInt);
            Screen s = p.getScreen();
            priceUpper.Text = s.getUpperPrice().ToString();
            priceStalls.Text = s.getStallsPrice().ToString();
            priceDress.Text = s.getDressPrice().ToString();
            titleBox.Text = p.getTitle();
            descriptionBox.Text = p.getDescription();
            dateBox.Text = p.getDate().ToString("dd/MM/yyyy HH:mm");
            thisTheatre = theatre;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            thisTheatre.deletePerformanceEntry(id);
            thisTheatre.getPerformances().Remove(thisTheatre.getPerformances().Find(x => x.getID() == int.Parse(id)));
        }

        private void addDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate != null)
            {
                if (isEditMode)
                {
                    DateTime date = (DateTime)datePicker.SelectedDate;
                    dateBox.Text = string.Format("{0} 21:00", date.ToString("dd/MM/yyyy"));
                }
                else {
                    if (dateBox.Text != "")
                    {
                        DateTime date = (DateTime)datePicker.SelectedDate;
                        dateBox.Text += string.Format(", {0} 21:00", date.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        DateTime date = (DateTime)datePicker.SelectedDate;
                        dateBox.Text += string.Format("{0} 21:00", date.ToString("dd/MM/yyyy"));
                    }
                }
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkCanSave())
            {

                if (isEditMode) // in edit mode, replace existing details with modified.
                {
                    int idInt = 0;
                    int.TryParse(id, out idInt);
                    if (idInt != 0)
                    {
                        Performance p = thisTheatre.getPerformances().Find(x => x.getID() == idInt);
                        
                        DateTime date = new dateConverter().stringToDate(dateBox.Text);
                        Screen s = p.getScreen();
                        s.setDressPrice(float.Parse(priceDress.Text));
                        s.setStallsPrice(float.Parse(priceStalls.Text));
                        s.setUpperPrice(float.Parse(priceUpper.Text));
                        Performance temp = new Performance(idInt, titleBox.Text, descriptionBox.Text, date, s);
                        thisTheatre.deletePerformanceEntry(id);
                        thisTheatre.getPerformances().Remove(p);
                        thisTheatre.addPerformance(temp);
                        MessageBox.Show("Updated Performance.");
                        this.Close();
                    }
                }
                else // not in edit mode, add new performance. 
                {
                    string[] dates = dateBox.Text.Split(',').ToArray();
                    List<DateTime> dateList = new List<DateTime>();
                    for (int i = 0; i < dates.Length; ++i)
                    {
                        DateTime date = new dateConverter().stringToDate(dates[i]);
                        if (dateList.Contains(date))
                            break;
                        dateList.Add(date);
                        Performance newPerf = new Performance(titleBox.Text, descriptionBox.Text, date, float.Parse(priceUpper.Text), float.Parse(priceDress.Text), float.Parse(priceStalls.Text));
                        thisTheatre.addPerformance(newPerf);                      
                    }
                    MessageBox.Show("New performance/s added succesfully.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please ensure all details have been entered.");
            }
        }

        bool checkCanSave()
        {
            if (!checkRegexMatch(priceStalls.Text))
                return false;
            if (!checkRegexMatch(priceDress.Text))
                return false;
            if (!checkRegexMatch(priceUpper.Text))
                return false;
            if (titleBox.Text != "")
                if (descriptionBox.Text != "")
                    if (dateBox.Text != "")
                        return true;
            return false;
        }

        private void priceStalls_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!checkRegexMatch(priceStalls.Text))
            { 
                priceStalls.Text = "";
                MessageBox.Show("Please enter a price in the form '##.##'.");
            }
                

        }

        private void priceUpper_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!checkRegexMatch(priceUpper.Text))
            {
                priceUpper.Text = "";
                MessageBox.Show("Please enter a price in the form '##.##'.");
            }
        }

        private void priceDress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!checkRegexMatch(priceDress.Text))
            {
                priceDress.Text = "";
                MessageBox.Show("Please enter a price in the form '##.##'.");
            }
        }

        private bool checkRegexMatch(string s)
        {
            string[] entry = s.Split('.');
            if (s == "")
                return false;
            if (entry.Length > 2)
                return false;
            if (s.Any(char.IsLetter))
                return false;
            if (entry.Length == 2)
            {
                if (entry[1].Length > 2)
                    return false;
            }
            return true;
        }
    }
}
