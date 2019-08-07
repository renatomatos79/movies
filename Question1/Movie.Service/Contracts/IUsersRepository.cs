using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Contracts
{
    public interface IUsersRepository : IBaseRepository<Domain.Models.Users, int>
    {
        Task<Domain.Models.Users> FindByLogin(string login);
    }
}