using FinanceTracker.Models;
using FinanceTracker.ViewModel;
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
                var transactions = _dbContext.Transactions.Where(e => e.CustomerId == customerId)
                                           .OrderByDescending(e => e.TimeStamp)
                                           .Include(e => e.Category)
                                           .Select(e => new TransactionViewModel()
                                           {
                                               TimeStamp = e.TimeStamp,
                                               Amount = e.amount,
                                               Description = e.description,
                                               Id = e.TransactionId,
                                               Type = e.Category.type.ToString()

                                           }).ToList();



                FinanceTrackerIndexViewModel indexViewModel = new FinanceTrackerIndexViewModel()
                {


                    transactionListItems = transactions


                };

                return View(indexViewModel);

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
