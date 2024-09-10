using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Facturas
    {
        public int id_factura {  get; set; }
        public DateTime fecha { get; set; }
        public int forma_pago { get; set; }
        public string cliente {  get; set; }
        public List<DetallesFactura> detalles { get; set; } = new List<DetallesFactura>();
    }
}
