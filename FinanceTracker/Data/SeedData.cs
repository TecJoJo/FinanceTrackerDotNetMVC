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
                if (!context.Incomes.Any())
                {
                    context.Incomes.AddRange(

                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 4, 1, 18, 0, 0),

                            amount = 1800,

                            description = "Monthly wage",

                            CustomerId = 1,

                            Category = IncomeCategory.Salary,




                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 1, 10, 0, 0),
                            amount = 1800,
                            description = "Monthly wage",
                            CustomerId = 1,
                            Category = IncomeCategory.Salary,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 5, 14, 0, 0),
                            amount = 2000,
                            description = "Business income",
                            CustomerId = 2,
                            Category = IncomeCategory.BusinessIncome,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 10, 16, 0, 0),
                            amount = 1500,
                            description = "Rental income",
                            CustomerId = 3,
                            Category = IncomeCategory.RentalIncome,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 15, 18, 0, 0),
                            amount = 1200,
                            description = "Royalties",
                            CustomerId = 4,
                            Category = IncomeCategory.Royalties,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 20, 20, 0, 0),
                            amount = 1600,
                            description = "Pension",
                            CustomerId = 1,
                            Category = IncomeCategory.Pension,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 25, 22, 0, 0),
                            amount = 1700,
                            description = "Social Security Benefit",
                            CustomerId = 2,
                            Category = IncomeCategory.SocialSecurityBenefit,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 30, 10, 0, 0),
                            amount = 1900,
                            description = "Gift",
                            CustomerId = 3,
                            Category = IncomeCategory.Gift,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 2, 12, 0, 0),
                            amount = 2100,
                            description = "Inheritance",
                            CustomerId = 4,
                            Category = IncomeCategory.Inheritance,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 7, 14, 0, 0),
                            amount = 2200,
                            description = "Other",
                            CustomerId = 1,
                            Category = IncomeCategory.Other,
                        },
                        new Income()
                        {
                            TimeStamp = new DateTime(2024, 3, 12, 16, 0, 0),
                            amount = 2300,
                            description = "Monthly wage",
                            CustomerId = 2,
                            Category = IncomeCategory.Salary,
                        }

                    );
                    context.SaveChanges();
                }
                if (!context.Expenses.Any())
                {
                    context.Expenses.AddRange(

                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 1, 18, 0, 0),

                        amount = 100,

                        description = "Monthly wage",

                        CustomerId = 1,

                        Category = ExpenseCategory.Transportation




                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 2, 10, 0, 0),
                        amount = 100,
                        description = "Housing expense",
                        CustomerId = 1,
                        Category = ExpenseCategory.Housing,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 6, 14, 0, 0),
                        amount = 150,
                        description = "Transportation expense",
                        CustomerId = 2,
                        Category = ExpenseCategory.Transportation,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 11, 16, 0, 0),
                        amount = 200,
                        description = "Food expense",
                        CustomerId = 3,
                        Category = ExpenseCategory.Food,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 16, 18, 0, 0),
                        amount = 250,
                        description = "Utilities expense",
                        CustomerId = 4,
                        Category = ExpenseCategory.Utilities,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 21, 20, 0, 0),
                        amount = 300,
                        description = "Healthcare expense",
                        CustomerId = 1,
                        Category = ExpenseCategory.Healthcare,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 26, 22, 0, 0),
                        amount = 350,
                        description = "Debt payment",
                        CustomerId = 2,
                        Category = ExpenseCategory.DebtPayment,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 3, 10, 0, 0),
                        amount = 400,
                        description = "Entertainment expense",
                        CustomerId = 3,
                        Category = ExpenseCategory.Entertainment,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 8, 12, 0, 0),
                        amount = 450,
                        description = "Clothing expense",
                        CustomerId = 4,
                        Category = ExpenseCategory.Clothing,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 13, 14, 0, 0),
                        amount = 500,
                        description = "Education expense",
                        CustomerId = 1,
                        Category = ExpenseCategory.Education,
                    },
                    new Expense()
                    {
                        TimeStamp = new DateTime(2024, 4, 18, 16, 0, 0),
                        amount = 550,
                        description = "Savings",
                        CustomerId = 2,
                        Category = ExpenseCategory.Savings,
                    }


                    );
                    context.SaveChanges();
                }
            }



        }
    }
}
