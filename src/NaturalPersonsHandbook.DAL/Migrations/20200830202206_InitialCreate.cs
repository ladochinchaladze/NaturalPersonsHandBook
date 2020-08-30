using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalPersonsHandbook.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonsRelationships",
                columns: table => new
                {
                    NaturalPersonId = table.Column<int>(type: "int", nullable: false),
                    TargetNaturalPersonId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RelationshipTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonsRelationships", x => new { x.NaturalPersonId, x.TargetNaturalPersonId });
                    table.ForeignKey(
                        name: "FK_NaturalPersonsRelationships_NaturalPersons_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NaturalPersonsRelationships_NaturalPersons_TargetNaturalPersonId",
                        column: x => x.TargetNaturalPersonId,
                        principalTable: "NaturalPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NaturalPersonsRelationships_RelationshipTypes_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalTable: "RelationshipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NaturalPersonId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_NaturalPersons_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 31, 0, 22, 5, 402, DateTimeKind.Local).AddTicks(2502), null, "Tbilisi" },
                    { 2, 2, new DateTime(2020, 8, 31, 0, 22, 5, 404, DateTimeKind.Local).AddTicks(9750), null, "Kutaisi" },
                    { 3, 3, new DateTime(2020, 8, 31, 0, 22, 5, 404, DateTimeKind.Local).AddTicks(9857), null, "Batumi" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 31, 0, 22, 5, 408, DateTimeKind.Local).AddTicks(5946), null, "Male" },
                    { 2, 2, new DateTime(2020, 8, 31, 0, 22, 5, 408, DateTimeKind.Local).AddTicks(6031), null, "Female" }
                });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(1278), null, "Mobile" },
                    { 2, 2, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(1377), null, "Office" },
                    { 3, 3, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(1385), null, "Home" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipTypes",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(6410), null, "Colleague" },
                    { 2, 2, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(6487), null, "Familiar" },
                    { 3, 3, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(6495), null, "Relative" },
                    { 4, 4, new DateTime(2020, 8, 31, 0, 22, 5, 409, DateTimeKind.Local).AddTicks(6499), null, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_CityId",
                table: "NaturalPersons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_GenderId",
                table: "NaturalPersons",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonsRelationships_RelationshipTypeId",
                table: "NaturalPersonsRelationships",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonsRelationships_TargetNaturalPersonId",
                table: "NaturalPersonsRelationships",
                column: "TargetNaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_NaturalPersonId",
                table: "Phones",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeId",
                table: "Phones",
                column: "PhoneTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaturalPersonsRelationships");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RelationshipTypes");

            migrationBuilder.DropTable(
                name: "NaturalPersons");

            migrationBuilder.DropTable(
                name: "PhoneTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
