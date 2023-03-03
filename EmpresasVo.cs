using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Arrendamientos
{
    public class EmpresasVo
    {
        string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        string _Valor;

        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        public EmpresasVo()
        {
        }
        public EmpresasVo(DataRow dr)
        {
            Id = dr["Id"].ToString();
            Valor = dr["Empresa"].ToString();
        }
    }
}