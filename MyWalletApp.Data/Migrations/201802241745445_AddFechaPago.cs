namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFechaPago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicios", "FechaPago", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicios", "FechaPago");
        }
    }
}
