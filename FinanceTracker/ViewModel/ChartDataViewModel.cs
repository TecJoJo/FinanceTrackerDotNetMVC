namespace FinanceTracker.ViewModel
{
    public class ChartDataViewModel
    {


        //properties for last 30 days chart
        public List<string> DateLabels { get; set; } = new List<string>();
        public List<decimal> DailyIncomes { get; set; } = new List<decimal>();
        public List<decimal> DailyExpenses { get; set; } = new List<decimal>();

        //properties for last 12 moths chart

        public List<string> MonthLabels { get; set; } = new List<string>();
        public List<decimal> MonthSavings { get; set; } = new List<decimal>();
        public List<decimal> MonthExpenses { get; set; } = new List<decimal>();

        public List<decimal> MonthIncomes { get; set; } = new List<decimal>();
    }
}
