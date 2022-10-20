using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Tipo
    {
        #region Atributos

        private string _Codigo;
        private string _Nombre;

        #endregion

        #region Pripiedades
        public string Codigo
        {
            get { return _Codigo; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[A-Za-z]{3}"))
                    _Codigo = value;
                else
                    throw new Exception("El codigo debe tener 3 caracteres.");
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (value.Trim().Length <= 15 && value.Trim() != "")
                    _Nombre = value;
                else
                    throw new Exception("Debe tener un nombre de Tipo, y debe ser menor a 16 caracteres.");
            }
        }
        #endregion

        #region Constructor

        public Tipo(string cCodigo, string nNombre)
        {
            Codigo = cCodigo;
            Nombre = nNombre;
        }

        #endregion
    }
}
