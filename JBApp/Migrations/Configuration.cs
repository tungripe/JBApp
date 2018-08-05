namespace JBApp.Migrations
{
    using JBApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JBApp.Models.JBAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "JBApp.Models.JBAppContext";
        }

        protected override void Seed(JBApp.Models.JBAppContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (context.Products.Count() == 0)
            {
                context.Products.Add(new Product() { Id = "1", Brand = "Samsung", Description = "Samsung Phone", Model = "Samsung galaxy" });
                context.Products.Add(new Product() { Id = "2", Brand = "Apple", Description = "Iphone", Model = "Iphone 7" });
                context.Products.Add(new Product() { Id = "3", Brand = "Sony", Description = "Sony Phone", Model = "TV" });
            }
        }
    }
}
