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
    public class ProyeccionController : Controller
    {
        private ServicioManager servicioManager;

        public ProyeccionController()
        {
            servicioManager = new ServicioManager();
        }

        // GET: Proyeccion
        public ActionResult Index()
        {
            var servicios = servicioManager.GetMontlyServicios();

            var proyeccion = new ProyeccionServicioViewModel()
            {
                Proyecciones = servicios.Select(s => new ProyeccionDto()
                {
                    id = s.Id,
                    y = s.Id,
                    fechaPago = s.FechaPago.Day.ToString(),
                    esPorMes = s.EsPorMes,
                    label = $"{s.Id} colones",
                    indexLabel = s.Nombre
                }).ToList()
            };

            return View(proyeccion);
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var servicios = servicioManager.GetMontlyServicios();
            var lista = (List<ServicioDto>)servicios;

            lista.Remove(servicios.FirstOrDefault(s => s.Id == id));

            var proyeccion = new ProyeccionServicioViewModel()
            {
                Proyecciones = lista.Select(s => new ProyeccionDto()
                {
                    id = s.Id,
                    y = s.Id,
                    fechaPago = s.FechaPago.Day.ToString(),
                    esPorMes = s.EsPorMes,
                    label = $"{s.Id} colones",
                    indexLabel = s.Nombre
                }).ToList()
            };

            return View("Index", proyeccion);
        }
    }
}
