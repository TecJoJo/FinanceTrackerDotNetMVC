using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.ViewModel
{
    public class RegisterViewModel
    {
        
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty ;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmed { get; set; } = string.Empty;
    }
}
