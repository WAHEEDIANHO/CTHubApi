using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class scheduler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "CThub",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifieldAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_Path",
                schema: "CThub",
                table: "Schedule",
                column: "Path",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schedule_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                column: "ScheduleId",
                principalSchema: "CThub",
                principalTable: "Schedule",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schedule_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "CThub");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");
        }
    }
}
