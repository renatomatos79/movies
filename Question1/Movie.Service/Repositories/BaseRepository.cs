using Movie.Domain.Models;
using Movie.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Repositories
{
    public class BaseRepository<T, Key> : IBaseRepository<T, Key> where T : class
    {
        protected MovieDbContext context;

        public BaseRepository(MovieDbContext ctx)
        {
            this.context = ctx;
        }

        public async Task<T> Add(T model)
        {
            await context.AddAsync<T>(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Exists(Key id)
        {
            return await this.Find(id) != null;            
        }

        public async Task<T> Find(Key id)
        {
            return await context.FindAsync<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsQueryable().AsEnumerable();
        }

        public async Task<T> Remove(Key id)
        {
            var item = await this.Find(id);
            if (item != null)
            {
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<T> Remove(T model)
        {
            if (model != null)
            {
                context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await context.SaveChangesAsync();
                return model;
            }
            return null;
        }

        public async Task<T> Update(T model)
        {
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return model;
        }
    }
}
