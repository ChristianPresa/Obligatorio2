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
    internal class PersistenciaUsuario:IPersistenciaUsuario
    {
        #region Singleton
        private static PersistenciaUsuario _instancia;
        private PersistenciaUsuario() { }
        public static PersistenciaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaUsuario();

            return _instancia;
        }
        #endregion
        public Usuario Logueo(string Usu, string Pass)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand cmd = new SqlCommand("Logueo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NombreUsuario", Usu);
            cmd.Parameters.AddWithValue("@Pass", Pass);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(_Retorno);

            Usuario oUsu = null;

            try
            {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                if (_lector.Read())
                {
                    string oNombreUsuario = (string)_lector["NombreUsuario"];
                    string oPass = (string)_lector["Pass"];
                    string oNombreCompleto = (string)_lector["NombreCompleto"];
                    string oMail = (string)_lector["Mail"];

                    oUsu = new Usuario(oNombreUsuario, oPass, oNombreCompleto, oMail);
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
            return oUsu;
        }
        public void Alta(Usuario UnUsu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AltaUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NombreLogueo", UnUsu.NombreUsuario);
            cmd.Parameters.AddWithValue("@Pass", UnUsu.Password);
            cmd.Parameters.AddWithValue("@NombreCompleto", UnUsu.NomCompleto);
            cmd.Parameters.AddWithValue("@Mail", UnUsu.Mail);

            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(Retorno);
            int oRetorno = 0;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                oRetorno = (int)cmd.Parameters["@Retorno"].Value;
                if (oRetorno == -1)
                    throw new Exception("El Usuario ya existe.");
                if (oRetorno == -2)
                    throw new Exception("Error de alta.");
                if (oRetorno == -3)
                    throw new Exception("Error de alta.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        public void Modificar(Usuario UnUsu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("ModificarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NombreLogueo", UnUsu.NombreUsuario);
            cmd.Parameters.AddWithValue("@Pass", UnUsu.Password);
            cmd.Parameters.AddWithValue("@NombreCompleto", UnUsu.NomCompleto);
            cmd.Parameters.AddWithValue("@Mail", UnUsu.Mail);

            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(Retorno);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                int oAfectados = (int)cmd.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No se pudo modificar el usuario.");
                if (oAfectados == -2)
                    throw new Exception("Error al modificar el usuario.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        public Usuario Busco(string UnUsu) 
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarUsuarioActivo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreUsuario", UnUsu);

            Usuario Usu = null;

            try
            {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                if (_lector.Read())
                {

                    string NombreUsuario = (string)_lector["NombreUsuario"];
                    string Pass = (string)_lector["Pass"];
                    string NombreCompleto = (string)_lector["NombreCompleto"];
                    string Mail = (string)_lector["Mail"];

                    Usu = new Usuario(NombreUsuario, Pass, NombreCompleto, Mail);
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
            return Usu;
        }
        public void Eliminar(Usuario UnUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("BajaUsuario", _cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@NombreLogueo", UnUsu.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmm.Parameters.Add(oRetorno);

            try
            {
                _cnn.Open();
                cmm.ExecuteNonQuery();

                int oAfectados = (int)cmm.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Usuario no existe.");
                if (oAfectados == -2)
                    throw new Exception("Error al eliminar usuario.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
        internal static Usuario BuscoTodosLosUsuarios(string UnUsu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarUsuariosTodos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreUsuario", UnUsu);

            EntidadesCompartidas.Usuario Usu = null;

            try
            {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                if (_lector.Read())
                {

                    string NombreUsuario = (string)_lector["NombreUsuario"];
                    string Pass = (string)_lector["Pass"];
                    string NombreCompleto = (string)_lector["NombreCompleto"];
                    string Mail = (string)_lector["Mail"];

                    Usu = new Usuario(NombreUsuario, Pass, NombreCompleto, Mail);
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
            return Usu;
        }
    }
}
