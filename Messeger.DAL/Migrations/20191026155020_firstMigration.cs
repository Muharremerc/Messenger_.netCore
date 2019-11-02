using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Messeger.DAL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Header = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MessageDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: false),
                    MessageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageDetails_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MessageDetails_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MessageMembers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    MessageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageMembers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageMembers_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MessageMembers_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageDetails_MemberID",
                table: "MessageDetails",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDetails_MessageID",
                table: "MessageDetails",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMembers_MemberID",
                table: "MessageMembers",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMembers_MessageID",
                table: "MessageMembers",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MemberID",
                table: "Messages",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageDetails");

            migrationBuilder.DropTable(
                name: "MessageMembers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
