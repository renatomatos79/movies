using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Contracts
{
    public interface IMovieTypesRepository : IBaseRepository<Domain.Models.MovieTypes, int>
    {
        Task<Domain.Models.MovieTypes> FindByName(string name);
    }
}