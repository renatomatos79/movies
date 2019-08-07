using Microsoft.EntityFrameworkCore;
using Movie.Domain.Models;
using Movie.Service.Contracts;
using Movie.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Repositories
{
    public class UsersRepository : BaseRepository<Domain.Models.Users, int>, IUsersRepository
    {
        public UsersRepository(MovieDbContext context) : base(context) { }

        public async Task<Domain.Models.Users> FindByLogin(string login)
        {
            return await context.Users.FirstOrDefaultAsync(a => a.Login == login);
        }
    }
}
