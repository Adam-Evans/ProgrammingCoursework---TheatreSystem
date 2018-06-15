using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS
{
    public class dateConverter
    {

        string dateString;
        DateTime dateDate;

        public dateConverter()
        {

        }

        public dateConverter(DateTime date)
        {
            dateDate = date;
        }

        public dateConverter(string date)
        {
            dateString = date;
        }

        public string dateToString()
        {
            string stringDate = dateDate.ToString("dd-MM-yyyy HH:mm");
            return stringDate;
        }

        public string dateToString(DateTime date)
        {
            string stringDate = date.ToString("dd-MM-yyyy HH:mm");
            return stringDate;
        }

        public DateTime stringToDate(string date)
        {
            //DateTime newDate = Convert.ToDateTime(date);
            DateTime newDate = DateTime.ParseExact(date, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            return newDate;
        }
    }
}
