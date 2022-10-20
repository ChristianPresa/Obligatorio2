using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaMensajeComun
    {
        void AltaMensajeComun(MensajeComun Mensaje);

        List<MensajeComun> ListaMensajeComunRecibido(Usuario NombreU);

        List<MensajeComun> ListaMensajeComunEnviado(Usuario NombreU);
    }
}
