using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IDesignationRepository
    {
        public IEnumerable<Designation> Get();
        public SaveVM Save(Designation designation);
    }
}
