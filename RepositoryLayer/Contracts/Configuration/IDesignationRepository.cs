using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IDesignationRepository
    {
        public IEnumerable<Designation> Get();
        public SaveVM Save(Designation designation);
    }
}
