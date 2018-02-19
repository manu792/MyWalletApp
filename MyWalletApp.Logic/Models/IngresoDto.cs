using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class IngresoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public double Monto { get; set; }
        [Required(ErrorMessage = "El campo Fuente es requerido")]
        public FuenteDto Fuente { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }
    }
}
