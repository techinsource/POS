using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class quotationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotationss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Refeno = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Biller = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    SuppllierssId = table.Column<int>(nullable: true),
                    CustomerssId = table.Column<int>(nullable: true),
                    ItemdId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotationss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotationss_Customerss_CustomerssId",
                        column: x => x.CustomerssId,
                        principalTable: "Customerss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotationss_Itemds_ItemdId",
                        column: x => x.ItemdId,
                        principalTable: "Itemds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotationss_Supplierss_SuppllierssId",
                        column: x => x.SuppllierssId,
                        principalTable: "Supplierss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotationss_CustomerssId",
                table: "Quotationss",
                column: "CustomerssId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotationss_ItemdId",
                table: "Quotationss",
                column: "ItemdId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotationss_SuppllierssId",
                table: "Quotationss",
                column: "SuppllierssId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotationss");
        }
    }
}
