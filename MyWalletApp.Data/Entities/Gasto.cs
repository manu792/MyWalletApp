using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data.Entities
{
    [Table("Gastos")]
    public class Gasto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; }

        // Navigation property
        public virtual Servicio Servicio { get; set; }
    }
}
