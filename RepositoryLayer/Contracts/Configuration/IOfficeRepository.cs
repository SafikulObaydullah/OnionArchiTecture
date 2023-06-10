using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using DIFECMS.Domain.ViewModel.Configuration.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IOfficeRepository
    {
        public IEnumerable<UserBasedOfficeVM> GetUserBasedOffice(long id);
        public SaveVM Save(Office office);
        public IEnumerable<GetOfficeVM> Get();
    }
}
