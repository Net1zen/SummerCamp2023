using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositorioPersonas
    {

        Task<bool> PersonaExistsAsync(string nombre);
        Task<bool> AltaPersonaAsync(Persona persona);
        Task<bool> SaveAsync();
        Task<IEnumerable<Persona>> Obtener10PersonasCondicionAsync();



    }
}
