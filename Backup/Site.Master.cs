using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arrendamientos
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Session["Usuario"].ToString();
                string Tipo = ArrendamientosDAL.TipoUsuario(Session["Usuario"].ToString());
                if (Tipo == "Admin")
                {
                    liadmin.Visible = true;
                }
                else
                {
                    liadmin.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}
