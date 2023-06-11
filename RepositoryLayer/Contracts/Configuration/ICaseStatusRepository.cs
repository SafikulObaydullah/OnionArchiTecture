using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
 


namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseStatusRepository
    {
        public IEnumerable<CaseStatus> Get();
        public SaveVM Save(CaseStatus caseStatus);
    }
}
