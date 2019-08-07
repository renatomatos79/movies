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
    public class MovieTypesRepository : BaseRepository<Domain.Models.MovieTypes, int>, IMovieTypesRepository
    {
        public MovieTypesRepository(MovieDbContext context) : base(context) { }

        public async Task<Domain.Models.MovieTypes> FindByName(string name)
        {
            return await context.MovieTypes.FirstOrDefaultAsync(a => a.Name == name);
        }

    }
}
