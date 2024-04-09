using FinanceTracker.Models;
using FinanceTracker.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer()
                        {
                            UserName = "admin",
                            Email = "admin@hamk.com",
                            Password = "password",
                            Role = Role.admin,
                            Balance = 1000


                        },
                        new Customer()
                        {
                            UserName = "luyao",
                            Email = "luyao@hamk.com",
                            Password = "password",
                            Role = Role.admin,
                            Balance = 5000


                        },
                        new Customer()
                        {
                            UserName = "user",
                            Email = "user@hamk.com",
                            Password = "password",
                            Role = Role.user,
                            Balance = 100


                        },
                        new Customer()
                        {
                            UserName = "visitor",
                            Email = "visitor@hamk.com",
                            Password = "password",
                            Role = Role.vistor,
                            Balance = 0


                        }

                    );
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category()
                        {
                            Name = "Housing",
                            type = CategoryType.Expense

                        },
                        new Category()
                        {
                            Name = "Salary",
                            type = CategoryType.Income

                        },
                        new Category()
                        {
                            Name = "BusinessIncome",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "RentalIncome",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Royalties",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Pension",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "SocialSecurityBenefit",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Gift",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Inheritance",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Other",
                            type = CategoryType.Income
                        },
                        new Category()
                        {
                            Name = "Transportation",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Food",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Utilities",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Healthcare",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "DebtPayment",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Entertainment",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Clothing",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Education",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Savings",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Investment",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "PersonalCare",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "CharitableGiving",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Insurance",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Tax",
                            type = CategoryType.Expense
                        },
                        new Category()
                        {
                            Name = "Other",
                            type = CategoryType.Expense
                        }

                    );

                    context.SaveChanges();
                }
                if (!context.Transactions.Any())
                {
                    context.Transactions.AddRange(

                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 5, 18, 0, 0),
                            amount = 2000,
                            description = "Monthly wage",
                            CustomerId = 1,
                            CategoryId = 2, // "Salary"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 1, 18, 0, 0),
                            amount = -800,
                            description = "Rent payment",
                            CustomerId = 1,
                            CategoryId = 1, // "Housing"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 15, 18, 0, 0),
                            amount = -500,
                            description = "Food expense",
                            CustomerId = 1,
                            CategoryId = 12, // "Food"
                        },

                        // Transactions for CustomerId = 2
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 7, 18, 0, 0),
                            amount = 1800,
                            description = "Business income",
                            CustomerId = 2,
                            CategoryId = 3, // "BusinessIncome"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 12, 18, 0, 0),
                            amount = -1300,
                            description = "Rent payment",
                            CustomerId = 2,
                            CategoryId = 1, // "Housing"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 17, 18, 0, 0),
                            amount = -600,
                            description = "Utilities expense",
                            CustomerId = 2,
                            CategoryId = 13, // "Utilities"
                        },

                        // Transactions for CustomerId = 3
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 9, 18, 0, 0),
                            amount = 1700,
                            description = "Pension income",
                            CustomerId = 3,
                            CategoryId = 6, // "Pension"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 14, 18, 0, 0),
                            amount = -1400,
                            description = "Rent payment",
                            CustomerId = 3,
                            CategoryId = 1, // "Housing"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 19, 18, 0, 0),
                            amount = -700,
                            description = "Healthcare expense",
                            CustomerId = 3,
                            CategoryId = 14, // "Healthcare"
                        },

                        // Transactions for CustomerId = 4
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 11, 18, 0, 0),
                            amount = 1900,
                            description = "Inheritance income",
                            CustomerId = 4,
                            CategoryId = 9, // "Inheritance"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 16, 18, 0, 0),
                            amount = -1600,
                            description = "Rent payment",
                            CustomerId = 4,
                            CategoryId = 1, // "Housing"
                        },
                        new Transaction()
                        {
                            TimeStamp = new DateTime(2024, 3, 21, 18, 0, 0),
                            amount = -800,
                            description = "Transportation expense",
                            CustomerId = 4,
                            CategoryId = 11, // "Transportation"
                        }


                    );
                    context.SaveChanges();
                }
            }



        }
    }
}
