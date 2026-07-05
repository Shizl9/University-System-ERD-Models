using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_System_ERD___Models.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    instructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    officeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    hireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    academicTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.instructorId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enrollmentYear = table.Column<int>(type: "int", nullable: false),
                    gpa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    building = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    headInstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.departmentId);
                    table.ForeignKey(
                        name: "FK_departments_instructors_headInstructorId",
                        column: x => x.headInstructorId,
                        principalTable: "instructors",
                        principalColumn: "instructorId");
                });

            migrationBuilder.CreateTable(
                name: "cources",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    creditHours = table.Column<int>(type: "int", nullable: false),
                    semesterOffered = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    instructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cources", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_cources_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cources_instructors_instructorId",
                        column: x => x.instructorId,
                        principalTable: "instructors",
                        principalColumn: "instructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    enrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finalGrade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.enrollmentId);
                    table.ForeignKey(
                        name: "FK_enrollments_cources_courseId",
                        column: x => x.courseId,
                        principalTable: "cources",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cources_departmentId",
                table: "cources",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_cources_instructorId",
                table: "cources",
                column: "instructorId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_headInstructorId",
                table: "departments",
                column: "headInstructorId",
                unique: true,
                filter: "[headInstructorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_courseId",
                table: "enrollments",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_studentId",
                table: "enrollments",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "cources");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "instructors");
        }
    }
}
