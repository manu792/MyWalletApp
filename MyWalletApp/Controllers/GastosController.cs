using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using MyWalletApp.Models;
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
        private ServicioManager servicioManager;
        private IEnumerable<ServicioDto> serviciosDisponibles;

        public GastosController()
        {
            manager = new GastoManager();
            servicioManager = new ServicioManager();
            serviciosDisponibles = servicioManager.GetAllServicios();
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
            var servicios = serviciosDisponibles.Select(s => new SelectListItem()
            {
                Text = s.Nombre,
                Value = s.Id.ToString()
                
            }).ToList();

            return View(new GastoViewModel()
            {
                ServiciosDisponibles = servicios
            });
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(GastoViewModel gasto)
        {
            try
            {
                manager.AddGasto(new GastoDto()
                {
                    Id = gasto.Id,
                    Monto = (double)gasto.Monto,
                    Fecha = Convert.ToDateTime(gasto.Fecha),
                    Servicio = new ServicioDto()
                    {
                        Id = gasto.ServicioId
                    }
                });

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

            var servicios = serviciosDisponibles.Select(s => new SelectListItem()
            {
                Text = s.Nombre,
                Value = s.Id.ToString()

            }).ToList();

            if (gasto != null)
                return View(new GastoViewModel()
                {
                    Id = gasto.Id,
                    Monto = gasto.Monto,
                    Fecha = gasto.Fecha,
                    ServicioId = gasto.Servicio.Id,
                    ServiciosDisponibles = servicios
                });

            return HttpNotFound("El gasto no fue encontrado");
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GastoViewModel gasto)
        {
            try
            {
                manager.UpdateGasto(new GastoDto()
                {
                    Id = gasto.Id,
                    Monto = (double)gasto.Monto,
                    Fecha = Convert.ToDateTime(gasto.Fecha),
                    Servicio = new ServicioDto()
                    {
                        Id = gasto.ServicioId
                    }
                });

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
