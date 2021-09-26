using System;
using System.Collections.Generic;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL
{
    public sealed class EatContext : DbContext
    {
        public EatContext(DbContextOptions options): base(options) { }

        public EatContext()
        {
            try
            {
                Database.EnsureCreated();
                this.Seed();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha na criação da Base de dados {e}");
                throw;
            }
        }

        #region Entities

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public ISet<ClienteUsuario> ClienteUsuario { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Morada> Morada { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().Ignore(a => a.NomeCompleto);

            modelBuilder.Entity<Morada>().Ignore(a => a.MoradaCompleta)
                .Property(a => a.Bloco).HasMaxLength(1);

            modelBuilder.Entity<Cliente>().Ignore(a => a.NomeCompleto)
                .HasOne(a => a.ClienteUsuario)
                .WithOne(a => a.Cliente);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=EatDbCore;integrated security=True; ");
        }
    }
}
