using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    #region Singleton
    internal class PersistenciaReceptor
    {
        private static PersistenciaReceptor _instancia;
        private PersistenciaReceptor() { }
        public static PersistenciaReceptor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaReceptor();

            return _instancia;
        }
        #endregion
        internal void Alta(Usuario UnUsuario, int CodMensaje, SqlTransaction _pTransaccion)
        {
            SqlCommand _comando = new SqlCommand("AltaDestinatario", _pTransaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NombreUsuRecibe", UnUsuario.NombreUsuario);
            _comando.Parameters.AddWithValue("@Codigo", CodMensaje);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _comando.Transaction = _pTransaccion;
                _comando.ExecuteNonQuery();
                int retorno = Convert.ToInt32(_ParmRetorno.Value);
                if (retorno == -1)
                    throw new Exception("No existe el usuario");
                if (retorno == -2)
                    throw new Exception("No existe el Mensaje");
                else if (retorno == -3)
                    throw new Exception("Usuario ya cargado, verifique la lista que no este duplicado.");
                else if (retorno == -4)
                    throw new Exception("Problema en la Base de Datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> ListarDestinatario(int codigo )
        {
        
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarDestinatario", cnn);
            cmm.Parameters.AddWithValue("@Codigo", codigo);
            cmm.CommandType = CommandType.StoredProcedure;

            List<Usuario> _Listarecibe = new List<Usuario>();
            Usuario Usu = null;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    string NombreUsu= (string)oReader["NombreUsuario"];
                    Usu = PersistenciaUsuario.BuscoTodosLosUsuarios( NombreUsu);
                    _Listarecibe.Add(Usu);
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
            return _Listarecibe;
        }
      
    }
}
