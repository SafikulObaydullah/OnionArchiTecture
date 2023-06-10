using DIFECMS.Domain.Models.Configuration;
using DIFECMS.Domain.ViewModel;
using DIFECMS.Domain.ViewModel.Configuration.Court;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface ICourtRepository
    {
        public SaveVM Save(Court court);
        public IEnumerable<GetCourtVM> Get();
    }
}
