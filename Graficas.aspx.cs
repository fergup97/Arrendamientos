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
    public partial class Graficas : System.Web.UI.Page
    {
        private void GraficasMetodo(Dictionary<string, int> Dicci, string tipo, string Titulo)
        {
            cargarCanvas.Controls.Clear();
            if ((tipo.Equals("column")) || (tipo.Equals("bar")) || (tipo.Equals("line")) || (tipo.Equals("area")) || (tipo.Equals("spline")) || (tipo.Equals("scatter")) || (tipo.Equals("stepLine")))
            {
                cargarCanvas.Controls.Add(new LiteralControl("<script type='text/javascript'>"));
                cargarCanvas.Controls.Add(new LiteralControl("window.onload = function () {"));
                cargarCanvas.Controls.Add(new LiteralControl("var chart = new CanvasJS.Chart('chartContainer',"));
                cargarCanvas.Controls.Add(new LiteralControl("{"));
                cargarCanvas.Controls.Add(new LiteralControl("title: {"));
                cargarCanvas.Controls.Add(new LiteralControl("text: '" + Titulo + "'"));
                cargarCanvas.Controls.Add(new LiteralControl("},exportFileName: 'CanvasJS Chart',exportEnabled: true,animationEnabled: true,animationDuration: 1500,"));
                cargarCanvas.Controls.Add(new LiteralControl("data: ["));
                cargarCanvas.Controls.Add(new LiteralControl("{"));
                cargarCanvas.Controls.Add(new LiteralControl("type: '" + tipo + "',"));
                cargarCanvas.Controls.Add(new LiteralControl("dataPoints: ["));
                foreach (var item in Dicci)
                {
                    cargarCanvas.Controls.Add(new LiteralControl("{  y: " + item.Value + ", label: '" + item.Key + "' },"));
                }
                cargarCanvas.Controls.Add(new LiteralControl("]"));
                cargarCanvas.Controls.Add(new LiteralControl("}"));
                cargarCanvas.Controls.Add(new LiteralControl("]"));
                cargarCanvas.Controls.Add(new LiteralControl("});"));
                cargarCanvas.Controls.Add(new LiteralControl("chart.render();"));
                cargarCanvas.Controls.Add(new LiteralControl("}"));
                cargarCanvas.Controls.Add(new LiteralControl("</script>"));
            }
            else
            {
                if ((tipo.Equals("pie")) || (tipo.Equals("doughnut")))
                {
                    cargarCanvas.Controls.Add(new LiteralControl("<script type='text/javascript'>"));
                    cargarCanvas.Controls.Add(new LiteralControl("window.onload = function () {"));
                    cargarCanvas.Controls.Add(new LiteralControl("var chart = new CanvasJS.Chart('chartContainer',"));
                    cargarCanvas.Controls.Add(new LiteralControl("{"));
                    cargarCanvas.Controls.Add(new LiteralControl("theme: 'theme2',"));
                    cargarCanvas.Controls.Add(new LiteralControl("title:{"));
                    cargarCanvas.Controls.Add(new LiteralControl("text: '" + Titulo + "'},exportFileName: 'CanvasJS Chart',exportEnabled: true,animationEnabled: true,animationDuration: 1500,"));
                    cargarCanvas.Controls.Add(new LiteralControl("data: ["));
                    cargarCanvas.Controls.Add(new LiteralControl("{"));
                    cargarCanvas.Controls.Add(new LiteralControl("type: '" + tipo + "',"));
                    cargarCanvas.Controls.Add(new LiteralControl("showInLegend: false,"));
                    cargarCanvas.Controls.Add(new LiteralControl("toolTipContent: '{indexLabel}: {y} - #percent %',"));
                    cargarCanvas.Controls.Add(new LiteralControl("legendText: '{indexLabel}',"));
                    cargarCanvas.Controls.Add(new LiteralControl("dataPoints: ["));
                    foreach (var item in Dicci)
                    {
                        string Lab = item.Key;
                        int val = item.Value;
                        if (Lab.Equals("") || Lab == null) Lab = "Desconocido";
                        cargarCanvas.Controls.Add(new LiteralControl("{ y: " + val + ", indexLabel: '" + Lab + "' },"));
                    }
                    cargarCanvas.Controls.Add(new LiteralControl("]"));
                    cargarCanvas.Controls.Add(new LiteralControl("}"));
                    cargarCanvas.Controls.Add(new LiteralControl("]"));
                    cargarCanvas.Controls.Add(new LiteralControl("});"));
                    cargarCanvas.Controls.Add(new LiteralControl("chart.render();"));
                    cargarCanvas.Controls.Add(new LiteralControl("}"));
                    cargarCanvas.Controls.Add(new LiteralControl("</script>"));
                }
            }
        }
        protected void Graficar(object sender, EventArgs e)
        {
            Session["Agraficar"] = ddlAgraficar.SelectedValue;
            Dictionary<string, int> Dicci = new Dictionary<string, int>();
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                string Query = "select "+ddlAgraficar.SelectedValue+ ",COUNT(" + ddlAgraficar.SelectedValue + ") from Arrendamientos_Registro group by " + ddlAgraficar.SelectedValue + "";
                SqlCommand cmd1 = new SqlCommand(Query, conn1);
                cmd1.Connection = conn1;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                DataSet dsCobros = new DataSet();
                adapter.Fill(dsCobros);
                int i = 1;
                foreach (DataRow dr in dsCobros.Tables[0].Rows)
                {
                    if (dr[0].ToString() == "")
                    {
                        //Dicci.Add("Sin Valor", int.Parse(dr["num"].ToString()));
                    }
                    else
                    {
                        Dicci.Add(dr[0].ToString(), int.Parse(dr[1].ToString()));
                    }
                    i = i + 1;
                }

            }
            catch { throw; }
            finally { conn1.Close(); }
            string Tipo = DDLTipo.SelectedValue;
            if (Tipo.Equals("Lineal")) { Tipo = "line"; }
            if (Tipo.Equals("Barras")) { Tipo = "bar"; }
            if (Tipo.Equals("Columnas")) { Tipo = "column"; }
            if (Tipo.Equals("Area")) { Tipo = "area"; }
            if (Tipo.Equals("Lineal Curva")) { Tipo = "spline"; }
            if (Tipo.Equals("Dispersion")) { Tipo = "scatter"; }
            if (Tipo.Equals("Circular")) { Tipo = "pie"; }
            if (Tipo.Equals("Lineal Cuadrada")) { Tipo = "stepLine"; }
            if (Tipo.Equals("Dona")) { Tipo = "doughnut"; }
            GraficasMetodo(Dicci, Tipo, ddlAgraficar.SelectedItem.Text);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLTipo.Items.Add("Lineal");
                DDLTipo.Items.Add("Barras");
                DDLTipo.Items.Add("Columnas");
                DDLTipo.Items.Add("Area");
                DDLTipo.Items.Add("Dispersion");
                DDLTipo.Items.Add("Circular");
                DDLTipo.Items.Add("Dona");
                DDLTipo.Items.Add("Lineal Curva");
                DDLTipo.Items.Add("Lineal Cuadrada");
                DDLTipo.SelectedValue = "Circular";
                Graficar(sender, e);
            }
        }
    }
}