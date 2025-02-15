using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ridermanyride : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RiderId",
                schema: "CThub",
                table: "Ride",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_RiderId",
                schema: "CThub",
                table: "Ride",
                column: "RiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Riders_RiderId",
                schema: "CThub",
                table: "Ride",
                column: "RiderId",
                principalSchema: "CThub",
                principalTable: "Riders",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Riders_RiderId",
                schema: "CThub",
                table: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Ride_RiderId",
                schema: "CThub",
                table: "Ride");

            migrationBuilder.AlterColumn<Guid>(
                name: "RiderId",
                schema: "CThub",
                table: "Ride",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
