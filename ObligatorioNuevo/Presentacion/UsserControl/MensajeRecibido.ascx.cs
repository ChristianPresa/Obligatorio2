using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsserControl_MensajeRecibido : System.Web.UI.UserControl
{
    protected List<EntidadesCompartidas.Mensaje> Lista1;
    protected List<EntidadesCompartidas.Mensaje> Lista2;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MostrarMensaje();
            LimpiarUsserRecibido();
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    public void MostrarMensaje()
    {
        try
        {
            int PosActual = (int)Session["MensajeSeleccionado"];
            int i = 0;
            Lista1 = (List<EntidadesCompartidas.Mensaje>)Session["MensajeRecibido"];
            Lista2 = (List<EntidadesCompartidas.Mensaje>)Session["Filtrados"];
            if (Lista2 != null)
            {
                foreach (EntidadesCompartidas.Mensaje M in Lista1)
                {
                    if (i == PosActual)
                    {
                        txtAsunto.Text = M.Asunto.ToString();
                        txtMensaje.Text = M.Texto.ToString();
                        txtEnviar.Text = M.Emisor.NombreUsuario.ToString();
                        lbRecibe.DataSource = M.Receptor;
                        lbRecibe.DataTextField = "NombreUsuario";
                        lbRecibe.DataBind(); 
                        txtFecha.Text = M.FechaHora.ToString();
                    }
                    i++;
                }
            }
            else
            {
                foreach (EntidadesCompartidas.Mensaje M in Lista1)
                {
                    if (i == PosActual)
                    {
                        txtAsunto.Text = M.Asunto.ToString();
                        txtMensaje.Text = M.Texto.ToString();
                        txtEnviar.Text = M.Emisor.NombreUsuario.ToString();
                        lbRecibe.DataSource = M.Receptor;
                        lbRecibe.DataTextField = "NombreUsuario";
                        lbRecibe.DataBind();
                        txtFecha.Text = M.FechaHora.ToString();
                    }
                    i++;
                }
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
        public void LimpiarUsserRecibido()
    {
        txtAsunto.Text = "";
        txtEnviar.Text = "";
        txtFecha.Text = "";
        txtMensaje.Text = "";
        lbRecibe.Items.Clear();
        lblError.Text = "";
    }

}