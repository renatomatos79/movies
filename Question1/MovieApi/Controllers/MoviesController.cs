using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movie.Api.Controllers;
using Movie.Api.Models.Response;
using Movie.Framework;
using Movie.Service.Contracts;

namespace Movie.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/movies")]
    [Produces("application/json")]
    public class MoviesController : BaseController<Domain.Models.Movies, int>
    {
        public MoviesController(IMoviesRepository reporitory) 
            : base(reporitory) { }

        [HttpGet("search/{title}/page/{page:int=1}")]
        [Produces(typeof(Domain.Models.Movies))]
        public async Task<IActionResult> Search([FromRoute] string title, string page)
        {
            var result = new MovieListResponse
            {
                Page = ConvertUtils.ToInt(page) > 0 ? ConvertUtils.ToInt(page) : 1,
                PerPage = 10
            };           
            
            var skip = (result.Page - 1) * result.PerPage;
            try
            {
                var repository = base.repository as IMoviesRepository;
                var rows = await repository.Search(title);

                result.Total = rows.Count();
                result.TotalPages = (result.Total / result.PerPage) + (result.Total % result.PerPage == 0 ? 0 : 1);
                result.Data = rows.Skip(skip).Take(result.PerPage).ToList().Select(s => MovieResponse.FromModel(s)).ToList();
                result.Success = true;

                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MoviesController.Search", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MoviesController.Search", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("MoviesController.Search", ex);
                result.Message = base.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }       
    }
}