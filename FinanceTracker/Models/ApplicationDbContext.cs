using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; } 


        
    }
}
