using FinanceTracker.Models;
using FinanceTracker.Services;
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

        private readonly UserService _userService;
      
        public FinanceManagerController(ApplicationDbContext dbContext, UserService userService)
        {

            _dbContext = dbContext;
            _userService = userService; 
        }
        [Authorize]
        public IActionResult Index()
        {

            int? customerId = _userService.fetchUser();
            if (customerId == null )
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

               

                FinanceTrackerIndexViewModel indexViewModel = new FinanceTrackerIndexViewModel()
                {
                   
                   
                    transactionListItems = transactions


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


        public IActionResult Create() {
            var options = _dbContext.Categories.Select(e => new SelectListItem()
            {
                Value = e.CategoryId.ToString(),
                Text = e.Name
            });

            List<SelectListItem> OptionList = options.ToList();

            var createForm = new TransactionCreateFormViewModel()
            {
                selectListItems = OptionList
            };
            return PartialView(createForm); 
        }

        //[HttpPost]
        //public IActionResult Create(TransactionCreateFormViewModel createForm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Constructing an object with the error message
        //        var errorObject = new { error = "Invalid form" };

        //        // Returning the error object as JSON
        //        return Json(errorObject);

                
        //    }
        //    else
        //    {
                
        //        //add the new entity into the db 
        //        _dbContext.Add(new Transaction()
        //        {
        //            TimeStamp = createForm.TimeStamp,
        //            amount = createForm.amount,
        //            description = createForm.description ?? string.Empty,
        //            CategoryId = createForm.CategoryId,
        //            CustomerId = customerId,
                    
                    
        //        });
        //        _dbContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}

    }
        

        
}
