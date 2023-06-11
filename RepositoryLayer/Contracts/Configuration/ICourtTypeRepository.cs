using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Configuration.CourtType;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICourtTypeRepository
    {
        public SaveVM Save(CourtType courtType);
        public IEnumerable<GetCourtTypeVM> Get();
    }
}
