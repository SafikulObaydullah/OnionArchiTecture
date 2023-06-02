
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ICountryInfoRepo
    {
        int Create(CreateCountry crate);

        List<CreateCountry> GetAll();

        CreateCountry GetById(int id);

        int Update(int id, UpadteCountry upadteCountry);
    }
}