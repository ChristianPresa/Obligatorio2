using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var unUsu = (Usuario)Session["Usuario"];
            if (unUsu != null)
            {
                lblNombreLogueo.Text = unUsu.NombreUsuario;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btnDeloguear_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Usuario"] = null;
            Response.Redirect("Default.aspx");
        }
        catch
        {
            lblError.Text = "Error.";
        }
    }
}
