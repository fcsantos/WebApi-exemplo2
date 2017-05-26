namespace Projeto.Infra.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        IdAutor = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.IdAutor);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        IdLivro = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        Titulo = c.String(nullable: false, maxLength: 100),
                        Genero = c.String(nullable: false, maxLength: 30),
                        Sinopse = c.String(nullable: false, maxLength: 200),
                        Categoria = c.String(nullable: false, maxLength: 30),
                        AutorId = c.Int(nullable: false),
                        EditoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLivro)
                .ForeignKey("dbo.Autor", t => t.AutorId)
                .ForeignKey("dbo.Editora", t => t.EditoraId)
                .Index(t => t.AutorId)
                .Index(t => t.EditoraId);
            
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        IdEditora = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.IdEditora);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "EditoraId", "dbo.Editora");
            DropForeignKey("dbo.Livro", "AutorId", "dbo.Autor");
            DropIndex("dbo.Livro", new[] { "EditoraId" });
            DropIndex("dbo.Livro", new[] { "AutorId" });
            DropTable("dbo.Editora");
            DropTable("dbo.Livro");
            DropTable("dbo.Autor");
        }
    }
}
