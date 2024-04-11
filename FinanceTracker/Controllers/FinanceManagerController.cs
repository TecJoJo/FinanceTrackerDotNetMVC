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
        [HttpPost]
        public IActionResult FetchEditForm([FromBody] string transactionId)
        {
            
            var options = _dbContext.Categories.Select(e => new SelectListItem()
            {
                Value = e.CategoryId.ToString(),
                Text = e.Name
            });

            List<SelectListItem> OptionList = options.ToList();

            TransactionEditFormViewModel editForm = new TransactionEditFormViewModel()
            {
                TransactionId = int.Parse(transactionId),
                selectListItems = OptionList,


            };
            return PartialView(editForm);
        }

        [HttpPost]
        public IActionResult Edit(TransactionEditFormView EditForm)
        {

            if (!ModelState.IsValid)
            {
                // Constructing an object with the error message
                var errorObject = new { error = "Invalid form" };

                // Returning the error object as JSON
                return Json(errorObject);
            }
            else
            {
                var entityToUpdate = _dbContext.Transactions.Find(EditForm.TransactionId);

                if(entityToUpdate != null)
                {

                entityToUpdate.amount = EditForm.Amount;
                entityToUpdate.description = EditForm.Description;
                entityToUpdate.CategoryId = EditForm.CategoryId;
                entityToUpdate.TimeStamp = EditForm.TimeStemp;

                    _dbContext.SaveChanges();
                }
                else
                {
                    // Constructing an object with the error message
                    var errorObject = new { error = "transaction is not found" };

                    // Returning the error object as JSON
                    return Json(errorObject);
                }

            return RedirectToAction("Index");
            }

            
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

        [HttpPost]
        public IActionResult Create(TransactionCreateFormViewModel createForm)
        {
            int? customerId =  _userService.fetchUser();
            if (!ModelState.IsValid)
            {
                // Constructing an object with the error message
                var errorObject = new { error = "Invalid form" };

                // Returning the error object as JSON
                return Json(errorObject);


            }
            else
            {
                if (customerId == null)
                {
                    // Constructing an object with the error message
                    var errorObject = new { error = "CustomerId is missing, make sure you have logged in" };

                    // Returning the error object as JSON
                    return Json(errorObject);
                }
                //add the new entity into the db 
                else
                {

                _dbContext.Add(new Transaction()
                {
                    TimeStamp = createForm.TimeStamp,
                    amount = createForm.amount,
                    description = createForm.description ?? string.Empty,
                    CategoryId = createForm.CategoryId,
                    CustomerId = (int)customerId,


                });
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] string transactionId)
        {
            var id = int.Parse(transactionId);
            var transactionToDelete = _dbContext.Transactions.Find(id);
            if (transactionToDelete != null)
            {
                _dbContext.Transactions.Remove(transactionToDelete);
                _dbContext.SaveChanges();
                return Ok(new { status = 200, message = "Transaction deleted successfully", success = true });
            }
            else
            {
                // Constructing an object with the error message
                var errorObject = new { status = 404, message = "Transaction not found", error = true };

                // Returning the error object as JSON
                return NotFound(errorObject);
            }
        }
    }
        

        
}
