﻿using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using MyWalletApp.Models;
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
        private FuenteManager fuenteManager;
        private IEnumerable<FuenteDto> fuentesDisponibles;

        public IngresosController()
        {
            manager = new IngresoManager();
            fuenteManager = new FuenteManager();
            fuentesDisponibles = fuenteManager.GetAllFuentes();
        }

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingresos = manager.GetAllIngresos();
            var lista = new List<SelectListItem>() { new SelectListItem() { Text = "Elija una fuente", Value = "-1" } };

            lista.AddRange(fuentesDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList());

            return View(new SearchViewModel<IngresoDto>()
            {
                Transacciones = ingresos,
                FuentesServiciosDisponibles = lista
            });
        }

        // POST: Ingresos
        [HttpPost]
        public ActionResult Index(SearchViewModel<IngresoDto> model)
        {
            var ingresos = manager.GetAllIngresos();
            var lista = new List<SelectListItem>() { new SelectListItem() { Text = "Elija una fuente", Value = "-1" } };

            lista.AddRange(fuentesDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList());

            if (model.FechaDesde != null && model.FechaHasta != null)
                ingresos = ingresos.Where(i => i.Fecha >= model.FechaDesde && i.Fecha <= model.FechaHasta);
            if (model.FuenteId != -1)
                ingresos = ingresos.Where(i => i.Fuente.Id == model.FuenteId);

            return View(new SearchViewModel<IngresoDto>()
            {
                Transacciones = ingresos,
                FuentesServiciosDisponibles = lista
            });
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int id)
        {
            var ingreso = manager.SearchById(id);

            if (ingreso != null)
                return View(new IngresoViewModel()
                {
                    Ingreso = new IngresoDto()
                    {
                        Id = ingreso.Id,
                        Monto = ingreso.Monto,
                        Fecha = ingreso.Fecha,
                        Fuente = new FuenteDto()
                        {
                            Id = ingreso.Fuente.Id,
                            Nombre = ingreso.Fuente.Nombre
                        }
                    }
                });

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            var list = fuentesDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList();
            
            return View(new IngresoViewModel() { FuentesDisponibles = list });
        }

        // POST: Ingresos/Create
        [HttpPost]
        public ActionResult Create(IngresoViewModel ingresoViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            
            try
            {
                manager.AddIngreso(new IngresoDto()
                {
                    Monto = (double)ingresoViewModel.Ingreso.Monto,
                    Fuente = new FuenteDto()
                    {
                        Id = ingresoViewModel.Ingreso.Fuente.Id
                    },
                    Fecha = Convert.ToDateTime(ingresoViewModel.Ingreso.Fecha)
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message.ToString());
                return View();
            }
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int id)
        {
            var list = fuentesDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList();

            var ingreso = manager.SearchById(id);

            if(ingreso != null)
                return View(new IngresoViewModel()
                {
                    Ingreso = new IngresoDto()
                    {
                        Id = ingreso.Id,
                        Monto = ingreso.Monto,
                        Fuente = ingreso.Fuente,
                        Fecha = ingreso.Fecha,
                    },
                    FuentesDisponibles = list
                });

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // POST: Ingresos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IngresoViewModel ingresoViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                manager.UpdateIngreso(id, new IngresoDto()
                {
                    Id = ingresoViewModel.Ingreso.Id,
                    Monto = (double)ingresoViewModel.Ingreso.Monto,
                    Fuente = new FuenteDto()
                    {
                        Id = ingresoViewModel.Ingreso.Fuente.Id
                    },
                    Fecha = Convert.ToDateTime(ingresoViewModel.Ingreso.Fecha)
                });

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
                return View(new IngresoViewModel()
                {
                    Ingreso = new IngresoDto()
                    {
                        Id = ingreso.Id,
                        Monto = ingreso.Monto,
                        Fecha = ingreso.Fecha,
                        Fuente = new FuenteDto()
                        {
                            Id = ingreso.Fuente.Id,
                            Nombre = ingreso.Fuente.Nombre
                        }
                    }
                });

            return HttpNotFound("El ingreso no fue encontrado");
        }

        // POST: Ingresos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IngresoViewModel ingresoViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var ingreso = manager.SearchById(id);

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
