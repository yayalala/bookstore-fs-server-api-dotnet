using BookstoreServerApiDotnetCore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookstoreServerApiDotnetCore.Rpositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignupModel signupModel);
        Task<string> Login(LoginModel loginModel);
    }
}