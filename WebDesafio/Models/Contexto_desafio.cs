using Microsoft.EntityFrameworkCore;

namespace WebDesafio.Models
{
    public class Contexto_desafio : DbContext
    {
        public Contexto_desafio(DbContextOptions<Contexto_desafio> options):base(options)
        {

        }
        
        public DbSet<CEP> CEP { get; set; } 
        
    }
}
