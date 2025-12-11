using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HuespedDAL
    {
        SingletonDAL dal = SingletonDAL.ObtenerInstancia();

        public bool Agregar(List<SqlParameter> parameters)
        {
            string query = "Insert into Huespedes (NombreCompleto, Pasaporte, Email) Values (@NombreCompleto, @Pasaporte,@Email)";
            return dal.EjecutarNonQuery(query, parameters);
        }

        public bool Eliminar(List<SqlParameter> parameters)
        {
            string query = "DELETE FROM Huespedes WHERE ID =@ID";
            return dal.EjecutarNonQuery(query, parameters);
        }

        public bool Modificar(List<SqlParameter> parameters)
        {
            string query = "UPDATE Huespedes set NombreCompleto = @NombreCompleto, Pasaporte = @Pasaporte, Email = @Email  where Id = @Id";
            return dal.EjecutarNonQuery(query, parameters);
        }

        public DataTable ObtenerTabla()
        {
            string query = "sp_SeleccionarHuesped";
            return dal.EjecutarQuery(query,null,true);
        }
    }
}
