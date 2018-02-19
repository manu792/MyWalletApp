using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public class FuenteDto
    {
        public int Id { get; set; }
        [DisplayName("Nombre Fuente")]
        public string Nombre { get; set; }
    }
}
