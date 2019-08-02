using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class changedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Newprice",
                table: "Itemds",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Newprice",
                table: "Itemds");
        }
    }
}
