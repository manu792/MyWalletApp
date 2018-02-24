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
    public class GastoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public double? Monto { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un servicio de la lista de servicios")]
        public int ServicioId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }
        [DisplayName("Servicio")]
        public IEnumerable<SelectListItem> ServiciosDisponibles { get; set; }
    }
}