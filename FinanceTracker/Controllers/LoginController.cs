﻿using FinanceTracker.Models;
using FinanceTracker.Utils;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
        [ValidateAntiForgeryToken]
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

        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register () {
        
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerForm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerForm);
            }
            else
            {
                _dbContext.Customers.Add(
                    new Customer
                    {
                        UserName = registerForm.UserName,
                        Email = registerForm.Email,
                        Password = registerForm.Password,
                        Role = Models.Enums.Role.user,
                        Balance = 0,

                       
                    }

                    );
                _dbContext.SaveChanges(); 
                return RedirectToAction("Index");
            }

            
           

        }


    }
}
