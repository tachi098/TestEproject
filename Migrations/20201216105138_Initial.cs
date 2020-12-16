using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orderdetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

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
                table: "Orderdetail",
                columns: new[] { "id", "detail" },
                values: new object[] { 1, "Nokia" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "avatar", "create_at", "email", "level", "name", "password", "phone", "status", "update_at" },
                values: new object[,]
                {
                    { 1, "binh thanh", "image/p1.png", new DateTime(2020, 12, 16, 17, 51, 38, 369, DateTimeKind.Local).AddTicks(3732), "toilahuy098@gmail.com", true, "huy", "123456", "0933691822", true, new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(5268) },
                    { 2, "quan 3", "image/p2.png", new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6678), "thaochi098@gmail.com", false, "chi", "123456", "0933691822", true, new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6708) },
                    { 3, "quan 3", "image/p2.png", new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6732), "hoaixp@gmail.com", false, "hoai", "123456", "0933691822", true, new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6737) },
                    { 4, "quan 3", "image/p2.png", new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6743), "lanttm@gmail.com", false, "lan", "123456", "0933691822", true, new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6750) },
                    { 5, "quan 3", "image/p2.png", new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6755), "lanttm@gmail.com", false, "lan", "123456", "0933691822", true, new DateTime(2020, 12, 16, 17, 51, 38, 370, DateTimeKind.Local).AddTicks(6757) }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "address", "email", "name", "phone", "status", "userid" },
                values: new object[,]
                {
                    { 1, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 },
                    { 2, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 },
                    { 3, "binh thanh", "toilahuy098@gmail.com", "hoai", "0933691822", true, 2 },
                    { 4, "binh thanh", "toilahuy098@gmail.com", "hoai", "0933691822", true, 2 }
                });

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
                name: "Orderdetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
