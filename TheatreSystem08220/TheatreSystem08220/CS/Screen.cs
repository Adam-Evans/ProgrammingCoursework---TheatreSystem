using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using TheatreSystem08220.CS;

namespace TheatreSystem08220.CS
{
    public class Screen
    {
        private List<Seat> upperSeats;
        private List<Seat> dressSeats;
        private List<Seat> stallsSeats;

        private float priceUpper;
        private float priceDress;
        private float priceStalls;

        public Screen(List<Seat> pUpper, List<Seat> pDress, List<Seat> pStalls, float pPriceUpper, float pPriceDress, float pPriceStalls)
        {
            upperSeats = pUpper;
            dressSeats = pDress;
            stallsSeats = pStalls;
            priceUpper = pPriceUpper;
            priceDress = pPriceDress;
            priceStalls = pPriceStalls;
        }

        public Screen(string pUpper, string pDress, string pStalls, float pPriceUpper, float pPriceDress, float pPriceStalls)
        {
            upperSeats = new Seat().stringToSeatList(pUpper);
            dressSeats = new Seat().stringToSeatList(pDress);
            stallsSeats = new Seat().stringToSeatList(pStalls);
            priceUpper = pPriceUpper;
            priceDress = pPriceDress;
            priceStalls = pPriceStalls;
        }

        public Screen(float pPriceUpper, float pPriceDress, float pPriceStalls)
        {
            priceDress = pPriceDress;
            priceUpper = pPriceUpper;
            priceStalls = pPriceStalls;
            upperSeats = generateNewUpper();
            dressSeats = generateNewDress();
            stallsSeats = generateNewStalls();
        }

        List<Seat> generateNewUpper()
        {
            List<Seat> newSeatList = new List<Seat>();

            for (int i = 1; i < 11; i++)
            {
                Seat temp = new Seat('E', i, seatType.upper, this.getUpperPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 26; i++)
            {
                Seat temp = new Seat('D', i, seatType.upper, this.getUpperPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 26; i++)
            {
                Seat temp = new Seat('C', i, seatType.upper, this.getUpperPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 26; i++)
            {
                Seat temp = new Seat('B', i, seatType.upper, this.getUpperPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 26; i++)
            {
                Seat temp = new Seat('A', i, seatType.upper, this.getUpperPrice());
                newSeatList.Add(temp);
            }
            return newSeatList;
        }

        List<Seat> generateNewDress()
        {
            List<Seat> newSeatList = new List<Seat>();
            for (int i = 1; i < 24; i++)
            {
                Seat temp = new Seat('E', i, seatType.dress, this.getDressPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 24; i++)
            {
                Seat temp = new Seat('D', i, seatType.dress, this.getDressPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 20; i++)
            {
                Seat temp = new Seat('C', i, seatType.dress, this.getDressPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 38; i++)
            {
                Seat temp = new Seat('B', i, seatType.dress, this.getDressPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 36; i++)
            {
                Seat temp = new Seat('A', i, seatType.dress, this.getDressPrice());
                newSeatList.Add(temp);
            }
            return newSeatList;
        }

        List<Seat> generateNewStalls()
        {
            List<Seat> newSeatList = new List<Seat>();
            for (int i = 1; i < 17; i++)
            {
                Seat temp = new Seat('L', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 21; i++)
            {
                Seat temp = new Seat('K', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 23; i++)
            {
                Seat temp = new Seat('J', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 23; i++)
            {
                Seat temp = new Seat('I', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 23; i++)
            {
                Seat temp = new Seat('H', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 2; i < 23; i++)
            {
                Seat temp = new Seat('G', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 22; i++)
            {
                Seat temp = new Seat('F', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 23; i++)
            {
                Seat temp = new Seat('E', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 23; i++)
            {
                Seat temp = new Seat('D', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 3; i < 21; i++)
            {
                Seat temp = new Seat('C', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 17; i++)
            {
                Seat temp = new Seat('B', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            for (int i = 1; i < 18; i++)
            {
                Seat temp = new Seat('A', i, seatType.stalls, this.getStallsPrice());
                newSeatList.Add(temp);
            }
            return newSeatList;
        }

        public int getUpperCount()
        {
            return upperSeats.Count;
        }

        public int getDressCount()
        {
            return dressSeats.Count;
        }

        public int getStallsCount()
        {
            return stallsSeats.Count;
        }

        //used to give an overview of how many seats are available for each section for a select performance.
        public int getUpperRemaining()
        {
            int count = 0;
            for (int i = 0; i < upperSeats.Count; i++)
            {
                if (!upperSeats[i].isReserved())
                {
                    count++;
                }
            }
            return count;
        }

        public int getDressRemaining()
        {
            int count = 0;
            for (int i = 0; i < dressSeats.Count; i++)
            {
                if (!dressSeats[i].isReserved())
                {
                    count++;
                }
            }
            return count;
        }

        public int getStallsRemaining()
        {
            int count = 0;
            for (int i = 0; i < stallsSeats.Count; i++)
            {
                if (!stallsSeats[i].isReserved())
                {
                    count++;
                }
            }
            return count;
        }

        //price is adaptive. Consider using an int attached to seat with it's indiviual pricetag. 
        public float getUpperPrice()
        {
            return priceUpper;
        }

        public List<Seat> getUpperList()
        {
            return upperSeats;
        }

        public void setUpperPrice(float price)
        {
            priceUpper = price;
        }

        public void setDressPrice(float price)
        {
            priceDress = price;
        }

        public void setStallsPrice(float price)
        {
            priceStalls = price;
        }

        public List<Seat> getDressList()
        {
            return dressSeats;
        }

        public List<Seat> getStallsList()
        {
            return stallsSeats;
        }

        public float getDressPrice()
        {
            return priceDress;
        }

        public float getStallsPrice()
        {
            return priceStalls;
        }

        public void saveScreen(int id, string title, string description, DateTime date, SQLiteConnection con)
        {
            string longSeatsUpper = "", longSeatsDress = "", longSeatsStall = "";
            foreach (Seat s in upperSeats)
            {
                longSeatsUpper += s.seatToString() + ",";
            }
            if (longSeatsUpper.Length > 1)
                longSeatsUpper = longSeatsUpper.Remove(longSeatsUpper.Length - 1);
            foreach (Seat s in dressSeats)
            {
                longSeatsDress += s.seatToString() + ",";
            }
            if (longSeatsDress.Length > 1)
                longSeatsDress = longSeatsDress.Remove(longSeatsDress.Length - 1);
            foreach (Seat s in stallsSeats)
            {
                longSeatsStall += s.seatToString() + ",";
            }
            if (longSeatsStall.Length > 1)
                longSeatsStall = longSeatsStall.Remove(longSeatsStall.Length - 1);
            string dateString = new dateConverter().dateToString(date);
            string sql = "REPLACE INTO Performances (Id, Title, Description, Date, seatsUpper, seatsDress, seatsStalls, priceUpper, priceDress, priceStalls) VALUES (@Id, @Title, @Description, @Date, @seatsUpper, @seatsDress, @seatsStalls, @priceUpper, @priceDress, @priceStalls)";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            com.Parameters.AddWithValue("@Id", id);
            com.Parameters.AddWithValue("@Title", title);
            com.Parameters.AddWithValue("@Description", description);
            com.Parameters.AddWithValue("@Date", dateString);
            com.Parameters.AddWithValue("@SeatsUpper", longSeatsUpper);
            com.Parameters.AddWithValue("@seatsDress", longSeatsDress);
            com.Parameters.AddWithValue("@seatsStalls", longSeatsStall);
            com.Parameters.AddWithValue("@priceUpper", getUpperPrice().ToString());
            com.Parameters.AddWithValue("@priceDress", getDressPrice().ToString());
            com.Parameters.AddWithValue("@priceStalls", getStallsPrice().ToString());
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
