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
            var fuentes = repository.GetAllFuentes();

            return fuentes.Select(i => new FuenteDto()
            {
                Id = i.Id,
                Nombre = i.Nombre
            }).ToList();
        }
    }
}
