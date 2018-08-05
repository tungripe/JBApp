using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using JBApp.Migrations;

namespace JBApp.Models
{
    public class JBAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public JBAppContext() : base("JBAppContext")
        {
            //update database to the latest versions.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JBAppContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}