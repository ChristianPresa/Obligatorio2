using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEF
{
    public class Validar
    {
        public static void ValidarMensaje(Mensaje Men)
        {
            if (Men.Asunto.Trim() == "")
                throw new Exception("El mensaje debe contener un Asuto");
            if (Men.Texto.Trim() == "")
                throw new Exception("El mensaje debe contener un Texto.");
            if (Men.Usuario1.Count >= 1)
                throw new Exception("El mensaje debe contener almenos un destinatario.");
            if (Men.Tipo == null)
                throw new Exception("Debe contener un tipo de mensaje.");
            if (Men.Usuario1 == null)
                throw new Exception("Debe tener un usuario de destino");
            if (Men.Usuario1.Count == 0)
                throw new Exception("Debe indicar un destinatario");
            
        }

        public static void ValidarUsuarios(Usuario Usu)
        {
            if (!(Usu.Mail.Trim().Length <= 20 && Usu.Mail.Trim() != "")) //FALTA VALIDAR @
                    throw new Exception("Debe contener contener un mail.");
            if (Usu.NombreCompleto.Trim() == "" || Usu.NombreCompleto.Trim().Length > 30)
                throw new Exception("Debe contener un mensaje.");
            if (!(System.Text.RegularExpressions.Regex.IsMatch(Usu.NombreUsuario, "[A-Za-z]{8}")))
                throw new Exception("Debe contener un nombre de usuario de 8 caracteres.");
            if (!(System.Text.RegularExpressions.Regex.IsMatch(Usu.Pass, "[A-Za-z]{5}[0-9]{1}")))
                throw new Exception("Las password debe contener 5 letras y 1 numero");
            
               
        }

        public static void ValidarTipo(Tipo Tipo)
        {
            if (!(System.Text.RegularExpressions.Regex.IsMatch(Tipo.CodigoTipo, "[A-Za-z]{3}")))
                throw new Exception("El tipo debe contener 3 letras");
            if (!(Tipo.NombreTipo.Trim().Length <= 15 && Tipo.NombreTipo.Trim() != ""))
                throw new Exception("El mensaje debe contener un nombre y debe ser menor a 15 letras."); //Misma validacion que proyecto anerior?
            
            

        }
    }
}
