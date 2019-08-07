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
    public class MoviesRepository : BaseRepository<Domain.Models.Movies, int>, IMoviesRepository
    {
        public MoviesRepository(MovieDbContext context) : base(context) { }
    }
}
