using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace Arrendamientos
{
    public partial class Lista : System.Web.UI.Page
    {
        public static void EnviarCorreo(string Mensaje, string De, string Para, string Asunto)
        {

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(Para));
            email.From = new MailAddress(De);
            email.Subject = Asunto;
            email.Body = Mensaje;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "172.20.4.124";
            smtp.Port = 587;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("invekra\\web.serv", "11913M1crodacyhnCr34d0r100)(/&");

            try
            {
                smtp.Send(email);
                email.Dispose();
                Console.WriteLine("Correo enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        protected void Comandos(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string id = Grida.DataKeys[index].Values["Id"].ToString();
            string Usuario = Grida.DataKeys[index].Values["Usuario"].ToString();
            string Estatus = Grida.DataKeys[index].Values["Estatus"].ToString();
            string Usuario1 = Session["Usuario"].ToString();
            string Tipo = ArrendamientosDAL.TipoUsuario(Usuario1);
            if (e.CommandName == "Dele")
            {
                EnviarCorreo("Se solicita la eliminacion del arrendamiento " + id + " por el usuario" + Usuario1, "web.serv@corex.com.mx", "jorge.juarez@corex.com.mx", "Borrar Arrendamiento");
                //ArrendamientosDAL.BorrarArrendamiento(id);
            }
            else
            {
                if (Tipo == "Estado" || Tipo == "Tesoreria" || Tipo == "Admin")
                {
                    if (Estatus == "(CD) CERRADO")
                    {
                        Response.Redirect("/Detalles.aspx?id=" + id);
                    }
                    else
                    {
                        Response.Redirect("/DetallesM.aspx?id=" + id);
                    }
                }
                else
                {
                    Response.Redirect("/Detalles.aspx?id=" + id);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstatus.Items.Add("");
                ddlEstatus.Items.Add("Proceso");
                ddlEstatus.Items.Add("Cerrado");
                string Numero = "";
                string Empresa = "";
                string Arrendadora = "";
                string Equipo = "";
                string Proveedor = "";
                string Condicionesdepago = "";
                string Estatus = "";
                Grida.DataSource = ArrendamientosDAL.ListaPaso2(Numero, Empresa, Arrendadora, Equipo, Proveedor, Condicionesdepago, Estatus);
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