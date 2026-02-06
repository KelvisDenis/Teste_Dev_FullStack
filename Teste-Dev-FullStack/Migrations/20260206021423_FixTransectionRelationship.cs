using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Dev_FullStack.Migrations
{
    /// <inheritdoc />
    public partial class FixTransectionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransectionsSet_PersonsSet_PersonId",
                table: "TransectionsSet");

            migrationBuilder.DropIndex(
                name: "IX_TransectionsSet_PersonId",
                table: "TransectionsSet");

            migrationBuilder.CreateIndex(
                name: "IX_TransectionsSet_CategoryId",
                table: "TransectionsSet",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransectionsSet_PersonId",
                table: "TransectionsSet",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransectionsSet_CategoriesSet_CategoryId",
                table: "TransectionsSet",
                column: "CategoryId",
                principalTable: "CategoriesSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransectionsSet_PersonsSet_PersonId",
                table: "TransectionsSet",
                column: "PersonId",
                principalTable: "PersonsSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransectionsSet_CategoriesSet_CategoryId",
                table: "TransectionsSet");

            migrationBuilder.DropForeignKey(
                name: "FK_TransectionsSet_PersonsSet_PersonId",
                table: "TransectionsSet");

            migrationBuilder.DropIndex(
                name: "IX_TransectionsSet_CategoryId",
                table: "TransectionsSet");

            migrationBuilder.DropIndex(
                name: "IX_TransectionsSet_PersonId",
                table: "TransectionsSet");

            migrationBuilder.CreateIndex(
                name: "IX_TransectionsSet_PersonId",
                table: "TransectionsSet",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransectionsSet_PersonsSet_PersonId",
                table: "TransectionsSet",
                column: "PersonId",
                principalTable: "PersonsSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
