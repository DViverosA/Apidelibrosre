using Apidelibros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Apidelibros
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Autor> autores { get; set; }
        public DbSet <Libro> libros { get; set; }
        public DbSet <Editorial> editoriales { get; set; }
    }
}
