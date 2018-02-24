using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
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
    }
}
