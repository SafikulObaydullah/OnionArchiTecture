
using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ICustomerRepo
   {
        int Create(CustomerInfo customer);

        List<CustomerInfo> GetAll();

        CustomerInfo GetById(int id);

        int Update(int id, UpdateCustomerInfo updateCustomer);
        int Delete(int id);
    }
}