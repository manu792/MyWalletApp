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
                Descripcion = i.Descripcion,
                Servicio = new ServicioDto()
                {
                    Id = i.Servicio.Id,
                    Nombre = i.Servicio.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public IEnumerable<GastoDto> GetGastosByDateRange(DateTime? start = null, DateTime? end = null)
        {
            if (start == null || end == null)
            {
                start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                end = DateTime.Now;
            }
            var ingresos = repository.GetGastosByDateRange(Convert.ToDateTime(start), Convert.ToDateTime(end));

            return ingresos.Select(i => new GastoDto()
            {
                Id = i.Id,
                Monto = i.Monto,
                Descripcion = i.Descripcion,
                Servicio = new ServicioDto()
                {
                    Id = i.Servicio.Id,
                    Nombre = i.Servicio.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public GastoDto SearchById(int id)
        {
            var gasto = repository.SearchById(id);

            if (gasto == null)
                return null;

            return new GastoDto()
            {
                Id = gasto.Id,
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                Servicio = new ServicioDto()
                {
                    Id = gasto.Servicio.Id,
                    Nombre = gasto.Servicio.Nombre
                },
                Fecha = gasto.Fecha
            };
        }

        public GastoDto AddGasto(GastoDto gasto)
        {
            repository.AddGasto(new Gasto()
            {
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                ServicioId = 1,
                Fecha = Convert.ToDateTime(gasto.Fecha)
            });

            return gasto;
        }

        public GastoDto UpdateGasto(GastoDto gasto)
        {
            repository.UpdateGasto(new Gasto()
            {
                Id = gasto.Id,
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                ServicioId = 1,
                Fecha = Convert.ToDateTime(gasto.Fecha)
            });

            return gasto;
        }

        public GastoDto DeleteGasto(GastoDto gasto)
        {
            var deletedGasto = repository.SearchById(gasto.Id);
            repository.DeleteGasto(deletedGasto);

            return gasto;
        }
    }
}
