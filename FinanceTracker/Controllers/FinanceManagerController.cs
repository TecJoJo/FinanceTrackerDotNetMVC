using FinanceTracker.Models;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FinanceTracker.Controllers
{

    public class FinanceManagerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FinanceManagerController(ApplicationDbContext dbContext)
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
            // the user is logged into the app 
            else
            {
                var customer = _dbContext.Customers
                                 .Include(c => c.Incomes) // Include related Orders
                                 .Include(c => c.Expenses) // Include related Orders
                                 .FirstOrDefault(e => e.CustomerId == customerId);

                //var incomes = _dbContext.Incomes
                //                    .Where(x => x.CustomerId == customerId)
                //                    .Select(e => new
                //                    {
                //                       type = "Income",
                //                       timeStemp = e.TimeStamp,
                //                       category = e.Category,
                //                       amount = e.amount,
                //                       description = e.description,


                //                    });
                //var expenses = _dbContext.Expenses
                //                   .Where(x => x.CustomerId == customerId)
                //                   .Select(e => new
                //                   {
                //                       type = "Expense",
                //                       timeStemp = e.TimeStamp,
                //                       category = e.Category,
                //                       amount = e.amount,
                //                       description = e.description,


                //                   });

                //var transactions = incomes.Concat(expenses);



                var customerIncomes = _dbContext.Incomes
                    .Where(i => i.CustomerId == customerId)
                    .OrderByDescending(i => i.TimeStamp)
                    .Take(5)
                    .Select(i => new TransactionViewModel()
                    {
                        TimeStamp = i.TimeStamp,
                        Amount = i.amount,
                        Description = i.description,
                        Category = i.Category.ToString(),
                        Id = i.IncomeId,
                        Type = "Income",
                    })
                    .ToList();

                var customerExpenses = _dbContext.Expenses
                    .Where(e => e.CustomerId == customerId)
                    .OrderByDescending(e => e.TimeStamp)
                    .Take(5)
                    .Select(e => new TransactionViewModel()
                    {
                        TimeStamp = e.TimeStamp,
                        Amount = e.amount,
                        Description = e.description,
                        Category = e.Category.ToString(),
                        Id = e.ExpenseId,
                        Type = "Expense"
                    })
                    .ToList();

                var customerTransactions = customerIncomes
                    .Concat(customerExpenses)
                    .OrderByDescending(t => t.TimeStamp)
                    .ToList();


                return View(customerTransactions);

            }
        }

        public IActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Edit(TransactionEditFormView EditForm)
        {
            var temp = EditForm;
            return PartialView(EditForm);
        }
    }
        

        
}
