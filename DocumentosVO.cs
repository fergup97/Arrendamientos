
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Arrendamientos
{
    public class DocumentosVO
    {
        string _URL;

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        string _Detalles;

        public string Detalles
        {
            get { return _Detalles; }
            set { _Detalles = value; }
        }
        string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public DocumentosVO()
        {
        }
        public DocumentosVO(DataRow dr)
        {
            URL = dr["Doc"].ToString();
            Detalles = System.IO.Path.GetFileName(URL);
            Id = dr["IdDoc"].ToString();
        }
    }
}