using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Service.Contracts;

namespace Movie.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController<T, Key> : ControllerBase where T : class
    {
        protected string OOPS_ERROR_MESSAGE = "Oops! An unexpected error has occurred! Check the log for details!";
        protected string OOPS_ACCESS_DENIED = "Oops! Access Denied!";

        protected IBaseRepository<T, Key> repository;

        public BaseController(IBaseRepository<T, Key> localRepository)
        {
            this.repository = localRepository;
        }

        protected int CurrentUserId
        {
            get
            {
                return int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            }
        }

        protected virtual async Task<IEnumerable<T>> InternalGetAll()
        {
            return await Task.FromResult(repository.GetAll());
        }

        protected virtual async Task<T> InternalGet(Key id)
        {
            return await repository.Find(id);
        }

        protected virtual async Task<T> InternalPost(T model)
        {
            return await repository.Add(model);
        }

        protected virtual async Task<T> InternalPut(T model)
        {
            return await repository.Update(model);
        }

        protected virtual async Task<T> InternalDelete(T model)
        {
            return await repository.Remove(model);
        }
    }
}