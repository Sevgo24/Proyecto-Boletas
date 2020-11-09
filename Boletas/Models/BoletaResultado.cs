using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletas.Models
{
    public class BoletaResultado
    {
        public string COD { get; set; }
        public string SOCIO { get; set; }
        public string DNI { get; set; }//
        public string RUC { get; set; }//
        public string PERIODO { get; set; }
        public string REPARTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string MEMO { get; set; }
        public string FECHALIQ { get; set; }
        public string SOCIO_INTERNO { get; set; }
        public string IMPORTE { get; set; }
        public string SUNAT { get; set; }
        public string JUDICIAL { get; set; }
        public string ONI { get; set; }
        public string EXC { get; set; }
        public string PEGA { get; set; }
        public string PORDIAR { get; set; }
        public string ADELANTO { get; set; }
        public string TOTAL { get; set; }
        public string CODIGO { get; set; }
        public string TIPO { get; set; } //se agregó este campo
    }
}