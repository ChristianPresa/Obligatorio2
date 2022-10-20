using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaEstadisticas
    {
        Dictionary<string,int> Estadisticas01();
        Dictionary<Tipo, int> Estadisticas02();
    }
}
