using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class ServicioDto
    {
        public int Id { get; set; }
        [DisplayName("Nombre Servicio")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public double Monto { get; set; }
        [DisplayName("Fecha de pago")]
        [Required(ErrorMessage = "El campo Fecha de pago es requerido")]
        public string FechaPago { get; set; }
        [DisplayName("Tipo de Pago")]
        [Required(ErrorMessage = "El campo Tipo de pago es requerido")]
        public bool EsPorMes { get; set; }
    }
}
