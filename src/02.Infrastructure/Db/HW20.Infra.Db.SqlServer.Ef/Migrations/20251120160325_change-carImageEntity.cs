using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW20.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class changecarImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarImages",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                newName: "IX_CarImages_RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Requests_RequestId",
                table: "CarImages",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Requests_RequestId",
                table: "CarImages");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "CarImages",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_RequestId",
                table: "CarImages",
                newName: "IX_CarImages_CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
