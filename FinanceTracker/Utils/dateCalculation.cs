namespace FinanceTracker.Utils
{
    public static class dateCalculation
    {
        public static List<DateTime> GetLast30Days()
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 30; i++)
            {
                dates.Add(DateTime.Now.AddDays(-i));
            }
            return dates;
        }

        public static List<DateTime> GetLast12Months()
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 12; i++)
            {
                dates.Add(DateTime.Now.AddMonths(-i));
            }
            return dates;
        }
    }
}
