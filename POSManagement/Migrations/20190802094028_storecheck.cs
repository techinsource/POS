using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class storecheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VantRegno",
                table: "Storess",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VantRegno",
                table: "Storess",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
