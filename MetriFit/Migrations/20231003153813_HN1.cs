using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetriFit.Migrations
{
    /// <inheritdoc />
    public partial class HN1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaloriesConsumedPerMeal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    ProtienCalories = table.Column<double>(type: "float", nullable: true),
                    CarbonhydrateCalories = table.Column<double>(type: "float", nullable: true),
                    FatCalories = table.Column<double>(type: "float", nullable: true),
                    SugarCalories = table.Column<double>(type: "float", nullable: true),
                    TotalCaloriesConsumed = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 3, 17, 38, 13, 751, DateTimeKind.Local).AddTicks(5276)),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaloriesConsumedPerMeal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protien = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    Carbonhydrate = table.Column<int>(type: "int", nullable: false),
                    MealPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportAgent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<double>(type: "float", maxLength: 4, nullable: false),
                    Weight = table.Column<double>(type: "float", maxLength: 4, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    WaistCircumference = table.Column<double>(type: "float", nullable: false),
                    NeckCircumference = table.Column<double>(type: "float", nullable: false),
                    HipCircumference = table.Column<double>(type: "float", nullable: true),
                    BodyFat = table.Column<double>(type: "float", nullable: true),
                    LeanerBodyMass = table.Column<double>(type: "float", nullable: true),
                    BasalMetabolicRate = table.Column<double>(type: "float", nullable: true),
                    BmrafterActivityLevel = table.Column<double>(type: "float", nullable: true),
                    LastMeasurmentsEntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValue: "User"),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NutritionInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_NutritionInformation_NutritionInformationId",
                        column: x => x.NutritionInformationId,
                        principalTable: "NutritionInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    CaloriesBurned = table.Column<double>(type: "float", nullable: false),
                    DateCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(5790)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    GoalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaloriesPerDayToBeEaten = table.Column<double>(type: "float", nullable: true),
                    DateStartedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 3, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4700)),
                    DateExAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 17, 15, 38, 13, 752, DateTimeKind.Utc).AddTicks(4893)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    MealLogType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtienConsumed = table.Column<double>(type: "float", nullable: false),
                    CarbonhydrateConsumed = table.Column<double>(type: "float", nullable: false),
                    FatConsumed = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    RepastGrams = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Local)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaloriesConsumedPerMealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealLog_CaloriesConsumedPerMeal_CaloriesConsumedPerMealId",
                        column: x => x.CaloriesConsumedPerMealId,
                        principalTable: "CaloriesConsumedPerMeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    MobilPhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalCaloriesPerDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCalories = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalCaloriesPerDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalCaloriesPerDay_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersNutritions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NutritionInfortmationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersNutritions", x => new { x.UserId, x.NutritionInfortmationId });
                    table.ForeignKey(
                        name: "FK_UsersNutritions_NutritionInformation_NutritionInfortmationId",
                        column: x => x.NutritionInfortmationId,
                        principalTable: "NutritionInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersNutritions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_UserId",
                table: "Exercise",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_UserId",
                table: "Goal",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MealLog_CaloriesConsumedPerMealId",
                table: "MealLog",
                column: "CaloriesConsumedPerMealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealLog_UserId",
                table: "MealLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_UserId",
                table: "PhoneNumber",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TotalCaloriesPerDay_UserId",
                table: "TotalCaloriesPerDay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_NutritionInformationId",
                table: "User",
                column: "NutritionInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersNutritions_NutritionInfortmationId",
                table: "UsersNutritions",
                column: "NutritionInfortmationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "MealLog");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "SupportAgent");

            migrationBuilder.DropTable(
                name: "TotalCaloriesPerDay");

            migrationBuilder.DropTable(
                name: "UsersNutritions");

            migrationBuilder.DropTable(
                name: "CaloriesConsumedPerMeal");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NutritionInformation");
        }
    }
}
