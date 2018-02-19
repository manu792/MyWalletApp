using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
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
            var ingreso = manager.SearchById(id);

            if (ingreso != null)
                return View(ingreso);

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingresos/Create
        [HttpPost]
        public ActionResult Create(IngresoDto ingreso)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                manager.AddIngreso(ingreso);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int id)
        {
            var ingreso = manager.SearchById(id);

            if(ingreso != null)
                return View(ingreso);

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // POST: Ingresos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IngresoDto ingreso)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                manager.UpdateIngreso(id, ingreso);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int id)
        {
            var ingreso = manager.SearchById(id);

            if (ingreso != null)
                return View(ingreso);

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // POST: Ingresos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IngresoDto ingreso)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                manager.DeleteIngreso(ingreso);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
