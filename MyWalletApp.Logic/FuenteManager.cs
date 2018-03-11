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
    public class FuenteManager
    {
        private FuenteRepository repository;

        public FuenteManager()
        {
            repository = new FuenteRepository();
        }

        public IEnumerable<FuenteDto> GetAllFuentes()
        {
            var fuentes = repository.GetAllFuentes().OrderBy(f => f.Nombre.ToLower().Equals("otro")).ThenBy(f => f.Id);

            return fuentes.Select(i => new FuenteDto()
            {
                Id = i.Id,
                Nombre = i.Nombre
            }).ToList();
        }

        public FuenteDto AddFuente(FuenteDto fuente)
        {
            repository.AddFuente(new Fuente()
            {
                Nombre = fuente.Nombre
            });

            return fuente;
        }

        public FuenteDto SearchById(int id)
        {
            var servicio = repository.SearchById(id);

            if (servicio == null)
                return null;

            return new FuenteDto()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre
            };
        }

        public FuenteDto UpdateFuente(int id, FuenteDto fuente)
        {
            repository.UpdateFuente(new Fuente()
            {
                Id = fuente.Id,
                Nombre = fuente.Nombre,
            });

            return fuente;
        }

        public FuenteDto DeleteFuente(FuenteDto fuente)
        {
            var deleteFuente = repository.SearchById(fuente.Id);
            repository.DeleteFuente(deleteFuente);

            return fuente;
        }
    }
}
