using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSManagement.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserssGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Totaluser = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserssGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserssGroupsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Userss_UserssGroup_UserssGroupsId",
                        column: x => x.UserssGroupsId,
                        principalTable: "UserssGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Userss_UserssGroupsId",
                table: "Userss",
                column: "UserssGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userss");

            migrationBuilder.DropTable(
                name: "UserssGroup");
        }
    }
}
