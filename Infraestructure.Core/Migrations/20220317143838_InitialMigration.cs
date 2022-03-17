using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "AuthorsEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                schema: "Library",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Sede = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "TypeBook",
                schema: "Master",
                columns: table => new
                {
                    IdTypeBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeBook = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBook", x => x.IdTypeBook);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Security",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TypePermission",
                schema: "Security",
                columns: table => new
                {
                    IdTypePermission = table.Column<int>(nullable: false),
                    TypePermission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePermission", x => x.IdTypePermission);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "Library",
                columns: table => new
                {
                    IdBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true),
                    Sipnosis = table.Column<string>(maxLength: 500, nullable: true),
                    Num_Paginas = table.Column<int>(nullable: false),
                    IdTypeBook = table.Column<int>(nullable: false),
                    IdEditorial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Book_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalSchema: "Library",
                        principalTable: "Editorial",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_TypeBook_IdTypeBook",
                        column: x => x.IdTypeBook,
                        principalSchema: "Master",
                        principalTable: "TypeBook",
                        principalColumn: "IdTypeBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Security",
                columns: table => new
                {
                    IdPermission = table.Column<int>(nullable: false),
                    Permission = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    IdTypePermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                    table.ForeignKey(
                        name: "FK_Permission_TypePermission_IdTypePermission",
                        column: x => x.IdTypePermission,
                        principalSchema: "Security",
                        principalTable: "TypePermission",
                        principalColumn: "IdTypePermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUser_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors_Has_BooksEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Authors = table.Column<int>(nullable: false),
                    Id_Books = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_Has_BooksEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Has_BooksEntities_AuthorsEntities_Id_Authors",
                        column: x => x.Id_Authors,
                        principalTable: "AuthorsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Has_BooksEntities_Book_Id_Books",
                        column: x => x.Id_Books,
                        principalSchema: "Library",
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermission",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermission_Permission_IdPermission",
                        column: x => x.IdPermission,
                        principalSchema: "Security",
                        principalTable: "Permission",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermission_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Has_BooksEntities_Id_Authors",
                table: "Authors_Has_BooksEntities",
                column: "Id_Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Has_BooksEntities_Id_Books",
                table: "Authors_Has_BooksEntities",
                column: "Id_Books");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdEditorial",
                schema: "Library",
                table: "Book",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdTypeBook",
                schema: "Library",
                table: "Book",
                column: "IdTypeBook");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdTypePermission",
                schema: "Security",
                table: "Permission",
                column: "IdTypePermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermission_IdPermission",
                schema: "Security",
                table: "RolesPermission",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermission_IdRol",
                schema: "Security",
                table: "RolesPermission",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdRol",
                schema: "Security",
                table: "RolUser",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdUser",
                schema: "Security",
                table: "RolUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Security",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors_Has_BooksEntities");

            migrationBuilder.DropTable(
                name: "RolesPermission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AuthorsEntities");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Editorial",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "TypeBook",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TypePermission",
                schema: "Security");
        }
    }
}
