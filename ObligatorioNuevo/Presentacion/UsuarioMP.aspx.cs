using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using Persistencia;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Limpio();
        }
    }

    void Limpio()
    {
        CargarDatos();     
        txtUsuario.Enabled = false;
        lblError.Text = "";
    }

    void CargarDatos()
    {
        Usuario usu = (Usuario)Session["Usuario"];
        txtUsuario.Text = usu.NombreUsuario;
        txtPassword.Text = usu.Password;
        txtMail.Text = usu.Mail;
        txtNomCompleto.Text = usu.NomCompleto;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario UnUsu = (Usuario)Session["Usuario"];
            UnUsu.Password = txtPassword.Text;
            UnUsu.NomCompleto = txtNomCompleto.Text;
            UnUsu.Mail = txtMail.Text;
            Session["Usuario"] = UnUsu;

            FabricaLogica.GetLogicaUsuario().Modificar(UnUsu);
            lblError.Text = "El Usuairo se modifico correctamente.";
            CargarDatos();
            
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario UnUsu = (Usuario)Session["Usuario"];
            FabricaLogica.GetLogicaUsuario().Eliminar(UnUsu);
            Session["Usuario"] = null;
            Limpio();
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
    }
}