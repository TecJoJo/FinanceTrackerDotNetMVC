using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace FinanceTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

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
                //var customer = _dbContext.Customers
                //                 .Include(c => c.Incomes) // Include related Orders
                //                 .Include(c => c.Expenses) // Include related Orders
                //                 .FirstOrDefault(e => e.CustomerId == customerId);

                return View();

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
