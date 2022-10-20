using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Data.SqlClient;
using System.Data;
using Logica;
using EntidadesCompartidas;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargoDatos();
            
            Limpio();                 
        }     
    }
    private void CargoDatos()
    {
        XmlDocument Doc = FabricaLogica.GetLogicaEstadisticas().Esta();

        System.Xml.Linq.XElement _documento = System.Xml.Linq.XElement.Parse(Doc.OuterXml);
        Session["Documento"] = _documento;

        var _elementos = (from UnM in _documento.Elements("Estadistica")
                          select new
                          {
                              Usu = UnM.Element("CantUsuariosActivos").Value,
                              MenC = UnM.Element("CantMensajesComunes").Value,
                              MenP = UnM.Element("CantMensajesPrivados").Value,
                          });


        foreach (var e in _elementos)
        {
            lblCantUsu.Text = "Cantidad de Usuarios: " + e.Usu;
            lblCantMensajesPriv.Text = "Cantidad Mensajes Privados: " + e.MenP;
            lblCantMensajesCom.Text = "Cantidad de Mensajes Comunes: " + e.MenC;
        }

        List<object> _resultado = (from UnM in _documento.Elements("Tipo")
                                   select new
                                   {
                                       Codigo = UnM.Element("Codigo").Value,
                                       Cantidad = UnM.Element("Cantidad").Value,
                                   }).ToList<object>();

        GVResultado.DataSource = _resultado;
        GVResultado.DataBind();    

    }

    private void Limpio()
    {
        txtContraseña.Text = "";
        txtUsuario.Text = "";
        lblError.Text = "";
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string LogUsuario = "";
        string Contraseña = "";
        try
        {
            LogUsuario = txtUsuario.Text;
            Contraseña = txtContraseña.Text;
            Usuario unUsu = FabricaLogica.GetLogicaUsuario().Logueo(LogUsuario, Contraseña);
            if (unUsu != null)
            {
                Session["Usuario"] = unUsu;
                Response.Redirect("PaginaPrincipal.aspx");
            }
            else
                lblError.Text = "Datos Incorrectos no tiene permiso para acceder al sitio";
        }
        catch
        {
            lblError.Text = "No existe el usuario ingresado";
            return;
        }
    }

    protected void lnkRegistrarse_Click(object sender, EventArgs e)
    {

    }
}