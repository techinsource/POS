using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class categoryp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpanseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Order = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ParentCategorysId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpanseCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpanseCategory_ParentCategorys_ParentCategorysId",
                        column: x => x.ParentCategorysId,
                        principalTable: "ParentCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpanseCategory_ParentCategorysId",
                table: "ExpanseCategory",
                column: "ParentCategorysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpanseCategory");

            migrationBuilder.DropTable(
                name: "ParentCategorys");
        }
    }
}
