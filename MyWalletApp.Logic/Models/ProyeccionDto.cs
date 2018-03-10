using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class ProyeccionDto
    {
        public double y { get; set; }
        public string fechaPago { get; set; }
        public bool esPorMes { get; set; }
        public string label { get; set; }
        public string indexLabel { get; set; }
        public int id { get; set; }
    }
}
