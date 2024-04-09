using FinanceTracker.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal amount { get; set; }

        public string? description { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

    }
}
