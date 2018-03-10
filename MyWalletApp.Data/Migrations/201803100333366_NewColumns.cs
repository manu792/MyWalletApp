namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gastos", "Descripcion", c => c.String());
            AddColumn("dbo.Servicios", "Monto", c => c.Double(nullable: false));
            AddColumn("dbo.Ingresos", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingresos", "Descripcion");
            DropColumn("dbo.Servicios", "Monto");
            DropColumn("dbo.Gastos", "Descripcion");
        }
    }
}
