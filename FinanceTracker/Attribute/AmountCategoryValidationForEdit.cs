﻿using FinanceTracker.Models.Enums;
using FinanceTracker.Models;
using FinanceTracker.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Attribute
{
    public class AmountCategoryValidationForEdit : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var transaction = (TransactionEditFormViewModel)validationContext.ObjectInstance;

            // Get the category from the database
            var category = dbContext.Categories.Find(transaction.CategoryId);

            if (transaction.amount < 0 && category.type != CategoryType.Expense)
            {
                return new ValidationResult("Negative amounts must have an Expense category.");
            }
            else if (transaction.amount > 0 && category.type != CategoryType.Income)
            {
                return new ValidationResult("Positive amounts must have an Income category.");
            }

            return ValidationResult.Success;
        }
    }
}
