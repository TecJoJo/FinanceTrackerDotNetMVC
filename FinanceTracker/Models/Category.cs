using FinanceTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; } = "other";

        public CategoryType type { get; set; }

        public ICollection<Transaction> transactions { get; set; } = new List<Transaction>();
    }
}
