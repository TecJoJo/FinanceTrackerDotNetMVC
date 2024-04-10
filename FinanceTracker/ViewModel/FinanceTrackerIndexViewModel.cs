using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinanceTracker.ViewModel
{
    public class FinanceTrackerIndexViewModel
    {   
      

        public List<SelectListItem> selectListItems { get; set; }

        public List<TransactionViewModel> transactionListItems { get; set; }    

        public TransactionCreateFormViewModel transactionCreateFormViewModel { get; set; } = new TransactionCreateFormViewModel();
    }
}
