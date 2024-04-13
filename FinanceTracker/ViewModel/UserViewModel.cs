using FinanceTracker.Models.Enums;

namespace FinanceTracker.ViewModel
{
    public class UserViewModel
    {
        
        public int CustomerId { get; set; } 
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        
    }
}
