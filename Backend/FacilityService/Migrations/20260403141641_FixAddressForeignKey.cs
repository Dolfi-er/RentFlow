using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityService.Migrations
{
    /// <inheritdoc />
    public partial class FixAddressForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Facilities_Id",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Addresses_Id",
                table: "Facilities",
                column: "Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Addresses_Id",
                table: "Facilities");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Facilities_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
