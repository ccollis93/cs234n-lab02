using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Mouse, Mickey", "101 Main Street", "Toontown", "FL","10001");
        }

        [Test]
        public void TestCustomerConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreEqual("Mouse, Mickey", c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreEqual("Toontown", c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreEqual("FL", c.State);
            Assert.AreNotEqual(null, c.ZipCode);
            Assert.AreEqual("10001", c.ZipCode);
        }

        [Test]
        public void TestCustomerSetters()
        {
 
            c.Name = "Mouse, Minnie";
            Assert.AreNotEqual("Mouse, Mickey", c.Name);
            Assert.AreEqual("Mouse, Minnie", c.Name);

            c.CustomerID = 2;
            Assert.AreNotEqual(1, c.CustomerID);
            Assert.AreEqual(2, c.CustomerID);

            c.Address = "202 Main Street";
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreEqual("202 Main Street", c.Address);

            c.City = "Tomorrowland";
            Assert.AreNotEqual("Toontown", c.City);
            Assert.AreEqual("Tomorrowland", c.City);

            c.State = "CA";
            Assert.AreNotEqual("FL", c.State);
            Assert.AreEqual("CA", c.State);

            c.ZipCode = "20002";
            Assert.AreNotEqual("10001", c.ZipCode);
            Assert.AreEqual("20002", c.ZipCode);

            //i really should have used variables to do this, but i was already almost done when I realized my mistake

        }


        //I think I could have done this all in a try/catch block. Would it work to do them all in a single one? 
        [Test]
        public void TestSettersNameTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "                  "); 
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        [Test]
        public void TestIDNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.CustomerID = -1);
        }

        [Test]
        public void TestStateTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "A");
        }

        [Test]
        public void TestStateTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "ABC");
        }

        [Test]
        public void TestZipTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "                   ");
        }

        [Test]
        public void TestZipTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "ABCDEFGHIJLKMNOP");
        }

        [Test]
        public void TestTooString()
        {
            Customer b = new Customer(3, "Duck, Donald", "303 Silly Street", "Toontown", "FL", "10001");
            Assert.IsTrue(b.ToString().Contains("3"));
            Assert.IsTrue(b.ToString().Contains("Duck, Donald"));
            Assert.IsTrue(b.ToString().Contains("303 Silly Street"));
            Assert.IsTrue(b.ToString().Contains("Toontown"));
            Assert.IsTrue(b.ToString().Contains("FL"));
            Assert.IsTrue(b.ToString().Contains("10001"));

        }
    }
}
