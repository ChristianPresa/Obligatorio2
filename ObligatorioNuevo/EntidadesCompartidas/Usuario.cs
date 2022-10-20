using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        #region Atributos  
            private string _NomUsuario;
            private string _Pass;
            private string _NombreCompleto;
            private string _Mail;
            #endregion

            #region Propiedades

            public string NombreUsuario
            {
                get { return _NomUsuario; }
                set
                {
                    if (value.Trim().Length == 8)
                        _NomUsuario = value;
                    else
                        throw new Exception("El nombre de usuasrio debe contener 8 caracteres.");
                }
            }

            public string Password
            {
                get { return _Pass; }
                set
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(value, "[A-Za-z]{5}[0-9]{1}"))
                        _Pass = value;
                    else
                        throw new Exception("La Password debe tener un largo de 6 caracteres.");

                }
            }

            public string NomCompleto
            {
                get { return _NombreCompleto; }
                set
                {
                    if (value.Trim().Length <= 30 && value.Trim() != "")
                        _NombreCompleto = value;
                    else
                        throw new Exception("El nombre completo tiene mas de 30 caracteres.");
                }
            }

            public string Mail
            {
                get { return _Mail; }
                set
                {
                    if (value.Trim().Length <= 20 && value.Trim() != "")
                        _Mail = value;
                    else
                        throw new Exception("El mail debe contener un simbolo de @ y 20 caracteres o menos.");
                }
            }
            #endregion
            #region Constructor
            public Usuario(string nNomUsuario, string pPassword, string nNomCompleto, string mMail)
            {
                NombreUsuario = nNomUsuario;
                Password = pPassword;
                NomCompleto = nNomCompleto;
                Mail = mMail;
            }
            #endregion
        }
    }
