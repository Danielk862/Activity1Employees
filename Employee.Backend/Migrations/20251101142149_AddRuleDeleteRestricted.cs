using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRuleDeleteRestricted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states");

            migrationBuilder.CreateIndex(
                name: "IX_states_Id_Name",
                table: "states",
                columns: new[] { "Id", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_Name",
                table: "countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_Id_Name",
                table: "cities",
                columns: new[] { "Id", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_Id_Name",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_countries_Name",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_cities_Id_Name",
                table: "cities");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_states_StateId",
                table: "cities",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
