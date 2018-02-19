using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class GastosController : Controller
    {
        private GastoManager manager;

        public GastosController()
        {
            manager = new GastoManager();
        }

        // GET: Gastos
        public ActionResult Index()
        {
            var gastos = manager.GetAllGastos();
            return View(gastos);
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int id)
        {
            var gasto = manager.SearchById(id);

            if (gasto != null)
                return View(gasto);

            return HttpNotFound("El gasto no fue encontrado");
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(GastoDto gasto)
        {
            try
            {
                manager.AddGasto(gasto);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int id)
        {
            var gasto = manager.SearchById(id);

            if (gasto != null)
                return View(gasto);

            return HttpNotFound("El gasto no fue encontrado");
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GastoDto gasto)
        {
            try
            {
                manager.UpdateGasto(gasto);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int id)
        {
            var gasto = manager.SearchById(id);

            if (gasto != null)
                return View(gasto);

            return HttpNotFound("El gasto no fue encontrado");
        }

        // POST: Gastos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GastoDto gasto)
        {
            try
            {
                manager.DeleteGasto(gasto);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }
    }
}
