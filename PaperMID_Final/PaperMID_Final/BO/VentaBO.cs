using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID_Final.BO
{
    public class VentaBO
    {
        public int IdStatus { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaRegistroVent { get; set; }
        public int IdMetodoPago1 { get; set; }
        public int IdStatusVen1 { get; set; }
    }
}