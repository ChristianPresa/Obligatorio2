using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    #region Singleton
    internal class PersistenciaTipo:IPersistenciaTipo
    {
        private static PersistenciaTipo _instancia;
        private PersistenciaTipo() { }
        public static PersistenciaTipo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaTipo();

            return _instancia;
        }
#endregion
 
        public Tipo Busco(string CodTipo)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarTipoMensaje", cnn);
            cmd.Parameters.AddWithValue("@CodigoTipo", CodTipo);
            cmd.CommandType = CommandType.StoredProcedure;

            Tipo tTipo = null;

            try
            {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                if (_lector.Read())
                {
                    tTipo = new Tipo((string)_lector["CodigoTipo"], (string)_lector["NombreTipo"]);
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return tTipo;
        }
        public List<Tipo> Listo()
        {

            List<Tipo> oAux = new List<Tipo>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarTipo", cnn);
            cmm.CommandType = CommandType.StoredProcedure;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    Tipo tTipo = new Tipo((string)oReader["CodigoTipo"], (string)oReader["NombreTipo"]);
                    oAux.Add(tTipo);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return oAux;
        }
     
    }
}
