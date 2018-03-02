using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Models
{
    public class Searchable
    {
        [DisplayName("Desde")]
        public DateTime? FechaDesde { get; set; }
        [DisplayName("Hasta")]
        public DateTime? FechaHasta { get; set; }
    }

    public class SearchViewModel<T> : Searchable where T : ITransaction
    {
        //public IEnumerable<T> Transacciones { get; set; }
        //[DisplayName("Desde")]
        //public DateTime? FechaDesde { get; set; }
        //[DisplayName("Hasta")]
        //public DateTime? FechaHasta { get; set; }
        //public int FuenteId { get; set; }
        //public IEnumerable<SelectListItem> FuentesDisponibles { get; set; }
        public IEnumerable<T> Transacciones { get; set; }
        public int FuenteId { get; set; }
        [DisplayName("Fuentes")]
        public IEnumerable<SelectListItem> FuentesServiciosDisponibles { get; set; }
        [DisplayName("Pagos proximos")]
        public IEnumerable<ServicioDto> ProximosPagos { get; set; }
    }
}