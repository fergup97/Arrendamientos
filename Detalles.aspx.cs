using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arrendamientos
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstatus.Items.Add("Pagado");
                ddlEstatus.Items.Add("No Pagado");
            }
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
            txtMoneda.Text = arr.Moneda;
            txtEstado.Text = arr.Estado;
            txtResponsable.Text = arr.Responsable;
            ddlEstatus.SelectedValue = arr.Estatus;
            txtComentarios.Text = arr.Comentarios;
            txtFechaRequisicion.Text = arr.FechaRequisicion;
            txtFechaOrden.Text = arr.FechaOrdenDeCompra;
            txtOrden.Text = arr.OrdenDeCompra;
            txtRequisicion.Text = arr.Numeroderequesicion;
            txtFechaColocacion.Text = arr.Fechadecolocacion;
            txtPlazo.Text = arr.Plazodeentrega;
            txtPlazo.Enabled = false;
            txtFechaColocacion.Enabled = false;
            txtNumero.Enabled = false;
            txtEmpresa.Enabled = false;
            txtArrendadora.Enabled = false;
            txtEquipo.Enabled = false;
            txtProveedor.Enabled = false;
            txtCondiciones.Enabled = false;
            txtMonto.Enabled = false;
            txtMoneda.Enabled = false;
            txtEstado.Enabled = false;
            txtResponsable.Enabled = false;
            ddlEstatus.Enabled = false;
            txtComentarios.Enabled = false;
            txtFechaRequisicion.Enabled = false;
            txtFechaOrden.Enabled = false;
            txtOrden.Enabled = false;
            txtRequisicion.Enabled = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Lista.aspx");
        }
    }
}