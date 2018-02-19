using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class GastoDto
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public ServicioDto Servicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }
    }
}
