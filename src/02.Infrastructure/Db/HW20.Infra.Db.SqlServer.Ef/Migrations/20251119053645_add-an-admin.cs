using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW20.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addanadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "PasswordHash", "UpdatedBy", "UptatedAt", "Username" },
                values: new object[] { 1, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "81dc9bdb52d04dc20036dbd8313ed055", null, null, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
