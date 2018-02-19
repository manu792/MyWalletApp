using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class IngresoDto
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public FuenteDto Fuente { get; set; }
        public DateTime Fecha { get; set; }
    }
}
