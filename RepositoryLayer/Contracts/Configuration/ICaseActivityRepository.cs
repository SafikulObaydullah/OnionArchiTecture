using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.ViewModel.Configuration.CaseActivity;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseActivityRepository
    {
        public SaveVM Save(CaseActivity caseActivity);
        public IEnumerable<CaseActivityVM> GetAllActivityByCaseId(int id);

    }
}
