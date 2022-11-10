using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebApp.Migrations
{
    public partial class InternetBankingLoginCreds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternetBankingLoginCreds",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    InternetBankingId = table.Column<int>(type: "int", nullable: false),
                    InternetBankingPassword = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetBankingLoginCreds", x => x.SerialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternetBankingLoginCreds");
        }
    }
}
