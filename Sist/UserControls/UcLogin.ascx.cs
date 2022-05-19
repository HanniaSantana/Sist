using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace Sist.UserControls
{
    public partial class UcLogin : System.Web.UI.UserControl
    {
        EntityAcciones ef = new EntityAcciones();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            Usuarios u = ef.Obtener<Usuarios>().Where(x => x.Correo == usuario && x.Contraseña == contraseña).FirstOrDefault();

            if (u != null)
            {
                Session["usuario"] = u;
                if (u.RolId == 1)
                {
                    Response.Redirect("/Admin/Admin.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "failUser", "alert('¡usuario y/o contraseña incorrectos!');", true);
            }
        }
    }
}