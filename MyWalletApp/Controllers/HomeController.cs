using MyWalletApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class HomeController : Controller
    {
        private IngresoManager ingresoManager;
        private GastoManager gastoManager;

        public HomeController()
        {
            ingresoManager = new IngresoManager();
            gastoManager = new GastoManager();
        }

        // GET: Home
        public ActionResult Index()
        {
            var ingresos = ingresoManager.GetAllIngresos();
            var gastos = gastoManager.GetAllGastos();

            var montoReal = ingresos.Sum(i => i.Monto) - gastos.Sum(g => g.Monto);

            ViewBag.Billetera = string.Format("{0:n0}", montoReal);

            return View();
        }
    }
}
