namespace FinanceTracker.ViewModel
{
    public class HomeIndexViewModel
    {
        public List<TransactionViewModel> Transactions = new List<TransactionViewModel>();

        public ChartDataViewModel ChartsData = new ChartDataViewModel();

        public decimal Last30DaysSavings { get; set; }

        public string UserName { get; set; } = "Anonymous User";

        public int CustomerId { get; set; } 

        public int maxDailyExpense { get; set; }    

        public decimal? SavingGoal { get; set; }


    }
}
