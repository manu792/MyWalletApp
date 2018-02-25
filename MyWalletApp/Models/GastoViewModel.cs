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
        public GastoDto Gasto { get; set; }
        [DisplayName("Servicio")]
        public IEnumerable<SelectListItem> ServiciosDisponibles { get; set; }
    }
}