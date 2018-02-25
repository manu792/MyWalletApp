using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Models
{
    public class IngresoViewModel
    {
        public IngresoDto Ingreso { get; set; }
        public IEnumerable<SelectListItem> FuentesDisponibles { get; set; }
    }
}