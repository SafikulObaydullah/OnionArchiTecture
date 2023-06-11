using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Configuration.Office;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IOfficeRepository
    {
        public IEnumerable<UserBasedOfficeVM> GetUserBasedOffice(long id);
        public SaveVM Save(Office office);
        public IEnumerable<GetOfficeVM> Get();
    }
}
