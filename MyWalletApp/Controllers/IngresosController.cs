using MyWalletApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class IngresosController : Controller
    {
        private IngresoManager manager;

        public IngresosController()
        {
            manager = new IngresoManager();
        }

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingresos = manager.GetAllIngresos();
            return View(ingresos);
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingresos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingresos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingresos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
