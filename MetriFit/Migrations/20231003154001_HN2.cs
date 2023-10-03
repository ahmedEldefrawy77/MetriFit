using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetriFit.Migrations
{
    /// <inheritdoc />
    public partial class HN2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(4261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 40, 1, 607, DateTimeKind.Local).AddTicks(1448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 38, 13, 751, DateTimeKind.Local).AddTicks(5276));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(5790),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 38, 13, 751, DateTimeKind.Local).AddTicks(5276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 40, 1, 607, DateTimeKind.Local).AddTicks(1448));
        }
    }
}
