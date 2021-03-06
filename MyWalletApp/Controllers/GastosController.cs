﻿using MyWalletApp.Logic;
using MyWalletApp.Logic.Models;
using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var proximosPagos = servicioManager.GetServiciosWithinNextFiveDays();

            var lista = new List<SelectListItem>() { new SelectListItem() { Text = "Elija un servicio", Value = "-1" } };
            lista.AddRange(serviciosDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList());

            var newGastos = new SearchViewModel<GastoDto>()
            {
                Transacciones = gastos,
                FuentesServiciosDisponibles = lista,
                ProximosPagos = proximosPagos
            };

            return View(newGastos);
        }

        // POST: Gastos
        [HttpPost]
        public ActionResult Index(SearchViewModel<GastoDto> searchViewModel)
        {
            var gastos = manager.GetAllGastos();
            var proximosPagos = servicioManager.GetServiciosWithinNextFiveDays();
            var lista = new List<SelectListItem>() { new SelectListItem() { Text = "Elija un servicio", Value = "-1" } };

            lista.AddRange(serviciosDisponibles.Select(f => new SelectListItem()
            {
                Text = f.Nombre,
                Value = f.Id.ToString()
            }).ToList());

            if (string.IsNullOrEmpty(searchViewModel.FechaDesde))
                searchViewModel.FechaDesde = "01/01/1970";
            if (string.IsNullOrEmpty(searchViewModel.FechaHasta))
                searchViewModel.FechaHasta = DateTime.Now.ToString("dd/MM/yyyy");
            
            gastos = gastos.Where(i => DateTime.ParseExact(i.Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(searchViewModel.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(i.Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(searchViewModel.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            if (searchViewModel.FuenteId != -1)
                gastos = gastos.Where(i => i.Servicio.Id == searchViewModel.FuenteId);

            return View(new SearchViewModel<GastoDto>()
            {
                Transacciones = gastos,
                FuentesServiciosDisponibles = lista,
                ProximosPagos = proximosPagos
            });
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int id)
        {
            var gasto = manager.SearchById(id);

            if (gasto != null)
                return View(new GastoViewModel()
                {
                    Gasto = new GastoDto()
                    {
                        Id = gasto.Id,
                        Monto = gasto.Monto,
                        Descripcion = gasto.Descripcion,
                        Fecha = gasto.Fecha,
                        Servicio = new ServicioDto()
                        {
                            Id = gasto.Servicio.Id,
                            Nombre = gasto.Servicio.Nombre,
                            FechaPago = gasto.Servicio.FechaPago
                        }
                    }
                });

            return HttpNotFound("El gasto no fue encontrado");
        }

        [HttpGet]
        public ActionResult SearchById(int id)
        {
            var gasto = serviciosDisponibles.FirstOrDefault(s => s.Id == id);

            if (gasto != null)
            {
                var json = new JsonResult();
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                json.Data = gasto;

                return json;
            }

            return HttpNotFound("El gasto no fue encontrado");
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            var servicios = serviciosDisponibles.Select(s => new SelectListItem()
            {
                Text = s.Nombre,
                Value = s.Id.ToString(),
                Selected = s.Id == 1 ? true : false

            }).ToList();

            return View(new GastoViewModel()
            {
                ServiciosDisponibles = servicios
            });
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(GastoViewModel gastoViewModel)
        {
            try
            {
                manager.AddGasto(new GastoDto()
                {
                    Id = gastoViewModel.Gasto.Id,
                    Monto = (double)gastoViewModel.Gasto.Monto,
                    Descripcion = gastoViewModel.Gasto.Descripcion,
                    Fecha = gastoViewModel.Gasto.Fecha,
                    Servicio = new ServicioDto()
                    {
                        Id = gastoViewModel.Gasto.Servicio.Id,
                        Nombre = gastoViewModel.Gasto.Servicio.Nombre,
                        FechaPago = gastoViewModel.Gasto.Servicio.FechaPago
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
                Value = s.Id.ToString(),
                Selected = s.Id == 1 ? true : false

            }).ToList();

            if (gasto != null)
                return View(new GastoViewModel()
                {
                    Gasto = new GastoDto()
                    {
                        Id = gasto.Id,
                        Monto = gasto.Monto,
                        Descripcion = gasto.Descripcion,
                        Fecha = gasto.Fecha,
                        Servicio = new ServicioDto()
                        {
                            Id = gasto.Servicio.Id,
                            Nombre = gasto.Servicio.Nombre,
                            FechaPago = gasto.Servicio.FechaPago
                        }
                    },
                    ServiciosDisponibles = servicios
                });

            return HttpNotFound("El gasto no fue encontrado");
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GastoViewModel gastoViewModel)
        {
            try
            {
                manager.UpdateGasto(new GastoDto()
                {
                    Id = gastoViewModel.Gasto.Id,
                    Monto = (double)gastoViewModel.Gasto.Monto,
                    Descripcion = gastoViewModel.Gasto.Descripcion,
                    Fecha = gastoViewModel.Gasto.Fecha,
                    Servicio = new ServicioDto()
                    {
                        Id = gastoViewModel.Gasto.Servicio.Id
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
                return View(new GastoViewModel()
                {
                    Gasto = new GastoDto()
                    {
                        Id = gasto.Id,
                        Monto = gasto.Monto,
                        Descripcion = gasto.Descripcion,
                        Fecha = gasto.Fecha,
                        Servicio = new ServicioDto()
                        {
                            Id = gasto.Servicio.Id,
                            Nombre = gasto.Servicio.Nombre,
                            FechaPago = gasto.Servicio.FechaPago
                        }
                    }
                });

            return HttpNotFound("El gasto no fue encontrado");
        }

        // POST: Gastos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GastoViewModel gastoViewModel)
        {
            try
            {
                var gasto = manager.SearchById(id);
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
