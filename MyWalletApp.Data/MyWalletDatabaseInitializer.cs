using MyWalletApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Data
{
    public class MyWalletDatabaseInitializer : DropCreateDatabaseIfModelChanges<MyWalletContext>
    {
        private MyWalletContext dbContext;
        protected override void Seed(MyWalletContext context)
        {
            dbContext = context;

            SeedServicios();
            SeedFuentes();
            base.Seed(context);
        }

        private void SeedFuentes()
        {
            dbContext.Fuentes.AddRange(new List<Fuente>()
            {
                new Fuente()
                {
                    Id = 1,
                    Nombre = "Salario"
                },
                new Fuente()
                {
                    Id = 2,
                    Nombre = "Transaccion"
                },
                new Fuente()
                {
                    Id = 3,
                    Nombre = "Otro"
                }
            });
            dbContext.SaveChanges();
        }

        private void SeedServicios()
        {
            dbContext.Servicios.AddRange(new List<Servicio>()
                    {
                        new Servicio
                        {
                            Id = 1,
                            Nombre = "Netflix",
                            FechaPago = Convert.ToDateTime("2017-02-24")
                        },
                        new Servicio
                        {
                            Id = 2,
                            Nombre = "HBO GO",
                            FechaPago = Convert.ToDateTime("2017-02-20")
                        },
                        new Servicio
                        {
                            Id = 3,
                            Nombre = "Agua",
                            FechaPago = Convert.ToDateTime("2017-02-15")
                        },
                        new Servicio
                        {
                            Id = 4,
                            Nombre = "Luz",
                            FechaPago = Convert.ToDateTime("2017-02-02")
                        },
                        new Servicio
                        {
                            Id = 5,
                            Nombre = "Celular",
                            FechaPago = Convert.ToDateTime("2017-02-15")
                        },
                        new Servicio
                        {
                            Id = 6,
                            Nombre = "Cable",
                            FechaPago = Convert.ToDateTime("2017-02-23")
                        },
                        new Servicio
                        {
                            Id = 7,
                            Nombre = "Prestamo carro",
                            FechaPago = Convert.ToDateTime("2017-02-15")
                        }
                    });
            dbContext.SaveChanges();
        }
    }
}
