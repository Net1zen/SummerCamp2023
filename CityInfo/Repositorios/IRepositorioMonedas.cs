using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositorioMonedas
    {
        IEnumerable<Moneda> ObtenerMonedas();

        Moneda ObtenerMoneda(string codigo);
        void AgregarMoneda(Moneda moneda);
    }
}
