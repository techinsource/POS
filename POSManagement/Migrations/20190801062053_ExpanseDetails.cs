using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class ExpanseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpanseCategory_ParentCategorys_ParentCategorysId",
                table: "ExpanseCategory");

            migrationBuilder.DropIndex(
                name: "IX_ExpanseCategory_ParentCategorysId",
                table: "ExpanseCategory");

            migrationBuilder.DropColumn(
                name: "ParentCategorysId",
                table: "ExpanseCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCategorysId",
                table: "ExpanseCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpanseCategory_ParentCategorysId",
                table: "ExpanseCategory",
                column: "ParentCategorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpanseCategory_ParentCategorys_ParentCategorysId",
                table: "ExpanseCategory",
                column: "ParentCategorysId",
                principalTable: "ParentCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
