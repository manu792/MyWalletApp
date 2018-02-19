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
                Nombre = s.Nombre
            }).ToList();
        }
    }
}
