using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReaderWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderWrappers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagKey = table.Column<string>(nullable: true),
                    ActivationCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivateEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTime = table.Column<DateTime>(nullable: false),
                    TagInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivateEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivateEvents_TagInfos_TagInfoId",
                        column: x => x.TagInfoId,
                        principalTable: "TagInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivateEvents_TagInfoId",
                table: "ActivateEvents",
                column: "TagInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivateEvents");

            migrationBuilder.DropTable(
                name: "ReaderWrappers");

            migrationBuilder.DropTable(
                name: "TagInfos");
        }
    }
}
