using Practica01.Datos.Interfaces;
using Practica01.Datos.Repositorios;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class FacturasServicios
    {
        IFormasPago formaPagoRepositorio;
        IArticulo articuloRepositorio;
        IFacturas facturaRepositorio;

        public FacturasServicios()
        {
            formaPagoRepositorio = new FormasPagoRepositorio();
            articuloRepositorio = new ArticulosRepositorio();
            facturaRepositorio = new FacturasRepositorio();
        }
        public List<FormasPago> GetAllFormasPago()
        {
            return formaPagoRepositorio.GetAllFormasPago();
        }

        public List<Articulos> GetAllArticulos()
        {
            return articuloRepositorio.GetAllArticulos();
        }

        public List<Facturas> GetAllFacturas()
        {
            return facturaRepositorio.GetAllFacturas();
        }

        public bool AddFactura (Facturas factura)
        {
            return facturaRepositorio.Add(factura);
        }
    }
}
