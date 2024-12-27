using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCLI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.EnsureSchema(
                name: "SystemCode");

            migrationBuilder.CreateTable(
                name: "Lk_Department",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemCodeType",
                schema: "SystemCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCodeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lk_JobTitle",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk_JobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lk_JobTitle_Lk_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Lookup",
                        principalTable: "Lk_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemCode",
                schema: "SystemCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaticValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemCodeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemCode_SystemCodeType_SystemCodeTypeId",
                        column: x => x.SystemCodeTypeId,
                        principalSchema: "SystemCode",
                        principalTable: "SystemCodeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Op_Employee",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrithDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    RelegionId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    DepatmentId = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Op_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Op_Employee_Lk_Department_DepatmentId",
                        column: x => x.DepatmentId,
                        principalSchema: "Lookup",
                        principalTable: "Lk_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Op_Employee_Lk_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "Lookup",
                        principalTable: "Lk_JobTitle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Op_Employee_SystemCode_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "SystemCode",
                        principalTable: "SystemCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Op_Employee_SystemCode_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "SystemCode",
                        principalTable: "SystemCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Op_Employee_SystemCode_RelegionId",
                        column: x => x.RelegionId,
                        principalSchema: "SystemCode",
                        principalTable: "SystemCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "SystemCode",
                table: "SystemCodeType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Gender" },
                    { 2, "MaritalStatus" },
                    { 3, "Relegion" }
                });

            migrationBuilder.InsertData(
                schema: "SystemCode",
                table: "SystemCode",
                columns: new[] { "Id", "StaticValue", "SystemCodeTypeId" },
                values: new object[,]
                {
                    { 1, "Male", 1 },
                    { 2, "Female", 1 },
                    { 3, "Single", 2 },
                    { 4, "Married", 2 },
                    { 5, "Muslim", 3 },
                    { 6, "Christian", 3 },
                    { 7, "Other", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lk_JobTitle_DepartmentId",
                schema: "Lookup",
                table: "Lk_JobTitle",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Op_Employee_DepatmentId",
                schema: "Operation",
                table: "Op_Employee",
                column: "DepatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Op_Employee_GenderId",
                schema: "Operation",
                table: "Op_Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Op_Employee_JobTitleId",
                schema: "Operation",
                table: "Op_Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Op_Employee_MaritalStatusId",
                schema: "Operation",
                table: "Op_Employee",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Op_Employee_RelegionId",
                schema: "Operation",
                table: "Op_Employee",
                column: "RelegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemCode_SystemCodeTypeId",
                schema: "SystemCode",
                table: "SystemCode",
                column: "SystemCodeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Op_Employee",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Lk_JobTitle",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SystemCode",
                schema: "SystemCode");

            migrationBuilder.DropTable(
                name: "Lk_Department",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SystemCodeType",
                schema: "SystemCode");
        }
    }
}
