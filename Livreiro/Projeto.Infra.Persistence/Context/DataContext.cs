using System.Data.Entity; //entityframework..
using System.Data.Entity.ModelConfiguration.Conventions; //convenções..
using System.Configuration; //connectionstring..
using Projeto.Entities;
using Projeto.Infra.Persistence.Configurations;

namespace Projeto.Infra.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.ConnectionStrings["DBLivreiro"].ConnectionString) { }

        //sobrescrever o método OnModelCreating..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //classes de configuração (mapeamento)
            modelBuilder.Configurations.Add(new AutorConfiguration());
            modelBuilder.Configurations.Add(new EditoraConfiguration());
            modelBuilder.Configurations.Add(new LivroConfiguration());

            //definição do entityframework..
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        //declarar um DbSet(Unit of Work) para cada entidade
        public DbSet<Livro> Livro { get; set; } //CRUD
        public DbSet<Autor> Autor { get; set; } //CRUD
        public DbSet<Editora> Editora { get; set; } //CRUD
    }
}
