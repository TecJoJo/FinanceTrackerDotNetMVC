namespace FinanceTracker.ViewModel
{
    public class TransactionViewModel
    {
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }    
        public string? Description { get; set; }
        public string Category { get; set; }   
        public int Id { get; set; }
        public string Type { get; set; }   
    }
}
