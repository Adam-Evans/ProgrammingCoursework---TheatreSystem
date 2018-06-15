using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS
{
    public class testEntries
    {

        /// <summary>
        /// This entire class is purely to create extra test performances and fill them with customers. WANRING becuase of the nature of performance having a screren containing ~500 seats saving takes a while. Because of this it is best to 
        /// keep the number to around 50 at a time. The generation itself is fairly fast however the saving to database causes quite a bottleneck. Too many causes VS debug to think we did a naughty. 
        /// </summary>
        /// <param name="pTheatre"></param>
        /// <param name="customerAdd"></param>
        /// <param name="performanceAdd"></param>
        public testEntries(Theatre pTheatre, int customerAdd, int performanceAdd)
        {
            addPerformances(pTheatre, performanceAdd);
            addCustomers(pTheatre, customerAdd);
        }

        void addPerformances(Theatre pTheatre, int performancesCount)
        {
            string[] movieNames = new string[] { "A Fistfull Of Fern", "Good Guys Wear Cranberry", "Pop Goes The Evil", "Soft Boiled", "Run Away!", "Fact Checker on Fact Checker Crime", "Kelp", "Exit The Dragon",
                    "The Programmerator", "Rinse and Repeat", "The Number Crunchers", "Lard Target", "Defer To Superiors", "Lie Down With Lemmings", "I’m Saying It For The First Time", "Feet of Fungus", "Poke Hard", "Kung-Food Fighting", "Mission Possible",
                    "The Road Worrier", "A Fistful Of Gumballs", "Easy Does It", "The Octogenarian", "FIFO", "The Pen IS Mightier Than The Sword", "The Loan Ranger", "Hell’s Smells", "Two Guys, a Girl, and One Stick of Gum", "Less Is More", "Black Belt Brown Shoes" };
            string[] descriptionA = new string[] {"This is a story of ", "This is the legend of ", "Not all heroes wear capes, take ", "The first time I met our hero I thought not much of him but when ", "Everything was going well for our hero ",
                    "I'm running out of descriptions and the only one who could help me was "};
            string[] descriptionB = new string[] {"A loaf of bread", "Corporal America", "The Flasher", "Some guy at a bus stop whose pants should be a fair bit higher", "Bob Dole", "Barney the dinosaur", "A confused Whale", "A bowl of petunias",
                    "An actual ant", "An overripe banana", "Daniels. Jack Daniels" };
            string[] descriptionC = new string[] {" by doing things you couldn't dream of but we somehow wrote!", " through a lot of mundane paperwork!", " by going far too in depth with his movie generator.",
                    " by getting into an epic battle featuring a stapler, a handkerchief and two goldfish!", " when he helped that old lady cross the street. I mean she didn't want to cross but hey, at least he tried.",
                    " by going to the gym every day, fitness is important, stay healthy kids!"};
            Random rnd = new Random(DateTime.Now.Millisecond * 20 + DateTime.Now.Second);
            List<Performance> perfList = new List<Performance>();
            foreach (Performance p in pTheatre.getPerformances())
            {
                perfList.Add(p);
            }
            for (int i = 0; i < performancesCount; i++)
            {
                string title = movieNames[rnd.Next(0, movieNames.Length)];
                string description = descriptionA[rnd.Next(0, descriptionA.Length)] + descriptionB[rnd.Next(0, descriptionB.Length)] + descriptionC[rnd.Next(0, descriptionC.Length)];
                DateTime date = DateTime.Now;
            randomDate:
                date = date.AddDays(rnd.Next(0, 800));
                if (perfList.Contains(perfList.Find(x => x.getDate() == date)))
                {
                    goto randomDate;
                }
                TimeSpan time = new TimeSpan(21, 0, 0);
                date = date.Date + time;
                pTheatre.addPerformance(new Performance(title, description, date, 5.5f, 8.5f, 3.0f));
            }
        }

        void addCustomers(Theatre pTheatre, int customersCount)
        {
            string[] firstNames = {"Adam", "Alan", "Amanda", "Beevis", "Charles", "Claire", "Dale", "Dane", "Erik", "Emma", "Fred", "Georgia", "Harry", "Hannah", "Sara", "Julie", "Ashley", "Peter", "Rick", "Andrew", "Steven", "Paul", "Jack", "Clare", "Sarah", "Rebekka"};
            string[] lastNames = {"Evans", /*Ayy*/ "Martin", "Powell", "Kennedy", "Formby", "King", "Platt", "Reader", "Larne", "Smith", "Butterworth", "Schmidt", "LeBlanc", "Latham", "Wearing", "Webster", "Duffy", "Dole", "Murray", "Jackson", "Parker"};
            string[] roadNames = {"Row", "Street", "Lane", "Cross", "Point", "Road", "Walk", "Hill", "Grange", "Way", "Square", "End", "Boulevard", "Crossing"};
            string[] postcodes = { "DL7 8GF", "NN2 7TA", "ME17 2JE", "G72 8BU", "SR1 1RZ", "RG45 6PL", "SN16 9RG", "WV3 7EE", "M23 0QN", "DT11 0JG", "WR9 7RZ", "S73 0QG", "LA1 4UE", "TA20 2QW", "BR6 9RL",
            "WF12 8HU", "V35 0AR", "KA11 4DD", "SR5 5TX", "EN2 8QD", "S4 8DA", "E14 4HD", "NR17 1XR", "SN8 3HH", "RH10 3UW", "WF9 4TR", "LL21 9SR", "WS3 5EZ", "BT45 6HQ", "LS14 1JF", "KW1 5QG", "EH4 7HH",
            "WA1 3QH", "SE2 9TQ", "CR3 5JZ", "UB1 2TZ", "E17 5EP", "EH15 2LH", "CV32 7EP", "RH15 8HB", "YO26 8JF", "SY13 2DY", "PL10 1JB", "SO18 5FT", "ML8 4EW", "OX28 3JN", "NR27 0EL", "KT12 3JQ" ,"BT43 6LP",
            "GU35 0PX", "IP30 0EN", "SL8 5EB", "NR15 2TH", "PR8 6BF", "TS27 3HA", "TQ13 7DN", "PL14 9TP", "BT18 9FD", "SE6 1SA", "TR16 6NQ", "BH20 6NF", "WD3 3FS", "NG12 2AW", "CM11 2ZU", "PL27 6JG"};
            Random rnd = new Random(DateTime.Now.Millisecond * 20 + DateTime.Now.Second);
            int currentIndex = 0;
            List<Performance> dateSortedPerformances = new List<Performance>();
            dateSortedPerformances = pTheatre.findPerformancesAfterDate(DateTime.Now);
            for (int i = 0; i < customersCount; i++)
            {
                string name = firstNames[rnd.Next(0, firstNames.Length)];
                string lastname = lastNames[rnd.Next(0, lastNames.Length)];
                string postCode = postcodes[rnd.Next(0, postcodes.Length)];
                string address = firstNames[rnd.Next(0, firstNames.Length)] + " " + roadNames[rnd.Next(0, roadNames.Length)];
                bool gold = Convert.ToBoolean(rnd.Next(0, 2));
                DateTime goldDate = DateTime.Now;
                List<Reservation> resList = new List<Reservation>();
                if (gold)
                {
                    int time = rnd.Next(0, 360);
                    goldDate = goldDate.AddDays(-time);
                }
                bool hasReservation = Convert.ToBoolean(rnd.Next(0, 2));
                if (hasReservation)
                {
                nextPerformance:
                    if (currentIndex > dateSortedPerformances.Count)
                    {
                        break;
                    }
                    Performance resPerf = dateSortedPerformances[currentIndex];
                    string performance = resPerf.getID().ToString() + "-" + resPerf.getTitle();
                    List<Seat> reserved = new List<Seat>();
                    if (resPerf.getScreen().getUpperRemaining() > 0)
                    {
                        reserved = resPerf.getEmptyUpperSeat(rnd.Next(0, 7));
                    }
                    else if (resPerf.getScreen().getDressRemaining() > 0)
                    {
                        reserved = resPerf.getEmptyDressSeat(rnd.Next(0, 7));
                    }
                    else if (resPerf.getScreen().getStallsRemaining() > 0)
                    {
                        reserved = resPerf.getEmptyStallsSeat(rnd.Next(0, 7));
                    }
                    else
                    {
                        currentIndex++;
                        goto nextPerformance;
                    }
                    bool paid = Convert.ToBoolean(rnd.Next(0, 2));
                    DateTime resDate = new DateTime();
                    if (paid)
                    {
                        resDate = DateTime.Now.AddDays(rnd.Next(-360, -1));
                    }
                    else
                    {
                        resDate = DateTime.Now.AddDays(rnd.Next(-6, 0));
                    }
                    Reservation res = new Reservation(performance, reserved, paid, resDate);
                    resList.Add(res);

                }
                pTheatre.addCustomer(new Customer(name, lastname, address, postCode, gold, goldDate, resList));
            }
        }
    }
}
