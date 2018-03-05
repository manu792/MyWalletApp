using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class ProyeccionController : Controller
    {
        // GET: Proyeccion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Proyeccion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proyeccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyeccion/Create
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

        // GET: Proyeccion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proyeccion/Edit/5
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

        // GET: Proyeccion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proyeccion/Delete/5
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
