using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer oldCustomer = CustomerDB.GetCustomer(2);

            Customer newCustomer = CustomerDB.GetCustomer(2);
            newCustomer.Address = "2121 Change";
           

            CustomerDB.UpdateCustomer(oldCustomer, newCustomer);
            Assert.AreNotEqual(oldCustomer,newCustomer);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);

            bool delCheck = CustomerDB.DeleteCustomer(c);
            Assert.IsTrue(delCheck);
            
        }
    }
}
