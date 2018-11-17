using Microsoft.EntityFrameworkCore.Migrations;

namespace TO.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    AttributeTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttributeTypeName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.AttributeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    InterfaceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterfaceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.InterfaceId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectItems",
                columns: table => new
                {
                    ObjectItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectItemName = table.Column<string>(nullable: true),
                    InterfaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectItems", x => x.ObjectItemId);
                    table.ForeignKey(
                        name: "FK_ObjectItems_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "InterfaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    AttributeValueId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(nullable: true),
                    ObjectItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.AttributeValueId);
                    table.ForeignKey(
                        name: "FK_AttributeValues_ObjectItems_ObjectItemId",
                        column: x => x.ObjectItemId,
                        principalTable: "ObjectItems",
                        principalColumn: "ObjectItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_ObjectItemId",
                table: "AttributeValues",
                column: "ObjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectItems_InterfaceId",
                table: "ObjectItems",
                column: "InterfaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "ObjectItems");

            migrationBuilder.DropTable(
                name: "Interfaces");
        }
    }
}
