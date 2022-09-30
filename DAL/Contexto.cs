using AP1_AP_Oly.Models;
using Microsoft.EntityFrameworkCore;

namespace AP1_AP_Oly.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Registros> Registros { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}
