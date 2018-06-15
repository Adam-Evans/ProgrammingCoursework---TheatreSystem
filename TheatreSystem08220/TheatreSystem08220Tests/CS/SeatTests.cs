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
    public class SeatTests
    {

        Seat testSeat = new Seat('E', 4, seatType.dress, 8);

        [TestMethod()]
        public void SeatTest()
        {
            Assert.IsNotNull(testSeat);
        }

        [TestMethod()]
        public void getRowTest()
        {
            char expected = 'E';
            char actual = testSeat.getRow();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void getColumnTest()
        {
            int expected = 4;
            int actual = testSeat.getColumn();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getSeatTest()
        {
            string expected = "dress:E4";
            string actual = testSeat.getSeat();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getTypeTest()
        {
            seatType expected = seatType.dress;
            seatType actual = testSeat.getType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isReservedTest()
        {
            bool expected = false;
            bool actual = testSeat.isReserved();
            Assert.AreEqual(expected, actual);
        }
    }
}