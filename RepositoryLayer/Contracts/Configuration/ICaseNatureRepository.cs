using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICaseNatureRepository
    {
        public IEnumerable<CaseNature> Get();
        public SaveVM Save(CaseNature caseNature);
    }
}
