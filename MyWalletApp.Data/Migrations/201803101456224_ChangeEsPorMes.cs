namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEsPorMes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicios", "EsPorMes", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servicios", "EsPorMes", c => c.Boolean(nullable: false));
        }
    }
}
