using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWalletApp.Models
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre Servicio")]
        public string Nombre { get; set; }
        [DisplayName("Fecha de pago")]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public string FechaPago { get; set; }
    }
}