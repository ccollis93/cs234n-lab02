using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {

        public static bool AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement = "INSERT Products " +
                                     "(Description, OnHandQuantity, ProductCode, UnitPrice) " +
                                     "VALUES (@Description, @OnHandQuantity, @ProductCode, @UnitPrice)";

            MySqlCommand insertCommand = new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);

            try
            {
                connection.Open();
                int addCheck = insertCommand.ExecuteNonQuery();

                if (addCheck == 1)
                    return true;
                else
                    return false;
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement = "DELETE FROM Products " +
                                     "WHERE Description = @Description " +
                                     "AND OnHandQuantity = @OnHandQuantity " +
                                     "AND ProductCode = @ProductCode " +
                                     "AND UnitPrice = @UnitPrice ";

            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);

            try
            {
                connection.Open();
                int delCheck = deleteCommand.ExecuteNonQuery();
                if (delCheck == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }

        public static List<Product> GetList()
        {
            //initialize the list
            List<Product> products = new List<Product>();
            //connect to the db
            MySqlConnection connection = MMABooksDB.GetConnection();

            string selectStatement = "SELECT Description, OnHandQuantity, ProductCode, UnitPrice "
                                     + "FROM Products "
                                     + "ORDER BY OnHandQuantity";

            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    // make a new product
                    Product p = new Product();

                    //I don't think I entierly understand these, but if we are making a list of
                    //the Products it must be pulling them out of the DB and assigning them the appropriate 
                    //data types?
                    p.Description = reader["Description"].ToString();
                    p.OnHandQuantity = (int)reader["OnHandQuantity"];
                    p.ProductCode = reader["ProductCode"].ToString();
                    p.UnitPrice = (decimal)reader["UnitPrice"];
                    products.Add(p);
                }
                reader.Close();
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;

        }

        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();

            string selectStatement = "SELECT Description, OnHandQuantity, ProductCode, UnitPrice "
                                     + "FROM Products "
                                     + "WHERE ProductCode = @ProductCode";

            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.Description = prodReader["Description"].ToString();
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];

                    prodReader.Close();
                    return product;
                }
                else
                    return null;
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement = "UPDATE Products SET " +
                                     "Description = @NewDescription, " +
                                     "OnHandQuantity = @NewOnHandQuantity, " +                                     
                                     "UnitPrice = @NewUnitPrice " +
                                     "WHERE Description = @OldDescription " +
                                     "AND OnHandQuantity = @OldOnHandQuantity " +
                                     "AND ProductCode = @OldProductCode " +                                                                        
                                     "AND UnitPrice = @OldUnitPrice ";

            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);            
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);

            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);

            try
            {
                connection.Open();
                int upCheck = updateCommand.ExecuteNonQuery();

                if (upCheck == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {  
                throw ex;
            }
            finally
            {
                
                connection.Close();
            }
        }

    }
}
