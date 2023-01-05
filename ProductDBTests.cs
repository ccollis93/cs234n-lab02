using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestAddProduct()
        {
            Product p = new Product();
            p.Description = "Do Androids Dream of Electric Sheep?";
            p.OnHandQuantity = 7;
            p.ProductCode = "BR82";
            p.UnitPrice = 16.99m;

            bool addCheck = ProductDB.AddProduct(p);
            Assert.IsTrue(addCheck);
        }

        //this one throws a syntax error "Server Error Code: 1064" and I'm not sure how to fix it
        [Test]
        public void TestUpdateProduct()
        {
            Product oldProduct = ProductDB.GetProduct("A4CS");
            Product newProduct = ProductDB.GetProduct("A4CS");
            newProduct.OnHandQuantity = 5000;

            ProductDB.UpdateProduct(oldProduct, newProduct);
            Assert.AreNotEqual(oldProduct, newProduct);
        }

        [Test]
        public void TestDeleteProduct()
        {
            Product p = ProductDB.GetProduct("BR82");

            bool delCheck = ProductDB.DeleteProduct(p);
            Assert.IsTrue(delCheck);
        } 
    }
}
