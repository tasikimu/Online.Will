using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online.Will.API.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deductions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marriage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfMarriage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BanksID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estates_Bank_BanksID",
                        column: x => x.BanksID,
                        principalTable: "Bank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstateValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarriagesID = table.Column<int>(type: "int", nullable: false),
                    BurialPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastWishes = table.Column<string>(type: "nvarchar(max)", maxLength: 20000, nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_Marriage_MarriagesID",
                        column: x => x.MarriagesID,
                        principalTable: "Marriage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Charity_PersonalDetails_PersonalDetailsID",
                        column: x => x.PersonalDetailsID,
                        principalTable: "PersonalDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Children_PersonalDetails_PersonalDetailsID",
                        column: x => x.PersonalDetailsID,
                        principalTable: "PersonalDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cohabit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohabit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cohabit_PersonalDetails_PersonalDetailsID",
                        column: x => x.PersonalDetailsID,
                        principalTable: "PersonalDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PrefferedHeir",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefferedHeir", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrefferedHeir_PersonalDetails_PersonalDetailsID",
                        column: x => x.PersonalDetailsID,
                        principalTable: "PersonalDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charity_PersonalDetailsID",
                table: "Charity",
                column: "PersonalDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Children_PersonalDetailsID",
                table: "Children",
                column: "PersonalDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Cohabit_PersonalDetailsID",
                table: "Cohabit",
                column: "PersonalDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_BanksID",
                table: "Estates",
                column: "BanksID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_MarriagesID",
                table: "PersonalDetails",
                column: "MarriagesID");

            migrationBuilder.CreateIndex(
                name: "IX_PrefferedHeir_PersonalDetailsID",
                table: "PrefferedHeir",
                column: "PersonalDetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charity");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Cohabit");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "PrefferedHeir");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "Marriage");
        }
    }
}
