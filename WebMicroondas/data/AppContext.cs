using Microsoft.EntityFrameworkCore;
using WebMicroondas.Models;

namespace WebMicroondas.data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ProgramasModel> Programas { get; set; }
    }
}