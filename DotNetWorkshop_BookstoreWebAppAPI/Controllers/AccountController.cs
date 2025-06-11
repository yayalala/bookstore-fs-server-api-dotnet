using DotNetWorkshop_BookstoreWebAppAPI.Models;
using DotNetWorkshop_BookstoreWebAppAPI.Rpositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWorkshop_BookstoreWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Signup([FromBody] SignupModel signupModel)
        {
            var res = await _accountRepository.SignUp(signupModel);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var res = await _accountRepository.Login(loginModel);
            if (string.IsNullOrWhiteSpace(res))
            {
                return Unauthorized();
            }
            return Ok(res);
        }
    }
}
