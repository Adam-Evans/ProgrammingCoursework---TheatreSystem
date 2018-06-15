using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Markup; 
using System.IO;
using System.Windows.Forms;
using TheatreSystem08220.CS;
using System.ComponentModel;

namespace TheatreSystem08220.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        static Theatre thisTheatre;
        static List<Performance> upcoming;

        public Main()
        {
            InitializeComponent();
            tabControl.Items.Remove(scheduleTab);
            tabControl.Items.Remove(bookingTab);
            tabControl.Items.Remove(confirmBookingTab);
            tabControl.Items.Remove(reportTab);
            tabControl.Items.Remove(newsletterTab);
            LoadTheatre(thisTheatre);
            upcoming = thisTheatre.findPerformancesAfterDate(DateTime.Now);
        }

        public Main(int level)
        {
            InitializeComponent();
            tabControl.Items.Clear();
            tabControl.Items.Add(homeTab);
            thisTheatre = new Theatre();
            LoadTheatre(thisTheatre);
            //testEntries testAdd = new testEntries(thisTheatre, 5000, 75);   // change these values to add more Customers / performances respectively to the system for testing purposes.
            saveTheatre(thisTheatre);
            upcoming = thisTheatre.findPerformancesAfterDate(DateTime.Now);
            switch (level)
            {
                case 1: // admin level

                    bookingButton.Visibility = Visibility.Visible;
                    playScheduleButton.Visibility = Visibility.Visible;                 // there are ABSOLUTELY better ways to do this but I offered a goat to the code gods for this lazy solution, they said they were cool with it so ¯\_(ツ)_/¯
                    newsletterButton.Visibility = Visibility.Visible;
                    reportsButton.Visibility = Visibility.Visible;
                    break;
                case 2: //  manager level
                    newsletterButton.Visibility = Visibility.Collapsed;
                    fileNewNewsletter.Visibility = Visibility.Collapsed;
                    bookingButton.Visibility = Visibility.Visible;
                    playScheduleButton.Visibility = Visibility.Visible;
                    reportsButton.Visibility = Visibility.Visible;
                    break;
                case 3: // booking officer level
                    newsletterButton.Visibility = Visibility.Collapsed;
                    fileNewNewsletter.Visibility = Visibility.Collapsed;
                    reportsButton.Visibility = Visibility.Collapsed;
                    fileNewReports.Visibility = Visibility.Collapsed;
                    bookingButton.Visibility = Visibility.Visible;
                    playScheduleButton.Visibility = Visibility.Visible;
                    break;
                case 4: // newsletter manager level
                    newsletterButton.Visibility = Visibility.Visible;
                    reportsButton.Visibility = Visibility.Collapsed;
                    fileNewReports.Visibility = Visibility.Collapsed;
                    bookingButton.Visibility = Visibility.Collapsed;
                    fileNewBooking.Visibility = Visibility.Collapsed;
                    playScheduleButton.Visibility = Visibility.Collapsed;
                    break;
                case 5: // rep level
                    reportsButton.Visibility = Visibility.Collapsed;
                    fileNewReports.Visibility = Visibility.Collapsed;
                    playScheduleButton.Visibility = Visibility.Collapsed;
                    fileNewPerformance.Visibility = Visibility.Collapsed;
                    newsletterButton.Visibility = Visibility.Collapsed;
                    fileNewNewsletter.Visibility = Visibility.Collapsed;
                    bookingButton.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This was originally going to be used for shortcuts for more advanced users to complete tasks in less steps however due to time constraints was not fully implemented.");
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////SCHEDULING////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

        private void playScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (!tabControl.Items.Contains(scheduleTab))
            {
                tabControl.Items.Add(scheduleTab);
            }
            initialiseScheduleListBox();
            tabControl.SelectedItem = scheduleTab;
        }

        private void initialiseScheduleListBox()
        {
            schUpcomingListBox.Items.Clear();
            schSearchPerformanceResultListBox.Items.Clear();
            DateTime now = DateTime.Now;
            upcoming = thisTheatre.findPerformancesAfterDate(now);
            foreach (Performance p in upcoming)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                i.FontSize = 16;
                i.ToolTip = p.getID() + ": " + p.getDescription();
                schUpcomingListBox.Items.Add(i);
            }
        }

        private void schIdSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (schIdInputTXT.Text != "")
            {
                schSearchPerformanceResultListBox.Items.Clear();
                int id = 0;
                int.TryParse(schIdInputTXT.Text, out id);
                if (id != 0)
                {
                    Performance display = thisTheatre.findPerformance(id);
                    if (display.getID() != 0)
                    {
                        ListBoxItem item = new ListBoxItem();
                        item.Content = display.getTitle() + " - " + display.getDate().ToString("dd/MM/yyyy HH.mm");
                        item.ToolTip = display.getID() + ": " + display.getDescription();
                        item.FontSize = 16;
                        schSearchPerformanceResultListBox.Items.Add(item);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No results found for that ID.");
                    }
                }
                else {
                    System.Windows.MessageBox.Show("Invalid ID entered.");
                }
            }
            else
            {
                initialiseScheduleListBox();
            }
        }


        private void schEditPerfButton_Click(object sender, RoutedEventArgs e)
        {
            if (schSearchPerformanceResultListBox.Items.Count == 0)
            {
                if (schUpcomingListBox.Items.Count != 0)
                {
                    if (schUpcomingListBox.SelectedIndex >= 0)
                    {
                        ListBoxItem selected = (ListBoxItem)schUpcomingListBox.Items[schUpcomingListBox.SelectedIndex];
                        string id = selected.ToolTip.ToString().Split(':')[0];
                        addEditPerformances editWindow = new addEditPerformances(id, thisTheatre);
                        editWindow.ShowDialog();
                        initialiseBookingUpcoming();
                    }
                    else {
                        ListBoxItem selected = (ListBoxItem)schUpcomingListBox.Items[0];
                        string id = selected.ToolTip.ToString().Split(':')[0];
                        addEditPerformances editWindow = new addEditPerformances(id, thisTheatre);
                        editWindow.ShowDialog();
                        initialiseBookingUpcoming();
                    }
                }
            }
            else {
                if (schUpcomingListBox.SelectedIndex >= 0)
                {
                    ListBoxItem selected = (ListBoxItem)schSearchPerformanceResultListBox.Items[schSearchPerformanceResultListBox.SelectedIndex];
                    string id = selected.ToolTip.ToString().Split(':')[0];
                    addEditPerformances editWindow = new addEditPerformances(id, thisTheatre);
                    editWindow.ShowDialog();
                    initialiseBookingUpcoming();
                }
                else {
                    ListBoxItem selected = (ListBoxItem)schSearchPerformanceResultListBox.Items[0];
                    string id = selected.ToolTip.ToString().Split(':')[0];
                    addEditPerformances editWindow = new addEditPerformances(id, thisTheatre);
                    editWindow.ShowDialog();
                    initialiseBookingUpcoming();
                }
            }
            
        }

        private void schAddPerfButton_Click(object sender, RoutedEventArgs e)
        {
            addEditPerformances addWindow = new addEditPerformances(thisTheatre);
            addWindow.ShowDialog();
            initialiseBookingUpcoming();
        }

        private void CheckNumericOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^\d]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void schSearchDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            schSearchPerformanceResultListBox.Items.Clear();
            Performance[] found = thisTheatre.findPerformancesByMonth((DateTime)schSearchDatePicker.SelectedDate);
            for (int i = 0; i < found.Length; ++i)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = found[i].getTitle() + " - " + found[i].getDate().ToString("dd/MM/yyyy HH.mm");
                item.FontSize = 16;
                item.ToolTip = found[i].getID() + ": " + found[i].getDescription();
                schSearchPerformanceResultListBox.Items.Add(item);
            }
        }

        private void schExitButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(scheduleTab);
            tabControl.SelectedItem = homeTab;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////BOOKING///////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

        private void bookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (!tabControl.Items.Contains(bookingTab))
                tabControl.Items.Add(bookingTab);
            initialiseBookingUpcoming();
        }

        private void initialiseBookingUpcoming()
        {
            bookingUpcomingListBox.Items.Clear();
            upcoming = thisTheatre.findPerformancesAfterDate(DateTime.Now);
            foreach (Performance p in upcoming)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                i.FontSize = 16;
                i.ToolTip = p.getID() + ": " + p.getDescription();
                bookingUpcomingListBox.Items.Add(i);
            }
            tabControl.SelectedItem = bookingTab;
            bookingUpcomingListBox.SelectedIndex = 0;
            if (bookingUpcomingListBox.Items.Count > 0)
            {
                updateBookingSeatCount(0);

                bookingStallsButton.IsEnabled = true;
                bookingUpperCircleButton.IsEnabled = true;
                bookingDressCircleButton.IsEnabled = true;
            }
            else
            {
                bookingStallsButton.IsEnabled = false;
                bookingUpperCircleButton.IsEnabled = false;
                bookingDressCircleButton.IsEnabled = false;
            }
        }

        private void bookingDateSearch_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            bookingUpcomingListBox.Items.Clear();
            DateTime date = (DateTime)bookingDateSearch.SelectedDate;
            upcoming = thisTheatre.findPerformancesAfterDate(date);
            foreach (Performance p in upcoming)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                i.FontSize = 16;
                i.ToolTip = p.getID() + ": " + p.getDescription();
                bookingUpcomingListBox.Items.Add(i);
            }
            bookingUpcomingListBox.SelectedIndex = 0;
            if (bookingUpcomingListBox.Items.Count > 0)
            {
                updateBookingSeatCount(0);

                bookingStallsButton.IsEnabled = true;
                bookingUpperCircleButton.IsEnabled = true;
                bookingDressCircleButton.IsEnabled = true;
            }
            else
            {
                bookingStallsButton.IsEnabled = false;
                bookingUpperCircleButton.IsEnabled = false;
                bookingDressCircleButton.IsEnabled = false;
            }
        }

        private void bookingIdSearchButton_Click(object sender, RoutedEventArgs e)
        {
            int idInt = 0;
            int.TryParse(bookingIdInputTXT.Text, out idInt);
            if (idInt != 0)
            {
                Performance result = thisTheatre.getPerformances().Find(x => x.getID() == idInt);
                if (result != null)
                {
                    bookingUpcomingListBox.Items.Clear();
                    ListBoxItem i = new ListBoxItem();
                    i.Content = result.getTitle() + " - " + result.getDate().ToString("dd/MM/yyyy HH.mm");
                    i.FontSize = 16;
                    i.ToolTip = result.getID() + ": " + result.getDescription();
                    bookingUpcomingListBox.Items.Add(i);
                    bookingUpcomingListBox.SelectedIndex = 0;
                    if (bookingUpcomingListBox.Items.Count > 0)
                    {
                        updateBookingSeatCount(0);

                        bookingStallsButton.IsEnabled = true;
                        bookingUpperCircleButton.IsEnabled = true;
                        bookingDressCircleButton.IsEnabled = true;
                    }
                    else
                    {
                        bookingStallsButton.IsEnabled = false;
                        bookingUpperCircleButton.IsEnabled = false;
                        bookingDressCircleButton.IsEnabled = false;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("No Performance found with that ID.");
                }
            }
            else
            {
                initialiseBookingUpcoming();
            }
        }

        private void bookingUpcomingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = bookingUpcomingListBox.SelectedIndex;
            if (index >= 0 && bookingUpcomingListBox.Items.Count > 0)
                updateBookingSeatCount(index);
        }

        private void updateBookingSeatCount(int index)
        {
            if (upcoming[index] != null)
            {
                bookingUpperCountTXT.Text = string.Format("{0} of 110", upcoming[index].getScreen().getUpperRemaining());
                bookingDressCountTXT.Text = string.Format("{0} of 137", upcoming[index].getScreen().getDressRemaining());
                bookingStallsCountTXT.Text = string.Format("{0} of 239", upcoming[index].getScreen().getStallsRemaining());
            }
        }

        private void upperCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookingUpcomingListBox.Items.Count != 0)
            {
                if (upcoming[bookingUpcomingListBox.SelectedIndex] != null)
                {
                    Window upperDetailed = new seatingDetailedUpper(this, upcoming[bookingUpcomingListBox.SelectedIndex]);
                    upperDetailed.ShowDialog();
                }
            }
        }

        private void dressCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookingUpcomingListBox.Items.Count != 0)
            {
                if (upcoming[bookingUpcomingListBox.SelectedIndex] != null)
                {
                    Window dressDetailed = new seatingDetailedDress(this, upcoming[bookingUpcomingListBox.SelectedIndex]);
                    dressDetailed.ShowDialog();
                }
            }
        }

        private void stallsButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookingUpcomingListBox.Items.Count != 0)
            {
                if (upcoming[bookingUpcomingListBox.SelectedIndex] != null)
                {
                    Window stallsDetailed = new seatingDetailedStalls(this, upcoming[bookingUpcomingListBox.SelectedIndex]);
                    stallsDetailed.ShowDialog();
                }
            }
        }



        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////CONFIRM BOOKING///////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///


        public void bookingConfirm(Seat[] seats)
        {
            if (!tabControl.Items.Contains(confirmBookingTab))
                tabControl.Items.Add(confirmBookingTab);
            tabControl.SelectedItem = confirmBookingTab;
            float price = 0;
            string seatText = string.Format("{0}:", seats[0].getType().ToString());
             
            for (int i = 0; i < seats.Length; i++)
            {
                price += seats[i].getPrice();
                seatText += seats[i].getRow() + seats[i].getColumn().ToString();
                if (i != seats.Length - 1)
                {
                    seatText += ",";
                }
            }
            if ((bool)confirmGoldMemberCheckBox.IsChecked || (bool)confirmAddNewGoldCheckBox.IsChecked)
            {
                price *= 0.9f;
            }
            if ((bool)confirmAddNewGoldCheckBox.IsChecked)
            {
                price += 5;
            }
            confirmAddNewGoldCheckBox.IsEnabled = true;
            confirmSeatNumbersDisplay.Text = seatText;
            confirmPerfTitleDisplay.Text = string.Format("{0} - {1}", upcoming[bookingUpcomingListBox.SelectedIndex].getID(), upcoming[bookingUpcomingListBox.SelectedIndex].getTitle());
            confirmPriceText.Text = string.Format("£{0}", price.ToString(".00"));
        }

        private void bookingBackButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(bookingTab);
            tabControl.SelectedItem = homeTab;
        }

        private void confirmSearchAccountsButton_Click(object sender, RoutedEventArgs e)
        {
            checkExistingCustomer();
        }

        private void confirmApplyBillingAddressButton_Click(object sender, RoutedEventArgs e)
        {
            billingAddressIn1.Text = confirmAddressIn1.Text;
            billingAddressIn2.Text = confirmAddressIn1.Text;
            billingPostcodeIn.Text = confirmPostcodeIn.Text;
        }

        private void checkExistingCustomer()
        {
            if (confirmIDsearchBox.Text != "")          // Ideally we would search by customer ID, this is much easier and as ID is unique to the customer it will be accurate to find one particualar customer. 
            {
                int id;
                int.TryParse(confirmIDsearchBox.Text, out id);
                Customer result = thisTheatre.getCustomers().Find(x => x.getID() == id);
                if (result == null)
                {
                    System.Windows.MessageBox.Show("No customer with that ID was found.");
                }
                else
                {
                    fillForm(result);
                }
            }
            else if (confirmFirstNameTXT.Text != "")        // if the customer does not have/know their ID we can also search by reduction. First all customers of same name are added to a list where they will be reduced until hopefully one remains. 
            {
                if (confirmLastNameTXT.Text != "")
                {
                    if (confirmPostcodeIn.Text != "")
                    {
                        string fName = confirmFirstNameTXT.Text;
                        string lName = confirmLastNameTXT.Text;
                        string pCode = confirmPostcodeIn.Text;
                        List<Customer> results = new List<Customer>();

                        foreach (Customer c in thisTheatre.getCustomers())
                        {
                            if (c.getPostcode() == pCode)
                            {
                                results.Add(c);
                            }
                        }
                        foreach (Customer c in results)
                        {
                            if (c.getFirstName() != fName)
                            {
                                results.Remove(c);
                                break;
                            }
                            if (c.getSurname() != lName)
                            {
                                results.Remove(c);
                            }
                       }
                        if (results.Count > 1)      // if there are more than one result at this point we can reduce by address.
                        {
                            if (confirmAddressIn1.Text != "")
                            {
                                string address = confirmAddressIn1.Text;
                                if (confirmAddressIn2.Text != "")
                                {
                                    address += string.Format(", {0}", confirmAddressIn2.Text);
                                }
                                foreach (Customer c in results)
                                {
                                    if (c.getAddress() != address)
                                    {
                                        results.Remove(c);
                                    }
                                }
                            }
                        }
                        if (results.Count == 1)
                        {
                            fillForm(results[0]);
                        }
                        else {
                            if (results.Count == 0)
                            {
                                System.Windows.MessageBox.Show("No customer found with these details, a new account will be created.");
                                confirmIDsearchBox.Text = "";
                            }
                            else {
                                System.Windows.MessageBox.Show("Too many results where found with the given criteria. Try adding an Address to the search details or enquire about the customers ID.");
                            }
                            
                        }
                    }
                    else {
                        System.Windows.MessageBox.Show("ID or first name, last name and postcode are required to search. Please enter the missing details to continue.");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("ID or first name, last name and postcode are required to search. Please enter the missing details to continue.");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("ID or first name, last name and postcode are required to search. Please enter the missing details to continue.");
            }
        }

       

        private void fillForm(Customer cust)
        {
            confirmFirstNameTXT.Text = cust.getFirstName();
            confirmLastNameTXT.Text = cust.getSurname();
            confirmGoldMemberCheckBox.IsChecked = cust.isGold();
            if (cust.isGold())
            {
                confirmGoldJoinDateTXT.Text = cust.getGoldDate().ToString("dd/MM/yyyy");
                confirmAddNewGoldCheckBox.IsEnabled = false;
            }
            string[] address = cust.getAddress().Split(',');
            confirmAddressIn1.Text = address[0];
            if (address.Length > 1)
            {
                confirmAddressIn2.Text = address[1];
            }
            confirmPostcodeIn.Text = cust.getPostcode();
        }


        private void confirmReservationButton_Click(object sender, RoutedEventArgs e)
        {
            if (confirmFirstNameTXT.Text != "")
            {
                if (confirmLastNameTXT.Text != "")
                {
                    if (confirmAddressIn1.Text != "")
                    {
                        if (confirmPostcodeIn.Text != "")
                        {
                            if (confirmIDsearchBox.Text != "")
                            {
                                addReservation(confirmIDsearchBox.Text);
                                closeConfirm();
                            }
                            else
                            {
                                addReservation();
                                System.Windows.MessageBox.Show("New Reservation was added successfully.");
                                closeConfirm();
                            }
                        }
                        else
                            System.Windows.MessageBox.Show("Please ensure all important details have been entered.");
                    }
                    else
                        System.Windows.MessageBox.Show("Please ensure all important details have been entered.");
                }
                else
                    System.Windows.MessageBox.Show("Please ensure all important details have been entered.");
            }
            else
                System.Windows.MessageBox.Show("Please ensure all important details have been entered.");
        }

        private void addReservation()
        {
            string firstName = confirmFirstNameTXT.Text;
            string lastName = confirmLastNameTXT.Text;
            string address = string.Format("{0}, {1}", confirmAddressIn1.Text, confirmAddressIn2.Text);
            string postCode = confirmPostcodeIn.Text;
            bool gold = false;
            string[] seating = confirmSeatNumbersDisplay.Text.Split(':');
            string[] seatNumbers = seating[1].Split(',');
            List<Seat> seatList = new List<Seat>();
            for (int i = 0; i < seatNumbers.Length; ++i)
            {
                string seatString = seating[0] + ":";
                seatString += seatNumbers[i] + ":";
                seatString += upcoming[bookingUpcomingListBox.SelectedIndex].getPrice(seating[0]) + ":";
                seatString += "true";
                Seat temp = new Seat().stringToSeat(seatString);
                seatList.Add(temp);
            }
            if ((bool)confirmAddNewGoldCheckBox.IsChecked)
            {
                gold = true;
            }
            DateTime time = DateTime.Now;
            string perf = upcoming[bookingUpcomingListBox.SelectedIndex].getID() + "-" + upcoming[bookingUpcomingListBox.SelectedIndex].getTitle();
            bool paid;
            switch (confirmPaymentMethodCombo.SelectedIndex)
            {
                case 0:
                    paid = true;
                    break;
                case 1:
                    paid = true;
                    break;
                case 2:
                    paid = true;
                    break;
                case 3:
                    paid = false;
                    break;
                default:
                    paid = false;
                    break;
            }
            Customer cust = new Customer(firstName, lastName, address, postCode, gold, time);
            cust.addReservation(perf, seatList, paid, DateTime.Now);
            thisTheatre.getCustomers().Add(cust);
            thisTheatre.getPerformances().Find(x => x.getID() == upcoming[bookingUpcomingListBox.SelectedIndex].getID()).addReservation(seatList);
        }

        public void addReservation(string id)
        {
            int ID = 0;
            int.TryParse(id, out ID);
            if (ID != 0)     //find by id, if id != customer then new customer  
            {
                Customer result = thisTheatre.getCustomers().Find(x => x.getID() == ID);
                if (result != null)
                {
                    string perf = upcoming[bookingUpcomingListBox.SelectedIndex].getID() + "-" + upcoming[bookingUpcomingListBox.SelectedIndex].getTitle();
                    string[] seating = confirmSeatNumbersDisplay.Text.Split(':');
                    string[] seatNumbers = seating[1].Split(',');
                    List<Seat> seatList = new List<Seat>();
                    for (int i = 0; i < seatNumbers.Length; ++i)
                    {
                        string seatString = seating[0] + ":";
                        seatString += seatNumbers[i] + ":";
                        seatString += upcoming[bookingUpcomingListBox.SelectedIndex].getPrice(seating[0]) + ":";
                        seatString += "true";
                        Seat temp = new Seat().stringToSeat(seatString);
                        seatList.Add(temp);
                    }
                    bool paid;
                    switch (confirmPaymentMethodCombo.SelectedIndex)
                    {
                        case 0:
                            paid = true;
                            break;
                        case 1:
                            paid = true;
                            break;
                        case 2:
                            paid = true;
                            break;
                        case 3:
                            paid = false;
                            break;
                        default:
                            paid = false;
                            break;
                    }
                    thisTheatre.getCustomers().Find(x => x.getID() == ID).addReservation(perf, seatList, paid, DateTime.Now);
                    thisTheatre.getPerformances().Find(x => x.getID() == upcoming[bookingUpcomingListBox.SelectedIndex].getID()).addReservation(seatList);
                }
            }
            else {
                addReservation();
            }
        }

        private void closeConfirm()
        {
            confirmFirstNameTXT.Text = "";
            confirmLastNameTXT.Text = "";
            confirmAddressIn1.Text = "";
            confirmAddressIn2.Text = "";
            confirmPostcodeIn.Text = "";
            confirmPaymentMethodCombo.SelectedItem = null;
            billingAddressIn1.Text = "";
            billingAddressIn2.Text = "";
            billingPostcodeIn.Text = "";
            confirmGoldJoinDateTXT.Text = "dd/mm/yyyy";
            confirmGoldMemberCheckBox.Content = false;
            confirmAddNewGoldCheckBox.Content = false;
            tabControl.Items.Remove(confirmBookingTab);
            tabControl.SelectedItem = homeTab;
        }

        private void confirmBookExitButton_Click(object sender, RoutedEventArgs e)
        {
            closeConfirm();
        }   

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////NEWSLETTER////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

        private void newsletterButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.Items.Contains(newsletterTab))
            {
                tabControl.SelectedItem = newsletterTab;
            }
            else
            {
                tabControl.Items.Add(newsletterTab);
                fillGoldMembersList();
                tabControl.SelectedItem = newsletterTab;
            }
        }

        private void fillGoldMembersList()
        {
            List<string> goldMembers = new List<string>();
            foreach (Customer c in thisTheatre.getCustomers())
            {
                if (c.isGold())
                    goldMembers.Add(c.getFullName());
            }
            foreach (string s in goldMembers)
            {
                newsGoldMemberListTXT.Items.Add(s);
            }
        }

        private void openNewsletter_Click(object sender, RoutedEventArgs e)
        {
        
            var fileOpenDialog = new OpenFileDialog();
            string filePath = @"News\";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = Path.Combine(directory, filePath);
            bool exists = Directory.Exists(connection);
            if (!exists)
                Directory.CreateDirectory(connection);
            fileOpenDialog.DefaultExt = "*.rtf";
            fileOpenDialog.Filter = "RTF Files|*.rtf";
            fileOpenDialog.InitialDirectory = connection;
            var result = fileOpenDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    FileStream input = new FileStream(fileOpenDialog.FileName, FileMode.OpenOrCreate);
                    newsletterRichText.SelectAll();
                    newsletterRichText.Selection.Load(input, System.Windows.Forms.DataFormats.Rtf);
                    input.Close();
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    break;
            }
        }

        private void saveNewsletter_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"News\";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = Path.Combine(directory, filePath);
            bool exists = Directory.Exists(connection);
            if (!exists)
                Directory.CreateDirectory(connection);
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";
            saveFile1.InitialDirectory = connection;

            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.    
                //newsletterRichText.SaveFile(saveFile1.FileName);
                FileStream output = new FileStream(saveFile1.FileName, FileMode.OpenOrCreate);
                newsletterRichText.SelectAll();
                newsletterRichText.Selection.Save(output, System.Windows.Forms.DataFormats.Rtf);
                output.Close();
            }
        } 

        //TODO add a save/load function. Keeping this one simple, save as RTF to preserve text and images. Newsletters cna be opened using the file bar the menu attached to the textbox. 
        // Also add a button to view/clipboard all current goldmembers. 

        private void newsBackButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(newsletterTab);
            tabControl.SelectedItem = homeTab;
        } 

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////REPORTS///////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.Items.Contains(reportTab))
            {
                tabControl.SelectedItem = reportTab;
            }
            else
            {
                tabControl.Items.Add(reportTab);
                populateUpcoming();
                tabControl.SelectedItem = reportTab;
                updateReports();
            }
        }

        private void populateUpcoming()
        {

            reportsUpcomingListbox.Items.Clear();
            DateTime now = DateTime.Now;
            List<Performance> upcoming = thisTheatre.findPerformancesAfterDate(now);
            foreach (Performance p in upcoming)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                i.FontSize = 16;
                i.ToolTip = p.getID() + ": " + p.getDescription();
                reportsUpcomingListbox.Items.Add(i);
            }
        }

        private void reportsUpdateSearchButton_Click(object sender, RoutedEventArgs e)
        {
            updateReports();
        }

        private void updatePerformanceReports(int renewalCount, int goldCount, int performancesInMonth)
        {
            reportsListBox.Items.Clear();
            List<string> reportsList = new List<string>();
            string goldCountString = string.Format("{0} gold club memberships as of {1}", goldCount, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            reportsList.Add(goldCountString);
            string renewalCountString = string.Format("{0} gold club renewals due this month.", renewalCount);
            reportsList.Add(renewalCountString);
            string performancesThisMonthString = string.Format("{0} performances in the month of {1}", performancesInMonth, DateTime.Now.ToString("MM/yyyy"));
            reportsList.Add(performancesThisMonthString);

            string id= "";
            if (reportsUpcomingListbox.Items.Count != 0)
            {
                ListBoxItem i = new ListBoxItem();
                i = (ListBoxItem)reportsUpcomingListbox.SelectedItem;
                if (i == null)
                    i = (ListBoxItem)reportsUpcomingListbox.Items[0];
                id = i.ToolTip.ToString().Split(':')[0];
                Performance searched = thisTheatre.getPerformances().Find(x => x.getID().ToString() == id);
                int reservedSeats = 0;
                string dressSeatsReserved = "Dress: ";
                string upperSeatsReserved = "Upper: ";
                string stallsSeatsReserved = "Seats: ";
                foreach (Seat s in searched.getScreen().getDressList())
                {
                    if (s.isReserved())
                    {
                        reservedSeats++;
                        dressSeatsReserved += (s.getRow().ToString() + s.getColumn().ToString() + ", ");
                    }
                }
                foreach (Seat s in searched.getScreen().getUpperList())
                {
                    if (s.isReserved())
                    {
                        reservedSeats++;
                        upperSeatsReserved += (s.getRow().ToString() + s.getColumn().ToString() + ", ");
                    }
                }
                foreach (Seat s in searched.getScreen().getStallsList())
                {
                    if (s.isReserved())
                    {
                        reservedSeats++;
                        stallsSeatsReserved += (s.getRow().ToString() + s.getColumn().ToString() + ", ");
                    }
                }
                string seatsSold = string.Format("{0} seats reserved for the showing of {1} (id = {2}) at {3}", reservedSeats, searched.getTitle(), searched.getID(), searched.getDate().ToString("dd:MM:yyyy HH:mm"));
                reportsList.Add(seatsSold);
                reportsList.Add(dressSeatsReserved);
                reportsList.Add(upperSeatsReserved);
                reportsList.Add(stallsSeatsReserved);
                  // TODO use id generated here to find performance, fill out remainging detials using this performance. ALSO use this method (like the exact same thing) on scheduling 
                                                            //and booking to search functions, they don't actually allow the user to select or do anything at the moment. Add list of goldmembers to newsletter listbox.
            }

            foreach (string s in reportsList)
            {
                reportsListBox.Items.Add(s);
            }
        }



        private void reportsSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (reportsIdSearch.Text != "") // search by ID
            {
                reportsUpcomingListbox.Items.Clear();
                int id = 0;
                int.TryParse(reportsIdSearch.Text, out id);
                if (id == 0) {
                    updateReports();
                    System.Windows.MessageBox.Show("Invalid Id entered, Id is numerical only.");                 
                } 
                else {
                    Performance p = thisTheatre.getPerformances().Find(x => x.getID() == id);   // if a valid Id has been entered we can update the listbox to contain just the entry. 
                    if (p != null)
                    {
                        ListBoxItem i = new ListBoxItem();
                        i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                        i.FontSize = 16;
                        i.ToolTip = p.getID() + ": " + p.getDescription();
                        reportsUpcomingListbox.Items.Add(i);
                    }
                     else
                    {
                        updateReports();
                    }
                }
                   
            }
            else if (reportsDateSearch.SelectedDate != null)
            {
                reportsUpcomingListbox.Items.Clear();
                List<Performance> results = new List<Performance>();
                foreach (Performance p in upcoming)
                {
                    if (p.getDate() > reportsDateSearch.SelectedDate)
                    {
                        results.Add(p);
                    }
                }
                if (results.Count != 0)
                {
                    results.Sort((x, y) => x.getDate().CompareTo(y.getDate()));
                    foreach (Performance p in results)
                    {
                        ListBoxItem i = new ListBoxItem();
                        i.Content = p.getTitle() + " - " + p.getDate().ToString("dd/MM/yyyy HH.mm");
                        i.FontSize = 16;
                        i.ToolTip = p.getID() + ": " + p.getDescription();
                        reportsUpcomingListbox.Items.Add(i);
                    }
                }
                else {
                    System.Windows.MessageBox.Show("No Performances found past the selected date.");
                    updateReports();
                }
            }
            else
            {
                updateReports();
            }
        }

        private void updateReports()
        {
            DateTime now = DateTime.Now;
            int renewalCount = 0;
            int goldCount = 0;
            foreach (Customer c in thisTheatre.getCustomers())
            {
                if (c.isGold())
                {
                    goldCount++;
                    if (c.getGoldDate().Year == now.Year - 1 && c.getGoldDate().Month == now.Month)
                    {
                        renewalCount++;
                    }
                }
                
            }
            int performancesThisMonth = 0;
            foreach (Performance p in upcoming)
            {
                if (p.getDate().Month == DateTime.Now.Month)
                {
                    if (p.getDate().Year == DateTime.Now.Year)
                    {
                        ++performancesThisMonth;
                    }
                }
            }
            updatePerformanceReports(renewalCount, goldCount, performancesThisMonth);
        }

        private void reportsBackButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(reportTab);
            tabControl.SelectedItem = homeTab;
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// ////////////////////////////////////////////////////////////////////////////////DATA HANDLING/////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

        /// AKA let that other class handle this stuff, Main is messy enough as it is.
        public void saveTheatre(Theatre theatreToSave)
        {
            theatreToSave.saveTheatre();
        }

        public void LoadTheatre(Theatre loadIntoTheatre)
        {
            loadIntoTheatre.loadTheatre();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            saveTheatre(thisTheatre);
        }

        private void confirmAddNewGoldCheckBox_Click(object sender, RoutedEventArgs e)
        {
            float price = 0;
            string priceString = confirmPriceText.Text;
            priceString = priceString.Remove(0, 1);
            float.TryParse(priceString, out price);
            if (price != 0)
            {
                if ((bool)confirmAddNewGoldCheckBox.IsChecked)
                {
                    price += 5;
                    confirmPriceText.Text = string.Format("£{0}", price.ToString(".00"));
                }
                if (!(bool)confirmAddNewGoldCheckBox.IsChecked)
                {
                    price -= 5;
                    confirmPriceText.Text = string.Format("£{0}", price.ToString(".00"));
                }
            }
        }
    }
}
