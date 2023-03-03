using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Arrendamientos
{
    public partial class AdminEstados : System.Web.UI.Page
    {
        protected void Refrescaagrid(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select Estado,id,activo from arrendamientos_Estados";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 2000;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                List<EstadosVo> dat = new List<EstadosVo>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat.Add(new EstadosVo(dr));

                }
                Grida.DataSource = dat;
                Grida.DataBind();
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
                Refrescaagrid(sender, e);
            }
        }
        protected void Comandos(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string id = Grida.DataKeys[index].Values["Id"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "delete from arrendamientos_Estados WHERE id='" + id + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            txtNumero.Text = "";
            Refrescaagrid(sender, e);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "delete from arrendamientos_Estados WHERE Estado='" + txtNumero.Text + "';INSERT INTO arrendamientos_Estados(Estado,activo)VALUES('" + txtNumero.Text + "','1')";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                txtNumero.Text = "";
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            Refrescaagrid(sender, e);
        }
    }
}