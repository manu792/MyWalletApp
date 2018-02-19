using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Repositories
{
    public class IngresoRepository
    {
        private MyWalletContext context;

        public IngresoRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Ingreso> GetAllIngresos()
        {
            return context.Ingresos.ToList();
        }

        public Ingreso AddIngreso(Ingreso ingreso)
        {
            context.Ingresos.Add(ingreso);
            context.SaveChanges();

            return ingreso;
        }

        public Ingreso SearchById(int id)
        {
            return context.Ingresos.Find(id);
        }

        public Ingreso UpdateIngreso(Ingreso ingreso)
        {
            context.Entry(ingreso).State = EntityState.Modified;
            context.SaveChanges();

            return ingreso;
        }

        public Ingreso DeleteIngreso(Ingreso ingreso)
        {
            context.Ingresos.Remove(ingreso);
            context.SaveChanges();

            return ingreso;
        }
    }
}
