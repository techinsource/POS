using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class POSM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineItemDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Barcode = table.Column<int>(nullable: false),
                    Sortorder = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItemDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item_Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Sortorder = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LineItemDefinitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Templates_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itemds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost_Price = table.Column<double>(nullable: false),
                    Retail_Price = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LineItemDefinitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itemds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itemds_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    SortItem = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemGroups_LineItemDefinitions_LineItemDefinitionId",
                        column: x => x.LineItemDefinitionId,
                        principalTable: "LineItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categorys",
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
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_Categorys_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LineItemDefinitionId",
                table: "Categories",
                column: "LineItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Templates_LineItemDefinitionId",
                table: "Item_Templates",
                column: "LineItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Itemds_LineItemDefinitionId",
                table: "Itemds",
                column: "LineItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_LineItemDefinitionId",
                table: "ItemGroups",
                column: "LineItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categorys_CategoryId",
                table: "Sub_Categorys",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item_Templates");

            migrationBuilder.DropTable(
                name: "Itemds");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Sub_Categorys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "LineItemDefinitions");
        }
    }
}
