﻿using FinanceTracker.Models;
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
    [Authorize(Roles ="admin,user")]
    public class FinanceManagerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserService _userService;
      
        public FinanceManagerController(ApplicationDbContext dbContext, UserService userService)
        {

            _dbContext = dbContext;
            _userService = userService; 
        }
        
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
                                                Type = e.Category.type.ToString(),
                                                Category = e.Category.Name,
                                               

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


            int transactionIdNumber = int.Parse(transactionId);

            var transaction = _dbContext.Transactions.Find(transactionIdNumber);


            TransactionEditFormViewModel editForm = new TransactionEditFormViewModel()
            {
                selectListItems = OptionList,
                TimeStamp = transaction.TimeStamp,
                amount = transaction.amount,
                description = transaction.description,
                CategoryId = transaction.CategoryId,
                TransactionId = transactionIdNumber
                



            };
            return PartialView(editForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransactionEditFormViewModel EditForm)
        {

            if (!ModelState.IsValid)
            {
                var message = "Invalid form, please check the your input";
                if (ModelState.TryGetValue("amount", out var amount) && amount.Errors.Any())
                {
                    message = "The amount and category type are not matching.";
                }
                // Constructing an object with the error message

                var errorObject = new { error = "Invalid form", message = message };

                return Json(errorObject);
            }
            else
            {
                var entityToUpdate = _dbContext.Transactions.Find(EditForm.TransactionId);

                if(entityToUpdate != null)
                {

                entityToUpdate.amount = EditForm.amount;
                entityToUpdate.description = EditForm.description;
                entityToUpdate.CategoryId = EditForm.CategoryId;
                entityToUpdate.TimeStamp = EditForm.TimeStamp;

                    _dbContext.SaveChanges();
                    var successObject = new { success = true };
                    return Json(successObject);
                }
                else
                {
                    // Constructing an object with the error message
                    var errorObject = new { error = "Transaction not found", message = "Transaction is not found" };

                    // Returning the error object as JSON
                    return Json(errorObject);
                }

            
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransactionCreateFormViewModel createForm)
        {
            int? customerId =  _userService.fetchUser();
            if (!ModelState.IsValid)
            {
                var message = "Invalid form, please check the your input";
                if(ModelState.TryGetValue("amount",out var amount) && amount.Errors.Any())
                {
                    message = "The amount and category type are not matching.";
                }
                // Constructing an object with the error message
                
                var errorObject = new { error = "Invalid form",message = message };

                return Json(errorObject);
             



            }
            else
            {
                if (customerId == null)
                {
                    // Constructing an object with the error message
                    var errorObject = new { error = "User not found", message= "CustomerId is missing, make sure you have logged in" };

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
                    var successObject = new {success = true };
                return Json(successObject);
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

        public IActionResult Error(string error)
        {
            ViewData["error"] = error;
            return View();
        }
    }
        

        
}
