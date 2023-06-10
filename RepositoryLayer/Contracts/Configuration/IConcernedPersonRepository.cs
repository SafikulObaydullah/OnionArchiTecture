using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IConcernedPersonRepository
    {
        public IEnumerable<ConcernedPerson> Get(int Creator);
        public SaveVM Save(ConcernedPerson concernedPerson);
    }
}
