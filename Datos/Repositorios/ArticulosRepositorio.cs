using Microsoft.Data.SqlClient;
using Practica01.Datos.Interfaces;
using Practica01.Dominio;
using Practica01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos.Repositorios
{
    public class ArticulosRepositorio : IArticulo
    {
        public List<Articulos> GetAllArticulos()
        {
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_CONSULTAR_ARTICULOS", null);

            var articulos = new List<Articulos>(); // la palabra var determina que le complilador le asigne el tipo de variable segun lo que hay a la derecha del =

            if(dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    var articulo = new Articulos()
                    {
                        id_art = (int)row["id_art"],
                        nombre = row["nombre"].ToString(),
                        precio = (decimal)row["precio"], // la variable a la izq del = hace referencia a la property, a la derecha, al campo de la bbdd
                    };
                    articulos.Add(articulo);
                }
                
            }
            return articulos;

        }
    }
}
