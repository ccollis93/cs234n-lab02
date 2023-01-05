using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string dscrip, int onhand, string code, decimal price)
        {
             Description = dscrip;
             OnHandQuantity = onhand;
             ProductCode = code;
             UnitPrice = price;

        }

        //private global class variables. I know thats not the right word but I hope you get what im going for
        private string dscrip;
        private int onhand;
        private string code;
        private decimal price;

        public string Description
        {
            get
            {
                return dscrip; 
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    dscrip = value;
                else
                    throw new ArgumentOutOfRangeException("Product description must be between 1 and 50 characters.");

            }
        }

        public int OnHandQuantity
        {
            get
            {
                return onhand;
            }
            set
            {
                if (value > -1 && value < int.MaxValue)
                    onhand = value;
                else
                    throw new ArgumentOutOfRangeException("On Hand Quantity can not be a negative number.");
            }
        }

        public string ProductCode
        {
            get
            {
                return code;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 10)
                    code = value;
                else
                    throw new ArgumentOutOfRangeException("Product code must be 10 characters long.");

            }
        }

        public decimal UnitPrice
        {
            get
            {
                return price;
            }
            set
            {
                int n = Convert.ToInt32(value);
                if(n > 0 && n < int.MaxValue)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0 and less than the max in value");
                }

                
            }
        }


        public override string ToString()
        {
            return Description + ", " + OnHandQuantity + ", " + ProductCode + ", " + "$" + UnitPrice;
        }
    }
}

