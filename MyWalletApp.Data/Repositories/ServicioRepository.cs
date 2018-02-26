using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Repositories
{
    public class ServicioRepository
    {
        private MyWalletContext context;

        public ServicioRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            return context.Servicios.ToList();
        }

        public Servicio AddServicio(Servicio servicio)
        {
            context.Servicios.Add(servicio);
            context.SaveChanges();

            return servicio;
        }

        public Servicio SearchById(int id)
        {
            return context.Servicios.Find(id);
        }

        public Servicio UpdateServicio(Servicio servicio)
        {
            context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return servicio;
        }

        public Servicio DeleteServicio(Servicio servicio)
        {
            context.Servicios.Remove(servicio);
            context.SaveChanges();

            return servicio;
        }

        public IEnumerable<Servicio> GetServiciosWithinNextFiveDays()
        {
            var today = DateTime.Now;
            var until = DateTime.Now.AddDays(5);
            List<Servicio> serviciosProximos = new List<Servicio>();

            serviciosProximos.AddRange(context.Servicios.Where(s => !s.EsPorMes &&
                s.FechaPago >= today && s.FechaPago <= until).ToList());
            

            if (today.Month == until.Month)
            {
                serviciosProximos.AddRange(context.Servicios
                .Where(g => g.EsPorMes && g.FechaPago.Day >= today.Day && g.FechaPago.Day <= until.Day)
                .ToList());
            }
            else
            {
                serviciosProximos.AddRange(context.Servicios
                .Where(g => g.EsPorMes && g.FechaPago.Day >= DateTime.Now.Day && g.FechaPago.Day <= 31 ||
                       g.EsPorMes && g.FechaPago.Day >= 1 && g.FechaPago.Day <= until.Day)
                .ToList());
            }

            return serviciosProximos;
        }
    }
}
