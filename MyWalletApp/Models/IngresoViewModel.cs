using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Models
{
    public class IngresoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public double? Monto { get; set; }
        [Required(ErrorMessage = "El campo Fuente es requerido")]
        public FuenteDto Fuente { get; set; }
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime? Fecha { get; set; }
        [DisplayName("Fuente")]
        public IEnumerable<SelectListItem> FuentesDisponibles { get; set; }
    }
}