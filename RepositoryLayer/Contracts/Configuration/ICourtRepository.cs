using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Configuration.Court;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICourtRepository
    {
        public SaveVM Save(Court court);
        public IEnumerable<GetCourtVM> Get();
    }
}
