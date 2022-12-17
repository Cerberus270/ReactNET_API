using Microsoft.EntityFrameworkCore;
using ReactNET_API.Models;

namespace ReactNET_API.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<GestoresBD> gestores_bd { get; set; }
    }
}
