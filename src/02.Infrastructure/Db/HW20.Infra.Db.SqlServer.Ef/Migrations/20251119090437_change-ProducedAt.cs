using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW20.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class changeProducedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducedAt",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ProducedAtYear",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducedAtYear",
                table: "Cars");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProducedAt",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
