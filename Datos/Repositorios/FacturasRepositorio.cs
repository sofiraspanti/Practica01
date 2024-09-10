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
    public class FacturasRepositorio : IFacturas
    {
        public bool Add(Facturas facturas)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_AGREGAR_FACTURAS", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                // PARAMETROS DE ENTRADA: equivalen a los VALUES de la sensentencia INSERT
                cmd.Parameters.AddWithValue("@fecha", facturas.fecha); // "@fecha" hace referencia al nombre que obtiene dicho campo en el almacenam almacenado
                cmd.Parameters.AddWithValue("id_forma_pago", facturas.forma_pago);
                cmd.Parameters.AddWithValue("cliente", facturas.cliente);

                // PARAMETRO DE SALIDA: equivale al nro de id que surge del registro anterior 
                SqlParameter param = new SqlParameter("id_factura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int idFactura = (int)param.Value;
                if (facturas.detalles.Count == 0)
                {
                    t.Rollback();
                }
                foreach (var detalle in facturas.detalles)
                {
                    var cmdDetalle = new SqlCommand("SP_AGREGAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_factura", detalle.nro_factura);
                    cmdDetalle.Parameters.AddWithValue("@id_art", detalle.articulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", detalle.precio);
                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            } catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }

        public List<Facturas> GetAllFacturas()
        {
            var facturas = new List<Facturas>();

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_CONSULTAR_FACTURAS", null);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Facturas factura = new Facturas()
                    {
                        id_factura = (int)row["id_factura"],
                        fecha = Convert.ToDateTime(row["fecha"]),
                        forma_pago = (int)row["id_forma_pago"],
                        cliente = row["cliente"].ToString(),
                    };
                    facturas.Add(factura);
                }
            }
            return facturas;
        }


    }
}
