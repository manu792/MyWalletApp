using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Entities
{
    public class Fuente
    {
        public int Id { get; set; }
        [DisplayName("Nombre Fuente")]
        public string Nombre { get; set; }
    }
}
