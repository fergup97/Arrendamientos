using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Arrendamientos
{
    public class ArrendamientosDAL
    {
        public static void BorrarArrendamiento(string ID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "delete from Arrendamientos_Registro where id='" + ID + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        public static int AgregarArrendamiento(string Numero, string Empresa, string Arrendadora, string Equipo, string Proveedor, string CondicionesDePago, string Monto, string Moneda, string Estado, string Responsable, string Estatus, string Comentarios, string Fecha, string Usuario, string FechaRequisicion, string FechaOrdenDeCompra, string OrdenDeCompra, string Numeroderequesicion, string Fechadecolocacion, string Plazodeentrega)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "INSERT INTO Arrendamientos_Registro(Numero,Empresa,Arrendadora,Equipo,Proveedor,CondicionesDePago,Monto,Moneda,Estado,Responsable,Estatus,Comentarios,Fecha,Usuario,FechaRequisicion,FechaOrdenDeCompra,OrdenDeCompra,Numeroderequesicion,Fechadecolocacion,Plazodeentrega)VALUES('" + Numero + "','" + Empresa + "','" + Arrendadora + "','" + Equipo + "','" + Proveedor + "','" + CondicionesDePago + "','" + Monto + "','" + Moneda + "','" + Estado + "','" + Responsable + "','" + Estatus + "','" + Comentarios + "','" + Fecha + "','" + Usuario + "','" + FechaRequisicion + "','" + FechaOrdenDeCompra + "','" + OrdenDeCompra + "','" + Numeroderequesicion + "','" + Fechadecolocacion + "','" + Plazodeentrega + "');select CAST (SCOPE_IDENTITY() As int);";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        public static void AgregarDoc(string Doc, string idArrendamiento)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "INSERT INTO Arrendamientos_Docs(Doc,idArrendamiento)VALUES('" + Doc + "','" + idArrendamiento + "')";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        public static void ModiFicar(string Numero, string Empresa, string Arrendadora, string Equipo, string Proveedor, string CondicionesDePago, string Monto, string Moneda, string Estado, string Responsable, string Estatus, string Comentarios, string Id, string FechaRequisicion, string FechaOrdenDeCompra, string OrdenDeCompra, string Numeroderequesicion)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string Query = "UPDATE Arrendamientos_Registro SET Numero = '" + Numero + "',Empresa = '" + Empresa + "',Arrendadora = '" + Arrendadora + "',Equipo = '" + Equipo + "',Proveedor = '" + Proveedor + "',CondicionesDePago = '" + CondicionesDePago + "',Monto = '" + Monto + "',Moneda = '" + Moneda + "',Estado = '" + Estado + "',Responsable = '" + Responsable + "',Estatus = '" + Estatus + "',Comentarios = '" + Comentarios + "',FechaRequisicion='" + FechaRequisicion + "',FechaOrdenDeCompra='" + FechaOrdenDeCompra + "',OrdenDeCompra='" + OrdenDeCompra + "',Numeroderequesicion='" + Numeroderequesicion + "' WHERE Id='" + Id + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        public static List<ArrendamientosVO> ListaPaso2(string Numero, string Empresa, string Arrendadora, string Equipo, string Proveedor, string Condicionesdepago, string Estatus)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select * from Arrendamientos_Registro where id!=0";
            if (Numero != "") Q = Q + " and Numero like '%" + Numero + "%'";

            if (Empresa != "") Q = Q + " and Empresa like '%" + Empresa + "%'";
            if (Arrendadora != "") Q = Q + " and Arrendadora like '%" + Arrendadora + "%'";
            if (Equipo != "") Q = Q + " and Equipo like '%" + Equipo + "%'";
            if (Proveedor != "") Q = Q + " and Proveedor like '%" + Proveedor + "%'";
            if (Condicionesdepago != "") Q = Q + " and Condicionesdepago like '%" + Condicionesdepago + "%'";
            if (Estatus != "") Q = Q + " and Estatus like '%" + Estatus + "%'";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 200;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                List<ArrendamientosVO> dat = new List<ArrendamientosVO>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat.Add(new ArrendamientosVO(dr));

                }
                return dat;
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
        public static List<DocumentosVO> ListaDocs(string id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select * from Arrendamientos_docs where idArrendamiento='" + id + "' order by Doc";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 200;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                List<DocumentosVO> dat = new List<DocumentosVO>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat.Add(new DocumentosVO(dr));

                }
                return dat;
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
        public static ArrendamientosVO Arrendamiento(string id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select distinct * from Arrendamientos_Registro where id='" + id + "'";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 201110;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ArrendamientosVO dat = new ArrendamientosVO();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat = (new ArrendamientosVO(dr));

                }
                return dat;
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
        public static string TipoUsuario(string Usuario)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select Tipo from Arrendamientos_Usuarios where usuario='" + Usuario + "'";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 201110;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                string dat = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat = dr["Tipo"].ToString();

                }
                return dat;
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
        public static int UsuarioCorrecto(string Usuario, string contra)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            string Q = "select * from Arrendamirntos_UsuariosExt where usuario='" + Usuario + "' and contra='" + contra + "'";
            try
            {
                string Query = Q;
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                cmd.CommandTimeout = 201110;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                int dat = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dat = dat + 1;

                }
                return dat;
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
}