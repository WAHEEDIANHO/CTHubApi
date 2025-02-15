using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class driverqueueadjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                schema: "CThub",
                table: "DriverQueues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                schema: "CThub",
                table: "DriverQueues");
        }
    }
}
