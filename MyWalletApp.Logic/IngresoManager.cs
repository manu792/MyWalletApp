using MyWalletApp.Data.Entities;
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

        public IngresoDto AddIngreso(IngresoDto ingreso)
        {
            repository.AddIngreso(new Ingreso()
            {
                Monto = ingreso.Monto,
                FuenteId = ingreso.Fuente.Id,
                Fecha = Convert.ToDateTime(ingreso.Fecha)
            });

            return ingreso;
        }

        public IngresoDto SearchById(int id)
        {
            var ingreso = repository.SearchById(id);

            if (ingreso == null)
                return null;

            return new IngresoDto()
            {
                Id = ingreso.Id,
                Monto = ingreso.Monto,
                Fuente = new FuenteDto()
                {
                    Id = ingreso.Fuente.Id,
                    Nombre = ingreso.Fuente.Nombre
                },
                Fecha = ingreso.Fecha
            };
        }

        public IngresoDto UpdateIngreso(int id, IngresoDto ingreso)
        {
            repository.UpdateIngreso(new Ingreso()
            {
                Id = ingreso.Id,
                Fecha = Convert.ToDateTime(ingreso.Fecha),
                FuenteId = ingreso.Fuente.Id,
                Monto = ingreso.Monto
            });

            return ingreso;
        }

        public IngresoDto DeleteIngreso(IngresoDto ingreso)
        {
            var deletedIngreso = repository.SearchById(ingreso.Id);

            repository.DeleteIngreso(deletedIngreso);

            return ingreso;
        }
    }
}
