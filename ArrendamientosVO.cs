using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Arrendamientos
{
    public class ArrendamientosVO
    {
        string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        string _Numero;

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        string _Empresa;

        public string Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }
        string _Arrendadora;

        public string Arrendadora
        {
            get { return _Arrendadora; }
            set { _Arrendadora = value; }
        }
        string _Equipo;

        public string Equipo
        {
            get { return _Equipo; }
            set { _Equipo = value; }
        }
        string _Proveedor;

        public string Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }
        string _CondicionesDePago;

        public string CondicionesDePago
        {
            get { return _CondicionesDePago; }
            set { _CondicionesDePago = value; }
        }
        string _Monto;

        public string Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        string _Moneda;

        public string Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }
        string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        string _Responsable;

        public string Responsable
        {
            get { return _Responsable; }
            set { _Responsable = value; }
        }
        string _Estatus;

        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        string _Comentarios;

        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }
        string _Fecha;

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        string _FechaRequisicion;

        public string FechaRequisicion
        {
            get { return _FechaRequisicion; }
            set { _FechaRequisicion = value; }
        }
        string _FechaOrdenDeCompra;

        public string FechaOrdenDeCompra
        {
            get { return _FechaOrdenDeCompra; }
            set { _FechaOrdenDeCompra = value; }
        }
        string _OrdenDeCompra;

        public string OrdenDeCompra
        {
            get { return _OrdenDeCompra; }
            set { _OrdenDeCompra = value; }
        }
        string _Numeroderequesicion;

        public string Numeroderequesicion
        {
            get { return _Numeroderequesicion; }
            set { _Numeroderequesicion = value; }
        }
        string _Fechadecolocacion;

        public string Fechadecolocacion
        {
            get { return _Fechadecolocacion; }
            set { _Fechadecolocacion = value; }
        }
        string _Plazodeentrega;

        public string Plazodeentrega
        {
            get { return _Plazodeentrega; }
            set { _Plazodeentrega = value; }
        }
        public ArrendamientosVO()
        {

        }
        public ArrendamientosVO(DataRow dr)
        {
            Id = dr["Id"].ToString();
            Numero = dr["Numero"].ToString();
            Empresa = dr["Empresa"].ToString();
            Arrendadora = dr["Arrendadora"].ToString();
            Equipo = dr["Equipo"].ToString();
            Proveedor = dr["Proveedor"].ToString();
            CondicionesDePago = dr["CondicionesDePago"].ToString();
            Monto = dr["Monto"].ToString();
            Moneda = dr["Moneda"].ToString();
            Estado = dr["Estado"].ToString();
            Responsable = dr["Responsable"].ToString();
            Estatus = dr["Estatus"].ToString();
            Comentarios = dr["Comentarios"].ToString();
            Fecha = dr["Fecha"].ToString();
            Usuario = dr["Usuario"].ToString();

            FechaRequisicion = dr["FechaRequisicion"].ToString();
            FechaOrdenDeCompra = dr["FechaOrdenDeCompra"].ToString();
            OrdenDeCompra = dr["OrdenDeCompra"].ToString();
            Numeroderequesicion = dr["Numeroderequesicion"].ToString();
            Fechadecolocacion = dr["Fechadecolocacion"].ToString();
            Plazodeentrega = dr["Plazodeentrega"].ToString();
        }
    }
}