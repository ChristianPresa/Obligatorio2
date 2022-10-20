using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Logica
{
    internal class LogicaTipo:ILogicaTipo
    {
        private static LogicaTipo _instancia = null;
        private LogicaTipo() { }
        public static LogicaTipo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaTipo();

            return _instancia;
        }
        public EntidadesCompartidas.Tipo Busco(string CodTipo)
        {
            return (FabricaPersistencia.GetPersistenciaTipo().Busco(CodTipo));
        }
        public List<EntidadesCompartidas.Tipo> Listo()
        {
            return (FabricaPersistencia.GetPersistenciaTipo().Listo());
        }
    }
}
