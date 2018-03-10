using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class FuenteController : Controller
    {
        private FuenteManager fuenteManager;

        public FuenteController()
        {
            fuenteManager = new FuenteManager();
        }

        // GET: Fuente
        public ActionResult Index()
        {
            var fuentes = fuenteManager.GetAllFuentes().Where(f => !f.Nombre.ToLower().Equals("otro"));
            return View(fuentes);
        }

        // GET: Fuente/Details/5
        public ActionResult Details(int id)
        {
            var fuente = fuenteManager.SearchById(id);

            if (fuente == null)
                return HttpNotFound();

            return View(fuente);
        }

        // GET: Fuente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuente/Create
        [HttpPost]
        public ActionResult Create(FuenteDto fuente)
        {
            try
            {
                fuenteManager.AddFuente(fuente);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());

                return View();
            }
        }

        // GET: Fuente/Edit/5
        public ActionResult Edit(int id)
        {
            var fuente = fuenteManager.SearchById(id);

            if (fuente == null)
                return HttpNotFound();

            return View(fuente);
        }

        // POST: Fuente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FuenteDto fuente)
        {
            try
            {
                fuenteManager.UpdateFuente(id, fuente);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());

                return View();
            }
        }

        // GET: Fuente/Delete/5
        public ActionResult Delete(int id)
        {
            var fuente = fuenteManager.SearchById(id);

            if (fuente == null)
                return HttpNotFound();

            return View(fuente);
        }

        // POST: Fuente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FuenteDto fuente)
        {
            try
            {
                fuenteManager.DeleteFuente(fuente);

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
