using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.ServiceInterface
{
   public interface ICustomerInfoService
   {
      IEnumerable<CustomerInfo> GetAllCustomer();
      CustomerInfo GetCustomer(int id);
      void InsertCustomer(CustomerInfo country);
      void UpdateCustomer(int id,UpdateCustomerInfo customer);
      void DeleteCustomer(int id);
   }
}
