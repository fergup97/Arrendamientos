using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace Arrendamientos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Usuario"] = null;
                Session["Pass"] = null;
            }
        }
        public bool estaAutenticado(string dominio, string usuario, string pwd, string path)
        {
            string domainAndUsername = dominio + @"\" + usuario;
            DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, pwd);
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                SearchResult result = search.FindOne();
                string NumeroEmpleado = result.Properties["EmployeeID"].ToString();
                string Mail = result.Properties["Mail"].ToString();
                string Nombre = result.Properties["Name"].ToString();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string Usuario = txtUsuario.Value;
                string Pass = txtPass.Value;
                //if (DAL.DatosDAL.revisarusua(Usuario,Pass)!=0)
                if (ArrendamientosDAL.UsuarioCorrecto(Usuario,Pass)!=0)
                {

                    Session["Usuario"] = Usuario;
                    Session["Pass"] = Pass;

                    Response.Redirect("/", false);

                }
                else
                {
                    string dominio = "invekra";
                    string path = "LDAP://invekra";
                    bool Aut = estaAutenticado(dominio, Usuario, Pass, path);
                    if (Aut)
                    {

                        Session["Usuario"] = Usuario;
                        Session["Pass"] = Pass;
                        try
                        {
                            Response.Redirect("/");
                        }
                        catch
                        {
                            Response.Redirect("/");
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
        }
    }
}