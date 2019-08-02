using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customerss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Creditbalance = table.Column<double>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Age = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customerss", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customerss");
        }
    }
}
