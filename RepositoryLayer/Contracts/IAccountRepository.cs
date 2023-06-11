using DomainLayer.Models.Accounts;
using DomainLayer.ViewModel;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<LoginUser> GetAuthenticUserData(Login o);
        IEnumerable<LoginUser> GetAllUserData();
        IEnumerable<SaveVM> SaveUser(LoginUser o);
    }
}
