using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data
{
    public class MyWalletContext : DbContext
    {
        public MyWalletContext() : base("MyWalletDBAzure")
        {
            Database.SetInitializer(new MyWalletDatabaseInitializer());
        }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Fuente> Fuentes { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
