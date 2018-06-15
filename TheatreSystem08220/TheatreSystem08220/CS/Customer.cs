using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TheatreSystem08220.CS
{
    public class Customer    
    {
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string postCode;
        bool goldStatus;
        DateTime goldDate;

        List<Reservation> reservations;

        public Customer(string pFirstname, string pLastname, string pAddress, string pPostcode, bool pGoldstatus, DateTime pGoldDate, List<Reservation> pReservations)
        {
            firstName = pFirstname;
            lastName = pLastname;
            address = pAddress;
            postCode = pPostcode;
            goldStatus = pGoldstatus;
            goldDate = pGoldDate;
            reservations = pReservations;
        }

        // some members may not have gold therefore an overload without goldDate is necesary. 
        public Customer(string pFirstname, string pLastname, string pAddress, string pPostcode, bool pGoldstatus)
        {
            firstName = pFirstname;
            lastName = pLastname;
            address = pAddress;
            postCode = pPostcode;
            goldStatus = pGoldstatus;
            reservations = new List<Reservation>();
        }

        public Customer(string pFirstname, string pLastname, string pAddress, string pPostcode, bool pGoldstatus, DateTime pGoldDate)
        {
            firstName = pFirstname;
            lastName = pLastname;
            address = pAddress;
            postCode = pPostcode;
            goldStatus = pGoldstatus;
            goldDate = pGoldDate;
            reservations = new List<Reservation>();
        }

        public Customer(string pFirstname, string pLastname, string pAddress, string pPostcode, bool pGoldstatus, List<Reservation> pReservations)
        {
            firstName = pFirstname;
            lastName = pLastname;
            address = pAddress;
            postCode = pPostcode;
            goldStatus = pGoldstatus;
            reservations = pReservations;
        }

        public Customer(int pId, string fName, string lName, string paddress, string ppostcode, int pGoldstatus, string pGolddate, string resLong)
        {
            id = pId;
            firstName = fName;
            lastName = lName;
            address = paddress;
            postCode = ppostcode;
            goldStatus = Convert.ToBoolean(pGoldstatus);
            goldDate = new dateConverter().stringToDate(pGolddate);
            reservations = new Reservation().stringToListReservations(resLong);
        }

        public Customer(int pId, string fName, string lName, string paddress, string ppostcode, int pGoldstatus, string pGolddate)  // overload for loading customers that may not have a reservationsLong string
        {
            id = pId;
            firstName = fName;
            lastName = lName;
            address = paddress;
            postCode = ppostcode;
            goldStatus = Convert.ToBoolean(pGoldstatus);
            goldDate = new dateConverter().stringToDate(pGolddate);
            reservations = new List<Reservation>();
        }

        public void saveCustomer(SQLiteConnection db)
        {
            string sql = "REPLACE INTO Customers (Id, Firstname, Lastname, Address, Postcode, Goldstatus, Golddate, ReservationsLong) VALUES (@Id, @Firstname, @Lastname, @Address, @Postcode, @Goldstatus, @Golddate, @ReservationsLong)";
            SQLiteCommand com = new SQLiteCommand(sql, db);
            com.Parameters.AddWithValue("@Id", getID());
            com.Parameters.AddWithValue("@Firstname", getFirstName());
            com.Parameters.AddWithValue("@Lastname", getSurname());
            com.Parameters.AddWithValue("@Address", getAddress());
            com.Parameters.AddWithValue("@Postcode", getPostcode());
            com.Parameters.AddWithValue("@Goldstatus", Convert.ToInt32(isGold()));
            com.Parameters.AddWithValue("@Golddate", new dateConverter().dateToString(goldDate));
            string ReservationLong = "";
            foreach (Reservation r in reservations)
            {
                ReservationLong += r.reservationToString();
            }
            if (ReservationLong.Length > 1)
                ReservationLong = ReservationLong.Remove(ReservationLong.Length - 1);
            com.Parameters.AddWithValue("@ReservationsLong", ReservationLong);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addReservation(string performance, List<Seat> seats, bool paid, DateTime date)
        {
            Reservation newRes = new Reservation(performance, seats, paid, date);
            reservations.Add(newRes);
        }

        public List<Reservation> getReservations()
        {
            return reservations;
        }

        public string getFullName()
        {
            string fullname = firstName + " " + lastName;
            return fullname;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getSurname()
        {
            return lastName;
        }

        public string getAddress()
        {
            return address;
        }

        public string getPostcode()
        {
            return postCode;
        }

        public bool isGold()
        {
            return goldStatus;
        }

        public int getID()
        {
            return id;
        }

        public void setID(int number)
        {
            id = number;
        }

        public DateTime getGoldDate()
        {
            return goldDate;
        }
    }
}
