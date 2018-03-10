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
        private static IEnumerable<ServicioDto> servicios;

        public ProyeccionController()
        {
            servicioManager = new ServicioManager();
        }

        // GET: Proyeccion
        public ActionResult Index()
        {
            servicios = servicioManager.GetMontlyServicios();

            var proyeccion = new ProyeccionServicioViewModel()
            {
                Proyecciones = servicios.Select(s => new ProyeccionDto()
                {
                    id = s.Id,
                    y = s.Monto,
                    fechaPago = s.FechaPago.Day.ToString(),
                    esPorMes = s.EsPorMes,
                    label = $"{s.Monto} colones",
                    indexLabel = s.Nombre
                }).ToList()
            };

            return View(proyeccion);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if(servicios.Any(s => s.Id == id))
                ((List<ServicioDto>)servicios).Remove(servicios.FirstOrDefault(s => s.Id == id));
            else
            {
                var servicio = servicioManager.SearchById(id);
                ((List<ServicioDto>)servicios).Add(servicio);
            }

            var proyeccion = new ProyeccionServicioViewModel()
            {
                Proyecciones = servicios.Select(s => new ProyeccionDto()
                {
                    id = s.Id,
                    y = s.Monto,
                    fechaPago = s.FechaPago.Day.ToString(),
                    esPorMes = s.EsPorMes,
                    label = $"{s.Monto} colones",
                    indexLabel = s.Nombre
                }).ToList()
            };

            var json = new JsonResult();
            json.Data = proyeccion;

            return json;
        }
    }
}
