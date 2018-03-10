using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Logic.Models
{
    public interface ITransaction
    {
        double Monto { get; set; }
        string Fecha { get; set; }
    }
}
