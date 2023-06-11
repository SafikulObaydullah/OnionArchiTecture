using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Repository.IRepository;

using ServicesLayer.CustomerService.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.Implementation
{
   public class CountryService : ICountryService
   {
     
      private ICountryInfoRepo _repository;
      
      public CountryService(ICountryInfoRepo repository)
      {
         _repository = repository;
      }

      public void DeleteCountry(int id)
      {
         _repository.GetById(id);
      }

      public IEnumerable<CreateCountry> GetAllCountry()
      {
        return _repository.GetAll();   
      }

      public CreateCountry GetCountry(int id)
      {
         return _repository.GetById(id);
      }

      public void InsertCountry(CreateCountry country)
      {
         _repository.Create(country);
      }

      public void UpdateCountry(int id,UpadteCountry country)
      {
         _repository.Update(id, country);
      }

      
   }
}
