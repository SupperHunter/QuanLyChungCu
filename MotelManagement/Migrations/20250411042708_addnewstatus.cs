using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelManagement.Migrations
{
    public partial class addnewstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Room");
        }
    }
}
