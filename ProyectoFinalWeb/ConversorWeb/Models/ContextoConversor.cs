using Microsoft.EntityFrameworkCore;

namespace ConversorWeb.Models
{
    public class ContextoConversor : DbContext
    {
        //1- Desde lla consola del administrados de paquetes nuget
        //escribimos add-migration "inicial"
        //2- Crear la bbd mediante el diguiente comanfdo (tambien desddee consola)
        //update-database

        //herramientas>administrador de pauetes nugget>consola
        //add-migration inicial. Se creara migration

        //update database
        public ContextoConversor(DbContextOptions<ContextoConversor> opciones) : base(opciones)
        {

        }

        public DbSet<Moneda> Moneda { get; set; }

        public DbSet<Pais> Pais { get; set; }
    }
}
