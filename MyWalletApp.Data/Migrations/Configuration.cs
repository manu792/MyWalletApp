namespace MyWalletApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyWalletApp.Data.MyWalletContext>
    {
        private MyWalletDatabaseInitializer dbInitializer;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            dbInitializer = new MyWalletDatabaseInitializer();
        }

        protected override void Seed(MyWalletApp.Data.MyWalletContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            dbInitializer.InitializeDatabase(context);
        }
    }
}
