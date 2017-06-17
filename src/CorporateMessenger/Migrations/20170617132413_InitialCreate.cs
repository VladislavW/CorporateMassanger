using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CorporateMessenger.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupsMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MassageMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextMassage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassageMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    GroupsId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMap_GroupsMap_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "GroupsMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMassageMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MassageId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMassageMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMassageMap_MassageMap_MassageId",
                        column: x => x.MassageId,
                        principalTable: "MassageMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMassageMap_UserMap_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMap_GroupsId",
                table: "UserMap",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMassageMap_MassageId",
                table: "UserMassageMap",
                column: "MassageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMassageMap_UserId",
                table: "UserMassageMap",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMassageMap");

            migrationBuilder.DropTable(
                name: "MassageMap");

            migrationBuilder.DropTable(
                name: "UserMap");

            migrationBuilder.DropTable(
                name: "GroupsMap");
        }
    }
}
