using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
 

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseNatureRepository
    {
        public IEnumerable<CaseNature> Get();
        public SaveVM Save(CaseNature caseNature);
    }
}
