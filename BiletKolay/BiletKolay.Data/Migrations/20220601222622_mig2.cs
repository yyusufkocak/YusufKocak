using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletKolay.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Tickets",
                newName: "CustomerNumber");

            migrationBuilder.AddColumn<string>(
                name: "CustomerMail",
                table: "Tickets",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerMail",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                table: "Tickets",
                newName: "PhoneNumber");
        }
    }
}
