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
    public class FormasPagoRepositorio : IFormasPago
    {
        public List<FormasPago> GetAllFormasPago()
        {
            DataTable dt = DataHelper
                .GetInstance()
                .ExecuteSPQuery("SP_CONSULTAR_FORMAS_PAGO", null);
            var formasPago = new List<FormasPago>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var formaPago = new FormasPago();
                    {
                        int id_forma_pago = (int)row["id_forma_pago"];
                        string nombre = row["nombre"].ToString();
                    };
                    formasPago.Add(formaPago);
                }
            }

            return formasPago;
        }
    }
}
