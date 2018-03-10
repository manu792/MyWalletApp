using MyWalletApp.Logic;
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

            if (string.IsNullOrEmpty(model.FechaDesde))
                model.FechaDesde = "01/01/1970";
            if (string.IsNullOrEmpty(model.FechaHasta))
                model.FechaHasta = DateTime.Now.ToString("dd/MM/yyyy");

            ingresos = ingresos.Where(i => DateTime.ParseExact(i.Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(model.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(i.Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(model.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture));

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
                        Descripcion = ingreso.Descripcion,
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
                Value = f.Id.ToString(),
                Selected = f.Id == 1 ? true : false
            }).ToList();
            
            return View(new IngresoViewModel() { FuentesDisponibles = list });
        }

        // POST: Ingresos/Create
        [HttpPost]
        public ActionResult Create(IngresoViewModel ingresoViewModel)
        {
            ModelState.Clear();
            var fuente = fuenteManager.SearchById(ingresoViewModel.Ingreso.Fuente.Id);

            ingresoViewModel.Ingreso.Fuente.Nombre = fuente.Nombre;

            if (!TryValidateModel(ingresoViewModel))
            {
                var list = fuentesDisponibles.Select(f => new SelectListItem()
                {
                    Text = f.Nombre,
                    Value = f.Id.ToString(),
                    Selected = f.Id == 1 ? true : false
                }).ToList();

                ingresoViewModel.FuentesDisponibles = list;
                return View(ingresoViewModel);
            }
            
            try
            {
                manager.AddIngreso(new IngresoDto()
                {
                    Monto = (double)ingresoViewModel.Ingreso.Monto,
                    Descripcion = ingresoViewModel.Ingreso.Descripcion,
                    Fuente = new FuenteDto()
                    {
                        Id = ingresoViewModel.Ingreso.Fuente.Id
                    },
                    Fecha = ingresoViewModel.Ingreso.Fecha
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
                Value = f.Id.ToString(),
                Selected = f.Id == 1 ? true : false
            }).ToList();

            var ingreso = manager.SearchById(id);

            if(ingreso != null)
                return View(new IngresoViewModel()
                {
                    Ingreso = new IngresoDto()
                    {
                        Id = ingreso.Id,
                        Monto = ingreso.Monto,
                        Descripcion = ingreso.Descripcion,
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
            ModelState.Clear();
            var fuente = fuenteManager.SearchById(ingresoViewModel.Ingreso.Fuente.Id);

            ingresoViewModel.Ingreso.Fuente.Nombre = fuente.Nombre;

            if (!TryValidateModel(ingresoViewModel))
            {
                var list = fuentesDisponibles.Select(f => new SelectListItem()
                {
                    Text = f.Nombre,
                    Value = f.Id.ToString(),
                    Selected = f.Id == 1 ? true : false
                }).ToList();

                ingresoViewModel.FuentesDisponibles = list;
                return View(ingresoViewModel);
            }

            try
            {
                manager.UpdateIngreso(id, new IngresoDto()
                {
                    Id = ingresoViewModel.Ingreso.Id,
                    Monto = (double)ingresoViewModel.Ingreso.Monto,
                    Descripcion = ingresoViewModel.Ingreso.Descripcion,
                    Fuente = new FuenteDto()
                    {
                        Id = ingresoViewModel.Ingreso.Fuente.Id
                    },
                    Fecha = ingresoViewModel.Ingreso.Fecha
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
                        Descripcion = ingreso.Descripcion,
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
