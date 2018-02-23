using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Repositories
{
    public class FuenteRepository
    {
        private MyWalletContext context;

        public FuenteRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Fuente> GetAllFuentes()
        {
            return context.Fuentes.ToList();
        }
    }
}
