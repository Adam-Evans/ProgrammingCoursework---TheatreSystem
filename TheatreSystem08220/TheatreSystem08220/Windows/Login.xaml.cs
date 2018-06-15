using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SQLite;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheatreSystem08220
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SQLiteConnection loginDB;
        string sql;

        public Login()
        {
            InitializeComponent();
            string filePath = @"Data\loginDB.sqlite";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = System.IO.Path.Combine(directory, filePath);
            loginDB = new SQLiteConnection(string.Format("Data Source={0};Version=3; FailIfMissing=True", connection), true);
            loginDB.Open();
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernametextBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            checklogin();
        }

        private void checklogin() {
            sql = "SELECT * from Login where User='" + UsernametextBox.Text + "' and Pass='" + passwordBox.Password + "' ";
            SQLiteCommand sqlcom = new SQLiteCommand(sql, loginDB);
            sqlcom.ExecuteNonQuery();
            SQLiteDataReader dr = sqlcom.ExecuteReader();

            int count = 0, level = 0;
            while (dr.Read())
            {
                count++;
                level = dr.GetInt32(2);
            }
            if (count == 1) {   // login successful
                Windows.Main main = new Windows.Main(level);
                main.Show();
                this.Close();
            }
            if (count < 1) {    // wrong login details
                MessageBox.Show("Invalid username or password.");
            }
            if (count > 1) {    // too many results i.e something cocked up in database. 
                MessageBox.Show("Oh This isn't meant to happen. God help you.");
            }
        }
    }
}
