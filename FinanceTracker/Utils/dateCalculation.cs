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
    }
}
