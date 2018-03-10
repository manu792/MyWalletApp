using MyWalletApp.Logic;
using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class ComparativaController : Controller
    {
        private IngresoManager ingresoManager;
        private GastoManager gastoManager;
        private FuenteManager fuenteManager;
        private ServicioManager servicioManager;

        public ComparativaController()
        {
            ingresoManager = new IngresoManager();
            gastoManager = new GastoManager();
            fuenteManager = new FuenteManager();
            servicioManager = new ServicioManager();
        }

        // GET: Comparativa
        public ActionResult Index()
        {
            var ingresos = ingresoManager.GetIngresosByDateRange();
            var gastos = gastoManager.GetGastosByDateRange();


            return View(new Comparativa()
            {
                Ingresos = ingresos,
                Gastos = gastos,
                Total = ingresos.Sum(item => item.Monto) - gastos.Sum(item => item.Monto)
            });
        }

        // POST: Comparativa
        [HttpPost]
        public ActionResult Index(Comparativa comparativa)
        {
            if (string.IsNullOrEmpty(comparativa.FechaDesde))
                comparativa.FechaDesde = "01/01/1970";
            if (string.IsNullOrEmpty(comparativa.FechaHasta))
                comparativa.FechaHasta = DateTime.Now.ToString("dd/MM/yyyy");

            var ingresos = ingresoManager.GetIngresosByDateRange(DateTime.ParseExact(comparativa.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(comparativa.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            var gastos = gastoManager.GetGastosByDateRange(DateTime.ParseExact(comparativa.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(comparativa.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            return View(new Comparativa()
            {
                Ingresos = ingresos,
                Gastos = gastos,
                Total = ingresos.Sum(item => item.Monto) - gastos.Sum(item => item.Monto)
            });
        }
    }
}
