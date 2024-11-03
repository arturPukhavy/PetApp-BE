using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetApp.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixingDateTimeUtcAndAddTestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Users",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Contacts", "DateRegistered", "Email", "Name", "Password", "Photo", "RoleId", "SitterId" },
                values: new object[,]
                {
                    { 1, "Instagram:hp", new DateTime(2020, 1, 1, 2, 3, 4, 0, DateTimeKind.Utc), "dirtyharry@gmail.com", "Harry Potter", "123456", null, 1, null },
                    { 2, "Instagram:rw", new DateTime(2020, 1, 1, 2, 3, 4, 0, DateTimeKind.Utc), "gingerhead@gmail.com", "Ron Weasley", "123456", null, 1, null },
                    { 3, "Instagram:hg", new DateTime(2020, 1, 1, 2, 3, 4, 0, DateTimeKind.Utc), "Hermione.Granger@gmail.com", "Hermione Granger", "123456", null, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
