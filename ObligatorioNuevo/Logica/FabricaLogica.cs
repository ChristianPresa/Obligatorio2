using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaUsuario GetLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());
        }

        public static IlogicaMensaje GetLogicaMensaje()
        {
            return (LogicaMensaje.GetInstancia());
        }

        public static ILogicaTipo GetLogicaTipo()
        {
            return (LogicaTipo.GetInstancia());
        }

        public static ILogicaEstadisticas GetLogicaEstadisticas()
        {
            return (LogicaEstadisticas.GetInstancia());
        }
    }
}
