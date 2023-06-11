using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Configuration.CaseType;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseTypeRepository
    {
        public SaveVM Save(CaseType caseType);
        public IEnumerable<GetCaseTypeVM> Get();
    }
}
