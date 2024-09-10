using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos.Interfaces
{
    public interface IFacturas
    {
        List<Facturas> GetAllFacturas();

        bool Add(Facturas facturas);
    }
}
