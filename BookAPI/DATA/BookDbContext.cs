using BookAPI.MODELS;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BookAPI.DATA
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<GeneroDetalle> GeneroDetalles { get; set; }
        public DbSet<Libro> libros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cliente1 = new Cliente() { ID = 1, NombreCompleto = "Juan Pérez", email = "juan@gmail.com" };
            var cliente2 = new Cliente() { ID = 2, NombreCompleto = "María García", email = "maria@gmail.com" };

            var libro1 = new Libro() { ID = 1, Titulo = "El código Da Vinci", Autor = "Dan Brown", Publicacion = new DateTime(2003, 4, 1) };
            var libro2 = new Libro() { ID = 2, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Publicacion = new DateTime(1967, 5, 30) };

            var genero1 = new Genero() { ID = 1, Name = "Misterio", Descripcion = "Libros de misterio y suspenso", LibroID = 1};
            var genero2 = new Genero() { ID = 2, Name = "Realismo mágico", Descripcion = "Libros con elementos de fantasía en un contexto realista" ,LibroID=2 };

            var generoDetalle1 = new GeneroDetalle() { ID = 1, GeneroID = 1 };
            var generoDetalle2 = new GeneroDetalle() { ID = 2, GeneroID = 2 };

            var pedido1 = new Pedido() { ID = 1, ClienteID = 1, LibroID = 1, FechaPedido = DateTime.Now.AddDays(-7) };
            var pedido2 = new Pedido() { ID = 2, ClienteID = 2, LibroID = 2, FechaPedido = DateTime.Now.AddDays(-14) };

            modelBuilder.Entity<Cliente>().HasData(new Cliente[] { cliente1, cliente2 });
            modelBuilder.Entity<Libro>().HasData(new Libro[] { libro1, libro2 });
            modelBuilder.Entity<Genero>().HasData(new Genero[] { genero1, genero2 });
            modelBuilder.Entity<GeneroDetalle>().HasData(new GeneroDetalle[] { generoDetalle1, generoDetalle2 });
            modelBuilder.Entity<Pedido>().HasData(new Pedido[] { pedido1, pedido2 });

            base.OnModelCreating(modelBuilder);
        }

    }
}
