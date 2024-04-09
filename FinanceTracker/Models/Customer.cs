using FinanceTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public string? FirstName {  get; set; }  

        public string? LastName { get; set; }    

        public decimal Balance { get; set; }    

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        

    }
}
