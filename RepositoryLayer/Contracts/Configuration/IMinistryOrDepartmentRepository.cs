using DomainLayer.Models.Configuration;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Configuration.MinistryOrDepartment;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts.Configuration
{
    public interface IMinistryOrDepartmentRepository
    {
        public SaveVM Save(MinistryOrDepartment ministryOrDepartment);
        public IEnumerable<GetMinistryOrDepartmentVM> Get();
    }
}
