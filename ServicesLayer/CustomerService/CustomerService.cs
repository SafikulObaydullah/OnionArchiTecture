using DomainLayer.Models;
using DomainLayer.Models.Request;
using Microsoft.Data.SqlClient;
using RepositoryLayer.RespositoryPattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ServicesLayer.CustomerService
{
    public class CustomerService : ICustomerService
    {
        #region Property
        private IRepository<Customer> _repository;
        #endregion
        #region Constructor
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
      #endregion
      private SqlConnection connection =
                new SqlConnection("Server=DESKTOP-HJ8UUA1\\SQLEXPRESS01;Database=onionarcDb;Trusted_Connection=True;MultipleActiveResultSets=True;");

      //Get All
      //public IEnumerable<Customer> GetAllCustomers()
      //{
      //   var allCountry = new List<Customer>();

      //   try
      //   {
      //      var command = new SqlCommand("Exec GeTAllCustomer  ", connection);

      //      connection.Open();

      //      var reader = command.ExecuteReader();

      //      while (reader.Read())
      //      {
      //         var customer = new Customer();
      //         customer.CustomerName = reader["customerName"].ToString();
      //         customer.PurchasesProduct = reader["purchasesProduct"].ToString();
      //         customer.PaymentType = reader["paymentType"].ToString();
               
      //         allCountry.Add(customer);
      //      }

      //      reader.Close();
      //      connection.Close();
      //   }
      //   catch (Exception ex)
      //   {
      //      Console.WriteLine(ex.Message);
      //   }
      //   finally
      //   {
      //      if (connection.State == ConnectionState.Open)
      //      {
      //         connection.Close();
      //      }
      //   }
      //   return allCountry;
      //}
      public IEnumerable<Customer> GetAllCustomers()
      {
         return _repository.GetAll();
      }

      public Customer GetCustomer(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCustomer(Customer customer)
        {
            _repository.Insert(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _repository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = GetCustomer(id);
            _repository.Remove(customer);
            _repository.SaveChanges();
        }
    }
}
