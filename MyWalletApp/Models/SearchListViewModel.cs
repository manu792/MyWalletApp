using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Models
{
    public class SearchListViewModel
    {
        public IEnumerable<IngresoDto> Ingresos { get; set; }
        [DisplayName("Desde")]
        public DateTime? FechaDesde { get; set; }
        [DisplayName("Hasta")]
        public DateTime? FechaHasta { get; set; }
        public int FuenteId { get; set; }
        [DisplayName("Fuente")]
        public IEnumerable<SelectListItem> FuentesDisponibles { get; set; }
    }
}