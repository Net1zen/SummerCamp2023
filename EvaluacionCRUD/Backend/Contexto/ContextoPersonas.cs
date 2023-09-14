using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Contexto
{
    public class ContextoPersonas : DbContext
    {
        //1- Desde lla consola del administrados de paquetes nuget
        //escribimos add-migration "inicial"
        //2- Crear la bbd mediante el diguiente comanfdo (tambien desddee consola)
        //update-database

        //herramientas>administrador de pauetes nugget>consola
        //add-migration inicial. Se creara migration

        //update database
        public ContextoPersonas(DbContextOptions<ContextoPersonas> opciones) : base(opciones)
        {

        }

        public DbSet<Persona> Persona { get; set; }

      

    }
}

