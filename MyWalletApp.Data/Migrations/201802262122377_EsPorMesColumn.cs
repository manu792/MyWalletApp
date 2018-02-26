namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EsPorMesColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicios", "EsPorMes", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicios", "EsPorMes");
        }
    }
}
