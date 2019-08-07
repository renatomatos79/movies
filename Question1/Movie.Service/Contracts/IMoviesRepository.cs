using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Contracts
{
    public interface IMoviesRepository : IBaseRepository<Domain.Models.Movies, int>
    {
        Task<IEnumerable<Domain.Models.Movies>> Search(string title);
    }
}