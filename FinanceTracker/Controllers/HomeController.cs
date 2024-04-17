using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using FinanceTracker.Utils;
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

            var userName = User.FindFirst("userName")?.Value;

            if (customerIdString == null)
            {

                var emptyIndexViewModel = new HomeIndexViewModel();
            return View(emptyIndexViewModel);
            }
            else
            {



                //if the user is logged in 

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



                

                //prepare the data for the charts 

                //code for bar chart, daily expense income analyses

              

               
                var last30DaysSavings = transactions?.Where(t => t.TimeStamp > DateTime.Now.AddDays(-30)).Sum(t => t.Amount);
                var dateLabels = dateCalculation.GetLast30Days().OrderBy(x => x).Select(x => x.ToString("MMMM dd"));
                var days = dateCalculation.GetLast30Days().OrderBy(x => x);
                List<decimal> dailyIncomes = new List<decimal>();

                foreach (var day in days)
                {
                    var dailyIncome = transactions?.Where(t => t.Type == CategoryType.Income.ToString()
                        && t.TimeStamp.Year == day.Year
                        && t.TimeStamp.Month == day.Month
                        && t.TimeStamp.Day == day.Day)
                        .Sum(t => t.Amount) ?? 0;
                    dailyIncomes.Add(dailyIncome);
                }

                List<decimal> dailyExpenses = new List<decimal>();

                foreach (var day in days)
                {
                    var dailyExpense = transactions?.Where(t => t.Type == CategoryType.Expense.ToString()
                        && t.TimeStamp.Year == day.Year
                        && t.TimeStamp.Month == day.Month
                        && t.TimeStamp.Day == day.Day)
                        .Sum(t => t.Amount) ?? 0;
                    dailyExpenses.Add(dailyExpense);
                    Console.WriteLine(dailyExpense);
                }

                //data for the combo chart

                var mothLabels = dateCalculation.GetLast12Months().OrderBy(x => x).Select(x => x.ToString("yyyy MMMM"));
                var months = dateCalculation.GetLast12Months().OrderBy(x => x);



                List<decimal> monthSavings = new List<decimal>();

                foreach (var month in months)
                {
                    var MonthSaving = transactions?.Where(t =>
                        t.TimeStamp.Year == month.Year
                        && t.TimeStamp.Month == month.Month)
                        .Sum(t => t.Amount) ?? 0;

                    monthSavings.Add(MonthSaving);
                }

                List<decimal> monthExpenses = new List<decimal>();

                foreach (var month in months)
                {
                    var MonthExpense = transactions?.Where(t =>
                        t.TimeStamp.Year == month.Year
                        && t.TimeStamp.Month == month.Month
                        && t.Type == CategoryType.Expense.ToString())
                        .Sum(t => t.Amount) ?? 0;

                    monthExpenses.Add(MonthExpense);
                }

                List<decimal> monthIncomes = new List<decimal>();

                foreach (var month in months)
                {
                    var MonthIncome = transactions?.Where(t =>
                        t.TimeStamp.Year == month.Year
                        && t.TimeStamp.Month == month.Month
                        && t.Type == CategoryType.Income.ToString())
                        .Sum(t => t.Amount) ?? 0;

                    monthIncomes.Add(MonthIncome);
                }


                //query for the saving goal 
                var savingGoal = _dbContext.Customers.Find(customerId)?.SavingGoal;


                var homeIndexViewModel = new HomeIndexViewModel()
                {
                    Transactions = transactions ?? new List<TransactionViewModel>(),
                    ChartsData = new ChartDataViewModel()
                    {
                        DateLabels = dateLabels.ToList(),
                        DailyIncomes = dailyIncomes,
                        DailyExpenses = dailyExpenses,
                        MonthLabels = mothLabels.ToList(),
                        MonthSavings = monthSavings,
                        MonthExpenses = monthExpenses,
                        MonthIncomes = monthIncomes
                    },

                    Last30DaysSavings = last30DaysSavings??0,
                    UserName = userName??"Anonymous User",
                    CustomerId = customerId,
                    SavingGoal = savingGoal,    
                    

                };

                return View(homeIndexViewModel);

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
