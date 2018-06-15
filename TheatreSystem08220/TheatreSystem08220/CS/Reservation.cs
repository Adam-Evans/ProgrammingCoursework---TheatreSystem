using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS
{
    public class Reservation
    {
        private string performance; // Stored in the form "ID-Title".
        private List<Seat> seats;
        private bool paid;
        private DateTime reservationDate;

        public Reservation(string pPerformance, List<Seat> pSeats, bool pPaid, DateTime pReservationDate) {
            performance = pPerformance;
            seats = pSeats;
            paid = pPaid;
            reservationDate = pReservationDate;
        }

        public Reservation()
        {
        }

        //self explanitory. 
        string getPerformance() {
            return performance;
        }

        public string reservationToString()
        {
            string outString = "";
            outString += performance + "|";
            foreach (Seat s in seats)
            {
                outString += s.seatToString();
                outString += ",";
            }
            outString = outString.Remove(outString.Length - 1);
            outString += "|" + Convert.ToInt32(paid) + "|" + new dateConverter().dateToString(reservationDate) + "&";
            return outString;
        }

        public List<Reservation> stringToListReservations(string resLong)
        {
            string[] split = resLong.Split('&');
            List<Reservation> newResList = new List<Reservation>();
            for (int i = 0; i < split.Length; i++)
            {
                Reservation temp = new Reservation().stringToReservation(split[i]);
                newResList.Add(temp);
            }
            return newResList;
        }

        public Reservation stringToReservation(string resLong)
        {
            string[] split = resLong.Split('|');
            if (split.Length != 4)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                string perf = split[0];
                List<Seat> listSeats = new Seat().stringToSeatList(split[1]);
                bool paid = Convert.ToBoolean(int.Parse(split[2]));
                DateTime date = new dateConverter().stringToDate(split[3]);
                return new Reservation(perf, listSeats, paid, date);
            }
        }

        //if this returns false and the reservation date is longer than a week ago the reservation should be cancelled and the seats freed up for re-sale. 
        bool isPaid() {
            return paid;
        }

        // list needed here as each customer may reserve up to 6 seats. Another option would be simply to use an Array[6]. 
        List<Seat> getSeats() {
            return seats;
        }

        //Not to be confused with performance date, this is the date the reservation was made. to be used to determine is a reservation should be cancelled if not paid / to see when a payment was made. 
        public DateTime getReservationDate() {
            return reservationDate;
        }
    }
}
