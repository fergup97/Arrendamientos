using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arrendamientos
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Comandos(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string id = Grida.DataKeys[index].Values["Id"].ToString();
            string Usuario = Grida.DataKeys[index].Values["Usuario"].ToString();
            string Usuario1 = Session["Usuario"].ToString();
            string Tipo = ArrendamientosDAL.TipoUsuario(Usuario1);
            if (Tipo == "Estado" || Tipo == "Tesoreria" || Tipo == "Admin")
            {
                Response.Redirect("/DetallesM.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("/Detalles.aspx?id=" + id);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstatus.Items.Add("");
                ddlEstatus.Items.Add("En proceso");
                ddlEstatus.Items.Add("Cerrado");
                string Numero = "";
                string Empresa = "";
                string Arrendadora = "";
                string Equipo = "";
                string Proveedor = "";
                string Condicionesdepago = "";
                string Estatus = "";
                Grida.DataSource = ArrendamientosDAL.ListaPaso2(Numero,Empresa, Arrendadora, Equipo, Proveedor, Condicionesdepago, Estatus);
                Grida.DataBind();
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            string Numero = txtNumero.Text;
            string Empresa = txtEmpresa.Text;
            string Arrendadora = txtArrendadora.Text;
            string Equipo = txtEquipo.Text;
            string Proveedor = txtProveedor.Text;
            string Condicionesdepago = txtCondiciones.Text;
            string Estatus = ddlEstatus.SelectedValue;
            Grida.DataSource = ArrendamientosDAL.ListaPaso2(Numero, Empresa, Arrendadora, Equipo, Proveedor, Condicionesdepago, Estatus);
            Grida.DataBind();
        }
    }
}