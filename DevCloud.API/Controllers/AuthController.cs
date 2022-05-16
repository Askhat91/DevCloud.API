using DevCloud.API.ViewModels;
using DevCloud.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Получение токена
        /// </summary>
        /// <remarks></remarks>
        /// <param name="account"></param>
        /// <response code="200">Успешно</response>
        /// 
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] Account account)
        {
            var user = await _userService.GetByLoginPassword(account.Login, account.Password);

            if (user != null)
            {
                var result = _tokenService.Create(user);

                return Ok(result);
            }

            return BadRequest(new { error = "Неправильный логин или пароль.", status = 400 });
        }
    }
}
