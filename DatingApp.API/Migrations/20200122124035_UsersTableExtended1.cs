using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class UsersTableExtended1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    Interrests = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Created", "DateOfBirth", "Gender", "Interrests", "Introduction", "KnownAs", "LastActive", "LookingFor", "PasswordHash", "PasswordSalt", "UserName", "city" },
                values: new object[] { 1, "Sri Lanka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Codeing", "Anything is Possible and Nothing is Impossible", "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don't reinvent the wheel,unless you plan on learning more about wheels", new byte[] { 190, 50, 197, 215, 242, 161, 41, 145, 234, 222, 19, 229, 166, 232, 121, 64, 205, 132, 168, 44, 17, 51, 46, 58, 154, 64, 56, 51, 8, 107, 41, 15, 174, 179, 63, 134, 71, 97, 150, 34, 154, 218, 79, 156, 145, 91, 197, 16, 60, 81, 142, 172, 121, 11, 61, 125, 253, 86, 197, 195, 63, 30, 129, 122 }, new byte[] { 127, 46, 60, 143, 94, 156, 214, 151, 72, 21, 158, 141, 123, 43, 91, 224, 0, 116, 45, 242, 159, 244, 93, 248, 56, 14, 139, 180, 101, 76, 54, 150, 32, 169, 124, 16, 147, 237, 231, 148, 129, 46, 202, 43, 255, 69, 155, 248, 40, 131, 29, 205, 87, 238, 12, 128, 44, 253, 20, 133, 240, 208, 19, 222, 148, 164, 45, 212, 89, 218, 37, 112, 64, 240, 174, 195, 132, 221, 23, 150, 98, 87, 196, 121, 192, 87, 213, 123, 131, 180, 69, 92, 85, 58, 9, 175, 47, 176, 15, 86, 106, 167, 206, 33, 49, 97, 15, 31, 76, 119, 217, 216, 71, 120, 53, 209, 173, 148, 167, 107, 240, 178, 232, 213, 179, 125, 236, 227 }, "kokila.sanjeewa@gmail.com", "Colombo" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "DateAdded", "Description", "IsMain", "Url", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://randomuser.me/", true, "https://randomuser.me/api/portraits/men/75.jpg", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
