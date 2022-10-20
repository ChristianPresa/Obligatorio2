using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaMensaje : IlogicaMensaje
    {
        private static LogicaMensaje _instancia = null;
        private LogicaMensaje() { }
        public static LogicaMensaje GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaMensaje();

            return _instancia;
        }

        public void Alta(Mensaje Mensaje)
        {
            if (Mensaje is MensajeComun)
                FabricaPersistencia.GetPersistenciaMensajeComun().AltaMensajeComun((MensajeComun)Mensaje);
            else
                FabricaPersistencia.GetPersistenciaMensajePrviado().AltaMensajePrivado((MensajePrivado)Mensaje);
        }


        public List<Mensaje> ListaMensajeEnviado(Usuario NombreU)
        {
            List<Mensaje> TodosLosMensajesEnviados = new List<Mensaje>();
            TodosLosMensajesEnviados.AddRange(FabricaPersistencia.GetPersistenciaMensajePrviado().ListarMensajePrivadoEnviado(NombreU));
            TodosLosMensajesEnviados.AddRange(FabricaPersistencia.GetPersistenciaMensajeComun().ListaMensajeComunEnviado(NombreU));

            List<Mensaje> Enviados = (from Mensajes in TodosLosMensajesEnviados
                                                           orderby Mensajes.FechaHora descending
                                                           select Mensajes).ToList<Mensaje>();
            return Enviados;
        }
        public List<Mensaje> ListaMensajeRecibido(Usuario NombreU)
        {
            List<Mensaje> TodosLosMensajesRecibidos = new List<Mensaje>();
            TodosLosMensajesRecibidos.AddRange(FabricaPersistencia.GetPersistenciaMensajeComun().ListaMensajeComunRecibido(NombreU));
            TodosLosMensajesRecibidos.AddRange(FabricaPersistencia.GetPersistenciaMensajePrviado().ListarMensajePrivadoRecibido(NombreU));

            List<Mensaje> Recibido = (from Mensajes in TodosLosMensajesRecibidos
                                                           orderby Mensajes.FechaHora descending
                                                           select Mensajes).ToList<Mensaje>();
            return TodosLosMensajesRecibidos;
        }

    }
}