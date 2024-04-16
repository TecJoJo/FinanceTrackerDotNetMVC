using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FinanceTracker.Utils
{
    public static class Auth
    {
        public static Customer? IdentityValidation(LoginViewModel userInfo, ApplicationDbContext dbContext)
        {
            Customer? customer = dbContext.Customers.FirstOrDefault(c => c.UserName == userInfo.userName);

            return customer;


        }

        public static async Task<bool> Login(string passwordInput, Customer customer, HttpContext httpContext)
        {
            if (passwordInput == customer.Password)
            {

                string RoleName = Enum.GetName(typeof(Role), customer.Role)!;
                var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                new Claim(ClaimTypes.Role,RoleName),
                new Claim("userName",customer.UserName)

            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = true,
                };
                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );

                return true;
            }
            else
            {
                //if password is not corresponding to the database, we do nothing 
                return false;
            }

        }
    }
}
