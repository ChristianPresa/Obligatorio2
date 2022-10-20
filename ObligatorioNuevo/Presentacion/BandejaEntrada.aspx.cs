using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
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
                CargoDdl();          
                MensajesRecibido();
            }
            else
            {
                gvEntrada.SelectedIndex = -1;
                Session["MensajeSeleccionado"] = -1;
            }

        }
        catch (Exception ex) 
        {
            lblError.Text = ex.Message;
        }
    }

    protected void MensajesRecibido()
    {

        Usuario Usuario = (Usuario)Session["Usuario"];

        List<Mensaje> Recibido = FabricaLogica.GetLogicaMensaje().ListaMensajeRecibido(Usuario);
        gvEntrada.DataSource = Recibido;
        gvEntrada.DataBind();

        Session["MensajeRecibido"] = Recibido;
    }

    private int[] ConvertirFechaHora(string pFecha, string pHoraMinutos)
    {
        int[] resultado = new int[5];
        try
        {
            string[] subFecha = pFecha.Split('-');
            resultado[0] = Convert.ToInt32(subFecha[0]);
            resultado[1] = Convert.ToInt32(subFecha[1]);
            resultado[2] = Convert.ToInt32(subFecha[2]);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return resultado;
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

            gvEntrada.DataSource = Resultado;
            gvEntrada.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvEntrada_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Pos = gvEntrada.SelectedIndex;
        Session["MensajeSeleccionado"] = Pos;
        MensajeRecibido1.MostrarMensaje();
    }

    protected void rbComun_CheckedChanged(object sender, EventArgs e)
    {
        txtFecha.Text = "";
        rbPrivado.Checked = false;
        List<Mensaje> MComun = (from unRegistro in (List<Mensaje>)Session["MensajeRecibido"]
                                                     where unRegistro is MensajeComun
                                                     select unRegistro).ToList<Mensaje>();
        gvEntrada.DataSource = MComun;
        gvEntrada.DataBind();

        Session["Filtrados"] = MComun;

        ddlTipo.Enabled = true;     
    }

    protected void rbPrivado_CheckedChanged(object sender, EventArgs e)
    {
        txtFecha.Text = "";
        ddlTipo.Enabled = false;
        rbComun.Checked = false;

        List<Mensaje> MPrivado = (from unRegistro in (List<Mensaje>)Session["MensajeRecibido"]
                      where unRegistro is MensajePrivado
                      select unRegistro).ToList<Mensaje>();

        gvEntrada.DataSource = MPrivado;
        gvEntrada.DataBind();

        Session["Filtrados"] = MPrivado;
        ddlTipo.Enabled = false;
    }

    protected void CargoDdl()
    {
        ddlTipo.DataSource = Logica.FabricaLogica.GetLogicaTipo().Listo();
        ddlTipo.DataTextField = "Nombre";
        ddlTipo.DataValueField = "Codigo";
        ddlTipo.DataBind();
    }

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
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

        gvEntrada.DataSource = MensajeFiltrado;
        gvEntrada.DataBind();

        Session["FiltradosMC"] = MensajeFiltrado;
        txtFecha.Text = "";
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
    }
    protected void Limpio()
    {
        rbPrivado.Checked = false;
        rbComun.Checked = false;
        MensajesRecibido();
        lblError.Text = "";
        MensajeRecibido1.LimpiarUsserRecibido();
        Session["MensajeSeleccionado"] = null;
        gvEntrada.SelectedIndex = -1;
        ddlTipo.Enabled = false;
        txtFecha.Text = "";
    }
}