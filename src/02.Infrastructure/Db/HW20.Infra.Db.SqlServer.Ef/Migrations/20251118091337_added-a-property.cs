using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW20.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addedaproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Unacceptable",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unacceptable",
                table: "Requests");
        }
    }
}
