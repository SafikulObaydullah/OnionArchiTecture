using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Microsoft.Data.SqlClient;

using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Repository
{
    public class CustomerInfoRepo : ICustomerRepo
   {
        private SqlConnection connection =
                new SqlConnection("Server=DESKTOP-MV6UQ21\\SQLEXPRESS;Database=onionarcDb;Trusted_Connection=True;MultipleActiveResultSets=True;");

        //Get All
        public List<CustomerInfo> GetAll()
        {
            var allCountry = new List<CustomerInfo>();

            try
            {
                var command = new SqlCommand("Exec GeTAllCustomer", connection);
            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue( "get","@partName");

            connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                     var customer = new CustomerInfo();
                     customer.Id = Convert.ToInt16(reader["Id"]);
                     customer.CustomerName = reader["customerName"].ToString();
                     customer.PurchasesProduct = reader["purchasesProduct"].ToString();
                     customer.PaymentType = reader["paymentType"].ToString();
                     allCountry.Add(customer);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return allCountry;
        }

        //GetById
        public CustomerInfo GetById(int id)
        {
            var customer = new CustomerInfo();
            try
            {
                var command = new SqlCommand("Exec GetByIdCustomerInfo @Id='" + id + "'", connection);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customer.Id = Convert.ToInt16(reader["id"]);
                    customer.CustomerName = reader["customerName"].ToString();
                    customer.PurchasesProduct = reader["purchasesProduct"].ToString();
                    customer.PaymentType = reader["paymentType"].ToString();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return customer;
        }

        //Create
        public int Create(CustomerInfo customer)
        {
            int rowsAffected = 0;
            try
            {
                var command = new SqlCommand("exec spInsertCustomerInfo @CustomerName='" + customer.CustomerName + "', @PurchasesProduct='" + customer.PurchasesProduct + "', @PaymentType='" + customer.PaymentType + "'", connection);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rowsAffected;
        }
        public int Update(int id, UpdateCustomerInfo upadteCustomer)
        {
            int rowsAffected = 0;
            try
            {
               var command = new SqlCommand("exec onionarcDb.dbo.spUpdateCustomerInfo @Id='" + id+ "', @CustomerName='" + upadteCustomer.CustomerName + "', @PurchasesProduct='" + upadteCustomer.PurchasesProduct + "', @PaymentType='" + upadteCustomer.PaymentType + "'", connection);
               connection.Open();
               rowsAffected = command.ExecuteNonQuery();
               connection.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
            return rowsAffected;
        }
        public int Delete(int id)
        {
            int rowsAffected = 0;
            try
            {
               var command = new SqlCommand("onionarcDb.dbo.spDeleteCustomerInfo @Id='" + id +"'", connection);
               connection.Open();
               //GetAll();
               rowsAffected = command.ExecuteNonQuery();
               connection.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
            return rowsAffected;
         }
    }
}