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
    public class ServicioManager
    {
        private ServicioRepository repository;

        public ServicioManager()
        {
            repository = new ServicioRepository();
        }

        public IEnumerable<ServicioDto> GetAllServicios()
        {
            var servicios = repository.GetAllServicios();

            return servicios.Select(s => new ServicioDto()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = s.EsPorMes
            }).ToList();
        }

        public ServicioDto AddServicio(ServicioDto servicio)
        {
            repository.AddServicio(new Servicio()
            {
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = (DateTime)servicio.FechaPago,
                EsPorMes = servicio.EsPorMes
            });

            return servicio;
        }

        public ServicioDto SearchById(int id)
        {
            var servicio = repository.SearchById(id);

            if (servicio == null)
                return null;

            return new ServicioDto()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = servicio.FechaPago,
                EsPorMes = servicio.EsPorMes
            };
        }

        public ServicioDto UpdateServicio(int id, ServicioDto servicio)
        {
            repository.UpdateServicio(new Servicio()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = (DateTime)servicio.FechaPago,
                EsPorMes = servicio.EsPorMes
            });

            return servicio;
        }

        public ServicioDto DeleteServicio(ServicioDto servicio)
        {
            var deleteServicio = repository.SearchById(servicio.Id);
            repository.DeleteServicio(deleteServicio);

            return servicio;
        }

        public IEnumerable<ServicioDto> GetServiciosWithinNextFiveDays()
        {
            var servicios = repository.GetServiciosWithinNextFiveDays();

            return servicios.Select(s => new ServicioDto()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = s.EsPorMes
            }).ToList();
        }

        public IEnumerable<ServicioDto> GetMontlyServicios()
        {
            var servicios = repository.GetMontlyServicios();

            return servicios.Select(s => new ServicioDto()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = s.EsPorMes
            }).ToList();
        }
    }
}
