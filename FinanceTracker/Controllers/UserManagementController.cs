using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using FinanceTracker.ViewModel;
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


                }).ToList();

            return View(userList);
            }
        }
    }
}
