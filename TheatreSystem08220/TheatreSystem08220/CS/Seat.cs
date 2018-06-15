using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS
{

    public enum seatType { upper, dress, stalls};

    public class Seat
    {
        private char row;
        private int column;
        private seatType type;
        private bool reserved;
        private float price;

        public Seat(char pRow, int pColumn, seatType pType, float pPrice) {
            row = pRow;
            column = pColumn;
            type = pType;
            price = pPrice;
            reserved = false;
        }

        public Seat(char pRow, int pColumn, seatType pType, float pPrice, bool pReserved)
        {
            row = pRow;
            column = pColumn;
            type = pType;
            price = pPrice;
            reserved = pReserved;
        }

        public bool isReserved()
        {
            return reserved;
        }

        public void setReserved(bool status)
        {
            reserved = status;
        }

        public Seat()
        {
        }

        public List<Seat> stringToSeatList(string pStringSeats)
        {
            List<Seat> newSeatList = new List<Seat>();
            string[] split = pStringSeats.Split(',');   // splits long string into individual seat strings.
            for (int i = 0; i < split.Length; i++)
            {
                Seat temp = stringToSeat(split[i]);
                newSeatList.Add(temp);
            }
            return newSeatList;
        }

        // rows will be lettered a-zA-Z
        public char getRow() {
            return row;
        }
        // columns are numbered. 
        public int getColumn() {
            return column;
        }

        //this will be used to attach a seat to its corresponding button for each performance. I.E a performance will have it's screen, a screen 3 lists of seats, lists are populated by entries of this object. Each seat will also be mapped to the appropriate UI button
        public string getSeat() {
            string seat = type.ToString() + ":" + row + column;
            return seat;
        }

        public seatType getType() {
            return type;
        }
        //used to ensure that a seat cannot be sold/reserved twice. Will be represented in UI by a change of button colour in the selection window. 
       

        public float getPrice() {
            return price;
        }

        public string seatToString()
        {
            string temp =  getType().ToString() + ":" + getRow().ToString() + getColumn().ToString() + ":" + getPrice().ToString() + ":" + isReserved().ToString();
            return temp;
        }

        public Seat stringToSeat(string typerowcolumnprice) // in the form "Type:ColumnRow:Price:Reserved"
        {
            string[] split = typerowcolumnprice.Split(':');
            if (split.Length == 1)
            {
                goto emptySeat;
            }
            if (split.Length != 4)
            {
                throw new ArgumentOutOfRangeException();
            }
            seatType type = stringToType(split[0]);
            char row = split[1][0];
            split[1] = split[1].Substring(1);
            int column = int.Parse(split[1]);
            float price = float.Parse(split[2]);
            bool res;
            if (split[3].ToLower() == "true")
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return new Seat(row, column, type, price, res);
        emptySeat:
            return new Seat();
        }

        public seatType stringToType(string pIN)
        {
            if (pIN.ToLower() == "upper")
            {
                return seatType.upper;
            }
            else if (pIN.ToLower() == "dress")
            {
                return seatType.dress;
            }
            else if (pIN.ToLower() == "stalls")
            {
                return seatType.stalls;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void saveSeat()
        {

        }

        public void loadSeat()
        {

        }
    }
}
