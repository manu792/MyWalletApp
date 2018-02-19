using MyWalletApp.Data.Repositories;
using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic
{
    public class IngresoManager
    {
        private IngresoRepository repository;

        public IngresoManager()
        {
            repository = new IngresoRepository();
        }

        public IEnumerable<IngresoDto> GetAllIngresos()
        {
            var ingresos = repository.GetAllIngresos();

            return ingresos.Select(i => new IngresoDto()
            {
                Id = i.Id,
                Monto = i.Monto,
                Fuente = new FuenteDto()
                {
                    Id = i.Fuente.Id,
                    Nombre = i.Fuente.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }
    }
}
