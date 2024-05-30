using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DonatePersonDbFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton");

            migrationBuilder.DropIndex(
                name: "IX_Donatiton_DonorPersonId",
                table: "Donatiton");

            migrationBuilder.DropColumn(
                name: "DonorPersonId",
                table: "Donatiton");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonorPersonId",
                table: "Donatiton",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donatiton_DonorPersonId",
                table: "Donatiton",
                column: "DonorPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton",
                column: "DonorPersonId",
                principalTable: "DonorPerson",
                principalColumn: "Id");
        }
    }
}
