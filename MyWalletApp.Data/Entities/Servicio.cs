using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        [DisplayName("Nombre Servicio")]
        public string Nombre { get; set; }
        public DateTime FechaPago { get; set; }
        [Required]
        public double Monto { get; set; }
        public bool EsPorMes { get; set; }
    }
}
