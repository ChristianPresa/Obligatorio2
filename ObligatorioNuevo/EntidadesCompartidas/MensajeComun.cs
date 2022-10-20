using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class MensajeComun:Mensaje
    {
        #region Atributos
        Tipo _Tipo;
        #endregion

        #region Propiedades

        public Tipo Tipo
        {
            get
            { return _Tipo; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe contener un Tipo de mensaje.");
                }
                else
                    _Tipo = value;
            }
        }
        #endregion

        #region Construcotr

        public MensajeComun(int cCodigo, DateTime fFecha,string aAsunto, string tTexto, Usuario eEmisor, List<Usuario> rReceptor,Tipo tTipo)
            :base(cCodigo,fFecha,aAsunto,tTexto,eEmisor,rReceptor)
        {
            Tipo = tTipo;
        }
        #endregion

    }
}
