using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using NuGet.Frameworks;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product alpha;
        private Product beta;

        [SetUp]
        public void SetUp()
        {
            alpha = new Product();
            beta = new Product("Hat", 2, "A1234" , 10.00m);
        }

        [Test]
        public void TestProductConstructor()
        {
            //empty contructor tests 
            Assert.IsNotNull(alpha);
            Assert.AreEqual(null, alpha.Description);
            Assert.AreEqual(0, alpha.OnHandQuantity);
            Assert.AreEqual(null, alpha.ProductCode);
            Assert.AreEqual(0, alpha.UnitPrice);

            //overloaded constructor tests
            Assert.IsNotNull(beta);
            Assert.AreNotEqual(null, beta.Description);
            Assert.AreEqual("Hat", beta.Description);
            Assert.AreNotEqual(null, beta.OnHandQuantity);
            Assert.AreEqual(2, beta.OnHandQuantity);
            Assert.AreNotEqual(null, beta.ProductCode);
            Assert.AreEqual("A1234", beta.ProductCode);
            Assert.AreNotEqual(null, beta.UnitPrice);
            Assert.AreEqual(10.00m, beta.UnitPrice);
        }

        [Test]
        public void TestProductSetters()
        {
           Product beta = new Product("Hat", 2, "A1234", 10.00m);
            //using variables this time!
            string newDisc = "Rat";
            int newQty = 5;
            string newCode = "B5678";
            decimal newPrice = 5.00m;

            //call to the setters
            beta.Description = newDisc;
            beta.OnHandQuantity = newQty;
            beta.ProductCode = newCode;
            beta.UnitPrice = newPrice;

            Assert.AreEqual(newDisc, beta.Description);
            Assert.AreEqual(newQty, beta.OnHandQuantity);
            Assert.AreEqual(newCode, beta.ProductCode);
            Assert.AreEqual(newPrice, beta.UnitPrice);

            //lets mix it up just to make sure
            newDisc = "Bat";
            newQty = 11;
            newCode = "C0987";
            newPrice = 9.95m;

            //call the setters again to give them the new info
            beta.Description = newDisc;
            beta.OnHandQuantity = newQty;
            beta.ProductCode = newCode;
            beta.UnitPrice = newPrice;

            Assert.AreEqual(newDisc, beta.Description);
            Assert.AreEqual(newQty, beta.OnHandQuantity);
            Assert.AreEqual(newCode, beta.ProductCode);
            Assert.AreEqual(newPrice, beta.UnitPrice);
        }

        [Test]
        public void TestDiscTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => beta.Description = "                  ");
        }

        [Test]
        public void TestDiscTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => beta.Description = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        [Test]
        public void TestOnHandQuantityLow()
        {
            try
            {
                beta.OnHandQuantity = -1;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        [Test]
        public void TestCodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => beta.ProductCode = "                  ");
        }

        [Test]
        public void TestCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => beta.ProductCode = "12345678910");
        }

        //are try/catch the best way to hand an everflow exception?
        [Test]
        public void TestPriceTooHigh()
        {
            try
            {
                beta.UnitPrice = 21474783646.00m;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (OverflowException e)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        [Test]
        public void TestPriceTooLow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => beta.UnitPrice = -1.00m);
        }

        [Test]
        public void TestTooString()
        {
            Product charlie = new Product("Spats", 11, "D67584930", 25.99m);
            Assert.IsTrue(charlie.ToString().Contains("Spats"));
            Assert.IsTrue(charlie.ToString().Contains("11"));
            Assert.IsTrue(charlie.ToString().Contains("D67584930"));
            Assert.IsTrue(charlie.ToString().Contains("25.99"));
        }
    }
}
