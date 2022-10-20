using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;


namespace Logica
{
    public interface ILogicaTipo
    {
  
        List<Tipo> Listo();
        Tipo Busco(string tipo);
   
    }
}
