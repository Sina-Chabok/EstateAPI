using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addestateprices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatePrice_Estate_EstateId",
                table: "EstatePrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstatePrice",
                table: "EstatePrice");

            migrationBuilder.RenameTable(
                name: "EstatePrice",
                newName: "EstatePrices");

            migrationBuilder.RenameIndex(
                name: "IX_EstatePrice_EstateId",
                table: "EstatePrices",
                newName: "IX_EstatePrices_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstatePrices",
                table: "EstatePrices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatePrices_Estate_EstateId",
                table: "EstatePrices",
                column: "EstateId",
                principalTable: "Estate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatePrices_Estate_EstateId",
                table: "EstatePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstatePrices",
                table: "EstatePrices");

            migrationBuilder.RenameTable(
                name: "EstatePrices",
                newName: "EstatePrice");

            migrationBuilder.RenameIndex(
                name: "IX_EstatePrices_EstateId",
                table: "EstatePrice",
                newName: "IX_EstatePrice_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstatePrice",
                table: "EstatePrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatePrice_Estate_EstateId",
                table: "EstatePrice",
                column: "EstateId",
                principalTable: "Estate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
