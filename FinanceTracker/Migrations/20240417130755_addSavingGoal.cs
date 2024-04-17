using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Migrations
{
    /// <inheritdoc />
    public partial class addSavingGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");

            migrationBuilder.AddColumn<decimal>(
                name: "SavingGoal",
                table: "Customers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavingGoal",
                table: "Customers");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
