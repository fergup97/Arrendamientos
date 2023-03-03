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
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Comandos(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            List<DocumentosVO> lista = new List<DocumentosVO>();
            foreach (GridViewRow gvro1 in GridaDocumetos.Rows)
            {
                if (index != gvro1.RowIndex)
                {
                    DocumentosVO doc = new DocumentosVO();
                    doc.URL = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Url"].ToString();
                    doc.Detalles = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Detalles"].ToString();
                    lista.Add(doc);
                }
            }
            List<DocumentosVO> SortedList = lista.OrderBy(o => o.URL).ToList();
            GridaDocumetos.DataSource = SortedList;
            GridaDocumetos.DataBind();
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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstatus.Items.Add("(PR) PROCESO");
                ddlEstatus.Items.Add("(CD) CERRADO");

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
                try
                {
                    string Query = "select Estado,id,activo from arrendamientos_Estados";
                    SqlCommand com = new SqlCommand();
                    com.CommandText = Query + ";";
                    com.Connection = conn;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    List<string> Nombre = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ddlEstado.Items.Add(sdr[0].ToString().Trim());
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
            }
        }

        protected void btnSubirDoc_Click(object sender, EventArgs e)
        {
            List<DocumentosVO> lista = new List<DocumentosVO>();
            foreach (GridViewRow gvro1 in GridaDocumetos.Rows)
            {
                DocumentosVO doc = new DocumentosVO();
                doc.URL = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Url"].ToString();
                doc.Detalles = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Detalles"].ToString();
                lista.Add(doc);
            }
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
                lista.Add(doc1);
            }
            List<DocumentosVO> SortedList = lista.OrderBy(o => o.URL).ToList();
            GridaDocumetos.DataSource = SortedList;
            GridaDocumetos.DataBind();
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
            string Estado = ddlEstado.SelectedValue;
            string Responsable = txtResponsable.Text;
            string Estatus = ddlEstatus.SelectedValue;
            string Comentarios = txtComentarios.Text;
            string Fecha = DateTime.Now.ToString();
            string Usuario = Session["Usuario"].ToString(); ;
            string FechaRequisicion = txtFechaRequisicion.Text;
            string FechaOrdenDeCompra = txtFechaOrden.Text;
            string OrdenDeCompra = txtOrden.Text;
            string Numeroderequesicion = txtRequisicion.Text;
            int registro = ArrendamientosDAL.AgregarArrendamiento(Numero, Empresa, Arrendadora, Equipo, Proveedor, CondicionesDePago, Monto, Moneda, Estado, Responsable, Estatus, Comentarios, Fecha, Usuario, FechaRequisicion, FechaOrdenDeCompra, OrdenDeCompra, Numeroderequesicion,txtFechaColocacion.Text,txtPlazo.Text);
            foreach (GridViewRow gvro1 in GridaDocumetos.Rows)
            {
                DocumentosVO doc = new DocumentosVO();
                doc.URL = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Url"].ToString();
                doc.Detalles = GridaDocumetos.DataKeys[gvro1.RowIndex].Values["Detalles"].ToString();
                ArrendamientosDAL.AgregarDoc(doc.URL, registro.ToString());
            }
            Response.Redirect("/Lista.aspx");
        }

    }
}