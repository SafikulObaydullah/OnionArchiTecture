


using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer.CustomerService.ServiceInterface
{
   public interface IOfficeService
   {
      CustomerInfo GetById(int id);
   }
}
