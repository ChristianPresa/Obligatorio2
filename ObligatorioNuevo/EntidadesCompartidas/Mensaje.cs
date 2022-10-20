using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesCompartidas
{
    public  abstract class Mensaje
    {
        #region Atributos

        private int _Codigo;
        private DateTime _FechaHora;
        private string _Asunto;
        private string _Texto;

        private Usuario _Emisor;
        List<Usuario> _Receptor;

        #endregion
        #region Propiedades

        public int CodMensaje
        {
            get { return _Codigo; }
            set {_Codigo = value; }
        }

        public string Asunto
        {
            get { return _Asunto; }
            set {
                if (value.Trim().Length <= 30 && value.Trim() != "")
                    _Asunto = value;
                else
                    throw new Exception("Debe contener un asunto");
            }
        }

        public string Texto
        {
            get { return _Texto; }
            set { if (value.Trim() != "")
                    _Texto = value;
                else
                    throw new Exception("El texto no puede ser vacio.");
            }
        }

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
        }

        public Usuario Emisor
        {
            get
            {return _Emisor;}
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe contener un Emisor.");
                }
                
                else
                    _Emisor = value;
            }
        }

        public List<Usuario> Receptor
        {
            get
            {
                return _Receptor;
            }
            set
            {
                if ( value == null)
                {
                    throw new Exception("No existe conjunto.");
                }
                if(value.Count()==0)
                {
                    throw new Exception("Debe contener al menos un receptor. ");
                }
                else
                    _Receptor = value;  
            }
        }

        #endregion
        #region Constructor

        public Mensaje(int cCodigo, DateTime fFecha, string aAsunto, string tTexto, Usuario eEmisor, List<Usuario> rReceptor)
        {
            CodMensaje = cCodigo;
            FechaHora = fFecha;
            Asunto = aAsunto;
            Texto = tTexto;
            Emisor = eEmisor;
            Receptor = rReceptor;
        }
        #endregion
    }
}
