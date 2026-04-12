using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityService.Migrations
{
    /// <inheritdoc />
    public partial class AddedRenterId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Facilities",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Facilities");
        }
    }
}
