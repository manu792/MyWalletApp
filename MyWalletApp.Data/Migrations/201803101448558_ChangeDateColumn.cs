namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicios", "FechaPago", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servicios", "FechaPago", c => c.DateTime(nullable: false));
        }
    }
}
