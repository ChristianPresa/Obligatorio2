using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaEstadisticas : IPersistenciaEstadisticas
    {
        private static PersistenciaEstadisticas _instancia;
        private PersistenciaEstadisticas() { }
        public static PersistenciaEstadisticas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEstadisticas();

            return _instancia;
        }

        public Dictionary<string, int> Estadisticas01()
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("Estadisticas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parametros de salida
            SqlParameter Valor1 = new SqlParameter("@CantUsuariosActivos", SqlDbType.Int);
            Valor1.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Valor1);
            SqlParameter Valor2 = new SqlParameter("@CantMensajesComunes", SqlDbType.Int);
            Valor2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Valor2);
            SqlParameter Valor3 = new SqlParameter("@CantMensajesPrivados", SqlDbType.Int);
            Valor3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Valor3);

            Dictionary<string, int> Aux = new Dictionary<string, int>();

            try
            {
                cnn.Open();
                cmd.ExecuteScalar();
                Aux.Add("CantUsuariosActivos", Convert.ToInt32(Valor1.Value));
                Aux.Add("CantMensajesComunes", Convert.ToInt32(Valor2.Value));
                Aux.Add("CantMensajesPrivados", Convert.ToInt32(Valor3.Value));
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return Aux;
        }

        public Dictionary<Tipo, int> Estadisticas02()
         {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("Estadisticas2", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            Dictionary<Tipo, int> Aux = new Dictionary<Tipo, int>();

             try
             {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                while (_lector.Read())
                {
                    string A = (string)_lector["CodigoTipo"];
                    int B = (int)_lector[1];

                    Tipo _tipo = PersistenciaTipo.GetInstancia().Busco(A);
                    Aux.Add(_tipo,B);
                }
                _lector.Close();
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             finally
             {
                 cnn.Close();
             }
            return Aux;   
         }  
    }
}
