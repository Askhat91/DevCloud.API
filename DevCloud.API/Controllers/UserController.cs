using DevCloud.API.ViewModels;
using DevCloud.Core.Entities;
using DevCloud.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="create">модель для пользования</param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewUser create)
        {
            if (await _userService.GetByLogin(create.Login) is not null)
                return BadRequest(new { error = "Пользователь с таким логином существует!" });

            User newUser = new User()
            {
                Login = create.Login,
                FirstName = create.FirstName,
                LastName = create.LastName,
                CreatedDate = DateTime.Now,
            };

            newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, create.Password);

            try
            {
                await _userService.Create(newUser);

                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
