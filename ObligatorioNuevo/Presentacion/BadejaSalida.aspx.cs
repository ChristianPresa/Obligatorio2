using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txtFecha.Attributes.Add("Type", "Date");
            if (!IsPostBack)
            {
                ddlTipo.Enabled = false;
                MensajesEnviados();
                CargoDdl();
            }
            else
            {
                Session["MensajeSeleccionado"] = -1;
                gvSalida.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void MensajesEnviados()
    {
        Usuario Usuario = (Usuario)Session["Usuario"];

        List<Mensaje> Enviados = FabricaLogica.GetLogicaMensaje().ListaMensajeEnviado(Usuario);
        gvSalida.DataSource = Enviados;
        gvSalida.DataBind();

        Session["MensajeEnviado"] = Enviados;
    }

    protected void gvEntrada_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Pos = gvSalida.SelectedIndex;
        Session["MensajeSeleccionado"] = Pos;
        MensajeEnviado1.MostrarMensaje();
    }

    protected void txtFecha_TextChanged(object sender, EventArgs e)
    {
        try
        {
            List<Mensaje> MFiltrado = new List<Mensaje>();

            if (rbComun.Checked)
            {
                MFiltrado.AddRange((List<MensajeComun>)Session["FiltradosMC"]);
            }
            if (rbPrivado.Checked)
            {
                MFiltrado = (List<Mensaje>)Session["Filtrados"];
            }
            if (rbComun.Checked == false && rbPrivado.Checked == false)
            {
                MFiltrado = (List<Mensaje>)Session["MensajeEnviado"];
            }

            Convert.ToDateTime(txtFecha.Text);

            List<Mensaje> Resultado = (from unM in MFiltrado
                                       where unM.FechaHora.Date == (Convert.ToDateTime(txtFecha.Text)).Date
                                       select unM).ToList<Mensaje>();

            gvSalida.DataSource = Resultado;
            gvSalida.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void rbComun_CheckedChanged(object sender, EventArgs e)
    {
        rbPrivado.Checked = false;
        txtFecha.Text = "";

        Usuario Usuario = (Usuario)Session["Usuario"];

        List<Mensaje> MComun = (from unRegistro in (List<Mensaje>)Session["MensajeEnviado"]
                                                     where unRegistro is MensajeComun
                                                     select unRegistro).ToList<Mensaje>();
        gvSalida.DataSource = MComun;
        gvSalida.DataBind();

        Session["Filtrados"] = MComun;
        ddlTipo.Enabled = true;
    }

    protected void rbPrivado_CheckedChanged(object sender, EventArgs e)
    {
        ddlTipo.Enabled = false;
        rbComun.Checked = false;
        txtFecha.Text = "";

        Usuario Usuario = (Usuario)Session["Usuario"];

        List<Mensaje> MPrivado = (from unRegistro in (List<Mensaje>)Session["MensajeEnviado"]
                                                       where unRegistro is MensajePrivado

                                                       select unRegistro).ToList<Mensaje>();
        gvSalida.DataSource = MPrivado;
        gvSalida.DataBind();
        Session["Filtrados"] = MPrivado;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
    }

    protected void CargoDdl()
    {
        ddlTipo.DataSource = FabricaLogica.GetLogicaTipo().Listo();
        ddlTipo.DataTextField = "Nombre";
        ddlTipo.DataValueField = "Codigo";
        ddlTipo.DataBind();
    }

    protected void Limpio()
    {
        rbPrivado.Checked = false;
        rbComun.Checked = false;
        MensajesEnviados();
        lblError.Text = "";
        MensajeEnviado1.LimpiarUsserEnviado();
        Session["MensajeSeleccionado"] = null;
        gvSalida.SelectedIndex = -1;
        ddlTipo.Enabled = false;
        txtFecha.Text = "";
    }

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<MensajeComun> MensajeFiltrado = new List<MensajeComun>();
            List<MensajeComun> Resultado = new List<MensajeComun>();

            foreach (MensajeComun Mensajes in (List<Mensaje>)Session["Filtrados"])
            {
                Resultado.Add(Mensajes);
            }

            if (ddlTipo.SelectedIndex != -1)
            {
                MensajeFiltrado = (from unM in Resultado
                                   where unM.Tipo.Codigo == ddlTipo.SelectedItem.Value
                                   select unM).ToList<MensajeComun>();
            }
            gvSalida.DataSource = MensajeFiltrado;
            gvSalida.DataBind();

            Session["FiltradosMC"] = MensajeFiltrado;
            txtFecha.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}