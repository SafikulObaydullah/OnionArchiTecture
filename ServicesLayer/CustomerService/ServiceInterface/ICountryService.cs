using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.ServiceInterface
{
   public interface ICountryService
   {
      IEnumerable<CreateCountry> GetAllCountry();
      CreateCountry GetCountry(int id);
      void InsertCountry(CreateCountry country);
      void UpdateCountry(int id,UpadteCountry country);
      void DeleteCountry(int id);
   }
}
