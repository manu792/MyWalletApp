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
                FechaPago = s.FechaPago
            }).ToList();
        }

        public ServicioDto AddServicio(ServicioDto servicio)
        {
            repository.AddServicio(new Servicio()
            {
                Nombre = servicio.Nombre,
                FechaPago = servicio.FechaPago
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
                FechaPago = servicio.FechaPago
            };
        }

        public ServicioDto UpdateServicio(int id, ServicioDto servicio)
        {
            repository.UpdateServicio(new Servicio()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                FechaPago = servicio.FechaPago
            });

            return servicio;
        }

        public ServicioDto DeleteServicio(ServicioDto servicio)
        {
            repository.DeleteServicio(new Servicio()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                FechaPago = servicio.FechaPago
            });

            return servicio;
        }
    }
}
