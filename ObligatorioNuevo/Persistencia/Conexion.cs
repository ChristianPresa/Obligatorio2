using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {

        internal static string _cnn = "Data Source=.;Initial Catalog=Mensajes;Integrated Security=True"; 
        internal static string Cnn
        {
            get { return _cnn; }
        }
    }
}
