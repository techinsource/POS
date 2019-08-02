using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class Storess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Mobile = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    VantRegno = table.Column<int>(nullable: false),
                    Timezo = table.Column<TimeSpan>(nullable: false),
                    Aftersellp = table.Column<string>(nullable: true),
                    Text = table.Column<int>(nullable: false),
                    Stockalertq = table.Column<int>(nullable: false),
                    Itemlimit = table.Column<int>(nullable: false),
                    Soundeffect = table.Column<string>(nullable: true),
                    UserssId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storess_Userss_UserssId",
                        column: x => x.UserssId,
                        principalTable: "Userss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storess_UserssId",
                table: "Storess",
                column: "UserssId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storess");
        }
    }
}
