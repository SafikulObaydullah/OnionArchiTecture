using DomainLayer.Models.Accounts;
using DomainLayer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts
{
    public interface IRepositoryRegistration
    {
        void AddInfrastucture(IServiceCollection services, string conStr);
    }
}
