using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Models
{
    public class Comparativa : Searchable
    {
        public IEnumerable<IngresoDto> Ingresos { get; set; }
        public IEnumerable<GastoDto> Gastos { get; set; }
        public double Total { get; set; }
    }
}