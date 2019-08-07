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
    [Route("api/movie-types")]
    [Produces("application/json")]
    public class MovieTypesController : BaseController<Domain.Models.MovieTypes, int>
    {
        public MovieTypesController(IMovieTypesRepository reporitory) 
            : base(reporitory) { }

        [HttpGet]
        [Produces(typeof(List<Domain.Models.MovieTypes>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await base.InternalGetAll();
                var rows = result.ToList().Select(s => MovieTypesResponse.FromModel(s));
                return new ObjectResult(rows);
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MovieTypesController.GetAll", ex);
                return BadRequest(new MovieTypesResponse { Message = ex.Message, Success = false });
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MovieTypesController.GetAll", ex);
                return Unauthorized(new MovieTypesResponse { Message = this.OOPS_ACCESS_DENIED, Success = false });
            }
            catch (Exception ex)
            {
                LogUtils.Add("MovieTypesController.GetAll", ex);
                return NotFound(new MovieTypesResponse { Message = this.OOPS_ERROR_MESSAGE, Success = false });
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(Domain.Models.MovieTypes))]
        public async Task<IActionResult> GetValue([FromRoute] int id)
        {
            var result = new MovieTypesResponse();
            try
            {
                #region .: request validation :.

                if (id <= 0)
                {
                    throw new ApplicationException("Invalid ID");
                }
                var repository = base.repository as IMovieTypesRepository;
                var model = await repository.Find(id);
                if (model == null)
                {
                    throw new ApplicationException($"Movie Type {id} not found!");
                }

                #endregion

                return Ok(MovieTypesResponse.FromModel(model));
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MovieTypesController.GetValue", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MovieTypesController.GetValue", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("MovieTypesController.GetValue", ex);
                result.Message = base.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }

        [HttpPost]
        [Produces(typeof(Domain.Models.MovieTypes))]
        public async Task<IActionResult> PostValue([FromBody] Models.Request.MovieTypesRequest request)
        {
            var result = new MovieTypesResponse();
            try
            {
                #region .: request validation :.

                if (request == null) 
                {
                    throw new ApplicationException("Request cannot be null!");
                }
                if (string.IsNullOrEmpty(request.Name))
                {
                    throw new ApplicationException("Name cannot be null");
                }
                var repository = base.repository as IMovieTypesRepository;
                var movieTypes = await repository.FindByName(request.Name);
                if (movieTypes != null)
                {
                    throw new ApplicationException($"Already exists a Movie Type with this name {request.Name}!");
                }

                #endregion

                var model = new Domain.Models.MovieTypes
                {
                    Name = request.Name,
                    Active = request.Active,
                    DtCreated = DateTime.Now,
                    CreatedBy = CurrentUserId
                };

                return Ok(MovieTypesResponse.FromModel(await base.InternalPost(model)));
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MovieTypesController.PostValue", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MovieTypesController.PostValue", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("MovieTypesController.PostValue", ex);
                result.Message = base.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }

        [HttpPut]
        [Produces(typeof(Domain.Models.MovieTypes))]
        public async Task<IActionResult> PutValue([FromRoute] int id, [FromBody] Models.Request.MovieTypesRequest request)
        {
            var result = new MovieTypesResponse();
            try
            {
                #region .: request validation :.

                if (request == null)
                {
                    throw new ApplicationException("Request cannot be null!");
                }
                if (id <= 0)
                {
                    throw new ApplicationException("Invalid ID");
                }
                if (string.IsNullOrEmpty(request.Name))
                {
                    throw new ApplicationException("Name cannot be null");
                }
                var repository = base.repository as IMovieTypesRepository;
                var area = await repository.Find(id);
                if (area == null)
                {
                    throw new ApplicationException($"Movie Type {id} not found!");
                }

                #endregion

                area.Name = request.Name;
                area.Active = request.Active;
                area.DtModified = DateTime.Now;
                area.ModifiedBy = CurrentUserId;

                return Ok(MovieTypesResponse.FromModel(await base.InternalPost(area)));
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MovieTypesController.PutValue", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MovieTypesController.PutValue", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("MovieTypesController.PutValue", ex);
                result.Message = base.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }

        [HttpDelete]
        [Produces(typeof(Domain.Models.MovieTypes))]
        public async Task<IActionResult> DeleteValue([FromRoute] int id)
        {
            var result = new MovieTypesResponse();
            try
            {
                #region .: request validation :.

                if (id <= 0)
                {
                    throw new ApplicationException("Invalid ID");
                }
                var repository = base.repository as IMovieTypesRepository;
                var model = await repository.Find(id);
                if (model == null)
                {
                    throw new ApplicationException($"Movie Type {id} not found!");
                }

                #endregion

                return Ok(await base.InternalDelete(model));
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("MovieTypesController.DeleteValue", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("MovieTypesController.DeleteValue", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("MovieTypesController.DeleteValue", ex);
                result.Message = base.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }
    }
}