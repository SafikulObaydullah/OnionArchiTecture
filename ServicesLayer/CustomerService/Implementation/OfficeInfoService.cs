
using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Repository.IRepository;
using RepositoryLayer.Contracts.Configuration;
using ServicesLayer.CustomerService.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.Implementation
{
   public class OfficeInfoService : IOfficeService
   {
      private IOfficeRepository _repository;
      public OfficeInfoService(IOfficeRepository repository)
      {
         this._repository = repository;
      }

      //public CustomerInfo GetById(int id)
      //{
      //   throw new NotImplementedException();
      //}

      public CustomerInfo GetById(int id)
      {
         return _repository.GetById(id);
      }
      //public void DeleteCustomer(int id)
      //{
      //   _repository.Delete(id);
      //}

      //public IEnumerable<CustomerInfo> GetAllCustomer()
      //{
      //   return _repository.GetAll();
      //}

      //public void InsertCustomer(CustomerInfo customer)
      //{
      //   _repository.Create(customer);
      //}

      //public void UpdateCustomer(int id, UpdateCustomerInfo customer)
      //{
      //   _repository.Update(id, customer);
      //}
   }
}
