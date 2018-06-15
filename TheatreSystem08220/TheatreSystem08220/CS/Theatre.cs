using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS // Important comment: make more comments!
{
    public class Theatre
    {
        private List<Performance> performances;
        private List<Customer> customers;

        public Theatre()
        {
            performances = new List<Performance>();
            customers = new List<Customer>();
        }

        public Theatre(List<Performance> pPerformances, List<Customer> pCustomers, List<Staff> pStaff)
        {
            performances = pPerformances;
            customers = pCustomers;
        }

        public List<Performance> getPerformances()
        {
            return performances;
        }

        public List<Customer> getCustomers()
        {
            return customers;
        }

        public int generateNewPerfID()
        {
            Random rnd = new Random();
        nextRandom:
            int id = rnd.Next(0, 100000000);
            if (performances.Count > 1)
            {
                foreach (Performance p in performances)
                {
                    if (id == p.getID())
                    {
                        goto nextRandom;
                    }
                }
            }
            return id;
        }

        public int generateNewCustID()
        {
            Random rnd = new Random();
        nextRandom:
            int id = rnd.Next(0, 100000000);
            if (customers.Count > 1)
            {
                foreach (Customer c in customers)
                {
                    if (id == c.getID())
                    {
                        goto nextRandom;
                    }
                }
            }
            return id;
        }

        public void addPerformance(Performance perf)    //add performance parameter to our list
        {
            if (perf.getID() == 0)
            {
                perf.setID(generateNewPerfID());
            }
            performances.Add(perf);
        }

        public void addCustomer(Customer cust)  //add customer parameter to our list.
        {
            if (cust.getID() == 0)
            {
                cust.setID(generateNewCustID());
            }
            customers.Add(cust);
        }

        public Performance findPerfomance(string title, DateTime date)  // one method of searching for performance by title and date. Another method will be using a unique ID. 
        {
            foreach (Performance p in performances)
            {
                if (p.getTitle() == title)
                {
                    if (p.getDate() == date)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public Performance findPerformance(int id)      // COULD sort entries and use a more efficient search method than linear however as we are sorting sometimes by date and sometimes by ID or title this could actually cause more work!
        {
            foreach (Performance p in performances)
            {
                if (p.getID() == id)
                {
                    return p;
                }
            }
            return new Performance();
        }

        /// <summary>
        /// Date is searched from UI such as finding upcoming performances. We then match all performances that include that month and year and sort them by ascending date. 
        /// </summary>
        /// <param name="dateSearched"></param>
        /// <returns></returns>
        public Performance[] findPerformancesByMonth(DateTime dateSearched)
        {
            List<Performance> list = new List<Performance>();
            Performance[] sortedOut;
            DateTime currentBest = DateTime.Now;
            foreach (Performance p in performances)
            {
                if (dateSearched.Year == p.getDate().Year && dateSearched.Month == p.getDate().Month)
                {
                    if (p.getDate().Day >= dateSearched.Day)
                        list.Add(p);
                }
            }
            sortedOut = list.OrderBy(x => x.getDate().Date).ToArray();
            return sortedOut;
        }

        public List<Performance> findPerformancesAfterDate(DateTime date)
        {
            List<Performance> list = new List<Performance>();
            list = performances.OrderBy(x => x.getDate().Date).ToList();
            for (int i = 0; i < performances.Count; i++)
            {
                if (performances[i].getDate() < date)
                {
                    list.Remove(performances[i]);
                }
            }
            return list;
        }

        public Customer findCustomer(string firstName, string lastName, string Postcode) // search the customers primary details to narrow down results. Note this could be done in SQLite given more time
        {
            foreach (Customer c in customers)
            {
                if (c.getFirstName() == firstName)
                {
                    if (c.getSurname() == lastName)
                    {
                        if (c.getPostcode() == Postcode)
                        {
                            return c;
                        }
                    }
                }
            }
            return null;
        }

        //each object will require its own save function to handle how information will be stored however they will all be invoked from here. 
        public void saveTheatre()
        {
            string filePath = @"Data\theatreDB.sqlite";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = System.IO.Path.Combine(directory, filePath);
            SQLiteConnection theatreDB = new SQLiteConnection(string.Format("Data Source={0};Version=3;", connection), true);
            theatreDB.Open();
            savePerformances(theatreDB);
            saveCustomers(theatreDB);
            theatreDB.Close();
        }

        public void loadTheatre()
        {
            string filePath = @"Data\theatreDB.sqlite";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = System.IO.Path.Combine(directory, filePath);
            SQLiteConnection theatreDB = new SQLiteConnection(string.Format("Data Source={0};Version=3;", connection), true);
            theatreDB.Open();
            loadPerformances(theatreDB);
            loadCustomers(theatreDB);
            theatreDB.Close();
        }

        public void deletePerformanceEntry(string id)
        {
            string filePath = @"Data\theatreDB.sqlite";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string connection = System.IO.Path.Combine(directory, filePath);
            SQLiteConnection theatreDB = new SQLiteConnection(string.Format("Data Source={0};Version=3;", connection), true);
            theatreDB.Open();
            string sql = string.Format("DELETE FROM Performances WHERE Id = {0}", id);
            SQLiteCommand cmd = new SQLiteCommand(sql, theatreDB);
            cmd.ExecuteNonQuery();
           theatreDB.Close();
        }

        private void savePerformances(SQLiteConnection db) // check if perforemances table exists in SQLite if not add, the we pass the connection to performance which takes the next step in saving for each performance in our list. 
        {
           
            string sql = "create table if not exists Performances (Id int PRIMARY KEY ASC, Title text, Description text, Date text, seatsUpper text, seatsDress text, seatsStalls text, priceUpper real, priceDress real, priceStalls real);";
            SQLiteCommand command = new SQLiteCommand(sql, db);
            command.ExecuteNonQuery();
            command = new SQLiteCommand("begin", db);
            command.ExecuteNonQuery();
            foreach (Performance p in getPerformances())
            {
                p.savePerformance(db);
            }
            command = new SQLiteCommand("end", db);
            command.ExecuteNonQuery();
        }

        private void loadPerformances(SQLiteConnection db)
        {
            string sql = "create table if not exists Performances (Id int PRIMARY KEY ASC, Title text, Description text, Date text, seatsUpper text, seatsDress text, seatsStalls text, priceUpper real, priceDress real, priceStalls real);";
            SQLiteCommand cmd = new SQLiteCommand(sql, db);
            cmd.ExecuteNonQuery();
            sql = "SELECT Id, Title, Description, Date, seatsUpper, seatsDress, seatsStalls, priceUpper, priceDress, priceStalls from Performances";
            cmd = new SQLiteCommand(sql, db);
            try
            {
                
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string title = rdr.GetString(1);
                    string description = rdr.GetString(2);
                    string dateString = rdr.GetString(3);
                    string seatsUpperString = rdr.GetString(4);
                    string seatsDressString = rdr.GetString(5);
                    string seatsStallsString = rdr.GetString(6);
                    float priceUpper = rdr.GetFloat(7);
                    float priceDress = rdr.GetFloat(8);
                    float priceStalls = rdr.GetFloat(9);
                    Performance temp = new Performance(id, title, description, dateString, seatsUpperString, seatsDressString, seatsStallsString, priceUpper, priceDress, priceStalls);
                    performances.Add(temp);
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        // same as save, each object will have a load function however they will all be invoked here. 

        private void saveCustomers(SQLiteConnection db)
        {
            
            string sql = "create table if not exists Customers (Id int PRIMARY KEY ASC, Firstname text, Lastname text, Address text, Postcode text, Goldstatus int, Golddate text, ReservationsLong text);";
            SQLiteCommand command = new SQLiteCommand(sql, db);
            command.ExecuteNonQuery();
            //SQLiteTransaction transaction = db.BeginTransaction();
            command = new SQLiteCommand("begin", db);
            command.ExecuteNonQuery();
            foreach (Customer c in getCustomers())
                {
                    c.saveCustomer(db);
                }
            command = new SQLiteCommand("end", db);
            command.ExecuteNonQuery();
        }

        private void loadCustomers(SQLiteConnection db)
        {
            string sql = "create table if not exists Customers (Id int PRIMARY KEY ASC, Firstname text, Lastname text, Address text, Postcode text, Goldstatus int, Golddate text, ReservationsLong text);";
            SQLiteCommand cmd = new SQLiteCommand(sql, db);
            cmd.ExecuteNonQuery();
            sql = "SELECT Id, Firstname, Lastname, Address, Postcode, Goldstatus, Golddate, ReservationsLong from Customers";
            cmd = new SQLiteCommand(sql, db);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string fName = rdr.GetString(1);
                string lName = rdr.GetString(2);
                string address = rdr.GetString(3);
                string postcode = rdr.GetString(4);
                int goldstatus = rdr.GetInt32(5);
                string golddate = rdr.GetString(6);
                string resLong = rdr.GetString(7);
                string[] resCheck = resLong.Split('|');
                if (resCheck.Length == 4)
                {
                    Customer temp = new Customer(id, fName, lName, address, postcode, goldstatus, golddate, resLong);
                    customers.Add(temp);
                }
                else
                {
                    Customer temp = new Customer(id, fName, lName, address, postcode, goldstatus, golddate);
                    customers.Add(temp);
                }
                
            }
        }
    }
}
