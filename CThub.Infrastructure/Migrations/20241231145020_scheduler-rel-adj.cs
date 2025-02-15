using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CThub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schedulerreladj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schedule_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "CThub",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ScheduleUser",
                schema: "CThub",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleUser", x => new { x.ScheduleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ScheduleUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "CThub",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleUser_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "CThub",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleUser_UserId",
                schema: "CThub",
                table: "ScheduleUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleUser",
                schema: "CThub");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schedule_ScheduleId",
                schema: "CThub",
                table: "AspNetUsers",
                column: "ScheduleId",
                principalSchema: "CThub",
                principalTable: "Schedule",
                principalColumn: "Id");
        }
    }
}
