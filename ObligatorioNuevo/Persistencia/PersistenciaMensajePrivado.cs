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
    internal class PersistenciaMensajePrivado:IPersistenciaMensajePrivado
    {
        private static PersistenciaMensajePrivado _instancia;
        private PersistenciaMensajePrivado() { }
        public static PersistenciaMensajePrivado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaMensajePrivado();

            return _instancia;
        }

        public void AltaMensajePrivado(MensajePrivado Mensaje)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AltaMensajePrivado", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NombreUsuario", Mensaje.Emisor.NombreUsuario);
            cmd.Parameters.AddWithValue("@Asunto", Mensaje.Asunto);
            cmd.Parameters.AddWithValue("@Texto", Mensaje.Texto);
            cmd.Parameters.AddWithValue("@FechaCaduca", Mensaje.FechaCaduca);

            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(Retorno);
            int oRetorno = 0;

            SqlTransaction _miTransaccion = null;

            try
            {
                cnn.Open();
                _miTransaccion = cnn.BeginTransaction();
                cmd.Transaction = _miTransaccion;
                cmd.ExecuteNonQuery();

                oRetorno = (int)cmd.Parameters["@Retorno"].Value;
                if (oRetorno == -1)
                    throw new Exception("El Usuario no existe.");
                if (oRetorno == -2)
                    throw new Exception("La fecha de caducidad debe ser mayor a 24 horas.");
                if (oRetorno == -3)
                    throw new Exception("Error en BD 100");
                if (oRetorno == -4)
                    throw new Exception("Error en BD 101");

                foreach (Usuario usu in Mensaje.Receptor)
                {
                    PersistenciaReceptor.GetInstancia().Alta(usu, oRetorno, _miTransaccion);
                }
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<MensajePrivado> ListarMensajePrivadoEnviado(Usuario NombreU)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("BuscarMailPrivadoEnviadoUsuario", cnn);
            cmm.Parameters.AddWithValue("@Nombreusuario", NombreU.NombreUsuario);
            cmm.CommandType = CommandType.StoredProcedure;

            List<MensajePrivado> _ListPrivadoEnviado = new List<MensajePrivado>();
            MensajePrivado _mensajes = null;
            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    int Codigo = (int)oReader["Codigo"];
                    DateTime FechaEnv = (DateTime)oReader["FechaHora"];
                    string Asunto = (string)oReader["Asunto"];
                    string Texto = (string)oReader["Texto"];
                    string NomUsu = (string)oReader["NombreUsuario"];
                    DateTime fechacaduca = (DateTime)oReader["FechaCaduca"];
  
                    _mensajes = new MensajePrivado(Codigo, FechaEnv, Asunto, Texto, PersistenciaUsuario.BuscoTodosLosUsuarios(NomUsu), PersistenciaReceptor.GetInstancia().ListarDestinatario(Codigo),fechacaduca);
                    _ListPrivadoEnviado.Add(_mensajes);
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
            return _ListPrivadoEnviado;
        }
        public List<MensajePrivado> ListarMensajePrivadoRecibido(Usuario NombreU)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("MailPrivadoRecibidosPorUsuario", cnn);
            cmm.Parameters.AddWithValue("@Nombreusuario", NombreU.NombreUsuario);
            cmm.CommandType = CommandType.StoredProcedure;

            List<MensajePrivado> _ListPrivadoRecibido = new List<MensajePrivado>();
            MensajePrivado _mensajes = null;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();
                
                while (oReader.Read())
                {
                    int Codigo = (int)oReader["Codigo"];
                    DateTime FechaEnv = (DateTime)oReader["FechaHora"];
                    string Asunto = (string)oReader["Asunto"];
                    string Texto = (string)oReader["Texto"];
                    string NomUsu = (string)oReader["NombreUsuario"];
                    DateTime fechacaduca = (DateTime)oReader["FechaCaduca"];



                    _mensajes = new MensajePrivado(Codigo, FechaEnv, Asunto, Texto, PersistenciaUsuario.BuscoTodosLosUsuarios(NomUsu), PersistenciaReceptor.GetInstancia().ListarDestinatario(Codigo), fechacaduca);
                    _ListPrivadoRecibido.Add(_mensajes);
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
            return _ListPrivadoRecibido;
        }
      
    }
}
