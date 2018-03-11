using MyWalletApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWalletApp.Controllers
{
    public class NotificationController : Controller
    {
        private ServicioManager servicioManager;

        public NotificationController()
        {
            servicioManager = new ServicioManager();
        }

        // GET: Notification
        public ActionResult GetNotifications()
        {
            var proximosPagos = servicioManager.GetServiciosWithinNextFiveDays();
            var json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = proximosPagos;

            return json;
        }
    }
}
