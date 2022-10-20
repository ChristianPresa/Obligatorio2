using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class MensajePrivado:Mensaje
    {
        #region Atributos
        private DateTime _FechaCaduca;
        #endregion

        #region Pripiedades
        public DateTime FechaCaduca
        {
            get { return _FechaCaduca; }
            set { _FechaCaduca = value; }
        }
        #endregion
        #region Constructor
        public MensajePrivado(int cCodigo, DateTime fFecha, string aAsunto, string tTexto, Usuario eEmisor, List<Usuario> rReceptor, DateTime fFechaCaducan)
            : base(cCodigo, fFecha, aAsunto, tTexto, eEmisor, rReceptor)
        {


            FechaCaduca = fFechaCaducan;
        }
         
        #endregion

    }
}
