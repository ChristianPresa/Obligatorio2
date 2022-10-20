using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaUsuario GetPersistenciaUsuario()
        {
            return (PersistenciaUsuario.GetInstancia());
        }

        public static IPersistenciaMensajeComun GetPersistenciaMensajeComun()
        {
            return (PersistenciaMensajeComun.GetInstancia());
        }

        public static IPersistenciaMensajePrivado GetPersistenciaMensajePrviado()
        {
            return (PersistenciaMensajePrivado.GetInstancia());
        }

        public static IPersistenciaTipo GetPersistenciaTipo()
        {
            return (PersistenciaTipo.GetInstancia());
        }

        public static IPersistenciaEstadisticas GetPersistenciaEstadisitcas()
        {
            return (PersistenciaEstadisticas.GetInstancia());
        }

    }
}
