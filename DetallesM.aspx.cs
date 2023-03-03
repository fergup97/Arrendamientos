using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Arrendamientos
{
    public partial class DetallesM : System.Web.UI.Page
    {
        public static List<string> CompletarMoneda(string prefixText, int count)
        {
            string Texto = prefixText;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "SELECT moneda,id FROM Arrendamientos_Monedas where id!='0' ";
                SqlCommand com = new SqlCommand();
                if (Texto != "*")
                {
                    com.CommandText = Query + " and moneda like '%'+@Search+'%';";
                    com.Parameters.AddWithValue("@Search", Texto);
                }
                else
                {
                    com.CommandText = Query + ";";
                }
                com.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                List<string> Nombre = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Nombre.Add(sdr[0].ToString().Trim());
                    }
                }
                if (Nombre.Count == 0) { Nombre.Add("No hay coicidencias"); }
                return Nombre;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> CompletarArrendadora(string prefixText, int count)
        {
            string Texto = prefixText;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "select Arrendadora,id,activado from arrendamientos_Arrendadoras where activado='1' ";
                SqlCommand com = new SqlCommand();
                if (Texto != "*")
                {
                    com.CommandText = Query + " and Arrendadora like '%'+@Search+'%';";
                    com.Parameters.AddWithValue("@Search", Texto);
                }
                else
                {
                    com.CommandText = Query + ";";
                }
                com.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                List<string> Nombre = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Nombre.Add(sdr[0].ToString().Trim());
                    }
                }
                if (Nombre.Count == 0) { Nombre.Add("No hay coicidencias"); }
                return Nombre;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> CompletarEmpresa(string prefixText, int count)
        {
            string Texto = prefixText;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "select Empresa,id,activado from arrendamientos_Empresas where activado='1' ";
                SqlCommand com = new SqlCommand();
                if (Texto != "*")
                {
                    com.CommandText = Query + " and Empresa like '%'+@Search+'%';";
                    com.Parameters.AddWithValue("@Search", Texto);
                }
                else
                {
                    com.CommandText = Query + ";";
                }
                com.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                List<string> Nombre = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Nombre.Add(sdr[0].ToString().Trim());
                    }
                }
                if (Nombre.Count == 0) { Nombre.Add("No hay coicidencias"); }
                return Nombre;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> CompletarEstado(string prefixText, int count)
        {
            string Texto = prefixText;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "select Estado,id,activo from arrendamientos_Estados where activo='1' ";
                SqlCommand com = new SqlCommand();
                if (Texto != "*")
                {
                    com.CommandText = Query + " and Estado like '%'+@Search+'%';";
                    com.Parameters.AddWithValue("@Search", Texto);
                }
                else
                {
                    com.CommandText = Query + ";";
                }
                com.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                List<string> Nombre = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Nombre.Add(sdr[0].ToString().Trim());
                    }
                }
                if (Nombre.Count == 0) { Nombre.Add("No hay coicidencias"); }
                return Nombre;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> CompletarProveerdor(string prefixText, int count)
        {
            string Texto = prefixText;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "select Proveerdor,id,activo from arrendamientos_Proveedores where activo='1' ";
                SqlCommand com = new SqlCommand();
                if (Texto != "*")
                {
                    com.CommandText = Query + " and Proveerdor like '%'+@Search+'%';";
                    com.Parameters.AddWithValue("@Search", Texto);
                }
                else
                {
                    com.CommandText = Query + ";";
                }
                com.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                List<string> Nombre = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Nombre.Add(sdr[0].ToString().Trim());
                    }
                }
                if (Nombre.Count == 0) { Nombre.Add("No hay coicidencias"); }
                return Nombre;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDlMoneda.Items.Add("");
               SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
                try
                {
                    string Query = "SELECT moneda,id FROM Arrendamientos_Monedas where id!='0' ";
                    SqlCommand com = new SqlCommand();
                    com.CommandText = Query + ";";
                    com.Connection = conn;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    List<string> Nombre = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DDlMoneda.Items.Add(sdr[0].ToString().Trim());
                        }
                    }

                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
                ddlEstatus.Items.Add("(PR) PROCESO");
                ddlEstatus.Items.Add("(CD) CERRADO");

                txtNumero.Enabled = true;
                
                txtArrendadora.Enabled = true;
                txtEquipo.Enabled = false;
                txtProveedor.Enabled = true;
                
                
                
                txtEstado.Enabled = false;
                txtResponsable.Enabled = true;
                ddlEstatus.Enabled = false;
                
                txtFechaRequisicion.Enabled = false;
                txtFechaOrden.Enabled = true;
                txtOrden.Enabled = true;
                txtRequisicion.Enabled = false;

                ArrendamientosVO arr = new ArrendamientosVO();
                try
                {
                    arr = ArrendamientosDAL.Arrendamiento(Request.QueryString["id"]);
                    GridaDocumetos.DataSource = ArrendamientosDAL.ListaDocs(Request.QueryString["id"]);
                    GridaDocumetos.DataBind();
                }
                catch
                {
                    Response.Redirect("/Lista.aspx");
                }
                txtNumero.Text = arr.Numero;
                txtEmpresa.Text = arr.Empresa;
                txtArrendadora.Text = arr.Arrendadora;
                txtEquipo.Text = arr.Equipo;
                txtProveedor.Text = arr.Proveedor;
                txtCondiciones.Text = arr.CondicionesDePago;
                txtMonto.Text = arr.Monto;
                DDlMoneda.SelectedValue = arr.Moneda;
                txtEstado.Text = arr.Estado;
                txtResponsable.Text = arr.Responsable;
                ddlEstatus.SelectedValue = arr.Estatus;
                lblComentarios.Text = arr.Comentarios;
                txtFechaRequisicion.Text=arr.FechaRequisicion;
                txtFechaOrden.Text=arr.FechaOrdenDeCompra;
                txtOrden.Text=arr.OrdenDeCompra;
                txtRequisicion.Text=arr.Numeroderequesicion;
                txtFechaColocacion.Text = arr.Fechadecolocacion;
                txtPlazo.Text = arr.Plazodeentrega;
                txtPlazo.Enabled = false;
                txtFechaColocacion.Enabled = false;
                string Usuario1 = Session["Usuario"].ToString();
                string Tipo = ArrendamientosDAL.TipoUsuario(Usuario1);
                if (Tipo == "Estado")
                {
                    txtEstado.Enabled = true;
                }
                if (Tipo == "Tesoreria")
                {
                    ddlEstatus.Enabled = true;
                }
                if (Tipo == "Admin")
                {
                    txtEstado.Enabled = true;
                    ddlEstatus.Enabled = true;
                }

            }
        }

        protected void btnSubirDoc_Click(object sender, EventArgs e)
        {
            if (fuDocumeto.HasFile == true)
            {
                DocumentosVO doc1 = new DocumentosVO();
                string PathDir = Server.MapPath("~/Documentos/");
                if (!Directory.Exists(PathDir))
                {
                    Directory.CreateDirectory(PathDir);
                }
                fuDocumeto.SaveAs(PathDir + fuDocumeto.FileName);
                doc1.URL = "/Documentos/" + fuDocumeto.FileName;
                doc1.Detalles = fuDocumeto.FileName;
                ArrendamientosDAL.AgregarDoc(doc1.URL, Request.QueryString["id"]);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string Numero = txtNumero.Text;
            string Empresa = txtEmpresa.Text;
            string Arrendadora = txtArrendadora.Text;
            string Equipo = txtEquipo.Text;
            string Proveedor = txtProveedor.Text;
            string CondicionesDePago = txtCondiciones.Text;
            string Monto = txtMonto.Text;
            string Moneda = DDlMoneda.SelectedValue;
            string Estado = txtEstado.Text;
            string Responsable = txtResponsable.Text;
            string Estatus = ddlEstatus.SelectedValue;
            string Comentarios =lblComentarios.Text+"  " +txtComentarios.Text;
            string FechaRequisicion = txtFechaRequisicion.Text;
            string FechaOrdenDeCompra = txtFechaOrden.Text;
            string OrdenDeCompra = txtOrden.Text;
            string Numeroderequesicion = txtRequisicion.Text;
            ArrendamientosDAL.ModiFicar(Numero, Empresa, Arrendadora, Equipo, Proveedor, CondicionesDePago, Monto, Moneda, Estado, Responsable, Estatus, Comentarios, Request.QueryString["id"], FechaRequisicion, FechaOrdenDeCompra, OrdenDeCompra, Numeroderequesicion);
            Response.Redirect("/Lista.aspx");
        }
        protected void Comandos(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string id = GridaDocumetos.DataKeys[index].Values["Id"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "delete from arrendamientos_docs WHERE iddoc='" + id + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            
            GridaDocumetos.DataSource = ArrendamientosDAL.ListaDocs(Request.QueryString["id"]);
            GridaDocumetos.DataBind();
        }
    }
} 