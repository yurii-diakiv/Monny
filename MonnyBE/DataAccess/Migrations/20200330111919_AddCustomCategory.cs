using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddCustomCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Limitation_Users_UserId",
                table: "Limitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Limitation",
                table: "Limitation");

            migrationBuilder.RenameTable(
                name: "Limitation",
                newName: "Limitations");

            migrationBuilder.RenameIndex(
                name: "IX_Limitation_UserId",
                table: "Limitations",
                newName: "IX_Limitations_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomCategoryId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Limitations",
                table: "Limitations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CustomCategoryId",
                table: "Expenses",
                column: "CustomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomCategories_UserId",
                table: "CustomCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CustomCategories_CustomCategoryId",
                table: "Expenses",
                column: "CustomCategoryId",
                principalTable: "CustomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Limitations_Users_UserId",
                table: "Limitations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CustomCategories_CustomCategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Limitations_Users_UserId",
                table: "Limitations");

            migrationBuilder.DropTable(
                name: "CustomCategories");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CustomCategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Limitations",
                table: "Limitations");

            migrationBuilder.DropColumn(
                name: "CustomCategoryId",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Limitations",
                newName: "Limitation");

            migrationBuilder.RenameIndex(
                name: "IX_Limitations_UserId",
                table: "Limitation",
                newName: "IX_Limitation_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Limitation",
                table: "Limitation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Limitation_Users_UserId",
                table: "Limitation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
