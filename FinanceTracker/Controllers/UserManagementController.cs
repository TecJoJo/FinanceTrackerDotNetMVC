using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;  

        public UserManagementController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public IActionResult Index()
        {
            List<Customer>? users = _dbContext.Customers.ToList();
            if (users == null) return View();
            else
            {
               var userList =  users.Select(user => new UserViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    Role = Enum.GetName(typeof(Role), user.Role)!,
                    FirstName = user.FirstName??"N/A",
                    LastName = user.LastName?? "N/A",
                    CustomerId = user.CustomerId,   

                }).ToList()??new List<UserViewModel>();

            return View(userList);
            }
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userUpdateForm)
        {
            if (!ModelState.IsValid)
            {
                // Constructing an object with the error message
                var errorObject = new { error = "Invalid form" };

                // Returning the error object as JSON
                return Json(errorObject);
            }
            var userToEdit = _dbContext.Customers.Find(userUpdateForm.CustomerId);
            if (userToEdit == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                userToEdit.UserName = userUpdateForm.UserName;
                userToEdit.Email = userUpdateForm.Email;
                userToEdit.Password = userUpdateForm.Password;
                userToEdit.FirstName = userUpdateForm.FirstName;
                userToEdit.LastName = userUpdateForm.LastName;
                userToEdit.Role = (Role)Enum.Parse(typeof(Role), userUpdateForm.Role);


                _dbContext.SaveChanges();   
                return RedirectToAction("Index");
            }



        }
    }
}
