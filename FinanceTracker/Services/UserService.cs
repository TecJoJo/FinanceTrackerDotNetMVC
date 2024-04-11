using System.Security.Claims;

namespace FinanceTracker.Services
{
    public class UserService
    {
        private string customerIdString= string.Empty;  

        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }
        public int? fetchUser()
        {
            if(this.customerIdString == string.Empty)
            {

            customerIdString = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            if(int.TryParse(customerIdString, out int customerId))
            {
                return customerId;
            }

            return null;
        }
    }
}
