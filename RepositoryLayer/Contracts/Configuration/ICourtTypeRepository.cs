using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using DIFECMS.Domain.ViewModel.Configuration.CourtType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICourtTypeRepository
    {
        public SaveVM Save(CourtType courtType);
        public IEnumerable<GetCourtTypeVM> Get();
    }
}
