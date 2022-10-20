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
    internal class PersistenciaMensajeComun:IPersistenciaMensajeComun
    {
        private static PersistenciaMensajeComun _instancia;
        private PersistenciaMensajeComun() { }
        public static PersistenciaMensajeComun GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaMensajeComun();

            return _instancia;
        }

        public void AltaMensajeComun(MensajeComun Mensaje)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AltaMensajeComun", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NombreUsuario", Mensaje.Emisor.NombreUsuario );
            cmd.Parameters.AddWithValue("@Asunto", Mensaje.Asunto);
            cmd.Parameters.AddWithValue("@Texto", Mensaje.Texto);
            cmd.Parameters.AddWithValue("@CodigoTipo", Mensaje.Tipo.Codigo);

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
                    throw new Exception("No existe el Tipo de mensaje.");
                if (oRetorno == -3)
                    throw new Exception("Error en BD 1.");
                if (oRetorno == -4)
                    throw new Exception("Error en BD 2.");

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
        public  List<MensajeComun> ListaMensajeComunEnviado(Usuario NombreU)
        {
           
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("BuscarMailComunEnviadoUsuario", cnn);
            cmm.Parameters.AddWithValue("@Nombreusuario", NombreU.NombreUsuario);
            cmm.CommandType = CommandType.StoredProcedure;

            List<MensajeComun> _ListComunEnviado = new List<MensajeComun>();
            MensajeComun _mensajes = null;

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
                    string codtipo = (string)oReader["CodigoTipo"]; 
                        
                        _mensajes = new MensajeComun(Codigo, FechaEnv, Asunto, Texto, PersistenciaUsuario.BuscoTodosLosUsuarios(NomUsu),PersistenciaReceptor.GetInstancia().ListarDestinatario(Codigo),PersistenciaTipo.GetInstancia().Busco(codtipo));
                    _ListComunEnviado.Add(_mensajes);
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
            return _ListComunEnviado;
        }
        public List<MensajeComun> ListaMensajeComunRecibido(Usuario NombreU)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("MailComunRecibidosPorUsuario", cnn);
            cmm.Parameters.AddWithValue("@Nombreusuario", NombreU.NombreUsuario);
            cmm.CommandType = CommandType.StoredProcedure;

            List<MensajeComun> _ListComunRecibido = new List<MensajeComun>();
            MensajeComun _mensajes = null;

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
                    string codtipo = (string)oReader["CodigoTipo"];


                    _mensajes = new MensajeComun(Codigo, FechaEnv, Asunto, Texto, PersistenciaUsuario.BuscoTodosLosUsuarios(NomUsu), PersistenciaReceptor.GetInstancia().ListarDestinatario(Codigo), PersistenciaTipo.GetInstancia().Busco(codtipo));
                    _ListComunRecibido.Add(_mensajes);
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
            return _ListComunRecibido;
        }
      
    }
}
