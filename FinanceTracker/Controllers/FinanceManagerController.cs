using FinanceTracker.Models;
using FinanceTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                

                var transactions = _dbContext.Transactions.Where(e => e.CustomerId == customerId)
                                            .OrderByDescending(e => e.TimeStamp)
                                            .Include(e=>e.Category)
                                            .Select(e=>new TransactionViewModel()
                                            {
                                                TimeStamp = e.TimeStamp,
                                                Amount = e.amount,
                                                Description = e.description,
                                                Id = e.TransactionId,
                                                Type = e.Category.type.ToString()

                                            }).ToList();

                var options = _dbContext.Categories.Select(e => new SelectListItem()
                {
                    Value = e.CategoryId.ToString(),
                    Text = e.Name
                });

                List<SelectListItem> OptionList = options.ToList();

                FinanceTrackerIndexViewModel indexViewModel = new FinanceTrackerIndexViewModel()
                {


                    transactionListItems = transactions,
                    transactionCreateForm = new TransactionCreateFormViewModel()
                    {
                        CategoryId = 10,
                        selectListItems = OptionList
                    }
                    
                   

                   
                };
                
                return View(indexViewModel);

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

        [HttpPost]
        public IActionResult Create([Bind("transactionCreateForm")] FinanceTrackerIndexViewModel indexViewModel)
        {
            if(!ModelState.IsValid)
            {
                // Constructing an object with the error message
                var errorObject = new { error = "Invalid form" };

                // Returning the error object as JSON
                return Json(errorObject);
            }
            else{
                return RedirectToAction("Index");
            }
        }

        
    }
        

        
}
