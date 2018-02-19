using MyWalletApp.Data.Repositories;
using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic
{
    public class GastoManager
    {
        private GastoRepository repository;

        public GastoManager()
        {
            repository = new GastoRepository();
        }

        public IEnumerable<GastoDto> GetAllGastos()
        {
            var ingresos = repository.GetAllGastos();

            return ingresos.Select(i => new GastoDto()
            {
                Id = i.Id,
                Monto = i.Monto,
                Servicio = new ServicioDto()
                {
                    Id = i.Servicio.Id,
                    Nombre = i.Servicio.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }
    }
}
