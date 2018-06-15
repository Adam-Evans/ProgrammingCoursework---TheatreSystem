using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheatreSystem08220.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS.Tests
{
   

    [TestClass()]
    public class ScreenTests
    {
        static List<Seat> testSeatsUpper = new List<Seat>()
        {
             new Seat('E', 4, seatType.upper, 6, true),
             new Seat('C', 4, seatType.upper, 6, true),
             new Seat('C', 1, seatType.upper, 6)
        };
        static List<Seat> testSeatsDress = new List<Seat>()
        {
             new Seat('D', 4, seatType.dress, 8, true)
        };
        static List<Seat> testSeatsStalls = new List<Seat>()
        {
            new Seat('F', 20, seatType.stalls, 3),
            new Seat('H', 12, seatType.stalls, 3)
        };
        static float priceUpper = 6;
        static float priceStalls = 3;
        static float priceDress = 8;

        Screen testScreen = new Screen(testSeatsUpper, testSeatsDress, testSeatsStalls, priceUpper, priceDress, priceStalls);

        [TestMethod()]
        public void getUpperCountTest()
        {
            int expected = 3;
            int actual = testScreen.getUpperCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getDressCountTest()
        {
            int expected = 1;
            int actual = testScreen.getDressCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getStallsCountTest()
        {
            int expected = 2;
            int actual = testScreen.getStallsCount();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void getUpperRemainingTest()
        {
            int expected = 1;
            int actual = testScreen.getUpperRemaining();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getDressRemainingTest()
        {
            int expected = 0;
            int actual = testScreen.getDressRemaining();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getStallsRemainingTest()
        {
            int expected = 2;
            int actual = testScreen.getStallsRemaining();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getUpperPriceTest()
        {
            float expected = 6;
            float actual = testScreen.getUpperPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getDressPriceTest()
        {
            float expected = 8;
            float actual = testScreen.getDressPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getStallsPriceTest()
        {
            float expected = 3;
            float actual = testScreen.getStallsPrice();
            Assert.AreEqual(expected, actual);
        }
    }
}