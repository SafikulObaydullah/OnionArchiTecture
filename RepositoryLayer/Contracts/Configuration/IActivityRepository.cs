using DIFECMS.Domain.Models;
using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IActivityRepository
    {
        public IEnumerable<Activity> Get();
        public SaveVM Save(Activity activity);
    }
}
