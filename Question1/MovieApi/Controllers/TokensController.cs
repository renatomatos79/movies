using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Movie.Api.Models.Response;
using Movie.Framework;
using Movie.Service.Contracts;

namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("api/token")]
    [Produces("application/json")]   
    public class TokensController : BaseController<Domain.Models.Tokens, string>
    {
        private IUsersRepository _userRepository;

        public TokensController(ITokensRepository tokenRepository, IUsersRepository userRepository) : base(tokenRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        [Produces(typeof(Domain.Models.Tokens))]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] Models.Request.LoginRequest request)
        {
            var result = new TokenResponse();
            try
            {
                #region .: request validation :.

                if (request == null)
                {
                    throw new ApplicationException("Request cannot be null!");
                }
                if (string.IsNullOrEmpty(request.Login))
                {
                    throw new ApplicationException("Login cannot be null");
                }
                if (string.IsNullOrEmpty(request.Password))
                {
                    throw new ApplicationException("Password cannot be null");
                }
                var user = await _userRepository.FindByLogin(request.Login);
                if (user == null)
                {
                    throw new ApplicationException($"User {request.Login} not found!");
                }

                var password = SecurityUtils.Encrypt(request.Password, user.Saltkey);
                if (!user.Password.Equals(password))
                {
                    throw new ApplicationException($"Invalid Login or Password!");
                }

                #endregion

                var token = new Domain.Models.Tokens
                {
                    Token = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    DtExpiration = DateTime.UtcNow.AddDays(1),
                    Active = true,
                    DtCreated = DateTime.UtcNow
                };

                await base.InternalPost(token);

                return Ok(TokenResponse.FromModel(token, user));
            }
            catch (ApplicationException ex)
            {
                LogUtils.Add("TokensController.Authenticate", ex);
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                LogUtils.Add("TokensController.Authenticate", ex);
                result.Message = this.OOPS_ACCESS_DENIED;
                result.Success = false;
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                LogUtils.Add("TokensController.Authenticate", ex);
                result.Message = this.OOPS_ERROR_MESSAGE;
                result.Success = false;
                return NotFound(result);
            }
        }
    }
}