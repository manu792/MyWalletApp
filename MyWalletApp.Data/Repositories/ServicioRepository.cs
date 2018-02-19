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
    }
}
