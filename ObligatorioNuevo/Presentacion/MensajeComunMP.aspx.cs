using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using Persistencia;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargoDDL();
                Limpio();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


    protected void Limpio()
    {
        txtMensaje.Text = "";
        txtReceptor.Text = "";
        txtAsunto.Text = "";
        lblError.Text = "";
        ddlTipo.SelectedIndex = 0;
    }

    protected void cargoDDL()
    {
        ddlTipo.DataSource = FabricaLogica.GetLogicaTipo().Listo();
        ddlTipo.DataTextField = "Nombre";
        ddlTipo.DataValueField = "Codigo";
        ddlTipo.DataBind();

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        List<Usuario> _lista = new List<Usuario>();
        //List<string> Usuarios = new List<string>();
        try
        {
            foreach (ListItem Uno in lbReceptores.Items)
            {
                Usuario usu = FabricaPersistencia.GetPersistenciaUsuario().Busco(Uno.Text.Trim());
                if (usu != null)
                    _lista.Add(FabricaPersistencia.GetPersistenciaUsuario().Busco(Uno.Text.Trim()));
                else
                {
                    lblError.Text = "El usuario " + Uno.ToString() + " no existe.";
                    return;
                }
            }

            DateTime fecha = DateTime.Now;
            var unUsu = (Usuario)Session["Usuario"];
            Tipo Tipo = FabricaLogica.GetLogicaTipo().Busco(ddlTipo.SelectedValue);

            MensajeComun Mensaje = new MensajeComun(0, fecha, txtAsunto.Text, txtMensaje.Text, unUsu, _lista, Tipo);

            Logica.FabricaLogica.GetLogicaMensaje().Alta(Mensaje);
            Limpio();

            lblError.Text = "Alta de mensaje correcta";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lbReceptores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (txtReceptor.Text.Trim().Length > 0)
        {
            lbReceptores.Items.Add(txtReceptor.Text.Trim());
            txtReceptor.Text = "";
            lblError.Text = "Se agrego un destinatario a la lista.";
        }
        else
            lblError.Text = "No Hay nada ingresado - No se agrega a la lista";
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        if (lbReceptores.SelectedIndex >= 0)
        {
            lbReceptores.Items.RemoveAt(lbReceptores.SelectedIndex);
            lblError.Text = "Eliminacion con exito";
        }
        else
            lblError.Text = "Debe Seleccionar un emisor para borrar";
    }

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
        lbReceptores.Items.Clear();
        lbReceptores.SelectedIndex = -1;
    }
 
}