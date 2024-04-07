﻿using FinanceTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        
        public DateTime TimeStamp { get; set; }

        public decimal amount { get; set; }

        public string? description { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public ExpenseCategory Category { get; set; }

        public Customer Customer { get; set; } = null!;

    }
}