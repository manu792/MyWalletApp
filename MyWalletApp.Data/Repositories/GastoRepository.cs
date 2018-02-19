using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Repositories
{
    public class GastoRepository
    {
        private MyWalletContext context;

        public GastoRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Gasto> GetAllGastos()
        {
            return context.Gastos.ToList();
        }
    }
}
