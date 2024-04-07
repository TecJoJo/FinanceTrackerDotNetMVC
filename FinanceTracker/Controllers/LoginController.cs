using FinanceTracker.Models;
using FinanceTracker.Utils;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            else
            {
                Customer? customer = Auth.IdentityValidation(loginViewModel, _dbContext);

                if (customer == null)
                {
                    return View(loginViewModel);
                }
                else
                {


                    Auth.Login(customer, this.HttpContext);


                    return RedirectToAction("Index", "Home");   

                }
                
                
            }

        }



    }
}
