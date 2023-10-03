using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetriFit.Migrations
{
    /// <inheritdoc />
    public partial class HN4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 18, 26, 52, 336, DateTimeKind.Local).AddTicks(6911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 18, 11, 26, 978, DateTimeKind.Local).AddTicks(5354));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(6993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 26, 52, 337, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 18, 11, 26, 978, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 18, 26, 52, 336, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MobilPhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_UserId",
                table: "PhoneNumber",
                column: "UserId");
        }
    }
}
