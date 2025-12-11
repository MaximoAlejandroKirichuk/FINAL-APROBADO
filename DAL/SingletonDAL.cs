using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SingletonDAL
    {
        private const string stringConnection = "Data Source=.;Initial Catalog=FinalAprobado1;Integrated Security=True";
        public static SingletonDAL Instancia { get; private set; }
        private SingletonDAL()
        {
            
        }

        public static SingletonDAL ObtenerInstancia()
        {
            if(Instancia == null)
            {
                Instancia = new SingletonDAL();
            }
            return Instancia;
        }

        public DataTable EjecutarQuery(string query,List<SqlParameter> parametros, bool esStoredProcedured = false)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(stringConnection))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (esStoredProcedured)
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    if(parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool EjecutarNonQuery(string query, List<SqlParameter> parameters = null, bool esStoredProcedured =false)
        {
            using(SqlConnection conn = new SqlConnection(stringConnection))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (esStoredProcedured)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    if(parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}
