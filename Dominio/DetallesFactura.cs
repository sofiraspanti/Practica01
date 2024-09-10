using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class DetallesFactura
    {
        public int id_detalle {  get; set; }
        public int nro_factura { get; set; }
        public int articulo { get; set; }  
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        
    }
}
