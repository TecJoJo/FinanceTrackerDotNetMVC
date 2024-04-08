using FinanceTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceTracker.Controllers
{
    
    public class FinanceManagerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FinanceManagerController (ApplicationDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var customerIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int.TryParse(customerIdString, out int customerId);

            if (customerIdString == null)
            {

                return View();
            }
            else
            {
                var customer = _dbContext.Customers
                                 .Include(c => c.Incomes) // Include related Orders
                                 .Include(c => c.Expenses) // Include related Orders
                                 .FirstOrDefault(e => e.CustomerId == customerId);

                return View(customer);

            }
        }
    }
}
