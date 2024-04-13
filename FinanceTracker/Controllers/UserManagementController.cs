using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
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
            var userToEdit = _dbContext.Customers.Find(userUpdateForm.CustomerId);
            if (userToEdit == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                userToEdit.UserName = userUpdateForm.UserName;
                userToEdit.Email = userUpdateForm.Email;

                _dbContext.SaveChanges();   
                return RedirectToAction("Index");
            }



        }
    }
}
