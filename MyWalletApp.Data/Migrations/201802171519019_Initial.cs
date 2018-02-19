namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fuentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Double(nullable: false),
                        ServicioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servicios", t => t.ServicioId, cascadeDelete: true)
                .Index(t => t.ServicioId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingresos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Double(nullable: false),
                        FuenteId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fuentes", t => t.FuenteId, cascadeDelete: true)
                .Index(t => t.FuenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingresos", "FuenteId", "dbo.Fuentes");
            DropForeignKey("dbo.Gastos", "ServicioId", "dbo.Servicios");
            DropIndex("dbo.Ingresos", new[] { "FuenteId" });
            DropIndex("dbo.Gastos", new[] { "ServicioId" });
            DropTable("dbo.Ingresos");
            DropTable("dbo.Servicios");
            DropTable("dbo.Gastos");
            DropTable("dbo.Fuentes");
        }
    }
}
