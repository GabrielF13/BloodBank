using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DonateDbFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorId",
                table: "Donatiton");

            migrationBuilder.DropForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton");

            migrationBuilder.DropIndex(
                name: "IX_Donatiton_DonorId",
                table: "Donatiton");

            migrationBuilder.AlterColumn<int>(
                name: "DonorPersonId",
                table: "Donatiton",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton",
                column: "DonorPersonId",
                principalTable: "DonorPerson",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton");

            migrationBuilder.AlterColumn<int>(
                name: "DonorPersonId",
                table: "Donatiton",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donatiton_DonorId",
                table: "Donatiton",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorId",
                table: "Donatiton",
                column: "DonorId",
                principalTable: "DonorPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donatiton_DonorPerson_DonorPersonId",
                table: "Donatiton",
                column: "DonorPersonId",
                principalTable: "DonorPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
