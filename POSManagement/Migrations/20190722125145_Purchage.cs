using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class Purchage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.CreateTable(
                name: "Supplierss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplierss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchasess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Referenceno = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Totalamount = table.Column<double>(nullable: false),
                    SuppliersId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchasess_Itemds_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itemds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchasess_Supplierss_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Supplierss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasess_ItemId",
                table: "Purchasess",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasess_SuppliersId",
                table: "Purchasess",
                column: "SuppliersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchasess");

            migrationBuilder.DropTable(
                name: "Supplierss");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });
        }
    }
}
