using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Contracts
{
    public interface IBaseRepository <T, Key> where T : class
    {
        Task<T> Add(T model);
        IEnumerable<T> GetAll();
        Task<T> Find(Key id);
        Task<T> Update(T model);
        Task<T> Remove(Key id);
        Task<T> Remove(T model);
        Task<bool> Exists(Key id);
    }
}
