using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseStatusRepository
    {
        public IEnumerable<CaseStatus> Get();
        public SaveVM Save(CaseStatus caseStatus);
    }
}
