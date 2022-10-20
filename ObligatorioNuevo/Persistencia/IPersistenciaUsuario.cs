using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaUsuario
    {
        void Alta(Usuario unUsu);
        Usuario Logueo(string Usu, string Pass);
        void Modificar(Usuario UnUsuario);
        Usuario Busco(string CodUsuario);
        void Eliminar(Usuario UnUsuario);
    }
}
