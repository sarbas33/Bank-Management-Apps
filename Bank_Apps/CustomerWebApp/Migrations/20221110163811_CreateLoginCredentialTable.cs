using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebApp.Migrations
{
    public partial class CreateLoginCredentialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginCustomer",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    InternetBankingId = table.Column<int>(type: "int", nullable: false),
                    InternetBankingPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCustomer", x => x.SerialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginCustomer");
        }
    }
}
