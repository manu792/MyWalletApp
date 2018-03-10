using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class ServicioController : Controller
    {
        private ServicioManager servicioManager;

        public ServicioController()
        {
            servicioManager = new ServicioManager();
        }

        // GET: Servicio
        public ActionResult Index()
        {
            var servicios = servicioManager.GetAllServicios().Where(s => !s.Nombre.ToLower().Equals("otro"));
            return View(servicios);
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            var servicio = servicioManager.SearchById(id);
            var date = DateTime.ParseExact(servicio.FechaPago, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            servicio.FechaPago = servicio.EsPorMes ? $"{date.Day.ToString()}"
                : $"{date.ToString("dd/MM")}";

            if (servicio == null)
                return HttpNotFound();

            return View(servicio);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(ServicioDto servicio)
        {
            try
            {
                servicioManager.AddServicio(servicio);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());

                return View();
            }
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id)
        {
            var servicio = servicioManager.SearchById(id);

            if (servicio == null)
                return HttpNotFound();

            return View(servicio);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServicioDto servicioDto)
        {
            try
            {
                servicioManager.UpdateServicio(id, servicioDto);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());

                return View();
            }
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int id)
        {
            var servicio = servicioManager.SearchById(id);

            if (servicio == null)
                return HttpNotFound();

            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ServicioDto servicio)
        {
            try
            {
                servicioManager.DeleteServicio(servicio);

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
