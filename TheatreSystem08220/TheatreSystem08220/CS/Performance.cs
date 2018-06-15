using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreSystem08220.CS;

namespace TheatreSystem08220.CS
{
    public class Performance
    {
        private int ID; 
        private string title;
        private string description;
        private DateTime performanceDate;
        private Screen screen;

        public Performance()
        {
            //blank performance for empty search returns.
        }

        public Performance(string pTitle, string pDescription, DateTime pPerformanceDate, Screen pScreen)
        {
            title = pTitle;
            description = pDescription;
            performanceDate = pPerformanceDate;
            screen = pScreen;
        }

        public Performance(int id, string pTitle, string pDescription, DateTime pPerformanceDate, Screen pScreen)
        {
            title = pTitle;
            description = pDescription;
            performanceDate = pPerformanceDate;
            screen = pScreen;
            ID = id;
        }

        public Performance(string pTitle, string pDescription, string pPerformanceDate, float priceUpper, float priceDress, float priceStalls)
        {
            title = pTitle;
            description = pDescription;
            performanceDate = Convert.ToDateTime(pPerformanceDate);
            screen = new Screen(priceUpper, priceDress, priceStalls);
        }

        public Performance(string pTitle, string pDescription, DateTime pPerformanceDate, float priceUpper, float priceDress, float priceStalls)
        {
            title = pTitle;
            description = pDescription;
            performanceDate = pPerformanceDate;
            screen = new Screen(priceUpper, priceDress, priceStalls);
        }

        public Performance(int pId, string pTitle, string pDescription, string pDate, string listUpper, string listDress, string listStalls, float priceUpper, float priceDress, float priceStalls)
        {
            ID = pId;
            title = pTitle;
            description = pDescription;
            performanceDate = new dateConverter().stringToDate(pDate);
            screen = new Screen(new Seat().stringToSeatList(listUpper), new Seat().stringToSeatList(listDress), new Seat().stringToSeatList(listStalls), priceUpper, priceDress, priceStalls);
        }

        public float getPrice (string type)     // used to retrieve the price for levels of seating.
        {
            switch (type.ToLower())
            {
                case "upper":
                    return getScreen().getUpperPrice();
                case "dress":
                    return getScreen().getDressPrice();
                case "stalls":
                    return getScreen().getStallsPrice();
                default:
                    return 0;
            }
        }

        public void addReservation(List<Seat> seats)
        {
            foreach (Seat s in seats)
            {
                if (s.getType() == seatType.dress)
                {
                    foreach (Seat d in screen.getDressList())
                    {
                        if (d.getColumn() == s.getColumn() && d.getRow() == s.getRow())
                        {
                            screen.getDressList().Remove(d);
                            screen.getDressList().Add(s);
                            break;
                        }
                    }
                }
                if (s.getType() == seatType.stalls)
                {
                    foreach (Seat d in screen.getStallsList())
                    {
                        if (d.getColumn() == s.getColumn() && d.getRow() == s.getRow())
                        {
                            screen.getStallsList().Remove(d);
                            screen.getStallsList().Add(s);
                            break;
                        }
                    }
                }
                if (s.getType() == seatType.upper)
                {
                    foreach (Seat d in screen.getUpperList())
                    {
                        if (d.getColumn() == s.getColumn() && d.getRow() == s.getRow())
                        {
                            screen.getUpperList().Remove(d);
                            screen.getUpperList().Add(s);
                            break;
                        }
                    }
                }
            }
        }

        public List<Seat> getEmptyUpperSeat(int count)
        {
            Random rnd = new Random(DateTime.Now.Millisecond * 20 + DateTime.Now.Second);
            int type = rnd.Next(0, 3);
            int loops = 0;
            List<Seat> foundSeats = new List<Seat>();
            for (int i = 0; i < count; i++)
            {
                List<Seat> upperSeats = screen.getUpperList();
                int rand = rnd.Next(0, upperSeats.Count);
                if (!upperSeats[rand].isReserved())
                {
                    foundSeats.Add(upperSeats[rand]);
                    screen.getUpperList()[rand].setReserved(true);
                }
                else
                {
                    i--;
                }
                loops++;
                if (loops > 100)
                    break;
            }
            return foundSeats;
        }

        public List<Seat> getEmptyDressSeat(int count)
        {
            Random rnd = new Random(DateTime.Now.Millisecond * 20 + DateTime.Now.Second);
            int type = rnd.Next(0, 3);
            int loops = 0;
            List<Seat> foundSeats = new List<Seat>();
            for (int i = 0; i < count; i++)
            {
                List<Seat> dressSeats = screen.getDressList();
                int rand = rnd.Next(0, dressSeats.Count);
                if (!dressSeats[rand].isReserved())
                {
                    foundSeats.Add(dressSeats[rand]);
                    screen.getDressList()[rand].setReserved(true);
                }
                else
                {
                    i--;
                }
                loops++;
                if (loops > 100)
                    break;
            }
            return foundSeats;
        }

        public List<Seat> getEmptyStallsSeat(int count)
        {
            Random rnd = new Random(DateTime.Now.Millisecond * 20 + DateTime.Now.Second);
            int type = rnd.Next(0, 3);
            int loops = 0;
            List<Seat> foundSeats = new List<Seat>();
            for (int i = 0; i < count; i++)
            {
                List<Seat> stallsSeats = screen.getStallsList();
                int rand = rnd.Next(0, stallsSeats.Count);
                if (!stallsSeats[rand].isReserved())
                {
                    foundSeats.Add(stallsSeats[rand]);
                    screen.getStallsList()[rand].setReserved(true);
                }
                else
                {
                    i--;
                }
                loops++;
                if (loops > 100)
                    break;
            }
            return foundSeats;
        }

        public string getTitle()
        {
            return title;
        }

        public string getDescription()
        {
            return description;
        }
        public DateTime getDate()
        {
            return performanceDate;
        }

        public int getID()
        {
            return ID;
        }

        public void setID(int number)
        {
            ID = number;
        }

        public Screen getScreen()
        {
            return screen;
        }

        public void savePerformance(SQLiteConnection con)
        {

            getScreen().saveScreen(getID(), getTitle(), getDescription(), getDate(), con);
        }

      
    }
}
