using MyWalletApp.Logic;
using MyWalletApp.Models;
using System;
using System.Collections.Generic;
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
            var ingresos = ingresoManager.GetAllIngresos();
            var gastos = gastoManager.GetAllGastos();


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
            var ingresos = ingresoManager.GetAllIngresos();
            var gastos = gastoManager.GetAllGastos();

            if (comparativa.FechaDesde != null && comparativa.FechaHasta != null)
            {
                ingresos = ingresos.Where(i => i.Fecha >= comparativa.FechaDesde && i.Fecha <= comparativa.FechaHasta);
                gastos = gastos.Where(g => g.Fecha >= comparativa.FechaDesde && g.Fecha <= comparativa.FechaHasta);
            }

            return View(new Comparativa()
            {
                Ingresos = ingresos,
                Gastos = gastos,
                Total = ingresos.Sum(item => item.Monto) - gastos.Sum(item => item.Monto)
            });
        }
    }
}
