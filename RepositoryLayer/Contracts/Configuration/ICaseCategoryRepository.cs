using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.ViewModel.Configuration.CaseCategory;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseCategoryRepository
    {
        public IEnumerable<CaseCategoryVM> Get();
        public SaveVM Save(CaseCategory caseCategory);
    }
}
