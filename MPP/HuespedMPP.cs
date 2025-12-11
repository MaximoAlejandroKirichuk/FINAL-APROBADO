using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class HuespedMPP : IABM<Huesped>
    {
        private HuespedDAL huespedDAL = new HuespedDAL();

        public bool Agregar(Huesped objeto)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Pasaporte",objeto.Pasaporte ),
                new SqlParameter("@Email",objeto.Email ),
                new SqlParameter("@NombreCompleto",objeto.NombreCompleto )
            };
            return huespedDAL.Agregar(parameters);
        }

        public bool Eliminar(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };
            return huespedDAL.Eliminar(parameters);
        }

        public bool Modificar(Huesped objeto)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id",objeto.Id),
                new SqlParameter("@NombreCompleto",objeto.NombreCompleto),
                new SqlParameter("@Pasaporte", objeto.Pasaporte),
                new SqlParameter("@Email", objeto.Email)
            };
            return huespedDAL.Modificar(parametros);
        }

        public List<Huesped> Listar()
        {
            DataTable dt = huespedDAL.ObtenerTabla();
            List<Huesped> huespedes = new List<Huesped>();
            foreach (DataRow dr in dt.Rows)
            {
                Huesped h = new Huesped()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Email = dr["Email"].ToString(),
                    Pasaporte = dr["Pasaporte"].ToString(),
                    NombreCompleto = dr["NombreCompleto"].ToString()
                };
                huespedes.Add(h);
            }
            return huespedes;
        }
    }
}
