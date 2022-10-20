using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Logica
{
    public interface IlogicaMensaje
    {
        void Alta(Mensaje Mensaje);
        List<Mensaje> ListaMensajeEnviado(Usuario NombreU);
        List<Mensaje> ListaMensajeRecibido(Usuario NombreU);
    }
}
