﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    public interface IPersistenciaMensajePrivado
    {
        void AltaMensajePrivado(MensajePrivado Mensaje);

        List<MensajePrivado> ListarMensajePrivadoRecibido(Usuario NombreU);

        List<MensajePrivado> ListarMensajePrivadoEnviado(Usuario NombreU);
    }
}
