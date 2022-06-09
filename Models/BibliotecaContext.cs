using csharp_bibliotecaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_bibliotecaMvc.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }
        public DbSet<Autore> Autori { get; set; }
        public DbSet<Libro> Libri { get; set; }
        public DbSet<Prestito> Prestiti { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        /*
         * Di default i nomi delle tabelle sono creati al plurale. Questo metodo 
         * serve per specificare dei nomi diversi, in questo caso al singolare.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Utente>().ToTable("Utente");
            modelBuilder.Entity<Autore>().ToTable("Autore");
            modelBuilder.Entity<Prestito>().ToTable("Prestito");
        }
    }
}
