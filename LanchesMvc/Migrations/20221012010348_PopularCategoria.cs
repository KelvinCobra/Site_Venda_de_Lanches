using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMvc.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                "VALUES('Normal','Lanches feitos com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                    "VALUES('Natural','Lanches feitos com ingredientes integrais e  naturais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROM Categorias");
        }
    }
}
