using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetriFit.Migrations
{
    /// <inheritdoc />
    public partial class HNv23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(6993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 18, 11, 26, 978, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 40, 1, 607, DateTimeKind.Local).AddTicks(1448));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStartedAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExAt",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 17, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(3642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 17, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedAt",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 15, 40, 1, 608, DateTimeKind.Utc).AddTicks(4261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 16, 11, 26, 979, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CaloriesConsumedPerMeal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 40, 1, 607, DateTimeKind.Local).AddTicks(1448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 18, 11, 26, 978, DateTimeKind.Local).AddTicks(5354));
        }
    }
}
