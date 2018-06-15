using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheatreSystem08220.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreSystem08220.CS;

namespace TheatreSystem08220.Windows.Tests
{
    [TestClass()]
    public class MainTests
    {
        static Theatre myTheatreTest;
        int id = 0;

        [TestMethod()]
        public void TestAdd()
        {
            myTheatreTest = new Theatre();
            Performance temp = new Performance("Test", "TestDescription", "12/12/1212 21:00", 3.5f, 5.0f, 8.5f);
            myTheatreTest.addPerformance(temp);
            id = temp.getID();
            Assert.IsNotNull(myTheatreTest.getPerformances().Find(x => x.getID() == id));
        }

        [TestMethod()]
        public void TestSaveAndLoad()
        {
            myTheatreTest.saveTheatre();
            Theatre testLoadTheatre = new Theatre();
            testLoadTheatre.loadTheatre();
            Assert.IsTrue(testLoadTheatre.getPerformances().Count != 0);
        }

        [TestMethod()]
        public void TestDelete()
        {
            myTheatreTest.deletePerformanceEntry(id.ToString());
            Assert.IsNull(myTheatreTest.getPerformances().Find(x => x.getID() == id));
        }

        [TestMethod()]
        public void TestAddCustomer()
        {
            Customer temp = new Customer("Test", "Guy", "In a Test Road", "With a test postcode", true, DateTime.Now);
            myTheatreTest.getCustomers().Add(temp);
            Assert.IsTrue(myTheatreTest.getCustomers().Count > 0);
        }

        [TestMethod()]
        public void TestAddReservation()
        {
            Performance temp = new Performance("Test", "TestDescription", "12/12/1212 21:00", 3.5f, 5.0f, 8.5f);
            myTheatreTest.addPerformance(temp);
            List<Seat> seats = new List<Seat>()
            {
                new Seat ('E', 4, seatType.dress, 5.0f),
                new Seat('C', 4, seatType.upper, 3.5f)
            };
            string perf = myTheatreTest.getPerformances()[0].getID() + "-" + myTheatreTest.getPerformances()[0].getTitle();
            myTheatreTest.getCustomers()[0].addReservation(perf, seats, true, DateTime.Now);
            Assert.IsTrue(myTheatreTest.getCustomers()[0].getReservations().Count > 0);
        }
    }
}