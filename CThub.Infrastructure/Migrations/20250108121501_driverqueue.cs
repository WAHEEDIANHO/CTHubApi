using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class driverqueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverQueues",
                schema: "CThub",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QueueTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location_Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifieldAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverQueues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverQueues_DriverId",
                schema: "CThub",
                table: "DriverQueues",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverQueues",
                schema: "CThub");
        }
    }
}
