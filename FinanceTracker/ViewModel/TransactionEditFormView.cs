using FinanceTracker.Models.Enums;

namespace FinanceTracker.ViewModel
{
    public class TransactionEditFormView
    {
        public int TransactionId {get; set; }
        public decimal Amount { get; set; } 
        public DateTime TimeStemp {  get; set; }    
        
        public string Description {  get; set; }    
        
        public int CategoryId {  get; set; }            
        

    }
}
