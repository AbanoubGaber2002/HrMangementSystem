﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    JobApplicationApplicationID = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Documents_JobApplications_JobApplicationApplicationID",
                        column: x => x.JobApplicationApplicationID,
                        principalTable: "JobApplications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewsScheduling",
                columns: table => new
                {
                    InterviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    JobApplicationApplicationID = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewsScheduling", x => x.InterviewID);
                    table.ForeignKey(
                        name: "FK_InterviewsScheduling_JobApplications_JobApplicationApplicationID",
                        column: x => x.JobApplicationApplicationID,
                        principalTable: "JobApplications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    JobOfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.JobOfferID);
                    table.ForeignKey(
                        name: "FK_JobOffers_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceID);
                    table.ForeignKey(
                        name: "FK_Absences_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leaves",
                columns: table => new
                {
                    LeaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaves", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_leaves_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    ObjectiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.ObjectiveID);
                    table.ForeignKey(
                        name: "FK_Objectives_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "performanceReviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_performanceReviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_performanceReviews_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_performanceReviews_Managers_ReviewerID",
                        column: x => x.ReviewerID,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyResult",
                columns: table => new
                {
                    KeyResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveID = table.Column<int>(type: "int", nullable: false),
                    KeyResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AchievedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyResult", x => x.KeyResultID);
                    table.ForeignKey(
                        name: "FK_KeyResult_Objectives_ObjectiveID",
                        column: x => x.ObjectiveID,
                        principalTable: "Objectives",
                        principalColumn: "ObjectiveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceProgresses",
                columns: table => new
                {
                    ProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ObjectiveID = table.Column<int>(type: "int", nullable: false),
                    ProgressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceProgresses", x => x.ProgressID);
                    table.ForeignKey(
                        name: "FK_PerformanceProgresses_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformanceProgresses_Objectives_ObjectiveID",
                        column: x => x.ObjectiveID,
                        principalTable: "Objectives",
                        principalColumn: "ObjectiveID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "DepartmentID", "Email", "FirstName", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, 0, "john.doe@example.com", "John", "Doe", "123-456-7890", "HR Manager" },
                    { 2, 0, "jane.smith@example.com", "Jane", "Smith", "987-654-3210", "IT Manager" },
                    { 3, 0, "bob.brown@example.com", "Bob", "Brown", "555-555-5555", "Marketing Manager" },
                    { 4, 0, "alice.white@example.com", "Alice", "White", "444-444-4444", "Sales Manager" },
                    { 5, 0, "tom.green@example.com", "Tom", "Green", "333-333-3333", "Finance Manager" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Email", "FirstName", "Image", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "alice.johnson@example.com", "Alice", "user-1.jpg", "Johnson", "hashed_password1", "HR" },
                    { 2, "bob.smith@example.com", "Bob", "user-1.jpg", "Smith", "hashed_password2", "Manager" },
                    { 3, "charlie.brown@example.com", "Charlie", "user-1.jpg", "Brown", "hashed_password3", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "Location", "ManagerId" },
                values: new object[,]
                {
                    { 1, "Human Resources", "Building A", 1 },
                    { 2, "IT", "Building B", 2 },
                    { 3, "Marketing", "Building C", 3 },
                    { 4, "Sales", "Building D", 4 },
                    { 5, "Finance", "Building E", 5 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Certificate", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "HireDate", "Image", "LastName", "Phone", "Position", "Resume", "Salary" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "michael.jordan@example.com", "Michael", "Male", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael_jordan.jpg", "Jordan", "111-111-1111", "HR Specialist", null, 50000m },
                    { 2, null, new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "serena.williams@example.com", "Serena", "Female", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "serena_williams.jpg", "Williams", "222-222-2222", "IT Specialist", null, 60000m },
                    { 3, null, new DateTime(1988, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "lebron.james@example.com", "LeBron", "Male", new DateTime(2019, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "lebron_james.jpg", "James", "333-333-3333", "Marketing Analyst", null, 55000m },
                    { 4, null, new DateTime(1996, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "simone.biles@example.com", "Simone", "Female", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "simone_biles.jpg", "Biles", "444-444-4444", "Sales Representative", null, 48000m },
                    { 5, null, new DateTime(1987, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "lionel.messi@example.com", "Lionel", "Male", new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "lionel_messi.jpg", "Messi", "555-555-5555", "Finance Analyst", null, 70000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EmployeeID",
                table: "Absences",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_JobApplicationApplicationID",
                table: "Documents",
                column: "JobApplicationApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsScheduling_JobApplicationApplicationID",
                table: "InterviewsScheduling",
                column: "JobApplicationApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ManagerID",
                table: "JobOffers",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResult_ObjectiveID",
                table: "KeyResult",
                column: "ObjectiveID");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_EmployeeID",
                table: "leaves",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_DepartmentID",
                table: "Objectives",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_EmployeeID",
                table: "Objectives",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceProgresses_EmployeeID",
                table: "PerformanceProgresses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceProgresses_ObjectiveID",
                table: "PerformanceProgresses",
                column: "ObjectiveID");

            migrationBuilder.CreateIndex(
                name: "IX_performanceReviews_EmployeeID",
                table: "performanceReviews",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_performanceReviews_ReviewerID",
                table: "performanceReviews",
                column: "ReviewerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "InterviewsScheduling");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "KeyResult");

            migrationBuilder.DropTable(
                name: "leaves");

            migrationBuilder.DropTable(
                name: "PerformanceProgresses");

            migrationBuilder.DropTable(
                name: "performanceReviews");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
