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
            servicios = servicioManager.GetNextMonthServiciosToPay();
            
            return View(GetProyeccion(servicios));
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

            
            var json = new JsonResult();
            json.Data = GetProyeccion(servicios);

            return json;
        }

        private ProyeccionServicioViewModel GetProyeccion(IEnumerable<ServicioDto> servicios)
        {
            var proyeccion = new ProyeccionServicioViewModel()
            {
                Proyecciones = servicios.Select(s => new ProyeccionDto()
                {
                    id = s.Id,
                    y = s.Monto,
                    fechaPago = s.EsPorMes ? $"{s.FechaPago}" : $"{s.FechaPago}",
                    esPorMes = s.EsPorMes,
                    label = $"{s.Monto} colones",
                    indexLabel = s.Nombre
                }).ToList()
            };

            return proyeccion;
        }
    }
}
