using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Repository.IRepository;
using RepositoryLayer.RespositoryPattern;
using ServicesLayer.CustomerService.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.Implementation
{
   public class CustomerInfoService : ICustomerInfoService
   {
      private ICustomerRepo _repository;
      public CustomerInfoService(ICustomerRepo repository)
      {
         this._repository = repository;
      }
      public void DeleteCustomer(int id)
      {
         _repository.Delete(id);
      }

      public IEnumerable<CustomerInfo> GetAllCustomer()
      {
         return _repository.GetAll();
      }

      public CustomerInfo GetCustomer(int id)
      {
         return _repository.GetById(id);
      }

      public void InsertCustomer(CustomerInfo customer)
      {
         _repository.Create(customer);
      }

      public void UpdateCustomer(int id, UpdateCustomerInfo customer)
      {
         _repository.Update(id, customer);
      }
   }
}
