using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IConcernedPersonRepository
    {
        public IEnumerable<ConcernedPerson> Get(int Creator);
        public SaveVM Save(ConcernedPerson concernedPerson);
    }
}
