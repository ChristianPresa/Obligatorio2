using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaEstadisticas:ILogicaEstadisticas
    {
        private static LogicaEstadisticas _instancia = null;
        private LogicaEstadisticas() { }
        public static LogicaEstadisticas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEstadisticas();

            return _instancia;
        }

        public Dictionary<string, int> Estadisticas01()
        {
            return FabricaPersistencia.GetPersistenciaEstadisitcas().Estadisticas01();
        }

        public Dictionary<Tipo, int> Estadisticas02()
        {
            return FabricaPersistencia.GetPersistenciaEstadisitcas().Estadisticas02();
        }

        public XmlDocument Esta()
        {
            Dictionary<string, int> Lista1 = FabricaLogica.GetLogicaEstadisticas().Estadisticas01();
            Dictionary<Tipo, int> Lista2 = FabricaLogica.GetLogicaEstadisticas().Estadisticas02();

            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml("<Estadistica02> </Estadistica02>");
            XmlNode _raiz = Doc.DocumentElement;      
            foreach (var element in Lista2)
            {
                XmlElement EleNom = Doc.CreateElement("Nombre");
                EleNom.InnerText = element.Key.Nombre;

                XmlElement EleCod = Doc.CreateElement("Codigo");
                EleCod.InnerText = element.Key.Codigo;

                XmlElement EleCant = Doc.CreateElement("Cantidad");
                EleCant.InnerText = element.Value.ToString();

                XmlElement _Dos = Doc.CreateElement("Tipo");
                _Dos.AppendChild(EleNom);
                _Dos.AppendChild(EleCod);
                _Dos.AppendChild(EleCant);
                _raiz.AppendChild(_Dos);
            }


            XmlElement _esta = Doc.CreateElement("Estadistica");
            foreach (var element in Lista1)
            {
                XmlElement Ele = Doc.CreateElement(element.Key);
                Ele.InnerText = element.Value.ToString();
                _esta.AppendChild(Ele);
                _raiz.AppendChild(_esta);
            }
            return Doc;
        }
    } 
}
