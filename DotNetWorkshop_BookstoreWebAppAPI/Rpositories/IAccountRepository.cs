using DotNetWorkshop_BookstoreWebAppAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DotNetWorkshop_BookstoreWebAppAPI.Rpositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignupModel signupModel);
        Task<string> Login(LoginModel loginModel);
    }
}