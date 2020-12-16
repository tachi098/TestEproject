using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProject.Migrations
{
    public partial class ApplicationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    avatar = table.Column<string>(nullable: true),
                    level = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    update_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "avatar", "create_at", "email", "level", "name", "password", "phone", "status", "update_at" },
                values: new object[] { 1, "binh thanh", "image/p1.png", new DateTime(2020, 12, 15, 10, 55, 6, 784, DateTimeKind.Local).AddTicks(8878), "toilahuy098@gmail.com", true, "huy", "123456", "0933691822", true, new DateTime(2020, 12, 15, 10, 55, 6, 785, DateTimeKind.Local).AddTicks(6640) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "avatar", "create_at", "email", "level", "name", "password", "phone", "status", "update_at" },
                values: new object[] { 2, "quan 3", "image/p2.png", new DateTime(2020, 12, 15, 10, 55, 6, 785, DateTimeKind.Local).AddTicks(7780), "thaochi098@gmail.com", false, "chi", "123456", "0933691822", true, new DateTime(2020, 12, 15, 10, 55, 6, 785, DateTimeKind.Local).AddTicks(7797) });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "address", "email", "name", "phone", "status", "userid" },
                values: new object[] { 1, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "address", "email", "name", "phone", "status", "userid" },
                values: new object[] { 2, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_userid",
                table: "Order",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
