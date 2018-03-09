using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWalletApp.Models
{
    public class ProyeccionServicioViewModel
    {
        public IEnumerable<ProyeccionDto> Proyecciones { get; set; }
    }
}