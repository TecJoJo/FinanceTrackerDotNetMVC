using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Income> Incomes { get; set; } 


        
    }
}
