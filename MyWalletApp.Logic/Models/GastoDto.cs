﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class GastoDto : ITransaction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public ServicioDto Servicio { get; set; }
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public string Fecha { get; set; }
    }
}
