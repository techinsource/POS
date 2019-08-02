using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class POSma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Categorys_Categories_CategoryId",
                table: "Sub_Categorys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Sortorder = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LineItemDefinitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_LineItemDefinitionId",
                table: "Categorys",
                column: "LineItemDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Categorys_Categorys_CategoryId",
                table: "Sub_Categorys",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Categorys_Categorys_CategoryId",
                table: "Sub_Categorys");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LineItemDefinitionId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sortorder = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LineItemDefinitionId",
                table: "Categories",
                column: "LineItemDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Categorys_Categories_CategoryId",
                table: "Sub_Categorys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
