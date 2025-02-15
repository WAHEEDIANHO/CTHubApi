using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class driverqueuevehinclerel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_DriverQueues_Drivers_DriverId",
                schema: "CThub",
                table: "DriverQueues",
                column: "DriverId",
                principalSchema: "CThub",
                principalTable: "Drivers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverQueues_Drivers_DriverId",
                schema: "CThub",
                table: "DriverQueues");
        }
    }
}
