using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
namespace RepositoryLayer.Contracts.Configuration
{
    public interface IUserTypeRepository
    {
        public SaveVM Save(UserType userType);
        public IEnumerable<UserType> Get();
    }
}
