using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leave_mgt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployeeDataPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
             name: "Discriminator",
             table: "AspNetUsers",
             nullable: false,
             defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
             name: "DateJoined",
             table: "AspNetUsers",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "DateOfBirth",
             table: "AspNetUsers",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "Firstname",
             table: "AspNetUsers",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "Lastname",
             table: "AspNetUsers",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
             name: "TaxId",
             table: "AspNetUsers",
             nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "AspNetUsers");
        }
    }
}
