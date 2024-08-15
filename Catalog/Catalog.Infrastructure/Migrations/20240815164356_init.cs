using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    RepetitionRule = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsObsolete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsObsolete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Homework",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsObsolete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homework", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homework_Sessions_Id",
                        column: x => x.Id,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsObsolete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Sessions_Id",
                        column: x => x.Id,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionReferences_Sessions_Id",
                        column: x => x.Id,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Duration", "IsObsolete", "ModifiedBy", "ModifiedDate", "Name", "RepetitionRule", "StartDate" },
                values: new object[,]
                {
                    { new Guid("223030a6-c3fe-4802-80c7-d22cdb02d569"), "CS301", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0), false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pragmatic Programmer", 31, new DateTime(2024, 2, 20, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"), "CS101", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 30, 0, 0), false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intro to CS", 31, new DateTime(2024, 2, 12, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"), "CS201", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Details", 96, new DateTime(2024, 8, 20, 12, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Homework",
                columns: new[] { "Id", "AcceptanceCriteria", "CreatedBy", "CreatedDate", "Description", "IsObsolete", "ModifiedBy", "ModifiedDate", "SessionId", "Title" },
                values: new object[,]
                {
                    { new Guid("0774b0b6-6dac-4bf4-b4ce-023491f81a71"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 2", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"), "Homework 2" },
                    { new Guid("17aef592-7b32-4330-b21d-31f53a530c7b"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 3", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"), "Homework 3" },
                    { new Guid("57b2c785-55f5-4b08-b2c0-6e6b71724000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 2", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"), "Homework 2" },
                    { new Guid("98030dcf-df14-4cf3-a0c4-47062adce75a"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 1", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"), "Homework 1" },
                    { new Guid("e84fd466-c932-486f-a482-b0d6c2885dab"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 3", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"), "Homework 3" },
                    { new Guid("f07004aa-4feb-48a4-ada5-2c49bc37d5e0"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 1", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"), "Homework 1" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsObsolete", "ModifiedBy", "ModifiedDate", "SessionId" },
                values: new object[,]
                {
                    { new Guid("1cedccea-a904-4284-b719-c4891a6e153b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 2", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") },
                    { new Guid("2f4cad70-b562-4377-a18d-7b7c705c2e3c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 1", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") },
                    { new Guid("f30e1f87-a9b7-47a7-89dc-aa599574ef4e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Note 3", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") }
                });

            migrationBuilder.InsertData(
                table: "SessionReferences",
                columns: new[] { "Id", "Reference", "SessionId" },
                values: new object[,]
                {
                    { new Guid("86f842dc-27a9-4327-b91b-87ec7537b212"), "Sample reference 2", new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") },
                    { new Guid("8ac5adf8-c074-4818-8664-7e8367cbf552"), "Sample reference 3", new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") },
                    { new Guid("d1ef9757-b333-402a-8d3c-98d8b878ba30"), "Sample reference 1", new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a") },
                    { new Guid("fbc3a10f-578a-4f3d-975b-b9c9410a7aaa"), "Sample reference 1", new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e") }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CourseId", "CreatedBy", "CreatedDate", "Description", "IsObsolete", "ModifiedBy", "ModifiedDate", "StartDate", "Topic" },
                values: new object[,]
                {
                    { new Guid("2bd3e9ac-32bb-44cb-a427-5a1cab82d0e7"), new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Course, will learn a lot of things Part 3", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), "Introduction to Course CS101" },
                    { new Guid("9437caa9-9814-49d1-a031-9d77d6bf9005"), new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201, will learn a lot of things", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201" },
                    { new Guid("9913114a-cb5e-4d00-bf63-ad054a179099"), new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201, will learn a lot of things", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201" },
                    { new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"), new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Course, will learn a lot of things Part 2", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 20, 19, 30, 0, 0, DateTimeKind.Unspecified), "Introduction to Course CS101" },
                    { new Guid("bdd42fa0-197d-4c8b-b02f-492a866ae115"), new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201, will learn a lot of things", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201" },
                    { new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"), new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Course, will learn a lot of things", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 19, 18, 30, 0, 0, DateTimeKind.Unspecified), "Introduction to Course CS101" },
                    { new Guid("fce3bf3f-bdaf-4672-b878-ea05f7e33319"), new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201, will learn a lot of things", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), "Programming Details CS201" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Code",
                table: "Courses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CourseId",
                table: "Sessions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Topic",
                table: "Sessions",
                column: "Topic",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homework");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "SessionReferences");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
