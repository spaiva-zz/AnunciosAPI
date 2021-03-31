using Microsoft.EntityFrameworkCore.Migrations;

namespace Anuncios.Infra.Data.Migrations
{
    public partial class PrimeiraCarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Clientes (Nome,Email,Senha,IsAtivo) VALUES ('Administrador','admin@email.com.br','admin@123',1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
