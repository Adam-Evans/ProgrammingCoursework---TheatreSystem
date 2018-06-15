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
    public class CustomerTests
    {
        Customer testCustomer = new Customer("Adam", "Buh", "Some Address at yo face", "1234567", true, DateTime.Today);

        [TestMethod()]
        public void getFullNameTest()
        {
            string expected = "Adam Buh";
            string actual = testCustomer.getFullName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getFirstNameTest()
        {
            string expected = "Adam";
            string actual = testCustomer.getFirstName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getSurnameTest()
        {
            string expected = "Buh";
            string actual = testCustomer.getSurname();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getAddressTest()
        {
            string expected = "Some Address at yo face";
            string actual = testCustomer.getAddress();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getPostcodeTest()
        {
            string expected = "1234567";
            string actual = testCustomer.getPostcode();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isGoldTest()
        {
            bool expected = true;
            bool actual = testCustomer.isGold();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void getGoldDateTest()
        {
            DateTime expected = DateTime.Today;
            Assert.AreEqual(testCustomer.getGoldDate(), expected);
        }
    }
}