using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersTableAndChangedProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => new { x.Email, x.Name, x.Age });
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new [] { "Name", "Email", "Age" },
                values: new object[,]
                {
                    { "Jozka", "jozo@rws.com", 21 }
                }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");
        }
    }
}
