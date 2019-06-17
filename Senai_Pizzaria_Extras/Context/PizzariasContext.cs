using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai_Pizzaria_Extras.Domains
{
    public partial class PizzariasContext : DbContext
    {
        public PizzariasContext()
        {
        }

        public PizzariasContext(DbContextOptions<PizzariasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pizzarias> Pizzarias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog = Senai_Pizzarias_Extra; user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzarias>(entity =>
            {
                entity.HasKey(e => e.IdPizzarias);

                entity.ToTable("pizzarias");

                entity.Property(e => e.IdPizzarias).HasColumnName("Id_Pizzarias");

                entity.Property(e => e.CategoriaPreco)
                    .HasColumnName("Categoria_Preco")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(205)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(205)
                    .IsUnicode(false);

                entity.Property(e => e.OpcaoVegana)
                    .HasColumnName("Opcao_Vegana")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(205)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuarios>>)((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuarios> entity) =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property((System.Linq.Expressions.Expression<Func<Usuarios, string>>)(e => (string)e.Senha))
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(205)
                    .IsUnicode(false);

                entity.Property((System.Linq.Expressions.Expression<Func<Usuarios, string>>)(e => (string)e.Senha))
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(205)
                    .IsUnicode(false);
            }));
        }
    }
}
