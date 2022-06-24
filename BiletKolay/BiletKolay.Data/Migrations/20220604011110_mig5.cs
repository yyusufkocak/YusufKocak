using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletKolay.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerMail",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerMail",
                table: "Tickets",
                type: "TEXT",
                nullable: true);
        }
    }
}
