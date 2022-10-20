using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

using System.Xml;

namespace Logica
{
    public interface ILogicaEstadisticas
    {
        Dictionary<string, int> Estadisticas01();
        Dictionary<Tipo, int> Estadisticas02();
        XmlDocument Esta();    
    }
}
