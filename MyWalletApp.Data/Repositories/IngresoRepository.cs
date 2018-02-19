using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
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
    }
}
