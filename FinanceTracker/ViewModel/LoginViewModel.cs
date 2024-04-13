using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]   

        public string password { get; set; }        

    }
}
