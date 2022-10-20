using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;


namespace Logica
{
    public interface ILogicaUsuario
    {
        void Alta(Usuario unUsu);
        Usuario Logueo(string usu, string pass);
        void Modificar(Usuario UnUsuario);
        Usuario Busco(string CodUsuario);
        void Eliminar(Usuario UnUsuario);
    }
}
