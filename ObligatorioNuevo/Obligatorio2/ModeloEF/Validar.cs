using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEF
{
    public class Validar
    {
        public static void Mensaje(Mensaje Men)
        {
            if (Men.Asunto.Trim() == "")
                throw new Exception("El mensaje debe tener Asunto.");
            if (Men.Texto.Trim() == "")
                throw new Exception("El mensaje debe contener un Texto.");
            if (Men.Usuario1.Count >= 1)
                throw new Exception("El mensaje debe contener almenos un destinatario.");
            if (Men.Tipo == null)
                throw new Exception("Debe contener un tipo de mensaje.");
        }

        public static void Usuarios(Usuario Usu)
        {
            if (Usu.Mail.Trim() == "")
                throw new Exception("Debe contener contener un mail.");
            if (Usu.NombreCompleto.Trim() == "")
                throw new Exception("Debe contener un mensaje.");
            if (Usu.Pass.Trim() == "")
                throw new Exception("Debe contener una password");
            if (Usu.NombreUsuario.Trim() == "")
                throw new Exception("Debe contener un nombre de usuario.");
        }

        public static void Tipo(Tipo Tipo)
        {
            if (Tipo.CodigoTipo.Trim().Length == 3)
                throw new Exception("El tipo debe contener 3 letras");
            if (Tipo.NombreTipo.Trim() == "")
                throw new Exception("El mensaje debe contener un nombre");
        }
    }
}
