using FinanceTracker.Models.Enums;

namespace FinanceTracker.ViewModel
{
    public class TransactionEditFormView
    {
        public decimal Amount { get; set; } 
        public DateTime TimeStemp {  get; set; }    
        
        public string Description {  get; set; }    
        
        public ExpenseCategory ExpenseCategory { get; set; }

        public IncomeCategory IncomeCategory { get; set; }  

    }
}
