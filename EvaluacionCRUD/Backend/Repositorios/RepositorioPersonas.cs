using Contexto;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioPersonas:IRepositorioPersonas
    {

        private ContextoPersonas _context;

        public RepositorioPersonas( ContextoPersonas context)
        {
            _context = context;
        }

        public async Task<bool> AltaPersonaAsync(Persona persona)
        {
            var exists = await PersonaExistsAsync(persona.Nombre);

            if (!exists)
            {
                _context.Persona.Add(persona);
                return false;
            }
            return true;
        }

        public async Task<bool> PersonaExistsAsync(string nombre)
        {
            if (nombre == null)
            {
                throw new ArgumentNullException(nameof(nombre));
            }

            return await _context.Persona.AnyAsync(p => p.Nombre == nombre);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }


    }
}
