using DomainLayer.Models.Accounts;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Permission;
using DomainLayer.ViewModel.User;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts
{
    public interface IAdminRepository
    {
        public IEnumerable<UserPermissionVM> SearchPermission(PermissionSearchVM permissionSearch);
        public IEnumerable<UserOfficePermissionVM> UserOfficePermission(int Id);
        public SaveVM AddOfficePermission(OfficePermissionAddVM officePermission);
    }
}
